using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.Repositories;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Today;
            LoadAllReports();
        }

        private void btnTaiBaoCao_Click(object sender, EventArgs e)
        {
            LoadAllReports();
        }

        private void LoadAllReports()
        {
            string fromDate = dtpFrom.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string toDate = dtpTo.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            DataTable revenue = ReportRepository.GetRevenueByDateRange(fromDate, toDate);
            dgvDoanhThu.DataSource = revenue;
            double tongDoanhThu = 0;
            foreach (DataRow row in revenue.Rows)
            {
                tongDoanhThu += row["DoanhThu"] != DBNull.Value ? Convert.ToDouble(row["DoanhThu"]) : 0;
            }
            txtTongDoanhThu.Text = tongDoanhThu.ToString("N0");
            lblBangChu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(txtTongDoanhThu.Text);

            DataTable bestSelling = ReportRepository.GetBestSellingProducts(fromDate, toDate);
            dgvSanPhamBanChay.DataSource = bestSelling;

            DataTable status = ReportRepository.GetOrderStatusSummary();
            dgvTrangThaiDon.DataSource = status;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
