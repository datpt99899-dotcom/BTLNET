using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>Form tìm kiếm/danh sách phiếu nhập kho.</summary>
    public partial class frmTimKiemPhieuNhap : Form
    {
        private readonly NhapKhoBUS _bus = new NhapKhoBUS();
        private DataTable _dt;

        public frmTimKiemPhieuNhap()
        {
            InitializeComponent();
            this.Load += FrmTimKiemPhieuNhap_Load;
        }

        private void FrmTimKiemPhieuNhap_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            LoadData();
            if (btnTimKiem != null) btnTimKiem.Click += BtnTimKiem_Click;
            if (btnLamMoi  != null) btnLamMoi.Click  += (s, ev) => { txtTimKiem.Text = ""; LoadData(); };
            if (dgvDSPhieuNhap != null) dgvDSPhieuNhap.CellClick += DgvDSPhieuNhap_CellClick;
        }

        private void LoadData()
        {
            try
            {
                _dt = _bus.GetAll();
                if (dgvDSPhieuNhap != null) dgvDSPhieuNhap.DataSource = _dt;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            if (_dt == null) return;
            string kw = (txtTimKiem?.Text ?? "").Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(kw)) { dgvDSPhieuNhap.DataSource = _dt; return; }
            var view = _dt.DefaultView;
            view.RowFilter = $"MaPhieuNhap LIKE '%{kw}%' OR TenNCC LIKE '%{kw}%' OR TenNhanVien LIKE '%{kw}%'";
            dgvDSPhieuNhap.DataSource = view;
        }

        private void DgvDSPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = dgvDSPhieuNhap.Rows[e.RowIndex];
                if (textBox1 != null) textBox1.Text = row.Cells["MaPhieuNhap"].Value?.ToString() ?? "";
                if (textBox2 != null) textBox2.Text = Convert.ToDateTime(row.Cells["NgayNhap"].Value).ToString("dd/MM/yyyy");
                if (textBox3 != null) textBox3.Text = row.Cells["TenNCC"].Value?.ToString() ?? "";
                if (textBox4 != null) textBox4.Text = row.Cells["TenNhanVien"].Value?.ToString() ?? "";
                if (textBox5 != null) textBox5.Text = Convert.ToDecimal(row.Cells["TongTien"].Value).ToString("N0");
            }
            catch { }
        }
    }
}
