using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh;

namespace QuanLyCuaHangMayTinh
{
    public partial class frm_quanlytaikhoan : Form
    {
        public frm_quanlytaikhoan()
        {
            InitializeComponent();
        }

        private DataTable dtNhanVien;
        private TextBox txtTimKiem;

        private void frm_quanlytaikhoan_Load(object sender, EventArgs e)
        {
            Function.Connect();

            // Cập nhật nhãn các control để phù hợp với schema mới
            label1.Text = "Mã nhân viên";
            label2.Text = "Họ tên";
            label3.Text = "Vai trò";
            label4.Text = "Tên đăng nhập";
            label5.Text = "Giới tính";
            label6.Text = "Email";
            label7.Text = "Mật khẩu";
            label8.Text = "Số điện thoại";
            label12.Text = "Địa chỉ";

            // Ẩn trường ngày sinh (không có trong schema mới)
            mskNgaysinh.Visible = false;
            label9.Visible = false;

            // Đổi cboMaque thành ô nhập tên đăng nhập
            cboMaque.DropDownStyle = ComboBoxStyle.Simple;
            cboMaque.Height = 33;

            // txtLuong dùng cho DiaChi
            txtLuong.ReadOnly = false;

            // Thêm ô tìm kiếm phía trên DataGridView
            txtTimKiem = new TextBox
            {
                Text = "Tìm kiếm theo tên, mã NV, vai trò...",
                ForeColor = System.Drawing.Color.Gray,
                Font = new Font("Microsoft Sans Serif", 11),
                Location = new Point(datagridtaikhoan.Left, datagridtaikhoan.Top - 38),
                Size = new Size(datagridtaikhoan.Width, 33)
            };
            txtTimKiem.GotFocus += (s, ev) => { if (txtTimKiem.ForeColor == System.Drawing.Color.Gray) { txtTimKiem.Text = ""; txtTimKiem.ForeColor = System.Drawing.Color.Black; } };
            txtTimKiem.LostFocus += (s, ev) => { if (string.IsNullOrWhiteSpace(txtTimKiem.Text)) { txtTimKiem.Text = "Tìm kiếm theo tên, mã NV, vai trò..."; txtTimKiem.ForeColor = System.Drawing.Color.Gray; } };
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            this.Controls.Add(txtTimKiem);
            txtTimKiem.BringToFront();

            txtManhanvien.Enabled = false;
            txtLuong.Enabled = false;
            ibtnLuu.Enabled = false;
            ibtnSua.Enabled = false;
            ibtnXoa.Enabled = false;

            Load_ComboBoxes();
            Load_DataGridView();
            ResetValues();
        }

        private void Load_DataGridView()
        {
            string sql = @"SELECT nv.MaNhanVien, nv.TenDangNhap, nv.HoTen, nv.GioiTinh,
                                  nv.SoDienThoai, nv.Email, nv.DiaChi,
                                  nv.MaVaiTro, vt.TenVaiTro, nv.TrangThai
                           FROM NhanVien nv
                           INNER JOIN VaiTro vt ON nv.MaVaiTro = vt.MaVaiTro
                           ORDER BY nv.MaNhanVien";
            dtNhanVien = Function.GetDataToTable(sql);
            datagridtaikhoan.DataSource = dtNhanVien;

            datagridtaikhoan.Columns["MaNhanVien"].HeaderText = "Mã NV";
            datagridtaikhoan.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            datagridtaikhoan.Columns["HoTen"].HeaderText = "Họ tên";
            datagridtaikhoan.Columns["GioiTinh"].HeaderText = "Giới tính";
            datagridtaikhoan.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            datagridtaikhoan.Columns["Email"].HeaderText = "Email";
            datagridtaikhoan.Columns["DiaChi"].HeaderText = "Địa chỉ";
            datagridtaikhoan.Columns["TenVaiTro"].HeaderText = "Vai trò";
            datagridtaikhoan.Columns["TrangThai"].HeaderText = "Trạng thái";
            datagridtaikhoan.Columns["MaVaiTro"].Visible = false;

            datagridtaikhoan.AllowUserToAddRows = false;
            datagridtaikhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Load_ComboBoxes()
        {
            DataTable dtVaiTro = Function.GetDataToTable("SELECT MaVaiTro, TenVaiTro FROM VaiTro");
            cboMachucvu.DataSource = dtVaiTro;
            cboMachucvu.ValueMember = "MaVaiTro";
            cboMachucvu.DisplayMember = "TenVaiTro";
            cboMachucvu.SelectedIndex = -1;
        }

        private void ResetValues()
        {
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            txtEmail.Text = "";
            mskSodienthoai.Text = "";
            txtMatkhau.Text = "";
            txtLuong.Text = "";
            cboMachucvu.SelectedIndex = -1;
            cboMaque.Text = "";
            chkNam.Checked = false;
            chkNu.Checked = false;
            ibtnLammoi.Enabled = true;
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dtNhanVien == null) return;
            if (txtTimKiem.ForeColor == System.Drawing.Color.Gray) return;
            string kw = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(kw))
            {
                datagridtaikhoan.DataSource = dtNhanVien;
                return;
            }
            DataView dv = dtNhanVien.DefaultView;
            dv.RowFilter = $"HoTen LIKE '%{kw}%' OR MaNhanVien LIKE '%{kw}%' OR TenDangNhap LIKE '%{kw}%' OR TenVaiTro LIKE '%{kw}%'";
            datagridtaikhoan.DataSource = dv.ToTable();
        }

