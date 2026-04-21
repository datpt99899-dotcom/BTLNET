using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh_Forms.Data;
using QuanLyCuaHangMayTinh_Forms.Enums;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    public partial class frmThuongHieu : Form
    {
        private readonly string _currentRole;
        private bool _canManage;
        private FormMode _mode = FormMode.View;

        public frmThuongHieu() : this("Admin")
        {
        }

        public frmThuongHieu(string currentRole)
        {
            _currentRole = currentRole;
            InitializeComponent();
        }

        private void frmThuongHieu_Load(object sender, EventArgs e)
        {
            lblVaiTro.Text = "Vai trò hiện tại: " + _currentRole;
            _canManage = string.Equals(_currentRole, "Admin", StringComparison.CurrentCultureIgnoreCase)
                      || string.Equals(_currentRole, "Nhân viên kho", StringComparison.CurrentCultureIgnoreCase);

            LoadThuongHieu();
            SetFormMode(FormMode.View);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadThuongHieu(txtTimKiem.Text.Trim());
        }

        private void LoadThuongHieu(string keyword = "")
        {
            const string query = @"
SELECT MaThuongHieu, TenThuongHieu
FROM ThuongHieu
WHERE (@Keyword = N'' OR MaThuongHieu LIKE @LikeKeyword OR TenThuongHieu LIKE @LikeKeyword)
ORDER BY TenThuongHieu;";

            try
            {
                dgvThuongHieu.DataSource = DbHelper.GetDataTable(
                    query,
                    new SqlParameter("@Keyword", keyword ?? string.Empty),
                    new SqlParameter("@LikeKeyword", $"%{keyword?.Trim()}%"));

                if (dgvThuongHieu.Columns.Count > 0)
                {
                    dgvThuongHieu.Columns["MaThuongHieu"].HeaderText = "Mã thương hiệu";
                    dgvThuongHieu.Columns["TenThuongHieu"].HeaderText = "Tên thương hiệu";
                }

                if (dgvThuongHieu.Rows.Count > 0)
                {
                    dgvThuongHieu.Rows[0].Selected = true;
                    FillInputsFromGrid();
                }
                else
                {
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu thương hiệu.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ApplyPermissions();
        }

        private void dgvThuongHieu_SelectionChanged(object sender, EventArgs e)
        {
            if (_mode == FormMode.View)
            {
                FillInputsFromGrid();
                ApplyPermissions();
            }
        }

        private void FillInputsFromGrid()
        {
            if (dgvThuongHieu.CurrentRow == null || dgvThuongHieu.CurrentRow.DataBoundItem == null)
                return;

            txtMaThuongHieu.Text = Convert.ToString(dgvThuongHieu.CurrentRow.Cells["MaThuongHieu"].Value);
            txtTenThuongHieu.Text = Convert.ToString(dgvThuongHieu.CurrentRow.Cells["TenThuongHieu"].Value);
        }

        private void ClearInputs()
        {
            txtMaThuongHieu.Clear();
            txtTenThuongHieu.Clear();
        }

        private void SetFormMode(FormMode mode)
        {
            _mode = mode;

            if (mode == FormMode.View)
            {
                FillInputsFromGrid();
            }
            else if (mode == FormMode.Add)
            {
                ClearInputs();
            }

            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            bool editing = _canManage && _mode != FormMode.View;

            btnThem.Enabled = _canManage && _mode == FormMode.View;
            btnSua.Enabled = _canManage && _mode == FormMode.View && dgvThuongHieu.CurrentRow != null;
            btnXoa.Enabled = _canManage && _mode == FormMode.View && dgvThuongHieu.CurrentRow != null;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

            txtMaThuongHieu.ReadOnly = _mode != FormMode.Add;
            txtTenThuongHieu.ReadOnly = !editing;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaThuongHieu.Text))
            {
                MessageBox.Show("Mã thương hiệu không được để trống.");
                txtMaThuongHieu.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenThuongHieu.Text))
            {
                MessageBox.Show("Tên thương hiệu không được để trống.");
                txtTenThuongHieu.Focus();
                return false;
            }

            if (_mode == FormMode.Add)
            {
                int duplicate = DbHelper.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM ThuongHieu WHERE MaThuongHieu = @Ma OR TenThuongHieu = @Ten;",
                    new SqlParameter("@Ma", txtMaThuongHieu.Text.Trim()),
                    new SqlParameter("@Ten", txtTenThuongHieu.Text.Trim()));

                if (duplicate > 0)
                {
                    MessageBox.Show("Mã thương hiệu hoặc tên thương hiệu đã tồn tại.");
                    return false;
                }
            }
            else if (_mode == FormMode.Edit)
            {
                int duplicate = DbHelper.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM ThuongHieu WHERE TenThuongHieu = @Ten AND MaThuongHieu <> @Ma;",
                    new SqlParameter("@Ten", txtTenThuongHieu.Text.Trim()),
                    new SqlParameter("@Ma", txtMaThuongHieu.Text.Trim()));

                if (duplicate > 0)
                {
                    MessageBox.Show("Tên thương hiệu đã tồn tại.");
                    return false;
                }
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetFormMode(FormMode.Add);
            txtMaThuongHieu.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThuongHieu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thương hiệu cần sửa.");
                return;
            }

            SetFormMode(FormMode.Edit);
            txtTenThuongHieu.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThuongHieu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thương hiệu cần xóa.");
                return;
            }

            string maThuongHieu = txtMaThuongHieu.Text.Trim();
            int usedCount = DbHelper.ExecuteScalar<int>(
                "SELECT COUNT(1) FROM SanPham WHERE MaThuongHieu = @Ma;",
                new SqlParameter("@Ma", maThuongHieu));

            if (usedCount > 0)
            {
                MessageBox.Show("Không thể xóa vì thương hiệu đã được gán cho sản phẩm.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa thương hiệu này không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                DbHelper.ExecuteNonQuery(
                    "DELETE FROM ThuongHieu WHERE MaThuongHieu = @Ma;",
                    new SqlParameter("@Ma", maThuongHieu));

                LoadThuongHieu(txtTimKiem.Text.Trim());
                SetFormMode(FormMode.View);
                MessageBox.Show("Xóa thương hiệu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được thương hiệu.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                if (_mode == FormMode.Add)
                {
                    DbHelper.ExecuteNonQuery(
                        "INSERT INTO ThuongHieu (MaThuongHieu, TenThuongHieu) VALUES (@Ma, @Ten);",
                        new SqlParameter("@Ma", txtMaThuongHieu.Text.Trim()),
                        new SqlParameter("@Ten", txtTenThuongHieu.Text.Trim()));
                }
                else if (_mode == FormMode.Edit)
                {
                    DbHelper.ExecuteNonQuery(
                        "UPDATE ThuongHieu SET TenThuongHieu = @Ten WHERE MaThuongHieu = @Ma;",
                        new SqlParameter("@Ma", txtMaThuongHieu.Text.Trim()),
                        new SqlParameter("@Ten", txtTenThuongHieu.Text.Trim()));
                }

                LoadThuongHieu(txtTimKiem.Text.Trim());
                SetFormMode(FormMode.View);
                MessageBox.Show("Lưu thương hiệu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lưu được thương hiệu.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetFormMode(FormMode.View);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadThuongHieu();
            SetFormMode(FormMode.View);
        }
    }
}
