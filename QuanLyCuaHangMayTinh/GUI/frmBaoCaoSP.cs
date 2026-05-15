using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyCuaHangMayTinh.BUS;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>Báo cáo sản phẩm bán chạy — top 10 (biểu đồ ngang + bảng).</summary>
    public partial class frmBaoCaoSP : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();

        public frmBaoCaoSP()
        {
            InitializeComponent();
            this.Load += FrmBaoCaoSP_Load;
        }

        private void FrmBaoCaoSP_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            try { dtpFrom.Value = DateTime.Today.AddDays(-30); dtpTo.Value = DateTime.Today; } catch { }
            if (btnXemBaoCao != null) btnXemBaoCao.Click += (s, ev) => LoadData();

            // Gắn nút header chung - 3 nút tab đã được xóa khỏi Designer
            ReportButtonsHelper.AttachHandlers(this,
                null, null, null,
                btnLamMoi, btnXuatExcel, btnInBaoCao, btnThoat,
                dgvChiTiet, "Bao cao SP ban chay", LoadData);

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var data = _bus.GetSanPhamBanChay(
                    dtpFrom?.Value ?? DateTime.Today.AddDays(-30),
                    dtpTo?.Value ?? DateTime.Today, 10);
                if (dgvChiTiet != null) dgvChiTiet.DataSource = data;
                BindChart(data);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void BindChart(DataTable tbl)
        {
            if (chtSanPham == null || tbl == null) return;
            chtSanPham.Series.Clear();
            if (chtSanPham.ChartAreas.Count == 0) chtSanPham.ChartAreas.Add(new ChartArea("Main"));
            var area = chtSanPham.ChartAreas[0];
            area.BackColor = AppTheme.CardBg;
            area.AxisX.LabelStyle.ForeColor = AppTheme.TextPrimary;
            area.AxisY.LabelStyle.ForeColor = AppTheme.TextPrimary;

            var series = new Series("Số lượng bán")
            {
                ChartType = SeriesChartType.Bar,
                Color = AppTheme.Success,
                IsValueShownAsLabel = true,
                BorderWidth = 0
            };
            chtSanPham.Series.Add(series);
            foreach (DataRow r in tbl.Rows)
                series.Points.AddXY(r["TenSanPham"].ToString(), Convert.ToInt32(r["TongSoLuong"]));
            chtSanPham.BackColor = AppTheme.CardBg;
        }
    }
}
