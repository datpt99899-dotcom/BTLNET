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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.btnLoaiSanPham = new System.Windows.Forms.Button();
            this.btnThuongHieu = new System.Windows.Forms.Button();
            this.btnNhaCungCap = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(75)))), ((int)(((byte)(140)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblNote);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1006, 117);
            this.pnlHeader.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(23, 21);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(395, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MENU DEMO CÁC FORM";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNote.Location = new System.Drawing.Point(26, 69);
            this.lblNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(443, 20);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "Chọn vai trò trước khi mở form để kiểm tra phân quyền hiển thị";
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVaiTro.Items.AddRange(new object[] {
            "Admin",
            "Nhân viên kho",
            "Nhân viên bán hàng",
            "Kế toán"});
            this.cboVaiTro.Location = new System.Drawing.Point(163, 143);
            this.cboVaiTro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(374, 36);
            this.cboVaiTro.TabIndex = 4;
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVaiTro.Location = new System.Drawing.Point(31, 148);
            this.lblVaiTro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(133, 28);
            this.lblVaiTro.TabIndex = 5;
            this.lblVaiTro.Text = "Vai trò demo";
            // 
            // btnLoaiSanPham
            // 
            this.btnLoaiSanPham.Location = new System.Drawing.Point(36, 213);
            this.btnLoaiSanPham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoaiSanPham.Name = "btnLoaiSanPham";
            this.btnLoaiSanPham.Size = new System.Drawing.Size(503, 51);
            this.btnLoaiSanPham.TabIndex = 3;
            this.btnLoaiSanPham.Text = "Mở frmLoaiSanPham";
            this.btnLoaiSanPham.Click += new System.EventHandler(this.btnLoaiSanPham_Click);
            // 
            // btnThuongHieu
            // 
            this.btnThuongHieu.Location = new System.Drawing.Point(36, 280);
            this.btnThuongHieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThuongHieu.Name = "btnThuongHieu";
            this.btnThuongHieu.Size = new System.Drawing.Size(503, 51);
            this.btnThuongHieu.TabIndex = 2;
            this.btnThuongHieu.Text = "Mở frmThuongHieu";
            this.btnThuongHieu.Click += new System.EventHandler(this.btnThuongHieu_Click);
            // 
            // btnNhaCungCap
            // 
            this.btnNhaCungCap.Location = new System.Drawing.Point(36, 347);
            this.btnNhaCungCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNhaCungCap.Name = "btnNhaCungCap";
            this.btnNhaCungCap.Size = new System.Drawing.Size(503, 51);
            this.btnNhaCungCap.TabIndex = 1;
            this.btnNhaCungCap.Text = "Mở frmNhaCungCap";
            this.btnNhaCungCap.Click += new System.EventHandler(this.btnNhaCungCap_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Location = new System.Drawing.Point(36, 413);
            this.btnSanPham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(503, 51);
            this.btnSanPham.TabIndex = 0;
            this.btnSanPham.Text = "Mở frmSanPham";
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // frmMenuDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1006, 512);
            this.Controls.Add(this.btnSanPham);
            this.Controls.Add(this.btnNhaCungCap);
            this.Controls.Add(this.btnThuongHieu);
            this.Controls.Add(this.btnLoaiSanPham);
            this.Controls.Add(this.cboVaiTro);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmMenuDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Demo";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
