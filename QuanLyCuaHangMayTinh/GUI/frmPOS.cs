using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;
using QuanLyCuaHangMayTinh.DAL;
using QuanLyCuaHangMayTinh.DTO;
using QuanLyCuaHangMayTinh.GUI;

namespace QuanLyCuaHangMayTinh
{
    /// <summary>
    /// Form bán hàng tại quầy (POS).
    /// Đồng bộ với Designer: dùng đầy đủ control sẵn có.
    /// Cách dùng:
    ///   1. Chọn Loại SP / Thương hiệu / nhập từ khóa để lọc danh sách bên trái
    ///   2. Chọn 1 dòng SP, nhập SỐ LƯỢNG vào numSoLuong
    ///   3. Double-click vào dòng → thêm vào giỏ với đúng số lượng đã nhập
    ///   4. Trong giỏ: có thể sửa cột "Số lượng" trực tiếp, click X để xóa
    ///   5. Nhập SĐT + Tên → Thêm khách hàng (lưu KH mới hoặc tra cứu KH cũ)
    ///   6. Nhập Chiết khấu (%) → tổng tiền tự cập nhật
    ///   7. Bấm Thanh toán → tạo hóa đơn + trừ kho (Transaction)
    /// </summary>
    public partial class frmPOS : Form
    {
        private readonly HoaDonBUS _hoaDonBus = new HoaDonBUS();
        private readonly DataTable cartTable = new DataTable();
        private string maKhachHang = null;   // null = khách vãng lai

        public frmPOS()
        {
            InitializeComponent();
            this.Load += frmPOS_Load;
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            InitCart();
            LoadComboLoaiSP();
            LoadComboThuongHieu();
            LoadSanPham();

            // dgvSanPham: read-only, full row select
            if (dgvSanPham != null)
            {
                dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSanPham.ReadOnly = true;
                dgvSanPham.AllowUserToAddRows = false;
                dgvSanPham.CellDoubleClick += dgvSanPham_CellDoubleClick;
            }

            // dgvCart: cho sửa SoLuong trực tiếp, click X để xóa
            if (dgvCart != null)
            {
                dgvCart.AllowUserToAddRows = false;
                dgvCart.AutoGenerateColumns = false;
                dgvCart.CellClick += dgvCart_CellClick;
                dgvCart.CellValueChanged += dgvCart_CellValueChanged;
                dgvCart.DataSource = cartTable;
            }

            // Wire toàn bộ event
            if (btnHuyDon    != null) btnHuyDon.Click    += btnHuyDon_Click;
            if (btnThanhVien != null) btnThanhVien.Click += btnThanhVien_Click;
            if (btnThanhToan != null) btnThanhToan.Click += btnThanhToan_Click;
            if (btnLamMoi    != null) btnLamMoi.Click    += btnLamMoi_Click;

            if (txtSearch  != null) txtSearch.TextChanged  += (s, ev) => LoadSanPham();
            if (txtGiamGia != null) txtGiamGia.TextChanged += (s, ev) => TinhTong();
            if (comboBox1 != null) comboBox1.SelectedIndexChanged += (s, ev) =>
            {
                string maLoai = comboBox1.SelectedValue?.ToString() ?? "";
                LoadComboThuongHieu(maLoai);   // lọc thương hiệu theo loại
                LoadSanPham();                  // lọc sản phẩm
            };
            if (cboThuongHieu != null) cboThuongHieu.SelectedIndexChanged += (s, ev) => LoadSanPham();
        }

        // ════════ INIT ════════

        private void InitCart()
        {
            if (cartTable.Columns.Count == 0)
            {
                cartTable.Columns.Add("MaSanPham", typeof(string));
                cartTable.Columns.Add("TenSanPham", typeof(string));
                cartTable.Columns.Add("GiaBan", typeof(decimal));
                cartTable.Columns.Add("SoLuong", typeof(int));
                cartTable.Columns.Add("ThanhTien", typeof(decimal), "GiaBan * SoLuong");
            }
        }

        private void LoadComboLoaiSP()
        {
            if (comboBox1 == null) return;
            try
            {
                var dt = Function.GetDataToTable("SELECT MaLoai, TenLoai FROM LoaiSanPham ORDER BY TenLoai");
                var rowAll = dt.NewRow();
                rowAll["MaLoai"] = ""; rowAll["TenLoai"] = "-- Tất cả --";
                dt.Rows.InsertAt(rowAll, 0);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "TenLoai";
                comboBox1.ValueMember = "MaLoai";
            }
            catch { }
        }

