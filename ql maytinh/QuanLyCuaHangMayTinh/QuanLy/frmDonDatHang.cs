using Dapper;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.QuanLy
{
    public class frmDonDatHang : Form
    {
        private DataGridView dgv;
        private Button btnTai, btnChuyen;
        private DateTimePicker dateTimePicker2;
        private DataGridView dGridDsHD;
        private Panel panel1;
        private DataGridView dGridChitietHD;
        private Label label3;
        private Label label2;
        private FontAwesome.Sharp.IconButton btnSearch;
        private FontAwesome.Sharp.IconButton btnInHD;
        private FontAwesome.Sharp.IconButton BtnThongke;
        private TextBox txtsdt;
        private Label label6;
        private Label label5;
        private Label label4;
        private DateTimePicker dateTimePicker1;

        public frmDonDatHang()
        {
            Text = "Đơn đặt hàng"; Width = 1000; Height = 600;
            dgv = new DataGridView { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 45 };
            btnTai = new Button { Text = "Tải danh sách", Width = 120 };
            btnChuyen = new Button { Text = "Chuyển sang đơn bán", Width = 180 };
            btnTai.Click += (s,e) => LoadData();
            btnChuyen.Click += BtnChuyen_Click;
            panel.Controls.AddRange(new Control[]{btnTai, btnChuyen});
            Controls.Add(dgv); Controls.Add(panel);
            Load += (s,e) => LoadData();
        }
        private void LoadData()
        {
            try
            {
                using(var conn = DapperRepository.CreateConnection())
                {
                    conn.Open();
                    var dt = new DataTable();
                    using (var da = new System.Data.SqlClient.SqlDataAdapter("SELECT TOP 100 MaDonDatHang, NgayDat, MaKhachHang, TrangThai, TongTien FROM DonDatHang ORDER BY NgayDat DESC", conn))
                    { da.Fill(dt); }
                    dgv.DataSource = dt;
                }
            }
            catch(Exception ex) { MessageBox.Show("Chưa tải được đơn đặt hàng: " + ex.Message); }
        }

        private void InitializeComponent()
        {
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dGridDsHD = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dGridChitietHD = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.btnInHD = new FontAwesome.Sharp.IconButton();
            this.BtnThongke = new FontAwesome.Sharp.IconButton();
            this.txtsdt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dGridDsHD)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridChitietHD)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(431, 139);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(136, 33);
            this.dateTimePicker2.TabIndex = 21;
            // 
            // dGridDsHD
            // 
            this.dGridDsHD.BackgroundColor = System.Drawing.Color.White;
            this.dGridDsHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridDsHD.Location = new System.Drawing.Point(27, 60);
            this.dGridDsHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dGridDsHD.Name = "dGridDsHD";
            this.dGridDsHD.RowHeadersWidth = 62;
            this.dGridDsHD.RowTemplate.Height = 28;
            this.dGridDsHD.Size = new System.Drawing.Size(696, 481);
            this.dGridDsHD.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.dGridChitietHD);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dGridDsHD);
            this.panel1.Location = new System.Drawing.Point(26, 238);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 560);
            this.panel1.TabIndex = 19;
            // 
            // dGridChitietHD
            // 
            this.dGridChitietHD.BackgroundColor = System.Drawing.Color.White;
            this.dGridChitietHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridChitietHD.Location = new System.Drawing.Point(771, 60);
            this.dGridChitietHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dGridChitietHD.Name = "dGridChitietHD";
            this.dGridChitietHD.RowHeadersWidth = 62;
            this.dGridChitietHD.RowTemplate.Height = 28;
            this.dGridChitietHD.Size = new System.Drawing.Size(487, 481);
            this.dGridChitietHD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(766, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "DANH SÁCH HÓA ĐƠN";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Green;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.SearchMinus;
            this.btnSearch.IconColor = System.Drawing.Color.White;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 30;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(1156, 52);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 71);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnInHD
            // 
            this.btnInHD.BackColor = System.Drawing.Color.Green;
            this.btnInHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInHD.ForeColor = System.Drawing.Color.White;
            this.btnInHD.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnInHD.IconColor = System.Drawing.Color.White;
            this.btnInHD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInHD.IconSize = 30;
            this.btnInHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInHD.Location = new System.Drawing.Point(1156, 143);
            this.btnInHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(150, 71);
            this.btnInHD.TabIndex = 27;
            this.btnInHD.Text = "In hóa đơn";
            this.btnInHD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInHD.UseVisualStyleBackColor = false;
            // 
            // BtnThongke
            // 
            this.BtnThongke.BackColor = System.Drawing.Color.Green;
            this.BtnThongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnThongke.ForeColor = System.Drawing.Color.White;
            this.BtnThongke.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.BtnThongke.IconColor = System.Drawing.Color.White;
            this.BtnThongke.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnThongke.IconSize = 30;
            this.BtnThongke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnThongke.Location = new System.Drawing.Point(30, 97);
            this.BtnThongke.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnThongke.Name = "BtnThongke";
            this.BtnThongke.Size = new System.Drawing.Size(150, 71);
            this.BtnThongke.TabIndex = 26;
            this.BtnThongke.Text = "Thống kê";
            this.BtnThongke.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnThongke.UseVisualStyleBackColor = false;
            // 
            // txtsdt
            // 
            this.txtsdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsdt.Location = new System.Drawing.Point(863, 89);
            this.txtsdt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsdt.Name = "txtsdt";
            this.txtsdt.Size = new System.Drawing.Size(184, 33);
            this.txtsdt.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(682, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 29);
            this.label6.TabIndex = 24;
            this.label6.Text = "Số điện thoại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(254, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 29);
            this.label5.TabIndex = 23;
            this.label5.Text = "Đến ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(254, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 29);
            this.label4.TabIndex = 22;
            this.label4.Text = "Từ ngày:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(431, 86);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(136, 33);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // frmDonDatHang
            // 
            this.ClientSize = new System.Drawing.Size(1335, 850);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnInHD);
            this.Controls.Add(this.BtnThongke);
            this.Controls.Add(this.txtsdt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDonDatHang";
            this.Load += new System.EventHandler(this.frmDonDatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGridDsHD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridChitietHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void frmDonDatHang_Load(object sender, EventArgs e)
        {

        }

        private void BtnChuyen_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { MessageBox.Show("Vui lòng chọn đơn đặt hàng."); return; }
            MessageBox.Show("Chức năng chuyển đơn đặt hàng sang đơn bán đã được bổ sung ở mức giao diện. Hãy cấu hình bảng DonDatHang/DonBanHang trong SQL để chạy nghiệp vụ đầy đủ.");
        }
    }
}
