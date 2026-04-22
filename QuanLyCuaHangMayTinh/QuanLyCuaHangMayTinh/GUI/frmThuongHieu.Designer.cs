using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    partial class frmThuongHieu
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaThuongHieu = new System.Windows.Forms.Label();
            this.lblTenThuongHieu = new System.Windows.Forms.Label();
            this.txtMaThuongHieu = new System.Windows.Forms.TextBox();
            this.txtTenThuongHieu = new System.Windows.Forms.TextBox();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimKiemTitle = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvThuongHieu = new System.Windows.Forms.DataGridView();
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
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(96)))), ((int)(((byte)(158)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1084, 78);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(22, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(392, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ THƯƠNG HIỆU";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblMaThuongHieu);
            this.grpThongTin.Controls.Add(this.lblTenThuongHieu);
            this.grpThongTin.Controls.Add(this.txtMaThuongHieu);
            this.grpThongTin.Controls.Add(this.txtTenThuongHieu);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Location = new System.Drawing.Point(24, 98);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(408, 150);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin thương hiệu";
            // 
            // lblMaThuongHieu
            // 
            this.lblMaThuongHieu.AutoSize = true;
            this.lblMaThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaThuongHieu.Location = new System.Drawing.Point(20, 42);
            this.lblMaThuongHieu.Name = "lblMaThuongHieu";
            this.lblMaThuongHieu.Size = new System.Drawing.Size(152, 28);
            this.lblMaThuongHieu.TabIndex = 0;
            this.lblMaThuongHieu.Text = "Mã thương hiệu";
            // 
            // lblTenThuongHieu
            // 
            this.lblTenThuongHieu.AutoSize = true;
            this.lblTenThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenThuongHieu.Location = new System.Drawing.Point(20, 88);
            this.lblTenThuongHieu.Name = "lblTenThuongHieu";
            this.lblTenThuongHieu.Size = new System.Drawing.Size(153, 28);
            this.lblTenThuongHieu.TabIndex = 1;
            this.lblTenThuongHieu.Text = "Tên thương hiệu";
            // 
            // txtMaThuongHieu
            // 
            this.txtMaThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaThuongHieu.Location = new System.Drawing.Point(148, 38);
            this.txtMaThuongHieu.Name = "txtMaThuongHieu";
            this.txtMaThuongHieu.Size = new System.Drawing.Size(221, 34);
            this.txtMaThuongHieu.TabIndex = 2;
            // 
            // txtTenThuongHieu
            // 
            this.txtTenThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenThuongHieu.Location = new System.Drawing.Point(148, 84);
            this.txtTenThuongHieu.Name = "txtTenThuongHieu";
            this.txtTenThuongHieu.Size = new System.Drawing.Size(221, 34);
            this.txtTenThuongHieu.TabIndex = 3;
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Controls.Add(this.lblTimKiemTitle);
            this.grpTimKiem.Controls.Add(this.txtTimKiem);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpTimKiem.Location = new System.Drawing.Point(455, 98);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(603, 88);
            this.grpTimKiem.TabIndex = 2;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm";
            // 
            // lblTimKiemTitle
            // 
            this.lblTimKiemTitle.AutoSize = true;
            this.lblTimKiemTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTimKiemTitle.Location = new System.Drawing.Point(19, 39);
            this.lblTimKiemTitle.Name = "lblTimKiemTitle";
            this.lblTimKiemTitle.Size = new System.Drawing.Size(82, 28);
            this.lblTimKiemTitle.TabIndex = 0;
            this.lblTimKiemTitle.Text = "Từ khóa";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(86, 35);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(377, 34);
            this.txtTimKiem.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(96)))), ((int)(((byte)(158)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(480, 33);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(101, 39);
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
            this.grpChucNang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpChucNang.Location = new System.Drawing.Point(455, 195);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new System.Drawing.Size(603, 124);
            this.grpChucNang.TabIndex = 3;
            this.grpChucNang.TabStop = false;
            this.grpChucNang.Text = "Chức năng";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(23, 34);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(92, 34);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(123, 34);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(92, 34);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(223, 34);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 34);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(323, 34);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(92, 34);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(423, 34);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(92, 34);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(23, 76);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(92, 34);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvThuongHieu);
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDanhSach.Location = new System.Drawing.Point(24, 332);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(1034, 327);
            this.grpDanhSach.TabIndex = 4;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách thương hiệu";
            // 
            // dgvThuongHieu
            // 
            this.dgvThuongHieu.AllowUserToAddRows = false;
            this.dgvThuongHieu.AllowUserToDeleteRows = false;
            this.dgvThuongHieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuongHieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvThuongHieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuongHieu.Location = new System.Drawing.Point(16, 29);
            this.dgvThuongHieu.MultiSelect = false;
            this.dgvThuongHieu.Name = "dgvThuongHieu";
            this.dgvThuongHieu.ReadOnly = true;
            this.dgvThuongHieu.RowHeadersVisible = false;
            this.dgvThuongHieu.RowHeadersWidth = 62;
            this.dgvThuongHieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuongHieu.Size = new System.Drawing.Size(1001, 281);
            this.dgvThuongHieu.TabIndex = 0;
            this.dgvThuongHieu.SelectionChanged += new System.EventHandler(this.dgvThuongHieu_SelectionChanged);
            // 
            // frmThuongHieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1084, 681);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpChucNang);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmThuongHieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
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

        }
    }
}
