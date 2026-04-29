namespace QuanLyCuaHangMayTinh.BUS
{
    internal class NhanVienBUS
    {
        private DAL.NhanVienDAL dal = new DAL.NhanVienDAL();

        // Thêm mới nhân viên (bổ sung kiểm tra hợp lệ nếu cần)
        public bool AddNhanVien(DTO.NhanVienDTO nv, string matKhau)
        {
            // Có thể kiểm tra hợp lệ ở đây (ví dụ: không trùng mã NV, tên đăng nhập, ...)
            return dal.AddNhanVien(nv.MaNhanVien, nv.TenDangNhap, matKhau, nv.HoTen, nv.GioiTinh, nv.SoDienThoai, nv.Email, nv.DiaChi, nv.MaVaiTro);
        }
    }
}
