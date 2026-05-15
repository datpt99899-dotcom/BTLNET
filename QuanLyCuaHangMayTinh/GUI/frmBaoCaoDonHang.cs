using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyCuaHangMayTinh.BUS;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>Báo cáo đơn hàng theo trạng thái — biểu đồ tròn.</summary>
    public partial class frmBaoCaoDonHang : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();

        public frmBaoCaoDonHang()
        {
            InitializeComponent();
            this.Load += FrmBaoCaoDonHang_Load;
        }

        private void FrmBaoCaoDonHang_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            try { dtpFrom.Value = DateTime.Today.AddDays(-30); dtpTo.Value = DateTime.Today; } catch { }
            if (btnXemBaoCao != null) btnXemBaoCao.Click += (s, ev) => LoadData();

            // Gắn nút header chung - 3 nút tab đã được xóa khỏi Designer
            ReportButtonsHelper.AttachHandlers(this,
                null, null, null,
                btnLamMoi, btnXuatExcel, btnInBaoCao, btnThoat,
                dgvChiTiet, "Bao cao don hang", LoadData);

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var data = _bus.GetDonHangTheoTrangThai(
                    dtpFrom?.Value ?? DateTime.Today.AddDays(-30),
                    dtpTo?.Value ?? DateTime.Today);
                if (dgvChiTiet != null) dgvChiTiet.DataSource = data;
                BindChart(data);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void BindChart(DataTable tbl)
        {
            if (chart2 == null || tbl == null) return;
            chart2.Series.Clear();
            if (chart2.ChartAreas.Count == 0) chart2.ChartAreas.Add(new ChartArea("Main"));
            chart2.ChartAreas[0].BackColor = AppTheme.CardBg;

            var series = new Series("Trạng thái")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "N0",
                BorderWidth = 0
            };
            chart2.Series.Add(series);
            foreach (DataRow r in tbl.Rows)
            {
                int idx = series.Points.AddXY(r["TrangThai"].ToString(), Convert.ToInt32(r["SoLuong"]));
                series.Points[idx].LegendText = r["TrangThai"].ToString();
            }
            chart2.BackColor = AppTheme.CardBg;
        }
    }
}
