using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh_Forms.Data;
using QuanLyCuaHangMayTinh_Forms.Enums;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    public partial class frmNhaCungCap : Form
    {
        private readonly string _currentRole;
        private bool _canManage;
        private FormMode _mode = FormMode.View;

        public frmNhaCungCap() : this("Admin")
        {
        }

        public frmNhaCungCap(string currentRole)
        {
            _currentRole = currentRole;
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            lblVaiTro.Text = "Vai trò hiện tại: " + _currentRole;
            _canManage = string.Equals(_currentRole, "Admin", StringComparison.CurrentCultureIgnoreCase)
                      || string.Equals(_currentRole, "Nhân viên kho", StringComparison.CurrentCultureIgnoreCase);

            LoadNhaCungCap();
            SetFormMode(FormMode.View);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadNhaCungCap(txtTimKiem.Text.Trim());
        }

        private void LoadNhaCungCap(string keyword = "")
        {
            const string query = @"
SELECT MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai
FROM NhaCungCap
WHERE (@Keyword = N''
       OR MaNhaCungCap LIKE @LikeKeyword
       OR TenNhaCungCap LIKE @LikeKeyword
       OR SoDienThoai LIKE @LikeKeyword)
ORDER BY TenNhaCungCap;";

            try
            {
                dgvNhaCungCap.DataSource = DbHelper.GetDataTable(
                    query,
                    new SqlParameter("@Keyword", keyword ?? string.Empty),
                    new SqlParameter("@LikeKeyword", $"%{keyword?.Trim()}%"));

                if (dgvNhaCungCap.Columns.Count > 0)
                {
                    dgvNhaCungCap.Columns["MaNhaCungCap"].HeaderText = "Mã NCC";
                    dgvNhaCungCap.Columns["TenNhaCungCap"].HeaderText = "Tên nhà cung cấp";
                    dgvNhaCungCap.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    dgvNhaCungCap.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                }

                if (dgvNhaCungCap.Rows.Count > 0)
                {
                    dgvNhaCungCap.Rows[0].Selected = true;
                    FillInputsFromGrid();
                }
                else
                {
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu nhà cung cấp.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ApplyPermissions();
        }

        private void dgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (_mode == FormMode.View)
            {
                FillInputsFromGrid();
                ApplyPermissions();
            }
        }

        private void FillInputsFromGrid()
        {
            if (dgvNhaCungCap.CurrentRow == null || dgvNhaCungCap.CurrentRow.DataBoundItem == null)
                return;

            txtMaNhaCungCap.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["MaNhaCungCap"].Value);
            txtTenNhaCungCap.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["TenNhaCungCap"].Value);
            txtDiaChi.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value);
            txtSoDienThoai.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["SoDienThoai"].Value);
        }

        private void ClearInputs()
        {
            txtMaNhaCungCap.Clear();
            txtTenNhaCungCap.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
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
            btnSua.Enabled = _canManage && _mode == FormMode.View && dgvNhaCungCap.CurrentRow != null;
            btnXoa.Enabled = _canManage && _mode == FormMode.View && dgvNhaCungCap.CurrentRow != null;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

            txtMaNhaCungCap.ReadOnly = _mode != FormMode.Add;
            txtTenNhaCungCap.ReadOnly = !editing;
            txtDiaChi.ReadOnly = !editing;
            txtSoDienThoai.ReadOnly = !editing;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaNhaCungCap.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống.");
                txtMaNhaCungCap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenNhaCungCap.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống.");
                txtTenNhaCungCap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.");
                txtSoDienThoai.Focus();
                return false;
            }

            if (!txtSoDienThoai.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số.");
                txtSoDienThoai.Focus();
                return false;
            }

            if (txtSoDienThoai.Text.Length < 9 || txtSoDienThoai.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại nên có từ 9 đến 11 số.");
                txtSoDienThoai.Focus();
                return false;
            }

            if (_mode == FormMode.Add)
            {
                int duplicate = DbHelper.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM NhaCungCap WHERE MaNhaCungCap = @Ma;",
                    new SqlParameter("@Ma", txtMaNhaCungCap.Text.Trim()));

                if (duplicate > 0)
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại.");
                    return false;
                }
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetFormMode(FormMode.Add);
            txtMaNhaCungCap.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa.");
                return;
            }

            SetFormMode(FormMode.Edit);
            txtTenNhaCungCap.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa.");
                return;
            }

            string ma = txtMaNhaCungCap.Text.Trim();
            int productCount = DbHelper.ExecuteScalar<int>(
                "SELECT COUNT(1) FROM SanPham WHERE MaNhaCungCap = @Ma;",
                new SqlParameter("@Ma", ma));
            int importCount = DbHelper.ExecuteScalar<int>(
                "SELECT COUNT(1) FROM PhieuNhapKho WHERE MaNhaCungCap = @Ma;",
                new SqlParameter("@Ma", ma));

            if (productCount > 0 || importCount > 0)
            {
                MessageBox.Show("Không thể xóa vì nhà cung cấp đã phát sinh dữ liệu liên quan.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                DbHelper.ExecuteNonQuery(
                    "DELETE FROM NhaCungCap WHERE MaNhaCungCap = @Ma;",
                    new SqlParameter("@Ma", ma));
                LoadNhaCungCap(txtTimKiem.Text.Trim());
                SetFormMode(FormMode.View);
                MessageBox.Show("Xóa thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được dữ liệu.\n" + ex.Message);
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
                        @"INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai)
                          VALUES (@Ma, @Ten, @DiaChi, @SoDienThoai);",
                        new SqlParameter("@Ma", txtMaNhaCungCap.Text.Trim()),
                        new SqlParameter("@Ten", txtTenNhaCungCap.Text.Trim()),
                        new SqlParameter("@DiaChi", string.IsNullOrWhiteSpace(txtDiaChi.Text) ? (object)DBNull.Value : txtDiaChi.Text.Trim()),
                        new SqlParameter("@SoDienThoai", txtSoDienThoai.Text.Trim()));
                }
                else if (_mode == FormMode.Edit)
                {
                    DbHelper.ExecuteNonQuery(
                        @"UPDATE NhaCungCap
                          SET TenNhaCungCap = @Ten, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai
                          WHERE MaNhaCungCap = @Ma;",
                        new SqlParameter("@Ma", txtMaNhaCungCap.Text.Trim()),
                        new SqlParameter("@Ten", txtTenNhaCungCap.Text.Trim()),
                        new SqlParameter("@DiaChi", string.IsNullOrWhiteSpace(txtDiaChi.Text) ? (object)DBNull.Value : txtDiaChi.Text.Trim()),
                        new SqlParameter("@SoDienThoai", txtSoDienThoai.Text.Trim()));
                }

                LoadNhaCungCap(txtTimKiem.Text.Trim());
                SetFormMode(FormMode.View);
                MessageBox.Show("Lưu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lưu được dữ liệu.\n" + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetFormMode(FormMode.View);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadNhaCungCap();
            SetFormMode(FormMode.View);
        }
    }
}
