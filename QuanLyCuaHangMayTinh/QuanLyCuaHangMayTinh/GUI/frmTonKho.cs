using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmNguyenLieu : Form
    {
        private DataTable tblSanPham;
        public frmNguyenLieu()
        {
            InitializeComponent();
        }

        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            Function.Connect();
            this.Text = "Danh mục sản phẩm";
            txtMaNL.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }

        private void Load_DataGridView()
        {
            string sql = @"SELECT sp.MaSanPham, sp.TenSanPham, sp.SoLuongTon,
                                  CONCAT(ls.TenLoai, ' / ', th.TenThuongHieu) AS MoTa
                           FROM SanPham sp
                           LEFT JOIN LoaiSanPham ls ON sp.MaLoai = ls.MaLoai
                           LEFT JOIN ThuongHieu th ON sp.MaThuongHieu = th.MaThuongHieu";
            tblSanPham = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblSanPham;
            if (DataGridView.Columns.Count >= 4)
            {
                DataGridView.Columns[0].HeaderText = "Mã sản phẩm";
                DataGridView.Columns[1].HeaderText = "Tên sản phẩm";
                DataGridView.Columns[2].HeaderText = "Số lượng tồn";
                DataGridView.Columns[3].HeaderText = "Loại / Thương hiệu";
            }
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaNL.Text = string.Empty;
            txtTenNL.Text = string.Empty;
            txtSoLuongTon.Text = string.Empty;
            txtDonViTinh.Text = string.Empty;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (tblSanPham == null || tblSanPham.Rows.Count == 0 || DataGridView.CurrentRow == null) return;
            txtMaNL.Text = Convert.ToString(DataGridView.CurrentRow.Cells[0].Value);
            txtTenNL.Text = Convert.ToString(DataGridView.CurrentRow.Cells[1].Value);
            txtSoLuongTon.Text = Convert.ToString(DataGridView.CurrentRow.Cells[2].Value);
            txtDonViTinh.Text = Convert.ToString(DataGridView.CurrentRow.Cells[3].Value);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng dùng form Quản lý sản phẩm để thêm mới sản phẩm theo schema dữ liệu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNL.Text)) return;
            if (MessageBox.Show("Xóa sản phẩm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Function.RunSqlDel("DELETE FROM SanPham WHERE MaSanPham = @MaSanPham", new System.Data.SqlClient.SqlParameter("@MaSanPham", txtMaNL.Text.Trim()));
            Load_DataGridView();
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNL.Text) || string.IsNullOrWhiteSpace(txtTenNL.Text)) return;
            int soLuong;
            int.TryParse(txtSoLuongTon.Text.Trim(), out soLuong);
            string sql = @"UPDATE SanPham
                           SET TenSanPham = @TenSanPham,
                               SoLuongTon = @SoLuongTon,
                               MoTa = @MoTa
                           WHERE MaSanPham = @MaSanPham";
            Function.RunSql(sql,
                new System.Data.SqlClient.SqlParameter("@TenSanPham", txtTenNL.Text.Trim()),
                new System.Data.SqlClient.SqlParameter("@SoLuongTon", soLuong),
                new System.Data.SqlClient.SqlParameter("@MoTa", txtDonViTinh.Text.Trim()),
                new System.Data.SqlClient.SqlParameter("@MaSanPham", txtMaNL.Text.Trim()));
            Load_DataGridView();
            ResetValues();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng dùng form Quản lý sản phẩm để thêm mới sản phẩm theo schema dữ liệu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT sp.MaSanPham, sp.TenSanPham, sp.SoLuongTon,
                                  CONCAT(ls.TenLoai, ' / ', th.TenThuongHieu) AS MoTa
                           FROM SanPham sp
                           LEFT JOIN LoaiSanPham ls ON sp.MaLoai = ls.MaLoai
                           LEFT JOIN ThuongHieu th ON sp.MaThuongHieu = th.MaThuongHieu
                           WHERE 1=1";
            if (!string.IsNullOrWhiteSpace(txtMaNL.Text)) sql += " AND sp.MaSanPham LIKE N'%" + txtMaNL.Text.Trim() + "%'";
            if (!string.IsNullOrWhiteSpace(txtTenNL.Text)) sql += " AND sp.TenSanPham LIKE N'%" + txtTenNL.Text.Trim() + "%'";
            if (!string.IsNullOrWhiteSpace(txtDonViTinh.Text)) sql += " AND sp.MoTa LIKE N'%" + txtDonViTinh.Text.Trim() + "%'";
            if (!string.IsNullOrWhiteSpace(txtSoLuongTon.Text)) sql += " AND CONVERT(nvarchar(20), sp.SoLuongTon) LIKE N'%" + txtSoLuongTon.Text.Trim() + "%'";
            tblSanPham = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblSanPham;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            Load_DataGridView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
