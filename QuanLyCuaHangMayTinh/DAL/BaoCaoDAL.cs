using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.DAL
{
    /// <summary>
    /// Báo cáo doanh thu, sản phẩm bán chạy, đơn theo trạng thái, tồn kho, KPI.
    /// Mọi query đều dùng parameter — chống SQL Injection.
    /// </summary>
    internal class BaoCaoDAL
    {
        public DataTable GetDoanhThuTheoNgay(DateTime fromDate, DateTime toDate)
        {
            const string sql = @"
                SELECT CAST(NgayBan AS date) AS Ngay,
                       COUNT(*)             AS SoDon,
                       SUM(TongTien)        AS DoanhThu,
                       AVG(TongTien)        AS TrungBinh
                FROM   HoaDonBan
                WHERE  TrangThai IN (N'Hoàn thành', N'Đã giao')
                  AND  NgayBan BETWEEN @from AND @to
                GROUP  BY CAST(NgayBan AS date)
                ORDER  BY Ngay";
            return Function.GetDataToTable(sql,
                new SqlParameter("@from", fromDate.Date),
                new SqlParameter("@to",   toDate.Date.AddDays(1).AddSeconds(-1)));
        }

        public DataTable GetDoanhThuTheoThang(int nam)
        {
            const string sql = @"
                SELECT MONTH(NgayBan) AS Thang, SUM(TongTien) AS DoanhThu, COUNT(*) AS SoDon
                FROM   HoaDonBan
                WHERE  TrangThai IN (N'Hoàn thành', N'Đã giao')
                  AND  YEAR(NgayBan) = @nam
                GROUP  BY MONTH(NgayBan)
                ORDER  BY Thang";
            return Function.GetDataToTable(sql, new SqlParameter("@nam", nam));
        }

        public DataTable GetDoanhThuTheoNam()
        {
            const string sql = @"
                SELECT YEAR(NgayBan) AS Nam, SUM(TongTien) AS DoanhThu, COUNT(*) AS SoDon
                FROM   HoaDonBan
                WHERE  TrangThai IN (N'Hoàn thành', N'Đã giao')
                GROUP  BY YEAR(NgayBan)
                ORDER  BY Nam DESC";
            return Function.GetDataToTable(sql);
        }

        public DataTable GetSanPhamBanChay(DateTime fromDate, DateTime toDate, int top = 10)
        {
            string sql = $@"
                SELECT TOP {top} sp.MaSanPham, sp.TenSanPham, lsp.TenLoai,
                       SUM(ct.SoLuong)              AS TongSoLuong,
                       SUM(ct.SoLuong * ct.DonGia)  AS DoanhThu
                FROM   ChiTietHoaDonBan ct
                INNER JOIN HoaDonBan hd  ON ct.MaHoaDonBan=hd.MaHoaDonBan
                INNER JOIN SanPham   sp  ON ct.MaSanPham=sp.MaSanPham
                INNER JOIN LoaiSanPham lsp ON sp.MaLoai=lsp.MaLoai
                WHERE  hd.NgayBan BETWEEN @from AND @to
                  AND  hd.TrangThai IN (N'Hoàn thành', N'Đã giao')
                GROUP  BY sp.MaSanPham, sp.TenSanPham, lsp.TenLoai
                ORDER  BY TongSoLuong DESC";
            return Function.GetDataToTable(sql,
                new SqlParameter("@from", fromDate.Date),
                new SqlParameter("@to",   toDate.Date.AddDays(1).AddSeconds(-1)));
        }

        public DataTable GetDonHangTheoTrangThai(DateTime? from = null, DateTime? to = null)
        {
            const string sql = @"
                SELECT TrangThai, COUNT(*) AS SoLuong, SUM(TongTien) AS TongTien
                FROM   DonDatHang
                WHERE  (@from IS NULL OR NgayDat >= @from)
                  AND  (@to   IS NULL OR NgayDat <= @to)
                GROUP  BY TrangThai
                ORDER  BY SoLuong DESC";
            return Function.GetDataToTable(sql,
                new SqlParameter("@from", (object)from ?? DBNull.Value),
                new SqlParameter("@to",   (object)to   ?? DBNull.Value));
        }

        public DataTable GetTonKho()
        {
            const string sql = @"
                SELECT sp.MaSanPham, sp.TenSanPham, lsp.TenLoai, th.TenThuongHieu,
                       sp.SoLuongTon, sp.GiaNhap, sp.GiaBan,
                       (sp.SoLuongTon * sp.GiaNhap) AS GiaTriTon
                FROM   SanPham sp
                INNER JOIN LoaiSanPham lsp ON sp.MaLoai=lsp.MaLoai
                INNER JOIN ThuongHieu  th  ON sp.MaThuongHieu=th.MaThuongHieu
                ORDER  BY sp.SoLuongTon ASC";
            return Function.GetDataToTable(sql);
        }

        public (decimal tongDoanhThu, int tongDon, decimal trungBinhDon) GetKPI(DateTime fromDate, DateTime toDate)
        {
            const string sql = @"
                SELECT ISNULL(SUM(TongTien),0) AS TongDT,
                       COUNT(*)                AS TongDon,
                       ISNULL(AVG(TongTien),0) AS TBDon
                FROM   HoaDonBan
                WHERE  TrangThai IN (N'Hoàn thành', N'Đã giao')
                  AND  NgayBan BETWEEN @from AND @to";
            var dt = Function.GetDataToTable(sql,
                new SqlParameter("@from", fromDate.Date),
                new SqlParameter("@to",   toDate.Date.AddDays(1).AddSeconds(-1)));
            if (dt.Rows.Count == 0) return (0, 0, 0);
            var row = dt.Rows[0];
            return (Convert.ToDecimal(row["TongDT"]),
                    Convert.ToInt32(row["TongDon"]),
                    Convert.ToDecimal(row["TBDon"]));
        }
    }
}
