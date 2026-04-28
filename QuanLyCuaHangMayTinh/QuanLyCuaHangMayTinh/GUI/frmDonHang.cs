using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public class frmDonHang : Form
    {
        // Controls
        private DataGridView dgvDonHang;
        private DataGridView dgvChiTiet;
        private ComboBox cboTrangThai;
        private TextBox txtMaDon;
        private Button btnCapNhat, btnChuyenHoaDon, btnTim, btnDong;
        private Label lblMaDon, lblTrangThai, lblThongTin;

        private DataTable dtDonHang;
        private DataTable dtChiTiet;
        private string currentMaDon = "";

        public frmDonHang()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dgvDonHang = new System.Windows.Forms.DataGridView();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnChuyenHoaDon = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblMaDon = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblThongTin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.ColumnHeadersHeight = 29;
            this.dgvDonHang.Location = new System.Drawing.Point(12, 87);
            this.dgvDonHang.MultiSelect = false;
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.ReadOnly = true;
            this.dgvDonHang.RowHeadersWidth = 51;
            this.dgvDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonHang.Size = new System.Drawing.Size(500, 267);
            this.dgvDonHang.TabIndex = 0;
            this.dgvDonHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonHang_CellClick);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.ColumnHeadersHeight = 29;
            this.dgvChiTiet.Location = new System.Drawing.Point(528, 87);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.Size = new System.Drawing.Size(400, 267);
            this.dgvChiTiet.TabIndex = 1;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Đang xử lý",
            "Đã giao",
            "Đã hủy"});
            this.cboTrangThai.Location = new System.Drawing.Point(139, 387);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(150, 31);
            this.cboTrangThai.TabIndex = 2;
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(118, 37);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.ReadOnly = true;
            this.txtMaDon.Size = new System.Drawing.Size(150, 30);
            this.txtMaDon.TabIndex = 3;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(319, 386);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(193, 32);
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "Cập nhật trạng thái";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnChuyenHoaDon
            // 
            this.btnChuyenHoaDon.Location = new System.Drawing.Point(549, 388);
            this.btnChuyenHoaDon.Name = "btnChuyenHoaDon";
            this.btnChuyenHoaDon.Size = new System.Drawing.Size(224, 30);
            this.btnChuyenHoaDon.TabIndex = 5;
            this.btnChuyenHoaDon.Text = "Chuyển thành hóa đơn";
            this.btnChuyenHoaDon.Click += new System.EventHandler(this.btnChuyenHoaDon_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(295, 32);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(122, 38);
            this.btnTim.TabIndex = 6;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(833, 390);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(95, 38);
            this.btnDong.TabIndex = 7;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // lblMaDon
            // 
            this.lblMaDon.Location = new System.Drawing.Point(12, 40);
            this.lblMaDon.Name = "lblMaDon";
            this.lblMaDon.Size = new System.Drawing.Size(83, 30);
            this.lblMaDon.TabIndex = 8;
            this.lblMaDon.Text = "Mã đơn:";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Location = new System.Drawing.Point(8, 390);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 23);
            this.lblTrangThai.TabIndex = 9;
            this.lblTrangThai.Text = "Trạng thái mới:";
            // 
            // lblThongTin
            // 
            this.lblThongTin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTin.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblThongTin.Location = new System.Drawing.Point(8, 9);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(281, 23);
            this.lblThongTin.TabIndex = 10;
            this.lblThongTin.Text = "DANH SÁCH ĐƠN HÀNG";
            // 
            // frmDonHang
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(940, 440);
            this.Controls.Add(this.dgvDonHang);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnChuyenHoaDon);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.lblMaDon);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblThongTin);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDonHang";
            this.Text = "Quản lý đơn hàng";
            this.Load += new System.EventHandler(this.frmDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void frmDonHang_Load(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void LoadDonHang(string filter = "")
        {
            string sql = @"SELECT MaDonDatHang, NgayDat, TenKhachHang, TongTien, TrangThai 
                           FROM DonDatHang d
                           INNER JOIN KhachHang k ON d.MaKhachHang = k.MaKhachHang";
            if (!string.IsNullOrEmpty(filter))
                sql += " WHERE MaDonDatHang LIKE @filter OR TenKhachHang LIKE @filter";
            sql += " ORDER BY NgayDat DESC";

            SqlParameter p = null;
            if (!string.IsNullOrEmpty(filter))
                p = new SqlParameter("@filter", "%" + filter + "%");

            dtDonHang = Function.GetDataToTable(sql, p);
            dgvDonHang.DataSource = dtDonHang;
            if (dgvDonHang.Columns.Count > 0)
            {
                dgvDonHang.Columns["MaDonDatHang"].HeaderText = "Mã đơn";
                dgvDonHang.Columns["NgayDat"].HeaderText = "Ngày đặt";
                dgvDonHang.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                dgvDonHang.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvDonHang.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentMaDon = dgvDonHang.Rows[e.RowIndex].Cells["MaDonDatHang"].Value.ToString();
                txtMaDon.Text = currentMaDon;
                // Load chi tiết đơn hàng
                LoadChiTiet(currentMaDon);
                // Set trạng thái hiện tại lên combobox
                string trangThai = dgvDonHang.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();
                cboTrangThai.SelectedItem = trangThai;
            }
        }

        private void LoadChiTiet(string maDon)
        {
            string sql = @"SELECT sp.TenSanPham, ct.SoLuong, ct.DonGia, ct.SoLuong * ct.DonGia AS ThanhTien
                           FROM ChiTietDonDatHang ct
                           INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                           WHERE ct.MaDonDatHang = @ma";
            dtChiTiet = Function.GetDataToTable(sql, new SqlParameter("@ma", maDon));
            dgvChiTiet.DataSource = dtChiTiet;
            if (dgvChiTiet.Columns.Count > 0)
            {
                dgvChiTiet.Columns["TenSanPham"].HeaderText = "Sản phẩm";
                dgvChiTiet.Columns["SoLuong"].HeaderText = "SL";
                dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaDon))
            {
                MessageBox.Show("Chọn đơn hàng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string trangThaiMoi = cboTrangThai.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(trangThaiMoi))
            {
                MessageBox.Show("Chọn trạng thái mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Cập nhật CSDL
            string sql = "UPDATE DonDatHang SET TrangThai = @tt WHERE MaDonDatHang = @ma";
            int kq = Function.ExecuteNonQuery(sql,
                new SqlParameter("@tt", trangThaiMoi),
                new SqlParameter("@ma", currentMaDon));
            if (kq > 0)
            {
                MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDonHang(); // refresh danh sách
                // Nếu đơn đã hủy hoặc giao thì không cho chuyển hóa đơn nữa? Tùy logic
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChuyenHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaDon))
            {
                MessageBox.Show("Chọn đơn hàng để chuyển thành hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra trạng thái đơn hàng: chỉ chuyển được nếu chưa hủy và chưa tạo hóa đơn
            DataTable dt = Function.GetDataToTable("SELECT TrangThai, DaTaoHoaDon FROM DonDatHang WHERE MaDonDatHang = @ma",
                new SqlParameter("@ma", currentMaDon));
            if (dt.Rows.Count > 0)
            {
                string tt = dt.Rows[0]["TrangThai"].ToString();
                bool daTao = false;
                if (dt.Columns.Contains("DaTaoHoaDon") && dt.Rows[0]["DaTaoHoaDon"] != DBNull.Value)
                    daTao = Convert.ToBoolean(dt.Rows[0]["DaTaoHoaDon"]);
                if (tt == "Đã hủy")
                {
                    MessageBox.Show("Đơn hàng đã hủy không thể chuyển thành hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (daTao)
                {
                    MessageBox.Show("Đơn hàng này đã được chuyển thành hóa đơn trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Tiến hành tạo hóa đơn từ đơn đặt hàng
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn tạo hóa đơn từ đơn đặt hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = Function.GetSqlConnection())
                    {
                        conn.Open();
                        SqlTransaction trans = conn.BeginTransaction();
                        try
                        {
                            // Lấy thông tin đơn đặt
                            DataTable dtDon = Function.GetDataToTable("SELECT MaKhachHang, TongTien FROM DonDatHang WHERE MaDonDatHang = @ma",
                                new SqlParameter("@ma", currentMaDon));
                            if (dtDon.Rows.Count == 0) throw new Exception("Không tìm thấy đơn hàng");
                            string maKhach = dtDon.Rows[0]["MaKhachHang"].ToString();
                            decimal tongTienDon = Convert.ToDecimal(dtDon.Rows[0]["TongTien"]);

                            // Tạo mã hóa đơn mới
                            string maHoaDon = TaoMaHoaDonMoi();

                            // Chèn hóa đơn
                            string sqlHD = @"INSERT INTO HoaDonBan (MaHoaDonBan, NgayBan, MaNhanVien, MaKhachHang, TongTien, TrangThai, MaDonDatHang)
                                             VALUES (@mahd, @ngay, @manv, @makh, @tong, N'Đã thanh toán', @madon)";
                            SqlCommand cmd = new SqlCommand(sqlHD, conn, trans);
                            cmd.Parameters.AddWithValue("@mahd", maHoaDon);
                            cmd.Parameters.AddWithValue("@ngay", DateTime.Now);
                            cmd.Parameters.AddWithValue("@manv", GetCurrentNhanVien()); // Hàm lấy nhân viên đang đăng nhập
                            cmd.Parameters.AddWithValue("@makh", maKhach);
                            cmd.Parameters.AddWithValue("@tong", tongTienDon);
                            cmd.Parameters.AddWithValue("@madon", currentMaDon);
                            cmd.ExecuteNonQuery();

                            // Lấy chi tiết đơn đặt và chèn vào chi tiết hóa đơn
                            DataTable dtCT = Function.GetDataToTable("SELECT MaSanPham, SoLuong, DonGia FROM ChiTietDonDatHang WHERE MaDonDatHang = @ma",
                                new SqlParameter("@ma", currentMaDon));
                            string sqlCT = @"INSERT INTO ChiTietHoaDonBan (MaHoaDonBan, MaSanPham, SoLuong, DonGia, GiamGia)
                                             VALUES (@mahd, @masp, @sl, @dongia, 0)";
                            foreach (DataRow row in dtCT.Rows)
                            {
                                SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                                cmdCT.Parameters.AddWithValue("@mahd", maHoaDon);
                                cmdCT.Parameters.AddWithValue("@masp", row["MaSanPham"]);
                                cmdCT.Parameters.AddWithValue("@sl", row["SoLuong"]);
                                cmdCT.Parameters.AddWithValue("@dongia", row["DonGia"]);
                                cmdCT.ExecuteNonQuery();
                            }

                            // Cập nhật cờ đã tạo hóa đơn trên đơn đặt (nếu có cột)
                            string sqlUpdate = "UPDATE DonDatHang SET DaTaoHoaDon = 1 WHERE MaDonDatHang = @ma";
                            SqlCommand cmdUpd = new SqlCommand(sqlUpdate, conn, trans);
                            cmdUpd.Parameters.AddWithValue("@ma", currentMaDon);
                            cmdUpd.ExecuteNonQuery();

                            trans.Commit();
                            MessageBox.Show($"Chuyển đơn hàng thành công! Mã hóa đơn: {maHoaDon}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDonHang(); // refresh
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Lỗi khi tạo hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối CSDL lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string TaoMaHoaDonMoi()
        {
            // Tương tự như trong frmChiTietHoaDon
            string today = DateTime.Now.ToString("yyyyMMdd");
            string sql = "SELECT TOP 1 MaHoaDonBan FROM HoaDonBan WHERE MaHoaDonBan LIKE @prefix ORDER BY MaHoaDonBan DESC";
            DataTable dt = Function.GetDataToTable(sql, new SqlParameter("@prefix", "HDB" + today + "%"));
            int stt = 1;
            if (dt.Rows.Count > 0)
            {
                string last = dt.Rows[0][0].ToString();
                if (last.Length >= 13 && int.TryParse(last.Substring(11), out int lastNum))
                    stt = lastNum + 1;
            }
            return "HDB" + today + stt.ToString("D3");
        }

        private string GetCurrentNhanVien()
        {
            // Giả sử có biến toàn cục lưu mã nhân viên hiện tại, nếu không thì trả về 'NV001'
            // Bạn có thể thay bằng logic lấy từ session
            return "NV001";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã đơn hoặc tên khách hàng:", "Tìm kiếm", "");
            LoadDonHang(keyword);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}