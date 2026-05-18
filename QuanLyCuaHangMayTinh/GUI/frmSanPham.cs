using QuanLyCuaHangMayTinh;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh_Forms.Data;
using QuanLyCuaHangMayTinh_Forms.Enums;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    public partial class frmSanPham : Form
    {
        private readonly string _currentRole;
        private readonly bool _canManage;
        private FormMode _mode = FormMode.View;
        private string _selectedImagePath = string.Empty;

        public frmSanPham() : this("Admin")
        {
        }

        public frmSanPham(string currentRole)
        {
            _currentRole = currentRole;
            // Theo đề số 1, mục 1.2: chỉ NV Kho được CRUD sản phẩm.
            // Admin CRUD mọi danh mục TRỪ sản phẩm → Admin chỉ tìm kiếm/xem.
            _canManage = string.Equals(_currentRole, "Nhân viên kho", StringComparison.CurrentCultureIgnoreCase)
                      || string.Equals(_currentRole, "NhanVienKho", StringComparison.CurrentCultureIgnoreCase);

            InitializeComponent();

            // Đảm bảo các event được wire kể cả khi Designer có vấn đề
            this.Load -= frmSanPham_Load;
            this.Load += frmSanPham_Load;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            try
            {
                LoadDanhMucCombobox();
                LoadSanPham();
                SetFormMode(FormMode.View);

                // Wire runtime để đảm bảo nút Chọn ảnh luôn hoạt động
                // (Designer có thể không sync sau khi sửa Designer.cs)
                if (btnChonAnh != null)
                {
                    btnChonAnh.Click -= btnChonAnh_Click; // tránh duplicate nếu Designer đã wire
                    btnChonAnh.Click += btnChonAnh_Click;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi tạo dữ liệu cho form sản phẩm.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhMucCombobox()
        {
            LoadComboLoai(cboLoaiSanPham, false);
            LoadComboThuongHieu(cboThuongHieu, false);
            LoadComboNhaCungCap(cboNhaCungCap, false);
            LoadComboLoai(cboLocLoai, true);
            LoadComboThuongHieu(cboLocThuongHieu, true);
        }

        private void LoadComboLoai(ComboBox combo, bool includeAll)
        {
            var dt = DbHelper.GetDataTable("SELECT MaLoai, TenLoai FROM LoaiSanPham ORDER BY TenLoai;");
            if (includeAll)
            {
                var row = dt.NewRow();
                row["MaLoai"] = string.Empty;
                row["TenLoai"] = "-- Tất cả --";
                dt.Rows.InsertAt(row, 0);
            }

            combo.DataSource = dt;
            combo.DisplayMember = "TenLoai";
            combo.ValueMember = "MaLoai";
        }

        private void LoadComboThuongHieu(ComboBox combo, bool includeAll)
        {
            var dt = DbHelper.GetDataTable("SELECT MaThuongHieu, TenThuongHieu FROM ThuongHieu ORDER BY TenThuongHieu;");
            if (includeAll)
            {
                var row = dt.NewRow();
                row["MaThuongHieu"] = string.Empty;
                row["TenThuongHieu"] = "-- Tất cả --";
                dt.Rows.InsertAt(row, 0);
            }

            combo.DataSource = dt;
            combo.DisplayMember = "TenThuongHieu";
            combo.ValueMember = "MaThuongHieu";
        }

        private void LoadComboNhaCungCap(ComboBox combo, bool includeAll)
        {
            var dt = DbHelper.GetDataTable("SELECT MaNCC, TenNCC FROM NhaCungCap ORDER BY TenNCC;");
            if (includeAll)
            {
                var row = dt.NewRow();
                row["MaNCC"] = string.Empty;
                row["TenNCC"] = "-- Tất cả --";
                dt.Rows.InsertAt(row, 0);
            }

            combo.DataSource = dt;
            combo.DisplayMember = "TenNCC";
            combo.ValueMember = "MaNCC";
        }

        private void LoadSanPham()
        {
            const string query = @"
SELECT
    sp.MaSanPham,
    sp.TenSanPham,
    lsp.TenLoai,
    th.TenThuongHieu,
    ncc.TenNCC,
    sp.GiaNhap,
    sp.GiaBan,
    sp.SoLuongTon,
    LEFT(ISNULL(sp.MoTa, N''), 80) AS MoTa,
    sp.BaoHanhThang,
    sp.HinhAnh,
    sp.MaLoai,
    sp.MaThuongHieu,
    sp.MaNCC
FROM SanPham sp
INNER JOIN LoaiSanPham lsp ON sp.MaLoai = lsp.MaLoai
INNER JOIN ThuongHieu th ON sp.MaThuongHieu = th.MaThuongHieu
INNER JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC
WHERE
    (@TuKhoa = N'' OR sp.MaSanPham LIKE @LikeTuKhoa OR sp.TenSanPham LIKE @LikeTuKhoa OR ISNULL(sp.MoTa, N'') LIKE @LikeTuKhoa)
    AND (@MaLoai = N'' OR sp.MaLoai = @MaLoai)
    AND (@MaThuongHieu = N'' OR sp.MaThuongHieu = @MaThuongHieu)
ORDER BY sp.TenSanPham;";

            var tuKhoa = txtTuKhoa.Text.Trim();
            var maLoai = Convert.ToString(cboLocLoai.SelectedValue) ?? string.Empty;
            var maThuongHieu = Convert.ToString(cboLocThuongHieu.SelectedValue) ?? string.Empty;

            try
            {
                dgvSanPham.DataSource = DbHelper.GetDataTable(
                    query,
                    new SqlParameter("@TuKhoa", tuKhoa),
                    new SqlParameter("@LikeTuKhoa", "%" + tuKhoa + "%"),
                    new SqlParameter("@MaLoai", maLoai),
                    new SqlParameter("@MaThuongHieu", maThuongHieu));

                FormatSanPhamGrid();

                if (dgvSanPham.Rows.Count > 0)
                {
                    dgvSanPham.Rows[0].Selected = true;
                    FillInputsFromGrid();
                }
                else
                {
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu sản phẩm.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ApplyPermissions();
        }

        private void FormatSanPhamGrid()
        {
            if (dgvSanPham.Columns.Count == 0)
                return;

            dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns["TenLoai"].HeaderText = "Loại";
            dgvSanPham.Columns["TenThuongHieu"].HeaderText = "Thương hiệu";
            dgvSanPham.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
            dgvSanPham.Columns["GiaNhap"].HeaderText = "Giá nhập";
            dgvSanPham.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvSanPham.Columns["SoLuongTon"].HeaderText = "Tồn kho";
            dgvSanPham.Columns["MoTa"].HeaderText = "Mô tả ngắn";
            dgvSanPham.Columns["BaoHanhThang"].HeaderText = "Bảo hành";

            dgvSanPham.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
            dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgvSanPham.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSanPham.Columns["BaoHanhThang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvSanPham.Columns["HinhAnh"].Visible = false;
            dgvSanPham.Columns["MaLoai"].Visible = false;
            dgvSanPham.Columns["MaThuongHieu"].Visible = false;
            dgvSanPham.Columns["MaNCC"].Visible = false;
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (_mode == FormMode.View)
            {
                FillInputsFromGrid();
                ApplyPermissions();
            }
        }

        private void FillInputsFromGrid()
        {
            if (dgvSanPham.CurrentRow == null || dgvSanPham.CurrentRow.DataBoundItem == null)
                return;

            txtMaSanPham.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value);
            txtTenSanPham.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["TenSanPham"].Value);
            cboLoaiSanPham.SelectedValue = Convert.ToString(dgvSanPham.CurrentRow.Cells["MaLoai"].Value);
            cboThuongHieu.SelectedValue = Convert.ToString(dgvSanPham.CurrentRow.Cells["MaThuongHieu"].Value);
            cboNhaCungCap.SelectedValue = Convert.ToString(dgvSanPham.CurrentRow.Cells["MaNCC"].Value);
            txtGiaNhap.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["GiaNhap"].Value);
            txtGiaBan.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["GiaBan"].Value);
            txtSoLuongTon.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["SoLuongTon"].Value);
            txtBaoHanhThang.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["BaoHanhThang"].Value);

            string maSanPham = txtMaSanPham.Text.Trim();
            if (!string.IsNullOrEmpty(maSanPham))
            {
                var fullInfo = DbHelper.GetDataTable(
                    "SELECT MoTa, HinhAnh FROM SanPham WHERE MaSanPham = @Ma;",
                    new SqlParameter("@Ma", maSanPham));

                if (fullInfo.Rows.Count > 0)
                {
                    rtbMoTa.Text = Convert.ToString(fullInfo.Rows[0]["MoTa"]);
                    _selectedImagePath = Convert.ToString(fullInfo.Rows[0]["HinhAnh"]);
                    LoadImageToPictureBox(_selectedImagePath);
                }
            }
        }

        private void ClearInputs()
        {
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuongTon.Clear();
            txtBaoHanhThang.Text = "12";
            rtbMoTa.Clear();
            _selectedImagePath = string.Empty;
            picHinhAnh.Image = null;
            picHinhAnh.BackColor = Color.White;
            lblDuongDanAnh.Text = "Chưa chọn ảnh";

            if (cboLoaiSanPham.Items.Count > 0) cboLoaiSanPham.SelectedIndex = 0;
            if (cboThuongHieu.Items.Count > 0) cboThuongHieu.SelectedIndex = 0;
            if (cboNhaCungCap.Items.Count > 0) cboNhaCungCap.SelectedIndex = 0;
        }

        private void LoadImageToPictureBox(string imagePath)
        {
            picHinhAnh.Image = null;
            picHinhAnh.BackColor = Color.White;
            lblDuongDanAnh.Text = string.IsNullOrWhiteSpace(imagePath) ? "Chưa chọn ảnh" : Path.GetFileName(imagePath);

            if (string.IsNullOrWhiteSpace(imagePath))
                return;

            try
            {
                // Thử các đường dẫn có thể: tuyệt đối, ./Images/, ../Images/, exe folder
                string foundPath = ResolveImagePath(imagePath);
                if (!string.IsNullOrEmpty(foundPath))
                {
                    using (var fs = new FileStream(foundPath, FileMode.Open, FileAccess.Read))
                    using (var img = Image.FromStream(fs))
                    {
                        picHinhAnh.Image = new Bitmap(img);
                    }
                    picHinhAnh.BackColor = Color.White; // Giữ trắng kể cả khi có ảnh
                }
                // Nếu không tìm thấy → giữ nền trắng (không phải MistyRose)
            }
            catch
            {
                picHinhAnh.Image = null;
                picHinhAnh.BackColor = Color.White; // Lỗi cũng để trắng, không phải hồng
            }
        }

        /// <summary>
        /// Resolve đường dẫn ảnh: thử tuyệt đối → Images/ → bin/Images/ → exe/Images/
        /// </summary>
        private string ResolveImagePath(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath)) return null;
            if (File.Exists(imagePath)) return imagePath;

            string fileName = Path.GetFileName(imagePath);

            // Các thư mục có thể chứa ảnh
            string[] candidates = new[]
            {
                Path.Combine(Application.StartupPath, "Images", fileName),
                Path.Combine(Application.StartupPath, fileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", fileName),
                Path.Combine(Environment.CurrentDirectory, "Images", fileName),
                Path.Combine(Environment.CurrentDirectory, fileName),
            };

            foreach (var p in candidates)
                if (File.Exists(p)) return p;

            return null;
        }

        private void SetFormMode(FormMode mode)
        {
            _mode = mode;

            if (mode == FormMode.View)
            {
                FillInputsFromGrid();
            }
            else if (mode == FormMode.Add)
            {
                ClearInputs();
            }

            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            bool isEditing = _canManage && _mode != FormMode.View;
            bool isSaleRole = string.Equals(_currentRole, "Nhân viên bán hàng", StringComparison.CurrentCultureIgnoreCase);

            btnThem.Enabled = _canManage && _mode == FormMode.View;
            btnSua.Enabled = _canManage && _mode == FormMode.View && dgvSanPham.CurrentRow != null;
            btnXoa.Enabled = _canManage && _mode == FormMode.View && dgvSanPham.CurrentRow != null;
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;
            btnChonAnh.Enabled = isEditing;

            txtMaSanPham.ReadOnly = _mode != FormMode.Add;
            txtTenSanPham.ReadOnly = !isEditing;
            txtGiaNhap.ReadOnly = !isEditing;
            txtGiaBan.ReadOnly = !isEditing;
            txtSoLuongTon.ReadOnly = !isEditing;
            txtBaoHanhThang.ReadOnly = !isEditing;
            rtbMoTa.ReadOnly = !isEditing;
            cboLoaiSanPham.Enabled = isEditing;
            cboThuongHieu.Enabled = isEditing;
            cboNhaCungCap.Enabled = isEditing;

            if (dgvSanPham.Columns.Contains("GiaNhap"))
            {
                dgvSanPham.Columns["GiaNhap"].Visible = !isSaleRole;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSanPham.Text))
            {
                MessageBox.Show("Mã sản phẩm không được để trống.");
                txtMaSanPham.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.");
                txtTenSanPham.Focus();
                return false;
            }

            if (cboLoaiSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm.");
                cboLoaiSanPham.Focus();
                return false;
            }

            if (cboThuongHieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thương hiệu.");
                cboThuongHieu.Focus();
                return false;
            }

            if (cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp.");
                cboNhaCungCap.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiaNhap.Text.Trim(), out var giaNhap) || giaNhap <= 0)
            {
                MessageBox.Show("Giá nhập phải là số lớn hơn 0.");
                txtGiaNhap.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out var giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán phải là số lớn hơn 0.");
                txtGiaBan.Focus();
                return false;
            }

            if (giaBan < giaNhap)
            {
                MessageBox.Show("Giá bán nên lớn hơn hoặc bằng giá nhập.");
                txtGiaBan.Focus();
                return false;
            }

            if (!int.TryParse(txtSoLuongTon.Text.Trim(), out var soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn phải là số nguyên không âm.");
                txtSoLuongTon.Focus();
                return false;
            }

            if (!int.TryParse(txtBaoHanhThang.Text.Trim(), out var baoHanh) || baoHanh < 0)
            {
                MessageBox.Show("Bảo hành phải là số nguyên không âm.");
                txtBaoHanhThang.Focus();
                return false;
            }

            if (_mode == FormMode.Add)
            {
                int duplicate = DbHelper.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM SanPham WHERE MaSanPham = @Ma;",
                    new SqlParameter("@Ma", txtMaSanPham.Text.Trim()));

                if (duplicate > 0)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại.");
                    txtMaSanPham.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetFormMode(FormMode.Add);
            txtMaSanPham.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.");
                return;
            }

            SetFormMode(FormMode.Edit);
            txtTenSanPham.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
                return;
            }

            string maSanPham = txtMaSanPham.Text.Trim();
            int usedInOrder = DbHelper.ExecuteScalar<int>(
                "SELECT COUNT(1) FROM ChiTietDonDatHang WHERE MaSanPham = @Ma;",
                new SqlParameter("@Ma", maSanPham));
            int usedInInvoice = DbHelper.ExecuteScalar<int>(
                "SELECT COUNT(1) FROM ChiTietHoaDonBan WHERE MaSanPham = @Ma;",
                new SqlParameter("@Ma", maSanPham));
            int usedInImport = DbHelper.ExecuteScalar<int>(
                "SELECT COUNT(1) FROM ChiTietPhieuNhap WHERE MaSanPham = @Ma;",
                new SqlParameter("@Ma", maSanPham));
            int usedInReturn = DbHelper.ExecuteScalar<int>(
                "SELECT COUNT(1) FROM ChiTietPhieuTraHang WHERE MaSanPham = @Ma;",
                new SqlParameter("@Ma", maSanPham));

            if (usedInOrder > 0 || usedInInvoice > 0 || usedInImport > 0 || usedInReturn > 0)
            {
                MessageBox.Show("Không thể xóa vì sản phẩm đã phát sinh dữ liệu liên quan.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                DbHelper.ExecuteNonQuery(
                    "DELETE FROM SanPham WHERE MaSanPham = @Ma;",
                    new SqlParameter("@Ma", maSanPham));
                LoadSanPham();
                SetFormMode(FormMode.View);
                MessageBox.Show("Xóa sản phẩm thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được sản phẩm.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                if (_mode == FormMode.Add)
                {
                    DbHelper.ExecuteNonQuery(
                        @"INSERT INTO SanPham
                        (MaSanPham, TenSanPham, MaLoai, MaThuongHieu, MaNCC, GiaNhap, GiaBan, SoLuongTon, MoTa, HinhAnh, BaoHanhThang)
                        VALUES (@Ma, @Ten, @MaLoai, @MaThuongHieu, @MaNCC, @GiaNhap, @GiaBan, @SoLuongTon, @MoTa, @HinhAnh, @BaoHanh);",
                        BuildParameters());
                }
                else if (_mode == FormMode.Edit)
                {
                    DbHelper.ExecuteNonQuery(
                        @"UPDATE SanPham
                        SET TenSanPham = @Ten,
                            MaLoai = @MaLoai,
                            MaThuongHieu = @MaThuongHieu,
                            MaNCC = @MaNCC,
                            GiaNhap = @GiaNhap,
                            GiaBan = @GiaBan,
                            SoLuongTon = @SoLuongTon,
                            MoTa = @MoTa,
                            HinhAnh = @HinhAnh,
                            BaoHanhThang = @BaoHanh
                        WHERE MaSanPham = @Ma;",
                        BuildParameters());
                }

                LoadSanPham();
                SetFormMode(FormMode.View);
                MessageBox.Show("Lưu sản phẩm thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lưu được sản phẩm.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SqlParameter[] BuildParameters()
        {
            return new[]
            {
                new SqlParameter("@Ma", txtMaSanPham.Text.Trim()),
                new SqlParameter("@Ten", txtTenSanPham.Text.Trim()),
                new SqlParameter("@MaLoai", Convert.ToString(cboLoaiSanPham.SelectedValue)),
                new SqlParameter("@MaThuongHieu", Convert.ToString(cboThuongHieu.SelectedValue)),
                new SqlParameter("@MaNCC", Convert.ToString(cboNhaCungCap.SelectedValue)),
                new SqlParameter("@GiaNhap", decimal.Parse(txtGiaNhap.Text.Trim())),
                new SqlParameter("@GiaBan", decimal.Parse(txtGiaBan.Text.Trim())),
                new SqlParameter("@SoLuongTon", int.Parse(txtSoLuongTon.Text.Trim())),
                new SqlParameter("@MoTa", string.IsNullOrWhiteSpace(rtbMoTa.Text) ? (object)DBNull.Value : rtbMoTa.Text.Trim()),
                new SqlParameter("@HinhAnh", string.IsNullOrWhiteSpace(_selectedImagePath) ? (object)DBNull.Value : _selectedImagePath),
                new SqlParameter("@BaoHanh", int.Parse(txtBaoHanhThang.Text.Trim()))
            };
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            // Nếu nút bị disable mà vẫn click được (an toàn) → hướng dẫn user
            if (!_canManage)
            {
                MessageBox.Show(
                    "Tài khoản hiện tại không có quyền sửa sản phẩm.\n" +
                    "Vui lòng đăng nhập bằng tài khoản Nhân viên kho (kho/kho123) để chọn ảnh.",
                    "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_mode == FormMode.View)
            {
                MessageBox.Show(
                    "Vui lòng bấm 'Thêm' để thêm sản phẩm mới hoặc 'Sửa' để chỉnh sửa sản phẩm hiện tại trước khi chọn ảnh.",
                    "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn hình ảnh sản phẩm";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = dialog.FileName;
                    try
                    {
                        // Load image — đảm bảo dispose ảnh cũ trước khi load mới
                        if (picHinhAnh.Image != null)
                        {
                            var old = picHinhAnh.Image;
                            picHinhAnh.Image = null;
                            old.Dispose();
                        }

                        // Đọc file vào memory rồi load — tránh giữ file lock
                        byte[] bytes = System.IO.File.ReadAllBytes(_selectedImagePath);
                        using (var ms = new System.IO.MemoryStream(bytes))
                        {
                            picHinhAnh.Image = System.Drawing.Image.FromStream(ms);
                        }
                        picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                        picHinhAnh.BackColor = System.Drawing.Color.White;

                        if (lblDuongDanAnh != null)
                            lblDuongDanAnh.Text = System.IO.Path.GetFileName(_selectedImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh:\n" + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadSanPham();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadSanPham();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            if (cboLocLoai.Items.Count > 0) cboLocLoai.SelectedIndex = 0;
            if (cboLocThuongHieu.Items.Count > 0) cboLocThuongHieu.SelectedIndex = 0;
            LoadSanPham();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetFormMode(FormMode.View);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            if (cboLocLoai.Items.Count > 0) cboLocLoai.SelectedIndex = 0;
            if (cboLocThuongHieu.Items.Count > 0) cboLocThuongHieu.SelectedIndex = 0;
            LoadSanPham();
            SetFormMode(FormMode.View);
        }
    }
}
