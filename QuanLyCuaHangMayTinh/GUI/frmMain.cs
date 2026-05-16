using FontAwesome.Sharp;
using QuanLyCuaHangMayTinh.GUI;
using QuanLyCuaHangMayTinh_Forms.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    /// <summary>
    /// Form chính với menu 5 module lớn (bám sát sơ đồ ma trận đề bài).
    /// Click vào module → bên phải hiện 1 thanh tab ngang với các form con của module đó.
    /// Phân quyền theo StaticData.MaVaiTro: VT01 (Admin), VT02 (Kho), VT03 (Bán hàng), VT04 (Kế toán)
    /// </summary>
    public partial class frm_quanly : Form
    {
        private Form currentChildForm;
        private Panel panelContent;       // vùng chứa form con
        private Panel panelTabBar;        // thanh tab ngang
        private Label lblNguoiDung;
        private IconButton btnLogout;

        private class SubItem
        {
            public string Title;
            public IconChar Icon;
            public Func<Form> CreateForm;
            public Button TabButton;
            public string[] AllowedRoles;
        }

        private class Module
        {
            public string Name;
            public IconChar Icon;
            public IconButton MenuButton;
            public List<SubItem> Items = new List<SubItem>();
        }

        private List<Module> _modules = new List<Module>();
        private IconButton _currentMenuBtn;
        private Button _currentTabBtn;
        private Module _currentModule;

        // Màu sắc
        private readonly Color colorMenuBg = Color.FromArgb(20, 35, 80);
        private readonly Color colorMenuActive = Color.FromArgb(255, 215, 0);  // vàng đậm
        private readonly Color colorMenuText = Color.White;
        private readonly Color colorMenuActiveText = Color.FromArgb(20, 35, 80);
        private readonly Color colorTabBg = Color.FromArgb(240, 242, 247);
        private readonly Color colorTabActive = Color.FromArgb(20, 35, 80);
        private readonly Color colorTabInactive = Color.White;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public frm_quanly()
        {
            InitializeComponent();
        }

        private void frm_quanly_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);

            // Đặt FormBorderStyle trước
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            // Ẩn các placeholder Designer (chỉ dùng để xem trước trong Design view)
            lblNguoiDungDS.Visible = false;
            btnDangXuatDS.Visible = false;
            btnNguoiDungDS.Visible = false;
            btnDanhMucDS.Visible = false;
            btnDonHangDS.Visible = false;
            btnKhoDS.Visible = false;
            btnBaoCaoDS.Visible = false;
            pnlTabBarDS.Visible = false;
            pnlContentDS.Visible = false;

            // Đăng ký event Shown để maximize SAU KHI form đã render
            this.Shown += FrmQuanly_Shown;

            int headerH = 80;
            int menuW = 260;
            int tabBarH = 50;

            // Thanh tab ngang (đặt ngay dưới header, sát phải menu)
            panelTabBar = new Panel
            {
                Location = new Point(menuW, headerH),
                Size = new Size(this.ClientSize.Width - menuW, tabBarH),
                BackColor = colorTabBg,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            this.Controls.Add(panelTabBar);

            // Vùng content (dưới thanh tab)
            panelContent = new Panel
            {
                Location = new Point(menuW, headerH + tabBarH),
                Size = new Size(this.ClientSize.Width - menuW, this.ClientSize.Height - headerH - tabBarH),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = Color.White,
                AutoScroll = true
            };
            this.Controls.Add(panelContent);

            // Đảm bảo z-order: panelContent dưới cùng, tabBar trên, menu+header trên cùng
            pnlTieuDe.BringToFront();
            panelMenu.BringToFront();

            // Tiêu đề trên header để trống vì các form con tự có title (tránh trùng)
            lblTieuDe.Text = "";

            HienThiHeader();
            DinhNghiaModules();
            VeMenu();
            MoModuleMacDinh();
        }

        private void HienThiHeader()
        {
            // Logo / tiêu đề hệ thống ở bên trái header
            lblTieuDe.Text = "🖥  Hệ thống quản lý cửa hàng máy tính";
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 24);

            // Nút Đăng xuất bên phải
            btnLogout = new IconButton
            {
                Text = "  Đăng xuất",
                IconChar = IconChar.SignOutAlt,
                IconColor = Color.White,
                IconSize = 20,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(192, 57, 43),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Size = new Size(120, 36),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleLeft,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Location = new Point(pnlTieuDe.Width - btnLogout.Width - 15, 22);
            btnLogout.Click += BtnLogout_Click;
            pnlTieuDe.Controls.Add(btnLogout);
            btnLogout.BringToFront();

            // Label user info bên trái nút logout
            lblNguoiDung = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = $"👤 {StaticData.HoTen}  ({StaticData.TenVaiTro})",
                BackColor = Color.Transparent
            };
            pnlTieuDe.Controls.Add(lblNguoiDung);
            lblNguoiDung.Location = new Point(btnLogout.Left - lblNguoiDung.Width - 20, 30);
            lblNguoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNguoiDung.BringToFront();
        }

        // ========================================================================
        // ĐỊNH NGHĨA 5 MODULE LỚN + TAB CON (BÁM SÁT MA TRẬN ĐỀ BÀI)
        // ========================================================================
        private void DinhNghiaModules()
        {
            // ===== Module 1.1: Người dùng =====
            var m1 = new Module { Name = "Người dùng", Icon = IconChar.UserShield };
            m1.Items.Add(new SubItem {
                Title = "Tài khoản", Icon = IconChar.UsersCog,
                CreateForm = () => new frm_quanlytaikhoan(),
                AllowedRoles = new[] { "VT01" }
            });
            m1.Items.Add(new SubItem {
                Title = "Đổi mật khẩu", Icon = IconChar.Key,
                CreateForm = () => null,  // mở dialog
                AllowedRoles = new[] { "VT01", "VT02", "VT03", "VT04" }
            });
            _modules.Add(m1);

            // ===== Module 1.2: Danh mục =====
            var m2 = new Module { Name = "Danh mục", Icon = IconChar.ClipboardList };
            m2.Items.Add(new SubItem {
                Title = "Sản phẩm", Icon = IconChar.Laptop,
                CreateForm = () => new frmSanPham(MapRoleSanPham()),
                AllowedRoles = new[] { "VT01", "VT02", "VT03" }  // Kho CRUD, Admin & Bán đều xem
            });
            m2.Items.Add(new SubItem {
                Title = "Loại sản phẩm", Icon = IconChar.Tags,
                CreateForm = () => new frmLoaiSanPham(MapRoleCategory()),
                AllowedRoles = new[] { "VT01", "VT02", "VT03" }  // VT03 xem để lọc SP khi bán
            });
            m2.Items.Add(new SubItem {
                Title = "Thương hiệu", Icon = IconChar.Tag,
                CreateForm = () => new frmThuongHieu(MapRoleCategory()),
                AllowedRoles = new[] { "VT01", "VT02", "VT03" }  // VT03 xem để lọc SP khi bán
            });
            m2.Items.Add(new SubItem {
                Title = "Nhà cung cấp", Icon = IconChar.Truck,
                CreateForm = () => new frmNhaCungCap(MapRoleCategory()),
                AllowedRoles = new[] { "VT01", "VT02", "VT03" }  // VT03 xem để tra cứu khi bán
            });
            m2.Items.Add(new SubItem {
                Title = "Khách hàng", Icon = IconChar.Users,
                CreateForm = () => new frmKhachHang(),
                AllowedRoles = new[] { "VT01", "VT03" }
            });
            _modules.Add(m2);

            // ===== Module 1.3: Đơn hàng =====
            // Theo đề: NV Bán hàng làm chính (POS, Đặt hàng, Trả hàng); Admin có thể xem (read);
            // Kế toán xem hóa đơn để kiểm sổ sách
            var m3 = new Module { Name = "Đơn hàng", Icon = IconChar.ShoppingCart };
            m3.Items.Add(new SubItem {
                Title = "Bán hàng (POS)", Icon = IconChar.CashRegister,
                CreateForm = () => new frmPOS(),
                AllowedRoles = new[] { "VT01", "VT03" }  // Admin xem, NV Bán CRUD
            });
            m3.Items.Add(new SubItem {
                Title = "Đơn đặt hàng", Icon = IconChar.CartArrowDown,
                CreateForm = () => new frmDonHang(),
                AllowedRoles = new[] { "VT01", "VT03" }
            });
            m3.Items.Add(new SubItem {
                Title = "Quản lý hóa đơn", Icon = IconChar.FileInvoiceDollar,
                CreateForm = () => new frmQuanLyHoaDon(),
                AllowedRoles = new[] { "VT01", "VT03", "VT04" }
            });
            m3.Items.Add(new SubItem {
                Title = "Trả hàng", Icon = IconChar.RotateLeft,
                CreateForm = () => new frmTraHang(),
                AllowedRoles = new[] { "VT01", "VT03" }
            });
            _modules.Add(m3);

            // ===== Module 1.3 (Kho/Nhập kho) =====
            var m4 = new Module { Name = "Kho/Nhập kho", Icon = IconChar.Warehouse };
            m4.Items.Add(new SubItem {
                Title = "Lập phiếu nhập", Icon = IconChar.PlusCircle,
                CreateForm = () => new frmNhap(),
                AllowedRoles = new[] { "VT01", "VT02" }
            });
            m4.Items.Add(new SubItem {
                Title = "Tìm phiếu nhập", Icon = IconChar.Search,
                CreateForm = () => new frmTimKiemPhieuNhap(),
                AllowedRoles = new[] { "VT01", "VT02" }
            });
            _modules.Add(m4);

            // ===== Module 1.4: Báo cáo & Thống kê (đề ghi rõ: DÀNH CHO ADMIN) =====
            var m5 = new Module { Name = "Báo cáo", Icon = IconChar.ChartLine };
            m5.Items.Add(new SubItem {
                Title = "Doanh thu", Icon = IconChar.MoneyBillWave,
                CreateForm = () => new frmBaoCaoDT(),
                AllowedRoles = new[] { "VT01" }
            });
            m5.Items.Add(new SubItem {
                Title = "SP bán chạy", Icon = IconChar.ChartBar,
                CreateForm = () => new frmBaoCaoSP(),
                AllowedRoles = new[] { "VT01" }
            });
            m5.Items.Add(new SubItem {
                Title = "Đơn hàng", Icon = IconChar.FileInvoice,
                CreateForm = () => new frmBaoCaoDonHang(),
                AllowedRoles = new[] { "VT01" }
            });
            _modules.Add(m5);
        }

        private void VeMenu()
        {
            int y = 10;
            foreach (var m in _modules)
            {
                // Ẩn module nếu không có item nào cho role này
                bool hasAccess = m.Items.Any(it => it.AllowedRoles.Contains(StaticData.MaVaiTro));
                if (!hasAccess) continue;

                var btn = new IconButton
                {
                    Text = "    " + m.Name,
                    IconChar = m.Icon,
                    IconColor = Color.FromArgb(255, 215, 0),
                    IconSize = 28,
                    ForeColor = colorMenuText,
                    BackColor = colorMenuBg,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Width = 254,
                    Height = 60,
                    Left = 3,
                    Top = y,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    TextAlign = ContentAlignment.MiddleLeft,
                    TextImageRelation = TextImageRelation.ImageBeforeText,
                    Cursor = Cursors.Hand
                };
                btn.FlatAppearance.BorderSize = 0;
                m.MenuButton = btn;
                Module captured = m;
                btn.Click += (s, e) => MoModule(captured);
                panelMenu.Controls.Add(btn);

                y += btn.Height + 6;
            }
        }

        private void MoModule(Module module)
        {
            // Reset menu cũ
            if (_currentMenuBtn != null)
            {
                _currentMenuBtn.BackColor = colorMenuBg;
                _currentMenuBtn.ForeColor = colorMenuText;
                _currentMenuBtn.IconColor = Color.FromArgb(255, 215, 0);
            }
            _currentMenuBtn = module.MenuButton;
            _currentMenuBtn.BackColor = colorMenuActive;
            _currentMenuBtn.ForeColor = colorMenuActiveText;
            _currentMenuBtn.IconColor = colorMenuActiveText;
            _currentModule = module;

            VeTabBar(module);

            // Mở tab đầu tiên được phép (bỏ qua "Đổi mật khẩu" - mở dialog không tốt để mặc định)
            var firstAllowed = module.Items.FirstOrDefault(it =>
                it.AllowedRoles.Contains(StaticData.MaVaiTro) && it.Title != "Đổi mật khẩu");
            if (firstAllowed == null)
            {
                firstAllowed = module.Items.FirstOrDefault(it => it.AllowedRoles.Contains(StaticData.MaVaiTro));
            }
            if (firstAllowed != null) MoTab(firstAllowed);
        }

        private void VeTabBar(Module module)
        {
            panelTabBar.Controls.Clear();
            _currentTabBtn = null;

            int x = 10;
            foreach (var it in module.Items)
            {
                if (!it.AllowedRoles.Contains(StaticData.MaVaiTro)) continue;

                var tab = new Button
                {
                    Text = "  " + it.Title + "  ",
                    Location = new Point(x, 8),
                    Height = 36,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    BackColor = colorTabInactive,
                    ForeColor = Color.DimGray,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Padding = new Padding(8, 4, 8, 4)
                };
                tab.FlatAppearance.BorderSize = 1;
                tab.FlatAppearance.BorderColor = Color.LightGray;
                it.TabButton = tab;
                SubItem captured = it;
                tab.Click += (s, e) => MoTab(captured);
                panelTabBar.Controls.Add(tab);

                // Force AutoSize tính toán trước khi đo width
                tab.PerformLayout();
                x += tab.Width + 6;
            }
        }

        private void MoTab(SubItem item)
        {
            // Trường hợp đặc biệt: Đổi mật khẩu → mở dialog
            if (item.Title == "Đổi mật khẩu")
            {
                using (var f = new frmDoiMatKhau())
                {
                    f.ShowDialog(this);
                }
                return;
            }

            // Đánh dấu tab active
            if (_currentTabBtn != null)
            {
                _currentTabBtn.BackColor = colorTabInactive;
                _currentTabBtn.ForeColor = Color.DimGray;
            }
            if (item.TabButton != null)
            {
                _currentTabBtn = item.TabButton;
                _currentTabBtn.BackColor = colorTabActive;
                _currentTabBtn.ForeColor = Color.White;
            }

            try
            {
                Form newForm = item.CreateForm();
                if (newForm == null) return;
                OpenForm(newForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở form: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenForm(Form childForm)
        {
            if (currentChildForm != null) currentChildForm.Close();

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            childForm.StartPosition = FormStartPosition.Manual;

            panelContent.Controls.Clear();
            panelContent.AutoScroll = true;
            panelContent.Controls.Add(childForm);

            // Căn giữa form con trong panelContent
            // (đặt sau khi Add vì lúc đó childForm mới biết size chính xác)
            CanGiua(childForm);

            // Khi panel resize → căn giữa lại
            panelContent.Resize -= PanelContent_Resize;
            panelContent.Resize += PanelContent_Resize;

            childForm.BringToFront();
            childForm.Show();
        }

        private void CanGiua(Form childForm)
        {
            if (childForm == null || childForm.IsDisposed) return;
            int x = Math.Max(0, (panelContent.ClientSize.Width - childForm.Width) / 2);
            int y = Math.Max(0, (panelContent.ClientSize.Height - childForm.Height) / 2);
            childForm.Location = new Point(x, y);
        }

        private void PanelContent_Resize(object sender, EventArgs e)
        {
            if (currentChildForm != null && !currentChildForm.IsDisposed)
                CanGiua(currentChildForm);
        }

        private void MoModuleMacDinh()
        {
            // Mở module đầu tiên có thể truy cập
            var firstModule = _modules.FirstOrDefault(m => m.MenuButton != null);
            if (firstModule != null) MoModule(firstModule);
        }

        /// <summary>
        /// Trick để form FormBorderStyle.None thực sự max ra full screen.
        /// Nếu chỉ dùng Maximized trong Load, có lúc Windows không tính đúng → form chỉ chiếm 1 phần.
        /// Cách fix: reset về Normal rồi Maximized lại trong event Shown (chạy sau Load).
        /// </summary>
        private void FrmQuanly_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
            this.Activate();
        }

        /// <summary>
        /// Cho phép các form báo cáo gọi để chuyển sang báo cáo khác (3 tab Doanh thu / SP bán chạy / Đơn theo trạng thái).
        /// Helper ReportButtonsHelper dùng reflection để gọi method này.
        /// </summary>
        public void MoBaoCaoTheoTen(string target)
        {
            // Tìm module Báo cáo
            var moduleBaoCao = _modules.Find(m => m.Name == "Báo cáo");
            if (moduleBaoCao == null) return;

            string targetTitle = "";
            switch (target)
            {
                case "doanh_thu":      targetTitle = "Doanh thu"; break;
                case "sp_ban_chay":    targetTitle = "SP bán chạy"; break;
                case "don_trang_thai": targetTitle = "Đơn hàng"; break;
                default: return;
            }

            // Đảm bảo module Báo cáo đang active
            if (_currentModule != moduleBaoCao) MoModule(moduleBaoCao);

            // Tìm tab khớp tên rồi mở
            var item = moduleBaoCao.Items.Find(i => i.Title == targetTitle);
            if (item != null && item.AllowedRoles.Contains(StaticData.MaVaiTro))
            {
                MoTab(item);
            }
        }

        // === Map role cho form con ===
        // Theo đề số 1, mục 1.2:
        //   - Admin: CRUD mọi danh mục TRỪ sản phẩm  → SanPham read-only
        //   - NV Kho:        CRUD sản phẩm + tìm kiếm/lọc tồn kho
        //   - NV Bán hàng:   tìm kiếm/lọc sản phẩm để bán (read-only)
        //   - Kế toán:       chỉ xem
        private string MapRoleSanPham()
        {
            switch (StaticData.MaVaiTro)
            {
                case "VT01": return "Admin";              // read-only theo đề
                case "VT02": return "Nhân viên kho";      // CRUD đầy đủ
                case "VT03": return "Nhân viên bán hàng"; // tìm kiếm cho POS
                default:     return "Kế toán";            // read-only
            }
        }

        private string MapRoleCategory()
        {
            switch (StaticData.MaVaiTro)
            {
                case "VT01": return "Admin";
                case "VT02": return "Nhân viên kho";
                case "VT03": return "Nhân viên bán hàng";
                default: return "Kế toán";
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StaticData.MaNV = "";
                StaticData.TenDangNhap = "";
                StaticData.HoTen = "";
                StaticData.MaVaiTro = "";
                StaticData.TenVaiTro = "";

                this.Hide();
                var f = new frmLogin();
                f.FormClosed += (s, ev) => this.Close();
                f.Show();
            }
        }

        // === Event handlers Designer ===
        private void pnlTieuDe_Paint(object sender, PaintEventArgs e) { }

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
    }
}