        private void LoadComboThuongHieu(string maLoai = "")
        {
            if (cboThuongHieu == null) return;
            try
            {
                DataTable dt;
                if (string.IsNullOrEmpty(maLoai))
                {
                    // Chưa chọn loại → hiện tất cả thương hiệu
                    dt = Function.GetDataToTable(
                        "SELECT MaThuongHieu, TenThuongHieu FROM ThuongHieu ORDER BY TenThuongHieu");
                }
                else
                {
                    // Đã chọn loại → chỉ hiện thương hiệu có SP thuộc loại đó
                    dt = Function.GetDataToTable(
                        @"SELECT DISTINCT th.MaThuongHieu, th.TenThuongHieu
                  FROM ThuongHieu th
                  INNER JOIN SanPham sp ON sp.MaThuongHieu = th.MaThuongHieu
                  WHERE sp.MaLoai = @maLoai
                  ORDER BY th.TenThuongHieu",
                        new SqlParameter("@maLoai", maLoai));
                }

                var rowAll = dt.NewRow();
                rowAll["MaThuongHieu"] = ""; rowAll["TenThuongHieu"] = "-- Tất cả --";
                dt.Rows.InsertAt(rowAll, 0);

                cboThuongHieu.DataSource = dt;
                cboThuongHieu.DisplayMember = "TenThuongHieu";
                cboThuongHieu.ValueMember = "MaThuongHieu";
            }
            catch { }
        }

        private void LoadSanPham()
        {
            if (dgvSanPham == null) return;
            try
            {
                string kw = txtSearch?.Text?.Trim() ?? "";
                string maLoai = comboBox1?.SelectedValue?.ToString() ?? "";
                string maTH = cboThuongHieu?.SelectedValue?.ToString() ?? "";

                string sql = @"
                    SELECT MaSanPham, TenSanPham, GiaBan, SoLuongTon
                    FROM   SanPham
                    WHERE  (TenSanPham LIKE @kw OR MaSanPham LIKE @kw)
                      AND  (@maLoai = '' OR MaLoai = @maLoai)
                      AND  (@maTH = ''   OR MaThuongHieu = @maTH)
                      AND  SoLuongTon > 0
                    ORDER  BY TenSanPham";

                var dt = Function.GetDataToTable(sql,
                    new SqlParameter("@kw", "%" + kw + "%"),
                    new SqlParameter("@maLoai", maLoai),
                    new SqlParameter("@maTH", maTH));

                dgvSanPham.DataSource = dt;

                // Format cột GiaBan có dấu phẩy
                if (dgvSanPham.Columns.Contains("GiaBan"))
                    dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message); }
        }

        // ════════ THÊM VÀO GIỎ ════════

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                string ma  = dgvSanPham.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString();
                string ten = dgvSanPham.Rows[e.RowIndex].Cells["TenSanPham"].Value.ToString();
                decimal gia = Convert.ToDecimal(dgvSanPham.Rows[e.RowIndex].Cells["GiaBan"].Value);
                int ton = Convert.ToInt32(dgvSanPham.Rows[e.RowIndex].Cells["SoLuongTon"].Value);

                // Lấy số lượng từ NumericUpDown (mặc định 1)
                int slNhap = numSoLuong != null ? (int)numSoLuong.Value : 1;
                if (slNhap < 1) slNhap = 1;

                DataRow found = cartTable.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaSanPham") == ma);
                if (found == null)
                {
                    if (slNhap <= ton) cartTable.Rows.Add(ma, ten, gia, slNhap);
                    else MessageBox.Show($"Không đủ hàng. Tồn kho hiện tại: {ton}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int slMoi = found.Field<int>("SoLuong") + slNhap;
                    if (slMoi <= ton) found["SoLuong"] = slMoi;
                    else MessageBox.Show($"Không đủ hàng (tồn: {ton}, giỏ hiện có: {found.Field<int>("SoLuong")})",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Reset NumericUpDown về 1 sau khi thêm
                if (numSoLuong != null) numSoLuong.Value = 1;
                TinhTong();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            // Click cột X → xóa dòng
            if (dgvCart.Columns[e.ColumnIndex].Name == "colDelete")
            {
                if (e.RowIndex < cartTable.Rows.Count)
                {
                    cartTable.Rows.RemoveAt(e.RowIndex);
                    TinhTong();
                }
            }
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Khi sửa cột SoLuong → cập nhật tổng + check tồn
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvCart.Columns[e.ColumnIndex].Name != "SoLuong") return;

            try
            {
                if (e.RowIndex >= cartTable.Rows.Count) return;
                var row = cartTable.Rows[e.RowIndex];
                int sl = Convert.ToInt32(row["SoLuong"]);
                if (sl < 1) { row["SoLuong"] = 1; sl = 1; }

                // Check tồn
                string maSP = row["MaSanPham"].ToString();
                var dt = Function.GetDataToTable(
                    "SELECT SoLuongTon FROM SanPham WHERE MaSanPham=@ma",
                    new SqlParameter("@ma", maSP));
                if (dt.Rows.Count > 0)
                {
                    int ton = Convert.ToInt32(dt.Rows[0][0]);
                    if (sl > ton)
                    {
                        MessageBox.Show($"Tồn kho chỉ còn {ton}", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row["SoLuong"] = ton;
                    }
                }
                TinhTong();
            }
            catch { }
        }

        // ════════ TÍNH TỔNG ════════

        private void TinhTong()
        {
            decimal tong = 0;
            if (cartTable.Rows.Count > 0)
                tong = cartTable.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));

            decimal giam = 0;
            decimal.TryParse((txtGiamGia?.Text ?? "0").Replace("%", "").Trim(), out giam);
            decimal thanhToan = tong - (tong * giam / 100);
            if (lblTongTien != null) lblTongTien.Text = thanhToan.ToString("N0") + " Vnd";
        }

