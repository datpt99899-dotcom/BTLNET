using System;

namespace QuanLyCuaHangMayTinh.DTO
{
    public class DonDatHangDTO
    {
        public string MaDonDatHang { get; set; }
        public DateTime NgayDat { get; set; }
        public string MaKhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
    }
}
