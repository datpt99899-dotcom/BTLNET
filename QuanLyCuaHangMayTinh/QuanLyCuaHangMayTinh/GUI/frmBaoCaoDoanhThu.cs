using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmBaoCao : Form
    {
        private DataTable tbl;

        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            cboLoai.SelectedIndex = 0;

            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;

            ApplyModernGridStyle();
            LoadFakeData();
        }

        private void LoadFakeData()
        {
            tbl = new DataTable();

            tbl.Columns.Add("Ngay");
            tbl.Columns.Add("SoDon", typeof(int));
            tbl.Columns.Add("DoanhThu", typeof(decimal));
            tbl.Columns.Add("TrungBinh", typeof(decimal));

            tbl.Rows.Add("18/04", 6, 32000000m, 5333333m);
            tbl.Rows.Add("19/04", 4, 21500000m, 5375000m);
            tbl.Rows.Add("20/04", 9, 42800000m, 4755555m);
            tbl.Rows.Add("21/04", 6, 28900000m, 4816666m);
            tbl.Rows.Add("22/04", 3, 17300000m, 5766667m);

            dgv.DataSource = tbl;

            UpdateStats();
            BindChart();
        }

        private void UpdateStats()
        {
            decimal tong = 0;
            int soDon = 0;

            foreach (DataRow r in tbl.Rows)
            {
                tong += Convert.ToDecimal(r["DoanhThu"]);
                soDon += Convert.ToInt32(r["SoDon"]);
            }

            decimal tb = soDon > 0 ? (tong / soDon) : 0;

            // KPI values only (title/hint are in Designer)
            lblDoanhThu.Text = tong.ToString("N0") + "đ";
            lblDonHang.Text = soDon.ToString("N0");
            lblTB.Text = tb.ToString("N0") + "đ";
        }

        private void BindChart()
        {
            if (tbl == null) return;

            chtDoanhThu.Series.Clear();
            chtDoanhThu.ChartAreas.Clear();
            chtDoanhThu.Legends.Clear();

            ChartArea area = new ChartArea("Main");
            area.BackColor = Color.FromArgb(28, 32, 40);
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LabelStyle.ForeColor = Color.Gainsboro;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(45, 50, 62);
            area.AxisY.LabelStyle.ForeColor = Color.Gainsboro;

            chtDoanhThu.ChartAreas.Add(area);

            Series s = new Series("Doanh thu");
            s.ChartType = SeriesChartType.Bar;
            s.Color = Color.FromArgb(0, 180, 170);
            s.BackSecondaryColor = Color.RoyalBlue;
            s.BorderWidth = 0;
            s.IsValueShownAsLabel = true;
            s.LabelForeColor = Color.White;
            s.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            s["PointWidth"] = "0.6";

            foreach (DataRow r in tbl.Rows)
            {
                string ngay = Convert.ToString(r["Ngay"]);
                decimal doanhThu = Convert.ToDecimal(r["DoanhThu"]);
                DataPoint p = new DataPoint();
                p.AxisLabel = ngay;
                p.YValues = new[] { (double)doanhThu };
                p.Label = (doanhThu / 1000000m).ToString("0.#") + "M";
                s.Points.Add(p);
            }

            chtDoanhThu.Series.Add(s);
            chtDoanhThu.BackColor = Color.FromArgb(28, 32, 40);
        }

        private void ApplyModernGridStyle()
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(45, 50, 62);
            dgv.BackgroundColor = Color.FromArgb(28, 32, 40);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(28, 32, 40);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 65, 85);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            // Later: replace with real query by dtpFrom/dtpTo + cboLoai.
            LoadFakeData();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}