namespace QuanLyCuaHangMayTinh
{
    partial class frm_quanly
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
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.btnDangXuat = new FontAwesome.Sharp.IconButton();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlDeskTop = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnKhuyenMai = new FontAwesome.Sharp.IconButton();
            this.btnBaoCao = new FontAwesome.Sharp.IconButton();
            this.btnQLLoaiMon = new FontAwesome.Sharp.IconButton();
            this.btnQLMon = new FontAwesome.Sharp.IconButton();
            this.btnQLHoaDon = new FontAwesome.Sharp.IconButton();
            this.btnQLBan = new FontAwesome.Sharp.IconButton();
            this.btnQLTaiKhoan = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTieuDe.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTieuDe
            // 
            this.pnlTieuDe.BackColor = System.Drawing.Color.Green;
            this.pnlTieuDe.Controls.Add(this.btnDangXuat);
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Location = new System.Drawing.Point(309, 0);
            this.pnlTieuDe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(1342, 94);
            this.pnlTieuDe.TabIndex = 8;
            this.pnlTieuDe.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTieuDe_Paint);
            this.pnlTieuDe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTieuDe_MouseDown);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.Yellow;
            this.btnDangXuat.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.btnDangXuat.IconColor = System.Drawing.Color.Yellow;
            this.btnDangXuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDangXuat.IconSize = 40;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(1090, 11);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(204, 71);
            this.btnDangXuat.TabIndex = 22;
            this.btnDangXuat.Text = "     Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Yellow;
            this.lblTieuDe.Location = new System.Drawing.Point(46, 42);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(0, 51);
            this.lblTieuDe.TabIndex = 2;
            // 
            // pnlDeskTop
            // 
            this.pnlDeskTop.BackColor = System.Drawing.Color.White;
            this.pnlDeskTop.Location = new System.Drawing.Point(309, 94);
            this.pnlDeskTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDeskTop.Name = "pnlDeskTop";
            this.pnlDeskTop.Size = new System.Drawing.Size(1342, 826);
            this.pnlDeskTop.TabIndex = 10;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Green;
            this.panelMenu.Controls.Add(this.btnKhuyenMai);
            this.panelMenu.Controls.Add(this.btnQLLoaiMon);
            this.panelMenu.Controls.Add(this.btnBaoCao);
            this.panelMenu.Controls.Add(this.btnQLMon);
            this.panelMenu.Controls.Add(this.btnQLHoaDon);
            this.panelMenu.Controls.Add(this.btnQLBan);
            this.panelMenu.Controls.Add(this.btnQLTaiKhoan);
            this.panelMenu.Location = new System.Drawing.Point(-4, 241);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(314, 679);
            this.panelMenu.TabIndex = 9;
            this.panelMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMenu_MouseDown);
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhuyenMai.ForeColor = System.Drawing.Color.White;
            this.btnKhuyenMai.IconChar = FontAwesome.Sharp.IconChar.Percentage;
            this.btnKhuyenMai.IconColor = System.Drawing.Color.White;
            this.btnKhuyenMai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhuyenMai.IconSize = 40;
            this.btnKhuyenMai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhuyenMai.Location = new System.Drawing.Point(3, 385);
            this.btnKhuyenMai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(310, 88);
            this.btnKhuyenMai.TabIndex = 12;
            this.btnKhuyenMai.Text = "    Quản lý khuyến mãi";
            this.btnKhuyenMai.UseVisualStyleBackColor = false;
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.btnBaoCao.IconColor = System.Drawing.Color.White;
            this.btnBaoCao.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaoCao.IconSize = 40;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(3, 286);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(310, 88);
            this.btnBaoCao.TabIndex = 16;
            this.btnBaoCao.Text = "     Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = false;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnQLLoaiMon
            // 
            this.btnQLLoaiMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLLoaiMon.ForeColor = System.Drawing.Color.White;
            this.btnQLLoaiMon.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnQLLoaiMon.IconColor = System.Drawing.Color.White;
            this.btnQLLoaiMon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLLoaiMon.IconSize = 40;
            this.btnQLLoaiMon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLLoaiMon.Location = new System.Drawing.Point(4, 581);
            this.btnQLLoaiMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQLLoaiMon.Name = "btnQLLoaiMon";
            this.btnQLLoaiMon.Size = new System.Drawing.Size(310, 88);
            this.btnQLLoaiMon.TabIndex = 18;
            this.btnQLLoaiMon.Text = "     ";
            this.btnQLLoaiMon.UseVisualStyleBackColor = false;
            this.btnQLLoaiMon.Click += new System.EventHandler(this.btnQLLoaiMon_Click);
            // 
            // btnQLMon
            // 
            this.btnQLMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLMon.ForeColor = System.Drawing.Color.White;
            this.btnQLMon.IconChar = FontAwesome.Sharp.IconChar.Coffee;
            this.btnQLMon.IconColor = System.Drawing.Color.White;
            this.btnQLMon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLMon.IconSize = 40;
            this.btnQLMon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLMon.Location = new System.Drawing.Point(4, 477);
            this.btnQLMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQLMon.Name = "btnQLMon";
            this.btnQLMon.Size = new System.Drawing.Size(310, 88);
            this.btnQLMon.TabIndex = 17;
            this.btnQLMon.UseVisualStyleBackColor = false;
            this.btnQLMon.Click += new System.EventHandler(this.btnQLMon_Click);
            // 
            // btnQLHoaDon
            // 
            this.btnQLHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnQLHoaDon.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.btnQLHoaDon.IconColor = System.Drawing.Color.White;
            this.btnQLHoaDon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLHoaDon.IconSize = 40;
            this.btnQLHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLHoaDon.Location = new System.Drawing.Point(3, 194);
            this.btnQLHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQLHoaDon.Name = "btnQLHoaDon";
            this.btnQLHoaDon.Size = new System.Drawing.Size(310, 88);
            this.btnQLHoaDon.TabIndex = 15;
            this.btnQLHoaDon.Text = "     Quản lý đơn hàng";
            this.btnQLHoaDon.UseVisualStyleBackColor = false;
            this.btnQLHoaDon.Click += new System.EventHandler(this.btnQLHoaDon_Click);
            // 
            // btnQLBan
            // 
            this.btnQLBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLBan.ForeColor = System.Drawing.Color.White;
            this.btnQLBan.IconChar = FontAwesome.Sharp.IconChar.Table;
            this.btnQLBan.IconColor = System.Drawing.Color.White;
            this.btnQLBan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLBan.IconSize = 40;
            this.btnQLBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLBan.Location = new System.Drawing.Point(3, 100);
            this.btnQLBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQLBan.Name = "btnQLBan";
            this.btnQLBan.Size = new System.Drawing.Size(310, 88);
            this.btnQLBan.TabIndex = 14;
            this.btnQLBan.Text = "     Quản lý danh mục";
            this.btnQLBan.UseVisualStyleBackColor = false;
            this.btnQLBan.Click += new System.EventHandler(this.btnQLBan_Click);
            // 
            // btnQLTaiKhoan
            // 
            this.btnQLTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnQLTaiKhoan.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.btnQLTaiKhoan.IconColor = System.Drawing.Color.White;
            this.btnQLTaiKhoan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLTaiKhoan.IconSize = 40;
            this.btnQLTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLTaiKhoan.Location = new System.Drawing.Point(3, 6);
            this.btnQLTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            this.btnQLTaiKhoan.Size = new System.Drawing.Size(310, 88);
            this.btnQLTaiKhoan.TabIndex = 13;
            this.btnQLTaiKhoan.Text = "     Quản lý người dùng";
            this.btnQLTaiKhoan.UseVisualStyleBackColor = false;
            this.btnQLTaiKhoan.Click += new System.EventHandler(this.btnQLTaiKhoan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 241);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frm_quanly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1652, 921);
            this.Controls.Add(this.pnlTieuDe);
            this.Controls.Add(this.pnlDeskTop);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frm_quanly";
            this.Text = "frm_quanly";
            this.Load += new System.EventHandler(this.frm_quanly_Load);
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlTieuDe.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTieuDe;
        private FontAwesome.Sharp.IconButton btnDangXuat;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlDeskTop;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnKhuyenMai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnQLLoaiMon;
        private FontAwesome.Sharp.IconButton btnQLMon;
        private FontAwesome.Sharp.IconButton btnBaoCao;
        private FontAwesome.Sharp.IconButton btnQLHoaDon;
        private FontAwesome.Sharp.IconButton btnQLBan;
        private FontAwesome.Sharp.IconButton btnQLTaiKhoan;
    }
}

