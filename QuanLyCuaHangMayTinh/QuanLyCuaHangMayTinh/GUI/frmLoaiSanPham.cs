using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmLoaiSanPham : Form
    {
        private enum FormMode
        {
            View,
            Add,
            Edit
        }

        private readonly string _currentRole;
        private readonly bool _canManage;
        private FormMode _mode = FormMode.View;

        public frmLoaiSanPham() : this("Admin")
        {
        }

        public frmLoaiSanPham(string currentRole)
        {
            _currentRole = string.IsNullOrWhiteSpace(currentRole) ? "Admin" : currentRole;
            _canManage = string.Equals(_currentRole, "Admin", StringComparison.CurrentCultureIgnoreCase)
                      || string.Equals(_currentRole, "Nhân viên kho", StringComparison.CurrentCultureIgnoreCase)
                      || string.Equals(_currentRole, "NhanVienKho", StringComparison.CurrentCultureIgnoreCase);
            InitializeComponent();
        }

        private void LoadLoaiSanPham(string keyword = "")
        {
            try
            {
                string sql = @"SELECT MaLoai, TenLoai
                               FROM LoaiSanPham
                               WHERE (@kw = N'' OR MaLoai LIKE @likeKw OR TenLoai LIKE @likeKw)
                               ORDER BY TenLoai";

                DataTable dt = Function.GetDataToTable(
                    sql,
                    new SqlParameter("@kw", keyword ?? string.Empty),
                    new SqlParameter("@likeKw", "%" + (keyword ?? string.Empty).Trim() + "%"));

                dgvLoaiSanPham.DataSource = dt;
                if (dgvLoaiSanPham.Columns.Contains("MaLoai")) dgvLoaiSanPham.Columns["MaLoai"].HeaderText = "Mã loại";
                if (dgvLoaiSanPham.Columns.Contains("TenLoai")) dgvLoaiSanPham.Columns["TenLoai"].HeaderText = "Tên loại";

                if (dgvLoaiSanPham.Rows.Count > 0)
                {
                    dgvLoaiSanPham.Rows[0].Selected = true;
                    FillInputsFromGrid();
                }
                else
                {
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu loại sản phẩm.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ApplyPermissions();
        }

        private void FillInputsFromGrid()
        {
            if (dgvLoaiSanPham.CurrentRow == null || dgvLoaiSanPham.CurrentRow.Cells.Count == 0) return;
            txtMaLoai.Text = Convert.ToString(dgvLoaiSanPham.CurrentRow.Cells["MaLoai"].Value);
            txtTenLoai.Text = Convert.ToString(dgvLoaiSanPham.CurrentRow.Cells["TenLoai"].Value);
        }

        private void ClearInputs()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
        }

        private void SetFormMode(FormMode mode)
        {
            _mode = mode;
            if (_mode == FormMode.View)
                FillInputsFromGrid();
            else if (_mode == FormMode.Add)
                ClearInputs();

            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            bool editing = _canManage && _mode != FormMode.View;

            btnThem.Enabled = _canManage && _mode == FormMode.View;
            btnSua.Enabled = _canManage && _mode == FormMode.View && dgvLoaiSanPham.CurrentRow != null;
            btnXoa.Enabled = _canManage && _mode == FormMode.View && dgvLoaiSanPham.CurrentRow != null;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
            btnTimKiem.Enabled = true;
            btnLamMoi.Enabled = true;

            txtMaLoai.ReadOnly = _mode != FormMode.Add;
            txtTenLoai.ReadOnly = !editing;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Mã loại không được để trống.");
                txtMaLoai.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Tên loại không được để trống.");
                txtTenLoai.Focus();
                return false;
            }

            if (_mode == FormMode.Add)
            {
                bool trùngMã = Function.CheckKey("SELECT MaLoai FROM LoaiSanPham WHERE MaLoai = N'" + txtMaLoai.Text.Trim().Replace("'", "''") + "'");
                if (trùngMã)
                {
                    MessageBox.Show("Mã loại đã tồn tại.");
                    txtMaLoai.Focus();
                    return false;
                }
            }

            bool trùngTên = Function.CheckKey(
                "SELECT MaLoai FROM LoaiSanPham WHERE TenLoai = N'" + txtTenLoai.Text.Trim().Replace("'", "''") + "' AND MaLoai <> N'" + txtMaLoai.Text.Trim().Replace("'", "''") + "'");
            if (trùngTên)
            {
                MessageBox.Show("Tên loại đã tồn tại.");
                txtTenLoai.Focus();
                return false;
            }

            return true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadLoaiSanPham(txtTimKiem.Text.Trim());
            SetFormMode(FormMode.View);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetFormMode(FormMode.Add);
            txtMaLoai.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLoaiSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm cần sửa.");
                return;
            }

            SetFormMode(FormMode.Edit);
            txtTenLoai.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoaiSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm cần xóa.");
                return;
            }

            string maLoai = txtMaLoai.Text.Trim();
            bool daSuDung = Function.CheckKey("SELECT MaSanPham FROM SanPham WHERE MaLoai = N'" + maLoai.Replace("'", "''") + "'");
            if (daSuDung)
            {
                MessageBox.Show("Không thể xóa vì loại sản phẩm đã được dùng trong bảng Sản phẩm.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            Function.RunSqlDel("DELETE FROM LoaiSanPham WHERE MaLoai = N'" + maLoai.Replace("'", "''") + "'");
            LoadLoaiSanPham(txtTimKiem.Text.Trim());
            SetFormMode(FormMode.View);
            MessageBox.Show("Xóa loại sản phẩm thành công.");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string ma = txtMaLoai.Text.Trim().Replace("'", "''");
            string ten = txtTenLoai.Text.Trim().Replace("'", "''");

            if (_mode == FormMode.Add)
                Function.RunSql("INSERT INTO LoaiSanPham(MaLoai, TenLoai) VALUES (N'" + ma + "', N'" + ten + "')");
            else if (_mode == FormMode.Edit)
                Function.RunSql("UPDATE LoaiSanPham SET TenLoai = N'" + ten + "' WHERE MaLoai = N'" + ma + "'");

            LoadLoaiSanPham(txtTimKiem.Text.Trim());
            SetFormMode(FormMode.View);
            MessageBox.Show("Lưu loại sản phẩm thành công.");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetFormMode(FormMode.View);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadLoaiSanPham();
            SetFormMode(FormMode.View);
        }

        private void dgvLoaiSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (_mode == FormMode.View)
            {
                FillInputsFromGrid();
                ApplyPermissions();
            }
        }
    }
}
