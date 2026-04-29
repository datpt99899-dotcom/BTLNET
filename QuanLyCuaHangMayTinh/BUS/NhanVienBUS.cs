using QuanLyCuaHangMayTinh.DTO;
using QuanLyCuaHangMayTinh.DAL;

namespace QuanLyCuaHangMayTinh.BUS
{
    public class NhanVienBUS
    {
        private static NhanVienBUS _instance;
        public static NhanVienBUS Instance => _instance ?? (_instance = new NhanVienBUS());

        public NhanVienDTO DangNhap(string username, string password)
        {
            // TODO: Thay thế bằng truy vấn thực tế tới DAL
            return NhanVienDAL.Instance.KiemTraDangNhap(username, password);
        }
    }
}
