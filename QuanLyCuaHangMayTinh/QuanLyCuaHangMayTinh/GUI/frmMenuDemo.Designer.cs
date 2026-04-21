using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    partial class frmMenuDemo
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblNote;
        private ComboBox cboVaiTro;
        private Label lblVaiTro;
        private Button btnLoaiSanPham;
        private Button btnThuongHieu;
        private Button btnNhaCungCap;
        private Button btnSanPham;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel(); this.lblTitle = new Label(); this.lblNote = new Label(); this.cboVaiTro = new ComboBox(); this.lblVaiTro = new Label(); this.btnLoaiSanPham = new Button(); this.btnThuongHieu = new Button(); this.btnNhaCungCap = new Button(); this.btnSanPham = new Button();
            this.pnlHeader.SuspendLayout(); this.SuspendLayout();
            this.pnlHeader.BackColor = Color.FromArgb(31, 75, 140); this.pnlHeader.Controls.AddRange(new Control[] { this.lblTitle, this.lblNote }); this.pnlHeader.Dock = DockStyle.Top; this.pnlHeader.Size = new Size(454, 88);
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold); this.lblTitle.ForeColor = Color.White; this.lblTitle.Location = new Point(18, 16); this.lblTitle.Text = "MENU DEMO CÁC FORM";
            this.lblNote.AutoSize = true; this.lblNote.ForeColor = Color.WhiteSmoke; this.lblNote.Location = new Point(20, 52); this.lblNote.Text = "Chọn vai trò trước khi mở form để kiểm tra phân quyền hiển thị";
            this.lblVaiTro.AutoSize = true; this.lblVaiTro.Font = new Font("Segoe UI", 10F, FontStyle.Bold); this.lblVaiTro.Location = new Point(24, 111); this.lblVaiTro.Text = "Vai trò demo";
            this.cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList; this.cboVaiTro.Font = new Font("Segoe UI", 10F); this.cboVaiTro.Items.AddRange(new object[] { "Admin", "Nhân viên kho", "Nhân viên bán hàng", "Kế toán" }); this.cboVaiTro.Location = new Point(127, 107); this.cboVaiTro.Size = new Size(292, 25); this.cboVaiTro.SelectedIndex = 0;
            this.btnLoaiSanPham.Location = new Point(28, 160); this.btnLoaiSanPham.Size = new Size(391, 38); this.btnLoaiSanPham.Text = "Mở frmLoaiSanPham"; this.btnLoaiSanPham.Click += new System.EventHandler(this.btnLoaiSanPham_Click);
            this.btnThuongHieu.Location = new Point(28, 210); this.btnThuongHieu.Size = new Size(391, 38); this.btnThuongHieu.Text = "Mở frmThuongHieu"; this.btnThuongHieu.Click += new System.EventHandler(this.btnThuongHieu_Click);
            this.btnNhaCungCap.Location = new Point(28, 260); this.btnNhaCungCap.Size = new Size(391, 38); this.btnNhaCungCap.Text = "Mở frmNhaCungCap"; this.btnNhaCungCap.Click += new System.EventHandler(this.btnNhaCungCap_Click);
            this.btnSanPham.Location = new Point(28, 310); this.btnSanPham.Size = new Size(391, 38); this.btnSanPham.Text = "Mở frmSanPham"; this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            this.AutoScaleDimensions = new SizeF(7F, 15F); this.AutoScaleMode = AutoScaleMode.Font; this.BackColor = Color.WhiteSmoke; this.ClientSize = new Size(454, 384); this.Controls.AddRange(new Control[] { this.btnSanPham, this.btnNhaCungCap, this.btnThuongHieu, this.btnLoaiSanPham, this.cboVaiTro, this.lblVaiTro, this.pnlHeader }); this.FormBorderStyle = FormBorderStyle.FixedDialog; this.MaximizeBox = false; this.Name = "frmMenuDemo"; this.StartPosition = FormStartPosition.CenterScreen; this.Text = "Menu Demo"; this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout(); this.ResumeLayout(false); this.PerformLayout();
        }
    }
}
