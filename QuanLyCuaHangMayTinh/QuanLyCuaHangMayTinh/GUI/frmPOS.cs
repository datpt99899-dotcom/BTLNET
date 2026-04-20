using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmBanhang_Nhanvien : Form
    {
        private DataTable cartTable;
        private string currentInvoiceId = string.Empty;

        public frmBanhang_Nhanvien()
        {
            InitializeComponent();
        }

        private void frmBanhang_Nhanvien_Load(object sender, EventArgs e)
        {
            InitializeButtonStyles();
            InitializeOptions();
            InitializeCart();
            LoadProductCards();
            grBan.Text = "DANH SÁCH SẢN PHẨM";
            grChitietban.Text = "GIỎ HÀNG / POS";
            btnChuyenban.Enabled = false;
            btnGopban.Enabled = false;
            cbChuyenban.Enabled = false;
            cbGopban.Enabled = false;
            txtKhachhang.Enabled = false;
            btnThanhvien.Enabled = false;
            txtTongtien.Enabled = false;
            txtMagiamgia.Text = "0";
            lbThonbaogiamgia.Text = string.Empty;
        }

        private void InitializeButtonStyles()
        {
            foreach (var button in new[] { btnThanhvien, btnAdd, btnThem, btnThemmon, btnXoamon, btnSuamon, btnThanhtoan, btnGiamgia, btnBoqua, btnSua, btnThoat })
            {
                if (button == null) continue;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }
        }

        private void InitializeOptions()
        {
            cbThanhvien.Items.Clear();
            cbThanhvien.Items.AddRange(new object[] { "Thành viên", "Khách lẻ" });
            cbThanhvien.SelectedIndex = 1;

            DataTable hinhThuc = new DataTable();
            hinhThuc.Columns.Add("Ma");
            hinhThuc.Columns.Add("Ten");
            hinhThuc.Rows.Add("POS", "Bán trực tiếp");
            hinhThuc.Rows.Add("CALL", "Đặt qua điện thoại");
            cbHinhthuc.DataSource = hinhThuc;
            cbHinhthuc.ValueMember = "Ma";
            cbHinhthuc.DisplayMember = "Ten";
            cbHinhthuc.SelectedIndex = 0;

            Function.FillCombo("SELECT MaLoai, TenLoai FROM LoaiSanPham", cbDanhmuc, "MaLoai", "TenLoai");
            cbDanhmuc.SelectedIndex = -1;
            cbThucuong.DataSource = null;
        }

        private void InitializeCart()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("MaSanPham");
            cartTable.Columns.Add("TenSanPham");
            cartTable.Columns.Add("DonGia", typeof(decimal));
            cartTable.Columns.Add("SoLuong", typeof(int));
            cartTable.Columns.Add("ThanhTien", typeof(decimal), "DonGia * SoLuong");
            cartTable.Columns.Add("GhiChu");
            dGridChitietban.DataSource = cartTable;
            if (dGridChitietban.Columns.Contains("MaSanPham")) dGridChitietban.Columns["MaSanPham"].Visible = false;
            dGridChitietban.AllowUserToAddRows = false;
            dGridChitietban.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadProductCards(string maLoai = null)
        {
            flowLayoutPanel1.Controls.Clear();
            string sql = @"SELECT MaSanPham, TenSanPham, GiaBan, SoLuongTon FROM SanPham
                           WHERE (@MaLoai IS NULL OR @MaLoai = '' OR MaLoai = @MaLoai)
                           ORDER BY TenSanPham";
            DataTable dt = Function.GetDataToTable(sql, new SqlParameter("@MaLoai", (object)maLoai ?? DBNull.Value));
            foreach (DataRow row in dt.Rows)
            {
                Panel p = new Panel
                {
                    Width = 185,
                    Height = 100,
                    Margin = new Padding(8),
                    BackColor = Color.WhiteSmoke,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = row["MaSanPham"].ToString()
                };
                Label lbName = new Label { Text = row["TenSanPham"].ToString(), AutoSize = false, Width = 165, Height = 40, Left = 10, Top = 10 };
                Label lbPrice = new Label { Text = Convert.ToDecimal(row["GiaBan"]).ToString("N0") + " đ", AutoSize = true, Left = 10, Top = 58, ForeColor = Color.DarkGreen };
                Label lbStock = new Label { Text = "Tồn: " + row["SoLuongTon"].ToString(), AutoSize = true, Left = 95, Top = 58, ForeColor = Color.SteelBlue };
                EventHandler choose = (s, e) => SelectProduct(row["MaSanPham"].ToString(), row["TenSanPham"].ToString());
                p.Click += choose; lbName.Click += choose; lbPrice.Click += choose; lbStock.Click += choose;
                p.Controls.Add(lbName); p.Controls.Add(lbPrice); p.Controls.Add(lbStock);
                flowLayoutPanel1.Controls.Add(p);
            }
        }

        private void SelectProduct(string maSanPham, string tenSanPham)
        {
            if (cbThucuong.DataSource == null)
            {
                DataTable dt = Function.GetDataToTable("SELECT MaSanPham, TenSanPham FROM SanPham ORDER BY TenSanPham");
                cbThucuong.DataSource = dt;
                cbThucuong.ValueMember = "MaSanPham";
                cbThucuong.DisplayMember = "TenSanPham";
            }
            cbThucuong.SelectedValue = maSanPham;
            txtGhichu.Focus();
        }

        private void ResetSale()
        {
            currentInvoiceId = string.Empty;
            cartTable.Rows.Clear();
            cbThanhvien.SelectedIndex = 1;
            txtSodienthoai.Text = "";
            txtKhachhang.Text = "";
            txtGhichu.Text = "";
            numSoluong.Value = 1;
            txtMagiamgia.Text = "0";
            lbThonbaogiamgia.Text = string.Empty;
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal tong = 0;
            foreach (DataRow row in cartTable.Rows)
            {
                tong += Convert.ToDecimal(row["ThanhTien"]);
            }
            decimal giam = 0;
            decimal.TryParse(txtMagiamgia.Text, out giam);
            if (giam < 0) giam = 0;
            if (giam > 100) giam = 100;
            decimal tongSauGiam = tong * (100 - giam) / 100;
            txtTongtien.Text = tongSauGiam.ToString("N0");
            btnThanhtoan.Enabled = cartTable.Rows.Count > 0;
        }

        private string EnsureCustomer()
        {
            if (cbThanhvien.SelectedIndex == 0)
            {
                if (string.IsNullOrWhiteSpace(txtSodienthoai.Text)) throw new InvalidOperationException("Vui lòng nhập số điện thoại khách hàng.");
                string maKhachHang = Function.GetFieldValues("SELECT MaKhachHang FROM KhachHang WHERE SoDienThoai = N'" + txtSodienthoai.Text.Trim() + "'");
                if (string.IsNullOrWhiteSpace(maKhachHang))
                {
                    maKhachHang = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string ten = string.IsNullOrWhiteSpace(txtKhachhang.Text) ? "Khách hàng thành viên" : txtKhachhang.Text.Trim();
                    Function.RunSql(@"INSERT INTO KhachHang(MaKhachHang, TenKhachHang, SoDienThoai, Email, DiaChi, DiemTichLuy)
                                      VALUES(@MaKhachHang,@TenKhachHang,@SoDienThoai,'','',0)",
                        new SqlParameter("@MaKhachHang", maKhachHang),
                        new SqlParameter("@TenKhachHang", ten),
                        new SqlParameter("@SoDienThoai", txtSodienthoai.Text.Trim()));
                }
                return maKhachHang;
            }
            string guest = Function.GetFieldValues("SELECT MaKhachHang FROM KhachHang WHERE TenKhachHang = N'Khách lẻ POS'");
            if (string.IsNullOrWhiteSpace(guest))
            {
                guest = "KHLE";
                Function.RunSql(@"IF NOT EXISTS(SELECT 1 FROM KhachHang WHERE MaKhachHang = N'KHLE')
                                  INSERT INTO KhachHang(MaKhachHang, TenKhachHang, SoDienThoai, Email, DiaChi, DiemTichLuy)
                                  VALUES(N'KHLE',N'Khách lẻ POS','','','',0)");
            }
            return "KHLE";
        }

        private void txMagiamgia_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetSale();
            lbThonbaogiamgia.Text = "Đã tạo phiên bán mới";
        }

        private void cbThanhvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool member = cbThanhvien.SelectedIndex == 0;
            txtSodienthoai.Enabled = member;
            btnThanhvien.Enabled = member;
            if (!member)
            {
                txtSodienthoai.Text = "";
                txtKhachhang.Text = "Khách lẻ POS";
            }
        }

        private void btnThanhvien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSodienthoai.Text)) return;
            string sql = "SELECT TenKhachHang FROM KhachHang WHERE SoDienThoai = N'" + txtSodienthoai.Text.Trim() + "'";
            txtKhachhang.Text = Function.GetFieldValues(sql) ?? "Khách hàng mới";
        }

        private void cbDanhmuc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbDanhmuc.SelectedValue == null) return;
            string maLoai = cbDanhmuc.SelectedValue.ToString();
            Function.FillCombo("SELECT MaSanPham, TenSanPham FROM SanPham WHERE MaLoai = N'" + maLoai + "' ORDER BY TenSanPham", cbThucuong, "MaSanPham", "TenSanPham");
            cbThucuong.SelectedIndex = -1;
            LoadProductCards(maLoai);
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            numSoluong.Value = 1;
            txtGhichu.Text = "";
            cbThucuong.SelectedIndex = -1;
        }

        private void btnThemmon_Click(object sender, EventArgs e)
        {
            if (cbThucuong.SelectedValue == null) { MessageBox.Show("Vui lòng chọn sản phẩm."); return; }
            string maSanPham = cbThucuong.SelectedValue.ToString();
            DataTable sp = Function.GetDataToTable("SELECT MaSanPham, TenSanPham, GiaBan, SoLuongTon FROM SanPham WHERE MaSanPham = @MaSanPham", new SqlParameter("@MaSanPham", maSanPham));
            if (sp.Rows.Count == 0) return;
            int soLuongTon = Convert.ToInt32(sp.Rows[0]["SoLuongTon"]);
            int soLuong = Convert.ToInt32(numSoluong.Value);
            if (soLuong > soLuongTon) { MessageBox.Show("Số lượng tồn không đủ."); return; }
            DataRow existing = cartTable.Select("MaSanPham = '" + maSanPham.Replace("'", "''") + "'").FirstOrDefault();
            if (existing == null)
            {
                cartTable.Rows.Add(maSanPham, sp.Rows[0]["TenSanPham"].ToString(), Convert.ToDecimal(sp.Rows[0]["GiaBan"]), soLuong, null, txtGhichu.Text.Trim());
            }
            else
            {
                existing["SoLuong"] = Convert.ToInt32(existing["SoLuong"]) + soLuong;
                existing["GhiChu"] = txtGhichu.Text.Trim();
            }
            UpdateTotal();
        }

        private void dGridChitietban_Click(object sender, EventArgs e)
        {
            if (dGridChitietban.CurrentRow == null) return;
            cbThucuong.SelectedValue = Convert.ToString(dGridChitietban.CurrentRow.Cells["MaSanPham"].Value);
            numSoluong.Value = Convert.ToDecimal(dGridChitietban.CurrentRow.Cells["SoLuong"].Value);
            txtGhichu.Text = Convert.ToString(dGridChitietban.CurrentRow.Cells["GhiChu"].Value);
        }

        private void dGridChitietban_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnSuamon_Click(object sender, EventArgs e)
        {
            if (dGridChitietban.CurrentRow == null) return;
            dGridChitietban.CurrentRow.Cells["SoLuong"].Value = Convert.ToInt32(numSoluong.Value);
            dGridChitietban.CurrentRow.Cells["GhiChu"].Value = txtGhichu.Text.Trim();
            UpdateTotal();
        }

        private void btnXoamon_Click(object sender, EventArgs e)
        {
            if (dGridChitietban.CurrentRow == null) return;
            dGridChitietban.Rows.RemoveAt(dGridChitietban.CurrentRow.Index);
            UpdateTotal();
        }

        private void btnGiamgia_Click(object sender, EventArgs e)
        {
            decimal giam;
            if (decimal.TryParse(txtMagiamgia.Text, out giam) && giam >= 0 && giam <= 100)
            {
                lbThonbaogiamgia.Text = "Áp dụng giảm giá " + giam + "%";
                UpdateTotal();
            }
            else
            {
                lbThonbaogiamgia.Text = "Giảm giá không hợp lệ";
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.");
                return;
            }
            try
            {
                string maKhachHang = EnsureCustomer();
                currentInvoiceId = "HDB" + DateTime.Now.ToString("yyyyMMddHHmmss");
                string maNhanVien = string.IsNullOrWhiteSpace(StaticData.MaNV) ? "NV003" : StaticData.MaNV;
                decimal tongTien;
                decimal.TryParse(txtTongtien.Text.Replace(",", ""), out tongTien);
                using (var conn = DapperRepository.CreateConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            using (var cmd = new SqlCommand(@"INSERT INTO HoaDonBan(MaHoaDonBan, NgayBan, MaKhachHang, MaNhanVien, MaDonDatHang, TongTien, TrangThai)
                                                             VALUES(@MaHoaDonBan, GETDATE(), @MaKhachHang, @MaNhanVien, NULL, @TongTien, N'Hoàn thành')", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaHoaDonBan", currentInvoiceId);
                                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                                cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                                cmd.ExecuteNonQuery();
                            }

                            foreach (DataRow row in cartTable.Rows)
                            {
                                using (var cmd = new SqlCommand(@"INSERT INTO ChiTietHoaDonBan(MaHoaDonBan, MaSanPham, SoLuong, DonGia)
                                                                 VALUES(@MaHoaDonBan, @MaSanPham, @SoLuong, @DonGia)", conn, tran))
                                {
                                    cmd.Parameters.AddWithValue("@MaHoaDonBan", currentInvoiceId);
                                    cmd.Parameters.AddWithValue("@MaSanPham", row["MaSanPham"].ToString());
                                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(row["SoLuong"]));
                                    cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(row["DonGia"]));
                                    cmd.ExecuteNonQuery();
                                }
                                using (var cmd = new SqlCommand("UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSanPham = @MaSanPham", conn, tran))
                                {
                                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(row["SoLuong"]));
                                    cmd.Parameters.AddWithValue("@MaSanPham", row["MaSanPham"].ToString());
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
                MessageBox.Show("Thanh toán thành công. Mã hóa đơn: " + currentInvoiceId, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetSale();
                LoadProductCards(cbDanhmuc.SelectedValue == null ? null : cbDanhmuc.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChuyenban_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng chuyển bàn không áp dụng cho cửa hàng máy tính.");
        }

        private void btnGopban_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng gộp bàn không áp dụng cho cửa hàng máy tính.");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ResetSale();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoadProductCards(cbDanhmuc.SelectedValue == null ? null : cbDanhmuc.SelectedValue.ToString());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ResetSale();
            MessageBox.Show("Đã làm mới phiên bán hàng.");
        }
    }
}
