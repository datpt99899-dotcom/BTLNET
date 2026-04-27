using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmNhapKho : Form
    {
        private DataTable tblPN;                     // Danh sách phiếu nhập từ DB
        private DataTable tblTamThoi;                // DataTable tạm thời cho chi tiết
        private bool addingHeader;
        private int STT = 0;

        public frmNhapKho()
        {
            InitializeComponent();
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            txtTongTien.Enabled = false;
            txtMaPN.Enabled = false;
            txtThanhTien.Enabled = false;

            Function.Connect();
            LoadCombos();
            LoadReceiptGrid();
            InitializeDetailGrid();
            ResetForm();
        }

        // ===== KHỞI TẠO DATATABLE TẠM THỜI =====
        private void InitializeDetailGrid()
        {
            tblTamThoi = new DataTable();
            tblTamThoi.Columns.Add("STT", typeof(int));
            tblTamThoi.Columns.Add("MaSanPham", typeof(string));
            tblTamThoi.Columns.Add("TenSanPham", typeof(string));
            tblTamThoi.Columns.Add("SoLuong", typeof(int));
            tblTamThoi.Columns.Add("DonGiaNhap", typeof(decimal));
            tblTamThoi.Columns.Add("ThanhTien", typeof(decimal));

            dataGridView1.DataSource = tblTamThoi;
            ConfigureDetailGridView();
        }

        private void ConfigureDetailGridView()
        {
            if (dataGridView1.Columns.Count >= 6)
            {
                dataGridView1.Columns[0].HeaderText = "STT";
                dataGridView1.Columns[0].Width = 50;

                dataGridView1.Columns[1].HeaderText = "Mã sản phẩm";
                dataGridView1.Columns[1].Width = 100;

                dataGridView1.Columns[2].HeaderText = "Tên sản phẩm";
                dataGridView1.Columns[2].Width = 300;

                dataGridView1.Columns[3].HeaderText = "Số lượng";
                dataGridView1.Columns[3].Width = 80;

                dataGridView1.Columns[4].HeaderText = "Đơn giá nhập (đ)";
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dataGridView1.Columns[5].HeaderText = "Thành tiền (đ)";
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[5].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        // ===== LỰA CHỌN SAI PHẨM TỪ COMBOBOX =====
        private void LoadCombos()
        {
            Function.FillCombo("SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap",
                cboNhaCungCap, "MaNhaCungCap", "TenNhaCungCap");
            cboNhaCungCap.SelectedIndex = -1;

            Function.FillCombo("SELECT MaNhanVien, HoTen FROM NhanVien WHERE MaVaiTro IN (N'VT01',N'VT02')",
                cboNVNhap, "MaNhanVien", "HoTen");
            cboNVNhap.SelectedIndex = -1;
        }

        // ===== LOAD DANH SÁCH PHIẾU NHẬP TỪ DATABASE =====
        private void LoadReceiptGrid()
        {
            string sql = @"SELECT pn.MaPhieuNhap, pn.NgayNhap, nv.HoTen, ncc.TenNhaCungCap, pn.TongTien,
                                  pn.MaNhaCungCap, pn.MaNhanVien
                           FROM PhieuNhapKho pn
                           INNER JOIN NhanVien nv ON pn.MaNhanVien = nv.MaNhanVien
                           INNER JOIN NhaCungCap ncc ON pn.MaNhaCungCap = ncc.MaNhaCungCap
                           ORDER BY pn.NgayNhap DESC";
            tblPN = Function.GetDataToTable(sql);

            if (tblPN.Rows.Count > 0)
            {
                txtMaPN.Text = tblPN.Rows[0]["MaPhieuNhap"].ToString();
                dtpNgayNhap.Value = Convert.ToDateTime(tblPN.Rows[0]["NgayNhap"]);
                cboNVNhap.SelectedValue = tblPN.Rows[0]["MaNhanVien"];
                cboNhaCungCap.SelectedValue = tblPN.Rows[0]["MaNhaCungCap"];
                txtTongTien.Text = Convert.ToDecimal(tblPN.Rows[0]["TongTien"]).ToString("N0");
                LoadDetailGridFromDB(txtMaPN.Text);
            }
            else
            {
                ResetForm();
            }
        }

        // ===== LOAD CHI TIẾT PHIẾU NHẬP TỪ DATABASE =====
        private void LoadDetailGridFromDB(string maPhieuNhap)
        {
            string sql = @"SELECT ct.MaPhieuNhap, ct.MaSanPham, sp.TenSanPham, ct.SoLuong, ct.DonGiaNhap,
                                  ct.SoLuong * ct.DonGiaNhap AS ThanhTien
                           FROM ChiTietPhieuNhap ct
                           INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                           WHERE ct.MaPhieuNhap = @MaPhieuNhap";
            DataTable tblCT = Function.GetDataToTable(sql, new SqlParameter("@MaPhieuNhap", maPhieuNhap));
            dataGridView1.DataSource = tblCT;
            ConfigureDetailGridView();
            UpdateTotalFromDB(maPhieuNhap);
        }

        private void UpdateTotalFromDB(string maPhieuNhap)
        {
            string sumSql = "SELECT ISNULL(SUM(SoLuong * DonGiaNhap),0) FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap";
            string value = Function.GetFieldValues(sumSql.Replace("@MaPhieuNhap", "N'" + maPhieuNhap + "'"));
            txtTongTien.Text = string.IsNullOrWhiteSpace(value) ? "0" : Convert.ToDecimal(value).ToString("N0");
        }

        // ===== TÌM SẢN PHẨM VỀ THÀNH TIỀN =====
        private void UpdateThanhTien()
        {
            int soLuong = 0;
            decimal donGia = 0;
            int.TryParse(txtSLNhap.Text, out soLuong);
            decimal.TryParse(txtDonGiaNhap.Text, out donGia);

            decimal thanhTien = soLuong * donGia;
            txtThanhTien.Text = thanhTien.ToString("N0");
        }

        // ===== TÍNH TỔNG TIỀN DATAGRIDVIEW TẠM THỜI =====
        private void UpdateTotalTemporary()
        {
            decimal total = 0;
            foreach (DataRow row in tblTamThoi.Rows)
            {
                total += Convert.ToDecimal(row["ThanhTien"]);
            }
            txtTongTien.Text = total.ToString("N0");
        }

        private void ResetForm()
        {
            txtMaPN.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
            cboNVNhap.SelectedIndex = -1;
            cboNhaCungCap.SelectedIndex = -1;
            txtTongTien.Text = "0";
            txtSLNhap.Text = "";
            txtDonGiaNhap.Text = "";
            txtThanhTien.Text = "";
            txtTimSP.Text = "";
            InitializeDetailGrid();
            STT = 0;
        }

        // ===== CLICK CHỌN DỮ LIỆU TỪ COMBOBOX =====
        private void cboNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tính thành tiền mỗi khi thay đổi combobox
            UpdateThanhTien();
        }

        // ===== CLICK CHỌN DÒNG TRONG DATAGRIDVIEW =====
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            // Nếu từ Database (có cột MaPhieuNhap)
            if (dataGridView1.Columns.Contains("MaPhieuNhap"))
            {
                txtSLNhap.Text = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();
                txtDonGiaNhap.Text = dataGridView1.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
                UpdateThanhTien();
            }
        }

        private string GenerateReceiptCode() => "PNK" + DateTime.Now.ToString("yyyyMMddHHmmss");

        // ===== BUTTON: TẠO PHIẾU NHẬP MỚI =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            addingHeader = true;
            ResetForm();
            txtMaPN.Text = GenerateReceiptCode();
            dtpNgayNhap.Enabled = true;
            cboNVNhap.Enabled = true;
            cboNhaCungCap.Enabled = true;
        }

        // ===== BUTTON: LƯU PHIẾU NHẬP (HEADER) =====
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPN.Text) || cboNVNhap.SelectedIndex < 0 || cboNhaCungCap.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin phiếu nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tblTamThoi.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào phiếu nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lưu header phiếu nhập
                if (addingHeader)
                {
                    Function.RunSql(@"INSERT INTO PhieuNhapKho(MaPhieuNhap, NgayNhap, MaNhaCungCap, MaNhanVien, TongTien, GhiChu)
                                      VALUES(@MaPhieuNhap, @NgayNhap, @MaNhaCungCap, @MaNhanVien, 0, @GhiChu)",
                        new SqlParameter("@MaPhieuNhap", txtMaPN.Text.Trim()),
                        new SqlParameter("@NgayNhap", dtpNgayNhap.Value),
                        new SqlParameter("@MaNhaCungCap", cboNhaCungCap.SelectedValue),
                        new SqlParameter("@MaNhanVien", cboNVNhap.SelectedValue),
                        new SqlParameter("@GhiChu", txtGhiChu.Text.Trim()));
                }
                else
                {
                    Function.RunSql(@"UPDATE PhieuNhapKho 
                                      SET NgayNhap=@NgayNhap, MaNhaCungCap=@MaNhaCungCap, MaNhanVien=@MaNhanVien, GhiChu=@GhiChu 
                                      WHERE MaPhieuNhap=@MaPhieuNhap",
                        new SqlParameter("@NgayNhap", dtpNgayNhap.Value),
                        new SqlParameter("@MaNhaCungCap", cboNhaCungCap.SelectedValue),
                        new SqlParameter("@MaNhanVien", cboNVNhap.SelectedValue),
                        new SqlParameter("@GhiChu", txtGhiChu.Text.Trim()),
                        new SqlParameter("@MaPhieuNhap", txtMaPN.Text.Trim()));
                }

                // Lưu chi tiết phiếu nhập
                foreach (DataRow row in tblTamThoi.Rows)
                {
                    string maSanPham = row["MaSanPham"].ToString();
                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                    decimal donGia = Convert.ToDecimal(row["DonGiaNhap"]);

                    Function.RunSql(@"INSERT INTO ChiTietPhieuNhap(MaPhieuNhap, MaSanPham, SoLuong, DonGiaNhap)
                                      VALUES(@MaPhieuNhap, @MaSanPham, @SoLuong, @DonGiaNhap)",
                        new SqlParameter("@MaPhieuNhap", txtMaPN.Text.Trim()),
                        new SqlParameter("@MaSanPham", maSanPham),
                        new SqlParameter("@SoLuong", soLuong),
                        new SqlParameter("@DonGiaNhap", donGia));

                    // Cập nhật tồn kho sản phẩm
                    Function.RunSql("UPDATE SanPham SET SoLuongTon = SoLuongTon + @SoLuong, GiaNhap = @GiaNhap WHERE MaSanPham=@MaSanPham",
                        new SqlParameter("@SoLuong", soLuong),
                        new SqlParameter("@GiaNhap", donGia),
                        new SqlParameter("@MaSanPham", maSanPham));
                }

                MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                addingHeader = false;
                dtpNgayNhap.Enabled = false;
                cboNVNhap.Enabled = false;
                cboNhaCungCap.Enabled = false;
                LoadReceiptGrid();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== BUTTON: THÊM SẢN PHẨM VÀO DATAGRIDVIEW TẠM THỜI =====
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            // Tìm sản phẩm từ txtTimSP
            if (string.IsNullOrWhiteSpace(txtTimSP.Text) || string.IsNullOrWhiteSpace(txtSLNhap.Text) || string.IsNullOrWhiteSpace(txtDonGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong = 0;
            decimal donGia = 0;
            int.TryParse(txtSLNhap.Text, out soLuong);
            decimal.TryParse(txtDonGiaNhap.Text, out donGia);

            if (soLuong <= 0 || donGia <= 0)
            {
                MessageBox.Show("Số lượng và đơn giá phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin sản phẩm từ database dựa trên txtTimSP
            string sql = "SELECT MaSanPham, TenSanPham FROM SanPham WHERE MaSanPham LIKE @Ma OR TenSanPham LIKE @Ten LIMIT 1";
            DataTable dt = Function.GetDataToTable(sql,
                new SqlParameter("@Ma", "%" + txtTimSP.Text + "%"),
                new SqlParameter("@Ten", "%" + txtTimSP.Text + "%"));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSanPham = dt.Rows[0]["MaSanPham"].ToString();
            string tenSanPham = dt.Rows[0]["TenSanPham"].ToString();
            decimal thanhTien = soLuong * donGia;

            // Kiểm tra sản phẩm đã có trong DataGridView chưa
            bool existsInGrid = false;
            foreach (DataRow row in tblTamThoi.Rows)
            {
                if (row["MaSanPham"].ToString() == maSanPham)
                {
                    // Cộng số lượng nếu đã có
                    int oldQty = Convert.ToInt32(row["SoLuong"]);
                    row["SoLuong"] = oldQty + soLuong;
                    row["DonGiaNhap"] = donGia;
                    row["ThanhTien"] = (oldQty + soLuong) * donGia;
                    existsInGrid = true;
                    break;
                }
            }

            // Thêm dòng mới nếu sản phẩm chưa có
            if (!existsInGrid)
            {
                STT++;
                tblTamThoi.Rows.Add(STT, maSanPham, tenSanPham, soLuong, donGia, thanhTien);
            }

            dataGridView1.DataSource = tblTamThoi.Copy();
            ConfigureDetailGridView();
            UpdateTotalTemporary();

            // Reset input
            txtTimSP.Text = "";
            txtSLNhap.Text = "";
            txtDonGiaNhap.Text = "";
            txtThanhTien.Text = "";
        }

        // ===== BUTTON: XÓA DÒNG TRONG DATAGRIDVIEW =====
        private void btnXoa2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int rowIndex = dataGridView1.CurrentRow.Index;
            if (rowIndex < tblTamThoi.Rows.Count)
            {
                tblTamThoi.Rows[rowIndex].Delete();
                tblTamThoi.AcceptChanges();
                dataGridView1.DataSource = tblTamThoi.Copy();
                ConfigureDetailGridView();
                UpdateTotalTemporary();
            }
        }

        // ===== BUTTON: LÀM MỚI =====
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadReceiptGrid();
        }

        // ===== KEYPRESS VALIDATE =====
        private void txtSLNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                UpdateThanhTien();
        }

        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '.');
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.')
                UpdateThanhTien();
        }

        private void txtTimSP_TextChanged(object sender, EventArgs e)
        {
            // Tìm kiếm sản phẩm khi nhập
        }


    }
}