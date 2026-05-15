using QuanLyCuaHangMayTinh.BUS;
using System;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Form đổi mật khẩu cho người dùng đang đăng nhập.
    /// Áp dụng cho mọi vai trò.
    /// </summary>
    public partial class frmDoiMatKhau : Form
    {
        private readonly NhanVienBUS _bus = new NhanVienBUS();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            lblNguoiDung.Text = $"Tài khoản: {StaticData.TenDangNhap}   |   {StaticData.HoTen}";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhauMoi.Text) ||
                string.IsNullOrWhiteSpace(txtNhapLai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLai.Focus();
                txtNhapLai.SelectAll();
                return;
            }

            if (txtMatKhauMoi.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (txtMatKhauCu.Text == txtMatKhauMoi.Text)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool ok = _bus.DoiMatKhau(StaticData.MaNV, txtMatKhauCu.Text, txtMatKhauMoi.Text);
                if (ok)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhauCu.Focus();
                    txtMatKhauCu.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool hide = !chkHienMatKhau.Checked;
            txtMatKhauCu.UseSystemPasswordChar = hide;
            txtMatKhauMoi.UseSystemPasswordChar = hide;
            txtNhapLai.UseSystemPasswordChar = hide;
        }
    }
}
