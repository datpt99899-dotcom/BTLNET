using System;

namespace QuanLyCuaHangMayTinh.DTO
{
    public class HoaDonBanDTO
    {
        public string MaHoaDonBan { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaKhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public string MaDonDatHang { get; set; }     // nullable
        public decimal TienGiam { get; set; }
        public decimal TongTien { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string TrangThai { get; set; }
    }
}
