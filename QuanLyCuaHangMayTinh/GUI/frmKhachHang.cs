using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Form quản lý khách hàng - CRUD đầy đủ.
    /// Quyền: Admin (VT01) và NV Bán hàng (VT03) được sửa, role khác chỉ xem.
    /// </summary>
    public partial class frmKhachHang : Form
    {
        private DataTable _dt;
        private bool _isAdding = false;
        private readonly bool _canEdit;

        public frmKhachHang()
        {
            InitializeComponent();
            _canEdit = StaticData.MaVaiTro == "VT01" || StaticData.MaVaiTro == "VT03";
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);

            // Gắn event handler vì Designer chưa gắn
            btnHienthi.Click += (s, ev) => { LoadData(); ResetForm(); };
            btnThem.Click    += BtnThem_Click;
            btnSua.Click     += BtnSua_Click;
            btnXoa.Click     += BtnXoa_Click;
            btnLuu.Click     += BtnLuu_Click;
            btnBoqua.Click   += (s, ev) => { ResetForm(); EnableNhap(false); };
            btnTimkiem.Click += BtnTimkiem_Click;
            btnDong.Click    += (s, ev) => this.Hide();

            dgvKhachHang.CellClick += DgvKhachHang_CellClick;

            // Mã khách hàng tự sinh - không cho sửa
            txtMakhachhang.ReadOnly = true;
            txtMakhachhang.BackColor = Color.LightYellow;

            // Phân quyền nút
            if (!_canEdit)
            {
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
                var lbl = new Label
                {
                    Text = "[CHỈ XEM] Bạn không có quyền chỉnh sửa khách hàng.",
                    ForeColor = Color.DarkRed,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
                    AutoSize = true,
                    Location = new Point(20, 10)
                };
                Controls.Add(lbl);
                lbl.BringToFront();
            }

            LoadData();
            EnableNhap(false);
        }

        private void LoadData()
        {
            try
            {
                Function.Connect();
                _dt = Function.GetDataToTable(
                    "SELECT MaKhachHang, TenKhachHang, SoDienThoai, Email, DiaChi, DiemTichLuy " +
                    "FROM KhachHang ORDER BY MaKhachHang");

                dgvKhachHang.DataSource = _dt;

                if (dgvKhachHang.Columns.Count > 0)
                {
                    dgvKhachHang.Columns["MaKhachHang"].HeaderText = "Mã KH";
                    dgvKhachHang.Columns["TenKhachHang"].HeaderText = "Tên khách hàng";
                    dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                    dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    dgvKhachHang.Columns["DiemTichLuy"].HeaderText = "Điểm tích lũy";
                    dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu khách hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvKhachHang.Rows.Count) return;
            var r = dgvKhachHang.Rows[e.RowIndex];
            txtMakhachhang.Text = r.Cells["MaKhachHang"].Value?.ToString();
            txtTenkhachhang.Text = r.Cells["TenKhachHang"].Value?.ToString();
            mskDienthoai.Text = r.Cells["SoDienThoai"].Value?.ToString();
            txtEmail.Text = r.Cells["Email"].Value?.ToString();
            txtDiachi.Text = r.Cells["DiaChi"].Value?.ToString();
            _isAdding = false;
            EnableNhap(false);
        }

        private void EnableNhap(bool enable)
        {
            txtTenkhachhang.ReadOnly = !enable;
            mskDienthoai.ReadOnly = !enable;
            txtEmail.ReadOnly = !enable;
            txtDiachi.ReadOnly = !enable;
            btnLuu.Enabled = enable && _canEdit;
            btnBoqua.Enabled = enable;
        }

        private void ResetForm()
        {
            txtMakhachhang.Text = "";
            txtTenkhachhang.Text = "";
            mskDienthoai.Text = "";
            txtEmail.Text = "";
            txtDiachi.Text = "";
            _isAdding = false;
        }

        private string SinhMaMoi()
        {
            DataTable dt = Function.GetDataToTable(
                "SELECT TOP 1 MaKhachHang FROM KhachHang ORDER BY MaKhachHang DESC");
            if (dt == null || dt.Rows.Count == 0) return "KH001";
            string last = dt.Rows[0][0].ToString();
            if (last.Length > 2 && int.TryParse(last.Substring(2), out int n))
                return "KH" + (n + 1).ToString("D3");
            return "KH001";
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            ResetForm();
            txtMakhachhang.Text = SinhMaMoi();
            _isAdding = true;
            EnableNhap(true);
            txtTenkhachhang.Focus();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMakhachhang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _isAdding = false;
            EnableNhap(true);
            txtTenkhachhang.Focus();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtTenkhachhang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenkhachhang.Focus();
                return;
            }
            string sdt = mskDienthoai.Text.Trim().Replace(" ", "").Replace("-", "");
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }

            try
            {
                if (_isAdding)
                {
                    Function.RunSql(
                        @"INSERT INTO KhachHang(MaKhachHang, TenKhachHang, SoDienThoai, Email, DiaChi, DiemTichLuy)
                          VALUES(@m, @t, @s, @e, @d, 0)",
                        new SqlParameter("@m", txtMakhachhang.Text.Trim()),
                        new SqlParameter("@t", txtTenkhachhang.Text.Trim()),
                        new SqlParameter("@s", sdt),
                        new SqlParameter("@e", (object)txtEmail.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@d", (object)txtDiachi.Text.Trim() ?? DBNull.Value));

                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Function.RunSql(
                        @"UPDATE KhachHang SET TenKhachHang=@t, SoDienThoai=@s, Email=@e, DiaChi=@d
                          WHERE MaKhachHang=@m",
                        new SqlParameter("@m", txtMakhachhang.Text.Trim()),
                        new SqlParameter("@t", txtTenkhachhang.Text.Trim()),
                        new SqlParameter("@s", sdt),
                        new SqlParameter("@e", (object)txtEmail.Text.Trim() ?? DBNull.Value),
                        new SqlParameter("@d", (object)txtDiachi.Text.Trim() ?? DBNull.Value));

                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
                ResetForm();
                EnableNhap(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMakhachhang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Xác nhận xóa khách hàng {txtMakhachhang.Text}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                Function.RunSql("DELETE FROM KhachHang WHERE MaKhachHang=@m",
                    new SqlParameter("@m", txtMakhachhang.Text.Trim()));
                MessageBox.Show("Đã xóa khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547)
            {
                MessageBox.Show("Không thể xóa: khách hàng này đã có đơn hàng/hóa đơn trong hệ thống.",
                    "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTimkiem_Click(object sender, EventArgs e)
        {
            string kw = txtTenkhachhang.Text.Trim();
            if (string.IsNullOrWhiteSpace(kw))
            {
                LoadData();
                return;
            }
            try
            {
                _dt = Function.GetDataToTable(
                    @"SELECT MaKhachHang, TenKhachHang, SoDienThoai, Email, DiaChi, DiemTichLuy
                      FROM KhachHang
                      WHERE TenKhachHang LIKE @kw OR SoDienThoai LIKE @kw OR MaKhachHang LIKE @kw
                      ORDER BY MaKhachHang",
                    new SqlParameter("@kw", "%" + kw + "%"));
                dgvKhachHang.DataSource = _dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
