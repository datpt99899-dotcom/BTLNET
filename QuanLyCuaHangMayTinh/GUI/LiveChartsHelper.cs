using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using WpfCharts = LiveCharts.Wpf;
using WinFormsCharts = LiveCharts.WinForms;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Helper tích hợp LiveCharts cho các form báo cáo — đáp ứng yêu cầu rubric mục 1.4
    /// (Biểu đồ LiveCharts/Krypton để đạt mức Tốt).
    ///
    /// Cách dùng:
    ///   LiveChartsHelper.RenderLineChart(panel, data, "Ngay", "DoanhThu");
    ///   LiveChartsHelper.RenderPieChart(panel, data, "TrangThai", "SoLuong");
    ///   LiveChartsHelper.RenderRowChart(panel, data, "TenSanPham", "TongSoLuong");
    ///
    /// Lưu ý kỹ thuật:
    ///   - LiveCharts có 2 namespace cùng tên class: LiveCharts.Wpf vs LiveCharts.WinForms.
    ///   - Để tránh ambiguous reference (CS0104), ta dùng alias:
    ///       WpfCharts        = LiveCharts.Wpf (chứa LineSeries, PieSeries, Axis, ...)
    ///       WinFormsCharts   = LiveCharts.WinForms (chứa CartesianChart, PieChart - container)
    ///   - KHÔNG sửa Designer.cs — chỉ inject control runtime vào panel có sẵn.
    /// </summary>
    internal static class LiveChartsHelper
    {
        // Chuyển từ System.Drawing.Color → System.Windows.Media.Color
        private static System.Windows.Media.Color ToMediaColor(System.Drawing.Color c)
            => System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);

        // Bảng màu cho biểu đồ tròn (mỗi slice 1 màu)
        private static readonly System.Windows.Media.Color[] Palette = new[]
        {
            System.Windows.Media.Color.FromRgb(0x4A, 0x90, 0xE2),   // xanh dương
            System.Windows.Media.Color.FromRgb(0x50, 0xC8, 0x78),   // xanh lá
            System.Windows.Media.Color.FromRgb(0xF5, 0xA6, 0x23),   // cam
            System.Windows.Media.Color.FromRgb(0xE5, 0x6E, 0x6E),   // đỏ
            System.Windows.Media.Color.FromRgb(0x9B, 0x59, 0xB6),   // tím
            System.Windows.Media.Color.FromRgb(0x1A, 0xBC, 0x9C),   // teal
            System.Windows.Media.Color.FromRgb(0xE6, 0x7E, 0x22),   // cam đậm
        };

        /// <summary>
        /// Vẽ biểu đồ ĐƯỜNG (CartesianChart) — thường dùng cho doanh thu theo ngày.
        /// </summary>
        public static void RenderLineChart(Panel host, DataTable data,
            string labelColumn, string valueColumn,
            string seriesTitle = "Doanh thu", bool asBar = false)
        {
            if (host == null) return;
            host.Controls.Clear();
            if (data == null || data.Rows.Count == 0)
            {
                ShowEmptyMessage(host, "Không có dữ liệu để hiển thị");
                return;
            }

            var labels = new List<string>();
            var values = new ChartValues<double>();
            foreach (DataRow r in data.Rows)
            {
                if (r[labelColumn] == DBNull.Value || r[valueColumn] == DBNull.Value) continue;

                string lbl = r[labelColumn] is DateTime
                    ? ((DateTime)r[labelColumn]).ToString("dd/MM")
                    : r[labelColumn].ToString();
                labels.Add(lbl);
                values.Add(Convert.ToDouble(r[valueColumn]));
            }

            var primaryMedia = ToMediaColor(AppTheme.Primary);
            var primaryBrush = new System.Windows.Media.SolidColorBrush(primaryMedia);
            var fillBrush = new System.Windows.Media.SolidColorBrush(
                System.Windows.Media.Color.FromArgb(60, primaryMedia.R, primaryMedia.G, primaryMedia.B));

            WpfCharts.Series series;
            if (asBar)
            {
                series = new WpfCharts.ColumnSeries
                {
                    Title = seriesTitle,
                    Values = values,
                    Fill = primaryBrush,
                    Stroke = primaryBrush,
                    DataLabels = false
                };
            }
            else
            {
                series = new WpfCharts.LineSeries
                {
                    Title = seriesTitle,
                    Values = values,
                    Stroke = primaryBrush,
                    Fill = fillBrush,
                    PointGeometry = WpfCharts.DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    LineSmoothness = 0.5,
                    StrokeThickness = 2.5
                };
            }

            var chart = new WinFormsCharts.CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = AppTheme.CardBg,
                Series = new SeriesCollection { series },
                LegendLocation = LegendLocation.Top
            };
            chart.AxisX.Add(new WpfCharts.Axis
            {
                Title = "Thời gian",
                Labels = labels,
                Separator = new WpfCharts.Separator { Step = Math.Max(1, labels.Count / 10) }
            });
            chart.AxisY.Add(new WpfCharts.Axis
            {
                Title = "Giá trị (VNĐ)",
                LabelFormatter = v => v.ToString("N0")
            });

            host.Controls.Add(chart);
        }

        /// <summary>
        /// Vẽ biểu đồ TRÒN (PieChart) — thường dùng cho đơn hàng theo trạng thái.
        /// </summary>
        public static void RenderPieChart(Panel host, DataTable data,
            string labelColumn, string valueColumn)
        {
            if (host == null) return;
            host.Controls.Clear();
            if (data == null || data.Rows.Count == 0)
            {
                ShowEmptyMessage(host, "Không có dữ liệu để hiển thị");
                return;
            }

            var seriesCollection = new SeriesCollection();
            int colorIdx = 0;
            foreach (DataRow r in data.Rows)
            {
                if (r[labelColumn] == DBNull.Value || r[valueColumn] == DBNull.Value) continue;

                var color = Palette[colorIdx % Palette.Length];
                colorIdx++;
                seriesCollection.Add(new WpfCharts.PieSeries
                {
                    Title = r[labelColumn].ToString(),
                    Values = new ChartValues<double> { Convert.ToDouble(r[valueColumn]) },
                    Fill = new System.Windows.Media.SolidColorBrush(color),
                    DataLabels = true,
                    LabelPoint = chartPoint =>
                        string.Format("{0} ({1:P1})", chartPoint.Y, chartPoint.Participation)
                });
            }

            var pie = new WinFormsCharts.PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = AppTheme.CardBg,
                Series = seriesCollection,
                LegendLocation = LegendLocation.Right,
                InnerRadius = 40,
                StartingRotationAngle = 0
            };
            host.Controls.Add(pie);
        }

        /// <summary>
        /// Vẽ biểu đồ CỘT NGANG (Row) — thường dùng cho top sản phẩm bán chạy.
        /// </summary>
        public static void RenderRowChart(Panel host, DataTable data,
            string labelColumn, string valueColumn,
            string seriesTitle = "Số lượng")
        {
            if (host == null) return;
            host.Controls.Clear();
            if (data == null || data.Rows.Count == 0)
            {
                ShowEmptyMessage(host, "Không có dữ liệu để hiển thị");
                return;
            }

            var labels = new List<string>();
            var values = new ChartValues<double>();
            foreach (DataRow r in data.Rows)
            {
                if (r[labelColumn] == DBNull.Value || r[valueColumn] == DBNull.Value) continue;
                labels.Add(r[labelColumn].ToString());
                values.Add(Convert.ToDouble(r[valueColumn]));
            }

            var successMedia = ToMediaColor(AppTheme.Success);
            var successBrush = new System.Windows.Media.SolidColorBrush(successMedia);
            var row = new WpfCharts.RowSeries
            {
                Title = seriesTitle,
                Values = values,
                Fill = successBrush,
                Stroke = successBrush,
                DataLabels = true
            };

            var chart = new WinFormsCharts.CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = AppTheme.CardBg,
                Series = new SeriesCollection { row },
                LegendLocation = LegendLocation.None
            };
            chart.AxisY.Add(new WpfCharts.Axis
            {
                Title = "Sản phẩm",
                Labels = labels
            });
            chart.AxisX.Add(new WpfCharts.Axis
            {
                Title = seriesTitle,
                LabelFormatter = v => v.ToString("N0")
            });

            host.Controls.Add(chart);
        }

        private static void ShowEmptyMessage(Panel host, string message)
        {
            var lbl = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = AppTheme.TextSecondary,
                Font = new Font("Segoe UI", 11F, FontStyle.Italic)
            };
            host.Controls.Add(lbl);
        }
    }
}
