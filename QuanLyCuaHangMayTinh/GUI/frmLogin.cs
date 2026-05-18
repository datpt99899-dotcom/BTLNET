using QuanLyCuaHangMayTinh.GUI;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.Repositories;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmLogin : Form
    {
        bool hidePass = true;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            hidePass = !hidePass;
            txtMatkhau.UseSystemPasswordChar = hidePass;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaikhoan.Text) || string.IsNullOrWhiteSpace(txtMatkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Function.Connect();
                DataRow row = AuthRepository.Authenticate(txtTaikhoan.Text.Trim(), txtMatkhau.Text.Trim());
                if (row == null)
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StaticData.MaNV = row["MaNhanVien"].ToString();
                StaticData.TenDangNhap = row["TenDangNhap"].ToString();
                StaticData.HoTen = row["HoTen"].ToString();
                StaticData.MaVaiTro = row["MaVaiTro"].ToString();
                StaticData.TenVaiTro = row["TenVaiTro"].ToString();

                // Tất cả role đều mở frm_quanly. frm_quanly tự phân quyền theo StaticData.MaVaiTro
                if (string.IsNullOrEmpty(StaticData.MaVaiTro))
                {
                    MessageBox.Show("Tài khoản chưa được gán vai trò. Vui lòng liên hệ quản trị viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Show();
                    return;
                }

                this.Hide();
                var fMain = new frm_quanly();
                fMain.FormClosed += (s, ev) => Application.Exit();
                fMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
