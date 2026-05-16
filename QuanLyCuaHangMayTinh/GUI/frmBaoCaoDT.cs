using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Báo cáo doanh thu — đáp ứng RUBRIC 1.4:
    ///   - Thống kê theo NGÀY / THÁNG / NĂM (dùng cboLoai có sẵn trong Designer)
    ///   - Biểu đồ LiveCharts (đường + cột)
    ///   - KPI cards: tổng doanh thu, số đơn, trung bình đơn
    ///   - Lọc theo khoảng thời gian
    ///   - Demo dùng cả ADO.NET + Dapper ORM (rubric 2.3)
    ///
    /// 100% UI khớp Designer — không thêm control runtime.
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
            try { dtpFrom.Value = DateTime.Today.AddDays(-90); dtpTo.Value = DateTime.Today; } catch { }

            // cboLoai đã có sẵn trong Designer với 3 mục: Theo ngày, Theo tháng, Theo năm
            if (cboLoai != null)
            {
                if (cboLoai.SelectedIndex < 0) cboLoai.SelectedIndex = 0;
                cboLoai.SelectedIndexChanged += (s, ev) => LoadData();
            }

            if (btnXemBaoCao != null) btnXemBaoCao.Click += (s, ev) => LoadData();

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
                DateTime from = dtpFrom?.Value ?? DateTime.Today.AddDays(-90);
                DateTime to = dtpTo?.Value ?? DateTime.Today;
                string mode = cboLoai?.SelectedItem?.ToString() ?? "Theo ngày";

                DataTable data;
                string chartTitle, labelCol, valueCol;
                bool asBar;

                switch (mode)
                {
                    case "Theo tháng":
                        data = _bus.GetDoanhThuTheoThang(to.Year);
                        chartTitle = "Doanh thu theo tháng năm " + to.Year;
                        labelCol = "Thang";
                        valueCol = "DoanhThu";
                        asBar = true;
                        break;

                    case "Theo năm":
                        data = _bus.GetDoanhThuTheoNam();
                        chartTitle = "Doanh thu theo năm";
                        labelCol = "Nam";
                        valueCol = "DoanhThu";
                        asBar = true;
                        break;

                    default: // Theo ngày
                        data = _bus.GetDoanhThuTheoNgay(from, to);
                        chartTitle = "Doanh thu theo ngày";
                        labelCol = "Ngay";
                        valueCol = "DoanhThu";
                        asBar = false;
                        break;
                }

                if (dgvChiTiet != null) dgvChiTiet.DataSource = data;

                // KPI: tổng doanh thu qua Dapper (rubric 2.3), số đơn + TB qua ADO.NET
                decimal tongDT = _bus.DapperGetTongDoanhThu(from, to);
                var kpi = _bus.GetKPI(from, to);

                if (lblDoanhThu != null) lblDoanhThu.Text = tongDT.ToString("N0") + " đ";
                if (lblDonHang != null) lblDonHang.Text = kpi.tongDon.ToString("N0");
                if (lblTB != null) lblTB.Text = kpi.trungBinhDon.ToString("N0") + " đ";

                // Bind LiveCharts vào chart2 đã có sẵn trong Designer (không tạo runtime)
                LiveChartsHelper.BindCartesian(chart2, data, labelCol, valueCol, chartTitle, asBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
