namespace QuanLyCuaHangMayTinh
{
    partial class frmBaoCao
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
            this.components = new System.ComponentModel.Container();
            this.rdoNgay = new System.Windows.Forms.RadioButton();
            this.rdoKhoang = new System.Windows.Forms.RadioButton();
            this.PanelTime = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtBangchu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.ckbHD = new System.Windows.Forms.CheckBox();
            this.ckbSP = new System.Windows.Forms.CheckBox();
            this.cboSP = new System.Windows.Forms.ComboBox();
            this.mskNgay = new System.Windows.Forms.DateTimePicker();
            this.btnInBC = new System.Windows.Forms.Button();
            this.btnHienthi = new System.Windows.Forms.Button();
            this.btnLammoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.quanLyBanHangCaPheDataSet = new QuanLyCuaHangMayTinh.QuanLyBanHangMayTinhDataSet();
            this.hoaDonBanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hoaDonBanTableAdapter = new QuanLyCuaHangMayTinh.QuanLyBanHangMayTinhDataSetTableAdapters.HoaDonBanTableAdapter();
            this.chiTietSanPhamTableAdapter1 = new QuanLyCuaHangMayTinh.QuanLyBanHangMayTinhDataSet1TableAdapters.ChiTietSanPhamTableAdapter();
            this.PanelTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanHangCaPheDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonBanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoNgay
            // 
            this.rdoNgay.AutoSize = true;
            this.rdoNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNgay.Location = new System.Drawing.Point(92, 118);
            this.rdoNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoNgay.Name = "rdoNgay";
            this.rdoNgay.Size = new System.Drawing.Size(122, 28);
            this.rdoNgay.TabIndex = 1;
            this.rdoNgay.TabStop = true;
            this.rdoNgay.Text = "Theo ngày";
            this.rdoNgay.UseVisualStyleBackColor = true;
            this.rdoNgay.CheckedChanged += new System.EventHandler(this.rdoNgay_CheckedChanged);
            // 
            // rdoKhoang
            // 
            this.rdoKhoang.AutoSize = true;
            this.rdoKhoang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoKhoang.Location = new System.Drawing.Point(449, 116);
            this.rdoKhoang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoKhoang.Name = "rdoKhoang";
            this.rdoKhoang.Size = new System.Drawing.Size(144, 28);
            this.rdoKhoang.TabIndex = 3;
            this.rdoKhoang.TabStop = true;
            this.rdoKhoang.Text = "Theo khoảng";
            this.rdoKhoang.UseVisualStyleBackColor = true;
            this.rdoKhoang.CheckedChanged += new System.EventHandler(this.rdoKhoang_CheckedChanged);
            // 
            // PanelTime
            // 
            this.PanelTime.Controls.Add(this.label3);
            this.PanelTime.Controls.Add(this.label2);
            this.PanelTime.Controls.Add(this.dateTimePicker2);
            this.PanelTime.Controls.Add(this.dateTimePicker1);
            this.PanelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelTime.Location = new System.Drawing.Point(605, 111);
            this.PanelTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelTime.Name = "PanelTime";
            this.PanelTime.Size = new System.Drawing.Size(420, 43);
            this.PanelTime.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tới:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(273, 5);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(125, 29);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.Value = new System.DateTime(2025, 5, 22, 17, 1, 27, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(56, 5);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 29);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(161, 159);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(831, 282);
            this.dataGridView.TabIndex = 6;
            // 
            // txtBangchu
            // 
            this.txtBangchu.AutoSize = true;
            this.txtBangchu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBangchu.Location = new System.Drawing.Point(168, 475);
            this.txtBangchu.Name = "txtBangchu";
            this.txtBangchu.Size = new System.Drawing.Size(111, 24);
            this.txtBangchu.TabIndex = 10;
            this.txtBangchu.Text = "Bằng chữ: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(689, 473);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tổng tiền:";
            // 
            // txtTongtien
            // 
            this.txtTongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongtien.Location = new System.Drawing.Point(804, 469);
            this.txtTongtien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(187, 29);
            this.txtTongtien.TabIndex = 12;
            // 
            // ckbHD
            // 
            this.ckbHD.AutoSize = true;
            this.ckbHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbHD.Location = new System.Drawing.Point(172, 68);
            this.ckbHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ckbHD.Name = "ckbHD";
            this.ckbHD.Size = new System.Drawing.Size(153, 28);
            this.ckbHD.TabIndex = 13;
            this.ckbHD.Text = "Theo hóa đơn";
            this.ckbHD.UseVisualStyleBackColor = true;
            this.ckbHD.CheckedChanged += new System.EventHandler(this.ckbHD_CheckedChanged);
            // 
            // ckbSP
            // 
            this.ckbSP.AutoSize = true;
            this.ckbSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSP.Location = new System.Drawing.Point(556, 64);
            this.ckbSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ckbSP.Name = "ckbSP";
            this.ckbSP.Size = new System.Drawing.Size(165, 28);
            this.ckbSP.TabIndex = 14;
            this.ckbSP.Text = "Theo sản phẩm";
            this.ckbSP.UseVisualStyleBackColor = true;
            this.ckbSP.CheckedChanged += new System.EventHandler(this.ckbSP_CheckedChanged);
            // 
            // cboSP
            // 
            this.cboSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSP.FormattingEnabled = true;
            this.cboSP.Location = new System.Drawing.Point(755, 62);
            this.cboSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboSP.Name = "cboSP";
            this.cboSP.Size = new System.Drawing.Size(157, 32);
            this.cboSP.TabIndex = 15;
            // 
            // mskNgay
            // 
            this.mskNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mskNgay.Location = new System.Drawing.Point(261, 118);
            this.mskNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskNgay.Name = "mskNgay";
            this.mskNgay.Size = new System.Drawing.Size(124, 29);
            this.mskNgay.TabIndex = 16;
            // 
            // btnInBC
            // 
            this.btnInBC.BackColor = System.Drawing.Color.Green;
            this.btnInBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBC.ForeColor = System.Drawing.Color.White;
            this.btnInBC.Location = new System.Drawing.Point(767, 561);
            this.btnInBC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInBC.Name = "btnInBC";
            this.btnInBC.Size = new System.Drawing.Size(133, 57);
            this.btnInBC.TabIndex = 19;
            this.btnInBC.Text = "In báo cáo";
            this.btnInBC.UseVisualStyleBackColor = false;
            this.btnInBC.Click += new System.EventHandler(this.btnInBC_Click_1);
            // 
            // btnHienthi
            // 
            this.btnHienthi.BackColor = System.Drawing.Color.Green;
            this.btnHienthi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienthi.ForeColor = System.Drawing.Color.White;
            this.btnHienthi.Location = new System.Drawing.Point(524, 561);
            this.btnHienthi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHienthi.Name = "btnHienthi";
            this.btnHienthi.Size = new System.Drawing.Size(133, 57);
            this.btnHienthi.TabIndex = 18;
            this.btnHienthi.Text = "Hiển thị";
            this.btnHienthi.UseVisualStyleBackColor = false;
            this.btnHienthi.Click += new System.EventHandler(this.btnHienthi_Click_1);
            // 
            // btnLammoi
            // 
            this.btnLammoi.BackColor = System.Drawing.Color.Green;
            this.btnLammoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLammoi.ForeColor = System.Drawing.Color.White;
            this.btnLammoi.Location = new System.Drawing.Point(276, 561);
            this.btnLammoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLammoi.Name = "btnLammoi";
            this.btnLammoi.Size = new System.Drawing.Size(133, 57);
            this.btnLammoi.TabIndex = 17;
            this.btnLammoi.Text = "Làm mới";
            this.btnLammoi.UseVisualStyleBackColor = false;
            this.btnLammoi.Click += new System.EventHandler(this.btnLammoi_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(401, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 20;
            // 
            // quanLyBanHangCaPheDataSet
            // 
            this.quanLyBanHangCaPheDataSet.DataSetName = "QuanLyBanHangMayTinhDataSet";
            this.quanLyBanHangCaPheDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hoaDonBanBindingSource
            // 
            this.hoaDonBanBindingSource.DataMember = "HoaDonBan";
            this.hoaDonBanBindingSource.DataSource = this.quanLyBanHangCaPheDataSet;
            // 
            // hoaDonBanTableAdapter
            // 
            this.hoaDonBanTableAdapter.ClearBeforeFill = true;
            // 
            // chiTietSanPhamTableAdapter1
            // 
            this.chiTietSanPhamTableAdapter1.ClearBeforeFill = true;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInBC);
            this.Controls.Add(this.btnHienthi);
            this.Controls.Add(this.btnLammoi);
            this.Controls.Add(this.mskNgay);
            this.Controls.Add(this.cboSP);
            this.Controls.Add(this.ckbSP);
            this.Controls.Add(this.ckbHD);
            this.Controls.Add(this.txtTongtien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBangchu);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.PanelTime);
            this.Controls.Add(this.rdoKhoang);
            this.Controls.Add(this.rdoNgay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmBaoCao";
            this.Text = "frmBaoCao";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.PanelTime.ResumeLayout(false);
            this.PanelTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanHangCaPheDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonBanBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rdoNgay;
        private System.Windows.Forms.RadioButton rdoKhoang;
        private System.Windows.Forms.Panel PanelTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label txtBangchu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.CheckBox ckbHD;
        private System.Windows.Forms.CheckBox ckbSP;
        private System.Windows.Forms.ComboBox cboSP;
        private System.Windows.Forms.DateTimePicker mskNgay;
        private System.Windows.Forms.Button btnInBC;
        private System.Windows.Forms.Button btnHienthi;
        private System.Windows.Forms.Button btnLammoi;
        private System.Windows.Forms.Label label1;
        private QuanLyBanHangMayTinhDataSet quanLyBanHangCaPheDataSet;
        private System.Windows.Forms.BindingSource hoaDonBanBindingSource;
        private QuanLyBanHangMayTinhDataSetTableAdapters.HoaDonBanTableAdapter hoaDonBanTableAdapter;
        private QuanLyBanHangMayTinhDataSet1TableAdapters.ChiTietSanPhamTableAdapter chiTietSanPhamTableAdapter1;
    }
}