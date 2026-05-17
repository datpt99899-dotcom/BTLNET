using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;
using QuanLyCuaHangMayTinh.DAL;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Báo cáo đơn hàng theo trạng thái — biểu đồ tròn LiveCharts.
    /// Có 3 combo lọc: Trạng thái, Loại sản phẩm, Thương hiệu — load từ DB.
    /// </summary>
    public partial class frmBaoCaoDonHang : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private bool _loadingFilters = false;

        public frmBaoCaoDonHang()
        {
            InitializeComponent();
            this.Load += FrmBaoCaoDonHang_Load;
        }

        private void FrmBaoCaoDonHang_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            try { dtpFrom.Value = DateTime.Today.AddDays(-30); dtpTo.Value = DateTime.Today; } catch { }

            LoadComboFilters();

            if (btnXemBaoCao != null) btnXemBaoCao.Click += (s, ev) => LoadData();
            if (cboTrangThai != null) cboTrangThai.SelectedIndexChanged += (s, ev) => { if (!_loadingFilters) LoadData(); };
            if (cboLoai != null) cboLoai.SelectedIndexChanged += (s, ev) => { if (!_loadingFilters) LoadData(); };
            if (cboThuongHieu != null) cboThuongHieu.SelectedIndexChanged += (s, ev) => { if (!_loadingFilters) LoadData(); };

            ReportButtonsHelper.AttachHandlers(this,
                null, null, null,
                btnLamMoi, btnXuatExcel, btnInBaoCao, btnThoat,
                dgvChiTiet, "Bao cao don hang", LoadData);

            LoadData();
        }

        private void LoadComboFilters()
        {
            _loadingFilters = true;
            try
            {
                // Trạng thái — fix sẵn các giá trị có thể có của DonDatHang
                if (cboTrangThai != null)
                {
                    cboTrangThai.Items.Clear();
                    cboTrangThai.Items.AddRange(new object[] {
                        "-- Tất cả --", "Chờ xử lý", "Đang giao", "Đã giao", "Hoàn thành", "Hủy"
                    });
                    cboTrangThai.SelectedIndex = 0;
                }

                // Loại sản phẩm — load từ DB
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

                // Thương hiệu — load từ DB
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
                string trangThai = cboTrangThai?.SelectedItem?.ToString() ?? "";
                if (trangThai == "-- Tất cả --") trangThai = "";
                string maLoai = cboLoai?.SelectedValue?.ToString() ?? "";
                string maTH = cboThuongHieu?.SelectedValue?.ToString() ?? "";

                // Truy vấn đơn theo trạng thái + lọc theo loại/TH nếu chọn
                string sql = @"
                    SELECT ddh.TrangThai,
                           COUNT(DISTINCT ddh.MaDonDatHang) AS SoLuong,
                           SUM(ddh.TongTien)               AS TongTien
                    FROM   DonDatHang ddh
                    LEFT JOIN ChiTietDonDatHang ct ON ddh.MaDonDatHang = ct.MaDonDatHang
                    LEFT JOIN SanPham           sp ON ct.MaSanPham = sp.MaSanPham
                    WHERE  ddh.NgayDat BETWEEN @from AND @to
                      AND  (@tt = '' OR ddh.TrangThai = @tt)
                      AND  (@maLoai = '' OR sp.MaLoai = @maLoai)
                      AND  (@maTH = '' OR sp.MaThuongHieu = @maTH)
                    GROUP  BY ddh.TrangThai
                    ORDER  BY SoLuong DESC";

                var data = Function.GetDataToTable(sql,
                    new SqlParameter("@from", from.Date),
                    new SqlParameter("@to", to.Date.AddDays(1).AddSeconds(-1)),
                    new SqlParameter("@tt", trangThai),
                    new SqlParameter("@maLoai", maLoai),
                    new SqlParameter("@maTH", maTH));

                if (dgvChiTiet != null) dgvChiTiet.DataSource = data;

                // Bind LiveCharts PieChart
                LiveChartsHelper.BindPie(chart2, data, "TrangThai", "SoLuong");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải báo cáo: " + ex.Message); }
        }
    }
}
