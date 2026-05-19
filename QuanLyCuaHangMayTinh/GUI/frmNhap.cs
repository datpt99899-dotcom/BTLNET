using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;
using QuanLyCuaHangMayTinh.DTO;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Form lập phiếu nhập kho — gọi NhapKhoBUS.TaoPhieuNhap (transaction).
    /// Trigger trg_NhapKho_TangTon sẽ tự cộng tồn kho và cập nhật giá nhập / giá bán.
    /// </summary>
    public partial class frmNhap : Form
    {
        private readonly NhapKhoBUS _bus = new NhapKhoBUS();
        private DataTable _dtChiTiet;

        // Mã phiếu nhập được mở để xem/sửa (null = tạo mới)
        private string _maPhieuNhapMo = null;
        // True = đang ở chế độ chỉ xem (readonly), False = đang sửa hoặc tạo mới
        private bool _readOnly = false;

        /// <summary>Constructor mặc định — tạo phiếu nhập mới.</summary>
        public frmNhap()
        {
            InitializeComponent();
            this.Load += FrmNhap_Load;
        }

        /// <summary>Constructor xem chi tiết phiếu nhập có sẵn (readonly).</summary>
        public frmNhap(string maPhieuNhap)
        {
            InitializeComponent();
            _maPhieuNhapMo = maPhieuNhap;
            _readOnly = true;
            this.Load += FrmNhap_Load;
        }

        private void FrmNhap_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);

            // Khởi tạo grid
            _dtChiTiet = new DataTable();
            _dtChiTiet.Columns.Add("MaSP", typeof(string));
            _dtChiTiet.Columns.Add("TenSP", typeof(string));
            _dtChiTiet.Columns.Add("SoLuong", typeof(int));
            _dtChiTiet.Columns.Add("DonGia", typeof(decimal));
            _dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));
            if (dgvPhieuNhap != null) dgvPhieuNhap.DataSource = _dtChiTiet;

            // Sinh mã phiếu nhập tự động
            if (txtMaPN != null) txtMaPN.Text = _bus.GenerateMaPhieuNhap();
            if (dtpNgayNhap != null) dtpNgayNhap.Value = DateTime.Now;
            if (txtTenNV != null) txtTenNV.Text = StaticData.HoTen;

            LoadComboNCC();
            LoadComboSP();
            LoadComboNV();

            if (btnThem != null) btnThem.Click += BtnThem_Click;
            if (btnLuu  != null) btnLuu.Click  += BtnLuu_Click;
            if (btnHuy  != null) btnHuy.Click  += BtnHuy_Click;
            if (btnDong != null) btnDong.Click += (s, ev) => this.Close();
            if (btnTimKiem != null) btnTimKiem.Click += BtnSua_Click;
            if (btnXuat    != null) btnXuat.Click    += BtnXuat_Click;
            if (cboMaSP  != null) cboMaSP.SelectedIndexChanged  += CboMaSP_SelectedIndexChanged;
            // Thêm vào sau dòng:
            // if (cboMaSP != null) cboMaSP.SelectedIndexChanged += CboMaSP_SelectedIndexChanged;

            if (txtSoLuong != null) txtSoLuong.TextChanged += TinhThanhTien;
            if (txtDonGia != null) txtDonGia.TextChanged += TinhThanhTien;
            if (txtGiamGia != null) txtGiamGia.TextChanged += TinhThanhTien;
            if (cboMaNCC != null) cboMaNCC.SelectedIndexChanged += CboMaNCC_SelectedIndexChanged;

            // Double-click vào dòng chi tiết để xóa khỏi danh sách (trước khi lưu)
            if (dgvPhieuNhap != null)
                dgvPhieuNhap.CellDoubleClick += DgvPhieuNhap_CellDoubleClick;

            // Nếu được mở để xem/sửa phiếu có sẵn → load và đặt readonly
            if (!string.IsNullOrEmpty(_maPhieuNhapMo))
            {
                LoadPhieuNhap(_maPhieuNhapMo);
                SetReadOnly(true);
            }
        }

        /// <summary>Load thông tin phiếu nhập từ DB lên form.</summary>
        private void LoadPhieuNhap(string maPhieuNhap)
        {
            try
            {
                var dtHeader = Function.GetDataToTable(@"
                    SELECT pn.MaPhieuNhap, pn.NgayNhap, pn.MaNCC, ncc.TenNCC,
                           pn.MaNhanVien, nv.HoTen AS TenNV, pn.TongTien
                    FROM   PhieuNhapKho pn
                    INNER JOIN NhaCungCap ncc ON pn.MaNCC = ncc.MaNCC
                    INNER JOIN NhanVien   nv  ON pn.MaNhanVien = nv.MaNhanVien
                    WHERE  pn.MaPhieuNhap = @ma",
                    new SqlParameter("@ma", maPhieuNhap));

                if (dtHeader.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập: " + maPhieuNhap);
                    return;
                }

                DataRow h = dtHeader.Rows[0];
                if (txtMaPN     != null) txtMaPN.Text     = h["MaPhieuNhap"].ToString();
                if (dtpNgayNhap != null) dtpNgayNhap.Value = Convert.ToDateTime(h["NgayNhap"]);
                if (cboMaNCC    != null) cboMaNCC.SelectedValue = h["MaNCC"].ToString();
                if (cboMaNV     != null) cboMaNV.SelectedValue  = h["MaNhanVien"].ToString();
                if (txtTenNV    != null) txtTenNV.Text   = h["TenNV"].ToString();
                if (txtTongTien != null) txtTongTien.Text = Convert.ToDecimal(h["TongTien"]).ToString("N0");

                // Load chi tiết
                var dtCT = Function.GetDataToTable(@"
                    SELECT ct.MaSanPham AS MaSP, sp.TenSanPham AS TenSP,
                           ct.SoLuong, ct.DonGiaNhap AS DonGia,
                           (ct.SoLuong * ct.DonGiaNhap) AS ThanhTien
                    FROM   ChiTietPhieuNhap ct
                    INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                    WHERE  ct.MaPhieuNhap = @ma",
                    new SqlParameter("@ma", maPhieuNhap));

                _dtChiTiet.Clear();
                foreach (DataRow r in dtCT.Rows)
                    _dtChiTiet.Rows.Add(r["MaSP"], r["TenSP"], r["SoLuong"], r["DonGia"], r["ThanhTien"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load phiếu: " + ex.Message);
            }
        }

        /// <summary>
        /// Bật/tắt chế độ chỉ xem (readonly).
        /// Khi readonly: tất cả input bị disable, chỉ nút "Sửa phiếu" và "Đóng" được enable.
        /// Khi rời readonly: cho phép sửa các trường.
        /// </summary>
        private void SetReadOnly(bool ro)
        {
            _readOnly = ro;

            // Các trường thông tin
            if (txtMaPN     != null) txtMaPN.ReadOnly       = ro;
            if (dtpNgayNhap != null) dtpNgayNhap.Enabled    = !ro;
            if (cboMaNCC    != null) cboMaNCC.Enabled       = !ro;
            if (cboMaNV     != null) cboMaNV.Enabled        = !ro;
            if (txtTenNCC   != null) txtTenNCC.ReadOnly     = ro;
            if (txtTenNV    != null) txtTenNV.ReadOnly      = ro;
            if (txtDiaChi   != null) txtDiaChi.ReadOnly     = ro;

            // Các trường nhập chi tiết
            if (cboMaSP    != null) cboMaSP.Enabled    = !ro;
            if (txtTenSP   != null) txtTenSP.ReadOnly  = ro;
            if (txtSoLuong != null) txtSoLuong.ReadOnly = ro;
            if (txtDonGia  != null) txtDonGia.ReadOnly  = ro;
            if (txtGiamGia != null) txtGiamGia.ReadOnly = ro;
            if (txtThanhTien != null) txtThanhTien.ReadOnly = ro;

            // Các nút chức năng
            if (btnThem != null) btnThem.Enabled = !ro;
            if (btnLuu  != null) btnLuu.Enabled  = !ro;
            if (btnHuy  != null) btnHuy.Enabled  = !ro;

            // Nút Sửa phiếu (btnTimKiem) đổi label theo trạng thái
            if (btnTimKiem != null)
            {
                btnTimKiem.Text = ro ? "Sửa phiếu" : "Khóa lại";
                btnTimKiem.Enabled = true;
            }

            // Cấm sửa cột SoLuong trong grid khi readonly
            if (dgvPhieuNhap != null)
            {
                dgvPhieuNhap.ReadOnly = ro;
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            // Toggle giữa chế độ readonly và edit
            if (_readOnly)
            {
                // Đang xem → chuyển sang sửa
                if (MessageBox.Show("Chuyển sang chế độ chỉnh sửa phiếu nhập này?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                SetReadOnly(false);
            }
            else
            {
                // Đang sửa → quay về readonly (cancel)
                SetReadOnly(true);
                // Reload lại để hủy thay đổi chưa lưu
                if (!string.IsNullOrEmpty(_maPhieuNhapMo))
                    LoadPhieuNhap(_maPhieuNhapMo);
            }
        }

        private void DgvPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _dtChiTiet == null) return;
            if (MessageBox.Show("Xóa sản phẩm này khỏi phiếu nhập?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            _dtChiTiet.Rows.RemoveAt(e.RowIndex);
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataRow r in _dtChiTiet.Rows)
                tong += Convert.ToDecimal(r["ThanhTien"]);
            if (txtTongTien != null) txtTongTien.Text = tong.ToString("N0");
        }

        private void BtnXuat_Click(object sender, EventArgs e)
        {
            if (_dtChiTiet == null || _dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có chi tiết để in.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // In phiếu nhập đơn giản: xuất ra file txt
            try
            {
                using (var sfd = new SaveFileDialog
                {
                    Filter = "Text file (*.txt)|*.txt",
                    FileName = $"PhieuNhap_{txtMaPN?.Text ?? "MoiTao"}_{DateTime.Now:yyyyMMdd_HHmm}.txt"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var sb = new System.Text.StringBuilder();
                    sb.AppendLine("=== PHIẾU NHẬP KHO ===");
                    sb.AppendLine($"Mã phiếu: {txtMaPN?.Text}");
                    sb.AppendLine($"Ngày nhập: {DateTime.Now:dd/MM/yyyy HH:mm}");
                    sb.AppendLine($"Nhà cung cấp: {cboMaNCC?.Text}");
                    sb.AppendLine($"Nhân viên: {cboMaNV?.Text ?? StaticData.HoTen}");
                    sb.AppendLine("---------------------------------------------------------");
                    sb.AppendLine($"{"Mã SP",-10} {"Tên SP",-30} {"SL",-5} {"Giá nhập",-15} Thành tiền");
                    sb.AppendLine("---------------------------------------------------------");
                    foreach (System.Data.DataRow r in _dtChiTiet.Rows)
                    {
                        decimal tt = Convert.ToDecimal(r["SoLuong"]) * Convert.ToDecimal(r["DonGiaNhap"]);
                        sb.AppendLine($"{r["MaSanPham"],-10} {r["TenSanPham"],-30} {r["SoLuong"],-5} {r["DonGiaNhap"]:N0,-15} {tt:N0}");
                    }
                    sb.AppendLine("---------------------------------------------------------");
                    sb.AppendLine($"TỔNG TIỀN: {txtTongTien?.Text}");
                    sb.AppendLine($"Bằng chữ: {lblBangChu?.Text}");

                    System.IO.File.WriteAllText(sfd.FileName, sb.ToString(),
                        System.Text.Encoding.UTF8);
                    MessageBox.Show("Đã in phiếu nhập ra file:\n" + sfd.FileName,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in phiếu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboNCC()
        {
            if (cboMaNCC == null) return;
            var dt = Function.GetDataToTable("SELECT MaNCC, TenNCC FROM NhaCungCap ORDER BY TenNCC");
            cboMaNCC.DataSource = dt;
            cboMaNCC.ValueMember = "MaNCC";
            cboMaNCC.DisplayMember = "MaNCC";
        }

        private void LoadComboSP()
        {
            if (cboMaSP == null) return;
            var dt = Function.GetDataToTable("SELECT MaSanPham, TenSanPham, GiaNhap FROM SanPham ORDER BY TenSanPham");
            cboMaSP.DataSource = dt;
            cboMaSP.ValueMember = "MaSanPham";
            cboMaSP.DisplayMember = "MaSanPham";
        }

        private void LoadComboNV()
        {
            if (cboMaNV == null) return;
            var dt = Function.GetDataToTable("SELECT MaNhanVien, HoTen FROM NhanVien WHERE TrangThai = 1");
            cboMaNV.DataSource = dt;
            cboMaNV.ValueMember = "MaNhanVien";
            cboMaNV.DisplayMember = "MaNhanVien";
            // Mặc định chọn người đang đăng nhập
            if (!string.IsNullOrEmpty(StaticData.MaNV))
                cboMaNV.SelectedValue = StaticData.MaNV;
        }

        private void CboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNCC?.SelectedValue == null) return;
            var dt = Function.GetDataToTable(
                "SELECT TenNCC, DiaChi, SoDienThoai FROM NhaCungCap WHERE MaNCC=@id",
                new SqlParameter("@id", cboMaNCC.SelectedValue.ToString()));
            if (dt.Rows.Count > 0)
            {
                if (txtTenNCC != null) txtTenNCC.Text = dt.Rows[0]["TenNCC"].ToString();
                if (txtDiaChi != null) txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                if (mskSDT    != null) mskSDT.Text    = dt.Rows[0]["SoDienThoai"].ToString();
            }
        }

        private void CboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSP?.SelectedValue == null) return;
            var dt = Function.GetDataToTable(
                "SELECT TenSanPham, GiaNhap FROM SanPham WHERE MaSanPham=@id",
                new SqlParameter("@id", cboMaSP.SelectedValue.ToString()));
            if (dt.Rows.Count > 0)
            {
                if (txtTenSP  != null) txtTenSP.Text  = dt.Rows[0]["TenSanPham"].ToString();
                if (txtDonGia != null) txtDonGia.Text = Convert.ToDecimal(dt.Rows[0]["GiaNhap"]).ToString("N0");
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMaSP?.SelectedValue == null) { MessageBox.Show("Chọn sản phẩm"); return; }
                int soLuong = int.Parse(txtSoLuong.Text);
                decimal donGia = decimal.Parse(txtDonGia.Text.Replace(",", "").Replace(".", ""));
                if (soLuong <= 0) { MessageBox.Show("Số lượng phải > 0"); return; }
                if (donGia  <= 0) { MessageBox.Show("Đơn giá phải > 0"); return; }

                decimal giamGia = 0;
                decimal.TryParse(
                    txtGiamGia?.Text?.Replace("%", "").Trim(),
                    out giamGia);

                decimal thanhTien = soLuong * donGia;
                if (giamGia > 0)
                    thanhTien = thanhTien - (thanhTien * giamGia / 100);

                _dtChiTiet.Rows.Add(cboMaSP.SelectedValue.ToString(), txtTenSP.Text, soLuong, donGia, thanhTien);
                UpdateTongTien();
                txtSoLuong.Text = ""; txtDonGia.Text = "";
                if (txtGiamGia != null) txtGiamGia.Text = "";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void UpdateTongTien()
        {
            decimal tong = 0;
            foreach (DataRow r in _dtChiTiet.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);
            if (txtTongTien != null) txtTongTien.Text = tong.ToString("N0");
            if (lblBangChu  != null) lblBangChu.Text  = Function.ChuyenSoSangChu(tong.ToString("F0"));
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (_dtChiTiet.Rows.Count == 0) { MessageBox.Show("Chưa có sản phẩm"); return; }
            if (cboMaNCC?.SelectedValue == null) { MessageBox.Show("Chọn nhà cung cấp"); return; }

            decimal tongTien = 0;
            var chiTiet = new List<(string, int, decimal)>();
            foreach (DataRow r in _dtChiTiet.Rows)
            {
                chiTiet.Add((r["MaSP"].ToString(), Convert.ToInt32(r["SoLuong"]), Convert.ToDecimal(r["DonGia"])));
                tongTien += Convert.ToDecimal(r["ThanhTien"]);
            }

            var phieu = new PhieuNhapKhoDTO
            {
                MaPhieuNhap = txtMaPN?.Text,
                NgayNhap    = dtpNgayNhap?.Value ?? DateTime.Now,
                MaNCC       = cboMaNCC.SelectedValue.ToString(),
                MaNhanVien  = cboMaNV?.SelectedValue?.ToString() ?? StaticData.MaNV,
                TongTien    = tongTien
            };

            var result = _bus.TaoPhieuNhap(phieu, chiTiet);
            MessageBox.Show(result.msg, result.ok ? "Thành công" : "Lỗi",
                MessageBoxButtons.OK, result.ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (result.ok) BtnHuy_Click(sender, e);
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            _dtChiTiet.Clear();
            if (txtTongTien != null) txtTongTien.Text = "0";
            if (lblBangChu  != null) lblBangChu.Text  = "";
            if (txtMaPN != null) txtMaPN.Text = _bus.GenerateMaPhieuNhap();
        }
        private void TinhThanhTien(object sender, EventArgs e)
        {
            try
            {
                decimal soLuong = 0, donGia = 0, giamGia = 0;

                decimal.TryParse(txtSoLuong?.Text?.Trim(), out soLuong);
                decimal.TryParse(
                    txtDonGia?.Text?.Replace(",", "").Replace(".", "").Trim(),
                    out donGia);
                decimal.TryParse(
                    txtGiamGia?.Text?.Replace("%", "").Trim(),
                    out giamGia);

                decimal thanhTien = soLuong * donGia;
                if (giamGia > 0)
                    thanhTien = thanhTien - (thanhTien * giamGia / 100);

                if (txtThanhTien != null)
                    txtThanhTien.Text = thanhTien > 0 ? thanhTien.ToString("N0") : "";
            }
            catch { }
        }
    }

}
