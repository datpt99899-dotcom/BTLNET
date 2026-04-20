using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.Repositories
{
    internal static class AuthRepository
    {
        public static DataRow Authenticate(string usernameOrEmployeeCode, string rawPassword)
        {
            string hashedPassword = SecurityHelper.ComputeSha256(rawPassword?.Trim() ?? string.Empty);
            string sql = @"SELECT nv.MaNhanVien, nv.TenDangNhap, nv.HoTen, nv.MaVaiTro, vt.TenVaiTro
                           FROM NhanVien nv
                           INNER JOIN VaiTro vt ON nv.MaVaiTro = vt.MaVaiTro
                           WHERE nv.TrangThai = 1
                             AND (nv.TenDangNhap = @login OR nv.MaNhanVien = @login)
                             AND (nv.MatKhau = @raw OR nv.MatKhau = @hash)";
            DataTable dt = Function.GetDataToTable(sql,
                new SqlParameter("@login", usernameOrEmployeeCode),
                new SqlParameter("@raw", rawPassword),
                new SqlParameter("@hash", hashedPassword));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}
