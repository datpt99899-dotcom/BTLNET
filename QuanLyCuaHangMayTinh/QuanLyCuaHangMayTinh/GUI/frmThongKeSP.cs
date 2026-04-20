using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.QuanLy
{
    public partial class frmThongKeDonHang : Form
    {
        private readonly LiveCharts.WinForms.CartesianChart cartesian;
        private readonly LiveCharts.WinForms.PieChart pie;

        public frmThongKeDonHang()
        {
            InitializeComponent();

            Text = "Biểu đồ báo cáo đơn hàng";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 1100;
            Height = 650;
            BackColor = Color.White;

            var split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 550,
                BackColor = Color.White
            };

            cartesian = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            pie = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            split.Panel1.BackColor = Color.White;
            split.Panel2.BackColor = Color.White;
            split.Panel1.Controls.Add(cartesian);
            split.Panel2.Controls.Add(pie);

            Controls.Add(split);

            Load += frmThongKeDonHang_Load;
        }

        private void frmThongKeDonHang_Load(object sender, EventArgs e)
        {
            LoadCharts();
        }

        private void LoadCharts()
        {
            try
            {
                LoadRevenueChart();
                LoadOrderStatusChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được biểu đồ thống kê: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void LoadRevenueChart()
        {
            DataTable doanhThu = Function.GetDataToTable(@"
                SELECT TOP 6
                    FORMAT(NgayBan, 'MM/yyyy') AS ThangNam,
                    SUM(TongTien) AS TongTien
                FROM HoaDonBan
                GROUP BY FORMAT(NgayBan, 'MM/yyyy')
                ORDER BY ThangNam
            ");

            string[] labels = doanhThu.AsEnumerable()
                .Select(r => r["ThangNam"].ToString())
                .ToArray();

            ChartValues<decimal> values = new ChartValues<decimal>(
                doanhThu.AsEnumerable()
                    .Select(r => Convert.ToDecimal(r["TongTien"]))
            );

            cartesian.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = values,
                    DataLabels = true
                }
            };

            cartesian.AxisX.Clear();
            cartesian.AxisY.Clear();

            cartesian.AxisX.Add(new Axis
            {
                Title = "Tháng",
                Labels = labels
            });

            cartesian.AxisY.Add(new Axis
            {
                Title = "VNĐ",
                LabelFormatter = value => value.ToString("N0")
            });

            cartesian.LegendLocation = LegendLocation.Right;
        }

        private void LoadOrderStatusChart()
        {
            DataTable trangThai = Function.GetDataToTable(@"
                SELECT TrangThai, COUNT(*) AS SoLuong
                FROM DonDatHang
                GROUP BY TrangThai
            ");

            pie.Series = new SeriesCollection();

            foreach (DataRow row in trangThai.Rows)
            {
                pie.Series.Add(new PieSeries
                {
                    Title = row["TrangThai"].ToString(),
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(Convert.ToDouble(row["SoLuong"]))
                    },
                    DataLabels = true
                });
            }

            pie.LegendLocation = LegendLocation.Right;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmThongKeDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Name = "frmThongKeDonHang";
            this.Text = "Biểu đồ báo cáo đơn hàng";
            this.ResumeLayout(false);
        }
    }
}