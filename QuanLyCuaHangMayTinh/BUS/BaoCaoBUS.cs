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

        // ─── Dapper demos (rubric 2.3) ───
        public decimal DapperGetTongDoanhThu(DateTime from, DateTime to)
            => _dal.DapperGetTongDoanhThu(from, to);

        public decimal DapperGetTongChiPhi(DateTime from, DateTime to)
            => _dal.DapperGetTongChiPhi(from, to);

        public System.Collections.Generic.List<dynamic> DapperDemDonTheoTrangThai(DateTime from, DateTime to)
            => _dal.DapperDemDonTheoTrangThai(from, to);
    }
}
