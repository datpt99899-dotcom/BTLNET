using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.QuanLy
{
    public class frmThongKeDonHang : Form
    {
        private CartesianChart cartesian;
        private PieChart pie;
        public frmThongKeDonHang()
        {
            Text = "Biểu đồ báo cáo đơn hàng"; Width = 1100; Height = 650;
            var split = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Vertical, SplitterDistance = 550 };
            cartesian = new CartesianChart { Dock = DockStyle.Fill };
            pie = new PieChart { Dock = DockStyle.Fill };
            split.Panel1.Controls.Add(cartesian); split.Panel2.Controls.Add(pie);
            Controls.Add(split);
            Load += (s,e) => LoadCharts();
        }
        private void LoadCharts()
        {
            try
            {
                var doanhThu = Function.GetDataToTable("SELECT TOP 6 MONTH(NgayBan) AS Thang, SUM(TongTien) AS TongTien FROM DonBanHang GROUP BY MONTH(NgayBan) ORDER BY Thang");
                cartesian.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Doanh thu",
                        Values = new ChartValues<decimal>(doanhThu.AsEnumerable().Select(r => r.Field<decimal>("TongTien")))
                    }
                };
                cartesian.AxisX.Add(new Axis { Title = "Tháng", Labels = doanhThu.AsEnumerable().Select(r => r["Thang"].ToString()).ToArray() });
                cartesian.AxisY.Add(new Axis { Title = "VNĐ" });
                var trangThai = Function.GetDataToTable("SELECT TrangThai, COUNT(*) AS SoLuong FROM DonBanHang GROUP BY TrangThai");
                pie.Series = new SeriesCollection();
                foreach (DataRow row in trangThai.Rows)
                {
                    pie.Series.Add(new PieSeries { Title = row["TrangThai"].ToString(), Values = new ChartValues<int> { Convert.ToInt32(row["SoLuong"]) }, DataLabels = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LiveCharts cần được restore NuGet và các bảng DonBanHang phải tồn tại. Chi tiết: " + ex.Message);
            }
        }
    }
}
