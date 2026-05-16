using QuanLyCuaHangMayTinh.BUS;
using QuanLyCuaHangMayTinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Form Quản lý đơn đặt hàng - khách gọi điện đặt hàng trước, NV bán hàng tạo đơn.
    /// Đề 1.3: Tạo đơn, chuyển trạng thái (Chờ xử lý → Đang giao → Đã giao → Hoàn thành/Hủy),
    /// chuyển sang đơn bán, hủy đơn, bỏ món khỏi đơn.
    /// </summary>
    public partial class frmDonHang : Form
    {
        private readonly DonDatHangBUS _bus = new DonDatHangBUS();
        private DataTable _dtAllDon;

        public frmDonHang()
        {
            InitializeComponent();
        }

        private void frmDonHang_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);

            // Gắn event handler
            btnThem.Click   += BtnThem_Click;
            btnSua.Click    += BtnSua_Click;
            btnXoa.Click    += BtnXoa_Click;
            btnLamMoi.Click += (s, ev) => { ResetFilter(); LoadData(); };
            btnXuatExcel.Click += BtnXuatExcel_Click;
            txtTimKiem.TextChanged += (s, ev) => ApplyFilter();
            cboTrangThai.SelectedIndexChanged += (s, ev) => ApplyFilter();
            dtpFrom.ValueChanged += (s, ev) => ApplyFilter();
            dtpTo.ValueChanged += (s, ev) => ApplyFilter();
            dgvDonHang.CellDoubleClick += DgvDonHang_CellDoubleClick;

            // Khởi tạo combo trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] {
                "(Tất cả)", "Chờ xử lý", "Đang giao", "Đã giao", "Hoàn thành", "Hủy"
            });
            cboTrangThai.SelectedIndex = 0;

            // Mặc định lọc 30 ngày gần nhất
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Function.Connect();
                // Lấy đơn đặt hàng + tên khách hàng
                _dtAllDon = Function.GetDataToTable(@"
                    SELECT d.MaDonDatHang, d.NgayDat, kh.TenKhachHang, kh.SoDienThoai,
                           d.TongTien, d.TrangThai, d.MaNhanVien
                    FROM   DonDatHang d
                    LEFT JOIN KhachHang kh ON d.MaKhachHang = kh.MaKhachHang
                    ORDER BY d.NgayDat DESC");

                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải đơn hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            if (_dtAllDon == null) return;
            try
            {
                string kw = txtTimKiem.Text?.Trim().ToLower() ?? "";
                string tt = cboTrangThai.SelectedItem?.ToString() ?? "(Tất cả)";
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                var filtered = _dtAllDon.AsEnumerable().Where(r =>
                {
                    DateTime ngay = Convert.ToDateTime(r["NgayDat"]);
                    if (ngay < from || ngay > to) return false;
                    if (tt != "(Tất cả)" && r["TrangThai"].ToString() != tt) return false;
                    if (!string.IsNullOrEmpty(kw))
                    {
                        string ma = r["MaDonDatHang"].ToString().ToLower();
                        string ten = r["TenKhachHang"]?.ToString().ToLower() ?? "";
                        string sdt = r["SoDienThoai"]?.ToString().ToLower() ?? "";
                        if (!ma.Contains(kw) && !ten.Contains(kw) && !sdt.Contains(kw)) return false;
                    }
                    return true;
                });

                DataTable result = filtered.Any() ? filtered.CopyToDataTable() : _dtAllDon.Clone();
                dgvDonHang.DataSource = result;

                if (dgvDonHang.Columns.Count > 0)
                {
                    dgvDonHang.Columns["MaDonDatHang"].HeaderText = "Mã đơn";
                    dgvDonHang.Columns["NgayDat"].HeaderText = "Ngày đặt";
                    dgvDonHang.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                    dgvDonHang.Columns["SoDienThoai"].HeaderText = "SĐT";
                    dgvDonHang.Columns["TongTien"].HeaderText = "Tổng tiền";
                    dgvDonHang.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    dgvDonHang.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvDonHang.Columns["MaNhanVien"].HeaderText = "NV phụ trách";
                    dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch { /* bỏ qua lỗi filter để không vỡ form */ }
        }

        private void ResetFilter()
        {
            txtTimKiem.Text = "";
            cboTrangThai.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            // Mở dialog tạo đơn mới
            using (var f = new frmDonHangMoiDialog(_bus))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần cập nhật.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maDon = dgvDonHang.CurrentRow.Cells["MaDonDatHang"].Value?.ToString();
            string tt = dgvDonHang.CurrentRow.Cells["TrangThai"].Value?.ToString();
            if (string.IsNullOrEmpty(maDon)) return;

            // Mở dialog cập nhật trạng thái + chuyển sang hóa đơn
            using (var f = new frmDonHangChiTietDialog(_bus, maDon, tt))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void DgvDonHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnSua_Click(sender, e);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần hủy.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maDon = dgvDonHang.CurrentRow.Cells["MaDonDatHang"].Value?.ToString();
            string tt = dgvDonHang.CurrentRow.Cells["TrangThai"].Value?.ToString();
            if (string.IsNullOrEmpty(maDon)) return;

            if (tt == "Hoàn thành" || tt == "Hủy")
            {
                MessageBox.Show("Đơn này đã ở trạng thái cuối, không thể hủy.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận HỦY đơn {maDon}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                bool ok = _bus.CapNhatTrangThai(maDon, "Hủy");
                if (ok)
                {
                    MessageBox.Show("Đã hủy đơn hàng.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Xuất CSV đơn giản (Excel mở được)
            using (var sfd = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = $"DonDatHang_{DateTime.Now:yyyyMMdd_HHmm}.csv"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    using (var sw = new System.IO.StreamWriter(sfd.FileName, false,
                        System.Text.Encoding.UTF8))
                    {
                        // Header
                        var headers = dgvDonHang.Columns.Cast<DataGridViewColumn>()
                            .Select(c => c.HeaderText);
                        sw.WriteLine(string.Join(",", headers));
                        // Rows
                        foreach (DataGridViewRow row in dgvDonHang.Rows)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>()
                                .Select(c => $"\"{c.Value?.ToString().Replace("\"", "\"\"")}\"");
                            sw.WriteLine(string.Join(",", cells));
                        }
                    }
                    MessageBox.Show("Đã xuất file: " + sfd.FileName, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    // ========================================================================
    // DIALOG 1: TẠO ĐƠN ĐẶT HÀNG MỚI
    // ========================================================================
    internal class frmDonHangMoiDialog : Form
    {
        private readonly DonDatHangBUS _bus;
        private ComboBox cboKhachHang, cboSanPham;
        private TextBox txtSoLuong;
        private DataGridView dgvChiTiet;
        private Label lblTongTien;
        private Button btnThemSP, btnXoaSP, btnLuu, btnHuy;
        private DataTable _dtSP;
        private List<ChiTietHoaDonDTO> _gio = new List<ChiTietHoaDonDTO>();

        public frmDonHangMoiDialog(DonDatHangBUS bus)
        {
            _bus = bus;
            BuildUI();
            this.Load += (s, e) => LoadCombo();
        }

        private void BuildUI()
        {
            Text = "Tạo đơn đặt hàng mới";
            Width = 720; Height = 580;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            BackColor = Color.White;

            Controls.Add(new Label { Text = "Khách hàng:", Location = new Point(20, 20), Width = 100 });
            cboKhachHang = new ComboBox { Location = new Point(130, 17), Width = 400, DropDownStyle = ComboBoxStyle.DropDownList };
            Controls.Add(cboKhachHang);

            Controls.Add(new Label { Text = "Sản phẩm:", Location = new Point(20, 60), Width = 100 });
            cboSanPham = new ComboBox { Location = new Point(130, 57), Width = 400, DropDownStyle = ComboBoxStyle.DropDownList };
            Controls.Add(cboSanPham);

            Controls.Add(new Label { Text = "Số lượng:", Location = new Point(20, 100), Width = 100 });
            txtSoLuong = new TextBox { Location = new Point(130, 97), Width = 80, Text = "1" };
            Controls.Add(txtSoLuong);

            btnThemSP = new Button { Text = "+ Thêm vào đơn", Location = new Point(220, 95), Width = 130, Height = 28, BackColor = Color.SeaGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnThemSP.Click += BtnThemSP_Click;
            Controls.Add(btnThemSP);

            btnXoaSP = new Button { Text = "- Bỏ SP đã chọn", Location = new Point(360, 95), Width = 130, Height = 28, BackColor = Color.IndianRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnXoaSP.Click += BtnXoaSP_Click;
            Controls.Add(btnXoaSP);

            dgvChiTiet = new DataGridView
            {
                Location = new Point(20, 140), Size = new Size(670, 280),
                ReadOnly = true, AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White, RowHeadersVisible = false
            };
            Controls.Add(dgvChiTiet);

            lblTongTien = new Label { Text = "Tổng tiền: 0 đ", Location = new Point(20, 435), Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = Color.DarkRed, AutoSize = true };
            Controls.Add(lblTongTien);

            btnLuu = new Button { Text = "Lưu đơn đặt hàng", Location = new Point(420, 480), Width = 150, Height = 38, BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            btnLuu.Click += BtnLuu_Click;
            Controls.Add(btnLuu);

            btnHuy = new Button { Text = "Hủy", Location = new Point(580, 480), Width = 100, Height = 38, BackColor = Color.Gray, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnHuy.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            Controls.Add(btnHuy);
        }

        private void LoadCombo()
        {
            try
            {
                var dtKH = Function.GetDataToTable(
                    "SELECT MaKhachHang, TenKhachHang + ' (' + SoDienThoai + ')' AS HienThi FROM KhachHang ORDER BY TenKhachHang");
                cboKhachHang.DataSource = dtKH;
                cboKhachHang.DisplayMember = "HienThi";
                cboKhachHang.ValueMember = "MaKhachHang";

                _dtSP = Function.GetDataToTable(
                    "SELECT MaSanPham, TenSanPham, GiaBan, SoLuongTon FROM SanPham WHERE SoLuongTon > 0 ORDER BY TenSanPham");
                var dtView = new DataTable();
                dtView.Columns.Add("MaSanPham", typeof(string));
                dtView.Columns.Add("HienThi", typeof(string));
                foreach (DataRow r in _dtSP.Rows)
                {
                    decimal gia = Convert.ToDecimal(r["GiaBan"]);
                    int ton = Convert.ToInt32(r["SoLuongTon"]);
                    dtView.Rows.Add(r["MaSanPham"], $"{r["TenSanPham"]} - {gia:N0}đ (Tồn: {ton})");
                }
                cboSanPham.DataSource = dtView;
                cboSanPham.DisplayMember = "HienThi";
                cboSanPham.ValueMember = "MaSanPham";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải combo: " + ex.Message);
            }
        }

        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null) return;
            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng phải > 0."); return;
            }
            string maSP = cboSanPham.SelectedValue.ToString();
            var spRow = _dtSP.AsEnumerable().FirstOrDefault(r => r["MaSanPham"].ToString() == maSP);
            if (spRow == null) return;

            int ton = Convert.ToInt32(spRow["SoLuongTon"]);
            var existing = _gio.Find(x => x.MaSanPham == maSP);
            int slCu = existing?.SoLuong ?? 0;
            if (slCu + sl > ton)
            {
                MessageBox.Show($"Vượt tồn kho (còn {ton})."); return;
            }
            decimal gia = Convert.ToDecimal(spRow["GiaBan"]);
            if (existing != null) existing.SoLuong += sl;
            else _gio.Add(new ChiTietHoaDonDTO { MaSanPham = maSP, SoLuong = sl, DonGia = gia });
            HienThiGio();
        }

        private void BtnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null) return;
            string ma = dgvChiTiet.CurrentRow.Cells["MaSanPham"]?.Value?.ToString();
            if (string.IsNullOrEmpty(ma)) return;
            _gio.RemoveAll(x => x.MaSanPham == ma);
            HienThiGio();
        }

        private void HienThiGio()
        {
            var dt = new DataTable();
            dt.Columns.Add("MaSanPham"); dt.Columns.Add("TenSanPham");
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("DonGia", typeof(decimal));
            dt.Columns.Add("ThanhTien", typeof(decimal));
            decimal total = 0;
            foreach (var ct in _gio)
            {
                var spRow = _dtSP.AsEnumerable().FirstOrDefault(r => r["MaSanPham"].ToString() == ct.MaSanPham);
                decimal tt = ct.SoLuong * ct.DonGia;
                total += tt;
                dt.Rows.Add(ct.MaSanPham, spRow?["TenSanPham"], ct.SoLuong, ct.DonGia, tt);
            }
            dgvChiTiet.DataSource = dt;
            if (dgvChiTiet.Columns.Count > 0)
            {
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
            lblTongTien.Text = $"Tổng tiền: {total:N0} đ";
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng."); return;
            }
            if (_gio.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất 1 sản phẩm."); return;
            }
            decimal total = _gio.Sum(x => x.SoLuong * x.DonGia);
            var don = new DonDatHangDTO
            {
                MaDonDatHang = _bus.GenerateMaDon(),
                NgayDat = DateTime.Now,
                MaKhachHang = cboKhachHang.SelectedValue.ToString(),
                MaNhanVien = StaticData.MaNV,
                TienGiam = 0,
                TongTien = total,
                TrangThai = "Chờ xử lý"
            };
            try
            {
                bool ok = _bus.TaoDon(don, _gio);
                if (ok)
                {
                    MessageBox.Show($"Đã tạo đơn {don.MaDonDatHang} thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else MessageBox.Show("Tạo đơn thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }

    // ========================================================================
    // DIALOG 2: CHI TIẾT ĐƠN HÀNG + CẬP NHẬT TRẠNG THÁI + CHUYỂN SANG HÓA ĐƠN
    // ========================================================================
    internal class frmDonHangChiTietDialog : Form
    {
        private readonly DonDatHangBUS _bus;
        private readonly string _maDon;
        private readonly string _trangThaiHienTai;
        private DataGridView dgvChiTiet;
        private ComboBox cboTrangThaiMoi;
        private Label lblInfo;
        private Button btnCapNhat, btnChuyenHoaDon, btnDong;

        public frmDonHangChiTietDialog(DonDatHangBUS bus, string maDon, string trangThai)
        {
            _bus = bus;
            _maDon = maDon;
            _trangThaiHienTai = trangThai;
            BuildUI();
            this.Load += (s, e) => LoadChiTiet();
        }

        private void BuildUI()
        {
            Text = $"Chi tiết đơn {_maDon}";
            Width = 720; Height = 520;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            BackColor = Color.White;

            lblInfo = new Label
            {
                Text = $"Đơn: {_maDon}     |     Trạng thái hiện tại: {_trangThaiHienTai}",
                Location = new Point(20, 15),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true
            };
            Controls.Add(lblInfo);

            dgvChiTiet = new DataGridView
            {
                Location = new Point(20, 50), Size = new Size(670, 280),
                ReadOnly = true, AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White, RowHeadersVisible = false
            };
            Controls.Add(dgvChiTiet);

            Controls.Add(new Label
            {
                Text = "Cập nhật trạng thái:",
                Location = new Point(20, 350), Width = 150,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            });

            cboTrangThaiMoi = new ComboBox
            {
                Location = new Point(180, 347),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboTrangThaiMoi.Items.AddRange(new object[] { "Chờ xử lý", "Đang giao", "Đã giao", "Hoàn thành", "Hủy" });
            cboTrangThaiMoi.SelectedItem = _trangThaiHienTai;
            Controls.Add(cboTrangThaiMoi);

            btnCapNhat = new Button
            {
                Text = "Cập nhật trạng thái",
                Location = new Point(400, 343), Width = 180, Height = 32,
                BackColor = Color.SteelBlue, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCapNhat.Click += BtnCapNhat_Click;
            Controls.Add(btnCapNhat);

            btnChuyenHoaDon = new Button
            {
                Text = "▶ Chuyển sang hóa đơn bán",
                Location = new Point(20, 410), Width = 280, Height = 40,
                BackColor = Color.DarkOrange, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnChuyenHoaDon.Click += BtnChuyenHoaDon_Click;
            Controls.Add(btnChuyenHoaDon);

            btnDong = new Button
            {
                Text = "Đóng",
                Location = new Point(580, 410), Width = 100, Height = 40,
                BackColor = Color.Gray, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDong.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            Controls.Add(btnDong);

            // Disable thao tác nếu đơn ở trạng thái cuối
            if (_trangThaiHienTai == "Hoàn thành" || _trangThaiHienTai == "Hủy")
            {
                btnCapNhat.Enabled = false;
                btnChuyenHoaDon.Enabled = false;
                cboTrangThaiMoi.Enabled = false;
            }
        }

        private void LoadChiTiet()
        {
            try
            {
                var dt = _bus.GetChiTiet(_maDon);
                dgvChiTiet.DataSource = dt;

                if (dgvChiTiet.Columns.Count > 0)
                {
                    if (dgvChiTiet.Columns.Contains("MaSanPham"))   dgvChiTiet.Columns["MaSanPham"].HeaderText = "Mã SP";
                    if (dgvChiTiet.Columns.Contains("TenSanPham"))  dgvChiTiet.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
                    if (dgvChiTiet.Columns.Contains("SoLuong"))     dgvChiTiet.Columns["SoLuong"].HeaderText = "SL";
                    if (dgvChiTiet.Columns.Contains("DonGia"))      { dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá"; dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0"; }
                    if (dgvChiTiet.Columns.Contains("ThanhTien"))   { dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền"; dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0"; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message);
            }
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            if (cboTrangThaiMoi.SelectedItem == null) return;
            string tt = cboTrangThaiMoi.SelectedItem.ToString();
            if (tt == _trangThaiHienTai)
            {
                MessageBox.Show("Trạng thái không thay đổi.", "Thông báo");
                return;
            }
            try
            {
                bool ok = _bus.CapNhatTrangThai(_maDon, tt);
                if (ok)
                {
                    MessageBox.Show("Đã cập nhật trạng thái.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else MessageBox.Show("Cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnChuyenHoaDon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Chuyển đơn {_maDon} sang hóa đơn bán?\n" +
                "(Đơn sẽ chuyển sang trạng thái Hoàn thành và tạo hóa đơn mới)",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                string maHD = SinhMaHoaDon();
                var (ok, msg) = _bus.ChuyenSangHoaDon(_maDon, maHD, StaticData.MaNV);
                MessageBox.Show(msg, ok ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (ok)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private string SinhMaHoaDon()
        {
            var dt = Function.GetDataToTable("SELECT TOP 1 MaHoaDonBan FROM HoaDonBan ORDER BY MaHoaDonBan DESC");
            if (dt == null || dt.Rows.Count == 0) return "HD001";
            string last = dt.Rows[0][0].ToString();
            if (last.Length > 2 && int.TryParse(last.Substring(2), out int n))
                return "HD" + (n + 1).ToString("D3");
            return "HD001";
        }
    }
}
