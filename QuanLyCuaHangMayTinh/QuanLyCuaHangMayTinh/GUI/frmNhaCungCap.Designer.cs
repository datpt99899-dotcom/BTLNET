using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    partial class frmNhaCungCap
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private GroupBox grpThongTin;
        private Label lblMaNhaCungCap;
        private Label lblTenNhaCungCap;
        private Label lblDiaChi;
        private Label lblSoDienThoai;
        private TextBox txtMaNhaCungCap;
        private TextBox txtTenNhaCungCap;
        private TextBox txtDiaChi;
        private TextBox txtSoDienThoai;
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
        private DataGridView dgvNhaCungCap;
        private Label lblVaiTro;
        private Label lblHuongDan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.grpThongTin = new GroupBox();
            this.lblMaNhaCungCap = new Label();
            this.lblTenNhaCungCap = new Label();
            this.lblDiaChi = new Label();
            this.lblSoDienThoai = new Label();
            this.txtMaNhaCungCap = new TextBox();
            this.txtTenNhaCungCap = new TextBox();
            this.txtDiaChi = new TextBox();
            this.txtSoDienThoai = new TextBox();
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
            this.dgvNhaCungCap = new DataGridView();
            this.lblVaiTro = new Label();
            this.lblHuongDan = new Label();
            this.pnlHeader.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            this.grpChucNang.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).BeginInit();
            this.SuspendLayout();
            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(27, 94, 107);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(1184, 78);
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(22, 14);
            this.lblTitle.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = Color.WhiteSmoke;
            this.lblSubtitle.Location = new Point(24, 47);
            this.lblSubtitle.Text = "Theo dõi mã, tên, địa chỉ và số điện thoại nhà cung cấp";
            // grpThongTin
            this.grpThongTin.Controls.AddRange(new Control[] { this.lblMaNhaCungCap, this.lblTenNhaCungCap, this.lblDiaChi, this.lblSoDienThoai, this.txtMaNhaCungCap, this.txtTenNhaCungCap, this.txtDiaChi, this.txtSoDienThoai });
            this.grpThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpThongTin.Location = new Point(24, 98);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new Size(462, 222);
            this.grpThongTin.Text = "Thông tin nhà cung cấp";
            // labels and textboxes
            this.lblMaNhaCungCap.AutoSize = true; this.lblMaNhaCungCap.Font = new Font("Segoe UI", 10F); this.lblMaNhaCungCap.Location = new Point(20, 39); this.lblMaNhaCungCap.Text = "Mã NCC";
            this.lblTenNhaCungCap.AutoSize = true; this.lblTenNhaCungCap.Font = new Font("Segoe UI", 10F); this.lblTenNhaCungCap.Location = new Point(20, 82); this.lblTenNhaCungCap.Text = "Tên NCC";
            this.lblDiaChi.AutoSize = true; this.lblDiaChi.Font = new Font("Segoe UI", 10F); this.lblDiaChi.Location = new Point(20, 125); this.lblDiaChi.Text = "Địa chỉ";
            this.lblSoDienThoai.AutoSize = true; this.lblSoDienThoai.Font = new Font("Segoe UI", 10F); this.lblSoDienThoai.Location = new Point(20, 168); this.lblSoDienThoai.Text = "Số điện thoại";
            this.txtMaNhaCungCap.Font = new Font("Segoe UI", 10F); this.txtMaNhaCungCap.Location = new Point(146, 35); this.txtMaNhaCungCap.Name = "txtMaNhaCungCap"; this.txtMaNhaCungCap.Size = new Size(280, 25);
            this.txtTenNhaCungCap.Font = new Font("Segoe UI", 10F); this.txtTenNhaCungCap.Location = new Point(146, 78); this.txtTenNhaCungCap.Name = "txtTenNhaCungCap"; this.txtTenNhaCungCap.Size = new Size(280, 25);
            this.txtDiaChi.Font = new Font("Segoe UI", 10F); this.txtDiaChi.Location = new Point(146, 121); this.txtDiaChi.Name = "txtDiaChi"; this.txtDiaChi.Size = new Size(280, 25);
            this.txtSoDienThoai.Font = new Font("Segoe UI", 10F); this.txtSoDienThoai.Location = new Point(146, 164); this.txtSoDienThoai.Name = "txtSoDienThoai"; this.txtSoDienThoai.Size = new Size(280, 25);
            // grpTimKiem
            this.grpTimKiem.Controls.AddRange(new Control[] { this.lblTimKiemTitle, this.txtTimKiem, this.btnTimKiem });
            this.grpTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpTimKiem.Location = new Point(510, 98);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new Size(648, 88);
            this.grpTimKiem.Text = "Tìm kiếm";
            this.lblTimKiemTitle.AutoSize = true; this.lblTimKiemTitle.Font = new Font("Segoe UI", 10F); this.lblTimKiemTitle.Location = new Point(19, 39); this.lblTimKiemTitle.Text = "Từ khóa";
            this.txtTimKiem.Font = new Font("Segoe UI", 10F); this.txtTimKiem.Location = new Point(86, 35); this.txtTimKiem.Name = "txtTimKiem"; this.txtTimKiem.Size = new Size(421, 25);
            this.btnTimKiem.BackColor = Color.FromArgb(27, 94, 107); this.btnTimKiem.FlatStyle = FlatStyle.Flat; this.btnTimKiem.ForeColor = Color.White; this.btnTimKiem.Location = new Point(524, 33); this.btnTimKiem.Name = "btnTimKiem"; this.btnTimKiem.Size = new Size(101, 30); this.btnTimKiem.Text = "Tìm kiếm"; this.btnTimKiem.UseVisualStyleBackColor = false; this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // grpChucNang
            this.grpChucNang.Controls.AddRange(new Control[] { this.btnThem, this.btnSua, this.btnXoa, this.btnLuu, this.btnHuy, this.btnLamMoi });
            this.grpChucNang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpChucNang.Location = new Point(510, 198);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new Size(648, 122);
            this.grpChucNang.Text = "Chức năng";
            this.btnThem.Location = new Point(24, 34); this.btnThem.Name = "btnThem"; this.btnThem.Size = new Size(94, 34); this.btnThem.Text = "Thêm"; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Location = new Point(126, 34); this.btnSua.Name = "btnSua"; this.btnSua.Size = new Size(94, 34); this.btnSua.Text = "Sửa"; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Location = new Point(228, 34); this.btnXoa.Name = "btnXoa"; this.btnXoa.Size = new Size(94, 34); this.btnXoa.Text = "Xóa"; this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLuu.Location = new Point(330, 34); this.btnLuu.Name = "btnLuu"; this.btnLuu.Size = new Size(94, 34); this.btnLuu.Text = "Lưu"; this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnHuy.Location = new Point(432, 34); this.btnHuy.Name = "btnHuy"; this.btnHuy.Size = new Size(94, 34); this.btnHuy.Text = "Hủy"; this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.btnLamMoi.Location = new Point(24, 76); this.btnLamMoi.Name = "btnLamMoi"; this.btnLamMoi.Size = new Size(94, 34); this.btnLamMoi.Text = "Làm mới"; this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // grpDanhSach
            this.grpDanhSach.Controls.Add(this.dgvNhaCungCap);
            this.grpDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpDanhSach.Location = new Point(24, 382);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new Size(1134, 287);
            this.grpDanhSach.Text = "Danh sách nhà cung cấp";
            this.dgvNhaCungCap.AllowUserToAddRows = false; this.dgvNhaCungCap.AllowUserToDeleteRows = false; this.dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; this.dgvNhaCungCap.BackgroundColor = Color.White; this.dgvNhaCungCap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; this.dgvNhaCungCap.Location = new Point(16, 29); this.dgvNhaCungCap.MultiSelect = false; this.dgvNhaCungCap.Name = "dgvNhaCungCap"; this.dgvNhaCungCap.ReadOnly = true; this.dgvNhaCungCap.RowHeadersVisible = false; this.dgvNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect; this.dgvNhaCungCap.Size = new Size(1102, 241); this.dgvNhaCungCap.SelectionChanged += new System.EventHandler(this.dgvNhaCungCap_SelectionChanged);
            // lblVaiTro
            this.lblVaiTro.AutoSize = true; this.lblVaiTro.Font = new Font("Segoe UI", 10F, FontStyle.Bold); this.lblVaiTro.Location = new Point(28, 336); this.lblVaiTro.Text = "Vai trò hiện tại:";
            // lblHuongDan
            this.lblHuongDan.ForeColor = Color.DimGray; this.lblHuongDan.Location = new Point(24, 356); this.lblHuongDan.Size = new Size(689, 23); this.lblHuongDan.Text = "Nhân viên kho quản lý nhà cung cấp để phục vụ nhập hàng. Không xóa nếu đã phát sinh sản phẩm hoặc phiếu nhập.";
            // form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(1184, 681);
            this.Controls.AddRange(new Control[] { this.lblHuongDan, this.lblVaiTro, this.grpDanhSach, this.grpChucNang, this.grpTimKiem, this.grpThongTin, this.pnlHeader });
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmNhaCungCap";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmNhaCungCap";
            this.Load += new System.EventHandler(this.frmNhaCungCap_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.grpChucNang.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
