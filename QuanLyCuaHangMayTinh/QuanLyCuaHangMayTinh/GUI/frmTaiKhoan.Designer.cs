namespace QuanLyCuaHangMayTinh
{
    partial class frm_quanlytaikhoan
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
            this.ibtnLuu = new FontAwesome.Sharp.IconButton();
            this.ibtnLammoi = new FontAwesome.Sharp.IconButton();
            this.ibtnXoa = new FontAwesome.Sharp.IconButton();
            this.ibtnSua = new FontAwesome.Sharp.IconButton();
            this.ibtnThem = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.mskSodienthoai = new System.Windows.Forms.MaskedTextBox();
            this.mskNgaysinh = new System.Windows.Forms.MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMaque = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTennhanvien = new System.Windows.Forms.TextBox();
            this.chkNu = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkNam = new System.Windows.Forms.CheckBox();
            this.cboMachucvu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtManhanvien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datagridtaikhoan = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridtaikhoan)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ibtnLuu
            // 
            this.ibtnLuu.BackColor = System.Drawing.Color.Green;
            this.ibtnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnLuu.ForeColor = System.Drawing.Color.White;
            this.ibtnLuu.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.ibtnLuu.IconColor = System.Drawing.Color.White;
            this.ibtnLuu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnLuu.IconSize = 30;
            this.ibtnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnLuu.Location = new System.Drawing.Point(461, 18);
            this.ibtnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtnLuu.Name = "ibtnLuu";
            this.ibtnLuu.Size = new System.Drawing.Size(133, 57);
            this.ibtnLuu.TabIndex = 23;
            this.ibtnLuu.Text = "     Lưu";
            this.ibtnLuu.UseVisualStyleBackColor = false;
            this.ibtnLuu.Click += new System.EventHandler(this.ibtnLuu_Click);
            // 
            // ibtnLammoi
            // 
            this.ibtnLammoi.BackColor = System.Drawing.Color.Green;
            this.ibtnLammoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnLammoi.ForeColor = System.Drawing.Color.White;
            this.ibtnLammoi.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.ibtnLammoi.IconColor = System.Drawing.Color.White;
            this.ibtnLammoi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnLammoi.IconSize = 30;
            this.ibtnLammoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnLammoi.Location = new System.Drawing.Point(787, 18);
            this.ibtnLammoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtnLammoi.Name = "ibtnLammoi";
            this.ibtnLammoi.Size = new System.Drawing.Size(133, 57);
            this.ibtnLammoi.TabIndex = 24;
            this.ibtnLammoi.Text = "     Làm mới ";
            this.ibtnLammoi.UseVisualStyleBackColor = false;
            this.ibtnLammoi.Click += new System.EventHandler(this.ibtnLammoi_Click);
            // 
            // ibtnXoa
            // 
            this.ibtnXoa.BackColor = System.Drawing.Color.Green;
            this.ibtnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnXoa.ForeColor = System.Drawing.Color.White;
            this.ibtnXoa.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.ibtnXoa.IconColor = System.Drawing.Color.White;
            this.ibtnXoa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnXoa.IconSize = 30;
            this.ibtnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnXoa.Location = new System.Drawing.Point(619, 18);
            this.ibtnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtnXoa.Name = "ibtnXoa";
            this.ibtnXoa.Size = new System.Drawing.Size(133, 57);
            this.ibtnXoa.TabIndex = 25;
            this.ibtnXoa.Text = "     Xóa ";
            this.ibtnXoa.UseVisualStyleBackColor = false;
            this.ibtnXoa.Click += new System.EventHandler(this.ibtnXoa_Click);
            // 
            // ibtnSua
            // 
            this.ibtnSua.BackColor = System.Drawing.Color.Green;
            this.ibtnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnSua.ForeColor = System.Drawing.Color.White;
            this.ibtnSua.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.ibtnSua.IconColor = System.Drawing.Color.White;
            this.ibtnSua.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnSua.IconSize = 30;
            this.ibtnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnSua.Location = new System.Drawing.Point(297, 18);
            this.ibtnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtnSua.Name = "ibtnSua";
            this.ibtnSua.Size = new System.Drawing.Size(133, 57);
            this.ibtnSua.TabIndex = 26;
            this.ibtnSua.Text = "     Sửa";
            this.ibtnSua.UseVisualStyleBackColor = false;
            this.ibtnSua.Click += new System.EventHandler(this.ibtnSua_Click);
            // 
            // ibtnThem
            // 
            this.ibtnThem.BackColor = System.Drawing.Color.Green;
            this.ibtnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnThem.ForeColor = System.Drawing.Color.White;
            this.ibtnThem.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.ibtnThem.IconColor = System.Drawing.Color.White;
            this.ibtnThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnThem.IconSize = 30;
            this.ibtnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnThem.Location = new System.Drawing.Point(137, 18);
            this.ibtnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtnThem.Name = "ibtnThem";
            this.ibtnThem.Size = new System.Drawing.Size(133, 57);
            this.ibtnThem.TabIndex = 27;
            this.ibtnThem.Text = "     Thêm";
            this.ibtnThem.UseVisualStyleBackColor = false;
            this.ibtnThem.Click += new System.EventHandler(this.ibtnThem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel2.Controls.Add(this.txtLuong);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtMatkhau);
            this.panel2.Controls.Add(this.mskSodienthoai);
            this.panel2.Controls.Add(this.mskNgaysinh);
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(640, 34);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 201);
            this.panel2.TabIndex = 21;
            // 
            // txtLuong
            // 
            this.txtLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuong.Location = new System.Drawing.Point(192, 154);
            this.txtLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(215, 29);
            this.txtLuong.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(21, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 24);
            this.label12.TabIndex = 16;
            this.label12.Text = "Lương ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ngày sinh";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "Số điện thoại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "Mật khẩu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Địa chỉ email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(192, 15);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(215, 29);
            this.txtEmail.TabIndex = 17;
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatkhau.Location = new System.Drawing.Point(192, 49);
            this.txtMatkhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.Size = new System.Drawing.Size(215, 29);
            this.txtMatkhau.TabIndex = 16;
            // 
            // mskSodienthoai
            // 
            this.mskSodienthoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskSodienthoai.Location = new System.Drawing.Point(192, 84);
            this.mskSodienthoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskSodienthoai.Mask = "(999) 000-0000";
            this.mskSodienthoai.Name = "mskSodienthoai";
            this.mskSodienthoai.Size = new System.Drawing.Size(215, 29);
            this.mskSodienthoai.TabIndex = 2;
            // 
            // mskNgaysinh
            // 
            this.mskNgaysinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskNgaysinh.Location = new System.Drawing.Point(192, 121);
            this.mskNgaysinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskNgaysinh.Mask = "0000/00/00";
            this.mskNgaysinh.Name = "mskNgaysinh";
            this.mskNgaysinh.Size = new System.Drawing.Size(215, 29);
            this.mskNgaysinh.TabIndex = 0;
            this.mskNgaysinh.ValidatingType = typeof(System.DateTime);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboMaque);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtTennhanvien);
            this.panel1.Controls.Add(this.chkNu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkNam);
            this.panel1.Controls.Add(this.cboMachucvu);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtManhanvien);
            this.panel1.Controls.Add(this.label3);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(83, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 201);
            this.panel1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Giới tính";
            // 
            // cboMaque
            // 
            this.cboMaque.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaque.FormattingEnabled = true;
            this.cboMaque.Location = new System.Drawing.Point(195, 121);
            this.cboMaque.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMaque.Name = "cboMaque";
            this.cboMaque.Size = new System.Drawing.Size(211, 32);
            this.cboMaque.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Quê quán";
            // 
            // txtTennhanvien
            // 
            this.txtTennhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTennhanvien.Location = new System.Drawing.Point(195, 49);
            this.txtTennhanvien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTennhanvien.Name = "txtTennhanvien";
            this.txtTennhanvien.Size = new System.Drawing.Size(211, 29);
            this.txtTennhanvien.TabIndex = 11;
            // 
            // chkNu
            // 
            this.chkNu.AutoSize = true;
            this.chkNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNu.Location = new System.Drawing.Point(345, 156);
            this.chkNu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkNu.Name = "chkNu";
            this.chkNu.Size = new System.Drawing.Size(57, 28);
            this.chkNu.TabIndex = 1;
            this.chkNu.Text = "Nữ";
            this.chkNu.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã nhân viên ";
            // 
            // chkNam
            // 
            this.chkNam.AutoSize = true;
            this.chkNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNam.Location = new System.Drawing.Point(196, 156);
            this.chkNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkNam.Name = "chkNam";
            this.chkNam.Size = new System.Drawing.Size(72, 28);
            this.chkNam.TabIndex = 0;
            this.chkNam.Text = "Nam";
            this.chkNam.UseVisualStyleBackColor = true;
            // 
            // cboMachucvu
            // 
            this.cboMachucvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMachucvu.FormattingEnabled = true;
            this.cboMachucvu.Location = new System.Drawing.Point(195, 84);
            this.cboMachucvu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMachucvu.Name = "cboMachucvu";
            this.cboMachucvu.Size = new System.Drawing.Size(211, 32);
            this.cboMachucvu.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên nhân viên";
            // 
            // txtManhanvien
            // 
            this.txtManhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManhanvien.Location = new System.Drawing.Point(195, 15);
            this.txtManhanvien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtManhanvien.Name = "txtManhanvien";
            this.txtManhanvien.Size = new System.Drawing.Size(211, 29);
            this.txtManhanvien.TabIndex = 10;
            this.txtManhanvien.TextChanged += new System.EventHandler(this.txtManhanvien_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Chức vụ ";
            // 
            // datagridtaikhoan
            // 
            this.datagridtaikhoan.BackgroundColor = System.Drawing.Color.White;
            this.datagridtaikhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridtaikhoan.Location = new System.Drawing.Point(83, 251);
            this.datagridtaikhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datagridtaikhoan.Name = "datagridtaikhoan";
            this.datagridtaikhoan.RowHeadersWidth = 82;
            this.datagridtaikhoan.RowTemplate.Height = 33;
            this.datagridtaikhoan.Size = new System.Drawing.Size(1044, 282);
            this.datagridtaikhoan.TabIndex = 29;
            this.datagridtaikhoan.Click += new System.EventHandler(this.datagridtaikhoan_Click_1);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Green;
            this.panel4.Controls.Add(this.ibtnLammoi);
            this.panel4.Controls.Add(this.ibtnThem);
            this.panel4.Controls.Add(this.ibtnLuu);
            this.panel4.Controls.Add(this.ibtnSua);
            this.panel4.Controls.Add(this.ibtnXoa);
            this.panel4.Location = new System.Drawing.Point(83, 555);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1044, 92);
            this.panel4.TabIndex = 30;
            // 
            // frm_quanlytaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1193, 661);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.datagridtaikhoan);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_quanlytaikhoan";
            this.Text = "frm_quanlytaikhoan";
            this.Load += new System.EventHandler(this.frm_quanlytaikhoan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridtaikhoan)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton ibtnLuu;
        private FontAwesome.Sharp.IconButton ibtnLammoi;
        private FontAwesome.Sharp.IconButton ibtnXoa;
        private FontAwesome.Sharp.IconButton ibtnSua;
        private FontAwesome.Sharp.IconButton ibtnThem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.MaskedTextBox mskSodienthoai;
        private System.Windows.Forms.MaskedTextBox mskNgaysinh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMaque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTennhanvien;
        private System.Windows.Forms.CheckBox chkNu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNam;
        private System.Windows.Forms.ComboBox cboMachucvu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManhanvien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView datagridtaikhoan;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel4;
    }
}