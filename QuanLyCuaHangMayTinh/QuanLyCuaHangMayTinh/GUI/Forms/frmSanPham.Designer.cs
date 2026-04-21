using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    partial class frmSanPham
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
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
        private Label lblVaiTro;
        private Label lblHuongDan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel(); this.lblTitle = new Label(); this.lblSubtitle = new Label();
            this.grpThongTin = new GroupBox(); this.lblMaSanPham = new Label(); this.lblTenSanPham = new Label(); this.lblLoaiSanPham = new Label(); this.lblThuongHieu = new Label(); this.lblNhaCungCap = new Label(); this.lblGiaNhap = new Label(); this.lblGiaBan = new Label(); this.lblSoLuongTon = new Label(); this.lblBaoHanh = new Label(); this.lblMoTa = new Label(); this.lblHinhAnh = new Label();
            this.txtMaSanPham = new TextBox(); this.txtTenSanPham = new TextBox(); this.cboLoaiSanPham = new ComboBox(); this.cboThuongHieu = new ComboBox(); this.cboNhaCungCap = new ComboBox(); this.txtGiaNhap = new TextBox(); this.txtGiaBan = new TextBox(); this.txtSoLuongTon = new TextBox(); this.txtBaoHanhThang = new TextBox(); this.rtbMoTa = new RichTextBox(); this.picHinhAnh = new PictureBox(); this.btnChonAnh = new Button(); this.lblDuongDanAnh = new Label();
            this.grpTimKiem = new GroupBox(); this.lblTuKhoa = new Label(); this.lblLocLoai = new Label(); this.lblLocThuongHieu = new Label(); this.txtTuKhoa = new TextBox(); this.cboLocLoai = new ComboBox(); this.cboLocThuongHieu = new ComboBox(); this.btnTimKiem = new Button(); this.btnLoc = new Button(); this.btnBoLoc = new Button();
            this.grpChucNang = new GroupBox(); this.btnThem = new Button(); this.btnSua = new Button(); this.btnXoa = new Button(); this.btnLuu = new Button(); this.btnHuy = new Button(); this.btnLamMoi = new Button();
            this.grpDanhSach = new GroupBox(); this.dgvSanPham = new DataGridView(); this.lblVaiTro = new Label(); this.lblHuongDan = new Label();
            this.pnlHeader.SuspendLayout(); this.grpThongTin.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit(); this.grpTimKiem.SuspendLayout(); this.grpChucNang.SuspendLayout(); this.grpDanhSach.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit(); this.SuspendLayout();
            // header
            this.pnlHeader.BackColor = Color.FromArgb(23, 78, 125); this.pnlHeader.Controls.AddRange(new Control[] { this.lblTitle, this.lblSubtitle }); this.pnlHeader.Dock = DockStyle.Top; this.pnlHeader.Size = new Size(1384, 82);
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold); this.lblTitle.ForeColor = Color.White; this.lblTitle.Location = new Point(22, 14); this.lblTitle.Text = "QUẢN LÝ / TRA CỨU SẢN PHẨM";
            this.lblSubtitle.AutoSize = true; this.lblSubtitle.ForeColor = Color.WhiteSmoke; this.lblSubtitle.Location = new Point(24, 50); this.lblSubtitle.Text = "Dùng cho nhân viên kho và bán hàng: tìm kiếm, lọc, xem giá, tồn kho, thêm/sửa/xóa theo quyền";
            // grpThongTin
            this.grpThongTin.Controls.AddRange(new Control[] { this.lblMaSanPham, this.lblTenSanPham, this.lblLoaiSanPham, this.lblThuongHieu, this.lblNhaCungCap, this.lblGiaNhap, this.lblGiaBan, this.lblSoLuongTon, this.lblBaoHanh, this.lblMoTa, this.lblHinhAnh, this.txtMaSanPham, this.txtTenSanPham, this.cboLoaiSanPham, this.cboThuongHieu, this.cboNhaCungCap, this.txtGiaNhap, this.txtGiaBan, this.txtSoLuongTon, this.txtBaoHanhThang, this.rtbMoTa, this.picHinhAnh, this.btnChonAnh, this.lblDuongDanAnh });
            this.grpThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold); this.grpThongTin.Location = new Point(24, 101); this.grpThongTin.Name = "grpThongTin"; this.grpThongTin.Size = new Size(468, 558); this.grpThongTin.Text = "Thông tin sản phẩm";
            int lx=20, tx=145; 
            this.lblMaSanPham.AutoSize = true; this.lblMaSanPham.Font = new Font("Segoe UI", 10F); this.lblMaSanPham.Location = new Point(lx, 35); this.lblMaSanPham.Text = "Mã sản phẩm";
            this.txtMaSanPham.Font = new Font("Segoe UI", 10F); this.txtMaSanPham.Location = new Point(tx, 31); this.txtMaSanPham.Name = "txtMaSanPham"; this.txtMaSanPham.Size = new Size(292, 25);
            this.lblTenSanPham.AutoSize = true; this.lblTenSanPham.Font = new Font("Segoe UI", 10F); this.lblTenSanPham.Location = new Point(lx, 72); this.lblTenSanPham.Text = "Tên sản phẩm";
            this.txtTenSanPham.Font = new Font("Segoe UI", 10F); this.txtTenSanPham.Location = new Point(tx, 68); this.txtTenSanPham.Name = "txtTenSanPham"; this.txtTenSanPham.Size = new Size(292, 25);
            this.lblLoaiSanPham.AutoSize = true; this.lblLoaiSanPham.Font = new Font("Segoe UI", 10F); this.lblLoaiSanPham.Location = new Point(lx, 109); this.lblLoaiSanPham.Text = "Loại sản phẩm";
            this.cboLoaiSanPham.DropDownStyle = ComboBoxStyle.DropDownList; this.cboLoaiSanPham.Font = new Font("Segoe UI", 10F); this.cboLoaiSanPham.Location = new Point(tx, 105); this.cboLoaiSanPham.Name = "cboLoaiSanPham"; this.cboLoaiSanPham.Size = new Size(292, 25);
            this.lblThuongHieu.AutoSize = true; this.lblThuongHieu.Font = new Font("Segoe UI", 10F); this.lblThuongHieu.Location = new Point(lx, 146); this.lblThuongHieu.Text = "Thương hiệu";
            this.cboThuongHieu.DropDownStyle = ComboBoxStyle.DropDownList; this.cboThuongHieu.Font = new Font("Segoe UI", 10F); this.cboThuongHieu.Location = new Point(tx, 142); this.cboThuongHieu.Name = "cboThuongHieu"; this.cboThuongHieu.Size = new Size(292, 25);
            this.lblNhaCungCap.AutoSize = true; this.lblNhaCungCap.Font = new Font("Segoe UI", 10F); this.lblNhaCungCap.Location = new Point(lx, 183); this.lblNhaCungCap.Text = "Nhà cung cấp";
            this.cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList; this.cboNhaCungCap.Font = new Font("Segoe UI", 10F); this.cboNhaCungCap.Location = new Point(tx, 179); this.cboNhaCungCap.Name = "cboNhaCungCap"; this.cboNhaCungCap.Size = new Size(292, 25);
            this.lblGiaNhap.AutoSize = true; this.lblGiaNhap.Font = new Font("Segoe UI", 10F); this.lblGiaNhap.Location = new Point(lx, 220); this.lblGiaNhap.Text = "Giá nhập";
            this.txtGiaNhap.Font = new Font("Segoe UI", 10F); this.txtGiaNhap.Location = new Point(tx, 216); this.txtGiaNhap.Name = "txtGiaNhap"; this.txtGiaNhap.Size = new Size(130, 25);
            this.lblGiaBan.AutoSize = true; this.lblGiaBan.Font = new Font("Segoe UI", 10F); this.lblGiaBan.Location = new Point(292, 220); this.lblGiaBan.Text = "Giá bán";
            this.txtGiaBan.Font = new Font("Segoe UI", 10F); this.txtGiaBan.Location = new Point(347, 216); this.txtGiaBan.Name = "txtGiaBan"; this.txtGiaBan.Size = new Size(90, 25);
            this.lblSoLuongTon.AutoSize = true; this.lblSoLuongTon.Font = new Font("Segoe UI", 10F); this.lblSoLuongTon.Location = new Point(lx, 257); this.lblSoLuongTon.Text = "Số lượng tồn";
            this.txtSoLuongTon.Font = new Font("Segoe UI", 10F); this.txtSoLuongTon.Location = new Point(tx, 253); this.txtSoLuongTon.Name = "txtSoLuongTon"; this.txtSoLuongTon.Size = new Size(130, 25);
            this.lblBaoHanh.AutoSize = true; this.lblBaoHanh.Font = new Font("Segoe UI", 10F); this.lblBaoHanh.Location = new Point(292, 257); this.lblBaoHanh.Text = "Bảo hành";
            this.txtBaoHanhThang.Font = new Font("Segoe UI", 10F); this.txtBaoHanhThang.Location = new Point(366, 253); this.txtBaoHanhThang.Name = "txtBaoHanhThang"; this.txtBaoHanhThang.Size = new Size(71, 25);
            this.lblMoTa.AutoSize = true; this.lblMoTa.Font = new Font("Segoe UI", 10F); this.lblMoTa.Location = new Point(lx, 296); this.lblMoTa.Text = "Mô tả";
            this.rtbMoTa.Font = new Font("Segoe UI", 10F); this.rtbMoTa.Location = new Point(tx, 292); this.rtbMoTa.Name = "rtbMoTa"; this.rtbMoTa.Size = new Size(292, 120);
            this.lblHinhAnh.AutoSize = true; this.lblHinhAnh.Font = new Font("Segoe UI", 10F); this.lblHinhAnh.Location = new Point(lx, 432); this.lblHinhAnh.Text = "Hình ảnh";
            this.picHinhAnh.BackColor = Color.White; this.picHinhAnh.BorderStyle = BorderStyle.FixedSingle; this.picHinhAnh.Location = new Point(tx, 430); this.picHinhAnh.Name = "picHinhAnh"; this.picHinhAnh.Size = new Size(128, 86); this.picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            this.btnChonAnh.Location = new Point(284, 445); this.btnChonAnh.Name = "btnChonAnh"; this.btnChonAnh.Size = new Size(95, 34); this.btnChonAnh.Text = "Chọn ảnh"; this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            this.lblDuongDanAnh.ForeColor = Color.DimGray; this.lblDuongDanAnh.Location = new Point(284, 486); this.lblDuongDanAnh.Name = "lblDuongDanAnh"; this.lblDuongDanAnh.Size = new Size(153, 35); this.lblDuongDanAnh.Text = "Chưa chọn ảnh";
            // grpTimKiem
            this.grpTimKiem.Controls.AddRange(new Control[] { this.lblTuKhoa, this.lblLocLoai, this.lblLocThuongHieu, this.txtTuKhoa, this.cboLocLoai, this.cboLocThuongHieu, this.btnTimKiem, this.btnLoc, this.btnBoLoc });
            this.grpTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold); this.grpTimKiem.Location = new Point(513, 101); this.grpTimKiem.Name = "grpTimKiem"; this.grpTimKiem.Size = new Size(847, 104); this.grpTimKiem.Text = "Tìm kiếm và lọc";
            this.lblTuKhoa.AutoSize = true; this.lblTuKhoa.Font = new Font("Segoe UI", 10F); this.lblTuKhoa.Location = new Point(18, 36); this.lblTuKhoa.Text = "Từ khóa";
            this.txtTuKhoa.Font = new Font("Segoe UI", 10F); this.txtTuKhoa.Location = new Point(80, 32); this.txtTuKhoa.Name = "txtTuKhoa"; this.txtTuKhoa.Size = new Size(235, 25);
            this.lblLocLoai.AutoSize = true; this.lblLocLoai.Font = new Font("Segoe UI", 10F); this.lblLocLoai.Location = new Point(330, 36); this.lblLocLoai.Text = "Loại";
            this.cboLocLoai.DropDownStyle = ComboBoxStyle.DropDownList; this.cboLocLoai.Font = new Font("Segoe UI", 10F); this.cboLocLoai.Location = new Point(371, 32); this.cboLocLoai.Name = "cboLocLoai"; this.cboLocLoai.Size = new Size(165, 25);
            this.lblLocThuongHieu.AutoSize = true; this.lblLocThuongHieu.Font = new Font("Segoe UI", 10F); this.lblLocThuongHieu.Location = new Point(553, 36); this.lblLocThuongHieu.Text = "Thương hiệu";
            this.cboLocThuongHieu.DropDownStyle = ComboBoxStyle.DropDownList; this.cboLocThuongHieu.Font = new Font("Segoe UI", 10F); this.cboLocThuongHieu.Location = new Point(640, 32); this.cboLocThuongHieu.Name = "cboLocThuongHieu"; this.cboLocThuongHieu.Size = new Size(185, 25);
            this.btnTimKiem.BackColor = Color.FromArgb(23, 78, 125); this.btnTimKiem.FlatStyle = FlatStyle.Flat; this.btnTimKiem.ForeColor = Color.White; this.btnTimKiem.Location = new Point(80, 66); this.btnTimKiem.Name = "btnTimKiem"; this.btnTimKiem.Size = new Size(95, 30); this.btnTimKiem.Text = "Tìm kiếm"; this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            this.btnLoc.Location = new Point(181, 66); this.btnLoc.Name = "btnLoc"; this.btnLoc.Size = new Size(95, 30); this.btnLoc.Text = "Lọc"; this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            this.btnBoLoc.Location = new Point(282, 66); this.btnBoLoc.Name = "btnBoLoc"; this.btnBoLoc.Size = new Size(95, 30); this.btnBoLoc.Text = "Bỏ lọc"; this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);
            // grpChucNang
            this.grpChucNang.Controls.AddRange(new Control[] { this.btnThem, this.btnSua, this.btnXoa, this.btnLuu, this.btnHuy, this.btnLamMoi });
            this.grpChucNang.Font = new Font("Segoe UI", 10F, FontStyle.Bold); this.grpChucNang.Location = new Point(513, 216); this.grpChucNang.Name = "grpChucNang"; this.grpChucNang.Size = new Size(847, 76); this.grpChucNang.Text = "Chức năng";
            this.btnThem.Location = new Point(18, 28); this.btnThem.Name = "btnThem"; this.btnThem.Size = new Size(95, 34); this.btnThem.Text = "Thêm"; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Location = new Point(119, 28); this.btnSua.Name = "btnSua"; this.btnSua.Size = new Size(95, 34); this.btnSua.Text = "Sửa"; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Location = new Point(220, 28); this.btnXoa.Name = "btnXoa"; this.btnXoa.Size = new Size(95, 34); this.btnXoa.Text = "Xóa"; this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLuu.Location = new Point(321, 28); this.btnLuu.Name = "btnLuu"; this.btnLuu.Size = new Size(95, 34); this.btnLuu.Text = "Lưu"; this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnHuy.Location = new Point(422, 28); this.btnHuy.Name = "btnHuy"; this.btnHuy.Size = new Size(95, 34); this.btnHuy.Text = "Hủy"; this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.btnLamMoi.Location = new Point(523, 28); this.btnLamMoi.Name = "btnLamMoi"; this.btnLamMoi.Size = new Size(95, 34); this.btnLamMoi.Text = "Làm mới"; this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // grpDanhSach
            this.grpDanhSach.Controls.Add(this.dgvSanPham); this.grpDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold); this.grpDanhSach.Location = new Point(513, 334); this.grpDanhSach.Name = "grpDanhSach"; this.grpDanhSach.Size = new Size(847, 325); this.grpDanhSach.Text = "Danh sách sản phẩm";
            this.dgvSanPham.AllowUserToAddRows = false; this.dgvSanPham.AllowUserToDeleteRows = false; this.dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; this.dgvSanPham.BackgroundColor = Color.White; this.dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; this.dgvSanPham.Location = new Point(16, 29); this.dgvSanPham.MultiSelect = false; this.dgvSanPham.Name = "dgvSanPham"; this.dgvSanPham.ReadOnly = true; this.dgvSanPham.RowHeadersVisible = false; this.dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect; this.dgvSanPham.Size = new Size(813, 279); this.dgvSanPham.SelectionChanged += new System.EventHandler(this.dgvSanPham_SelectionChanged);
            // labels role/info
            this.lblVaiTro.AutoSize = true; this.lblVaiTro.Font = new Font("Segoe UI", 10F, FontStyle.Bold); this.lblVaiTro.Location = new Point(24, 671); this.lblVaiTro.Text = "Vai trò hiện tại:";
            this.lblHuongDan.ForeColor = Color.DimGray; this.lblHuongDan.Location = new Point(271, 667); this.lblHuongDan.Size = new Size(1089, 28); this.lblHuongDan.Text = "Admin/Nhân viên kho: có thể CRUD sản phẩm. Nhân viên bán hàng: tìm kiếm, lọc, xem giá bán và tồn kho; cột giá nhập sẽ bị ẩn.";
            // form
            this.AutoScaleDimensions = new SizeF(7F, 15F); this.AutoScaleMode = AutoScaleMode.Font; this.BackColor = Color.WhiteSmoke; this.ClientSize = new Size(1384, 711); this.Controls.AddRange(new Control[] { this.lblHuongDan, this.lblVaiTro, this.grpDanhSach, this.grpChucNang, this.grpTimKiem, this.grpThongTin, this.pnlHeader }); this.Font = new Font("Segoe UI", 9F); this.FormBorderStyle = FormBorderStyle.FixedSingle; this.MaximizeBox = false; this.Name = "frmSanPham"; this.StartPosition = FormStartPosition.CenterScreen; this.Text = "frmSanPham"; this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout(); this.grpThongTin.ResumeLayout(false); this.grpThongTin.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit(); this.grpTimKiem.ResumeLayout(false); this.grpTimKiem.PerformLayout(); this.grpChucNang.ResumeLayout(false); this.grpDanhSach.ResumeLayout(false); ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit(); this.ResumeLayout(false); this.PerformLayout();
        }
    }
}
