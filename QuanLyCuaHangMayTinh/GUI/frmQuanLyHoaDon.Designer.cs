namespace QuanLyCuaHangMayTinh.GUI
{
    partial class frmQuanLyHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTu = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblTongHD = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.btnHuyHoaDon = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1200, 50);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(349, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ HÓA ĐƠN BÁN";
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.lblTuKhoa);
            this.gbFilter.Controls.Add(this.txtTimKiem);
            this.gbFilter.Controls.Add(this.lblTrangThai);
            this.gbFilter.Controls.Add(this.cboTrangThai);
            this.gbFilter.Controls.Add(this.lblTu);
            this.gbFilter.Controls.Add(this.dtpFrom);
            this.gbFilter.Controls.Add(this.lblDen);
            this.gbFilter.Controls.Add(this.dtpTo);
            this.gbFilter.Controls.Add(this.btnTimKiem);
            this.gbFilter.Controls.Add(this.btnBoLoc);
            this.gbFilter.Controls.Add(this.btnLamMoi);
            this.gbFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.gbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(80)))));
            this.gbFilter.Location = new System.Drawing.Point(15, 65);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1170, 75);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Tìm kiếm và Lọc";
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(15, 35);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(83, 25);
            this.lblTuKhoa.TabIndex = 0;
            this.lblTuKhoa.Text = "Từ khóa:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(85, 31);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 34);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(305, 35);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 25);
            this.lblTrangThai.TabIndex = 2;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.Location = new System.Drawing.Point(385, 31);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(140, 36);
            this.cboTrangThai.TabIndex = 3;
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(545, 35);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(37, 25);
            this.lblTu.TabIndex = 4;
            this.lblTu.Text = "Từ:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(580, 31);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 34);
            this.dtpFrom.TabIndex = 5;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(725, 35);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(50, 25);
            this.lblDen.TabIndex = 6;
            this.lblDen.Text = "Đến:";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(770, 31);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 34);
            this.dtpTo.TabIndex = 7;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(920, 28);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(70, 33);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = " Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.BackColor = System.Drawing.Color.Gray;
            this.btnBoLoc.FlatAppearance.BorderSize = 0;
            this.btnBoLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBoLoc.ForeColor = System.Drawing.Color.White;
            this.btnBoLoc.Location = new System.Drawing.Point(995, 28);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(65, 33);
            this.btnBoLoc.TabIndex = 9;
            this.btnBoLoc.Text = "Bỏ lọc";
            this.btnBoLoc.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Gray;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(1065, 28);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(105, 33);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = " Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeight = 35;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoaDon.EnableHeadersVisualStyles = false;
            this.dgvHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvHoaDon.Location = new System.Drawing.Point(15, 155);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 62;
            this.dgvHoaDon.RowTemplate.Height = 28;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1170, 500);
            this.dgvHoaDon.TabIndex = 2;
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlAction.Controls.Add(this.lblHint);
            this.pnlAction.Controls.Add(this.lblTongHD);
            this.pnlAction.Controls.Add(this.lblTongTien);
            this.pnlAction.Controls.Add(this.btnXemChiTiet);
            this.pnlAction.Controls.Add(this.btnHuyHoaDon);
            this.pnlAction.Controls.Add(this.btnXuatExcel);
            this.pnlAction.Controls.Add(this.btnDong);
            this.pnlAction.Location = new System.Drawing.Point(15, 670);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(1170, 75);
            this.pnlAction.TabIndex = 3;
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(15, 8);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(420, 25);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "Click vào dòng để xem, double-click để xem chi tiết.";
            // 
            // lblTongHD
            // 
            this.lblTongHD.AutoSize = true;
            this.lblTongHD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(80)))));
            this.lblTongHD.Location = new System.Drawing.Point(15, 35);
            this.lblTongHD.Name = "lblTongHD";
            this.lblTongHD.Size = new System.Drawing.Size(168, 28);
            this.lblTongHD.TabIndex = 1;
            this.lblTongHD.Text = "Tổng: 0 hóa đơn";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongTien.Location = new System.Drawing.Point(200, 35);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(132, 28);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "Đã chọn: 0 đ";
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnXemChiTiet.FlatAppearance.BorderSize = 0;
            this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(569, 22);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(141, 38);
            this.btnXemChiTiet.TabIndex = 3;
            this.btnXemChiTiet.Text = " Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = false;
            // 
            // btnHuyHoaDon
            // 
            this.btnHuyHoaDon.BackColor = System.Drawing.Color.Gray;
            this.btnHuyHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHuyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnHuyHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHuyHoaDon.Location = new System.Drawing.Point(720, 22);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(130, 38);
            this.btnHuyHoaDon.TabIndex = 4;
            this.btnHuyHoaDon.Text = "✕ Hủy hóa đơn";
            this.btnHuyHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(860, 22);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(130, 38);
            this.btnXuatExcel.TabIndex = 5;
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Gray;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1000, 22);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 38);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // frmQuanLyHoaDon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.pnlTitle);
            this.Name = "frmQuanLyHoaDon";
            this.Text = "Quản lý hóa đơn";
            this.Load += new System.EventHandler(this.frmQuanLyHoaDon_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnlAction.ResumeLayout(false);
            this.pnlAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnBoLoc;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblTongHD;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.Button btnHuyHoaDon;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnDong;
    }
}
