using FontAwesome.Sharp;
using QuanLyCuaHangMayTinh.QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh_Forms.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frm_quanly : Form
    {
        private Form currentChildForm;
        private IconButton currentBtn;
        private Dictionary<IconButton, string> originalButtonTexts = new Dictionary<IconButton, string>();

        private Color defaultIconColor = Color.Yellow;
        private Color defaultTextColor = Color.Yellow;
        private Color defaultButtonColor = Color.Green;

        private Color activeIconColor = Color.Green;
        private Color activeTextColor = Color.Green;
        private Color activeButtonColor = Color.Yellow;
        private IconButton btnDonDatHangMoRong;
        private IconButton btnTraHangMoRong;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        public frm_quanly()
        {
            InitializeComponent();
        }
        private void OpenForm(Form childForm, string tenTrang)
        {
            if (currentChildForm != null) currentChildForm.Close();

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlDeskTop.Controls.Add(childForm);
            pnlDeskTop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTieuDe.Text = tenTrang;
        }
        private void ActivateButton(object senderBtn, string tenTrang)
        {
            if (senderBtn == null) return;

            IconButton clickedBtn = (IconButton)senderBtn;

            if (currentBtn != null && currentBtn != clickedBtn)
            {
                DisableButton(currentBtn);
            }

            if (!originalButtonTexts.ContainsKey(clickedBtn))
                originalButtonTexts[clickedBtn] = clickedBtn.Text;

            currentBtn = clickedBtn;
            currentBtn.BackColor = activeButtonColor;
            currentBtn.ForeColor = activeTextColor;
            currentBtn.Text = string.Empty;
            currentBtn.IconColor = activeIconColor;
            currentBtn.ImageAlign = ContentAlignment.MiddleCenter;
            currentBtn.TextImageRelation = TextImageRelation.Overlay;
            currentBtn.Padding = new Padding(0);

            lblTieuDe.Text = tenTrang;
        }

        private void DisableButton(IconButton button)
        {
            if (button == null) return;

            button.BackColor = defaultButtonColor;
            button.ForeColor = defaultTextColor;
            if (originalButtonTexts.ContainsKey(button))
                button.Text = originalButtonTexts[button];
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.IconColor = defaultIconColor;
            button.TextImageRelation = TextImageRelation.Overlay;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(10, 0, 0, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_quanly_Load(object sender, EventArgs e)
        {
            ThemChucNangMoRong();
            btnQLBan.Text = "    Quản lý KH";
            btnKhuyenMai.Text = "    Khuyến mãi";

            // Hiển thị tên người dùng và vai trò
            lblNguoiDung.Text = $"👤 {StaticData.HoTen}  |  {StaticData.TenVaiTro}";

            // Phân quyền menu theo vai trò
            SetPermission(StaticData.MaVaiTro);

            OpenForm(new frmThongTinTK(), "Thông tin tài khoản");
        }

        private void SetPermission(string maVaiTro)
        {
            // Admin (VT01): hiện đủ menu
            // NV bán hàng (VT03): ẩn các menu không liên quan
            // NV kho (VT02): chỉ nhập kho, danh mục, sản phẩm
            // Kế toán (VT04): chỉ báo cáo, hóa đơn
            switch (maVaiTro)
            {
                case "VT01": // Admin: hiện tất cả
                    break;
                case "VT02": // NV kho
                    btnQLTaiKhoan.Visible = false;
                    btnQLHoaDon.Visible = false;
                    btnBaoCao.Visible = false;
                    btnKhuyenMai.Visible = false;
                    break;
                case "VT03": // NV bán hàng
                    btnQLTaiKhoan.Visible = false;
                    btnQLMon.Visible = false;
                    btnQLLoaiMon.Visible = false;
                    btnKhuyenMai.Visible = false;
                    break;
                case "VT04": // Kế toán
                    btnQLTaiKhoan.Visible = false;
                    btnQLMon.Visible = false;
                    btnQLLoaiMon.Visible = false;
                    btnQLBan.Visible = false;
                    btnKhuyenMai.Visible = false;
                    break;
            }
        }

        private void ThemChucNangMoRong()
        {
            btnDonDatHangMoRong = new IconButton();
            btnDonDatHangMoRong.Text = "Đơn đặt hàng";
            btnDonDatHangMoRong.IconChar = IconChar.CartArrowDown;
            btnDonDatHangMoRong.IconColor = Color.Yellow;
            btnDonDatHangMoRong.ForeColor = Color.Yellow;
            btnDonDatHangMoRong.BackColor = Color.Green;
            btnDonDatHangMoRong.FlatStyle = FlatStyle.Flat;
            btnDonDatHangMoRong.Width = 180; btnDonDatHangMoRong.Height = 42;
            btnDonDatHangMoRong.Left = 10; btnDonDatHangMoRong.Top = panelMenu.Controls.Count * 44;
            btnDonDatHangMoRong.Click += (s,e) => { ActivateButton(btnDonDatHangMoRong, "Đơn hàng"); OpenForm(new frmDonHang(), "Đơn hàng"); };
            panelMenu.Controls.Add(btnDonDatHangMoRong);

            btnTraHangMoRong = new IconButton();
            btnTraHangMoRong.Text = "Trả hàng";
            btnTraHangMoRong.IconChar = IconChar.RotateLeft;
            btnTraHangMoRong.IconColor = Color.Yellow;
            btnTraHangMoRong.ForeColor = Color.Yellow;
            btnTraHangMoRong.BackColor = Color.Green;
            btnTraHangMoRong.FlatStyle = FlatStyle.Flat;
            btnTraHangMoRong.Width = 180; btnTraHangMoRong.Height = 42;
            btnTraHangMoRong.Left = 10; btnTraHangMoRong.Top = btnDonDatHangMoRong.Bottom + 5;
            btnTraHangMoRong.Click += (s,e) => { ActivateButton(btnTraHangMoRong, "Trả hàng"); OpenForm(new frmTraHang(), "Trả hàng"); };
            panelMenu.Controls.Add(btnTraHangMoRong);
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Quản lý tài khoản");
            OpenForm(new frm_quanlytaikhoan(), "Quản lý tài khoản");
        }

        private void btnQLBan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Quản lý khách hàng");
            OpenForm(new frmKhachHang(), "Quản lý khách hàng");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmLogin f = new frmLogin();
                f.Show();
            }
        }

        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Quản lý hóa đơn");
            OpenForm(new frmChiTietHoaDon(), "Quản lý hóa đơn");
        }

        private void btnQLMon_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Quản lý sản phẩm");
            OpenForm(new frmSanpham(), "Quản lý sản phẩm");
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Báo cáo doanh thu");
            OpenForm(new frmBaoCao(), "Báo cáo doanh thu");
        }

        private void btnQLLoaiMon_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Danh sách Quản lý danh mục");
            OpenForm(new frmDanhmucsanpham(), "Danh sách Quản lý danh mục");
        }

        private void pnlTieuDe_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Khuyến mãi");
            OpenForm(new frmKhuyenMai(), "Khuyến mãi");
        }

        private void pnlTieuDe_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