        private void datagridtaikhoan_Click_1(object sender, EventArgs e)
        {
            if (ibtnLuu.Enabled)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (datagridtaikhoan.CurrentRow == null || datagridtaikhoan.Rows.Count == 0) return;

            DataGridViewRow row = datagridtaikhoan.CurrentRow;
            txtManhanvien.Text = row.Cells["MaNhanVien"].Value?.ToString() ?? "";
            txtTennhanvien.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            mskSodienthoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
            txtMatkhau.Text = "";
            txtLuong.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
            cboMaque.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
            cboMachucvu.SelectedValue = row.Cells["MaVaiTro"].Value?.ToString() ?? "";

            string gt = row.Cells["GioiTinh"].Value?.ToString() ?? "";
            chkNam.Checked = gt == "Nam" || gt == "M";
            chkNu.Checked = gt == "Nu" || gt == "F" || gt == "Nữ";

            ibtnSua.Enabled = true;
            ibtnXoa.Enabled = true;
        }

        private void ibtnThem_Click(object sender, EventArgs e)
        {
            ibtnSua.Enabled = false;
            ibtnXoa.Enabled = false;
            ibtnLuu.Enabled = true;
            ibtnThem.Enabled = false;
            ibtnLammoi.Enabled = true;
            ResetValues();
            txtManhanvien.Enabled = true;
            txtLuong.Enabled = true;
            txtManhanvien.Focus();
        }

