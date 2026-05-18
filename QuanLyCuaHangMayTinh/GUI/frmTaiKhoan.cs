using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;
using QuanLyCuaHangMayTinh.DTO;

namespace QuanLyCuaHangMayTinh
{
    /// <summary>Form quản lý tài khoản nhân viên — dùng NhanVienBUS với schema mới.</summary>
    public partial class frm_quanlytaikhoan : Form
    {
        private readonly NhanVienBUS _bus = new NhanVienBUS();
        private DataTable _dt;

        public frm_quanlytaikhoan()
        {
            InitializeComponent();
        }

        private void frm_quanlytaikhoan_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            try
            {
                Function.Connect();
                LoadVaiTroCombo();
                LoadData();

                // Đảm bảo các control HIỂN THỊ (sửa bug ẩn nhầm từ phiên cũ)
                if (txtLuong != null) txtLuong.Visible = true;
                if (mskNgaysinh != null) mskNgaysinh.Visible = true;
                if (label3 != null) label3.Text = "Vai trò";

                if (datagridtaikhoan != null) datagridtaikhoan.CellClick += DataGrid_CellClick;
                if (ibtnLuu != null) ibtnLuu.Click += BtnLuu_Click;
                if (ibtnSua != null) ibtnSua.Click += BtnSua_Click;
                if (ibtnLammoi != null) ibtnLammoi.Click += (s, ev) => { LoadData(); ResetValues(); };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadVaiTroCombo()
        {
            if (cboMachucvu == null) return;
            var dt = Function.GetDataToTable("SELECT MaVaiTro, TenVaiTro FROM VaiTro ORDER BY MaVaiTro");
            cboMachucvu.DataSource = dt;
            cboMachucvu.ValueMember = "MaVaiTro";
            cboMachucvu.DisplayMember = "TenVaiTro";
        }

        private void LoadData()
        {
            _dt = _bus.GetAll();
            if (datagridtaikhoan != null)
            {
                datagridtaikhoan.DataSource = _dt;
                // Format cột NgaySinh hiển thị dd/MM/yyyy thay vì kèm giờ
                if (datagridtaikhoan.Columns.Contains("NgaySinh"))
                {
                    datagridtaikhoan.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    datagridtaikhoan.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                }
            }
        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = datagridtaikhoan.Rows[e.RowIndex];
            try
            {
                if (txtManhanvien != null) txtManhanvien.Text = row.Cells["MaNhanVien"].Value?.ToString();
                if (txtTennhanvien != null) txtTennhanvien.Text = row.Cells["HoTen"].Value?.ToString();
                if (txtEmail != null) txtEmail.Text = row.Cells["Email"].Value?.ToString();
                if (mskSodienthoai != null) mskSodienthoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                if (cboMachucvu != null && row.Cells["MaVaiTro"].Value != null)
                    cboMachucvu.SelectedValue = row.Cells["MaVaiTro"].Value;
                string gt = row.Cells["GioiTinh"].Value?.ToString() ?? "";
                if (chkNam != null) chkNam.Checked = (gt == "Nam");
                if (chkNu != null) chkNu.Checked = (gt == "Nữ");

                // Ngày sinh: parse từ DataGridView (định dạng MM/dd/yyyy hoặc tương tự)
                if (mskNgaysinh != null && row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value != DBNull.Value)
                {
                    if (DateTime.TryParse(row.Cells["NgaySinh"].Value.ToString(), out DateTime ns))
                        mskNgaysinh.Text = ns.ToString("dd/MM/yyyy");
                    else
                        mskNgaysinh.Text = row.Cells["NgaySinh"].Value.ToString();
                }

                // Quê quán (DiaChi): bind vào combo nếu có item, nếu không thì để trống
                if (cboMaque != null && row.Cells["DiaChi"].Value != null)
                {
                    string que = row.Cells["DiaChi"].Value.ToString();
                    int idx = cboMaque.FindStringExact(que);
                    if (idx >= 0) cboMaque.SelectedIndex = idx;
                    else cboMaque.Text = que;
                }

                // Mật khẩu: KHÔNG hiển thị hash đã lưu (bảo mật, hash không thể decode ngược).
                // Hiển thị placeholder "********" để biết tài khoản đã có mật khẩu.
                // Admin có thể gõ mật khẩu mới vào ô này → khi Sửa sẽ tự reset.
                if (txtMatkhau != null)
                {
                    txtMatkhau.UseSystemPasswordChar = false;  // hiển thị plain ******** để admin thấy rõ
                    txtMatkhau.Text = MAT_KHAU_PLACEHOLDER;
                }
            }
            catch { }
        }

        // Placeholder để biết admin không đổi mật khẩu (chỉ xem)
        private const string MAT_KHAU_PLACEHOLDER = "********";

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtManhanvien?.Text) ||
                    string.IsNullOrWhiteSpace(txtTennhanvien?.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ mã và tên nhân viên.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nv = new NhanVienDTO
                {
                    MaNhanVien = txtManhanvien?.Text ?? "",
                    TenDangNhap = (txtManhanvien?.Text ?? "").ToLower(),
                    HoTen = txtTennhanvien?.Text ?? "",
                    GioiTinh = (chkNam != null && chkNam.Checked) ? "Nam"
                                : ((chkNu != null && chkNu.Checked) ? "Nữ" : "Khác"),
                    Email = txtEmail?.Text ?? "",
                    SoDienThoai = mskSodienthoai?.Text ?? "",
                    DiaChi = cboMaque?.Text ?? "",
                    MaVaiTro = cboMachucvu?.SelectedValue?.ToString() ?? "VT03",
                    NgaySinh = ParseNgaySinh(mskNgaysinh?.Text),
                    TrangThai = true
                };

                // Mật khẩu: nếu admin gõ vào ô (khác placeholder) thì dùng mật khẩu đó
                // Nếu để trống hoặc placeholder thì dùng default = mã NV + "123"
                string mkAdmin = txtMatkhau?.Text?.Trim() ?? "";
                string mk = (string.IsNullOrEmpty(mkAdmin) || mkAdmin == MAT_KHAU_PLACEHOLDER)
                    ? nv.MaNhanVien.ToLower() + "123"
                    : mkAdmin;

                bool ok = _bus.AddNhanVien(nv, mk);
                MessageBox.Show(ok ? $"Đã thêm nhân viên. Mật khẩu: {mk}" : "Lỗi thêm.",
                    "Thông báo", MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (ok) { LoadData(); ResetValues(); }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtManhanvien?.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nv = new NhanVienDTO
                {
                    MaNhanVien = txtManhanvien?.Text ?? "",
                    HoTen = txtTennhanvien?.Text ?? "",
                    GioiTinh = (chkNam != null && chkNam.Checked) ? "Nam"
                                : ((chkNu != null && chkNu.Checked) ? "Nữ" : "Khác"),
                    Email = txtEmail?.Text ?? "",
                    SoDienThoai = mskSodienthoai?.Text ?? "",
                    DiaChi = cboMaque?.Text ?? "",
                    MaVaiTro = cboMachucvu?.SelectedValue?.ToString() ?? "VT03",
                    NgaySinh = ParseNgaySinh(mskNgaysinh?.Text),
                    TrangThai = true
                };

                bool ok = _bus.UpdateNhanVien(nv);

                // Nếu admin có nhập mật khẩu mới (khác placeholder và không rỗng) → reset luôn
                string mkAdmin = txtMatkhau?.Text?.Trim() ?? "";
                string msg = ok ? "Đã cập nhật thông tin." : "Lỗi cập nhật.";
                if (ok && !string.IsNullOrEmpty(mkAdmin) && mkAdmin != MAT_KHAU_PLACEHOLDER)
                {
                    bool okMk = _bus.DoiMatKhau(nv.MaNhanVien, mkAdmin);
                    msg += okMk ? $"\nĐã reset mật khẩu mới cho {nv.MaNhanVien}." : "\nReset mật khẩu thất bại.";
                }

                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (ok) LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void ResetValues()
        {
            if (txtManhanvien != null) txtManhanvien.Text = "";
            if (txtTennhanvien != null) txtTennhanvien.Text = "";
            if (txtEmail != null) txtEmail.Text = "";
            if (mskSodienthoai != null) mskSodienthoai.Text = "";
            if (mskNgaysinh != null) mskNgaysinh.Text = "";
            if (chkNam != null) chkNam.Checked = false;
            if (chkNu != null) chkNu.Checked = false;
        }

        /// <summary>
        /// Parse chuỗi MaskedTextBox "dd/MM/yyyy" thành DateTime?.
        /// Trả về null nếu rỗng / không hợp lệ.
        /// </summary>
        private static DateTime? ParseNgaySinh(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            // Lọc bỏ ký tự mặc định "_" của MaskedTextBox
            text = text.Replace("_", "").Trim();
            if (string.IsNullOrWhiteSpace(text) || text.Length < 8) return null;

            // Thử các định dạng phổ biến
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "yyyy-MM-dd", "yyyy/MM/dd" };
            if (DateTime.TryParseExact(text, formats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime dt))
                return dt;

            // Fallback: parse linh hoạt
            if (DateTime.TryParse(text, out dt)) return dt;
            return null;
        }
    


        // Auto-generated event wrappers
        private void ibtnThem_Click(object sender, EventArgs e) { BtnLuu_Click(sender, e); }
        private void ibtnLuu_Click(object sender, EventArgs e) { BtnLuu_Click(sender, e); }
        private void ibtnSua_Click(object sender, EventArgs e) { BtnSua_Click(sender, e); }
        private void ibtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtManhanvien?.Text?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(maNV))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(
                        $"Bạn có chắc muốn xóa nhân viên {maNV}?\n\n" +
                        "(Đây là xóa MỀM: nhân viên sẽ không đăng nhập được nữa\n" +
                        "nhưng dữ liệu lịch sử bán hàng/nhập kho vẫn giữ nguyên.)",
                        "Xác nhận xóa", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes) return;

                bool ok = _bus.SoftDeleteNhanVien(maNV);
                MessageBox.Show(ok ? "Đã xóa nhân viên." : "Xóa thất bại.",
                    "Thông báo", MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (ok) { ResetValues(); LoadData(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ibtnLammoi_Click(object sender, EventArgs e) { ResetValues(); LoadData(); }
        private void txtManhanvien_TextChanged(object sender, EventArgs e) { }
        private void datagridtaikhoan_Click_1(object sender, EventArgs e) { }
    }
}
