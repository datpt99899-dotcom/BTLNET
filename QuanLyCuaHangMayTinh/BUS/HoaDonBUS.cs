using System.Collections.Generic;
using System.Data;
using QuanLyCuaHangMayTinh.DTO;

namespace QuanLyCuaHangMayTinh.BUS
{
    internal class HoaDonBUS
    {
        private readonly DAL.HoaDonDAL _dal = new DAL.HoaDonDAL();

        public DataTable GetAll() => _dal.GetAll();
        public DataTable GetChiTiet(string maHoaDon) => _dal.GetChiTiet(maHoaDon);
        public string GenerateMaHoaDon() => _dal.GenerateMaHoaDon();

        public (bool ok, string msg) TaoHoaDon(HoaDonBanDTO hd, List<ChiTietHoaDonDTO> chiTiet)
        {
            if (chiTiet == null || chiTiet.Count == 0)
                return (false, "Đơn hàng không có sản phẩm.");
            if (hd.TongTien <= 0)
                return (false, "Tổng tiền phải lớn hơn 0.");
            return _dal.TaoHoaDon(hd, chiTiet);
        }

        public bool CapNhatTrangThai(string maHoaDon, string trangThai)
            => _dal.CapNhatTrangThai(maHoaDon, trangThai);
    }
}
