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

        public frmNhap()
        {
            InitializeComponent();
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
            if (btnTimKiem != null) btnTimKiem.Click += BtnTimKiem_Click;
            if (btnXuat    != null) btnXuat.Click    += BtnXuat_Click;
            if (cboMaSP  != null) cboMaSP.SelectedIndexChanged  += CboMaSP_SelectedIndexChanged;
            if (cboMaNCC != null) cboMaNCC.SelectedIndexChanged += CboMaNCC_SelectedIndexChanged;

            // Double-click vào dòng chi tiết để xóa khỏi danh sách (trước khi lưu)
            if (dgvPhieuNhap != null)
                dgvPhieuNhap.CellDoubleClick += DgvPhieuNhap_CellDoubleClick;
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

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            // Mở form Tìm kiếm phiếu nhập (đã có sẵn trong project)
            using (var f = new frmTimKiemPhieuNhap())
            {
                f.ShowDialog(this);
            }
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

                decimal thanhTien = soLuong * donGia;
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
    }
}
