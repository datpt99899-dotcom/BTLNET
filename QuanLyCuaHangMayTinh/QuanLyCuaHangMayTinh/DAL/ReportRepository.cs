using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.Repositories
{
    internal static class ReportRepository
    {
        public static DataTable GetRevenueByDateRange(string fromDate, string toDate)
        {
            string sql = @"SELECT CAST(NgayBan AS date) AS Ngay, SUM(TongTien) AS DoanhThu
                           FROM HoaDonBan
                           WHERE TrangThai = N'Hoàn thành' AND NgayBan BETWEEN @fromDate AND @toDate
                           GROUP BY CAST(NgayBan AS date)
                           ORDER BY Ngay";
            return Function.GetDataToTable(sql,
                new SqlParameter("@fromDate", fromDate),
                new SqlParameter("@toDate", toDate));
        }

        public static DataTable GetBestSellingProducts(string fromDate, string toDate)
        {
            string sql = @"SELECT TOP 10 sp.MaSanPham, sp.TenSanPham,
                                  SUM(ct.SoLuong) AS TongSoLuong,
                                  SUM(ct.SoLuong * ct.DonGia) AS DoanhThu
                           FROM ChiTietHoaDonBan ct
                           INNER JOIN HoaDonBan hd ON ct.MaHoaDonBan = hd.MaHoaDonBan
                           INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                           WHERE hd.NgayBan BETWEEN @fromDate AND @toDate
                           GROUP BY sp.MaSanPham, sp.TenSanPham
                           ORDER BY TongSoLuong DESC";
            return Function.GetDataToTable(sql,
                new SqlParameter("@fromDate", fromDate),
                new SqlParameter("@toDate", toDate));
        }

        public static DataTable GetOrderStatusSummary()
        {
            string sql = @"SELECT TrangThai, COUNT(*) AS SoLuong
                           FROM DonDatHang
                           GROUP BY TrangThai
                           ORDER BY SoLuong DESC";
            return Function.GetDataToTable(sql);
        }
    }
}
