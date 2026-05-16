using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using WpfCharts = LiveCharts.Wpf;
using WinFormsCharts = LiveCharts.WinForms;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Helper bind data vào các CartesianChart / PieChart đã được tạo SẴN
    /// trong Designer của 3 form báo cáo. KHÔNG tạo chart runtime —
    /// đảm bảo UI lúc chạy khớp 100% với thiết kế Designer.
    /// </summary>
    internal static class LiveChartsHelper
    {
        private static System.Windows.Media.Color ToMediaColor(System.Drawing.Color c)
            => System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);

        private static readonly System.Windows.Media.Color[] Palette = new[]
        {
            System.Windows.Media.Color.FromRgb(0x4A, 0x90, 0xE2),
            System.Windows.Media.Color.FromRgb(0x50, 0xC8, 0x78),
            System.Windows.Media.Color.FromRgb(0xF5, 0xA6, 0x23),
            System.Windows.Media.Color.FromRgb(0xE5, 0x6E, 0x6E),
            System.Windows.Media.Color.FromRgb(0x9B, 0x59, 0xB6),
            System.Windows.Media.Color.FromRgb(0x1A, 0xBC, 0x9C),
            System.Windows.Media.Color.FromRgb(0xE6, 0x7E, 0x22),
        };

        /// <summary>
        /// Bind data vào CartesianChart có sẵn (đường hoặc cột).
        /// </summary>
        public static void BindCartesian(WinFormsCharts.CartesianChart chart, DataTable data,
            string labelColumn, string valueColumn,
            string seriesTitle = "Doanh thu", bool asBar = false)
        {
            if (chart == null) return;

            chart.Series = new SeriesCollection();
            chart.AxisX.Clear();
            chart.AxisY.Clear();

            if (data == null || data.Rows.Count == 0) return;

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

            chart.Series.Add(series);
            chart.LegendLocation = LegendLocation.Top;
            chart.AxisX.Add(new WpfCharts.Axis
            {
                Title = "Thời gian",
                Labels = labels,
                Separator = new WpfCharts.Separator { Step = Math.Max(1, labels.Count / 10) }
            });
            chart.AxisY.Add(new WpfCharts.Axis
            {
                Title = "Giá trị",
                LabelFormatter = v => v.ToString("N0")
            });
        }

        /// <summary>
        /// Bind data vào PieChart có sẵn — thường dùng cho đơn theo trạng thái.
        /// </summary>
        public static void BindPie(WinFormsCharts.PieChart chart, DataTable data,
            string labelColumn, string valueColumn)
        {
            if (chart == null) return;
            chart.Series = new SeriesCollection();
            if (data == null || data.Rows.Count == 0) return;

            int colorIdx = 0;
            foreach (DataRow r in data.Rows)
            {
                if (r[labelColumn] == DBNull.Value || r[valueColumn] == DBNull.Value) continue;

                var color = Palette[colorIdx % Palette.Length];
                colorIdx++;
                chart.Series.Add(new WpfCharts.PieSeries
                {
                    Title = r[labelColumn].ToString(),
                    Values = new ChartValues<double> { Convert.ToDouble(r[valueColumn]) },
                    Fill = new System.Windows.Media.SolidColorBrush(color),
                    DataLabels = true,
                    LabelPoint = chartPoint =>
                        string.Format("{0} ({1:P1})", chartPoint.Y, chartPoint.Participation)
                });
            }

            chart.LegendLocation = LegendLocation.Right;
            chart.InnerRadius = 40;
            chart.StartingRotationAngle = 0;
        }

        /// <summary>
        /// Bind data vào CartesianChart dưới dạng cột ngang (Row) — top sản phẩm bán chạy.
        /// </summary>
        public static void BindRow(WinFormsCharts.CartesianChart chart, DataTable data,
            string labelColumn, string valueColumn,
            string seriesTitle = "Số lượng")
        {
            if (chart == null) return;
            chart.Series = new SeriesCollection();
            chart.AxisX.Clear();
            chart.AxisY.Clear();
            if (data == null || data.Rows.Count == 0) return;

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

            chart.Series.Add(row);
            chart.LegendLocation = LegendLocation.None;
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
        }
    }
}
