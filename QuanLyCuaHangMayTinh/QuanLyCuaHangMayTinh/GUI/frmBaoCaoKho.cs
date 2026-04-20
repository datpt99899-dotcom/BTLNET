using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmBaoCaoKho : Form
    {
        public frmBaoCaoKho()
        {
            InitializeComponent();
        }

        private void LoadTonKhoChart()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            var series = new Series("Tồn kho")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            string sql = @"SELECT TOP 10 TenSanPham, SoLuongTon
                           FROM SanPham
                           ORDER BY SoLuongTon DESC, TenSanPham";
            DataTable dt = Function.GetDataToTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(row["TenSanPham"].ToString(), Convert.ToInt32(row["SoLuongTon"]));
            }
            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.Titles.Add("Số lượng tồn kho theo sản phẩm");
        }

        private void LoadChiPhiNhapChart()
        {
            chart2.Series.Clear();
            chart2.Titles.Clear();
            var series = new Series("Chi phí nhập")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            string sql = @"SELECT TOP 10 sp.TenSanPham,
                                  SUM(ct.SoLuong * ct.DonGiaNhap) AS TongChiPhi
                           FROM ChiTietPhieuNhap ct
                           INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                           GROUP BY sp.TenSanPham
                           ORDER BY TongChiPhi DESC";
            DataTable dt = Function.GetDataToTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(row["TenSanPham"].ToString(), Convert.ToDecimal(row["TongChiPhi"]));
            }
            chart2.Series.Add(series);
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.Titles.Add("Chi phí nhập theo sản phẩm");
        }

        private void frmBaoCaoKho_Load(object sender, EventArgs e)
        {
            LoadTonKhoChart();
            LoadChiPhiNhapChart();
            label1.Text = "BIỂU ĐỒ TỒN KHO";
            label2.Text = "BIỂU ĐỒ CHI PHÍ NHẬP";
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }
    }
}
