namespace QuanLyCuaHangMayTinh
{
    partial class frm_quanly
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblNguoiDungDS = new System.Windows.Forms.Label();
            this.btnDangXuatDS = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnNguoiDungDS = new System.Windows.Forms.Button();
            this.btnDanhMucDS = new System.Windows.Forms.Button();
            this.btnDonHangDS = new System.Windows.Forms.Button();
            this.btnKhoDS = new System.Windows.Forms.Button();
            this.btnBaoCaoDS = new System.Windows.Forms.Button();
            this.pnlTabBarDS = new System.Windows.Forms.Panel();
            this.lblTabHintDS = new System.Windows.Forms.Label();
            this.pnlContentDS = new System.Windows.Forms.Panel();
            this.lblContentHintDS = new System.Windows.Forms.Label();
            this.pnlTieuDe.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.pnlTabBarDS.SuspendLayout();
            this.pnlContentDS.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTieuDe
            //
            this.pnlTieuDe.BackColor = System.Drawing.Color.FromArgb(20, 35, 80);
            this.pnlTieuDe.Controls.Add(this.lblNguoiDungDS);
            this.pnlTieuDe.Controls.Add(this.btnDangXuatDS);
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(1920, 80);
            this.pnlTieuDe.TabIndex = 0;
            this.pnlTieuDe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTieuDe_MouseDown);
            this.pnlTieuDe.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTieuDe_Paint);
            //
            // lblTieuDe (placeholder logo bên trái)
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 26);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(335, 25);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "🖥  Hệ thống quản lý cửa hàng máy tính";
            //
            // lblNguoiDungDS (placeholder thông tin user - sẽ bị thay khi chạy)
            //
            this.lblNguoiDungDS.AutoSize = true;
            this.lblNguoiDungDS.BackColor = System.Drawing.Color.Transparent;
            this.lblNguoiDungDS.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNguoiDungDS.ForeColor = System.Drawing.Color.White;
            this.lblNguoiDungDS.Location = new System.Drawing.Point(1570, 30);
            this.lblNguoiDungDS.Name = "lblNguoiDungDS";
            this.lblNguoiDungDS.Size = new System.Drawing.Size(177, 19);
            this.lblNguoiDungDS.TabIndex = 1;
            this.lblNguoiDungDS.Text = "👤 Nguyễn Văn Admin (Admin)";
            //
            // btnDangXuatDS (placeholder nút Đăng xuất - sẽ bị thay khi chạy)
            //
            this.btnDangXuatDS.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDangXuatDS.FlatAppearance.BorderSize = 0;
            this.btnDangXuatDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuatDS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDangXuatDS.ForeColor = System.Drawing.Color.White;
            this.btnDangXuatDS.Location = new System.Drawing.Point(1771, 22);
            this.btnDangXuatDS.Name = "btnDangXuatDS";
            this.btnDangXuatDS.Size = new System.Drawing.Size(120, 36);
            this.btnDangXuatDS.TabIndex = 2;
            this.btnDangXuatDS.Text = "🚪 Đăng xuất";
            this.btnDangXuatDS.UseVisualStyleBackColor = false;
            //
            // panelMenu
            //
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(20, 35, 80);
            this.panelMenu.Controls.Add(this.btnNguoiDungDS);
            this.panelMenu.Controls.Add(this.btnDanhMucDS);
            this.panelMenu.Controls.Add(this.btnDonHangDS);
            this.panelMenu.Controls.Add(this.btnKhoDS);
            this.panelMenu.Controls.Add(this.btnBaoCaoDS);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 80);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(260, 960);
            this.panelMenu.TabIndex = 1;
            this.panelMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMenu_MouseDown);
            //
            // btnNguoiDungDS (placeholder - sẽ bị thay bởi IconButton thật khi chạy)
            //
            this.btnNguoiDungDS.BackColor = System.Drawing.Color.FromArgb(20, 35, 80);
            this.btnNguoiDungDS.FlatAppearance.BorderSize = 0;
            this.btnNguoiDungDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNguoiDungDS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNguoiDungDS.ForeColor = System.Drawing.Color.White;
            this.btnNguoiDungDS.Location = new System.Drawing.Point(3, 10);
            this.btnNguoiDungDS.Name = "btnNguoiDungDS";
            this.btnNguoiDungDS.Size = new System.Drawing.Size(254, 60);
            this.btnNguoiDungDS.TabIndex = 0;
            this.btnNguoiDungDS.Text = "👤  Người dùng";
            this.btnNguoiDungDS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNguoiDungDS.UseVisualStyleBackColor = false;
            //
            // btnDanhMucDS
            //
            this.btnDanhMucDS.BackColor = System.Drawing.Color.FromArgb(20, 35, 80);
            this.btnDanhMucDS.FlatAppearance.BorderSize = 0;
            this.btnDanhMucDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhMucDS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDanhMucDS.ForeColor = System.Drawing.Color.White;
            this.btnDanhMucDS.Location = new System.Drawing.Point(3, 76);
            this.btnDanhMucDS.Name = "btnDanhMucDS";
            this.btnDanhMucDS.Size = new System.Drawing.Size(254, 60);
            this.btnDanhMucDS.TabIndex = 1;
            this.btnDanhMucDS.Text = "📋  Danh mục";
            this.btnDanhMucDS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhMucDS.UseVisualStyleBackColor = false;
            //
            // btnDonHangDS
            //
            this.btnDonHangDS.BackColor = System.Drawing.Color.FromArgb(255, 215, 0);
            this.btnDonHangDS.FlatAppearance.BorderSize = 0;
            this.btnDonHangDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonHangDS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDonHangDS.ForeColor = System.Drawing.Color.FromArgb(20, 35, 80);
            this.btnDonHangDS.Location = new System.Drawing.Point(3, 142);
            this.btnDonHangDS.Name = "btnDonHangDS";
            this.btnDonHangDS.Size = new System.Drawing.Size(254, 60);
            this.btnDonHangDS.TabIndex = 2;
            this.btnDonHangDS.Text = "🛒  Đơn hàng";
            this.btnDonHangDS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonHangDS.UseVisualStyleBackColor = false;
            //
            // btnKhoDS
            //
            this.btnKhoDS.BackColor = System.Drawing.Color.FromArgb(20, 35, 80);
            this.btnKhoDS.FlatAppearance.BorderSize = 0;
            this.btnKhoDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoDS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnKhoDS.ForeColor = System.Drawing.Color.White;
            this.btnKhoDS.Location = new System.Drawing.Point(3, 208);
            this.btnKhoDS.Name = "btnKhoDS";
            this.btnKhoDS.Size = new System.Drawing.Size(254, 60);
            this.btnKhoDS.TabIndex = 3;
            this.btnKhoDS.Text = "🏭  Kho/Nhập kho";
            this.btnKhoDS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhoDS.UseVisualStyleBackColor = false;
            //
            // btnBaoCaoDS
            //
            this.btnBaoCaoDS.BackColor = System.Drawing.Color.FromArgb(20, 35, 80);
            this.btnBaoCaoDS.FlatAppearance.BorderSize = 0;
            this.btnBaoCaoDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCaoDS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoDS.ForeColor = System.Drawing.Color.White;
            this.btnBaoCaoDS.Location = new System.Drawing.Point(3, 274);
            this.btnBaoCaoDS.Name = "btnBaoCaoDS";
            this.btnBaoCaoDS.Size = new System.Drawing.Size(254, 60);
            this.btnBaoCaoDS.TabIndex = 4;
            this.btnBaoCaoDS.Text = "📊  Báo cáo";
            this.btnBaoCaoDS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoDS.UseVisualStyleBackColor = false;
            //
            // pnlTabBarDS (placeholder tab bar - sẽ bị thay)
            //
            this.pnlTabBarDS.BackColor = System.Drawing.Color.FromArgb(240, 242, 247);
            this.pnlTabBarDS.Controls.Add(this.lblTabHintDS);
            this.pnlTabBarDS.Location = new System.Drawing.Point(260, 80);
            this.pnlTabBarDS.Name = "pnlTabBarDS";
            this.pnlTabBarDS.Size = new System.Drawing.Size(1660, 50);
            this.pnlTabBarDS.TabIndex = 2;
            //
            // lblTabHintDS
            //
            this.lblTabHintDS.AutoSize = true;
            this.lblTabHintDS.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblTabHintDS.ForeColor = System.Drawing.Color.Gray;
            this.lblTabHintDS.Location = new System.Drawing.Point(15, 16);
            this.lblTabHintDS.Name = "lblTabHintDS";
            this.lblTabHintDS.Size = new System.Drawing.Size(386, 19);
            this.lblTabHintDS.TabIndex = 0;
            this.lblTabHintDS.Text = "[ Thanh tab các form con sẽ hiển thị ở đây khi chạy ]";
            //
            // pnlContentDS (placeholder vùng content - sẽ bị thay)
            //
            this.pnlContentDS.BackColor = System.Drawing.Color.White;
            this.pnlContentDS.Controls.Add(this.lblContentHintDS);
            this.pnlContentDS.Location = new System.Drawing.Point(260, 130);
            this.pnlContentDS.Name = "pnlContentDS";
            this.pnlContentDS.Size = new System.Drawing.Size(1660, 910);
            this.pnlContentDS.TabIndex = 3;
            //
            // lblContentHintDS
            //
            this.lblContentHintDS.AutoSize = true;
            this.lblContentHintDS.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            this.lblContentHintDS.ForeColor = System.Drawing.Color.LightGray;
            this.lblContentHintDS.Location = new System.Drawing.Point(40, 40);
            this.lblContentHintDS.Name = "lblContentHintDS";
            this.lblContentHintDS.Size = new System.Drawing.Size(429, 20);
            this.lblContentHintDS.TabIndex = 0;
            this.lblContentHintDS.Text = "[ Form con (Sản phẩm, Hóa đơn, Báo cáo...) hiển thị ở đây ]";
            //
            // frm_quanly
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1920, 1040);
            this.Controls.Add(this.pnlContentDS);
            this.Controls.Add(this.pnlTabBarDS);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.pnlTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_quanly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cửa hàng máy tính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_quanly_Load);
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlTieuDe.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.pnlTabBarDS.ResumeLayout(false);
            this.pnlTabBarDS.PerformLayout();
            this.pnlContentDS.ResumeLayout(false);
            this.pnlContentDS.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Các control thật được dùng runtime:
        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panelMenu;

        // Các placeholder cho Designer view (sẽ bị ẩn/xóa khi runtime):
        private System.Windows.Forms.Label lblNguoiDungDS;
        private System.Windows.Forms.Button btnDangXuatDS;
        private System.Windows.Forms.Button btnNguoiDungDS;
        private System.Windows.Forms.Button btnDanhMucDS;
        private System.Windows.Forms.Button btnDonHangDS;
        private System.Windows.Forms.Button btnKhoDS;
        private System.Windows.Forms.Button btnBaoCaoDS;
        private System.Windows.Forms.Panel pnlTabBarDS;
        private System.Windows.Forms.Label lblTabHintDS;
        private System.Windows.Forms.Panel pnlContentDS;
        private System.Windows.Forms.Label lblContentHintDS;
    }
}
