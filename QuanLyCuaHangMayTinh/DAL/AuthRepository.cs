using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.Repositories
{
    /// <summary>
    /// Xác thực tài khoản: lấy hash từ DB rồi dùng BCrypt.Verify() — KHÔNG bao giờ so sánh plaintext.
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

            // Sử dụng BCrypt.Verify - KHÔNG so sánh plaintext
            bool ok = SecurityHelper.VerifyPassword(rawPassword, storedHash);
            if (!ok) return null;

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

            dt.Columns.Remove("MatKhau");
            return dt.Rows[0];
        }
    }
}
