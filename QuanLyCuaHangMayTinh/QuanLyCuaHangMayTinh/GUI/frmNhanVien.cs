using FontAwesome.Sharp;
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
using QuanLyCuaHangMayTinh.GUI;

namespace QuanLyCuaHangMayTinh
{
        public partial class frmNhanVienKho : Form
        {
            private Button btnThemNhanVien;
            private DataGridView dgvNhanVien;
            private Button btnLamMoi;
            private BUS.NhanVienBUS bus = new BUS.NhanVienBUS();
        private Form currentChildForm;
        private IconButton currentBtn;
        private Dictionary<IconButton, string> originalButtonTexts = new Dictionary<IconButton, string>();

        private Color defaultIconColor = Color.Yellow;
        private Color defaultTextColor = Color.Yellow;
        private Color defaultButtonColor = Color.Green;

        private Color activeIconColor = Color.Green;
        private Color activeTextColor = Color.Green;
        private Color activeButtonColor = Color.Yellow;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        public frmNhanVienKho()
        {
            InitializeComponent();
            // Khởi tạo DataGridView và nút làm mới
            dgvNhanVien = new DataGridView
            {
                Location = new System.Drawing.Point(220, 80),
                Size = new System.Drawing.Size(800, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dgvNhanVien);

            btnLamMoi = new Button
            {
                Text = "Làm mới danh sách",
                Location = new System.Drawing.Point(220, 400),
                Size = new System.Drawing.Size(150, 30)
            };
            btnLamMoi.Click += (s, e) => LoadNhanVien();
            this.Controls.Add(btnLamMoi);

            btnThemNhanVien = new Button
            {
                Text = "Thêm nhân viên",
                Location = new System.Drawing.Point(400, 400),
                Size = new System.Drawing.Size(150, 30)
            };
            btnThemNhanVien.Click += BtnThemNhanVien_Click;
            this.Controls.Add(btnThemNhanVien);
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

        private void btnTK_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Danh sách sản phẩm");
            OpenForm(new frmSanpham(), "Danh sách sản phẩm");
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlTieuDe_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmNhanVienKho_Load(object sender, EventArgs e)
        {
            OpenForm(new frmThongTinTK(), "Thông tin tài khoản");
            LoadNhanVien();

            // Ví dụ thêm mới nhân viên (bạn thay bằng form nhập liệu thực tế)
            //TestAddNhanVien();
        }

        private void LoadNhanVien()
        {
            // Lấy danh sách nhân viên từ database
            var dt = QuanLyCuaHangMayTinh.Function.GetDataToTable("SELECT MaNhanVien, TenDangNhap, HoTen, GioiTinh, SoDienThoai, Email, DiaChi, MaVaiTro FROM NhanVien WHERE TrangThai = 1");
            dgvNhanVien.DataSource = dt;
        }

        private void BtnThemNhanVien_Click(object sender, EventArgs e)
        {
            using (var f = new QuanLyCuaHangMayTinh.GUI.frmThemNhanVien())
            {
                if (f.ShowDialog() == DialogResult.OK && f.NhanVienMoi != null)
                {
                    if (bus.AddNhanVien(f.NhanVienMoi, f.MatKhauMoi))
                    {
                        MessageBox.Show("Thêm nhân viên thành công!");
                        LoadNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thất bại!");
                    }
                }
            }
        }

        // Hàm mẫu để test thêm nhân viên và tự động refresh danh sách
        private void TestAddNhanVien()
        {
            var nv = new DTO.NhanVienDTO
            {
                MaNhanVien = "NVTEST",
                TenDangNhap = "testuser",
                HoTen = "Test User",
                GioiTinh = "Nam",
                SoDienThoai = "0900000000",
                Email = "test@store.local",
                DiaChi = "Hà Nội",
                MaVaiTro = "VT02"
            };
            string matKhau = "test123";
            if (bus.AddNhanVien(nv, matKhau))
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadNhanVien();
            }
			else
			{
				MessageBox.Show("Thêm nhân viên thất bại!");
			}
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Nhập kho");
            OpenForm(new frmNhapKho(), "Nhập kho");
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, "Báo cáo kho");
            OpenForm(new frmBaoCaoKho(), "Báo cáo kho");
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
    }
}
