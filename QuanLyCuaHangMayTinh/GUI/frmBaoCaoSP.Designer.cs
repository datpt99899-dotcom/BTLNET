namespace QuanLyCuaHangMayTinh.GUI
{
    partial class frmBaoCaoSP
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chtSanPham = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.chtDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlFrom = new System.Windows.Forms.Panel();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTongBan = new System.Windows.Forms.Label();
            this.lblTongNhap = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlLoai = new System.Windows.Forms.Panel();
            this.cboThuongHieu = new System.Windows.Forms.ComboBox();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.pnlTabIndicator = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtSanPham)).BeginInit();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFrom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlLoai.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Location = new System.Drawing.Point(1, 1);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlHeader.Size = new System.Drawing.Size(1200, 75);
            this.pnlHeader.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(268, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(665, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Báo cáo & Thống kê Sản phẩm bán chạy ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chtSanPham
            // 
            chartArea1.Name = "ChartArea1";
            this.chtSanPham.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtSanPham.Legends.Add(legend1);
            this.chtSanPham.Location = new System.Drawing.Point(30, 44);
            this.chtSanPham.Name = "chtSanPham";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtSanPham.Series.Add(series1);
            this.chtSanPham.Size = new System.Drawing.Size(465, 199);
            this.chtSanPham.TabIndex = 2;
            this.chtSanPham.Text = "chart2";
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChart.Controls.Add(this.chtDoanhThu);
            this.pnlChart.Controls.Add(this.chtSanPham);
            this.pnlChart.Controls.Add(this.lblChartTitle);
            this.pnlChart.Location = new System.Drawing.Point(16, 314);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(16, 12, 16, 16);
            this.pnlChart.Size = new System.Drawing.Size(1168, 260);
            this.pnlChart.TabIndex = 6;
            // 
            // chtDoanhThu
            // 
            chartArea2.Name = "ChartArea1";
            this.chtDoanhThu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chtDoanhThu.Legends.Add(legend2);
            this.chtDoanhThu.Location = new System.Drawing.Point(626, 44);
            this.chtDoanhThu.Name = "chtDoanhThu";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtDoanhThu.Series.Add(series2);
            this.chtDoanhThu.Size = new System.Drawing.Size(465, 199);
            this.chtDoanhThu.TabIndex = 2;
            this.chtDoanhThu.Text = "chart2";
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblChartTitle.Location = new System.Drawing.Point(16, 12);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(1134, 29);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "BIỂU ĐỒ THỐNG KÊ SẢN PHẨM BÁN CHẠY VÀ DOANH THU TƯƠNG ỨNG";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvChiTiet.ColumnHeadersHeight = 32;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Enabled = false;
            this.dgvChiTiet.Location = new System.Drawing.Point(16, 47);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 62;
            this.dgvChiTiet.Size = new System.Drawing.Size(1134, 248);
            this.dgvChiTiet.TabIndex = 1;
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblGridTitle.Location = new System.Drawing.Point(16, 12);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(1134, 35);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "CHI TIẾT DANH SÁCH SẢN PHẨM BÁN CHẠY ";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Controls.Add(this.pnlGrid);
            this.pnlContent.Controls.Add(this.pnlChart);
            this.pnlContent.Controls.Add(this.pnlFilter);
            this.pnlContent.Controls.Add(this.pnlTabs);
            this.pnlContent.Location = new System.Drawing.Point(1, 79);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(16, 0, 16, 16);
            this.pnlContent.Size = new System.Drawing.Size(1200, 937);
            this.pnlContent.TabIndex = 7;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.dgvChiTiet);
            this.pnlGrid.Controls.Add(this.lblGridTitle);
            this.pnlGrid.Location = new System.Drawing.Point(16, 584);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16, 12, 16, 16);
            this.pnlGrid.Size = new System.Drawing.Size(1168, 313);
            this.pnlGrid.TabIndex = 8;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.Snow;
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.pnlFrom);
            this.pnlFilter.Controls.Add(this.btnThoat);
            this.pnlFilter.Controls.Add(this.btnLamMoi);
            this.pnlFilter.Controls.Add(this.btnXemBaoCao);
            this.pnlFilter.Controls.Add(this.panel1);
            this.pnlFilter.Controls.Add(this.pnlLoai);
            this.pnlFilter.Controls.Add(this.btnInBaoCao);
            this.pnlFilter.Controls.Add(this.btnXuatExcel);
            this.pnlFilter.Location = new System.Drawing.Point(16, 109);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlFilter.Size = new System.Drawing.Size(1168, 175);
            this.pnlFilter.TabIndex = 2;
            // 
            // pnlFrom
            // 
            this.pnlFrom.Controls.Add(this.dtpTo);
            this.pnlFrom.Controls.Add(this.lblTo);
            this.pnlFrom.Controls.Add(this.dtpFrom);
            this.pnlFrom.Controls.Add(this.lblFrom);
            this.pnlFrom.Location = new System.Drawing.Point(16, 12);
            this.pnlFrom.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlFrom.Name = "pnlFrom";
            this.pnlFrom.Size = new System.Drawing.Size(279, 149);
            this.pnlFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(14, 106);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(250, 34);
            this.dtpTo.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblTo.Location = new System.Drawing.Point(14, 74);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(99, 28);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "Đến ngày";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(14, 28);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(250, 34);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblFrom.Location = new System.Drawing.Point(14, -4);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(85, 28);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ ngày";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.DarkGray;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnThoat.ForeColor = System.Drawing.SystemColors.Control;
            this.btnThoat.Location = new System.Drawing.Point(962, 77);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(129, 46);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát ";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLamMoi.Location = new System.Drawing.Point(791, 77);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(161, 46);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới ";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.MediumBlue;
            this.btnXemBaoCao.FlatAppearance.BorderSize = 0;
            this.btnXemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(791, 12);
            this.btnXemBaoCao.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(161, 46);
            this.btnXemBaoCao.TabIndex = 0;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTongBan);
            this.panel1.Controls.Add(this.lblTongNhap);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(547, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 149);
            this.panel1.TabIndex = 2;
            // 
            // lblTongBan
            // 
            this.lblTongBan.AutoSize = true;
            this.lblTongBan.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongBan.ForeColor = System.Drawing.Color.Red;
            this.lblTongBan.Location = new System.Drawing.Point(7, 112);
            this.lblTongBan.Name = "lblTongBan";
            this.lblTongBan.Size = new System.Drawing.Size(31, 30);
            this.lblTongBan.TabIndex = 0;
            this.lblTongBan.Text = "0 ";
            // 
            // lblTongNhap
            // 
            this.lblTongNhap.AutoSize = true;
            this.lblTongNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongNhap.ForeColor = System.Drawing.Color.Red;
            this.lblTongNhap.Location = new System.Drawing.Point(7, 36);
            this.lblTongNhap.Name = "lblTongNhap";
            this.lblTongNhap.Size = new System.Drawing.Size(31, 30);
            this.lblTongNhap.TabIndex = 0;
            this.lblTongNhap.Text = "0 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.label2.Location = new System.Drawing.Point(-5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng sản phẩm nhập vào ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng sản phẩm bán ra ";
            // 
            // pnlLoai
            // 
            this.pnlLoai.Controls.Add(this.cboThuongHieu);
            this.pnlLoai.Controls.Add(this.cboLoai);
            this.pnlLoai.Controls.Add(this.label1);
            this.pnlLoai.Controls.Add(this.lblLoai);
            this.pnlLoai.Location = new System.Drawing.Point(305, 12);
            this.pnlLoai.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlLoai.Name = "pnlLoai";
            this.pnlLoai.Size = new System.Drawing.Size(232, 149);
            this.pnlLoai.TabIndex = 2;
            // 
            // cboThuongHieu
            // 
            this.cboThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThuongHieu.FormattingEnabled = true;
            this.cboThuongHieu.Items.AddRange(new object[] {
            "Theo ngày",
            "Theo tháng"});
            this.cboThuongHieu.Location = new System.Drawing.Point(15, 104);
            this.cboThuongHieu.Name = "cboThuongHieu";
            this.cboThuongHieu.Size = new System.Drawing.Size(202, 36);
            this.cboThuongHieu.TabIndex = 1;
            // 
            // cboLoai
            // 
            this.cboLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Items.AddRange(new object[] {
            "Theo ngày",
            "Theo tháng"});
            this.cboLoai.Location = new System.Drawing.Point(15, 28);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(202, 36);
            this.cboLoai.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.label1.Location = new System.Drawing.Point(15, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thương hiệu ";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblLoai.Location = new System.Drawing.Point(15, -3);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(150, 28);
            this.lblLoai.TabIndex = 0;
            this.lblLoai.Text = "Loại sản phẩm ";
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.BackColor = System.Drawing.Color.White;
            this.btnInBaoCao.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnInBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBaoCao.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnInBaoCao.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnInBaoCao.Location = new System.Drawing.Point(1104, 12);
            this.btnInBaoCao.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(54, 46);
            this.btnInBaoCao.TabIndex = 1;
            this.btnInBaoCao.Text = "In";
            this.btnInBaoCao.UseVisualStyleBackColor = false;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnXuatExcel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(962, 12);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(129, 46);
            this.btnXuatExcel.TabIndex = 2;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.White;
            this.pnlTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTabs.Controls.Add(this.pnlTabIndicator);
            this.pnlTabs.Location = new System.Drawing.Point(0, -1);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Padding = new System.Windows.Forms.Padding(12, 6, 12, 0);
            this.pnlTabs.Size = new System.Drawing.Size(1200, 88);
            this.pnlTabs.TabIndex = 0;
            // 
            // pnlTabIndicator
            // 
            this.pnlTabIndicator.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlTabIndicator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTabIndicator.Enabled = false;
            this.pnlTabIndicator.Location = new System.Drawing.Point(12, 83);
            this.pnlTabIndicator.Name = "pnlTabIndicator";
            this.pnlTabIndicator.Size = new System.Drawing.Size(1174, 3);
            this.pnlTabIndicator.TabIndex = 1;
            // 
            // frmBaoCaoSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 988);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlContent);
            this.Name = "frmBaoCaoSP";
            this.Text = "frmBaoCaoSP";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtSanPham)).EndInit();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFrom.ResumeLayout(false);
            this.pnlFrom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLoai.ResumeLayout(false);
            this.pnlLoai.PerformLayout();
            this.pnlTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtSanPham;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Panel pnlLoai;
        private System.Windows.Forms.ComboBox cboThuongHieu;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Panel pnlTabIndicator;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTongNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTongBan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtDoanhThu;
    }
}