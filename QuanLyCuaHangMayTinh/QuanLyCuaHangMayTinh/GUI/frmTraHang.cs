using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.QuanLy
{
    public class frmTraHang : Form
    {
        private readonly DataGridView dgvHoaDon = new DataGridView();
        private readonly DataGridView dgvChiTiet = new DataGridView();
        private readonly Button btnTai = new Button();
        private readonly Button btnTaoPhieuTra = new Button();
        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private TextBox txtChucVu;
        private Label label3;
        private TextBox txtMaNV;
        private TextBox txtHoTen;
        private Label label2;
        private readonly SplitContainer split = new SplitContainer();

        public frmTraHang()
        {
            Text = "Trả hàng";
            Width = 1100;
            Height = 650;

            btnTai.Text = "Tải hóa đơn";
            btnTai.Width = 120;
            btnTai.Click += (s, e) => LoadInvoices();

            btnTaoPhieuTra.Text = "Tạo phiếu trả";
            btnTaoPhieuTra.Width = 140;
            btnTaoPhieuTra.Click += BtnTaoPhieuTra_Click;

            FlowLayoutPanel top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 42 };
            top.Controls.Add(btnTai);
            top.Controls.Add(btnTaoPhieuTra);

            split.Dock = DockStyle.Fill;
            split.Orientation = Orientation.Vertical;
            split.SplitterDistance = 600;

            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.Click += (s, e) => LoadInvoiceDetails();

            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.MultiSelect = false;

            split.Panel1.Controls.Add(dgvHoaDon);
            split.Panel2.Controls.Add(dgvChiTiet);

            Controls.Add(split);
            Controls.Add(top);
            Load += (s, e) => LoadInvoices();
        }

        private void LoadInvoices()
        {
            string sql = @"SELECT h.MaHoaDonBan, h.NgayBan, kh.TenKhachHang, nv.HoTen AS TenNhanVien, h.TrangThai, h.TongTien
                           FROM HoaDonBan h
                           INNER JOIN KhachHang kh ON h.MaKhachHang = kh.MaKhachHang
                           INNER JOIN NhanVien nv ON h.MaNhanVien = nv.MaNhanVien
                           ORDER BY h.NgayBan DESC";
            dgvHoaDon.DataSource = Function.GetDataToTable(sql);
        }

        private void LoadInvoiceDetails()
        {
            if (dgvHoaDon.CurrentRow == null) return;
            string ma = Convert.ToString(dgvHoaDon.CurrentRow.Cells["MaHoaDonBan"].Value);
            string sql = @"SELECT ct.MaSanPham, sp.TenSanPham, ct.SoLuong, ct.DonGia, ct.SoLuong * ct.DonGia AS ThanhTien
                           FROM ChiTietHoaDonBan ct
                           INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                           WHERE ct.MaHoaDonBan = @MaHoaDonBan";
            dgvChiTiet.DataSource = Function.GetDataToTable(sql, new SqlParameter("@MaHoaDonBan", ma));
        }

        private void BtnTaoPhieuTra_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null || dgvChiTiet.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn và sản phẩm cần trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maHoaDon = Convert.ToString(dgvHoaDon.CurrentRow.Cells["MaHoaDonBan"].Value);
            string maSanPham = Convert.ToString(dgvChiTiet.CurrentRow.Cells["MaSanPham"].Value);
            decimal donGia = Convert.ToDecimal(dgvChiTiet.CurrentRow.Cells["DonGia"].Value);
            int soLuongDaBan = Convert.ToInt32(dgvChiTiet.CurrentRow.Cells["SoLuong"].Value);
            int soLuongTra = 1;
            if (soLuongDaBan <= 0)
            {
                MessageBox.Show("Số lượng trả không hợp lệ.");
                return;
            }
            string maPhieuTra = "PTH" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string maNhanVien = string.IsNullOrWhiteSpace(StaticData.MaNV) ? "NV004" : StaticData.MaNV;

            using (var conn = DapperRepository.CreateConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new SqlCommand(@"INSERT INTO PhieuTraHang(MaPhieuTraHang, NgayTra, MaHoaDonBan, MaNhanVien, TongTien)
                                                         VALUES(@Ma, GETDATE(), @MaHoaDon, @MaNhanVien, @TongTien)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Ma", maPhieuTra);
                            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                            cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                            cmd.Parameters.AddWithValue("@TongTien", donGia * soLuongTra);
                            cmd.ExecuteNonQuery();
                        }
                        using (var cmd = new SqlCommand(@"INSERT INTO ChiTietPhieuTraHang(MaPhieuTraHang, MaSanPham, SoLuongTra, DonGia)
                                                         VALUES(@MaPhieuTra, @MaSanPham, @SoLuongTra, @DonGia)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaPhieuTra", maPhieuTra);
                            cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                            cmd.Parameters.AddWithValue("@SoLuongTra", soLuongTra);
                            cmd.Parameters.AddWithValue("@DonGia", donGia);
                            cmd.ExecuteNonQuery();
                        }
                        using (var cmd = new SqlCommand("UPDATE SanPham SET SoLuongTon = SoLuongTon + @SoLuongTra WHERE MaSanPham = @MaSanPham", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@SoLuongTra", soLuongTra);
                            cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                            cmd.ExecuteNonQuery();
                        }
                        tran.Commit();
                        MessageBox.Show("Đã tạo phiếu trả hàng: " + maPhieuTra, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Không tạo được phiếu trả hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(615, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 44);
            this.label1.TabIndex = 22;
            this.label1.Text = "Mã nhân viên:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txtChucVu);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMaNV);
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-514, -272);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1629, 904);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(69, 146);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(458, 472);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // txtChucVu
            // 
            this.txtChucVu.BackColor = System.Drawing.Color.Green;
            this.txtChucVu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChucVu.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChucVu.ForeColor = System.Drawing.Color.Yellow;
            this.txtChucVu.Location = new System.Drawing.Point(888, 489);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.ReadOnly = true;
            this.txtChucVu.Size = new System.Drawing.Size(292, 43);
            this.txtChucVu.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(615, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 44);
            this.label3.TabIndex = 26;
            this.label3.Text = "Chức vụ:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.BackColor = System.Drawing.Color.Green;
            this.txtMaNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaNV.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.ForeColor = System.Drawing.Color.Yellow;
            this.txtMaNV.Location = new System.Drawing.Point(888, 255);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(292, 43);
            this.txtMaNV.TabIndex = 25;
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.Color.Green;
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHoTen.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.ForeColor = System.Drawing.Color.Yellow;
            this.txtHoTen.Location = new System.Drawing.Point(888, 372);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(292, 43);
            this.txtHoTen.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(615, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 44);
            this.label2.TabIndex = 23;
            this.label2.Text = "Họ tên:";
            // 
            // frmTraHang
            // 
            this.ClientSize = new System.Drawing.Size(1123, 640);
            this.Controls.Add(this.panel1);
            this.Name = "frmTraHang";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
