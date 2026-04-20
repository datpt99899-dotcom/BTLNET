using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh
{
    public partial class frm_quanlyban : Form
    {
        private DataTable tblDon;
        public frm_quanlyban()
        {
            InitializeComponent();
        }

        private void frm_quanlyban_Load(object sender, EventArgs e)
        {
            Function.Connect();
            this.Text = "Quản lý trạng thái đơn hàng";
            txtMaban.Enabled = false;
            ibtnLuu.Enabled = false;
            Load_DataGridView();
            cboTinhtrang.Items.Clear();
            cboTinhtrang.Items.AddRange(new object[] { "Chờ xử lý", "Đang giao", "Đã giao", "Hủy", "Hoàn thành" });
            datagridBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }

        private void Load_DataGridView()
        {
            string sql = "SELECT MaDonDatHang, TongTien, TrangThai FROM DonDatHang ORDER BY NgayDat DESC";
            tblDon = Function.GetDataToTable(sql);
            datagridBan.DataSource = tblDon;
            if (datagridBan.Columns.Count >= 3)
            {
                datagridBan.Columns[0].HeaderText = "Mã đơn";
                datagridBan.Columns[1].HeaderText = "Tổng tiền";
                datagridBan.Columns[2].HeaderText = "Trạng thái";
            }
            datagridBan.AllowUserToAddRows = false;
            datagridBan.EditMode = DataGridViewEditMode.EditProgrammatically;
            DoiMauTrangThaiDon();
        }

        private void DoiMauTrangThaiDon()
        {
            foreach (DataGridViewRow row in datagridBan.Rows)
            {
                if (row.Cells[2].Value == null) continue;
                string trangThai = Convert.ToString(row.Cells[2].Value);
                if (trangThai == "Hoàn thành" || trangThai == "Đã giao") row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (trangThai == "Hủy") row.DefaultCellStyle.BackColor = Color.LightPink;
                else row.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void datagridBan_Click(object sender, EventArgs e)
        {
            if (tblDon == null || tblDon.Rows.Count == 0 || datagridBan.CurrentRow == null) return;
            txtMaban.Text = Convert.ToString(datagridBan.CurrentRow.Cells[0].Value);
            txtSoluongghe.Text = Convert.ToString(datagridBan.CurrentRow.Cells[1].Value);
            cboTinhtrang.Text = Convert.ToString(datagridBan.CurrentRow.Cells[2].Value);
            ibtnSua.Enabled = true;
            ibtnXoa.Enabled = true;
            ibtnThem.Enabled = false;
            ibtnLuu.Enabled = false;
            txtMaban.Enabled = false;
        }

        private void ResetValues()
        {
            txtMaban.Text = string.Empty;
            txtSoluongghe.Text = string.Empty;
            cboTinhtrang.Text = string.Empty;
            ibtnThem.Enabled = true;
            ibtnXoa.Enabled = true;
            txtMaban.Focus();
        }

        private void ibtnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng dùng form Đơn đặt hàng để tạo đơn mới trong schema dữ liệu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ibtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaban.Text) || string.IsNullOrWhiteSpace(cboTinhtrang.Text)) return;
            Function.RunSql("UPDATE DonDatHang SET TrangThai=@TrangThai WHERE MaDonDatHang=@Ma",
                new SqlParameter("@TrangThai", cboTinhtrang.Text.Trim()),
                new SqlParameter("@Ma", txtMaban.Text.Trim()));
            Load_DataGridView();
            ResetValues();
        }

        private void ibtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaban.Text)) return;
            if (MessageBox.Show("Đánh dấu hủy đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Function.RunSql("UPDATE DonDatHang SET TrangThai=N'Hủy' WHERE MaDonDatHang=@Ma", new SqlParameter("@Ma", txtMaban.Text.Trim()));
            Load_DataGridView();
            ResetValues();
        }

        private void ibtnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng lưu mới đã được chuyển sang form Đơn đặt hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ibtnLamoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            Load_DataGridView();
        }

        private void datagridBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