        private void ibtnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(requireMaNV: true)) return;

            string gioitinh = chkNam.Checked ? "Nam" : "Nữ";
            string matkhau = string.IsNullOrWhiteSpace(txtMatkhau.Text)
                ? null
                : SecurityHelper.ComputeSha256(txtMatkhau.Text.Trim());

            string sqlUpdate;
            if (matkhau != null)
            {
                sqlUpdate = @"UPDATE NhanVien SET HoTen=@HoTen, TenDangNhap=@TenDangNhap, GioiTinh=@GioiTinh,
                              SoDienThoai=@SDT, Email=@Email, DiaChi=@DiaChi, MaVaiTro=@MaVaiTro, MatKhau=@MatKhau
                              WHERE MaNhanVien=@MaNV";
                Function.RunSql(sqlUpdate,
                    new System.Data.SqlClient.SqlParameter("@HoTen", txtTennhanvien.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@TenDangNhap", cboMaque.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@GioiTinh", gioitinh),
                    new System.Data.SqlClient.SqlParameter("@SDT", mskSodienthoai.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@Email", txtEmail.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@DiaChi", txtLuong.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@MaVaiTro", cboMachucvu.SelectedValue.ToString()),
                    new System.Data.SqlClient.SqlParameter("@MatKhau", matkhau),
                    new System.Data.SqlClient.SqlParameter("@MaNV", txtManhanvien.Text.Trim()));
            }
            else
            {
                sqlUpdate = @"UPDATE NhanVien SET HoTen=@HoTen, TenDangNhap=@TenDangNhap, GioiTinh=@GioiTinh,
                              SoDienThoai=@SDT, Email=@Email, DiaChi=@DiaChi, MaVaiTro=@MaVaiTro
                              WHERE MaNhanVien=@MaNV";
                Function.RunSql(sqlUpdate,
                    new System.Data.SqlClient.SqlParameter("@HoTen", txtTennhanvien.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@TenDangNhap", cboMaque.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@GioiTinh", gioitinh),
                    new System.Data.SqlClient.SqlParameter("@SDT", mskSodienthoai.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@Email", txtEmail.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@DiaChi", txtLuong.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@MaVaiTro", cboMachucvu.SelectedValue.ToString()),
                    new System.Data.SqlClient.SqlParameter("@MaNV", txtManhanvien.Text.Trim()));
            }

            Load_DataGridView();
            ResetValues();
            ibtnSua.Enabled = false;
            ibtnXoa.Enabled = false;
            ibtnLuu.Enabled = false;
            ibtnThem.Enabled = true;
            MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ibtnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(requireMaNV: true)) return;
            if (string.IsNullOrWhiteSpace(cboMaque.Text))
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaque.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMatkhau.Text))
            {
                MessageBox.Show("Bạn phải nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatkhau.Focus();
                return;
            }

            // Kiểm tra trùng mã NV
            if (Function.CheckKey($"SELECT MaNhanVien FROM NhanVien WHERE MaNhanVien=N'{txtManhanvien.Text.Trim()}'"))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                return;
            }
            // Kiểm tra trùng tên đăng nhập
            if (Function.CheckKey($"SELECT TenDangNhap FROM NhanVien WHERE TenDangNhap=N'{cboMaque.Text.Trim()}'"))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaque.Focus();
                return;
            }

            string gioitinh = chkNam.Checked ? "Nam" : "Nữ";
            string hashedPwd = SecurityHelper.ComputeSha256(txtMatkhau.Text.Trim());

            try
            {
                Function.RunSql(@"INSERT INTO NhanVien (MaNhanVien, TenDangNhap, MatKhau, HoTen, GioiTinh, SoDienThoai, Email, DiaChi, MaVaiTro, TrangThai)
                                  VALUES (@MaNV, @TenDN, @MatKhau, @HoTen, @GT, @SDT, @Email, @DiaChi, @MaVaiTro, 1)",
                    new System.Data.SqlClient.SqlParameter("@MaNV", txtManhanvien.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@TenDN", cboMaque.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@MatKhau", hashedPwd),
                    new System.Data.SqlClient.SqlParameter("@HoTen", txtTennhanvien.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@GT", gioitinh),
                    new System.Data.SqlClient.SqlParameter("@SDT", mskSodienthoai.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@Email", txtEmail.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@DiaChi", txtLuong.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@MaVaiTro", cboMachucvu.SelectedValue.ToString()));

                Load_DataGridView();
                ResetValues();
                ibtnThem.Enabled = true;
                ibtnSua.Enabled = false;
                ibtnXoa.Enabled = false;
                ibtnLuu.Enabled = false;
                txtManhanvien.Enabled = false;
                txtLuong.Enabled = false;
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtManhanvien.Text))
            {
                MessageBox.Show("Bạn phải chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Bạn có chắc muốn xóa nhân viên [{txtManhanvien.Text}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Function.RunSql("UPDATE NhanVien SET TrangThai=0 WHERE MaNhanVien=@MaNV",
                    new System.Data.SqlClient.SqlParameter("@MaNV", txtManhanvien.Text.Trim()));
                Load_DataGridView();
                ResetValues();
                ibtnSua.Enabled = false;
                ibtnXoa.Enabled = false;
                MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtnLammoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            ibtnThem.Enabled = true;
            ibtnSua.Enabled = false;
            ibtnXoa.Enabled = false;
            ibtnLuu.Enabled = false;
            txtManhanvien.Enabled = false;
            txtLuong.Enabled = false;
            if (txtTimKiem != null) txtTimKiem.Text = "";
            Load_DataGridView();
        }

        private bool ValidateFields(bool requireMaNV)
        {
            if (requireMaNV && string.IsNullOrWhiteSpace(txtManhanvien.Text))
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtTennhanvien.Text))
            {
                MessageBox.Show("Bạn phải nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus(); return false;
            }
            if (cboMachucvu.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMachucvu.Focus(); return false;
            }
            if (!chkNam.Checked && !chkNu.Checked)
            {
                MessageBox.Show("Bạn phải chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void cboMachucvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Không cần load lương vì dùng VaiTro thay cho ChucVu
        }

        private void chkNam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNam.Checked) chkNu.Checked = false;
        }

        private void chkNu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNu.Checked) chkNam.Checked = false;
        }

        private void txtManhanvien_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
