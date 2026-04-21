using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh_Forms.Data;
using QuanLyCuaHangMayTinh_Forms.Enums;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    public partial class frmLoaiSanPham : Form
    {
        private readonly string _currentRole;
        private bool _canManage;
        private FormMode _mode = FormMode.View;

        public frmLoaiSanPham() : this("Admin")
        {
        }

        public frmLoaiSanPham(string currentRole)
        {
            _currentRole = currentRole;
            InitializeComponent();
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            lblVaiTro.Text = "Vai trò hiện tại: " + _currentRole;
            _canManage = string.Equals(_currentRole, "Admin", StringComparison.CurrentCultureIgnoreCase)
                      || string.Equals(_currentRole, "Nhân viên kho", StringComparison.CurrentCultureIgnoreCase);

            LoadLoaiSanPham();
            SetFormMode(FormMode.View);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadLoaiSanPham(txtTimKiem.Text.Trim());
        }

        private void LoadLoaiSanPham(string keyword = "")
        {
            const string query = @"
SELECT MaLoai, TenLoai
FROM LoaiSanPham
WHERE (@Keyword = N'' OR MaLoai LIKE @LikeKeyword OR TenLoai LIKE @LikeKeyword)
ORDER BY TenLoai;";

            try
            {
                dgvLoaiSanPham.DataSource = DbHelper.GetDataTable(
                    query,
                    new SqlParameter("@Keyword", keyword ?? string.Empty),
                    new SqlParameter("@LikeKeyword", $"%{keyword?.Trim()}%"));

                if (dgvLoaiSanPham.Columns.Count > 0)
                {
                    dgvLoaiSanPham.Columns["MaLoai"].HeaderText = "Mã loại";
                    dgvLoaiSanPham.Columns["TenLoai"].HeaderText = "Tên loại";
                }

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

        private void dgvLoaiSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (_mode == FormMode.View)
            {
                FillInputsFromGrid();
                ApplyPermissions();
            }
        }

        private void FillInputsFromGrid()
        {
            if (dgvLoaiSanPham.CurrentRow == null || dgvLoaiSanPham.CurrentRow.DataBoundItem == null)
                return;

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
            btnSua.Enabled = _canManage && _mode == FormMode.View && dgvLoaiSanPham.CurrentRow != null;
            btnXoa.Enabled = _canManage && _mode == FormMode.View && dgvLoaiSanPham.CurrentRow != null;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

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
                int duplicate = DbHelper.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM LoaiSanPham WHERE MaLoai = @Ma OR TenLoai = @Ten;",
                    new SqlParameter("@Ma", txtMaLoai.Text.Trim()),
                    new SqlParameter("@Ten", txtTenLoai.Text.Trim()));

                if (duplicate > 0)
                {
                    MessageBox.Show("Mã loại hoặc tên loại đã tồn tại.");
                    return false;
                }
            }
            else if (_mode == FormMode.Edit)
            {
                int duplicate = DbHelper.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM LoaiSanPham WHERE TenLoai = @Ten AND MaLoai <> @Ma;",
                    new SqlParameter("@Ten", txtTenLoai.Text.Trim()),
                    new SqlParameter("@Ma", txtMaLoai.Text.Trim()));

                if (duplicate > 0)
                {
                    MessageBox.Show("Tên loại đã tồn tại.");
                    return false;
                }
            }

            return true;
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
            int usedCount = DbHelper.ExecuteScalar<int>(
                "SELECT COUNT(1) FROM SanPham WHERE MaLoai = @MaLoai;",
                new SqlParameter("@MaLoai", maLoai));

            if (usedCount > 0)
            {
                MessageBox.Show("Không thể xóa vì loại sản phẩm đã được sử dụng trong bảng Sản phẩm.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm này không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                DbHelper.ExecuteNonQuery(
                    "DELETE FROM LoaiSanPham WHERE MaLoai = @Ma;",
                    new SqlParameter("@Ma", maLoai));

                LoadLoaiSanPham(txtTimKiem.Text.Trim());
                SetFormMode(FormMode.View);
                MessageBox.Show("Xóa loại sản phẩm thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được loại sản phẩm.\n" + ex.Message,
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
                        "INSERT INTO LoaiSanPham (MaLoai, TenLoai) VALUES (@Ma, @Ten);",
                        new SqlParameter("@Ma", txtMaLoai.Text.Trim()),
                        new SqlParameter("@Ten", txtTenLoai.Text.Trim()));
                }
                else if (_mode == FormMode.Edit)
                {
                    DbHelper.ExecuteNonQuery(
                        "UPDATE LoaiSanPham SET TenLoai = @Ten WHERE MaLoai = @Ma;",
                        new SqlParameter("@Ma", txtMaLoai.Text.Trim()),
                        new SqlParameter("@Ten", txtTenLoai.Text.Trim()));
                }

                LoadLoaiSanPham(txtTimKiem.Text.Trim());
                SetFormMode(FormMode.View);
                MessageBox.Show("Lưu loại sản phẩm thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lưu được loại sản phẩm.\n" + ex.Message,
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
            LoadLoaiSanPham();
            SetFormMode(FormMode.View);
        }
    }
}
