using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    partial class frmThuongHieu
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private GroupBox grpThongTin;
        private Label lblMaThuongHieu;
        private Label lblTenThuongHieu;
        private TextBox txtMaThuongHieu;
        private TextBox txtTenThuongHieu;
        private GroupBox grpTimKiem;
        private Label lblTimKiemTitle;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private GroupBox grpChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuy;
        private Button btnLamMoi;
        private GroupBox grpDanhSach;
        private DataGridView dgvThuongHieu;
        private Label lblVaiTro;
        private Label lblHuongDan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.grpThongTin = new GroupBox();
            this.lblMaThuongHieu = new Label();
            this.lblTenThuongHieu = new Label();
            this.txtMaThuongHieu = new TextBox();
            this.txtTenThuongHieu = new TextBox();
            this.grpTimKiem = new GroupBox();
            this.lblTimKiemTitle = new Label();
            this.txtTimKiem = new TextBox();
            this.btnTimKiem = new Button();
            this.grpChucNang = new GroupBox();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnXoa = new Button();
            this.btnLuu = new Button();
            this.btnHuy = new Button();
            this.btnLamMoi = new Button();
            this.grpDanhSach = new GroupBox();
            this.dgvThuongHieu = new DataGridView();
            this.lblVaiTro = new Label();
            this.lblHuongDan = new Label();
            this.pnlHeader.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            this.grpChucNang.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuongHieu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = Color.FromArgb(39, 96, 158);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(1084, 78);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(22, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(227, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ THƯƠNG HIỆU";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = Color.WhiteSmoke;
            this.lblSubtitle.Location = new Point(24, 47);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new Size(402, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Quản lý mã và tên thương hiệu để dùng cho form sản phẩm";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblMaThuongHieu);
            this.grpThongTin.Controls.Add(this.lblTenThuongHieu);
            this.grpThongTin.Controls.Add(this.txtMaThuongHieu);
            this.grpThongTin.Controls.Add(this.txtTenThuongHieu);
            this.grpThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpThongTin.Location = new Point(24, 98);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new Size(408, 150);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin thương hiệu";
            // 
            // lblMaThuongHieu
            // 
            this.lblMaThuongHieu.AutoSize = true;
            this.lblMaThuongHieu.Font = new Font("Segoe UI", 10F);
            this.lblMaThuongHieu.Location = new Point(20, 42);
            this.lblMaThuongHieu.Name = "lblMaThuongHieu";
            this.lblMaThuongHieu.Size = new Size(109, 19);
            this.lblMaThuongHieu.TabIndex = 0;
            this.lblMaThuongHieu.Text = "Mã thương hiệu";
            // 
            // lblTenThuongHieu
            // 
            this.lblTenThuongHieu.AutoSize = true;
            this.lblTenThuongHieu.Font = new Font("Segoe UI", 10F);
            this.lblTenThuongHieu.Location = new Point(20, 88);
            this.lblTenThuongHieu.Name = "lblTenThuongHieu";
            this.lblTenThuongHieu.Size = new Size(112, 19);
            this.lblTenThuongHieu.TabIndex = 1;
            this.lblTenThuongHieu.Text = "Tên thương hiệu";
            // 
            // txtMaThuongHieu
            // 
            this.txtMaThuongHieu.Font = new Font("Segoe UI", 10F);
            this.txtMaThuongHieu.Location = new Point(148, 38);
            this.txtMaThuongHieu.Name = "txtMaThuongHieu";
            this.txtMaThuongHieu.Size = new Size(221, 25);
            this.txtMaThuongHieu.TabIndex = 2;
            // 
            // txtTenThuongHieu
            // 
            this.txtTenThuongHieu.Font = new Font("Segoe UI", 10F);
            this.txtTenThuongHieu.Location = new Point(148, 84);
            this.txtTenThuongHieu.Name = "txtTenThuongHieu";
            this.txtTenThuongHieu.Size = new Size(221, 25);
            this.txtTenThuongHieu.TabIndex = 3;
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Controls.Add(this.lblTimKiemTitle);
            this.grpTimKiem.Controls.Add(this.txtTimKiem);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpTimKiem.Location = new Point(455, 98);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new Size(603, 88);
            this.grpTimKiem.TabIndex = 2;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm";
            // 
            // lblTimKiemTitle
            // 
            this.lblTimKiemTitle.AutoSize = true;
            this.lblTimKiemTitle.Font = new Font("Segoe UI", 10F);
            this.lblTimKiemTitle.Location = new Point(19, 39);
            this.lblTimKiemTitle.Name = "lblTimKiemTitle";
            this.lblTimKiemTitle.Size = new Size(55, 19);
            this.lblTimKiemTitle.TabIndex = 0;
            this.lblTimKiemTitle.Text = "Từ khóa";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new Point(86, 35);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new Size(377, 25);
            this.txtTimKiem.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = Color.FromArgb(39, 96, 158);
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
            this.btnTimKiem.ForeColor = Color.White;
            this.btnTimKiem.Location = new Point(480, 33);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new Size(101, 30);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // grpChucNang
            // 
            this.grpChucNang.Controls.Add(this.btnThem);
            this.grpChucNang.Controls.Add(this.btnSua);
            this.grpChucNang.Controls.Add(this.btnXoa);
            this.grpChucNang.Controls.Add(this.btnLuu);
            this.grpChucNang.Controls.Add(this.btnHuy);
            this.grpChucNang.Controls.Add(this.btnLamMoi);
            this.grpChucNang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpChucNang.Location = new Point(455, 195);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new Size(603, 124);
            this.grpChucNang.TabIndex = 3;
            this.grpChucNang.TabStop = false;
            this.grpChucNang.Text = "Chức năng";
            // buttons similar
            this.btnThem.Location = new Point(23, 34); this.btnThem.Name = "btnThem"; this.btnThem.Size = new Size(92, 34); this.btnThem.TabIndex = 0; this.btnThem.Text = "Thêm"; this.btnThem.UseVisualStyleBackColor = true; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Location = new Point(123, 34); this.btnSua.Name = "btnSua"; this.btnSua.Size = new Size(92, 34); this.btnSua.TabIndex = 1; this.btnSua.Text = "Sửa"; this.btnSua.UseVisualStyleBackColor = true; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Location = new Point(223, 34); this.btnXoa.Name = "btnXoa"; this.btnXoa.Size = new Size(92, 34); this.btnXoa.TabIndex = 2; this.btnXoa.Text = "Xóa"; this.btnXoa.UseVisualStyleBackColor = true; this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLuu.Location = new Point(323, 34); this.btnLuu.Name = "btnLuu"; this.btnLuu.Size = new Size(92, 34); this.btnLuu.TabIndex = 3; this.btnLuu.Text = "Lưu"; this.btnLuu.UseVisualStyleBackColor = true; this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnHuy.Location = new Point(423, 34); this.btnHuy.Name = "btnHuy"; this.btnHuy.Size = new Size(92, 34); this.btnHuy.TabIndex = 4; this.btnHuy.Text = "Hủy"; this.btnHuy.UseVisualStyleBackColor = true; this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.btnLamMoi.Location = new Point(23, 76); this.btnLamMoi.Name = "btnLamMoi"; this.btnLamMoi.Size = new Size(92, 34); this.btnLamMoi.TabIndex = 5; this.btnLamMoi.Text = "Làm mới"; this.btnLamMoi.UseVisualStyleBackColor = true; this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvThuongHieu);
            this.grpDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpDanhSach.Location = new Point(24, 332);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new Size(1034, 327);
            this.grpDanhSach.TabIndex = 4;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách thương hiệu";
            // 
            // dgvThuongHieu
            // 
            this.dgvThuongHieu.AllowUserToAddRows = false;
            this.dgvThuongHieu.AllowUserToDeleteRows = false;
            this.dgvThuongHieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuongHieu.BackgroundColor = Color.White;
            this.dgvThuongHieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuongHieu.Location = new Point(16, 29);
            this.dgvThuongHieu.MultiSelect = false;
            this.dgvThuongHieu.Name = "dgvThuongHieu";
            this.dgvThuongHieu.ReadOnly = true;
            this.dgvThuongHieu.RowHeadersVisible = false;
            this.dgvThuongHieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuongHieu.Size = new Size(1001, 281);
            this.dgvThuongHieu.TabIndex = 0;
            this.dgvThuongHieu.SelectionChanged += new System.EventHandler(this.dgvThuongHieu_SelectionChanged);
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblVaiTro.Location = new Point(27, 267);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new Size(103, 19);
            this.lblVaiTro.TabIndex = 5;
            this.lblVaiTro.Text = "Vai trò hiện tại:";
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.ForeColor = Color.DimGray;
            this.lblHuongDan.Location = new Point(24, 292);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new Size(408, 30);
            this.lblHuongDan.TabIndex = 6;
            this.lblHuongDan.Text = "Thương hiệu dùng để lọc và gán cho sản phẩm. Không xóa nếu đã có sản phẩm sử dụng.";
            // 
            // frmThuongHieu
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(1084, 681);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpChucNang);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmThuongHieu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmThuongHieu";
            this.Load += new System.EventHandler(this.frmThuongHieu_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.grpChucNang.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuongHieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
