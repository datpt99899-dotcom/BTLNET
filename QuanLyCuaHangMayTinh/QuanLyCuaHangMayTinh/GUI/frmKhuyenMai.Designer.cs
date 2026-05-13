namespace QuanLyCuaHangMayTinh.GUI
{
    partial class frmKhuyenMai
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
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaKM = new System.Windows.Forms.Label();
            this.txtMaKM = new System.Windows.Forms.TextBox();
            this.lblTenKM = new System.Windows.Forms.Label();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.lblMucKM = new System.Windows.Forms.Label();
            this.txtMucKM = new System.Windows.Forms.TextBox();
            this.lblNgayBD = new System.Windows.Forms.Label();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.lblDieuKien = new System.Windows.Forms.Label();
            this.txtDieuKien = new System.Windows.Forms.TextBox();
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnHienthi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(428, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(510, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DANH MỤC KHUYẾN MÃI";
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.lblMaKM);
            this.gbThongTin.Controls.Add(this.txtMaKM);
            this.gbThongTin.Controls.Add(this.lblTenKM);
            this.gbThongTin.Controls.Add(this.txtTenKM);
            this.gbThongTin.Controls.Add(this.lblMucKM);
            this.gbThongTin.Controls.Add(this.txtMucKM);
            this.gbThongTin.Controls.Add(this.lblNgayBD);
            this.gbThongTin.Controls.Add(this.dtpNgayBD);
            this.gbThongTin.Controls.Add(this.lblNgayKT);
            this.gbThongTin.Controls.Add(this.dtpNgayKT);
            this.gbThongTin.Controls.Add(this.lblDieuKien);
            this.gbThongTin.Controls.Add(this.txtDieuKien);
            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbThongTin.Location = new System.Drawing.Point(34, 100);
            this.gbThongTin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbThongTin.Size = new System.Drawing.Size(1170, 250);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin khuyến mãi";
            // 
            // lblMaKM
            // 
            this.lblMaKM.Location = new System.Drawing.Point(22, 44);
            this.lblMaKM.Name = "lblMaKM";
            this.lblMaKM.Size = new System.Drawing.Size(112, 29);
            this.lblMaKM.TabIndex = 0;
            this.lblMaKM.Text = "Mã KM:";
            // 
            // txtMaKM
            // 
            this.txtMaKM.Location = new System.Drawing.Point(135, 40);
            this.txtMaKM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaKM.Name = "txtMaKM";
            this.txtMaKM.Size = new System.Drawing.Size(224, 34);
            this.txtMaKM.TabIndex = 1;
            // 
            // lblTenKM
            // 
            this.lblTenKM.Location = new System.Drawing.Point(394, 44);
            this.lblTenKM.Name = "lblTenKM";
            this.lblTenKM.Size = new System.Drawing.Size(112, 29);
            this.lblTenKM.TabIndex = 2;
            this.lblTenKM.Text = "Tên KM:";
            // 
            // txtTenKM
            // 
            this.txtTenKM.Location = new System.Drawing.Point(506, 40);
            this.txtTenKM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(281, 34);
            this.txtTenKM.TabIndex = 3;
            // 
            // lblMucKM
            // 
            this.lblMucKM.Location = new System.Drawing.Point(821, 44);
            this.lblMucKM.Name = "lblMucKM";
            this.lblMucKM.Size = new System.Drawing.Size(146, 29);
            this.lblMucKM.TabIndex = 4;
            this.lblMucKM.Text = "Mức KM (%):";
            // 
            // txtMucKM
            // 
            this.txtMucKM.Location = new System.Drawing.Point(956, 40);
            this.txtMucKM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMucKM.Name = "txtMucKM";
            this.txtMucKM.Size = new System.Drawing.Size(168, 34);
            this.txtMucKM.TabIndex = 5;
            // 
            // lblNgayBD
            // 
            this.lblNgayBD.Location = new System.Drawing.Point(22, 94);
            this.lblNgayBD.Name = "lblNgayBD";
            this.lblNgayBD.Size = new System.Drawing.Size(112, 29);
            this.lblNgayBD.TabIndex = 6;
            this.lblNgayBD.Text = "Ngày BĐ:";
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBD.Location = new System.Drawing.Point(135, 90);
            this.dtpNgayBD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(224, 34);
            this.dtpNgayBD.TabIndex = 7;
            // 
            // lblNgayKT
            // 
            this.lblNgayKT.Location = new System.Drawing.Point(394, 94);
            this.lblNgayKT.Name = "lblNgayKT";
            this.lblNgayKT.Size = new System.Drawing.Size(112, 29);
            this.lblNgayKT.TabIndex = 8;
            this.lblNgayKT.Text = "Ngày KT:";
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKT.Location = new System.Drawing.Point(506, 90);
            this.dtpNgayKT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(281, 34);
            this.dtpNgayKT.TabIndex = 9;
            // 
            // lblDieuKien
            // 
            this.lblDieuKien.Location = new System.Drawing.Point(22, 144);
            this.lblDieuKien.Name = "lblDieuKien";
            this.lblDieuKien.Size = new System.Drawing.Size(112, 29);
            this.lblDieuKien.TabIndex = 10;
            this.lblDieuKien.Text = "Điều kiện:";
            // 
            // txtDieuKien
            // 
            this.txtDieuKien.Location = new System.Drawing.Point(135, 140);
            this.txtDieuKien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDieuKien.Multiline = true;
            this.txtDieuKien.Name = "txtDieuKien";
            this.txtDieuKien.Size = new System.Drawing.Size(990, 74);
            this.txtDieuKien.TabIndex = 11;
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Location = new System.Drawing.Point(34, 375);
            this.dgvKhuyenMai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.RowHeadersWidth = 51;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(1170, 350);
            this.dgvKhuyenMai.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(34, 750);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 56);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(158, 750);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(112, 56);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(281, 750);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 56);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(405, 750);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(112, 56);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnBoqua
            // 
            this.btnBoqua.BackColor = System.Drawing.Color.Gray;
            this.btnBoqua.ForeColor = System.Drawing.Color.White;
            this.btnBoqua.Location = new System.Drawing.Point(529, 750);
            this.btnBoqua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(112, 56);
            this.btnBoqua.TabIndex = 3;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(765, 750);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(112, 56);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnHienthi
            // 
            this.btnHienthi.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnHienthi.ForeColor = System.Drawing.Color.White;
            this.btnHienthi.Location = new System.Drawing.Point(889, 750);
            this.btnHienthi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHienthi.Name = "btnHienthi";
            this.btnHienthi.Size = new System.Drawing.Size(112, 56);
            this.btnHienthi.TabIndex = 1;
            this.btnHienthi.Text = "Hiển thị";
            this.btnHienthi.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.DimGray;
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1091, 750);
            this.btnDong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(112, 56);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // frmKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1238, 850);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnHienthi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvKhuyenMai);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmKhuyenMai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khuyến mãi";
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblMaKM;
        private System.Windows.Forms.TextBox txtMaKM;
        private System.Windows.Forms.Label lblTenKM;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.Label lblMucKM;
        private System.Windows.Forms.TextBox txtMucKM;
        private System.Windows.Forms.Label lblNgayBD;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.Label lblNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.Label lblDieuKien;
        private System.Windows.Forms.TextBox txtDieuKien;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnHienthi;
        private System.Windows.Forms.Button btnDong;
    }
}