namespace QuanLyCuaHangMayTinh
{
    partial class frmPOS
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnThanhVien = new System.Windows.Forms.Button();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.btnHuyDon = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.cboThuongHieu = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel3.Location = new System.Drawing.Point(-2, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1345, 19);
            this.panel3.TabIndex = 13;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1345, 20);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin đơn hàng :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 28);
            this.label11.TabIndex = 15;
            this.label11.Text = "Tên Khách hàng :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 28);
            this.label12.TabIndex = 16;
            this.label12.Text = "Số điện thoại :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboThuongHieu);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblSoLuong);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(15, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(658, 194);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(188, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 36);
            this.comboBox1.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(146, 28);
            this.label15.TabIndex = 19;
            this.label15.Text = "Loại sản phẩm :";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(442, 138);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(101, 28);
            this.lblSoLuong.TabIndex = 14;
            this.lblSoLuong.Text = "Số lượng :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(208, 28);
            this.label13.TabIndex = 17;
            this.label13.Text = "TÌM KIẾM SẢN PHẨM";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(188, 64);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(195, 34);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.Text = "Tìm kiếm..";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(170, 28);
            this.label14.TabIndex = 18;
            this.label14.Text = "Nhập tên/ Mã SP :";
            // 
            // dgvCart
            // 
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.SoLuong,
            this.Column,
            this.Colum,
            this.colDelete});
            this.dgvCart.Location = new System.Drawing.Point(678, 76);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 24;
            this.dgvCart.Size = new System.Drawing.Size(664, 304);
            this.dgvCart.TabIndex = 1;
            // 
            // MaSP
            // 
            this.MaSP.HeaderText = "MaSP";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.Visible = false;
            this.MaSP.Width = 125;
            // 
            // TenSP
            // 
            this.TenSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 125;
            // 
            // Column
            // 
            this.Column.HeaderText = "Đơn giá";
            this.Column.MinimumWidth = 6;
            this.Column.Name = "Column";
            this.Column.Width = 125;
            // 
            // Colum
            // 
            this.Colum.HeaderText = "Thành tiền";
            this.Colum.MinimumWidth = 6;
            this.Colum.Name = "Colum";
            this.Colum.ReadOnly = true;
            this.Colum.Width = 125;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.MinimumWidth = 6;
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "X";
            this.colDelete.Width = 125;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(679, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(666, 38);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 28);
            this.label16.TabIndex = 15;
            this.label16.Text = "GIỎ HÀNG ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(713, 392);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 28);
            this.label17.TabIndex = 22;
            this.label17.Text = "SDT :";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(884, 389);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(189, 34);
            this.txtTenKH.TabIndex = 12;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(884, 439);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(189, 34);
            this.txtSDT.TabIndex = 11;
            // 
            // btnThanhVien
            // 
            this.btnThanhVien.Location = new System.Drawing.Point(1137, 532);
            this.btnThanhVien.Name = "btnThanhVien";
            this.btnThanhVien.Size = new System.Drawing.Size(194, 42);
            this.btnThanhVien.TabIndex = 10;
            this.btnThanhVien.Text = "Thêm khách hàng";
            this.btnThanhVien.UseVisualStyleBackColor = true;
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(884, 491);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(189, 34);
            this.txtGiamGia.TabIndex = 4;
            this.txtGiamGia.Text = "%";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnThanhToan.ForeColor = System.Drawing.SystemColors.Control;
            this.btnThanhToan.Location = new System.Drawing.Point(1147, 593);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(184, 44);
            this.btnThanhToan.TabIndex = 8;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(713, 445);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(155, 28);
            this.label18.TabIndex = 23;
            this.label18.Text = "Tên khách hàng :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(713, 497);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 28);
            this.label19.TabIndex = 24;
            this.label19.Text = "Chiết  khấu :";
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(713, 546);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(104, 28);
            this.label200.TabIndex = 25;
            this.label200.Text = "Tổng tiền :";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(879, 546);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(65, 28);
            this.lblTongTien.TabIndex = 26;
            this.lblTongTien.Text = "0 Vnd";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(994, 593);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(127, 44);
            this.btnLamMoi.TabIndex = 27;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(12, 244);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(661, 404);
            this.dgvSanPham.TabIndex = 0;
            // 
            // btnHuyDon
            // 
            this.btnHuyDon.Location = new System.Drawing.Point(868, 593);
            this.btnHuyDon.Name = "btnHuyDon";
            this.btnHuyDon.Size = new System.Drawing.Size(109, 44);
            this.btnHuyDon.TabIndex = 28;
            this.btnHuyDon.Text = "Hủy đơn";
            this.btnHuyDon.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnHuyDon);
            this.panel4.Controls.Add(this.dgvSanPham);
            this.panel4.Controls.Add(this.btnLamMoi);
            this.panel4.Controls.Add(this.lblTongTien);
            this.panel4.Controls.Add(this.label200);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.btnThanhToan);
            this.panel4.Controls.Add(this.txtGiamGia);
            this.panel4.Controls.Add(this.btnThanhVien);
            this.panel4.Controls.Add(this.txtSDT);
            this.panel4.Controls.Add(this.txtTenKH);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.dgvCart);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1345, 660);
            this.panel4.TabIndex = 18;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(24, 161);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(131, 28);
            this.label20.TabIndex = 19;
            this.label20.Text = "Thương hiệu :";
            // 
            // cboThuongHieu
            // 
            this.cboThuongHieu.FormattingEnabled = true;
            this.cboThuongHieu.Location = new System.Drawing.Point(188, 158);
            this.cboThuongHieu.Name = "cboThuongHieu";
            this.cboThuongHieu.Size = new System.Drawing.Size(195, 36);
            this.cboThuongHieu.TabIndex = 20;
            // 
            // frmPOS
            // 
            this.ClientSize = new System.Drawing.Size(1345, 660);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPOS";
            this.Text = "frmPOS";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grBan;
        private System.Windows.Forms.GroupBox grChitietban;
        private System.Windows.Forms.ComboBox cbThanhvien;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private System.Windows.Forms.ComboBox cbHinhthuc;
        private System.Windows.Forms.TextBox txtKhachhang;
        private System.Windows.Forms.Label label1;
     
        private FontAwesome.Sharp.IconButton btnThoat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dGridChitietban;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbThucuong;
        private System.Windows.Forms.ComboBox cbDanhmuc;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnThemmon;
        private FontAwesome.Sharp.IconButton btnXoamon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGhichu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label lbThonbaogiamgia;
        private FontAwesome.Sharp.IconButton btnGiamgia;
        private System.Windows.Forms.TextBox txtMagiamgia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        
        private FontAwesome.Sharp.IconButton btnGopban;
        private FontAwesome.Sharp.IconButton btnChuyenban;
        private System.Windows.Forms.ComboBox cbGopban;
        private System.Windows.Forms.ComboBox cbChuyenban;
        private FontAwesome.Sharp.IconButton btnBoqua;
        private System.Windows.Forms.TextBox txtSodienthoai;

        private FontAwesome.Sharp.IconButton btnSuamon;
        private FontAwesome.Sharp.IconButton btnAdd;
        
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnThanhVien;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Button btnHuyDon;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboThuongHieu;
        private System.Windows.Forms.Label label20;
    }
}