using System;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;
using QuanLyCuaHangMayTinh.DTO;

namespace QuanLyCuaHangMayTinh.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var user = StaticData.CurrentUser;
            lblTenNguoiDung.Text = user.HoTen;
            lblVaiTro.Text = user.MaVaiTro;
            SetPermission(user.MaVaiTro);
        }

        private void SetPermission(string maVaiTro)
        {
            // Ẩn/hiện menu theo vai trò
            // Ví dụ:
            // menuAdmin.Visible = maVaiTro == "ADMIN";
            // menuBanHang.Visible = maVaiTro == "BANHANG";
            // menuKho.Visible = maVaiTro == "KHO";
            // menuKeToan.Visible = maVaiTro == "KETOAN";
        }

        private Form currentChildForm;
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
                currentChildForm.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            StaticData.CurrentUser = null;
            frmLogin login = new frmLogin();
            login.Show();
        }
    }
}
