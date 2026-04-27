namespace QuanLyCuaHangMayTinh
{
    partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.pnlTabIndicator = new System.Windows.Forms.Panel();
            this.flpTabs = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTabDoanhThu = new System.Windows.Forms.Button();
            this.btnTabSPBanChay = new System.Windows.Forms.Button();
            this.btnTabDonTrangThai = new System.Windows.Forms.Button();
            this.btnTabBieuDo = new System.Windows.Forms.Button();
            this.pnlGapTabsFilter = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.tblFilter = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFrom = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.pnlTo = new System.Windows.Forms.Panel();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.pnlLoai = new System.Windows.Forms.Panel();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.pnlGapFilterStats = new System.Windows.Forms.Panel();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.tblStats = new System.Windows.Forms.TableLayoutPanel();
            this.cardDoanhThu = new System.Windows.Forms.Panel();
            this.lblDoanhThuHint = new System.Windows.Forms.Label();
            this.lblDoanhThuTitle = new System.Windows.Forms.Label();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.cardDonHang = new System.Windows.Forms.Panel();
            this.lblDonHangHint = new System.Windows.Forms.Label();
            this.lblDonHangTitle = new System.Windows.Forms.Label();
            this.lblDonHang = new System.Windows.Forms.Label();
            this.cardTB = new System.Windows.Forms.Panel();
            this.lblTBHint = new System.Windows.Forms.Label();
            this.lblTBTitle = new System.Windows.Forms.Label();
            this.lblTB = new System.Windows.Forms.Label();
            this.pnlGapStatsChart = new System.Windows.Forms.Panel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.chtDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.pnlGapChartGrid = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.flpTabs.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.tblFilter.SuspendLayout();
            this.pnlFrom.SuspendLayout();
            this.pnlTo.SuspendLayout();
            this.pnlLoai.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.tblStats.SuspendLayout();
            this.cardDoanhThu.SuspendLayout();
            this.cardDonHang.SuspendLayout();
            this.cardTB.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtDoanhThu)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlHeader.Size = new System.Drawing.Size(1200, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(385, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(525, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Báo cáo & Thống kê Doanh Thu ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.White;
            this.pnlTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTabs.Controls.Add(this.pnlTabIndicator);
            this.pnlTabs.Controls.Add(this.flpTabs);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(16, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Padding = new System.Windows.Forms.Padding(12, 6, 12, 0);
            this.pnlTabs.Size = new System.Drawing.Size(1168, 53);
            this.pnlTabs.TabIndex = 0;
            // 
            // pnlTabIndicator
            // 
            this.pnlTabIndicator.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlTabIndicator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTabIndicator.Enabled = false;
            this.pnlTabIndicator.Location = new System.Drawing.Point(12, 48);
            this.pnlTabIndicator.Name = "pnlTabIndicator";
            this.pnlTabIndicator.Size = new System.Drawing.Size(1142, 3);
            this.pnlTabIndicator.TabIndex = 1;
            // 
            // flpTabs
            // 
            this.flpTabs.Controls.Add(this.btnTabDoanhThu);
            this.flpTabs.Controls.Add(this.btnTabSPBanChay);
            this.flpTabs.Controls.Add(this.btnTabDonTrangThai);
            this.flpTabs.Controls.Add(this.btnTabBieuDo);
            this.flpTabs.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.flpTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTabs.Enabled = false;
            this.flpTabs.Location = new System.Drawing.Point(12, 6);
            this.flpTabs.Margin = new System.Windows.Forms.Padding(0);
            this.flpTabs.Name = "flpTabs";
            this.flpTabs.Size = new System.Drawing.Size(1142, 45);
            this.flpTabs.TabIndex = 0;
            this.flpTabs.WrapContents = false;
            // 
            // btnTabDoanhThu
            // 
            this.btnTabDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnTabDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDoanhThu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnTabDoanhThu.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnTabDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.btnTabDoanhThu.Margin = new System.Windows.Forms.Padding(0);
            this.btnTabDoanhThu.Name = "btnTabDoanhThu";
            this.btnTabDoanhThu.Size = new System.Drawing.Size(155, 43);
            this.btnTabDoanhThu.TabIndex = 0;
            this.btnTabDoanhThu.Text = "Doanh thu";
            this.btnTabDoanhThu.UseVisualStyleBackColor = true;
            // 
            // btnTabSPBanChay
            // 
            this.btnTabSPBanChay.FlatAppearance.BorderSize = 0;
            this.btnTabSPBanChay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabSPBanChay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabSPBanChay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.btnTabSPBanChay.Location = new System.Drawing.Point(155, 0);
            this.btnTabSPBanChay.Margin = new System.Windows.Forms.Padding(0);
            this.btnTabSPBanChay.Name = "btnTabSPBanChay";
            this.btnTabSPBanChay.Size = new System.Drawing.Size(132, 43);
            this.btnTabSPBanChay.TabIndex = 1;
            this.btnTabSPBanChay.Text = "SP bán chạy";
            this.btnTabSPBanChay.UseVisualStyleBackColor = true;
            // 
            // btnTabDonTrangThai
            // 
            this.btnTabDonTrangThai.FlatAppearance.BorderSize = 0;
            this.btnTabDonTrangThai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDonTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabDonTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.btnTabDonTrangThai.Location = new System.Drawing.Point(287, 0);
            this.btnTabDonTrangThai.Margin = new System.Windows.Forms.Padding(0);
            this.btnTabDonTrangThai.Name = "btnTabDonTrangThai";
            this.btnTabDonTrangThai.Size = new System.Drawing.Size(188, 43);
            this.btnTabDonTrangThai.TabIndex = 2;
            this.btnTabDonTrangThai.Text = "Đơn theo trạng thái";
            this.btnTabDonTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnTabBieuDo
            // 
            this.btnTabBieuDo.FlatAppearance.BorderSize = 0;
            this.btnTabBieuDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabBieuDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabBieuDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.btnTabBieuDo.Location = new System.Drawing.Point(475, 0);
            this.btnTabBieuDo.Margin = new System.Windows.Forms.Padding(0);
            this.btnTabBieuDo.Name = "btnTabBieuDo";
            this.btnTabBieuDo.Size = new System.Drawing.Size(115, 43);
            this.btnTabBieuDo.TabIndex = 3;
            this.btnTabBieuDo.Text = "Biểu đồ";
            this.btnTabBieuDo.UseVisualStyleBackColor = true;
            // 
            // pnlGapTabsFilter
            // 
            this.pnlGapTabsFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlGapTabsFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGapTabsFilter.Location = new System.Drawing.Point(16, 53);
            this.pnlGapTabsFilter.Name = "pnlGapTabsFilter";
            this.pnlGapTabsFilter.Size = new System.Drawing.Size(1168, 17);
            this.pnlGapTabsFilter.TabIndex = 1;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.tblFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(16, 70);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlFilter.Size = new System.Drawing.Size(1168, 121);
            this.pnlFilter.TabIndex = 2;
            // 
            // tblFilter
            // 
            this.tblFilter.ColumnCount = 4;
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tblFilter.Controls.Add(this.pnlFrom, 0, 0);
            this.tblFilter.Controls.Add(this.pnlTo, 1, 0);
            this.tblFilter.Controls.Add(this.pnlLoai, 2, 0);
            this.tblFilter.Controls.Add(this.flpActions, 3, 0);
            this.tblFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFilter.Location = new System.Drawing.Point(16, 12);
            this.tblFilter.Name = "tblFilter";
            this.tblFilter.RowCount = 1;
            this.tblFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFilter.Size = new System.Drawing.Size(1134, 95);
            this.tblFilter.TabIndex = 0;
            // 
            // pnlFrom
            // 
            this.pnlFrom.Controls.Add(this.dtpFrom);
            this.pnlFrom.Controls.Add(this.lblFrom);
            this.pnlFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrom.Location = new System.Drawing.Point(0, 0);
            this.pnlFrom.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlFrom.Name = "pnlFrom";
            this.pnlFrom.Size = new System.Drawing.Size(262, 95);
            this.pnlFrom.TabIndex = 0;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(0, 28);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(250, 34);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblFrom.Location = new System.Drawing.Point(0, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(85, 28);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ ngày";
            // 
            // pnlTo
            // 
            this.pnlTo.Controls.Add(this.dtpTo);
            this.pnlTo.Controls.Add(this.lblTo);
            this.pnlTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTo.Location = new System.Drawing.Point(272, 0);
            this.pnlTo.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlTo.Name = "pnlTo";
            this.pnlTo.Size = new System.Drawing.Size(262, 95);
            this.pnlTo.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(0, 28);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(250, 34);
            this.dtpTo.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblTo.Location = new System.Drawing.Point(0, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(99, 28);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "Đến ngày";
            // 
            // pnlLoai
            // 
            this.pnlLoai.Controls.Add(this.cboLoai);
            this.pnlLoai.Controls.Add(this.lblLoai);
            this.pnlLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoai.Location = new System.Drawing.Point(544, 0);
            this.pnlLoai.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlLoai.Name = "pnlLoai";
            this.pnlLoai.Size = new System.Drawing.Size(216, 95);
            this.pnlLoai.TabIndex = 2;
            // 
            // cboLoai
            // 
            this.cboLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Items.AddRange(new object[] {
            "Theo ngày",
            "Theo tháng"});
            this.cboLoai.Location = new System.Drawing.Point(0, 27);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(202, 36);
            this.cboLoai.TabIndex = 1;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblLoai.Location = new System.Drawing.Point(0, 0);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(58, 28);
            this.lblLoai.TabIndex = 0;
            this.lblLoai.Text = "Theo";
            // 
            // flpActions
            // 
            this.flpActions.Controls.Add(this.btnXem);
            this.flpActions.Controls.Add(this.btnInBaoCao);
            this.flpActions.Controls.Add(this.btnXuatExcel);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpActions.Location = new System.Drawing.Point(770, 0);
            this.flpActions.Margin = new System.Windows.Forms.Padding(0);
            this.flpActions.Name = "flpActions";
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 28, 0, 0);
            this.flpActions.Size = new System.Drawing.Size(364, 95);
            this.flpActions.TabIndex = 3;
            this.flpActions.WrapContents = false;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnXem.FlatAppearance.BorderSize = 0;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(0, 28);
            this.btnXem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(161, 35);
            this.btnXem.TabIndex = 0;
            this.btnXem.Text = "Xem báo cáo";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.BackColor = System.Drawing.Color.White;
            this.btnInBaoCao.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnInBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBaoCao.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnInBaoCao.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnInBaoCao.Location = new System.Drawing.Point(171, 28);
            this.btnInBaoCao.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(54, 35);
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
            this.btnXuatExcel.Location = new System.Drawing.Point(235, 28);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(129, 35);
            this.btnXuatExcel.TabIndex = 2;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // pnlGapFilterStats
            // 
            this.pnlGapFilterStats.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlGapFilterStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGapFilterStats.Location = new System.Drawing.Point(16, 191);
            this.pnlGapFilterStats.Name = "pnlGapFilterStats";
            this.pnlGapFilterStats.Size = new System.Drawing.Size(1168, 12);
            this.pnlGapFilterStats.TabIndex = 3;
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStats.Controls.Add(this.tblStats);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(16, 203);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlStats.Size = new System.Drawing.Size(1168, 110);
            this.pnlStats.TabIndex = 4;
            // 
            // tblStats
            // 
            this.tblStats.ColumnCount = 3;
            this.tblStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblStats.Controls.Add(this.cardDoanhThu, 0, 0);
            this.tblStats.Controls.Add(this.cardDonHang, 1, 0);
            this.tblStats.Controls.Add(this.cardTB, 2, 0);
            this.tblStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStats.Location = new System.Drawing.Point(16, 12);
            this.tblStats.Name = "tblStats";
            this.tblStats.RowCount = 1;
            this.tblStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblStats.Size = new System.Drawing.Size(1134, 84);
            this.tblStats.TabIndex = 0;
            // 
            // cardDoanhThu
            // 
            this.cardDoanhThu.BackColor = System.Drawing.Color.White;
            this.cardDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardDoanhThu.Controls.Add(this.lblDoanhThuHint);
            this.cardDoanhThu.Controls.Add(this.lblDoanhThuTitle);
            this.cardDoanhThu.Controls.Add(this.lblDoanhThu);
            this.cardDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.cardDoanhThu.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cardDoanhThu.Name = "cardDoanhThu";
            this.cardDoanhThu.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.cardDoanhThu.Size = new System.Drawing.Size(368, 84);
            this.cardDoanhThu.TabIndex = 0;
            // 
            // lblDoanhThuHint
            // 
            this.lblDoanhThuHint.AutoSize = true;
            this.lblDoanhThuHint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDoanhThuHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblDoanhThuHint.Location = new System.Drawing.Point(14, 52);
            this.lblDoanhThuHint.Name = "lblDoanhThuHint";
            this.lblDoanhThuHint.Size = new System.Drawing.Size(231, 28);
            this.lblDoanhThuHint.TabIndex = 2;
            this.lblDoanhThuHint.Text = "Tổng doanh thu trong kỳ";
            // 
            // lblDoanhThuTitle
            // 
            this.lblDoanhThuTitle.AutoSize = true;
            this.lblDoanhThuTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblDoanhThuTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblDoanhThuTitle.Location = new System.Drawing.Point(14, 8);
            this.lblDoanhThuTitle.Name = "lblDoanhThuTitle";
            this.lblDoanhThuTitle.Size = new System.Drawing.Size(160, 28);
            this.lblDoanhThuTitle.TabIndex = 0;
            this.lblDoanhThuTitle.Text = "Tổng doanh thu";
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblDoanhThu.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDoanhThu.Location = new System.Drawing.Point(14, 29);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(23, 28);
            this.lblDoanhThu.TabIndex = 1;
            this.lblDoanhThu.Text = "0";
            // 
            // cardDonHang
            // 
            this.cardDonHang.BackColor = System.Drawing.Color.White;
            this.cardDonHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardDonHang.Controls.Add(this.lblDonHangHint);
            this.cardDonHang.Controls.Add(this.lblDonHangTitle);
            this.cardDonHang.Controls.Add(this.lblDonHang);
            this.cardDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDonHang.Location = new System.Drawing.Point(378, 0);
            this.cardDonHang.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cardDonHang.Name = "cardDonHang";
            this.cardDonHang.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.cardDonHang.Size = new System.Drawing.Size(368, 84);
            this.cardDonHang.TabIndex = 1;
            // 
            // lblDonHangHint
            // 
            this.lblDonHangHint.AutoSize = true;
            this.lblDonHangHint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDonHangHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblDonHangHint.Location = new System.Drawing.Point(14, 52);
            this.lblDonHangHint.Name = "lblDonHangHint";
            this.lblDonHangHint.Size = new System.Drawing.Size(203, 28);
            this.lblDonHangHint.TabIndex = 2;
            this.lblDonHangHint.Text = "Số đơn hàng trong kỳ";
            // 
            // lblDonHangTitle
            // 
            this.lblDonHangTitle.AutoSize = true;
            this.lblDonHangTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblDonHangTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblDonHangTitle.Location = new System.Drawing.Point(14, 8);
            this.lblDonHangTitle.Name = "lblDonHangTitle";
            this.lblDonHangTitle.Size = new System.Drawing.Size(129, 28);
            this.lblDonHangTitle.TabIndex = 0;
            this.lblDonHangTitle.Text = "Số đơn hàng";
            // 
            // lblDonHang
            // 
            this.lblDonHang.AutoSize = true;
            this.lblDonHang.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblDonHang.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDonHang.Location = new System.Drawing.Point(14, 29);
            this.lblDonHang.Name = "lblDonHang";
            this.lblDonHang.Size = new System.Drawing.Size(23, 28);
            this.lblDonHang.TabIndex = 1;
            this.lblDonHang.Text = "0";
            // 
            // cardTB
            // 
            this.cardTB.BackColor = System.Drawing.Color.White;
            this.cardTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTB.Controls.Add(this.lblTBHint);
            this.cardTB.Controls.Add(this.lblTBTitle);
            this.cardTB.Controls.Add(this.lblTB);
            this.cardTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTB.Location = new System.Drawing.Point(756, 0);
            this.cardTB.Margin = new System.Windows.Forms.Padding(0);
            this.cardTB.Name = "cardTB";
            this.cardTB.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.cardTB.Size = new System.Drawing.Size(378, 84);
            this.cardTB.TabIndex = 2;
            // 
            // lblTBHint
            // 
            this.lblTBHint.AutoSize = true;
            this.lblTBHint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTBHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblTBHint.Location = new System.Drawing.Point(14, 52);
            this.lblTBHint.Name = "lblTBHint";
            this.lblTBHint.Size = new System.Drawing.Size(214, 28);
            this.lblTBHint.TabIndex = 2;
            this.lblTBHint.Text = "TB / đơn hàng trong kỳ";
            // 
            // lblTBTitle
            // 
            this.lblTBTitle.AutoSize = true;
            this.lblTBTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTBTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblTBTitle.Location = new System.Drawing.Point(14, 8);
            this.lblTBTitle.Name = "lblTBTitle";
            this.lblTBTitle.Size = new System.Drawing.Size(170, 28);
            this.lblTBTitle.TabIndex = 0;
            this.lblTBTitle.Text = "TB mỗi đơn hàng";
            // 
            // lblTB
            // 
            this.lblTB.AutoSize = true;
            this.lblTB.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTB.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTB.Location = new System.Drawing.Point(14, 29);
            this.lblTB.Name = "lblTB";
            this.lblTB.Size = new System.Drawing.Size(23, 28);
            this.lblTB.TabIndex = 1;
            this.lblTB.Text = "0";
            // 
            // pnlGapStatsChart
            // 
            this.pnlGapStatsChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlGapStatsChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGapStatsChart.Location = new System.Drawing.Point(16, 313);
            this.pnlGapStatsChart.Name = "pnlGapStatsChart";
            this.pnlGapStatsChart.Size = new System.Drawing.Size(1168, 12);
            this.pnlGapStatsChart.TabIndex = 5;
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChart.Controls.Add(this.chtDoanhThu);
            this.pnlChart.Controls.Add(this.lblChartTitle);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart.Location = new System.Drawing.Point(16, 325);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(16, 12, 16, 16);
            this.pnlChart.Size = new System.Drawing.Size(1168, 244);
            this.pnlChart.TabIndex = 6;
            // 
            // chtDoanhThu
            // 
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.Name = "ChartArea1";
            this.chtDoanhThu.ChartAreas.Add(chartArea3);
            this.chtDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.BackColor = System.Drawing.Color.White;
            legend3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            legend3.Name = "Legend1";
            this.chtDoanhThu.Legends.Add(legend3);
            this.chtDoanhThu.Location = new System.Drawing.Point(16, 35);
            this.chtDoanhThu.Name = "chtDoanhThu";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "DoanhThu";
            this.chtDoanhThu.Series.Add(series3);
            this.chtDoanhThu.Size = new System.Drawing.Size(1134, 191);
            this.chtDoanhThu.TabIndex = 1;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(63)))));
            this.lblChartTitle.Location = new System.Drawing.Point(16, 12);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(1134, 23);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "BIỂU ĐỒ DOANH THU (THEO NGÀY)";
            // 
            // pnlGapChartGrid
            // 
            this.pnlGapChartGrid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlGapChartGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGapChartGrid.Location = new System.Drawing.Point(16, 569);
            this.pnlGapChartGrid.Name = "pnlGapChartGrid";
            this.pnlGapChartGrid.Size = new System.Drawing.Size(1168, 12);
            this.pnlGapChartGrid.TabIndex = 7;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.dgv);
            this.pnlGrid.Controls.Add(this.lblGridTitle);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(16, 581);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16, 12, 16, 16);
            this.pnlGrid.Size = new System.Drawing.Size(1168, 228);
            this.pnlGrid.TabIndex = 8;
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.ColumnHeadersHeight = 32;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Enabled = false;
            this.dgv.Location = new System.Drawing.Point(16, 47);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.Size = new System.Drawing.Size(1134, 163);
            this.dgv.TabIndex = 1;
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
            this.lblGridTitle.Text = "CHI TIẾT DOANH THU";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Controls.Add(this.pnlGrid);
            this.pnlContent.Controls.Add(this.pnlGapChartGrid);
            this.pnlContent.Controls.Add(this.pnlChart);
            this.pnlContent.Controls.Add(this.pnlGapStatsChart);
            this.pnlContent.Controls.Add(this.pnlStats);
            this.pnlContent.Controls.Add(this.pnlGapFilterStats);
            this.pnlContent.Controls.Add(this.pnlFilter);
            this.pnlContent.Controls.Add(this.pnlGapTabsFilter);
            this.pnlContent.Controls.Add(this.pnlTabs);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 75);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(16, 0, 16, 16);
            this.pnlContent.Size = new System.Drawing.Size(1200, 825);
            this.pnlContent.TabIndex = 1;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1200, 900);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBaoCao";
            this.Text = "frmBaoCao";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTabs.ResumeLayout(false);
            this.flpTabs.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.tblFilter.ResumeLayout(false);
            this.pnlFrom.ResumeLayout(false);
            this.pnlFrom.PerformLayout();
            this.pnlTo.ResumeLayout(false);
            this.pnlTo.PerformLayout();
            this.pnlLoai.ResumeLayout(false);
            this.pnlLoai.PerformLayout();
            this.flpActions.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.tblStats.ResumeLayout(false);
            this.cardDoanhThu.ResumeLayout(false);
            this.cardDoanhThu.PerformLayout();
            this.cardDonHang.ResumeLayout(false);
            this.cardDonHang.PerformLayout();
            this.cardTB.ResumeLayout(false);
            this.cardTB.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtDoanhThu)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Panel pnlTabIndicator;
        private System.Windows.Forms.FlowLayoutPanel flpTabs;
        private System.Windows.Forms.Button btnTabDoanhThu;
        private System.Windows.Forms.Button btnTabSPBanChay;
        private System.Windows.Forms.Button btnTabDonTrangThai;
        private System.Windows.Forms.Button btnTabBieuDo;
        private System.Windows.Forms.Panel pnlGapTabsFilter;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TableLayoutPanel tblFilter;
        private System.Windows.Forms.Panel pnlFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Panel pnlTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Panel pnlLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Panel pnlGapFilterStats;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.TableLayoutPanel tblStats;
        private System.Windows.Forms.Panel cardDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuHint;
        private System.Windows.Forms.Label lblDoanhThuTitle;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Panel cardDonHang;
        private System.Windows.Forms.Label lblDonHangHint;
        private System.Windows.Forms.Label lblDonHangTitle;
        private System.Windows.Forms.Label lblDonHang;
        private System.Windows.Forms.Panel cardTB;
        private System.Windows.Forms.Label lblTBHint;
        private System.Windows.Forms.Label lblTBTitle;
        private System.Windows.Forms.Label lblTB;
        private System.Windows.Forms.Panel pnlGapStatsChart;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtDoanhThu;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.Panel pnlGapChartGrid;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Panel pnlContent;
    }
}