using System.Collections.Generic;
using System.Data;
using QuanLyCuaHangMayTinh.DTO;

namespace QuanLyCuaHangMayTinh.BUS
{
    internal class TraHangBUS
    {
        private readonly DAL.TraHangDAL _dal = new DAL.TraHangDAL();

        public DataTable GetAll() => _dal.GetAll();
        public DataTable GetSanPhamCuaHoaDon(string maHoaDon) => _dal.GetSanPhamCuaHoaDon(maHoaDon);
        public string GenerateMaPhieuTra() => _dal.GenerateMaPhieuTra();

        public (bool ok, string msg) TaoPhieuTra(
            PhieuTraHangDTO phieu,
            List<(string maSP, int soLuong, decimal donGia, string tinhTrang)> chiTiet)
        {
            if (string.IsNullOrWhiteSpace(phieu.MaHoaDonBan))
                return (false, "Vui lòng nhập mã hóa đơn gốc.");
            if (chiTiet == null || chiTiet.Count == 0)
                return (false, "Chưa có sản phẩm trả.");
            if (string.IsNullOrWhiteSpace(phieu.LyDo))
                return (false, "Lý do trả hàng bắt buộc.");
            return _dal.TaoPhieuTra(phieu, chiTiet);
        }
    }
}
