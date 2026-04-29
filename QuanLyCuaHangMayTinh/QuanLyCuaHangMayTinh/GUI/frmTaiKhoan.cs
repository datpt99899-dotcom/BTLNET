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
        DataTable NV;
        private void frm_quanlytaikhoan_Load(object sender, EventArgs e)
        {
            Function.Connect();
            txtManhanvien.Enabled = false;
            txtLuong.Enabled = false;
            ibtnLuu.Enabled = false;
            ibtnLammoi.Enabled = true;
            chkNam.CheckedChanged += chkNam_CheckedChanged;
            chkNu.CheckedChanged += chkNu_CheckedChanged;
            cboMachucvu.SelectedIndexChanged += new EventHandler(cboMachucvu_SelectedIndexChanged); // Đăng ký sự kiện
            Load_DataGridView();
            Load_ComboBoxes();
            ResetValues();

        }
        private void Load_DataGridView()
        {
            string sql = "SELECT nv.Manhanvien, nv.TenNhanvien, nv.GioiTinh, nv.NgaySinh, nv.Email, nv.SoDienThoai, " +
             "nv.MaChucVu, cv.TenChucVu, nv.MaQue, q.TenQue, nv.MatKhau, nv.NgayTao, cv.LuongCoBan " +
             "FROM Nhanvien nv " +
             "JOIN ChucVu cv ON nv.MaChucVu = cv.MaChucVu " +
             "JOIN Que q ON nv.MaQue = q.MaQue";
            NV = Function.GetDataToTable(sql);
            datagridtaikhoan.DataSource = NV;
            datagridtaikhoan.Columns["Manhanvien"].HeaderText = "Mã nhân viên";
            datagridtaikhoan.Columns["TenNhanvien"].HeaderText = "Tên nhân viên";
            datagridtaikhoan.Columns["GioiTinh"].HeaderText = "Giới tính";
            datagridtaikhoan.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            datagridtaikhoan.Columns["Email"].HeaderText = "Email";
            datagridtaikhoan.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            datagridtaikhoan.Columns["TenChucVu"].HeaderText = "Chức vụ";
            datagridtaikhoan.Columns["TenQue"].HeaderText = "Quê quán";
            datagridtaikhoan.Columns["MatKhau"].HeaderText = "Mật khẩu";
            datagridtaikhoan.Columns["LuongCoBan"].HeaderText = "LuongCoBan";
            datagridtaikhoan.Columns["NgayTao"].HeaderText = "Ngày tạo";
            datagridtaikhoan.Columns["MaChucVu"].Visible = false;
            datagridtaikhoan.Columns["MaQue"].Visible = false;
            datagridtaikhoan.Columns[0].Width = 100;
            datagridtaikhoan.Columns[1].Width = 250;
            datagridtaikhoan.Columns[2].Width = 250;
            datagridtaikhoan.Columns[3].Width = 250;
            datagridtaikhoan.Columns[4].Width = 250;
            datagridtaikhoan.Columns[5].Width = 250;
            datagridtaikhoan.Columns[6].Width = 250;
            datagridtaikhoan.Columns[7].Width = 250;
            datagridtaikhoan.Columns[8].Width = 250;
            datagridtaikhoan.Columns[9].Width = 250;
            datagridtaikhoan.Columns[10].Width = 250;
            datagridtaikhoan.AllowUserToAddRows = false;
            datagridtaikhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ComboBoxes()
        {
            string sqlChucVu = "SELECT MaChucVu, TenChucVu FROM ChucVu";
            DataTable dtChucVu = Function.GetDataToTable(sqlChucVu);
            cboMachucvu.DataSource = dtChucVu;
            cboMachucvu.ValueMember = "MaChucVu"; // Lưu mã
            cboMachucvu.DisplayMember = "TenChucVu"; // Hiển thị tên
            cboMachucvu.SelectedIndex = -1; // Không chọn mặc định
            string sqlQue = "SELECT MaQue, TenQue FROM Que";
            DataTable dtQue = Function.GetDataToTable(sqlQue);
            cboMaque.DataSource = dtQue;
            cboMaque.ValueMember = "MaQue";
            cboMaque.DisplayMember = "TenQue";
            cboMaque.SelectedIndex = -1;
        }
        private void ResetValues()
        {
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            txtEmail.Text = "";
            mskSodienthoai.Text = "";
            mskNgaysinh.Text = "";
            cboMachucvu.SelectedIndex = -1; // Xóa lựa chọn
            cboMaque.SelectedIndex = -1; // Xóa lựa chọn
            txtMatkhau.Text = "";
            chkNam.Checked = false;
            chkNu.Checked = false;
            ibtnLammoi.Enabled = true;
        }

        private void datagridtaikhoan_Click_1(object sender, EventArgs e)
        {
            if (ibtnLuu.Enabled == true) // Đang ở chế độ thêm mới
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManhanvien.Focus();
                return;
            }

            if (datagridtaikhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Gán dữ liệu từ dòng hiện tại vào các ô nhập liệu
            txtManhanvien.Text = datagridtaikhoan.CurrentRow.Cells["Manhanvien"].Value.ToString();
            txtTennhanvien.Text = datagridtaikhoan.CurrentRow.Cells["TenNhanvien"].Value.ToString();
            txtEmail.Text = datagridtaikhoan.CurrentRow.Cells["Email"].Value.ToString();
            mskSodienthoai.Text = datagridtaikhoan.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            txtMatkhau.Text = datagridtaikhoan.CurrentRow.Cells["MatKhau"].Value.ToString();
            txtLuong.Text = datagridtaikhoan.CurrentRow.Cells["LuongCoBan"].Value.ToString();
            cboMachucvu.SelectedValue = datagridtaikhoan.CurrentRow.Cells["MaChucVu"].Value.ToString();
            cboMaque.SelectedValue = datagridtaikhoan.CurrentRow.Cells["MaQue"].Value.ToString();

            // Gán giới tính checkbox
            string gioitinh = datagridtaikhoan.CurrentRow.Cells["GioiTinh"].Value.ToString();
            if (gioitinh == "M")
            {
                chkNam.Checked = true;
                chkNu.Checked = false;
            }
            else 
            {
                chkNam.Checked = false;
                chkNu.Checked = true;
            }


            txtEmail.Text = datagridtaikhoan.CurrentRow.Cells["Email"].Value.ToString();
            mskSodienthoai.Text = datagridtaikhoan.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            txtMatkhau.Text = datagridtaikhoan.CurrentRow.Cells["MatKhau"].Value.ToString();
            mskNgaysinh.Text = Convert.ToDateTime(datagridtaikhoan.CurrentRow.Cells["NgaySinh"].Value).ToString("yyyy-MM-dd");
            ibtnSua.Enabled = true;
            ibtnXoa.Enabled = true;
        }
        private void cboMachucvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMachucvu.SelectedIndex != -1) // Kiểm tra xem có chức vụ nào được chọn không
            {
                string selectedMaChucVu = cboMachucvu.SelectedValue?.ToString();
                if (!string.IsNullOrEmpty(selectedMaChucVu))
                {
                    // Truy vấn lấy lương cơ bản từ bảng ChucVu
                    string sql = "SELECT LuongCoBan FROM ChucVu WHERE MaChucVu = N'" + selectedMaChucVu + "'";
                    DataTable dtLuong = Function.GetDataToTable(sql);

                    if (dtLuong.Rows.Count > 0)
                    {
                        // Hiển thị lương cơ bản trong txtLuong
                        txtLuong.Text = dtLuong.Rows[0]["LuongCoBan"].ToString();
                    }
                    else
                    {
                        txtLuong.Text = "0"; // Nếu không tìm thấy, đặt mặc định là 0
                    }
                }
                else
                {
                    txtLuong.Text = "0"; // Nếu SelectedValue null hoặc empty
                }
            }
            else
            {
                txtLuong.Text = "0"; // Nếu không chọn chức vụ, đặt lương về 0
            }
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
            txtTennhanvien.Enabled = true;
            txtEmail.Enabled = true;
            mskSodienthoai.Enabled = true;
            mskNgaysinh.Enabled = true;
            cboMachucvu.Enabled = true;
            cboMaque.Enabled = true;
            txtMatkhau.Enabled = true;
            chkNam.Checked = false;
            chkNu.Checked = false;
            txtManhanvien.Focus();
        }

        private void ibtnSua_Click(object sender, EventArgs e)
        {
            string sql;

            if (txtManhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                return;
            }
            if (txtTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (cboMachucvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMachucvu.Focus();
                return;
            }
            if (mskNgaysinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (!mskSodienthoai.MaskFull)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskSodienthoai.Focus();
                return;
            }
            if (txtMatkhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatkhau.Focus();
                return;
            }
            // Lấy giới tính
            string gioitinh = "";
            if (chkNam.Checked) gioitinh = "M";
            else if (chkNu.Checked) gioitinh = "F";
            // Câu lệnh cập nhật
            sql = "UPDATE Nhanvien SET " + "TenNhanvien = N'" + txtTennhanvien.Text.Trim() + "', " +"GioiTinh = N'" + gioitinh + "', " +"NgaySinh = CONVERT(DATE, '" + mskNgaysinh.Text.Trim() + "', 120), " +
                   "Email = N'" + txtEmail.Text.Trim() + "', " +"SoDienThoai = N'" + mskSodienthoai.Text.Trim() + "', " +"MaChucVu = N'" + cboMachucvu.SelectedValue.ToString().Trim() + "', " +"MaQue = N'" + cboMaque.SelectedValue.ToString().Trim() + "', " +
                   "MatKhau = N'" + txtMatkhau.Text.Trim() + "' " +"WHERE MaNhanVien = N'" + txtManhanvien.Text.Trim() + "'";
            Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            ibtnLuu.Enabled = false;
            txtManhanvien.Enabled = false;
            MessageBox.Show("Đã sửa thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ibtnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtManhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                return;
            }
            if (txtTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (cboMachucvu.SelectedValue == null || cboMachucvu.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMachucvu.Focus();
                return;
            }
            if (mskNgaysinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (mskSodienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskSodienthoai.Focus();
                return;
            }
            if (txtMatkhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatkhau.Focus();
                return;
            }
            if (!chkNam.Checked && !chkNu.Checked)
            {
                MessageBox.Show("Bạn phải chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMaque.SelectedValue == null || cboMaque.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn quê quán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaque.Focus();
                return;
            }

            sql = "SELECT MaNhanVien FROM NhanVien WHERE MaNhanVien=N'" + txtManhanvien.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                return;
            }

            string gioitinh = "";
            if (chkNam.Checked) gioitinh = "M";
            else if (chkNu.Checked) gioitinh = "F";

            sql = "INSERT INTO NhanVien (MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, Email, SoDienThoai, MaChucVu, MaQue, MatKhau, NgayTao) " +"VALUES (N'" + txtManhanvien.Text.Trim() + "', N'" + txtTennhanvien.Text.Trim() + "', N'" + gioitinh + "', " +
                   "CONVERT(DATE, '" + mskNgaysinh.Text.Trim() + "', 120), N'" + txtEmail.Text.Trim() + "', N'" + mskSodienthoai.Text.Trim() + "', " +"N'" + cboMachucvu.SelectedValue.ToString().Trim() + "', N'" + cboMaque.SelectedValue.ToString().Trim() + "', N'" + txtMatkhau.Text.Trim() + "', " +
                    "CONVERT(DATE, '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 120))";
            try
            {
                Function.RunSql(sql);
                Load_DataGridView();
                Load_ComboBoxes();
                ResetValues();
                ibtnXoa.Enabled = true;
                ibtnThem.Enabled = true;
                ibtnSua.Enabled = true;
                ibtnLuu.Enabled = false;
                txtManhanvien.Enabled = false;
                MessageBox.Show("Đã thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtnXoa_Click(object sender, EventArgs e)
        {
            if (txtManhanvien.Text == "")
            {
                MessageBox.Show("Bạn phải chọn nhân viên để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM Nhanvien WHERE Manhanvien='" + txtManhanvien.Text + "'";
                Function.RunSql(sql);
                Load_DataGridView();
                ResetValues();
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
        }

        private void chkNam_CheckedChanged(object sender, EventArgs e)
        {
          
            if (chkNam.Checked)
                chkNu.Checked = false;
        }

        private void chkNu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNu.Checked)
                chkNam.Checked = false;
        }

        private void txtManhanvien_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


