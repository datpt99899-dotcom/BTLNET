using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>Báo cáo sản phẩm bán chạy — top 10 với biểu đồ cột ngang LiveCharts.</summary>
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

                // Ẩn chart cũ + dùng LiveCharts (RowChart cho top sản phẩm bán chạy)
                if (chtSanPham != null) chtSanPham.Visible = false;
                if (chtDoanhThu != null) chtDoanhThu.Visible = false;
                LiveChartsHelper.RenderRowChart(pnlChart, data, "TenSanPham", "TongSoLuong", "Số lượng bán");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}
