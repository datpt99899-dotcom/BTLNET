using System.Collections.Generic;
using System.Data;
using QuanLyCuaHangMayTinh.DTO;

namespace QuanLyCuaHangMayTinh.BUS
{
    internal class NhapKhoBUS
    {
        private readonly DAL.NhapKhoDAL _dal = new DAL.NhapKhoDAL();

        public DataTable GetAll() => _dal.GetAll();
        public DataTable GetChiTiet(string maPhieu) => _dal.GetChiTiet(maPhieu);
        public string GenerateMaPhieuNhap() => _dal.GenerateMaPhieuNhap();

        public (bool ok, string msg) TaoPhieuNhap(
            PhieuNhapKhoDTO phieu,
            List<(string maSP, int soLuong, decimal donGia)> chiTiet)
        {
            if (chiTiet == null || chiTiet.Count == 0)
                return (false, "Phiếu nhập không có sản phẩm.");
            return _dal.TaoPhieuNhap(phieu, chiTiet);
        }
    }
}
