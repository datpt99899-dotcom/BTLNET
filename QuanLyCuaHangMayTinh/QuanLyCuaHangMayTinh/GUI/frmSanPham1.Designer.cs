namespace QuanLyCuaHangMayTinh
{
    partial class frmSanpham
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBoqua = new FontAwesome.Sharp.IconButton();
            this.btnLuu = new FontAwesome.Sharp.IconButton();
            this.btnXoa = new FontAwesome.Sharp.IconButton();
            this.btnSua = new FontAwesome.Sharp.IconButton();
            this.btnThem = new FontAwesome.Sharp.IconButton();
            this.dataGridViewQLyCaPhe = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewChiTietSP = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSoluongdung = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMasanpham = new System.Windows.Forms.TextBox();
            this.txtTensanpham = new System.Windows.Forms.TextBox();
            this.txtGianhap = new System.Windows.Forms.TextBox();
            this.txtGiaban = new System.Windows.Forms.TextBox();
            this.cboDanhmuc = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.btnOpen = new FontAwesome.Sharp.IconButton();
            this.btnTim = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboMaSPChitiet = new System.Windows.Forms.ComboBox();
            this.cboNguyenlieu = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLuuChitiet = new FontAwesome.Sharp.IconButton();
            this.btnXoaChitiet = new FontAwesome.Sharp.IconButton();
            this.btnSuaChitiet = new FontAwesome.Sharp.IconButton();
            this.btnThemChitiet = new FontAwesome.Sharp.IconButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQLyCaPhe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChiTietSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBoqua);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.dataGridViewQLyCaPhe);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(21, 14);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 372);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnBoqua
            // 
            this.btnBoqua.BackColor = System.Drawing.Color.ForestGreen;
            this.btnBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoqua.ForeColor = System.Drawing.Color.White;
            this.btnBoqua.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnBoqua.IconColor = System.Drawing.Color.White;
            this.btnBoqua.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBoqua.IconSize = 30;
            this.btnBoqua.Location = new System.Drawing.Point(611, 295);
            this.btnBoqua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(133, 47);
            this.btnBoqua.TabIndex = 12;
            this.btnBoqua.Text = "     Bỏ qua";
            this.btnBoqua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBoqua.UseVisualStyleBackColor = false;
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.ForestGreen;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnLuu.IconColor = System.Drawing.Color.White;
            this.btnLuu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLuu.IconSize = 30;
            this.btnLuu.Location = new System.Drawing.Point(611, 233);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(133, 47);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "     Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.ForestGreen;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnXoa.IconColor = System.Drawing.Color.White;
            this.btnXoa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXoa.IconSize = 30;
            this.btnXoa.Location = new System.Drawing.Point(611, 169);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(133, 47);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "     Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnSua.IconColor = System.Drawing.Color.White;
            this.btnSua.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSua.IconSize = 30;
            this.btnSua.Location = new System.Drawing.Point(611, 108);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(133, 47);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "     Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnThem.IconColor = System.Drawing.Color.White;
            this.btnThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThem.IconSize = 30;
            this.btnThem.Location = new System.Drawing.Point(611, 46);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(133, 47);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "     Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dataGridViewQLyCaPhe
            // 
            this.dataGridViewQLyCaPhe.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewQLyCaPhe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQLyCaPhe.GridColor = System.Drawing.Color.White;
            this.dataGridViewQLyCaPhe.Location = new System.Drawing.Point(24, 49);
            this.dataGridViewQLyCaPhe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewQLyCaPhe.Name = "dataGridViewQLyCaPhe";
            this.dataGridViewQLyCaPhe.RowHeadersWidth = 51;
            this.dataGridViewQLyCaPhe.RowTemplate.Height = 24;
            this.dataGridViewQLyCaPhe.Size = new System.Drawing.Size(552, 293);
            this.dataGridViewQLyCaPhe.TabIndex = 5;
            this.dataGridViewQLyCaPhe.Click += new System.EventHandler(this.dataGridViewQLyCaPhe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(153, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "DANH SÁCH SẢN PHẨM";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(79, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 26);
            this.label8.TabIndex = 13;
            this.label8.Text = "CHI TIẾT SẢN PHẨM";
            // 
            // dataGridViewChiTietSP
            // 
            this.dataGridViewChiTietSP.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewChiTietSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChiTietSP.GridColor = System.Drawing.Color.White;
            this.dataGridViewChiTietSP.Location = new System.Drawing.Point(24, 53);
            this.dataGridViewChiTietSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewChiTietSP.Name = "dataGridViewChiTietSP";
            this.dataGridViewChiTietSP.RowHeadersWidth = 51;
            this.dataGridViewChiTietSP.RowTemplate.Height = 24;
            this.dataGridViewChiTietSP.Size = new System.Drawing.Size(368, 153);
            this.dataGridViewChiTietSP.TabIndex = 14;
            this.dataGridViewChiTietSP.Click += new System.EventHandler(this.dataGridViewChiTietSP_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(417, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Tên sản phẩm";
            // 
            // txtSoluongdung
            // 
            this.txtSoluongdung.Location = new System.Drawing.Point(420, 191);
            this.txtSoluongdung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoluongdung.Name = "txtSoluongdung";
            this.txtSoluongdung.Size = new System.Drawing.Size(200, 22);
            this.txtSoluongdung.TabIndex = 20;
            this.txtSoluongdung.TextChanged += new System.EventHandler(this.txtSoluongdung_TextChanged);
            this.txtSoluongdung.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoluongdung_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(417, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 16);
            this.label12.TabIndex = 19;
            this.label12.Text = "Số lượng dùng";
            // 
            // txtTim
            // 
            this.txtTim.AcceptsReturn = true;
            this.txtTim.Location = new System.Drawing.Point(27, 32);
            this.txtTim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(193, 24);
            this.txtTim.TabIndex = 0;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên sản phẩm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Danh mục";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Giá nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Giá bán";
            // 
            // txtMasanpham
            // 
            this.txtMasanpham.Location = new System.Drawing.Point(171, 103);
            this.txtMasanpham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMasanpham.Name = "txtMasanpham";
            this.txtMasanpham.Size = new System.Drawing.Size(180, 24);
            this.txtMasanpham.TabIndex = 7;
            // 
            // txtTensanpham
            // 
            this.txtTensanpham.Location = new System.Drawing.Point(171, 140);
            this.txtTensanpham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTensanpham.Name = "txtTensanpham";
            this.txtTensanpham.Size = new System.Drawing.Size(180, 24);
            this.txtTensanpham.TabIndex = 8;
            // 
            // txtGianhap
            // 
            this.txtGianhap.Location = new System.Drawing.Point(171, 218);
            this.txtGianhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGianhap.Name = "txtGianhap";
            this.txtGianhap.Size = new System.Drawing.Size(180, 24);
            this.txtGianhap.TabIndex = 9;
            // 
            // txtGiaban
            // 
            this.txtGiaban.Location = new System.Drawing.Point(171, 256);
            this.txtGiaban.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGiaban.Name = "txtGiaban";
            this.txtGiaban.Size = new System.Drawing.Size(180, 24);
            this.txtGiaban.TabIndex = 10;
            // 
            // cboDanhmuc
            // 
            this.cboDanhmuc.FormattingEnabled = true;
            this.cboDanhmuc.Location = new System.Drawing.Point(171, 180);
            this.cboDanhmuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboDanhmuc.Name = "cboDanhmuc";
            this.cboDanhmuc.Size = new System.Drawing.Size(180, 26);
            this.cboDanhmuc.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Hình ảnh";
            // 
            // picAnh
            // 
            this.picAnh.Location = new System.Drawing.Point(27, 352);
            this.picAnh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(345, 185);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnh.TabIndex = 13;
            this.picAnh.TabStop = false;
            // 
            // txtAnh
            // 
            this.txtAnh.Location = new System.Drawing.Point(171, 295);
            this.txtAnh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.Size = new System.Drawing.Size(180, 24);
            this.txtAnh.TabIndex = 14;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.btnOpen.IconColor = System.Drawing.Color.White;
            this.btnOpen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOpen.IconSize = 30;
            this.btnOpen.Location = new System.Drawing.Point(143, 560);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(111, 50);
            this.btnOpen.TabIndex = 13;
            this.btnOpen.Text = "Open";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.IconChar = FontAwesome.Sharp.IconChar.SearchMinus;
            this.btnTim.IconColor = System.Drawing.Color.White;
            this.btnTim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTim.IconSize = 30;
            this.btnTim.Location = new System.Drawing.Point(227, 20);
            this.btnTim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(117, 47);
            this.btnTim.TabIndex = 15;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.txtAnh);
            this.panel1.Controls.Add(this.picAnh);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboDanhmuc);
            this.panel1.Controls.Add(this.txtGiaban);
            this.panel1.Controls.Add(this.txtGianhap);
            this.panel1.Controls.Add(this.txtTensanpham);
            this.panel1.Controls.Add(this.txtMasanpham);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTim);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(785, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 634);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboMaSPChitiet);
            this.panel3.Controls.Add(this.cboNguyenlieu);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.btnLuuChitiet);
            this.panel3.Controls.Add(this.btnXoaChitiet);
            this.panel3.Controls.Add(this.txtSoluongdung);
            this.panel3.Controls.Add(this.btnSuaChitiet);
            this.panel3.Controls.Add(this.btnThemChitiet);
            this.panel3.Controls.Add(this.dataGridViewChiTietSP);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(21, 398);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(759, 250);
            this.panel3.TabIndex = 21;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // cboMaSPChitiet
            // 
            this.cboMaSPChitiet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaSPChitiet.FormattingEnabled = true;
            this.cboMaSPChitiet.Location = new System.Drawing.Point(420, 53);
            this.cboMaSPChitiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMaSPChitiet.Name = "cboMaSPChitiet";
            this.cboMaSPChitiet.Size = new System.Drawing.Size(200, 24);
            this.cboMaSPChitiet.TabIndex = 24;
            // 
            // cboNguyenlieu
            // 
            this.cboNguyenlieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguyenlieu.FormattingEnabled = true;
            this.cboNguyenlieu.Location = new System.Drawing.Point(420, 113);
            this.cboNguyenlieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboNguyenlieu.Name = "cboNguyenlieu";
            this.cboNguyenlieu.Size = new System.Drawing.Size(200, 24);
            this.cboNguyenlieu.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(417, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Tên sản phẩm";
            // 
            // btnLuuChitiet
            // 
            this.btnLuuChitiet.BackColor = System.Drawing.Color.ForestGreen;
            this.btnLuuChitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuChitiet.ForeColor = System.Drawing.Color.White;
            this.btnLuuChitiet.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnLuuChitiet.IconColor = System.Drawing.Color.White;
            this.btnLuuChitiet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLuuChitiet.IconSize = 30;
            this.btnLuuChitiet.Location = new System.Drawing.Point(627, 192);
            this.btnLuuChitiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuuChitiet.Name = "btnLuuChitiet";
            this.btnLuuChitiet.Size = new System.Drawing.Size(117, 47);
            this.btnLuuChitiet.TabIndex = 13;
            this.btnLuuChitiet.Text = "Lưu";
            this.btnLuuChitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuChitiet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuChitiet.UseVisualStyleBackColor = false;
            this.btnLuuChitiet.Click += new System.EventHandler(this.btnLuuChitiet_Click);
            // 
            // btnXoaChitiet
            // 
            this.btnXoaChitiet.BackColor = System.Drawing.Color.ForestGreen;
            this.btnXoaChitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaChitiet.ForeColor = System.Drawing.Color.White;
            this.btnXoaChitiet.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnXoaChitiet.IconColor = System.Drawing.Color.White;
            this.btnXoaChitiet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXoaChitiet.IconSize = 30;
            this.btnXoaChitiet.Location = new System.Drawing.Point(627, 134);
            this.btnXoaChitiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaChitiet.Name = "btnXoaChitiet";
            this.btnXoaChitiet.Size = new System.Drawing.Size(117, 47);
            this.btnXoaChitiet.TabIndex = 15;
            this.btnXoaChitiet.Text = "Xóa";
            this.btnXoaChitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaChitiet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaChitiet.UseVisualStyleBackColor = false;
            this.btnXoaChitiet.Click += new System.EventHandler(this.btnXoaChitiet_Click);
            // 
            // btnSuaChitiet
            // 
            this.btnSuaChitiet.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSuaChitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaChitiet.ForeColor = System.Drawing.Color.White;
            this.btnSuaChitiet.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnSuaChitiet.IconColor = System.Drawing.Color.White;
            this.btnSuaChitiet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSuaChitiet.IconSize = 30;
            this.btnSuaChitiet.Location = new System.Drawing.Point(627, 76);
            this.btnSuaChitiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaChitiet.Name = "btnSuaChitiet";
            this.btnSuaChitiet.Size = new System.Drawing.Size(117, 47);
            this.btnSuaChitiet.TabIndex = 14;
            this.btnSuaChitiet.Text = "Sửa";
            this.btnSuaChitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaChitiet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuaChitiet.UseVisualStyleBackColor = false;
            this.btnSuaChitiet.Click += new System.EventHandler(this.btnSuaChitiet_Click);
            // 
            // btnThemChitiet
            // 
            this.btnThemChitiet.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThemChitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemChitiet.ForeColor = System.Drawing.Color.White;
            this.btnThemChitiet.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnThemChitiet.IconColor = System.Drawing.Color.White;
            this.btnThemChitiet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThemChitiet.IconSize = 30;
            this.btnThemChitiet.Location = new System.Drawing.Point(627, 17);
            this.btnThemChitiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemChitiet.Name = "btnThemChitiet";
            this.btnThemChitiet.Size = new System.Drawing.Size(117, 47);
            this.btnThemChitiet.TabIndex = 13;
            this.btnThemChitiet.Text = "Thêm";
            this.btnThemChitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemChitiet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemChitiet.UseVisualStyleBackColor = false;
            this.btnThemChitiet.Click += new System.EventHandler(this.btnThemChitiet_Click);
            // 
            // frmSanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1193, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSanpham";
            this.Text = "frmSanpham";
            this.Load += new System.EventHandler(this.frmSanpham_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQLyCaPhe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChiTietSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewQLyCaPhe;
        private FontAwesome.Sharp.IconButton btnThem;
        private FontAwesome.Sharp.IconButton btnXoa;
        private FontAwesome.Sharp.IconButton btnSua;
        private FontAwesome.Sharp.IconButton btnBoqua;
        private FontAwesome.Sharp.IconButton btnLuu;
        private System.Windows.Forms.DataGridView dataGridViewChiTietSP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSoluongdung;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMasanpham;
        private System.Windows.Forms.TextBox txtTensanpham;
        private System.Windows.Forms.TextBox txtGianhap;
        private System.Windows.Forms.TextBox txtGiaban;
        private System.Windows.Forms.ComboBox cboDanhmuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.TextBox txtAnh;
        private FontAwesome.Sharp.IconButton btnOpen;
        private FontAwesome.Sharp.IconButton btnTim;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btnLuuChitiet;
        private FontAwesome.Sharp.IconButton btnXoaChitiet;
        private FontAwesome.Sharp.IconButton btnSuaChitiet;
        private FontAwesome.Sharp.IconButton btnThemChitiet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboNguyenlieu;
        private System.Windows.Forms.ComboBox cboMaSPChitiet;
    }
}