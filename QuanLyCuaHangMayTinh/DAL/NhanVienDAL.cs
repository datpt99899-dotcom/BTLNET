using QuanLyCuaHangMayTinh.DTO;
using System.Linq;
using System.Collections.Generic;

namespace QuanLyCuaHangMayTinh.DAL
{
    public class NhanVienDAL
    {
        private static NhanVienDAL _instance;
        public static NhanVienDAL Instance => _instance ?? (_instance = new NhanVienDAL());

        // Giả lập dữ liệu, thay bằng truy vấn DB thực tế
        private List<NhanVienDTO> _dsNhanVien = new List<NhanVienDTO>
        {
            new NhanVienDTO { MaNhanVien = "AD01", TenDangNhap = "admin", MatKhau = "123", MaVaiTro = "ADMIN", HoTen = "Admin" },
            new NhanVienDTO { MaNhanVien = "NV01", TenDangNhap = "nvban", MatKhau = "123", MaVaiTro = "BANHANG", HoTen = "Nhân viên bán hàng" }
        };

        public NhanVienDTO KiemTraDangNhap(string username, string password)
        {
            return _dsNhanVien.FirstOrDefault(x => x.TenDangNhap == username && x.MatKhau == password);
        }
    }
}
