using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.Repositories
{
    /// <summary>
    /// Xác thực tài khoản: dùng SecurityHelper.VerifyPassword (hỗ trợ BCrypt + SHA256 + plaintext).
    /// Khi user login bằng hash cũ (SHA256/plaintext), tự động UPGRADE sang BCrypt — chỉ làm 1 lần/user.
    /// </summary>
    internal static class AuthRepository
    {
        public static DataRow Authenticate(string usernameOrEmployeeCode, string rawPassword)
        {
            if (string.IsNullOrWhiteSpace(rawPassword)) return null;
            const string sql = @"
                SELECT nv.MaNhanVien, nv.TenDangNhap, nv.HoTen, nv.MaVaiTro,
                       vt.TenVaiTro, nv.MatKhau
                FROM   NhanVien nv
                INNER JOIN VaiTro vt ON nv.MaVaiTro = vt.MaVaiTro
                WHERE  nv.TrangThai = 1
                  AND  (nv.TenDangNhap = @login OR nv.MaNhanVien = @login)";

            DataTable dt = Function.GetDataToTable(sql,
                new SqlParameter("@login", usernameOrEmployeeCode.Trim()));
            if (dt == null || dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            string storedHash = row["MatKhau"]?.ToString() ?? "";

            // Verify (BCrypt / SHA256 / plaintext) — không bao giờ so plaintext trực tiếp với production data
            bool ok = SecurityHelper.VerifyPassword(rawPassword, storedHash);
            if (!ok) return null;

            // Auto-migrate: nếu hash trong DB còn ở format cũ -> nâng cấp sang BCrypt
            if (SecurityHelper.NeedsRehash(storedHash))
            {
                TryUpgradeHashToBCrypt(row["MaNhanVien"]?.ToString(), rawPassword);
            }

            dt.Columns.Remove("MatKhau");
            return dt.Rows[0];
        }

        /// <summary>Xác thực bằng MaNhanVien (dùng khi đã đăng nhập rồi đổi mật khẩu).</summary>
        public static DataRow AuthenticateByMaNV(string maNhanVien, string rawPassword)
        {
            if (string.IsNullOrWhiteSpace(rawPassword)) return null;
            const string sql = @"
                SELECT MaNhanVien, MatKhau
                FROM   NhanVien
                WHERE  TrangThai = 1 AND MaNhanVien = @id";

            DataTable dt = Function.GetDataToTable(sql,
                new SqlParameter("@id", maNhanVien));
            if (dt == null || dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            string storedHash = row["MatKhau"]?.ToString() ?? "";

            bool ok = SecurityHelper.VerifyPassword(rawPassword, storedHash);
            if (!ok) return null;

            if (SecurityHelper.NeedsRehash(storedHash))
            {
                TryUpgradeHashToBCrypt(maNhanVien, rawPassword);
            }

            dt.Columns.Remove("MatKhau");
            return dt.Rows[0];
        }

        /// <summary>
        /// Nâng cấp hash trong DB sang BCrypt. Lỗi sẽ bị nuốt vì đây là tính năng phụ —
        /// không được phép phá luồng login chính.
        /// </summary>
        private static void TryUpgradeHashToBCrypt(string maNhanVien, string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien)) return;
            try
            {
                string newHash = SecurityHelper.HashPassword(plainPassword);
                if (string.IsNullOrEmpty(newHash)) return;
                Function.ExecuteNonQuery(
                    "UPDATE NhanVien SET MatKhau=@mk WHERE MaNhanVien=@id",
                    new SqlParameter("@mk", newHash),
                    new SqlParameter("@id", maNhanVien));
            }
            catch (Exception)
            {
                // Không log ra UI — chỉ là tối ưu phụ
            }
        }
    }
}
