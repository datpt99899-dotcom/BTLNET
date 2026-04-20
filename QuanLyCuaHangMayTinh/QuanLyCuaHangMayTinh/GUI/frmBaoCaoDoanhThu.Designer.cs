namespace QuanLyCuaHangMayTinh
{
    partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnTaiBaoCao = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.lblBangChu = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.tabSanPham = new System.Windows.Forms.TabPage();
            this.dgvSanPhamBanChay = new System.Windows.Forms.DataGridView();
            this.tabTrangThai = new System.Windows.Forms.TabPage();
            this.dgvTrangThaiDon = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.tabSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamBanChay)).BeginInit();
            this.tabTrangThai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrangThaiDon)).BeginInit();
            this.SuspendLayout();
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1184, 72);
            this.pnlHeader.TabIndex = 0;
            // lblHeader
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1184, 72);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "BÁO CÁO VÀ THỐNG KÊ";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // grpFilter
            this.grpFilter.Controls.Add(this.btnTaiBaoCao);
            this.grpFilter.Controls.Add(this.dtpTo);
            this.grpFilter.Controls.Add(this.lblTo);
            this.grpFilter.Controls.Add(this.dtpFrom);
            this.grpFilter.Controls.Add(this.lblFrom);
            this.grpFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpFilter.Location = new System.Drawing.Point(24, 88);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(1136, 82);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Bộ lọc thời gian";
            // btnTaiBaoCao
            this.btnTaiBaoCao.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnTaiBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaiBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnTaiBaoCao.Location = new System.Drawing.Point(933, 29);
            this.btnTaiBaoCao.Name = "btnTaiBaoCao";
            this.btnTaiBaoCao.Size = new System.Drawing.Size(165, 35);
            this.btnTaiBaoCao.TabIndex = 4;
            this.btnTaiBaoCao.Text = "Tải báo cáo";
            this.btnTaiBaoCao.UseVisualStyleBackColor = false;
            this.btnTaiBaoCao.Click += new System.EventHandler(this.btnTaiBaoCao_Click);
            // dtpTo
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(511, 33);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(180, 30);
            this.dtpTo.TabIndex = 3;
            // lblTo
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTo.Location = new System.Drawing.Point(454, 36);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(39, 23);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "Đến";
            // dtpFrom
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(156, 33);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(180, 30);
            this.dtpFrom.TabIndex = 1;
            // lblFrom
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFrom.Location = new System.Drawing.Point(82, 36);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(31, 23);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ";
            // tabControl1
            this.tabControl1.Controls.Add(this.tabDoanhThu);
            this.tabControl1.Controls.Add(this.tabSanPham);
            this.tabControl1.Controls.Add(this.tabTrangThai);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.Location = new System.Drawing.Point(24, 187);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1136, 445);
            this.tabControl1.TabIndex = 2;
            // tabDoanhThu
            this.tabDoanhThu.Controls.Add(this.lblBangChu);
            this.tabDoanhThu.Controls.Add(this.txtTongDoanhThu);
            this.tabDoanhThu.Controls.Add(this.lblTongDoanhThu);
            this.tabDoanhThu.Controls.Add(this.dgvDoanhThu);
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 32);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoanhThu.Size = new System.Drawing.Size(1128, 409);
            this.tabDoanhThu.TabIndex = 0;
            this.tabDoanhThu.Text = "Doanh thu";
            this.tabDoanhThu.UseVisualStyleBackColor = true;
            // lblBangChu
            this.lblBangChu.AutoSize = true;
            this.lblBangChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblBangChu.Location = new System.Drawing.Point(24, 366);
            this.lblBangChu.Name = "lblBangChu";
            this.lblBangChu.Size = new System.Drawing.Size(87, 23);
            this.lblBangChu.TabIndex = 3;
            this.lblBangChu.Text = "Bằng chữ:";
            // txtTongDoanhThu
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTongDoanhThu.Location = new System.Drawing.Point(918, 360);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(180, 30);
            this.txtTongDoanhThu.TabIndex = 2;
            // lblTongDoanhThu
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(777, 363);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(127, 23);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "Tổng doanh thu";
            // dgvDoanhThu
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(16, 16);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 24;
            this.dgvDoanhThu.Size = new System.Drawing.Size(1082, 328);
            this.dgvDoanhThu.TabIndex = 0;
            // tabSanPham
            this.tabSanPham.Controls.Add(this.dgvSanPhamBanChay);
            this.tabSanPham.Location = new System.Drawing.Point(4, 32);
            this.tabSanPham.Name = "tabSanPham";
            this.tabSanPham.Padding = new System.Windows.Forms.Padding(3);
            this.tabSanPham.Size = new System.Drawing.Size(1128, 409);
            this.tabSanPham.TabIndex = 1;
            this.tabSanPham.Text = "Sản phẩm bán chạy";
            this.tabSanPham.UseVisualStyleBackColor = true;
            // dgvSanPhamBanChay
            this.dgvSanPhamBanChay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPhamBanChay.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPhamBanChay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPhamBanChay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPhamBanChay.Location = new System.Drawing.Point(3, 3);
            this.dgvSanPhamBanChay.Name = "dgvSanPhamBanChay";
            this.dgvSanPhamBanChay.RowHeadersWidth = 51;
            this.dgvSanPhamBanChay.RowTemplate.Height = 24;
            this.dgvSanPhamBanChay.Size = new System.Drawing.Size(1122, 403);
            this.dgvSanPhamBanChay.TabIndex = 0;
            // tabTrangThai
            this.tabTrangThai.Controls.Add(this.dgvTrangThaiDon);
            this.tabTrangThai.Location = new System.Drawing.Point(4, 32);
            this.tabTrangThai.Name = "tabTrangThai";
            this.tabTrangThai.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrangThai.Size = new System.Drawing.Size(1128, 409);
            this.tabTrangThai.TabIndex = 2;
            this.tabTrangThai.Text = "Trạng thái đơn";
            this.tabTrangThai.UseVisualStyleBackColor = true;
            // dgvTrangThaiDon
            this.dgvTrangThaiDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrangThaiDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrangThaiDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrangThaiDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrangThaiDon.Location = new System.Drawing.Point(3, 3);
            this.dgvTrangThaiDon.Name = "dgvTrangThaiDon";
            this.dgvTrangThaiDon.RowHeadersWidth = 51;
            this.dgvTrangThaiDon.RowTemplate.Height = 24;
            this.dgvTrangThaiDon.Size = new System.Drawing.Size(1122, 403);
            this.dgvTrangThaiDon.TabIndex = 0;
            // btnDong
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(995, 649);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(165, 42);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // frmBaoCao
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.pnlHeader.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabDoanhThu.ResumeLayout(false);
            this.tabDoanhThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.tabSanPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamBanChay)).EndInit();
            this.tabTrangThai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrangThaiDon)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button btnTaiBaoCao;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDoanhThu;
        private System.Windows.Forms.TabPage tabSanPham;
        private System.Windows.Forms.TabPage tabTrangThai;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblBangChu;
        private System.Windows.Forms.DataGridView dgvSanPhamBanChay;
        private System.Windows.Forms.DataGridView dgvTrangThaiDon;
        private System.Windows.Forms.Button btnDong;
    }
}
