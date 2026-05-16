using System.Collections.Generic;
using System.Data;
using QuanLyCuaHangMayTinh.DTO;

namespace QuanLyCuaHangMayTinh.BUS
{
    internal class DonDatHangBUS
    {
        private readonly DAL.DonDatHangDAL _dal = new DAL.DonDatHangDAL();

        public DataTable GetAll(string trangThai = null) => _dal.GetAll(trangThai);
        public DataTable GetChiTiet(string maDon) => _dal.GetChiTiet(maDon);
        public string GenerateMaDon() => _dal.GenerateMaDon();

        public bool TaoDon(DonDatHangDTO don, List<ChiTietHoaDonDTO> chiTiet)
        {
            if (chiTiet == null || chiTiet.Count == 0)
                throw new System.Exception("Đơn không có sản phẩm.");
            return _dal.TaoDon(don, chiTiet);
        }

        public bool CapNhatTrangThai(string maDon, string trangThai)
            => _dal.CapNhatTrangThai(maDon, trangThai);

        public (bool ok, string msg) ChuyenSangHoaDon(string maDon, string maHoaDonMoi, string maNhanVien)
            => _dal.ChuyenSangHoaDon(maDon, maHoaDonMoi, maNhanVien);
    }
}
