using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmNguyenLieu: Form
    {
        DataTable tblNL;
        public frmNguyenLieu()
        {
            InitializeComponent();
        }

        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            Function.Connect();
            txtMaNL.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaNguyenLieu, TenNguyenLieu, SoLuongHienCo, DonViTinh from NguyenLieu";
            tblNL = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblNL;
            DataGridView.Columns[0].HeaderText = "Mã sản phẩm";
            DataGridView.Columns[1].HeaderText = "Tên sản phẩm";
            DataGridView.Columns[2].HeaderText = "Số lượng hiện có";
            DataGridView.Columns[3].HeaderText = "Đơn vị tính";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaNL.Text = "";
            txtTenNL.Text = "";
            txtSoLuongTon.Text = "";
            txtDonViTinh.Text = "";
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNL.Focus();
                return;
            }
            if (tblNL.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNL.Text = DataGridView.CurrentRow.Cells["MaNguyenLieu"].Value.ToString();
            txtTenNL.Text = DataGridView.CurrentRow.Cells["TenNguyenLieu"].Value.ToString();
            txtDonViTinh.Text = DataGridView.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtSoLuongTon.Text = DataGridView.CurrentRow.Cells["SoLuongHienCo"].Value.ToString();
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
            txtMaNL.Enabled = true;
            txtMaNL.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNL.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NguyenLieu WHERE MaNguyenLieu = '" + txtMaNL.Text.Trim() + "'";
                Function.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNL.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNL.Focus();
                return;
            }
            if (txtTenNL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNL.Focus();
                return;
            }
            if (txtDonViTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonViTinh.Focus();
                return;
            }
            if (txtSoLuongTon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongTon.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "UPDATE NguyenLieu SET TenNguyenLieu=N'" + txtTenNL.Text.Trim().ToString() +
                    "',DonViTinh=N'" + txtDonViTinh.Text.Trim().ToString() +
                    "',SoLuongHienCo='" + txtSoLuongTon.Text.Trim().ToString() +
                    "' WHERE MaNguyenLieu=N'" + txtMaNL.Text + "'";
                Function.RunSql(sql);
                Load_DataGridView();
                ResetValues();
                btnLamMoi.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNL.Focus();
                return;
            }
            if (txtTenNL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNL.Focus();
                return;
            }
            if (txtDonViTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonViTinh.Focus();
                return;
            }
            if (txtSoLuongTon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongTon.Focus();
                return;
            }
            sql = "SELECT MaNguyenLieu FROM NguyenLieu WHERE MaNguyenLieu=N'" + txtMaNL.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNL.Focus();
                txtMaNL.Text = "";
                return;
            }
            sql = "INSERT INTO NguyenLieu(MaNguyenLieu, TenNguyenLieu, DonViTinh, SoLuongHienCo) VALUES (N'" + txtMaNL.Text.Trim() +
                "',N'" + txtTenNL.Text.Trim() +
                "',N'" + txtDonViTinh.Text.Trim() +
                "','" + txtSoLuongTon.Text.Trim() + "')";
            Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNL.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaNL.Text == "") && (txtTenNL.Text == "") && (txtDonViTinh.Text == "") && (txtSoLuongTon.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM NguyenLieu WHERE 1=1";
            if (txtMaNL.Text != "")
                sql += " AND MaNguyenLieu LIKE N'%" + txtMaNL.Text + "%'";
            if (txtTenNL.Text != "")
                sql += " AND TenNguyenLieu LIKE N'%" + txtTenNL.Text + "%'";
            if (txtDonViTinh.Text != "")
                sql += " AND DonViTinh LIKE N'%" + txtDonViTinh.Text + "%'";
            if (txtSoLuongTon.Text != "")
                sql += " AND SoLuongHienCo LIKE N'%" + txtSoLuongTon.Text + "%'";
            tblNL = Function.GetDataToTable(sql);
            if (tblNL.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblNL.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblNL;
            ResetValues();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnLamMoi.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNL.Enabled = false;
        }

        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b') // \b = Backspace
                e.Handled = true;

            if ((e.KeyChar == '.' && tb.Text.Contains(".")))
                e.Handled = true;
        }
    }
}
