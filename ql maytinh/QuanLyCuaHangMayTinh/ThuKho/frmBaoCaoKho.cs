using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmBaoCaoKho: Form
    {
        public frmBaoCaoKho()
        {
            InitializeComponent();
        }
        private void LoadTonKhoChart()
        {
            chart1.Series.Clear();
            Series series = new Series("Tồn kho");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            series.IsValueShownAsLabel = false;

            string sql = "SELECT TenNguyenLieu, SoLuongHienCo FROM NguyenLieu ORDER BY SoLuongHienCo DESC";
            DataTable dt = Function.GetDataToTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                string ten = row["TenNguyenLieu"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuongHienCo"]);
                series.Points.AddXY(ten, soLuong);
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }

        private void LoadChiPhiNhapChart()
        {
            chart2.Series.Clear();
            Series series = new Series("Chi phí nhập");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            series.IsValueShownAsLabel = false;

            string sql = @"
        SELECT nl.TenNguyenLieu, SUM(ct.ThanhTien) AS TongChiPhi
        FROM ChiTietHoaDonNhap ct
        JOIN NguyenLieu nl ON ct.MaNguyenLieu = nl.MaNguyenLieu
        GROUP BY nl.TenNguyenLieu
        ORDER BY TongChiPhi DESC";

            DataTable dt = Function.GetDataToTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                string ten = row["TenNguyenLieu"].ToString();
                decimal tongChiPhi = Convert.ToDecimal(row["TongChiPhi"]);
                series.Points.AddXY(ten, tongChiPhi);
            }

            chart2.Series.Add(series);
            chart2.ChartAreas[0].AxisX.Interval = 1;
        }

        private void frmBaoCaoKho_Load(object sender, EventArgs e)
        {
            LoadTonKhoChart();
            LoadChiPhiNhapChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
