namespace QuanLyCuaHangMayTinh
{
    partial class frmTonKho
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlTongSP = new System.Windows.Forms.Panel();
            this.lblTongSPTitle = new System.Windows.Forms.Label();
            this.lblTongSPDesc = new System.Windows.Forms.Label();
            this.txtTongSP = new System.Windows.Forms.TextBox();
            this.pnlSapHet = new System.Windows.Forms.Panel();
            this.lblSapHetTitle = new System.Windows.Forms.Label();
            this.lblSapHetDesc = new System.Windows.Forms.Label();
            this.txtSapHet = new System.Windows.Forms.TextBox();
            this.pnlHetHang = new System.Windows.Forms.Panel();
            this.lblHetHangTitle = new System.Windows.Forms.Label();
            this.lblHetHangDesc = new System.Windows.Forms.Label();
            this.txtHetHang = new System.Windows.Forms.TextBox();
            this.pnlTonTB = new System.Windows.Forms.Panel();
            this.lblTonTBTitle = new System.Windows.Forms.Label();
            this.lblTonTBDesc = new System.Windows.Forms.Label();
            this.txtTonTB = new System.Windows.Forms.TextBox();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLoaiSP = new System.Windows.Forms.Label();
            this.cboLoaiSP = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTKiem = new System.Windows.Forms.Button();
            this.btnLMoi = new System.Windows.Forms.Button();
            this.pnlDataGrid = new System.Windows.Forms.Panel();
            this.lblDataGridTitle = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTotalStock = new System.Windows.Forms.Label();
            this.txtTongTon = new System.Windows.Forms.TextBox();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.pnlStats.SuspendLayout();
            this.pnlTongSP.SuspendLayout();
            this.pnlSapHet.SuspendLayout();
            this.pnlHetHang.SuspendLayout();
            this.pnlTonTB.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(23, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(174, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý tồn kho";
            // 
            // pnlStats
            // 
            this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStats.Controls.Add(this.pnlTongSP);
            this.pnlStats.Controls.Add(this.pnlSapHet);
            this.pnlStats.Controls.Add(this.pnlHetHang);
            this.pnlStats.Controls.Add(this.pnlTonTB);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 0);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1200, 130);
            this.pnlStats.TabIndex = 1;
            // 
            // pnlTongSP
            // 
            this.pnlTongSP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTongSP.Controls.Add(this.lblTongSPTitle);
            this.pnlTongSP.Controls.Add(this.lblTongSPDesc);
            this.pnlTongSP.Controls.Add(this.txtTongSP);
            this.pnlTongSP.Location = new System.Drawing.Point(30, 15);
            this.pnlTongSP.Name = "pnlTongSP";
            this.pnlTongSP.Size = new System.Drawing.Size(250, 100);
            this.pnlTongSP.TabIndex = 0;
            // 
            // lblTongSPTitle
            // 
            this.lblTongSPTitle.AutoSize = true;
            this.lblTongSPTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSPTitle.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTongSPTitle.Location = new System.Drawing.Point(43, 4);
            this.lblTongSPTitle.Name = "lblTongSPTitle";
            this.lblTongSPTitle.Size = new System.Drawing.Size(154, 28);
            this.lblTongSPTitle.TabIndex = 0;
            this.lblTongSPTitle.Text = "Tổng sản phẩm";
            // 
            // lblTongSPDesc
            // 
            this.lblTongSPDesc.AutoSize = true;
            this.lblTongSPDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTongSPDesc.Location = new System.Drawing.Point(64, 70);
            this.lblTongSPDesc.Name = "lblTongSPDesc";
            this.lblTongSPDesc.Size = new System.Drawing.Size(111, 21);
            this.lblTongSPDesc.TabIndex = 1;
            this.lblTongSPDesc.Text = "Loại sản phẩm";
            // 
            // txtTongSP
            // 
            this.txtTongSP.Enabled = false;
            this.txtTongSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTongSP.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtTongSP.Location = new System.Drawing.Point(75, 30);
            this.txtTongSP.Name = "txtTongSP";
            this.txtTongSP.Size = new System.Drawing.Size(90, 39);
            this.txtTongSP.TabIndex = 2;
            this.txtTongSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlSapHet
            // 
            this.pnlSapHet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSapHet.Controls.Add(this.lblSapHetTitle);
            this.pnlSapHet.Controls.Add(this.lblSapHetDesc);
            this.pnlSapHet.Controls.Add(this.txtSapHet);
            this.pnlSapHet.Location = new System.Drawing.Point(315, 15);
            this.pnlSapHet.Name = "pnlSapHet";
            this.pnlSapHet.Size = new System.Drawing.Size(250, 100);
            this.pnlSapHet.TabIndex = 1;
            // 
            // lblSapHetTitle
            // 
            this.lblSapHetTitle.AutoSize = true;
            this.lblSapHetTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblSapHetTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblSapHetTitle.Location = new System.Drawing.Point(56, 4);
            this.lblSapHetTitle.Name = "lblSapHetTitle";
            this.lblSapHetTitle.Size = new System.Drawing.Size(133, 28);
            this.lblSapHetTitle.TabIndex = 0;
            this.lblSapHetTitle.Text = "Sắp hết hàng";
            // 
            // lblSapHetDesc
            // 
            this.lblSapHetDesc.AutoSize = true;
            this.lblSapHetDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSapHetDesc.Location = new System.Drawing.Point(66, 72);
            this.lblSapHetDesc.Name = "lblSapHetDesc";
            this.lblSapHetDesc.Size = new System.Drawing.Size(116, 21);
            this.lblSapHetDesc.TabIndex = 1;
            this.lblSapHetDesc.Text = "Cần nhập thêm";
            // 
            // txtSapHet
            // 
            this.txtSapHet.Enabled = false;
            this.txtSapHet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtSapHet.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtSapHet.Location = new System.Drawing.Point(77, 30);
            this.txtSapHet.Name = "txtSapHet";
            this.txtSapHet.Size = new System.Drawing.Size(90, 39);
            this.txtSapHet.TabIndex = 2;
            this.txtSapHet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlHetHang
            // 
            this.pnlHetHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHetHang.Controls.Add(this.lblHetHangTitle);
            this.pnlHetHang.Controls.Add(this.lblHetHangDesc);
            this.pnlHetHang.Controls.Add(this.txtHetHang);
            this.pnlHetHang.Location = new System.Drawing.Point(600, 15);
            this.pnlHetHang.Name = "pnlHetHang";
            this.pnlHetHang.Size = new System.Drawing.Size(250, 100);
            this.pnlHetHang.TabIndex = 2;
            // 
            // lblHetHangTitle
            // 
            this.lblHetHangTitle.AutoSize = true;
            this.lblHetHangTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblHetHangTitle.ForeColor = System.Drawing.Color.Red;
            this.lblHetHangTitle.Location = new System.Drawing.Point(76, 4);
            this.lblHetHangTitle.Name = "lblHetHangTitle";
            this.lblHetHangTitle.Size = new System.Drawing.Size(97, 28);
            this.lblHetHangTitle.TabIndex = 0;
            this.lblHetHangTitle.Text = "Hết hàng";
            // 
            // lblHetHangDesc
            // 
            this.lblHetHangDesc.AutoSize = true;
            this.lblHetHangDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHetHangDesc.Location = new System.Drawing.Point(65, 70);
            this.lblHetHangDesc.Name = "lblHetHangDesc";
            this.lblHetHangDesc.Size = new System.Drawing.Size(123, 21);
            this.lblHetHangDesc.TabIndex = 1;
            this.lblHetHangDesc.Text = "Không còn hàng";
            // 
            // txtHetHang
            // 
            this.txtHetHang.Enabled = false;
            this.txtHetHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtHetHang.ForeColor = System.Drawing.Color.Red;
            this.txtHetHang.Location = new System.Drawing.Point(81, 28);
            this.txtHetHang.Name = "txtHetHang";
            this.txtHetHang.Size = new System.Drawing.Size(90, 39);
            this.txtHetHang.TabIndex = 2;
            this.txtHetHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlTonTB
            // 
            this.pnlTonTB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTonTB.Controls.Add(this.lblTonTBTitle);
            this.pnlTonTB.Controls.Add(this.lblTonTBDesc);
            this.pnlTonTB.Controls.Add(this.txtTonTB);
            this.pnlTonTB.Location = new System.Drawing.Point(885, 15);
            this.pnlTonTB.Name = "pnlTonTB";
            this.pnlTonTB.Size = new System.Drawing.Size(250, 100);
            this.pnlTonTB.TabIndex = 3;
            // 
            // lblTonTBTitle
            // 
            this.lblTonTBTitle.AutoSize = true;
            this.lblTonTBTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTonTBTitle.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTonTBTitle.Location = new System.Drawing.Point(51, 3);
            this.lblTonTBTitle.Name = "lblTonTBTitle";
            this.lblTonTBTitle.Size = new System.Drawing.Size(150, 28);
            this.lblTonTBTitle.TabIndex = 0;
            this.lblTonTBTitle.Text = "Tồn trung bình";
            // 
            // lblTonTBDesc
            // 
            this.lblTonTBDesc.AutoSize = true;
            this.lblTonTBDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTonTBDesc.Location = new System.Drawing.Point(77, 70);
            this.lblTonTBDesc.Name = "lblTonTBDesc";
            this.lblTonTBDesc.Size = new System.Drawing.Size(111, 21);
            this.lblTonTBDesc.TabIndex = 1;
            this.lblTonTBDesc.Text = "Sản phẩm/loại";
            // 
            // txtTonTB
            // 
            this.txtTonTB.Enabled = false;
            this.txtTonTB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTonTB.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtTonTB.Location = new System.Drawing.Point(83, 28);
            this.txtTonTB.Name = "txtTonTB";
            this.txtTonTB.Size = new System.Drawing.Size(90, 39);
            this.txtTonTB.TabIndex = 2;
            this.txtTonTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.lblTimKiem);
            this.pnlFilter.Controls.Add(this.txtTimKiem);
            this.pnlFilter.Controls.Add(this.lblLoaiSP);
            this.pnlFilter.Controls.Add(this.cboLoaiSP);
            this.pnlFilter.Controls.Add(this.lblTrangThai);
            this.pnlFilter.Controls.Add(this.cboTrangThai);
            this.pnlFilter.Controls.Add(this.btnTKiem);
            this.pnlFilter.Controls.Add(this.btnLMoi);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 130);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1200, 140);
            this.pnlFilter.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "BỘ LỌC TÌM KIẾM";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = System.Drawing.Color.White;
            this.lblTimKiem.Location = new System.Drawing.Point(10, 45);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(192, 28);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "Tìm kiếm sản phẩm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(10, 76);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 34);
            this.txtTimKiem.TabIndex = 2;
            // 
            // lblLoaiSP
            // 
            this.lblLoaiSP.AutoSize = true;
            this.lblLoaiSP.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblLoaiSP.ForeColor = System.Drawing.Color.White;
            this.lblLoaiSP.Location = new System.Drawing.Point(310, 45);
            this.lblLoaiSP.Name = "lblLoaiSP";
            this.lblLoaiSP.Size = new System.Drawing.Size(144, 28);
            this.lblLoaiSP.TabIndex = 3;
            this.lblLoaiSP.Text = "Loại sản phẩm";
            // 
            // cboLoaiSP
            // 
            this.cboLoaiSP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiSP.FormattingEnabled = true;
            this.cboLoaiSP.Location = new System.Drawing.Point(310, 76);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Size = new System.Drawing.Size(220, 36);
            this.cboLoaiSP.TabIndex = 4;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = System.Drawing.Color.White;
            this.lblTrangThai.Location = new System.Drawing.Point(570, 45);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(102, 28);
            this.lblTrangThai.TabIndex = 5;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(570, 76);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(220, 36);
            this.cboTrangThai.TabIndex = 6;
            // 
            // btnTKiem
            // 
            this.btnTKiem.BackColor = System.Drawing.Color.LightBlue;
            this.btnTKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTKiem.Location = new System.Drawing.Point(830, 76);
            this.btnTKiem.Name = "btnTKiem";
            this.btnTKiem.Size = new System.Drawing.Size(150, 37);
            this.btnTKiem.TabIndex = 7;
            this.btnTKiem.Text = "Tìm kiếm";
            this.btnTKiem.UseVisualStyleBackColor = false;
            this.btnTKiem.Click += new System.EventHandler(this.btnTKiem_Click);
            // 
            // btnLMoi
            // 
            this.btnLMoi.BackColor = System.Drawing.Color.White;
            this.btnLMoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLMoi.Location = new System.Drawing.Point(1000, 76);
            this.btnLMoi.Name = "btnLMoi";
            this.btnLMoi.Size = new System.Drawing.Size(150, 37);
            this.btnLMoi.TabIndex = 8;
            this.btnLMoi.Text = "Làm mới";
            this.btnLMoi.UseVisualStyleBackColor = true;
            // 
            // pnlDataGrid
            // 
            this.pnlDataGrid.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlDataGrid.Controls.Add(this.lblDataGridTitle);
            this.pnlDataGrid.Controls.Add(this.dataGridView1);
            this.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGrid.Location = new System.Drawing.Point(0, 270);
            this.pnlDataGrid.Name = "pnlDataGrid";
            this.pnlDataGrid.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDataGrid.Size = new System.Drawing.Size(1200, 442);
            this.pnlDataGrid.TabIndex = 3;
            // 
            // lblDataGridTitle
            // 
            this.lblDataGridTitle.AutoSize = true;
            this.lblDataGridTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblDataGridTitle.ForeColor = System.Drawing.Color.White;
            this.lblDataGridTitle.Location = new System.Drawing.Point(20, 10);
            this.lblDataGridTitle.Name = "lblDataGridTitle";
            this.lblDataGridTitle.Size = new System.Drawing.Size(221, 28);
            this.lblDataGridTitle.TabIndex = 0;
            this.lblDataGridTitle.Text = "DANH SÁCH TỒN KHO";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 310);
            this.dataGridView1.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.lblTotalStock);
            this.pnlBottom.Controls.Add(this.txtTongTon);
            this.pnlBottom.Controls.Add(this.btnXuat);
            this.pnlBottom.Controls.Add(this.btnIn);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 712);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1200, 88);
            this.pnlBottom.TabIndex = 4;
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.AutoSize = true;
            this.lblTotalStock.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalStock.Location = new System.Drawing.Point(30, 25);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(142, 28);
            this.lblTotalStock.TabIndex = 0;
            this.lblTotalStock.Text = "Tổng tồn kho:";
            // 
            // txtTongTon
            // 
            this.txtTongTon.Enabled = false;
            this.txtTongTon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTongTon.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtTongTon.Location = new System.Drawing.Point(180, 20);
            this.txtTongTon.Name = "txtTongTon";
            this.txtTongTon.Size = new System.Drawing.Size(150, 34);
            this.txtTongTon.TabIndex = 1;
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(830, 15);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(170, 50);
            this.btnXuat.TabIndex = 2;
            this.btnXuat.Text = "Xuất Excel";
            this.btnXuat.UseVisualStyleBackColor = false;
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.Location = new System.Drawing.Point(1017, 15);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(153, 50);
            this.btnIn.TabIndex = 3;
            this.btnIn.Text = "In báo cáo";
            this.btnIn.UseVisualStyleBackColor = false;
            // 
            // frmNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlDataGrid);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmNguyenLieu";
            this.Text = "Quản lý tồn kho";
            this.Load += new System.EventHandler(this.frmNguyenLieu_Load);
            this.pnlStats.ResumeLayout(false);
            this.pnlTongSP.ResumeLayout(false);
            this.pnlTongSP.PerformLayout();
            this.pnlSapHet.ResumeLayout(false);
            this.pnlSapHet.PerformLayout();
            this.pnlHetHang.ResumeLayout(false);
            this.pnlHetHang.PerformLayout();
            this.pnlTonTB.ResumeLayout(false);
            this.pnlTonTB.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlDataGrid.ResumeLayout(false);
            this.pnlDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlDataGrid;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnTKiem;
        private System.Windows.Forms.Button btnLMoi;
        private System.Windows.Forms.Panel pnlTongSP;
        private System.Windows.Forms.TextBox txtTongSP;
        private System.Windows.Forms.Label lblTongSPTitle;
        private System.Windows.Forms.Label lblTongSPDesc;
        private System.Windows.Forms.Panel pnlSapHet;
        private System.Windows.Forms.TextBox txtSapHet;
        private System.Windows.Forms.Label lblSapHetTitle;
        private System.Windows.Forms.Label lblSapHetDesc;
        private System.Windows.Forms.Panel pnlHetHang;
        private System.Windows.Forms.TextBox txtHetHang;
        private System.Windows.Forms.Label lblHetHangTitle;
        private System.Windows.Forms.Label lblHetHangDesc;
        private System.Windows.Forms.Panel pnlTonTB;
        private System.Windows.Forms.TextBox txtTonTB;
        private System.Windows.Forms.Label lblTonTBTitle;
        private System.Windows.Forms.Label lblTonTBDesc;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblDataGridTitle;
        private System.Windows.Forms.Label lblTotalStock;
        private System.Windows.Forms.TextBox txtTongTon;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnIn;
    }
}