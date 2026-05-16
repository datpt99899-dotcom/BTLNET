using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>Báo cáo đơn hàng theo trạng thái — biểu đồ tròn LiveCharts.</summary>
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

                // Ẩn chart cũ + dùng LiveCharts (PieChart cho trạng thái đơn)
                if (chart2 != null) chart2.Visible = false;
                LiveChartsHelper.RenderPieChart(pnlChart, data, "TrangThai", "SoLuong");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}
