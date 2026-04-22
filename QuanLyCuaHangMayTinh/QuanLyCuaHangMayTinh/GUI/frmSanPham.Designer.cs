using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    partial class frmSanPham
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private GroupBox grpThongTin;
        private Label lblMaSanPham;
        private Label lblTenSanPham;
        private Label lblLoaiSanPham;
        private Label lblThuongHieu;
        private Label lblNhaCungCap;
        private Label lblGiaNhap;
        private Label lblGiaBan;
        private Label lblSoLuongTon;
        private Label lblBaoHanh;
        private Label lblMoTa;
        private Label lblHinhAnh;
        private TextBox txtMaSanPham;
        private TextBox txtTenSanPham;
        private ComboBox cboLoaiSanPham;
        private ComboBox cboThuongHieu;
        private ComboBox cboNhaCungCap;
        private TextBox txtGiaNhap;
        private TextBox txtGiaBan;
        private TextBox txtSoLuongTon;
        private TextBox txtBaoHanhThang;
        private RichTextBox rtbMoTa;
        private PictureBox picHinhAnh;
        private Button btnChonAnh;
        private Label lblDuongDanAnh;
        private GroupBox grpTimKiem;
        private Label lblTuKhoa;
        private Label lblLocLoai;
        private Label lblLocThuongHieu;
        private TextBox txtTuKhoa;
        private ComboBox cboLocLoai;
        private ComboBox cboLocThuongHieu;
        private Button btnTimKiem;
        private Button btnLoc;
        private Button btnBoLoc;
        private GroupBox grpChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuy;
        private Button btnLamMoi;
        private GroupBox grpDanhSach;
        private DataGridView dgvSanPham;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaSanPham = new System.Windows.Forms.Label();
            this.lblTenSanPham = new System.Windows.Forms.Label();
            this.lblLoaiSanPham = new System.Windows.Forms.Label();
            this.lblThuongHieu = new System.Windows.Forms.Label();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.lblGiaNhap = new System.Windows.Forms.Label();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.lblBaoHanh = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblHinhAnh = new System.Windows.Forms.Label();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.cboLoaiSanPham = new System.Windows.Forms.ComboBox();
            this.cboThuongHieu = new System.Windows.Forms.ComboBox();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.txtBaoHanhThang = new System.Windows.Forms.TextBox();
            this.rtbMoTa = new System.Windows.Forms.RichTextBox();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.lblDuongDanAnh = new System.Windows.Forms.Label();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.lblLocLoai = new System.Windows.Forms.Label();
            this.lblLocThuongHieu = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.cboLocLoai = new System.Windows.Forms.ComboBox();
            this.cboLocThuongHieu = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            this.grpTimKiem.SuspendLayout();
            this.grpChucNang.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(78)))), ((int)(((byte)(125)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1384, 82);
            this.pnlHeader.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(22, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(540, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ / TRA CỨU SẢN PHẨM";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblMaSanPham);
            this.grpThongTin.Controls.Add(this.lblTenSanPham);
            this.grpThongTin.Controls.Add(this.lblLoaiSanPham);
            this.grpThongTin.Controls.Add(this.lblThuongHieu);
            this.grpThongTin.Controls.Add(this.lblNhaCungCap);
            this.grpThongTin.Controls.Add(this.lblGiaNhap);
            this.grpThongTin.Controls.Add(this.lblGiaBan);
            this.grpThongTin.Controls.Add(this.lblSoLuongTon);
            this.grpThongTin.Controls.Add(this.lblBaoHanh);
            this.grpThongTin.Controls.Add(this.lblMoTa);
            this.grpThongTin.Controls.Add(this.lblHinhAnh);
            this.grpThongTin.Controls.Add(this.txtMaSanPham);
            this.grpThongTin.Controls.Add(this.txtTenSanPham);
            this.grpThongTin.Controls.Add(this.cboLoaiSanPham);
            this.grpThongTin.Controls.Add(this.cboThuongHieu);
            this.grpThongTin.Controls.Add(this.cboNhaCungCap);
            this.grpThongTin.Controls.Add(this.txtGiaNhap);
            this.grpThongTin.Controls.Add(this.txtGiaBan);
            this.grpThongTin.Controls.Add(this.txtSoLuongTon);
            this.grpThongTin.Controls.Add(this.txtBaoHanhThang);
            this.grpThongTin.Controls.Add(this.rtbMoTa);
            this.grpThongTin.Controls.Add(this.picHinhAnh);
            this.grpThongTin.Controls.Add(this.btnChonAnh);
            this.grpThongTin.Controls.Add(this.lblDuongDanAnh);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Location = new System.Drawing.Point(24, 101);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(468, 558);
            this.grpThongTin.TabIndex = 5;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin sản phẩm";
            // 
            // lblMaSanPham
            // 
            this.lblMaSanPham.AutoSize = true;
            this.lblMaSanPham.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaSanPham.Location = new System.Drawing.Point(20, 35);
            this.lblMaSanPham.Name = "lblMaSanPham";
            this.lblMaSanPham.Size = new System.Drawing.Size(129, 28);
            this.lblMaSanPham.TabIndex = 0;
            this.lblMaSanPham.Text = "Mã sản phẩm";
            // 
            // lblTenSanPham
            // 
            this.lblTenSanPham.AutoSize = true;
            this.lblTenSanPham.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenSanPham.Location = new System.Drawing.Point(20, 72);
            this.lblTenSanPham.Name = "lblTenSanPham";
            this.lblTenSanPham.Size = new System.Drawing.Size(130, 28);
            this.lblTenSanPham.TabIndex = 1;
            this.lblTenSanPham.Text = "Tên sản phẩm";
            // 
            // lblLoaiSanPham
            // 
            this.lblLoaiSanPham.AutoSize = true;
            this.lblLoaiSanPham.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoaiSanPham.Location = new System.Drawing.Point(20, 109);
            this.lblLoaiSanPham.Name = "lblLoaiSanPham";
            this.lblLoaiSanPham.Size = new System.Drawing.Size(137, 28);
            this.lblLoaiSanPham.TabIndex = 2;
            this.lblLoaiSanPham.Text = "Loại sản phẩm";
            // 
            // lblThuongHieu
            // 
            this.lblThuongHieu.AutoSize = true;
            this.lblThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThuongHieu.Location = new System.Drawing.Point(20, 146);
            this.lblThuongHieu.Name = "lblThuongHieu";
            this.lblThuongHieu.Size = new System.Drawing.Size(122, 28);
            this.lblThuongHieu.TabIndex = 3;
            this.lblThuongHieu.Text = "Thương hiệu";
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhaCungCap.Location = new System.Drawing.Point(20, 183);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(132, 28);
            this.lblNhaCungCap.TabIndex = 4;
            this.lblNhaCungCap.Text = "Nhà cung cấp";
            // 
            // lblGiaNhap
            // 
            this.lblGiaNhap.AutoSize = true;
            this.lblGiaNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGiaNhap.Location = new System.Drawing.Point(20, 220);
            this.lblGiaNhap.Name = "lblGiaNhap";
            this.lblGiaNhap.Size = new System.Drawing.Size(90, 28);
            this.lblGiaNhap.TabIndex = 5;
            this.lblGiaNhap.Text = "Giá nhập";
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGiaBan.Location = new System.Drawing.Point(292, 220);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(79, 28);
            this.lblGiaBan.TabIndex = 6;
            this.lblGiaBan.Text = "Giá bán";
            // 
            // lblSoLuongTon
            // 
            this.lblSoLuongTon.AutoSize = true;
            this.lblSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoLuongTon.Location = new System.Drawing.Point(20, 257);
            this.lblSoLuongTon.Name = "lblSoLuongTon";
            this.lblSoLuongTon.Size = new System.Drawing.Size(127, 28);
            this.lblSoLuongTon.TabIndex = 7;
            this.lblSoLuongTon.Text = "Số lượng tồn";
            // 
            // lblBaoHanh
            // 
            this.lblBaoHanh.AutoSize = true;
            this.lblBaoHanh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBaoHanh.Location = new System.Drawing.Point(292, 257);
            this.lblBaoHanh.Name = "lblBaoHanh";
            this.lblBaoHanh.Size = new System.Drawing.Size(93, 28);
            this.lblBaoHanh.TabIndex = 8;
            this.lblBaoHanh.Text = "Bảo hành";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.Location = new System.Drawing.Point(20, 296);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(64, 28);
            this.lblMoTa.TabIndex = 9;
            this.lblMoTa.Text = "Mô tả";
            // 
            // lblHinhAnh
            // 
            this.lblHinhAnh.AutoSize = true;
            this.lblHinhAnh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHinhAnh.Location = new System.Drawing.Point(20, 432);
            this.lblHinhAnh.Name = "lblHinhAnh";
            this.lblHinhAnh.Size = new System.Drawing.Size(90, 28);
            this.lblHinhAnh.TabIndex = 10;
            this.lblHinhAnh.Text = "Hình ảnh";
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaSanPham.Location = new System.Drawing.Point(145, 31);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(292, 34);
            this.txtMaSanPham.TabIndex = 11;
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenSanPham.Location = new System.Drawing.Point(145, 68);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(292, 34);
            this.txtTenSanPham.TabIndex = 12;
            // 
            // cboLoaiSanPham
            // 
            this.cboLoaiSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiSanPham.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiSanPham.Location = new System.Drawing.Point(145, 105);
            this.cboLoaiSanPham.Name = "cboLoaiSanPham";
            this.cboLoaiSanPham.Size = new System.Drawing.Size(292, 36);
            this.cboLoaiSanPham.TabIndex = 13;
            // 
            // cboThuongHieu
            // 
            this.cboThuongHieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThuongHieu.Location = new System.Drawing.Point(145, 142);
            this.cboThuongHieu.Name = "cboThuongHieu";
            this.cboThuongHieu.Size = new System.Drawing.Size(292, 36);
            this.cboThuongHieu.TabIndex = 14;
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhaCungCap.Location = new System.Drawing.Point(145, 179);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(292, 36);
            this.cboNhaCungCap.TabIndex = 15;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiaNhap.Location = new System.Drawing.Point(145, 216);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(130, 34);
            this.txtGiaNhap.TabIndex = 16;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiaBan.Location = new System.Drawing.Point(347, 216);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(90, 34);
            this.txtGiaBan.TabIndex = 17;
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoLuongTon.Location = new System.Drawing.Point(145, 253);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(130, 34);
            this.txtSoLuongTon.TabIndex = 18;
            // 
            // txtBaoHanhThang
            // 
            this.txtBaoHanhThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBaoHanhThang.Location = new System.Drawing.Point(366, 253);
            this.txtBaoHanhThang.Name = "txtBaoHanhThang";
            this.txtBaoHanhThang.Size = new System.Drawing.Size(71, 34);
            this.txtBaoHanhThang.TabIndex = 19;
            // 
            // rtbMoTa
            // 
            this.rtbMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbMoTa.Location = new System.Drawing.Point(145, 292);
            this.rtbMoTa.Name = "rtbMoTa";
            this.rtbMoTa.Size = new System.Drawing.Size(292, 120);
            this.rtbMoTa.TabIndex = 20;
            this.rtbMoTa.Text = "";
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.BackColor = System.Drawing.Color.White;
            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.Location = new System.Drawing.Point(145, 430);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(128, 86);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnh.TabIndex = 21;
            this.picHinhAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(284, 445);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(95, 34);
            this.btnChonAnh.TabIndex = 22;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // lblDuongDanAnh
            // 
            this.lblDuongDanAnh.ForeColor = System.Drawing.Color.DimGray;
            this.lblDuongDanAnh.Location = new System.Drawing.Point(284, 486);
            this.lblDuongDanAnh.Name = "lblDuongDanAnh";
            this.lblDuongDanAnh.Size = new System.Drawing.Size(153, 35);
            this.lblDuongDanAnh.TabIndex = 23;
            this.lblDuongDanAnh.Text = "Chưa chọn ảnh";
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Controls.Add(this.lblTuKhoa);
            this.grpTimKiem.Controls.Add(this.lblLocLoai);
            this.grpTimKiem.Controls.Add(this.lblLocThuongHieu);
            this.grpTimKiem.Controls.Add(this.txtTuKhoa);
            this.grpTimKiem.Controls.Add(this.cboLocLoai);
            this.grpTimKiem.Controls.Add(this.cboLocThuongHieu);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Controls.Add(this.btnLoc);
            this.grpTimKiem.Controls.Add(this.btnBoLoc);
            this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpTimKiem.Location = new System.Drawing.Point(513, 101);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(847, 104);
            this.grpTimKiem.TabIndex = 4;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm và lọc";
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTuKhoa.Location = new System.Drawing.Point(18, 36);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(82, 28);
            this.lblTuKhoa.TabIndex = 0;
            this.lblTuKhoa.Text = "Từ khóa";
            // 
            // lblLocLoai
            // 
            this.lblLocLoai.AutoSize = true;
            this.lblLocLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLocLoai.Location = new System.Drawing.Point(330, 36);
            this.lblLocLoai.Name = "lblLocLoai";
            this.lblLocLoai.Size = new System.Drawing.Size(48, 28);
            this.lblLocLoai.TabIndex = 1;
            this.lblLocLoai.Text = "Loại";
            // 
            // lblLocThuongHieu
            // 
            this.lblLocThuongHieu.AutoSize = true;
            this.lblLocThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLocThuongHieu.Location = new System.Drawing.Point(553, 36);
            this.lblLocThuongHieu.Name = "lblLocThuongHieu";
            this.lblLocThuongHieu.Size = new System.Drawing.Size(122, 28);
            this.lblLocThuongHieu.TabIndex = 2;
            this.lblLocThuongHieu.Text = "Thương hiệu";
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTuKhoa.Location = new System.Drawing.Point(80, 32);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(235, 34);
            this.txtTuKhoa.TabIndex = 3;
            // 
            // cboLocLoai
            // 
            this.cboLocLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocLoai.Location = new System.Drawing.Point(371, 32);
            this.cboLocLoai.Name = "cboLocLoai";
            this.cboLocLoai.Size = new System.Drawing.Size(165, 36);
            this.cboLocLoai.TabIndex = 4;
            // 
            // cboLocThuongHieu
            // 
            this.cboLocThuongHieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocThuongHieu.Location = new System.Drawing.Point(640, 32);
            this.cboLocThuongHieu.Name = "cboLocThuongHieu";
            this.cboLocThuongHieu.Size = new System.Drawing.Size(185, 36);
            this.cboLocThuongHieu.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(78)))), ((int)(((byte)(125)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(80, 66);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(95, 38);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(181, 66);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(95, 36);
            this.btnLoc.TabIndex = 7;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.Location = new System.Drawing.Point(282, 66);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(95, 38);
            this.btnBoLoc.TabIndex = 8;
            this.btnBoLoc.Text = "Bỏ lọc";
            this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);
            // 
            // grpChucNang
            // 
            this.grpChucNang.Controls.Add(this.btnThem);
            this.grpChucNang.Controls.Add(this.btnSua);
            this.grpChucNang.Controls.Add(this.btnXoa);
            this.grpChucNang.Controls.Add(this.btnLuu);
            this.grpChucNang.Controls.Add(this.btnHuy);
            this.grpChucNang.Controls.Add(this.btnLamMoi);
            this.grpChucNang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpChucNang.Location = new System.Drawing.Point(513, 216);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new System.Drawing.Size(847, 76);
            this.grpChucNang.TabIndex = 3;
            this.grpChucNang.TabStop = false;
            this.grpChucNang.Text = "Chức năng";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(18, 28);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 42);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(119, 28);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 42);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(220, 28);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 42);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(321, 28);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(95, 42);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(422, 28);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(95, 42);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(523, 28);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 42);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvSanPham);
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDanhSach.Location = new System.Drawing.Point(513, 334);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(847, 325);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách sản phẩm";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(16, 29);
            this.dgvSanPham.MultiSelect = false;
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowHeadersWidth = 62;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(813, 279);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.SelectionChanged += new System.EventHandler(this.dgvSanPham_SelectionChanged);
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1384, 711);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpChucNang);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSanPham";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.grpChucNang.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
