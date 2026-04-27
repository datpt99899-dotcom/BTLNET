using System;
namespace QuanLyCuaHangMayTinh.DAL
{
    internal class NhanVienDAL
    {
        // Thêm mới nhân viên
        public bool AddNhanVien(string maNV, string tenDangNhap, string matKhau, string hoTen, string gioiTinh, string soDienThoai, string email, string diaChi, string maVaiTro)
        {
            string hashedPassword = SecurityHelper.ComputeSha256(matKhau?.Trim() ?? string.Empty);
            string sql = @"INSERT INTO NhanVien (MaNhanVien, TenDangNhap, MatKhau, HoTen, GioiTinh, SoDienThoai, Email, DiaChi, MaVaiTro, TrangThai)
                            VALUES (@MaNhanVien, @TenDangNhap, @MatKhau, @HoTen, @GioiTinh, @SoDienThoai, @Email, @DiaChi, @MaVaiTro, 1)";
            try
            {
                Function.RunSql(sql,
                    new System.Data.SqlClient.SqlParameter("@MaNhanVien", maNV),
                    new System.Data.SqlClient.SqlParameter("@TenDangNhap", tenDangNhap),
                    new System.Data.SqlClient.SqlParameter("@MatKhau", hashedPassword),
                    new System.Data.SqlClient.SqlParameter("@HoTen", hoTen),
                    new System.Data.SqlClient.SqlParameter("@GioiTinh", gioiTinh),
                    new System.Data.SqlClient.SqlParameter("@SoDienThoai", soDienThoai),
                    new System.Data.SqlClient.SqlParameter("@Email", email),
                    new System.Data.SqlClient.SqlParameter("@DiaChi", diaChi),
                    new System.Data.SqlClient.SqlParameter("@MaVaiTro", maVaiTro)
                );
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message, "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
