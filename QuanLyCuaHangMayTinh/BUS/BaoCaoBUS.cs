using System;
using System.Data;

namespace QuanLyCuaHangMayTinh.BUS
{
    internal class BaoCaoBUS
    {
        private readonly DAL.BaoCaoDAL _dal = new DAL.BaoCaoDAL();

        public DataTable GetDoanhThuTheoNgay(DateTime from, DateTime to) => _dal.GetDoanhThuTheoNgay(from, to);
        public DataTable GetDoanhThuTheoThang(int nam) => _dal.GetDoanhThuTheoThang(nam);
        public DataTable GetDoanhThuTheoNam() => _dal.GetDoanhThuTheoNam();
        public DataTable GetSanPhamBanChay(DateTime from, DateTime to, int top = 10) => _dal.GetSanPhamBanChay(from, to, top);
        public DataTable GetDonHangTheoTrangThai(DateTime? from = null, DateTime? to = null) => _dal.GetDonHangTheoTrangThai(from, to);
        public DataTable GetTonKho() => _dal.GetTonKho();

        public (decimal tongDoanhThu, int tongDon, decimal trungBinhDon) GetKPI(DateTime from, DateTime to)
            => _dal.GetKPI(from, to);
    }
}
