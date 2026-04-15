namespace QuanLyCuaHangMayTinh
{
    partial class frmQuanlybanhang_Nhanvien
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBaocaohoadon_nhanvien = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnDangxuat = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lbXinchao = new System.Windows.Forms.Label();
            this.pnelQuanlybanhang = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.iconDropDownButton1 = new FontAwesome.Sharp.IconDropDownButton();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1114, 40);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(409, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ BÁN HÀNG COFFEE";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaGreen;
            this.panel2.Controls.Add(this.btnBaocaohoadon_nhanvien);
            this.panel2.Controls.Add(this.iconButton1);
            this.panel2.Controls.Add(this.btnDangxuat);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbXinchao);
            this.panel2.Location = new System.Drawing.Point(55, 34);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1058, 32);
            this.panel2.TabIndex = 2;
            // 
            // btnBaocaohoadon_nhanvien
            // 
            this.btnBaocaohoadon_nhanvien.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnBaocaohoadon_nhanvien.IconColor = System.Drawing.Color.Black;
            this.btnBaocaohoadon_nhanvien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaocaohoadon_nhanvien.Location = new System.Drawing.Point(333, 14);
            this.btnBaocaohoadon_nhanvien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBaocaohoadon_nhanvien.Name = "btnBaocaohoadon_nhanvien";
            this.btnBaocaohoadon_nhanvien.Size = new System.Drawing.Size(121, 21);
            this.btnBaocaohoadon_nhanvien.TabIndex = 8;
            this.btnBaocaohoadon_nhanvien.Text = "Báo cáo hóa đơn";
            this.btnBaocaohoadon_nhanvien.UseVisualStyleBackColor = true;
            this.btnBaocaohoadon_nhanvien.Click += new System.EventHandler(this.btnBaocaohoadon_nhanvien_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(202, 14);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(109, 21);
            this.iconButton1.TabIndex = 7;
            this.iconButton1.Text = "Quản lý bàn";
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btnDangxuat
            // 
            this.btnDangxuat.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.btnDangxuat.IconColor = System.Drawing.Color.Green;
            this.btnDangxuat.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnDangxuat.IconSize = 20;
            this.btnDangxuat.Location = new System.Drawing.Point(961, 9);
            this.btnDangxuat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDangxuat.Name = "btnDangxuat";
            this.btnDangxuat.Size = new System.Drawing.Size(94, 24);
            this.btnDangxuat.TabIndex = 6;
            this.btnDangxuat.Text = "Đăng xuất";
            this.btnDangxuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDangxuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangxuat.UseCompatibleTextRendering = true;
            this.btnDangxuat.UseVisualStyleBackColor = true;
            this.btnDangxuat.Click += new System.EventHandler(this.btnDangxuat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(544, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 0;
            // 
            // lbXinchao
            // 
            this.lbXinchao.AutoSize = true;
            this.lbXinchao.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbXinchao.ForeColor = System.Drawing.Color.White;
            this.lbXinchao.Location = new System.Drawing.Point(17, 13);
            this.lbXinchao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbXinchao.Name = "lbXinchao";
            this.lbXinchao.Size = new System.Drawing.Size(58, 16);
            this.lbXinchao.TabIndex = 3;
            this.lbXinchao.Text = "Xin chào";
            // 
            // pnelQuanlybanhang
            // 
            this.pnelQuanlybanhang.Location = new System.Drawing.Point(16, 72);
            this.pnelQuanlybanhang.Margin = new System.Windows.Forms.Padding(0);
            this.pnelQuanlybanhang.Name = "pnelQuanlybanhang";
            this.pnelQuanlybanhang.Size = new System.Drawing.Size(1076, 612);
            this.pnelQuanlybanhang.TabIndex = 3;
            this.pnelQuanlybanhang.Paint += new System.Windows.Forms.PaintEventHandler(this.pnelQuanlybanhang_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.pictureBox1.Image = global::QuanLyCuaHangMayTinh.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // iconDropDownButton1
            // 
            this.iconDropDownButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconDropDownButton1.IconColor = System.Drawing.Color.Black;
            this.iconDropDownButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDropDownButton1.Name = "iconDropDownButton1";
            this.iconDropDownButton1.Size = new System.Drawing.Size(23, 23);
            this.iconDropDownButton1.Text = "iconDropDownButton1";
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(32, 19);
            this.iconMenuItem1.Text = "iconMenuItem1";
            // 
            // frmQuanlybanhang_Nhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 693);
            this.Controls.Add(this.pnelQuanlybanhang);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Green;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmQuanlybanhang_Nhanvien";
            this.Text = "frmQuanlybanhang_Nhanvien";
            this.Load += new System.EventHandler(this.frmQuanlybanhang_Nhanvien_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbXinchao;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnDangxuat;
        private System.Windows.Forms.Panel pnelQuanlybanhang;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconButton btnBaocaohoadon_nhanvien;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}