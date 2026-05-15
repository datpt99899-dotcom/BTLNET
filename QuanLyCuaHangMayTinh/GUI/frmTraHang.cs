using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public class frmTraHang : Form
    {
        // Khai báo các control
        private GroupBox groupBox1, groupBox2, groupBox3, groupBox4;
        private TextBox txtMaPhieuTra, txtTenKhachHang, txtTenNhanVien, txtMaHoaDonGoc, txtTongTienTra, txtGhiChu;
        private DateTimePicker dtpNgayTra;
        private ComboBox cboMaNhanVien, cboMaKhachHang, cboHinhThucHoan;
        private Button btnTimHoaDon, btnLuu, btnHuy, btnIn, btnDong;
        private DataGridView dgvSanPhamTra;
        private Label label1, label2, label3, label4, label5, label6, label7, label8, label9, label10;

        // DataTable lưu danh sách sản phẩm trả
        private DataTable dtSanPhamTra;
        private string maHoaDonGoc = "";

  

        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn SoLuongDaMua;
        private DataGridViewTextBoxColumn SoLuongTra;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn ThanhTienTra;
        private DataGridViewTextBoxColumn LyDo;
        private Label label11;
        private Button btnLamMoi;
        private bool isLoaded = false;

        public frmTraHang()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaPhieuTra = new System.Windows.Forms.TextBox();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.cboMaNhanVien = new System.Windows.Forms.ComboBox();
            this.cboMaKhachHang = new System.Windows.Forms.ComboBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimHoaDon = new System.Windows.Forms.Button();
            this.txtMaHoaDonGoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSanPhamTra = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongDaMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTienTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTongTienTra = new System.Windows.Forms.TextBox();
            this.cboHinhThucHoan = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamTra)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Controls.Add(this.txtMaPhieuTra);
            this.groupBox1.Controls.Add(this.dtpNgayTra);
            this.groupBox1.Controls.Add(this.cboMaNhanVien);
            this.groupBox1.Controls.Add(this.cboMaKhachHang);
            this.groupBox1.Controls.Add(this.txtTenKhachHang);
            this.groupBox1.Controls.Add(this.txtTenNhanVien);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1081, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN PHIẾU TRẢ HÀNG ";
            // 
            // txtMaPhieuTra
            // 
            this.txtMaPhieuTra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuTra.Location = new System.Drawing.Point(195, 42);
            this.txtMaPhieuTra.Name = "txtMaPhieuTra";
            this.txtMaPhieuTra.ReadOnly = true;
            this.txtMaPhieuTra.Size = new System.Drawing.Size(219, 34);
            this.txtMaPhieuTra.TabIndex = 0;
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayTra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTra.Location = new System.Drawing.Point(721, 42);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(219, 34);
            this.dtpNgayTra.TabIndex = 1;
            // 
            // cboMaNhanVien
            // 
            this.cboMaNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNhanVien.Location = new System.Drawing.Point(195, 85);
            this.cboMaNhanVien.Name = "cboMaNhanVien";
            this.cboMaNhanVien.Size = new System.Drawing.Size(219, 36);
            this.cboMaNhanVien.TabIndex = 2;
            this.cboMaNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboMaNhanVien_SelectedIndexChanged);
            // 
            // cboMaKhachHang
            // 
            this.cboMaKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaKhachHang.Location = new System.Drawing.Point(721, 84);
            this.cboMaKhachHang.Name = "cboMaKhachHang";
            this.cboMaKhachHang.Size = new System.Drawing.Size(219, 36);
            this.cboMaKhachHang.TabIndex = 3;
            this.cboMaKhachHang.SelectedIndexChanged += new System.EventHandler(this.cboTenNhanVien_SelectedIndexChanged);
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhachHang.Location = new System.Drawing.Point(721, 129);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.ReadOnly = true;
            this.txtTenKhachHang.Size = new System.Drawing.Size(219, 34);
            this.txtTenKhachHang.TabIndex = 4;
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNhanVien.Location = new System.Drawing.Point(195, 132);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.ReadOnly = true;
            this.txtTenNhanVien.Size = new System.Drawing.Size(219, 34);
            this.txtTenNhanVien.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã phiếu trả:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(548, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 36);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mã khách hàng:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(31, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mã nhân viên:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(548, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 34);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ngày trả:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(548, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 37);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tên khách hàng:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(31, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tên nhân viên:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Controls.Add(this.btnTimHoaDon);
            this.groupBox2.Controls.Add(this.txtMaHoaDonGoc);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1081, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn gốc";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(839, 20);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(161, 43);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới ";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnTimHoaDon_Click);
            // 
            // btnTimHoaDon
            // 
            this.btnTimHoaDon.BackColor = System.Drawing.Color.LightBlue;
            this.btnTimHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimHoaDon.Location = new System.Drawing.Point(657, 20);
            this.btnTimHoaDon.Name = "btnTimHoaDon";
            this.btnTimHoaDon.Size = new System.Drawing.Size(161, 43);
            this.btnTimHoaDon.TabIndex = 0;
            this.btnTimHoaDon.Text = "Tìm kiếm";
            this.btnTimHoaDon.UseVisualStyleBackColor = false;
            this.btnTimHoaDon.Click += new System.EventHandler(this.btnTimHoaDon_Click);
            // 
            // txtMaHoaDonGoc
            // 
            this.txtMaHoaDonGoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHoaDonGoc.Location = new System.Drawing.Point(195, 27);
            this.txtMaHoaDonGoc.Name = "txtMaHoaDonGoc";
            this.txtMaHoaDonGoc.Size = new System.Drawing.Size(219, 34);
            this.txtMaHoaDonGoc.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 31);
            this.label7.TabIndex = 2;
            this.label7.Text = "Mã hóa đơn:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvSanPhamTra);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 373);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1081, 250);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách sản phẩm trả (chỉnh sửa cột Số lượng trả và Lý do)";
            // 
            // dgvSanPhamTra
            // 
            this.dgvSanPhamTra.AllowUserToAddRows = false;
            this.dgvSanPhamTra.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSanPhamTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPhamTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.SoLuongDaMua,
            this.SoLuongTra,
            this.DonGia,
            this.ThanhTienTra,
            this.LyDo});
            this.dgvSanPhamTra.Location = new System.Drawing.Point(84, 40);
            this.dgvSanPhamTra.Name = "dgvSanPhamTra";
            this.dgvSanPhamTra.RowHeadersWidth = 51;
            this.dgvSanPhamTra.Size = new System.Drawing.Size(886, 215);
            this.dgvSanPhamTra.TabIndex = 0;
            this.dgvSanPhamTra.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPhamTra_CellValueChanged);
            // 
            // MaSP
            // 
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            this.MaSP.Width = 80;
            // 
            // TenSP
            // 
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            this.TenSP.Width = 200;
            // 
            // SoLuongDaMua
            // 
            this.SoLuongDaMua.HeaderText = "SL đã mua";
            this.SoLuongDaMua.MinimumWidth = 6;
            this.SoLuongDaMua.Name = "SoLuongDaMua";
            this.SoLuongDaMua.ReadOnly = true;
            this.SoLuongDaMua.Width = 80;
            // 
            // SoLuongTra
            // 
            this.SoLuongTra.HeaderText = "SL trả";
            this.SoLuongTra.MinimumWidth = 6;
            this.SoLuongTra.Name = "SoLuongTra";
            this.SoLuongTra.Width = 80;
            // 
            // DonGia
            // 
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.MinimumWidth = 6;
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            this.DonGia.Width = 125;
            // 
            // ThanhTienTra
            // 
            this.ThanhTienTra.HeaderText = "Thành tiền trả";
            this.ThanhTienTra.MinimumWidth = 6;
            this.ThanhTienTra.Name = "ThanhTienTra";
            this.ThanhTienTra.ReadOnly = true;
            this.ThanhTienTra.Width = 120;
            // 
            // LyDo
            // 
            this.LyDo.HeaderText = "Lý do trả";
            this.LyDo.MinimumWidth = 6;
            this.LyDo.Name = "LyDo";
            this.LyDo.Width = 150;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox4.Controls.Add(this.txtTongTienTra);
            this.groupBox4.Controls.Add(this.cboHinhThucHoan);
            this.groupBox4.Controls.Add(this.txtGhiChu);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(12, 646);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1081, 115);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tổng kết";
            // 
            // txtTongTienTra
            // 
            this.txtTongTienTra.Location = new System.Drawing.Point(195, 22);
            this.txtTongTienTra.Name = "txtTongTienTra";
            this.txtTongTienTra.ReadOnly = true;
            this.txtTongTienTra.Size = new System.Drawing.Size(219, 34);
            this.txtTongTienTra.TabIndex = 0;
            // 
            // cboHinhThucHoan
            // 
            this.cboHinhThucHoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHinhThucHoan.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản"});
            this.cboHinhThucHoan.Location = new System.Drawing.Point(195, 62);
            this.cboHinhThucHoan.Name = "cboHinhThucHoan";
            this.cboHinhThucHoan.Size = new System.Drawing.Size(219, 36);
            this.cboHinhThucHoan.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(630, 25);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(400, 60);
            this.txtGhiChu.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 31);
            this.label8.TabIndex = 3;
            this.label8.Text = "Tổng tiền trả:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(226, 32);
            this.label9.TabIndex = 4;
            this.label9.Text = "Hình thức hoàn:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(524, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ghi chú:";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.SlateBlue;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLuu.Location = new System.Drawing.Point(96, 778);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(162, 50);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu phiếu trả";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Tomato;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHuy.Location = new System.Drawing.Point(282, 778);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(101, 50);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnIn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIn.Location = new System.Drawing.Point(416, 778);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(143, 50);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "In phiếu trả";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.DarkGray;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDong.Location = new System.Drawing.Point(918, 778);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(124, 50);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.MediumBlue;
            this.label11.Location = new System.Drawing.Point(391, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(301, 45);
            this.label11.TabIndex = 56;
            this.label11.Text = "PHIẾU TRẢ HÀNG ";
            // 
            // frmTraHang
            // 
            this.ClientSize = new System.Drawing.Size(1105, 849);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTraHang";
            this.Text = "Phiếu trả hàng";
            this.Load += new System.EventHandler(this.frmTraHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamTra)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void frmTraHang_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            dtpNgayTra.Value = DateTime.Now;
            LoadNhanVien();
            TaoMaPhieuTuDong();
            cboHinhThucHoan.SelectedIndex = 0;
        }

        private void LoadNhanVien()
        {
            DataTable dt = Function.GetDataToTable("SELECT MaNhanVien, HoTen FROM NhanVien WHERE TrangThai = 1");
            cboMaNhanVien.DataSource = dt;
            cboMaNhanVien.DisplayMember = "MaNhanVien";
            cboMaNhanVien.ValueMember = "MaNhanVien";

            cboMaKhachHang.DataSource = dt.Copy();
            cboMaKhachHang.DisplayMember = "HoTen";
            cboMaKhachHang.ValueMember = "MaNhanVien";
        }

        private void TaoMaPhieuTuDong()
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            string sql = "SELECT TOP 1 MaPhieuTra FROM PhieuTraHang WHERE MaPhieuTra LIKE @prefix ORDER BY MaPhieuTra DESC";
            SqlParameter p = new SqlParameter("@prefix", "PT" + today + "%");
            DataTable dt = Function.GetDataToTable(sql, p);
            int stt = 1;
            if (dt.Rows.Count > 0)
            {
                string last = dt.Rows[0][0].ToString();
                if (last.Length >= 13 && int.TryParse(last.Substring(11), out int lastNum))
                    stt = lastNum + 1;
            }
            txtMaPhieuTra.Text = "PT" + today + stt.ToString("D3");
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhanVien.SelectedValue != null)
                cboMaKhachHang.SelectedValue = cboMaNhanVien.SelectedValue;
        }

        private void cboTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKhachHang.SelectedValue != null)
                cboMaNhanVien.SelectedValue = cboMaKhachHang.SelectedValue;
        }

        private void btnTimHoaDon_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHoaDonGoc.Text.Trim();
            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn cần trả hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtHD = Function.GetDataToTable(
                "SELECT h.MaKhachHang, kh.TenKhachHang, h.NgayBan, h.TongTien " +
                "FROM HoaDonBan h INNER JOIN KhachHang kh ON h.MaKhachHang = kh.MaKhachHang " +
                "WHERE h.MaHoaDonBan = @ma", new SqlParameter("@ma", maHD));
            if (dtHD.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            maHoaDonGoc = maHD;
            DataRow r = dtHD.Rows[0];
            txtTenKhachHang.Text = r["MaKhachHang"].ToString();
            txtTenNhanVien.Text = r["TenKhachHang"].ToString();

            DataTable dtCT = Function.GetDataToTable(
                @"SELECT ct.MaSanPham, sp.TenSanPham, ct.SoLuong, ct.DonGia 
                  FROM ChiTietHoaDonBan ct 
                  INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham 
                  WHERE ct.MaHoaDonBan = @maHD", new SqlParameter("@maHD", maHD));

            dtSanPhamTra = new DataTable();
            dtSanPhamTra.Columns.Add("MaSP", typeof(string));
            dtSanPhamTra.Columns.Add("TenSP", typeof(string));
            dtSanPhamTra.Columns.Add("SoLuongDaMua", typeof(int));
            dtSanPhamTra.Columns.Add("SoLuongTra", typeof(int));
            dtSanPhamTra.Columns.Add("DonGia", typeof(decimal));
            dtSanPhamTra.Columns.Add("ThanhTienTra", typeof(decimal));
            dtSanPhamTra.Columns.Add("LyDo", typeof(string));

            foreach (DataRow row in dtCT.Rows)
            {
                dtSanPhamTra.Rows.Add(
                    row["MaSanPham"],
                    row["TenSanPham"],
                    row["SoLuong"],
                    0,
                    row["DonGia"],
                    0,
                    "");
            }
            dgvSanPhamTra.DataSource = dtSanPhamTra;
            isLoaded = true;
            TinhTongTienTra();
        }

        private void dgvSanPhamTra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isLoaded) return;
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvSanPhamTra.Columns["SoLuongTra"].Index)
            {
                int daMua = Convert.ToInt32(dgvSanPhamTra.Rows[e.RowIndex].Cells["SoLuongDaMua"].Value);
                int tra = 0;
                if (!int.TryParse(dgvSanPhamTra.Rows[e.RowIndex].Cells["SoLuongTra"].Value?.ToString(), out tra))
                    tra = 0;
                if (tra > daMua)
                {
                    MessageBox.Show($"Số lượng trả không thể vượt quá số lượng đã mua ({daMua})!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvSanPhamTra.Rows[e.RowIndex].Cells["SoLuongTra"].Value = daMua;
                    tra = daMua;
                }
                if (tra < 0) tra = 0;
                decimal donGia = Convert.ToDecimal(dgvSanPhamTra.Rows[e.RowIndex].Cells["DonGia"].Value);
                decimal thanhTien = tra * donGia;
                dgvSanPhamTra.Rows[e.RowIndex].Cells["ThanhTienTra"].Value = thanhTien;
                TinhTongTienTra();
            }
        }

        private void TinhTongTienTra()
        {
            decimal tong = 0;
            if (dtSanPhamTra != null)
            {
                foreach (DataRow row in dtSanPhamTra.Rows)
                {
                    if (row.RowState != DataRowState.Deleted && row["ThanhTienTra"] != DBNull.Value)
                        tong += Convert.ToDecimal(row["ThanhTienTra"]);
                }
            }
            txtTongTienTra.Text = tong.ToString("N0") + " đ";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool coTra = false;
            foreach (DataRow row in dtSanPhamTra.Rows)
            {
                if (Convert.ToInt32(row["SoLuongTra"]) > 0) { coTra = true; break; }
            }
            if (!coTra)
            {
                MessageBox.Show("Chưa chọn sản phẩm trả hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMaNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Chọn nhân viên xử lý trả hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Function.GetSqlConnection())
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        // Schema mới: PhieuTraHang(MaPhieuTra, NgayTra, MaHoaDonBan, MaNhanVien, TongTien, LyDo)
                        string lyDoChung = (cboHinhThucHoan.SelectedItem?.ToString() ?? "") + " - " + (txtGhiChu.Text ?? "");
                        string sqlPhieu = @"INSERT INTO PhieuTraHang (MaPhieuTra, NgayTra, MaHoaDonBan, MaNhanVien, TongTien, LyDo)
                                            VALUES (@ma, @ngay, @mahd, @manv, @tong, @lydo)";
                        SqlCommand cmd = new SqlCommand(sqlPhieu, conn, trans);
                        cmd.Parameters.AddWithValue("@ma", txtMaPhieuTra.Text);
                        cmd.Parameters.AddWithValue("@ngay", dtpNgayTra.Value);
                        cmd.Parameters.AddWithValue("@mahd", maHoaDonGoc);
                        cmd.Parameters.AddWithValue("@manv", cboMaNhanVien.SelectedValue?.ToString() ?? StaticData.MaNV);
                        cmd.Parameters.AddWithValue("@tong", decimal.Parse(txtTongTienTra.Text.Replace(" đ", "").Replace(",", "").Replace(".", "")));
                        cmd.Parameters.AddWithValue("@lydo", string.IsNullOrEmpty(lyDoChung.Trim(' ', '-')) ? "Khách trả" : lyDoChung);
                        cmd.ExecuteNonQuery();

                        // Schema mới: ChiTietPhieuTraHang(MaPhieuTra, MaSanPham, SoLuongTra, DonGia, TinhTrangSP)
                        // Trigger trg_TraHang_TangTon TỰ cộng tồn kho cho SP "Nguyên vẹn" -> KHÔNG cần update thủ công
                        string sqlCT = @"INSERT INTO ChiTietPhieuTraHang (MaPhieuTra, MaSanPham, SoLuongTra, DonGia, TinhTrangSP)
                                         VALUES (@mapt, @masp, @sl, @dongia, @tinhtrang)";
                        foreach (DataRow row in dtSanPhamTra.Rows)
                        {
                            int slTra = Convert.ToInt32(row["SoLuongTra"]);
                            if (slTra == 0) continue;
                            string maSP = row["MaSP"].ToString();
                            decimal donGia = Convert.ToDecimal(row["DonGia"]);
                            string lyDo = row["LyDo"]?.ToString() ?? "";

                            SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                            cmdCT.Parameters.AddWithValue("@mapt", txtMaPhieuTra.Text);
                            cmdCT.Parameters.AddWithValue("@masp", maSP);
                            cmdCT.Parameters.AddWithValue("@sl", slTra);
                            cmdCT.Parameters.AddWithValue("@dongia", donGia);
                            cmdCT.Parameters.AddWithValue("@tinhtrang", string.IsNullOrEmpty(lyDo) ? "Nguyên vẹn" : "Nguyên vẹn");
                            cmdCT.ExecuteNonQuery();
                            // Trigger DB sẽ tự cộng tồn kho cho SP "Nguyên vẹn"
                        }
                        trans.Commit();
                        MessageBox.Show("Lưu phiếu trả hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối CSDL lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy phiếu trả hàng hiện tại?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtMaHoaDonGoc.Text = "";
            txtTenKhachHang.Text = "";
            txtTenNhanVien.Text = "";
            txtGhiChu.Text = "";
            cboHinhThucHoan.SelectedIndex = 0;
            dtSanPhamTra?.Clear();
            TaoMaPhieuTuDong();
            dtpNgayTra.Value = DateTime.Now;
            txtTongTienTra.Text = "0 đ";
            maHoaDonGoc = "";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieuTra.Text) || dtSanPhamTra == null || dtSanPhamTra.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("================== PHIẾU TRẢ HÀNG ==================");
            sb.AppendLine($"Mã phiếu trả: {txtMaPhieuTra.Text}");
            sb.AppendLine($"Ngày trả: {dtpNgayTra.Value:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Nhân viên: {cboMaKhachHang.Text}");
            sb.AppendLine($"Khách hàng: {txtTenNhanVien.Text} - {txtTenKhachHang.Text}");
            sb.AppendLine($"Hóa đơn gốc: {maHoaDonGoc}");
            sb.AppendLine("------------------------------------------------------");
            sb.AppendLine($"{"Mã SP",-8} {"Tên sản phẩm",-25} {"SL trả",-6} {"Đơn giá",-12} {"Thành tiền",-12}");
            foreach (DataRow row in dtSanPhamTra.Rows)
            {
                int sl = Convert.ToInt32(row["SoLuongTra"]);
                if (sl == 0) continue;
                sb.AppendLine($"{row["MaSP"],-8} {row["TenSP"],-25} {sl,-6} {Convert.ToDecimal(row["DonGia"]).ToString("N0"),-12} {Convert.ToDecimal(row["ThanhTienTra"]).ToString("N0"),-12}");
            }
            sb.AppendLine($"Tổng tiền trả: {txtTongTienTra.Text}");
            sb.AppendLine($"Hình thức hoàn: {cboHinhThucHoan.Text}");
            sb.AppendLine($"Ghi chú: {txtGhiChu.Text}");
            sb.AppendLine("======================================================");
            MessageBox.Show(sb.ToString(), "In phiếu trả hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}