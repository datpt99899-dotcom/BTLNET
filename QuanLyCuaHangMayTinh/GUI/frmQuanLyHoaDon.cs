using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Form Quản lý hóa đơn — danh sách HD đã bán, có thể xem chi tiết, hủy, xuất Excel.
    /// Phân quyền: Admin và NV Bán hàng có thể hủy, Kế toán chỉ xem (read-only).
    /// </summary>
    public partial class frmQuanLyHoaDon : Form
    {
        private DataTable _dtAllHD;
        private readonly bool _canModify;

        public frmQuanLyHoaDon()
        {
            InitializeComponent();
            // Admin + NV Bán hàng được hủy HĐ; Kế toán read-only
            _canModify = StaticData.MaVaiTro == "VT01" || StaticData.MaVaiTro == "VT03";
        }

        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            // KHÔNG gọi ThemeManager.Apply() — gây lỗi chữ trắng trên nền trắng

            // Gắn event
            btnLamMoi.Click += (s, ev) => { ResetFilter(); LoadData(); };
            btnXemChiTiet.Click += BtnXemChiTiet_Click;
            btnHuyHoaDon.Click += BtnHuyHoaDon_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            btnDong.Click += (s, ev) => this.Hide();
            dgvHoaDon.CellClick += DgvHoaDon_CellClick;
            dgvHoaDon.CellDoubleClick += (s, ev) => BtnXemChiTiet_Click(s, ev);
            txtTimKiem.TextChanged += (s, ev) => ApplyFilter();
            cboTrangThai.SelectedIndexChanged += (s, ev) => ApplyFilter();
            dtpFrom.ValueChanged += (s, ev) => ApplyFilter();
            dtpTo.ValueChanged += (s, ev) => ApplyFilter();

            // Nút Tìm kiếm: chủ động filter (ngoài auto-filter)
            if (btnTimKiem != null) btnTimKiem.Click += (s, ev) => ApplyFilter();
            // Nút Bỏ lọc: xóa filter và hiển thị tất cả
            if (btnBoLoc != null) btnBoLoc.Click += (s, ev) => { ResetFilter(); ApplyFilter(); };

            // Combo trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "(Tất cả)", "Hoàn thành", "Đã trả hàng", "Hủy" });
            cboTrangThai.SelectedIndex = 0;

            // Mặc định lọc rộng (5 năm) để cover dữ liệu demo
            dtpFrom.Value = DateTime.Now.AddYears(-5);
            dtpTo.Value = DateTime.Now.AddDays(1);

            // Disable nút Hủy nếu không có quyền
            btnHuyHoaDon.Enabled = _canModify;
            if (!_canModify)
            {
                lblHint.Text = "[CHỈ XEM] Vai trò Kế toán không thể hủy hóa đơn.";
                lblHint.ForeColor = Color.DarkRed;
            }

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _dtAllHD = Function.GetDataToTable(@"
                    SELECT hd.MaHoaDonBan, hd.NgayBan,
                           ISNULL(kh.TenKhachHang, N'Khách lẻ') AS TenKhachHang,
                           ISNULL(kh.SoDienThoai, '') AS SoDienThoai,
                           nv.HoTen AS TenNhanVien,
                           hd.TongTien, hd.HinhThucThanhToan, hd.TrangThai,
                          ISNULL(hd.MaDonDatHang, '') AS MaDonDatHang
                    FROM HoaDonBan hd
                    LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                    LEFT JOIN NhanVien  nv ON hd.MaNhanVien = nv.MaNhanVien
                    ORDER BY hd.NgayBan DESC");
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            if (_dtAllHD == null) return;
            try
            {
                string kw = txtTimKiem.Text?.Trim().ToLower() ?? "";
                string tt = cboTrangThai.SelectedItem?.ToString() ?? "(Tất cả)";
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                var filtered = _dtAllHD.AsEnumerable().Where(r =>
                {
                    if (r["NgayBan"] == DBNull.Value) return false;
                    DateTime ngay = Convert.ToDateTime(r["NgayBan"]);
                    if (ngay < from || ngay > to) return false;
                    if (tt != "(Tất cả)" && r["TrangThai"]?.ToString() != tt) return false;
                    if (!string.IsNullOrEmpty(kw))
                    {
                        // Tìm kiếm trên TẤT CẢ cột text (mã HĐ, tên KH, SĐT, tên NV, mã đơn đặt)
                        string ma   = r["MaHoaDonBan"]?.ToString()?.ToLower() ?? "";
                        string ten  = r["TenKhachHang"]?.ToString()?.ToLower() ?? "";
                        string sdt  = r["SoDienThoai"]?.ToString()?.ToLower() ?? "";
                        string nv   = r["TenNhanVien"]?.ToString()?.ToLower() ?? "";
                        string mdd  = "";
                        if (_dtAllHD.Columns.Contains("MaDonDatHang"))
                            mdd = r["MaDonDatHang"]?.ToString()?.ToLower() ?? "";
                        if (!ma.Contains(kw) && !ten.Contains(kw) && !sdt.Contains(kw)
                            && !nv.Contains(kw) && !mdd.Contains(kw)) return false;
                    }
                    return true;
                });

                DataTable result = filtered.Any() ? filtered.CopyToDataTable() : _dtAllHD.Clone();
                dgvHoaDon.DataSource = result;

                if (dgvHoaDon.Columns.Count > 0)
                {
                    if (dgvHoaDon.Columns.Contains("MaHoaDonBan"))
                        dgvHoaDon.Columns["MaHoaDonBan"].HeaderText = "Mã HĐ";
                    if (dgvHoaDon.Columns.Contains("NgayBan"))
                        dgvHoaDon.Columns["NgayBan"].HeaderText = "Ngày bán";
                    if (dgvHoaDon.Columns.Contains("TenKhachHang"))
                        dgvHoaDon.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                    if (dgvHoaDon.Columns.Contains("SoDienThoai"))
                        dgvHoaDon.Columns["SoDienThoai"].HeaderText = "SĐT";
                    if (dgvHoaDon.Columns.Contains("TenNhanVien"))
                        dgvHoaDon.Columns["TenNhanVien"].HeaderText = "Nhân viên";
                    if (dgvHoaDon.Columns.Contains("TongTien"))
                    {
                        dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                        dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    }
                    if (dgvHoaDon.Columns.Contains("HinhThucThanhToan"))
                        dgvHoaDon.Columns["HinhThucThanhToan"].HeaderText = "Thanh toán";
                    if (dgvHoaDon.Columns.Contains("TrangThai"))
                        dgvHoaDon.Columns["TrangThai"].HeaderText = "Trạng thái";
                    if (dgvHoaDon.Columns.Contains("MaDonDatHang"))
                        dgvHoaDon.Columns["MaDonDatHang"].HeaderText = "Mã đơn đặt";
                    dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                lblTongHD.Text = $"Tổng: {result.Rows.Count} hóa đơn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilter()
        {
            txtTimKiem.Text = "";
            cboTrangThai.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Now.AddYears(-5);
            dtpTo.Value = DateTime.Now.AddDays(1);
        }

        private void DgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvHoaDon.CurrentRow == null) return;
            // Hiển thị tổng tiền dòng được chọn
            try
            {
                decimal tong = Convert.ToDecimal(dgvHoaDon.CurrentRow.Cells["TongTien"].Value);
                lblTongTien.Text = "Đã chọn: " + tong.ToString("N0") + " đ";
            }
            catch { }
        }

        private void BtnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string maHD = dgvHoaDon.CurrentRow.Cells["MaHoaDonBan"].Value?.ToString();
            if (string.IsNullOrEmpty(maHD)) return;

            try
            {
                var dtCT = Function.GetDataToTable(@"
                    SELECT sp.MaSanPham, sp.TenSanPham, ct.SoLuong, ct.DonGia,
                           (ct.SoLuong * ct.DonGia) AS ThanhTien
                    FROM ChiTietHoaDonBan ct
                    INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                    WHERE ct.MaHoaDonBan = @ma",
                    new SqlParameter("@ma", maHD));

                // Show dialog xem chi tiết
                using (var f = new Form
                {
                    Text = "Chi tiết hóa đơn " + maHD,
                    Size = new Size(700, 500),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    BackColor = Color.White
                })
                {
                    var lbl = new Label
                    {
                        Text = $"Mã hóa đơn: {maHD}",
                        Location = new Point(20, 15),
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        ForeColor = Color.DarkBlue,
                        AutoSize = true
                    };
                    f.Controls.Add(lbl);

                    var dgv = new DataGridView
                    {
                        Location = new Point(20, 50),
                        Size = new Size(640, 350),
                        DataSource = dtCT,
                        ReadOnly = true,
                        AllowUserToAddRows = false,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                        BackgroundColor = Color.White,
                        RowHeadersVisible = false
                    };
                    f.Controls.Add(dgv);

                    if (dgv.Columns.Count > 0)
                    {
                        dgv.Columns["MaSanPham"].HeaderText = "Mã SP";
                        dgv.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
                        dgv.Columns["SoLuong"].HeaderText = "SL";
                        dgv.Columns["DonGia"].HeaderText = "Đơn giá";
                        dgv.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                        dgv.Columns["ThanhTien"].HeaderText = "Thành tiền";
                        dgv.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                    }

                    decimal tong = dtCT.AsEnumerable().Sum(r => Convert.ToDecimal(r["ThanhTien"]));
                    var lblTong = new Label
                    {
                        Text = "TỔNG: " + tong.ToString("N0") + " đ",
                        Location = new Point(20, 415),
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                        ForeColor = Color.DarkRed,
                        AutoSize = true
                    };
                    f.Controls.Add(lblTong);

                    var btnClose = new Button
                    {
                        Text = "Đóng",
                        Location = new Point(560, 410),
                        Size = new Size(100, 36),
                        BackColor = Color.Gray,
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat
                    };
                    btnClose.Click += (s, ev) => f.Close();
                    f.Controls.Add(btnClose);

                    f.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xem chi tiết: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần hủy.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string maHD = dgvHoaDon.CurrentRow.Cells["MaHoaDonBan"].Value?.ToString();
            string tt = dgvHoaDon.CurrentRow.Cells["TrangThai"].Value?.ToString();
            if (string.IsNullOrEmpty(maHD)) return;

            if (tt == "Hủy")
            {
                MessageBox.Show("Hóa đơn này đã hủy.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Xác nhận HỦY hóa đơn {maHD}?\n(Tồn kho sẽ được cộng lại)",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Hủy HĐ + hoàn tồn kho trong Transaction
            SqlTransaction tran = null;
            try
            {
                if (Function.Conn.State != ConnectionState.Open) Function.Conn.Open();
                tran = Function.Conn.BeginTransaction();

                // 1. Update trạng thái HĐ
                using (var cmd = new SqlCommand(
                    "UPDATE HoaDonBan SET TrangThai = N'Hủy' WHERE MaHoaDonBan = @ma",
                    Function.Conn, tran))
                {
                    cmd.Parameters.AddWithValue("@ma", maHD);
                    cmd.ExecuteNonQuery();
                }

                // 2. Hoàn tồn kho từ ChiTietHoaDonBan
                using (var cmd = new SqlCommand(@"
                    UPDATE sp SET SoLuongTon = sp.SoLuongTon + ct.SoLuong
                    FROM SanPham sp
                    INNER JOIN ChiTietHoaDonBan ct ON sp.MaSanPham = ct.MaSanPham
                    WHERE ct.MaHoaDonBan = @ma",
                    Function.Conn, tran))
                {
                    cmd.Parameters.AddWithValue("@ma", maHD);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                MessageBox.Show("Đã hủy hóa đơn và cập nhật lại tồn kho.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                try { tran?.Rollback(); } catch { }
                MessageBox.Show("Lỗi hủy HĐ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var sfd = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = $"DanhSachHoaDon_{DateTime.Now:yyyyMMdd_HHmm}.csv"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    using (var sw = new System.IO.StreamWriter(sfd.FileName, false,
                        new System.Text.UTF8Encoding(true)))
                    {
                        var headers = dgvHoaDon.Columns.Cast<DataGridViewColumn>()
                            .Select(c => "\"" + c.HeaderText.Replace("\"", "\"\"") + "\"");
                        sw.WriteLine(string.Join(",", headers));

                        foreach (DataGridViewRow row in dgvHoaDon.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var cells = row.Cells.Cast<DataGridViewCell>()
                                .Select(c => "\"" + (c.Value?.ToString() ?? "").Replace("\"", "\"\"") + "\"");
                            sw.WriteLine(string.Join(",", cells));
                        }
                    }
                    MessageBox.Show("Đã xuất: " + sfd.FileName, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất: " + ex.Message);
                }
            }
        }
    }
}