        // ════════ THANH TOÁN ════════

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal tongHang = cartTable.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));
                decimal phanTramGiam = 0;
                decimal.TryParse((txtGiamGia?.Text ?? "0").Replace("%", "").Trim(), out phanTramGiam);
                decimal tienGiam = tongHang * phanTramGiam / 100;
                decimal tongThanhToan = tongHang - tienGiam;

                string maNV = string.IsNullOrEmpty(StaticData.MaNV) ? "NV003" : StaticData.MaNV;
                string maHD = _hoaDonBus.GenerateMaHoaDon();

                // Tra cứu khách hàng theo SĐT (nếu có)
                TraCuuKhachHangTheoSDT();

                var hd = new HoaDonBanDTO
                {
                    MaHoaDonBan = maHD,
                    NgayBan = DateTime.Now,
                    MaKhachHang = maKhachHang,
                    MaNhanVien = maNV,
                    TienGiam = tienGiam,
                    TongTien = tongThanhToan,
                    HinhThucThanhToan = "Tiền mặt",
                    TrangThai = "Hoàn thành"
                };

                var ct = cartTable.AsEnumerable().Select(r => new ChiTietHoaDonDTO
                {
                    MaHoaDonBan = maHD,
                    MaSanPham   = r.Field<string>("MaSanPham"),
                    SoLuong     = r.Field<int>("SoLuong"),
                    DonGia      = r.Field<decimal>("GiaBan")
                }).ToList();

                var result = _hoaDonBus.TaoHoaDon(hd, ct);
                if (result.ok)
                {
                    MessageBox.Show($"Thanh toán thành công!\nMã hóa đơn: {maHD}\nTổng tiền: {tongThanhToan:N0} VNĐ",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + result.msg, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void TraCuuKhachHangTheoSDT()
        {
            string sdt = txtSDT?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(sdt))
            {
                maKhachHang = null;
                return;
            }
            try
            {
                var dt = Function.GetDataToTable(
                    "SELECT MaKhachHang FROM KhachHang WHERE SoDienThoai = @sdt",
                    new SqlParameter("@sdt", sdt));
                if (dt.Rows.Count > 0)
                    maKhachHang = dt.Rows[0]["MaKhachHang"].ToString();
                else
                    maKhachHang = null;
            }
            catch { maKhachHang = null; }
        }

        // ════════ NÚT KHÁC ════════

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cartTable.Clear();
            if (txtSearch  != null) txtSearch.Clear();
            if (txtGiamGia != null) txtGiamGia.Text = "0";
            if (txtSDT != null) txtSDT.Clear();
            if (txtTenKH != null) txtTenKH.Clear();
            if (numSoLuong != null) numSoLuong.Value = 1;
            if (comboBox1 != null && comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            if (cboThuongHieu != null && cboThuongHieu.Items.Count > 0) cboThuongHieu.SelectedIndex = 0;
            maKhachHang = null;
            TinhTong();
            LoadSanPham();
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var result = MessageBox.Show("Bạn có chắc muốn hủy đơn hàng hiện tại?",
                "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cartTable.Clear();
                if (txtGiamGia != null) txtGiamGia.Text = "0";
                if (txtSDT != null) txtSDT.Clear();
                if (txtTenKH != null) txtTenKH.Clear();
                maKhachHang = null;
                TinhTong();
            }
        }

        private void btnThanhVien_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại để tra cứu hoặc thêm khách hàng.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dt = Function.GetDataToTable(
                    "SELECT MaKhachHang, TenKhachHang FROM KhachHang WHERE SoDienThoai = @sdt",
                    new SqlParameter("@sdt", sdt));
                if (dt.Rows.Count > 0)
                {
                    maKhachHang = dt.Rows[0]["MaKhachHang"].ToString();
                    if (txtTenKH != null) txtTenKH.Text = dt.Rows[0]["TenKhachHang"].ToString();
                    MessageBox.Show("Đã tra cứu thành viên: " + maKhachHang, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string tenKH = txtTenKH?.Text?.Trim() ?? "";
                    if (string.IsNullOrWhiteSpace(tenKH))
                    {
                        MessageBox.Show("Chưa có thành viên này. Vui lòng nhập tên khách hàng để thêm mới.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string maKH = "KH" + DateTime.Now.ToString("HHmmss");
                    Function.RunSql(
                        "INSERT INTO KhachHang(MaKhachHang, TenKhachHang, SoDienThoai, DiemTichLuy) " +
                        "VALUES (@ma, @ten, @sdt, 0)",
                        new SqlParameter("@ma", maKH),
                        new SqlParameter("@ten", tenKH),
                        new SqlParameter("@sdt", sdt));
                    maKhachHang = maKH;
                    MessageBox.Show("Đã thêm khách hàng mới: " + maKH, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
