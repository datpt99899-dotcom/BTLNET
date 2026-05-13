namespace QuanLyCuaHangMayTinh.GUI
{
    partial class frmThanhToan
    {
        /// <summary>
        /// Required designer variable
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTongTienText = new System.Windows.Forms.Label();
            this.lblTongTienSo = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblHTTT = new System.Windows.Forms.Label();
            this.cboHinhThucTT = new System.Windows.Forms.ComboBox();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.lblTienKhachDua = new System.Windows.Forms.Label();
            this.txtTienKhachDua = new System.Windows.Forms.TextBox();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.lblTienThua = new System.Windows.Forms.Label();
            this.txtTienThua = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1400, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1400, 80);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG THANH TOÁN HÓA ĐƠN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlContent.Controls.Add(this.pnlLeft);
            this.pnlContent.Controls.Add(this.pnlRight);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(15);
            this.pnlContent.Size = new System.Drawing.Size(1400, 770);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.dgvGioHang);
            this.pnlLeft.Controls.Add(this.lblGridTitle);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(15, 15);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLeft.Size = new System.Drawing.Size(870, 740);
            this.pnlLeft.TabIndex = 0;
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AllowUserToDeleteRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGioHang.ColumnHeadersHeight = 35;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioHang.Location = new System.Drawing.Point(15, 50);
            this.dgvGioHang.MultiSelect = false;
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.RowTemplate.Height = 30;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(840, 675);
            this.dgvGioHang.TabIndex = 1;
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblGridTitle.Location = new System.Drawing.Point(15, 15);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(840, 35);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "DANH SÁCH SẢN PHẨM TRONG GIỎ HÀNG";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.pnlButtons);
            this.pnlRight.Controls.Add(this.pnlSummary);
            this.pnlRight.Controls.Add(this.pnlInput);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(885, 15);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(500, 740);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnThanhToan);
            this.pnlButtons.Controls.Add(this.btnInHoaDon);
            this.pnlButtons.Controls.Add(this.btnHuy);
            this.pnlButtons.Controls.Add(this.btnDong);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 599);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(20);
            this.pnlButtons.Size = new System.Drawing.Size(500, 141);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.SeaGreen;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(20, 15);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(220, 45);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Location = new System.Drawing.Point(250, 15);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(220, 45);
            this.btnInHoaDon.TabIndex = 1;
            this.btnInHoaDon.Text = "IN HÓA ĐƠN";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DarkOrange;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(20, 75);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(220, 45);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "LÀM MỚI";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Gray;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(250, 75);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(220, 45);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "ĐÓNG";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlSummary.Controls.Add(this.lblTongTienText);
            this.pnlSummary.Controls.Add(this.lblTongTienSo);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(0, 470);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(500, 129);
            this.pnlSummary.TabIndex = 1;
            // 
            // lblTongTienText
            // 
            this.lblTongTienText.AutoSize = true;
            this.lblTongTienText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTienText.Location = new System.Drawing.Point(20, 20);
            this.lblTongTienText.Name = "lblTongTienText";
            this.lblTongTienText.Size = new System.Drawing.Size(228, 30);
            this.lblTongTienText.TabIndex = 0;
            this.lblTongTienText.Text = "TỔNG THANH TOÁN";
            // 
            // lblTongTienSo
            // 
            this.lblTongTienSo.AutoSize = true;
            this.lblTongTienSo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTongTienSo.ForeColor = System.Drawing.Color.Red;
            this.lblTongTienSo.Location = new System.Drawing.Point(20, 55);
            this.lblTongTienSo.Name = "lblTongTienSo";
            this.lblTongTienSo.Size = new System.Drawing.Size(158, 60);
            this.lblTongTienSo.TabIndex = 1;
            this.lblTongTienSo.Text = "0 VNĐ";
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.lblMaHD);
            this.pnlInput.Controls.Add(this.txtMaHD);
            this.pnlInput.Controls.Add(this.lblNgayLap);
            this.pnlInput.Controls.Add(this.dtpNgayLap);
            this.pnlInput.Controls.Add(this.lblNhanVien);
            this.pnlInput.Controls.Add(this.cboNhanVien);
            this.pnlInput.Controls.Add(this.lblKhachHang);
            this.pnlInput.Controls.Add(this.cboKhachHang);
            this.pnlInput.Controls.Add(this.lblHTTT);
            this.pnlInput.Controls.Add(this.cboHinhThucTT);
            this.pnlInput.Controls.Add(this.lblGiamGia);
            this.pnlInput.Controls.Add(this.txtGiamGia);
            this.pnlInput.Controls.Add(this.lblTienKhachDua);
            this.pnlInput.Controls.Add(this.txtTienKhachDua);
            this.pnlInput.Controls.Add(this.lblThanhTien);
            this.pnlInput.Controls.Add(this.txtThanhTien);
            this.pnlInput.Controls.Add(this.lblTienThua);
            this.pnlInput.Controls.Add(this.txtTienThua);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(20);
            this.pnlInput.Size = new System.Drawing.Size(500, 470);
            this.pnlInput.TabIndex = 0;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaHD.Location = new System.Drawing.Point(20, 15);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(127, 28);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã hóa đơn";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaHD.Location = new System.Drawing.Point(20, 40);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(450, 34);
            this.txtMaHD.TabIndex = 1;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNgayLap.Location = new System.Drawing.Point(20, 80);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(97, 28);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày lập";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(20, 105);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(450, 34);
            this.dtpNgayLap.TabIndex = 3;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNhanVien.Location = new System.Drawing.Point(20, 145);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(109, 28);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhanVien.Location = new System.Drawing.Point(20, 170);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(450, 36);
            this.cboNhanVien.TabIndex = 5;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKhachHang.Location = new System.Drawing.Point(20, 210);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(123, 28);
            this.lblKhachHang.TabIndex = 6;
            this.lblKhachHang.Text = "Khách hàng";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboKhachHang.Location = new System.Drawing.Point(20, 235);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(450, 36);
            this.cboKhachHang.TabIndex = 7;
            // 
            // lblHTTT
            // 
            this.lblHTTT.AutoSize = true;
            this.lblHTTT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHTTT.Location = new System.Drawing.Point(20, 275);
            this.lblHTTT.Name = "lblHTTT";
            this.lblHTTT.Size = new System.Drawing.Size(216, 28);
            this.lblHTTT.TabIndex = 8;
            this.lblHTTT.Text = "Hình thức thanh toán";
            // 
            // cboHinhThucTT
            // 
            this.cboHinhThucTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHinhThucTT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboHinhThucTT.FormattingEnabled = true;
            this.cboHinhThucTT.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản",
            "QR Code",
            "Ví điện tử",
            "Thẻ ATM"});
            this.cboHinhThucTT.Location = new System.Drawing.Point(20, 300);
            this.cboHinhThucTT.Name = "cboHinhThucTT";
            this.cboHinhThucTT.Size = new System.Drawing.Size(450, 36);
            this.cboHinhThucTT.TabIndex = 9;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGiamGia.Location = new System.Drawing.Point(20, 340);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(96, 28);
            this.lblGiamGia.TabIndex = 10;
            this.lblGiamGia.Text = "Giảm giá";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiamGia.Location = new System.Drawing.Point(20, 365);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(210, 34);
            this.txtGiamGia.TabIndex = 11;
            this.txtGiamGia.Text = "0";
            this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTienKhachDua
            // 
            this.lblTienKhachDua.AutoSize = true;
            this.lblTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTienKhachDua.Location = new System.Drawing.Point(250, 340);
            this.lblTienKhachDua.Name = "lblTienKhachDua";
            this.lblTienKhachDua.Size = new System.Drawing.Size(158, 28);
            this.lblTienKhachDua.TabIndex = 12;
            this.lblTienKhachDua.Text = "Tiền khách đưa";
            // 
            // txtTienKhachDua
            // 
            this.txtTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTienKhachDua.Location = new System.Drawing.Point(250, 365);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.Size = new System.Drawing.Size(220, 34);
            this.txtTienKhachDua.TabIndex = 13;
            this.txtTienKhachDua.Text = "0";
            this.txtTienKhachDua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThanhTien.Location = new System.Drawing.Point(20, 405);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(114, 28);
            this.lblThanhTien.TabIndex = 14;
            this.lblThanhTien.Text = "Thành tiền";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.BackColor = System.Drawing.Color.LightYellow;
            this.txtThanhTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtThanhTien.Location = new System.Drawing.Point(20, 430);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(210, 34);
            this.txtThanhTien.TabIndex = 15;
            this.txtThanhTien.Text = "0";
            this.txtThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTienThua
            // 
            this.lblTienThua.AutoSize = true;
            this.lblTienThua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTienThua.Location = new System.Drawing.Point(250, 405);
            this.lblTienThua.Name = "lblTienThua";
            this.lblTienThua.Size = new System.Drawing.Size(103, 28);
            this.lblTienThua.TabIndex = 16;
            this.lblTienThua.Text = "Tiền thừa";
            // 
            // txtTienThua
            // 
            this.txtTienThua.BackColor = System.Drawing.Color.Honeydew;
            this.txtTienThua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTienThua.Location = new System.Drawing.Point(250, 430);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.ReadOnly = true;
            this.txtTienThua.Size = new System.Drawing.Size(220, 34);
            this.txtTienThua.TabIndex = 17;
            this.txtTienThua.Text = "0";
            this.txtTienThua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1400, 850);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán hóa đơn";
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel pnlContent;

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.DataGridView dgvGioHang;

        private System.Windows.Forms.Panel pnlRight;

        private System.Windows.Forms.Panel pnlInput;

        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.TextBox txtMaHD;

        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;

        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;

        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;

        private System.Windows.Forms.Label lblHTTT;
        private System.Windows.Forms.ComboBox cboHinhThucTT;

        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.TextBox txtGiamGia;

        private System.Windows.Forms.Label lblTienKhachDua;
        private System.Windows.Forms.TextBox txtTienKhachDua;

        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.TextBox txtThanhTien;

        private System.Windows.Forms.Label lblTienThua;
        private System.Windows.Forms.TextBox txtTienThua;

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTongTienText;
        private System.Windows.Forms.Label lblTongTienSo;

        private System.Windows.Forms.Panel pnlButtons;

        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDong;
    }
}