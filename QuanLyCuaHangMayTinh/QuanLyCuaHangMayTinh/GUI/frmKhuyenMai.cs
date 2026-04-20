using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmKhuyenMai : Form
    {
        private DataTable tblNCC;
        public frmKhuyenMai()
        {
            InitializeComponent();
        }

        private void frmKhuyenMai_Load(object sender, EventArgs e)
        {
            Function.Connect();
            this.Text = "Quản lý nhà cung cấp";
            dtpNgayBD.Visible = false;
            dtpNgayKT.Visible = false;
            txtMaKM.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }

        private void Load_DataGridView()
        {
            string sql = "SELECT MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai FROM NhaCungCap";
            tblNCC = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblNCC;
            if (DataGridView.Columns.Count >= 4)
            {
                DataGridView.Columns[0].HeaderText = "Mã NCC";
                DataGridView.Columns[1].HeaderText = "Tên nhà cung cấp";
                DataGridView.Columns[2].HeaderText = "Địa chỉ";
                DataGridView.Columns[3].HeaderText = "Số điện thoại";
            }
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaKM.Text = string.Empty;
            txtMucKM.Text = string.Empty;
            txtDieuKien.Text = string.Empty;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (tblNCC == null || tblNCC.Rows.Count == 0 || DataGridView.CurrentRow == null) return;
            txtMaKM.Text = Convert.ToString(DataGridView.CurrentRow.Cells[0].Value);
            txtMucKM.Text = Convert.ToString(DataGridView.CurrentRow.Cells[1].Value);
            txtDieuKien.Text = Convert.ToString(DataGridView.CurrentRow.Cells[2].Value);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLamMoi.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaKM.Enabled = true;
            txtMaKM.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKM.Text)) return;
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Function.RunSqlDel("DELETE FROM NhaCungCap WHERE MaNhaCungCap=@Ma", new SqlParameter("@Ma", txtMaKM.Text.Trim()));
            Load_DataGridView();
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKM.Text) || string.IsNullOrWhiteSpace(txtMucKM.Text)) return;
            Function.RunSql("UPDATE NhaCungCap SET TenNhaCungCap=@Ten, DiaChi=@DiaChi WHERE MaNhaCungCap=@Ma",
                new SqlParameter("@Ten", txtMucKM.Text.Trim()),
                new SqlParameter("@DiaChi", txtDieuKien.Text.Trim()),
                new SqlParameter("@Ma", txtMaKM.Text.Trim()));
            Load_DataGridView();
            ResetValues();
            btnLamMoi.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKM.Text) || string.IsNullOrWhiteSpace(txtMucKM.Text))
            {
                MessageBox.Show("Bạn phải nhập mã và tên nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Function.CheckKey("SELECT MaNhaCungCap FROM NhaCungCap WHERE MaNhaCungCap=N'" + txtMaKM.Text.Trim() + "'"))
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Function.RunSql("INSERT INTO NhaCungCap(MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai) VALUES(@Ma,@Ten,@DiaChi,@SDT)",
                new SqlParameter("@Ma", txtMaKM.Text.Trim()),
                new SqlParameter("@Ten", txtMucKM.Text.Trim()),
                new SqlParameter("@DiaChi", txtDieuKien.Text.Trim()),
                new SqlParameter("@SDT", string.Empty));
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaKM.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai FROM NhaCungCap WHERE 1=1";
            if (!string.IsNullOrWhiteSpace(txtMaKM.Text)) sql += " AND MaNhaCungCap LIKE N'%" + txtMaKM.Text.Trim() + "%'";
            if (!string.IsNullOrWhiteSpace(txtMucKM.Text)) sql += " AND TenNhaCungCap LIKE N'%" + txtMucKM.Text.Trim() + "%'";
            if (!string.IsNullOrWhiteSpace(txtDieuKien.Text)) sql += " AND DiaChi LIKE N'%" + txtDieuKien.Text.Trim() + "%'";
            tblNCC = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblNCC;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            Load_DataGridView();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            txtMaKM.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
