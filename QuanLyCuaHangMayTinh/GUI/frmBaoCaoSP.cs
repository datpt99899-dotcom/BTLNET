using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;
using QuanLyCuaHangMayTinh.DAL;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Báo cáo sản phẩm bán chạy — top 10 với biểu đồ cột ngang LiveCharts.
    /// Có 2 combobox lọc: Loại sản phẩm và Thương hiệu.
    /// Hiển thị: Tổng SP nhập vào, Tổng SP bán ra (đếm số sản phẩm phân biệt).
    /// </summary>
    public partial class frmBaoCaoSP : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private bool _loadingFilters = false;

        public frmBaoCaoSP()
        {
            InitializeComponent();
            this.Load += FrmBaoCaoSP_Load;
        }

        private void FrmBaoCaoSP_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            try { dtpFrom.Value = DateTime.Today.AddDays(-30); dtpTo.Value = DateTime.Today; } catch { }

            // Load combo filters
            LoadComboFilters();

            if (btnXemBaoCao != null) btnXemBaoCao.Click += (s, ev) => LoadData();
            if (cboLoai != null) cboLoai.SelectedIndexChanged += (s, ev) => { if (!_loadingFilters) LoadData(); };
            if (cboThuongHieu != null) cboThuongHieu.SelectedIndexChanged += (s, ev) => { if (!_loadingFilters) LoadData(); };

            ReportButtonsHelper.AttachHandlers(this,
                null, null, null,
                btnLamMoi, btnXuatExcel, btnInBaoCao, btnThoat,
                dgvChiTiet, "Bao cao SP ban chay", LoadData);

            LoadData();
        }

        private void LoadComboFilters()
        {
            _loadingFilters = true;
            try
            {
                // Loại sản phẩm
                if (cboLoai != null)
                {
                    var dtLoai = Function.GetDataToTable("SELECT MaLoai, TenLoai FROM LoaiSanPham ORDER BY TenLoai");
                    var rowAll = dtLoai.NewRow();
                    rowAll["MaLoai"] = ""; rowAll["TenLoai"] = "-- Tất cả --";
                    dtLoai.Rows.InsertAt(rowAll, 0);
                    cboLoai.DataSource = dtLoai;
                    cboLoai.DisplayMember = "TenLoai";
                    cboLoai.ValueMember = "MaLoai";
                }

                // Thương hiệu
                if (cboThuongHieu != null)
                {
                    var dtTH = Function.GetDataToTable("SELECT MaThuongHieu, TenThuongHieu FROM ThuongHieu ORDER BY TenThuongHieu");
                    var rowAll = dtTH.NewRow();
                    rowAll["MaThuongHieu"] = ""; rowAll["TenThuongHieu"] = "-- Tất cả --";
                    dtTH.Rows.InsertAt(rowAll, 0);
                    cboThuongHieu.DataSource = dtTH;
                    cboThuongHieu.DisplayMember = "TenThuongHieu";
                    cboThuongHieu.ValueMember = "MaThuongHieu";
                }
            }
            catch { }
            _loadingFilters = false;
        }

        private void LoadData()
        {
            try
            {
                DateTime from = dtpFrom?.Value ?? DateTime.Today.AddDays(-30);
                DateTime to = dtpTo?.Value ?? DateTime.Today;
                string maLoai = cboLoai?.SelectedValue?.ToString() ?? "";
                string maTH = cboThuongHieu?.SelectedValue?.ToString() ?? "";

                // Truy vấn top SP bán chạy + lọc theo loại/TH (top 7 để chart đỡ chật)
                string sql = @"
                    SELECT TOP 7
                           sp.MaSanPham, sp.TenSanPham, lsp.TenLoai, th.TenThuongHieu,
                           SUM(ct.SoLuong)             AS TongSoLuong,
                           SUM(ct.SoLuong * ct.DonGia) AS DoanhThu
                    FROM   ChiTietHoaDonBan ct
                    INNER JOIN HoaDonBan   hd  ON ct.MaHoaDonBan = hd.MaHoaDonBan
                    INNER JOIN SanPham     sp  ON ct.MaSanPham = sp.MaSanPham
                    INNER JOIN LoaiSanPham lsp ON sp.MaLoai = lsp.MaLoai
                    INNER JOIN ThuongHieu  th  ON sp.MaThuongHieu = th.MaThuongHieu
                    WHERE  hd.NgayBan BETWEEN @from AND @to
                      AND  hd.TrangThai IN (N'Hoàn thành', N'Đã giao')
                      AND  (@maLoai = '' OR sp.MaLoai = @maLoai)
                      AND  (@maTH = ''   OR sp.MaThuongHieu = @maTH)
                    GROUP  BY sp.MaSanPham, sp.TenSanPham, lsp.TenLoai, th.TenThuongHieu
                    ORDER  BY TongSoLuong DESC";

                var data = Function.GetDataToTable(sql,
                    new SqlParameter("@from", from.Date),
                    new SqlParameter("@to", to.Date.AddDays(1).AddSeconds(-1)),
                    new SqlParameter("@maLoai", maLoai),
                    new SqlParameter("@maTH", maTH));

                if (dgvChiTiet != null) dgvChiTiet.DataSource = data;

                LiveChartsHelper.BindRow(chtSanPham, data, "TenSanPham", "TongSoLuong", "Số lượng bán");
                LiveChartsHelper.BindCartesian(chtDoanhThu, data, "TenSanPham", "DoanhThu", "Doanh thu", true);

                // Đếm tổng SP nhập vào / bán ra trong cùng khoảng + filter
                TinhTongNhapBan(from, to, maLoai, maTH);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void TinhTongNhapBan(DateTime from, DateTime to, string maLoai, string maTH)
        {
            try
            {
                // Tổng SỐ LƯỢNG sản phẩm nhập vào
                string sqlNhap = @"
                    SELECT ISNULL(SUM(ct.SoLuong), 0)
                    FROM   ChiTietPhieuNhap ct
                    INNER JOIN PhieuNhapKho pn ON ct.MaPhieuNhap = pn.MaPhieuNhap
                    INNER JOIN SanPham      sp ON ct.MaSanPham = sp.MaSanPham
                    WHERE  pn.NgayNhap BETWEEN @from AND @to
                      AND  (@maLoai = '' OR sp.MaLoai = @maLoai)
                      AND  (@maTH = ''   OR sp.MaThuongHieu = @maTH)";
                var dtNhap = Function.GetDataToTable(sqlNhap,
                    new SqlParameter("@from", from.Date),
                    new SqlParameter("@to", to.Date.AddDays(1).AddSeconds(-1)),
                    new SqlParameter("@maLoai", maLoai),
                    new SqlParameter("@maTH", maTH));
                int tongNhap = dtNhap.Rows.Count > 0 ? Convert.ToInt32(dtNhap.Rows[0][0]) : 0;
                if (lblTongNhap != null) lblTongNhap.Text = tongNhap.ToString("N0");

                // Tổng SỐ LƯỢNG sản phẩm bán ra
                string sqlBan = @"
                    SELECT ISNULL(SUM(ct.SoLuong), 0)
                    FROM   ChiTietHoaDonBan ct
                    INNER JOIN HoaDonBan   hd ON ct.MaHoaDonBan = hd.MaHoaDonBan
                    INNER JOIN SanPham     sp ON ct.MaSanPham = sp.MaSanPham
                    WHERE  hd.NgayBan BETWEEN @from AND @to
                      AND  hd.TrangThai IN (N'Hoàn thành', N'Đã giao')
                      AND  (@maLoai = '' OR sp.MaLoai = @maLoai)
                      AND  (@maTH = ''   OR sp.MaThuongHieu = @maTH)";
                var dtBan = Function.GetDataToTable(sqlBan,
                    new SqlParameter("@from", from.Date),
                    new SqlParameter("@to", to.Date.AddDays(1).AddSeconds(-1)),
                    new SqlParameter("@maLoai", maLoai),
                    new SqlParameter("@maTH", maTH));
                int tongBan = dtBan.Rows.Count > 0 ? Convert.ToInt32(dtBan.Rows[0][0]) : 0;
                if (lblTongBan != null) lblTongBan.Text = tongBan.ToString("N0");
            }
            catch { }
        }
    }
}
