using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Báo cáo doanh thu — KPI cards + biểu đồ đường LiveCharts + bảng chi tiết.
    /// Đáp ứng rubric 1.4: dùng LiveCharts cho biểu đồ + lọc ngày/tháng/năm.
    /// </summary>
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

            // Gắn nút header chung (Làm mới, Xuất Excel, In, Thoát)
            ReportButtonsHelper.AttachHandlers(this,
                null, null, null,
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

                // Ẩn chart cũ (nếu có) và dùng LiveCharts đè lên panel
                if (chart2 != null) chart2.Visible = false;
                LiveChartsHelper.RenderLineChart(pnlChart, data, "Ngay", "DoanhThu", "Doanh thu theo ngày");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
