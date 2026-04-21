namespace QuanLyCuaHangMayTinh
{
    partial class frmNhapKho
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
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.lblLoaiNV = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.cboNguyenLieu = new System.Windows.Forms.ComboBox();
            this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSLNhap = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.cboNVNhap = new System.Windows.Forms.ComboBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMaHDN = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLamMoi2 = new FontAwesome.Sharp.IconButton();
            this.btnLuu2 = new FontAwesome.Sharp.IconButton();
            this.btnTimKiem2 = new FontAwesome.Sharp.IconButton();
            this.btnSua2 = new FontAwesome.Sharp.IconButton();
            this.btnThem2 = new FontAwesome.Sharp.IconButton();
            this.btnXoa2 = new FontAwesome.Sharp.IconButton();
            this.btnLamMoi1 = new FontAwesome.Sharp.IconButton();
            this.btnLuu1 = new FontAwesome.Sharp.IconButton();
            this.btnTimKiem1 = new FontAwesome.Sharp.IconButton();
            this.btnSua1 = new FontAwesome.Sharp.IconButton();
            this.btnThem1 = new FontAwesome.Sharp.IconButton();
            this.btnXoa1 = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CalendarTrailingForeColor = System.Drawing.SystemColors.Control;
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(327, 151);
            this.dtpNgayNhap.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(190, 33);
            this.dtpNgayNhap.TabIndex = 43;
            // 
            // lblLoaiNV
            // 
            this.lblLoaiNV.AutoSize = true;
            this.lblLoaiNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lblLoaiNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblLoaiNV.Location = new System.Drawing.Point(98, 195);
            this.lblLoaiNV.Name = "lblLoaiNV";
            this.lblLoaiNV.Size = new System.Drawing.Size(108, 25);
            this.lblLoaiNV.TabIndex = 45;
            this.lblLoaiNV.Text = "Tổng tiền:";
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lblLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblLop.Location = new System.Drawing.Point(98, 155);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(122, 25);
            this.lblLop.TabIndex = 39;
            this.lblLop.Text = "Ngày nhập:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lblNgaySinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblNgaySinh.Location = new System.Drawing.Point(98, 111);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(151, 25);
            this.lblNgaySinh.TabIndex = 40;
            this.lblNgaySinh.Text = "Nhà cung cấp:";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lblTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblTen.Location = new System.Drawing.Point(98, 63);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(169, 25);
            this.lblTen.TabIndex = 41;
            this.lblTen.Text = "Nhân viên nhập:";
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lblMSSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblMSSV.Location = new System.Drawing.Point(98, 18);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(186, 25);
            this.lblMSSV.TabIndex = 42;
            this.lblMSSV.Text = "Mã hóa đơn nhập:";
            // 
            // cboNguyenLieu
            // 
            this.cboNguyenLieu.FormattingEnabled = true;
            this.cboNguyenLieu.Location = new System.Drawing.Point(316, 42);
            this.cboNguyenLieu.Name = "cboNguyenLieu";
            this.cboNguyenLieu.Size = new System.Drawing.Size(190, 28);
            this.cboNguyenLieu.TabIndex = 56;
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Location = new System.Drawing.Point(316, 155);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(190, 26);
            this.txtDonGiaNhap.TabIndex = 55;
            this.txtDonGiaNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGiaNhap_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.label4.Location = new System.Drawing.Point(94, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 25);
            this.label4.TabIndex = 54;
            this.label4.Text = "Đơn giá nhập:";
            // 
            // txtSLNhap
            // 
            this.txtSLNhap.Location = new System.Drawing.Point(316, 100);
            this.txtSLNhap.Name = "txtSLNhap";
            this.txtSLNhap.Size = new System.Drawing.Size(190, 26);
            this.txtSLNhap.TabIndex = 52;
            this.txtSLNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSLNhap_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboNguyenLieu);
            this.panel3.Controls.Add(this.txtDonGiaNhap);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtSLNhap);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(696, 442);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(630, 231);
            this.panel3.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.label3.Location = new System.Drawing.Point(94, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 25);
            this.label3.TabIndex = 51;
            this.label3.Text = "Số lượng nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.label2.Location = new System.Drawing.Point(94, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 50;
            this.label2.Text = "Sản phẩm:";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(327, 105);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(190, 28);
            this.cboNhaCungCap.TabIndex = 51;
            // 
            // cboNVNhap
            // 
            this.cboNVNhap.FormattingEnabled = true;
            this.cboNVNhap.Location = new System.Drawing.Point(327, 63);
            this.cboNVNhap.Name = "cboNVNhap";
            this.cboNVNhap.Size = new System.Drawing.Size(190, 28);
            this.cboNVNhap.TabIndex = 50;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(327, 191);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(190, 26);
            this.txtTongTien.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboNhaCungCap);
            this.panel2.Controls.Add(this.cboNVNhap);
            this.panel2.Controls.Add(this.txtTongTien);
            this.panel2.Controls.Add(this.txtMaHDN);
            this.panel2.Controls.Add(this.dtpNgayNhap);
            this.panel2.Controls.Add(this.lblLoaiNV);
            this.panel2.Controls.Add(this.lblLop);
            this.panel2.Controls.Add(this.lblNgaySinh);
            this.panel2.Controls.Add(this.lblTen);
            this.panel2.Controls.Add(this.lblMSSV);
            this.panel2.Location = new System.Drawing.Point(12, 442);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 231);
            this.panel2.TabIndex = 24;
            // 
            // txtMaHDN
            // 
            this.txtMaHDN.Location = new System.Drawing.Point(327, 14);
            this.txtMaHDN.Name = "txtMaHDN";
            this.txtMaHDN.Size = new System.Drawing.Size(190, 26);
            this.txtMaHDN.TabIndex = 47;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Green;
            this.panel4.Controls.Add(this.btnLamMoi2);
            this.panel4.Controls.Add(this.btnLuu2);
            this.panel4.Controls.Add(this.btnTimKiem2);
            this.panel4.Controls.Add(this.btnSua2);
            this.panel4.Controls.Add(this.btnThem2);
            this.panel4.Controls.Add(this.btnXoa2);
            this.panel4.Controls.Add(this.btnLamMoi1);
            this.panel4.Controls.Add(this.btnLuu1);
            this.panel4.Controls.Add(this.btnTimKiem1);
            this.panel4.Controls.Add(this.btnSua1);
            this.panel4.Controls.Add(this.btnThem1);
            this.panel4.Controls.Add(this.btnXoa1);
            this.panel4.Location = new System.Drawing.Point(12, 678);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1314, 135);
            this.panel4.TabIndex = 23;
            // 
            // btnLamMoi2
            // 
            this.btnLamMoi2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi2.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi2.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnLamMoi2.IconColor = System.Drawing.Color.White;
            this.btnLamMoi2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLamMoi2.IconSize = 20;
            this.btnLamMoi2.Location = new System.Drawing.Point(1144, 78);
            this.btnLamMoi2.Name = "btnLamMoi2";
            this.btnLamMoi2.Size = new System.Drawing.Size(130, 46);
            this.btnLamMoi2.TabIndex = 14;
            this.btnLamMoi2.Text = "     Làm mới";
            this.btnLamMoi2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi2.UseVisualStyleBackColor = false;
            this.btnLamMoi2.Click += new System.EventHandler(this.btnLamMoi2_Click);
            // 
            // btnLuu2
            // 
            this.btnLuu2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu2.ForeColor = System.Drawing.Color.White;
            this.btnLuu2.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnLuu2.IconColor = System.Drawing.Color.White;
            this.btnLuu2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLuu2.IconSize = 20;
            this.btnLuu2.Location = new System.Drawing.Point(716, 78);
            this.btnLuu2.Name = "btnLuu2";
            this.btnLuu2.Size = new System.Drawing.Size(130, 46);
            this.btnLuu2.TabIndex = 13;
            this.btnLuu2.Text = "     Lưu";
            this.btnLuu2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu2.UseVisualStyleBackColor = false;
            this.btnLuu2.Click += new System.EventHandler(this.btnLuu2_Click);
            // 
            // btnTimKiem2
            // 
            this.btnTimKiem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem2.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem2.IconChar = FontAwesome.Sharp.IconChar.SearchMinus;
            this.btnTimKiem2.IconColor = System.Drawing.Color.White;
            this.btnTimKiem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTimKiem2.IconSize = 20;
            this.btnTimKiem2.Location = new System.Drawing.Point(934, 78);
            this.btnTimKiem2.Name = "btnTimKiem2";
            this.btnTimKiem2.Size = new System.Drawing.Size(130, 46);
            this.btnTimKiem2.TabIndex = 12;
            this.btnTimKiem2.Text = "     Tìm kiếm";
            this.btnTimKiem2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem2.UseVisualStyleBackColor = false;
            this.btnTimKiem2.Click += new System.EventHandler(this.btnTimKiem2_Click);
            // 
            // btnSua2
            // 
            this.btnSua2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua2.ForeColor = System.Drawing.Color.White;
            this.btnSua2.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnSua2.IconColor = System.Drawing.Color.White;
            this.btnSua2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSua2.IconSize = 20;
            this.btnSua2.Location = new System.Drawing.Point(1144, 15);
            this.btnSua2.Name = "btnSua2";
            this.btnSua2.Size = new System.Drawing.Size(130, 46);
            this.btnSua2.TabIndex = 10;
            this.btnSua2.Text = "     Sửa";
            this.btnSua2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua2.UseVisualStyleBackColor = false;
            this.btnSua2.Click += new System.EventHandler(this.btnSua2_Click);
            // 
            // btnThem2
            // 
            this.btnThem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem2.ForeColor = System.Drawing.Color.White;
            this.btnThem2.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnThem2.IconColor = System.Drawing.Color.White;
            this.btnThem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThem2.IconSize = 20;
            this.btnThem2.Location = new System.Drawing.Point(716, 15);
            this.btnThem2.Name = "btnThem2";
            this.btnThem2.Size = new System.Drawing.Size(130, 46);
            this.btnThem2.TabIndex = 9;
            this.btnThem2.Text = "     Thêm";
            this.btnThem2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem2.UseVisualStyleBackColor = false;
            this.btnThem2.Click += new System.EventHandler(this.btnThem2_Click);
            // 
            // btnXoa2
            // 
            this.btnXoa2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa2.ForeColor = System.Drawing.Color.White;
            this.btnXoa2.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnXoa2.IconColor = System.Drawing.Color.White;
            this.btnXoa2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXoa2.IconSize = 20;
            this.btnXoa2.Location = new System.Drawing.Point(934, 15);
            this.btnXoa2.Name = "btnXoa2";
            this.btnXoa2.Size = new System.Drawing.Size(130, 46);
            this.btnXoa2.TabIndex = 11;
            this.btnXoa2.Text = "     Xóa";
            this.btnXoa2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa2.UseVisualStyleBackColor = false;
            this.btnXoa2.Click += new System.EventHandler(this.btnXoa2_Click);
            // 
            // btnLamMoi1
            // 
            this.btnLamMoi1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi1.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi1.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnLamMoi1.IconColor = System.Drawing.Color.White;
            this.btnLamMoi1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLamMoi1.IconSize = 20;
            this.btnLamMoi1.Location = new System.Drawing.Point(480, 78);
            this.btnLamMoi1.Name = "btnLamMoi1";
            this.btnLamMoi1.Size = new System.Drawing.Size(130, 46);
            this.btnLamMoi1.TabIndex = 8;
            this.btnLamMoi1.Text = "     Làm mới";
            this.btnLamMoi1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi1.UseVisualStyleBackColor = false;
            this.btnLamMoi1.Click += new System.EventHandler(this.btnLamMoi1_Click);
            // 
            // btnLuu1
            // 
            this.btnLuu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu1.ForeColor = System.Drawing.Color.White;
            this.btnLuu1.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnLuu1.IconColor = System.Drawing.Color.White;
            this.btnLuu1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLuu1.IconSize = 20;
            this.btnLuu1.Location = new System.Drawing.Point(52, 78);
            this.btnLuu1.Name = "btnLuu1";
            this.btnLuu1.Size = new System.Drawing.Size(130, 46);
            this.btnLuu1.TabIndex = 7;
            this.btnLuu1.Text = "     Lưu";
            this.btnLuu1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu1.UseVisualStyleBackColor = false;
            this.btnLuu1.Click += new System.EventHandler(this.btnLuu1_Click);
            // 
            // btnTimKiem1
            // 
            this.btnTimKiem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem1.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem1.IconChar = FontAwesome.Sharp.IconChar.SearchMinus;
            this.btnTimKiem1.IconColor = System.Drawing.Color.White;
            this.btnTimKiem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTimKiem1.IconSize = 20;
            this.btnTimKiem1.Location = new System.Drawing.Point(270, 78);
            this.btnTimKiem1.Name = "btnTimKiem1";
            this.btnTimKiem1.Size = new System.Drawing.Size(130, 46);
            this.btnTimKiem1.TabIndex = 6;
            this.btnTimKiem1.Text = "     Tìm kiếm";
            this.btnTimKiem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem1.UseVisualStyleBackColor = false;
            this.btnTimKiem1.Click += new System.EventHandler(this.btnTimKiem1_Click);
            // 
            // btnSua1
            // 
            this.btnSua1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua1.ForeColor = System.Drawing.Color.White;
            this.btnSua1.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnSua1.IconColor = System.Drawing.Color.White;
            this.btnSua1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSua1.IconSize = 20;
            this.btnSua1.Location = new System.Drawing.Point(480, 15);
            this.btnSua1.Name = "btnSua1";
            this.btnSua1.Size = new System.Drawing.Size(130, 46);
            this.btnSua1.TabIndex = 2;
            this.btnSua1.Text = "     Sửa";
            this.btnSua1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua1.UseVisualStyleBackColor = false;
            this.btnSua1.Click += new System.EventHandler(this.btnSua1_Click);
            // 
            // btnThem1
            // 
            this.btnThem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem1.ForeColor = System.Drawing.Color.White;
            this.btnThem1.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnThem1.IconColor = System.Drawing.Color.White;
            this.btnThem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThem1.IconSize = 20;
            this.btnThem1.Location = new System.Drawing.Point(52, 15);
            this.btnThem1.Name = "btnThem1";
            this.btnThem1.Size = new System.Drawing.Size(130, 46);
            this.btnThem1.TabIndex = 1;
            this.btnThem1.Text = "     Thêm";
            this.btnThem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem1.UseVisualStyleBackColor = false;
            this.btnThem1.Click += new System.EventHandler(this.btnThem1_Click);
            // 
            // btnXoa1
            // 
            this.btnXoa1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa1.ForeColor = System.Drawing.Color.White;
            this.btnXoa1.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnXoa1.IconColor = System.Drawing.Color.White;
            this.btnXoa1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXoa1.IconSize = 20;
            this.btnXoa1.Location = new System.Drawing.Point(270, 15);
            this.btnXoa1.Name = "btnXoa1";
            this.btnXoa1.Size = new System.Drawing.Size(130, 46);
            this.btnXoa1.TabIndex = 3;
            this.btnXoa1.Text = "     Xóa";
            this.btnXoa1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa1.UseVisualStyleBackColor = false;
            this.btnXoa1.Click += new System.EventHandler(this.btnXoa1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(680, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chi tiết";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(39, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(159, 25);
            this.lblTieuDe.TabIndex = 3;
            this.lblTieuDe.Text = "Hóa đơn nhập";
            // 
            // DataGridView2
            // 
            this.DataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Location = new System.Drawing.Point(684, 32);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.RowHeadersWidth = 51;
            this.DataGridView2.RowTemplate.Height = 28;
            this.DataGridView2.Size = new System.Drawing.Size(590, 352);
            this.DataGridView2.TabIndex = 1;
            this.DataGridView2.Click += new System.EventHandler(this.DataGridView2_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(44, 32);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersWidth = 51;
            this.DataGridView1.RowTemplate.Height = 28;
            this.DataGridView1.Size = new System.Drawing.Size(590, 352);
            this.DataGridView1.TabIndex = 0;
            this.DataGridView1.Click += new System.EventHandler(this.DataGridView1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTieuDe);
            this.panel1.Controls.Add(this.DataGridView2);
            this.panel1.Controls.Add(this.DataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1314, 409);
            this.panel1.TabIndex = 22;
            // 
            // frmNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 826);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmNhapKho";
            this.Text = "frmNhapKho";
            this.Load += new System.EventHandler(this.frmNhapKho_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblLoaiNV;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblMSSV;
        private FontAwesome.Sharp.IconButton btnLamMoi2;
        private FontAwesome.Sharp.IconButton btnLuu2;
        private FontAwesome.Sharp.IconButton btnTimKiem2;
        private FontAwesome.Sharp.IconButton btnSua2;
        private FontAwesome.Sharp.IconButton btnThem2;
        private FontAwesome.Sharp.IconButton btnXoa2;
        private FontAwesome.Sharp.IconButton btnLamMoi1;
        private FontAwesome.Sharp.IconButton btnLuu1;
        private FontAwesome.Sharp.IconButton btnTimKiem1;
        private FontAwesome.Sharp.IconButton btnSua1;
        private FontAwesome.Sharp.IconButton btnThem1;
        private System.Windows.Forms.ComboBox cboNguyenLieu;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSLNhap;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnXoa1;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.ComboBox cboNVNhap;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaHDN;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.DataGridView DataGridView2;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Panel panel1;
    }
}