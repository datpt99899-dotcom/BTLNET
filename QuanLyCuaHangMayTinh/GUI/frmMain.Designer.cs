namespace QuanLyCuaHangMayTinh.GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblTenNguoiDung = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(12, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(760, 480);
            this.panelMain.TabIndex = 0;
            // 
            // lblTenNguoiDung
            // 
            this.lblTenNguoiDung.AutoSize = true;
            this.lblTenNguoiDung.Location = new System.Drawing.Point(12, 20);
            this.lblTenNguoiDung.Name = "lblTenNguoiDung";
            this.lblTenNguoiDung.Size = new System.Drawing.Size(100, 16);
            this.lblTenNguoiDung.TabIndex = 1;
            this.lblTenNguoiDung.Text = "Tên người dùng";
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(150, 20);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(48, 16);
            this.lblVaiTro.TabIndex = 2;
            this.lblVaiTro.Text = "Vai trò";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(650, 15);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(100, 30);
            this.btnDangXuat.TabIndex = 3;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.lblTenNguoiDung);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý cửa hàng máy tính";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTenNguoiDung;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Button btnDangXuat;
    }
}
