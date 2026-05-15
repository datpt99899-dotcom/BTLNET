using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyCuaHangMayTinh.BUS;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>Báo cáo doanh thu — KPI cards + biểu đồ cột + bảng chi tiết.</summary>
    public partial class frmBaoCaoDT : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();

        public frmBaoCaoDT()
        {
            InitializeComponent();
            this.Load += FrmBaoCaoDT_Load;
        }

        private void FrmBaoCaoDT_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            try { dtpFrom.Value = DateTime.Today.AddDays(-30); dtpTo.Value = DateTime.Today; } catch { }
            if (btnXemBaoCao != null) btnXemBaoCao.Click += (s, ev) => LoadData();

            // Gắn 7 nút header chung
            ReportButtonsHelper.AttachHandlers(this,
                btnTabDoanhThu, btnTabSPBanChay, btnTabDonTrangThai,
                btnLamMoi, btnXuatExcel, btnInBaoCao, btnThoat,
                dgvChiTiet, "Bao cao doanh thu", LoadData);

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DateTime from = dtpFrom?.Value ?? DateTime.Today.AddDays(-30);
                DateTime to   = dtpTo?.Value   ?? DateTime.Today;
                var data = _bus.GetDoanhThuTheoNgay(from, to);
                if (dgvChiTiet != null) dgvChiTiet.DataSource = data;
                var kpi = _bus.GetKPI(from, to);
                if (lblDoanhThu != null) lblDoanhThu.Text = kpi.tongDoanhThu.ToString("N0") + " đ";
                if (lblDonHang  != null) lblDonHang.Text  = kpi.tongDon.ToString("N0");
                if (lblTB       != null) lblTB.Text       = kpi.trungBinhDon.ToString("N0") + " đ";
                BindChart(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindChart(DataTable tbl)
        {
            if (chart2 == null || tbl == null) return;
            chart2.Series.Clear();
            if (chart2.ChartAreas.Count == 0) chart2.ChartAreas.Add(new ChartArea("Main"));
            var area = chart2.ChartAreas[0];
            area.BackColor = AppTheme.CardBg;
            area.AxisX.LabelStyle.ForeColor = AppTheme.TextPrimary;
            area.AxisY.LabelStyle.ForeColor = AppTheme.TextPrimary;
            area.AxisY.LabelStyle.Format    = "N0";

            var series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column,
                Color = AppTheme.Primary,
                BorderWidth = 0
            };
            chart2.Series.Add(series);
            foreach (DataRow r in tbl.Rows)
            {
                if (r["Ngay"] == DBNull.Value || r["DoanhThu"] == DBNull.Value) continue;
                series.Points.AddXY(Convert.ToDateTime(r["Ngay"]).ToString("dd/MM"),
                                    Convert.ToDecimal(r["DoanhThu"]));
            }
            chart2.BackColor = AppTheme.CardBg;
        }
    }
}
