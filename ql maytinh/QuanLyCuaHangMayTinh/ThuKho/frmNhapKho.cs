using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmNhapKho: Form
    {
        DataTable tblHDN;
        DataTable tblCTHDN;
        public frmNhapKho()
        {
            InitializeComponent();
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            txtTongTien.Enabled = false;
            cboNguyenLieu.Enabled = false;
            txtMaHDN.Enabled = false;
            btnThem2.Enabled = false;
            btnXoa2.Enabled = false;
            btnSua2.Enabled = false;
            btnTimKiem2.Enabled = false;
            btnLuu1.Enabled = false;
            btnLuu2.Enabled = false;
            btnLamMoi1.Enabled = false;
            btnLamMoi2.Enabled = false;
            Load_DataGridView1();
            Function.FillCombo("SELECT MaNhanVien, TenNhanVien FROM NhanVien", cboNVNhap, "MaNhanVien", "TenNhanVien");
            cboNVNhap.SelectedIndex = -1;
            Function.FillCombo("SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap", cboNhaCungCap, "MaNhaCungCap", "TenNhaCungCap");
            cboNhaCungCap.SelectedIndex = -1;
            Function.FillCombo("SELECT MaNguyenLieu, TenNguyenLieu FROM NguyenLieu", cboNguyenLieu, "MaNguyenLieu", "TenNguyenLieu");
            cboNguyenLieu.SelectedIndex = -1;
            ResetValues1();
            ResetValues2();
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void Load_DataGridView1()
        {
            string sql;
            sql = "SELECT hd.MaHoaDonNhap, nv.MaNhanVien, nv.TenNhanVien AS TenNV, ncc.MaNhaCungCap, ncc.TenNhaCungCap, hd.NgayNhap, hd.TongTien\r\nFROM HoaDonNhap hd\r\nJOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien\r\nJOIN NhaCungCap ncc ON hd.MaNhaCungCap = ncc.MaNhaCungCap\r\n";
            tblHDN = Function.GetDataToTable(sql);
            DataGridView1.DataSource = tblHDN;
            DataGridView1.Columns["MaNhanVien"].Visible = false;
            DataGridView1.Columns["MaNhaCungCap"].Visible = false;
            DataGridView1.Columns[0].HeaderText = "Mã hóa đơn nhập";
            DataGridView1.Columns[2].HeaderText = "Nhân viên nhập";
            DataGridView1.Columns[4].HeaderText = "Nhà cung cấp";
            DataGridView1.Columns[5].HeaderText = "Ngày nhập";
            DataGridView1.Columns[6].HeaderText = "Tổng tiền";
            DataGridView1.Columns[0].Width = 100;
            DataGridView1.Columns[2].Width = 120;
            DataGridView1.Columns[4].Width = 50;
            DataGridView1.Columns[5].Width = 50;
            DataGridView1.Columns[6].Width = 50;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_DataGridView2(string ma)
        {
            string sql;
            sql = "select b.MaNguyenLieu, b.TenNguyenLieu, a.SoLuong, a.DonGia, a.ThanhTien from ChiTietHoaDonNhap a\r\njoin NguyenLieu b on a.MaNguyenLieu = b.MaNguyenLieu WHERE a.MaHoaDonNhap = N'" + ma+"'";
            tblCTHDN = Function.GetDataToTable(sql);
            DataGridView2.DataSource = tblCTHDN;
            DataGridView2.Columns["MaNguyenLieu"].Visible = false;
            DataGridView2.Columns[1].HeaderText = "Tên sản phẩm";
            DataGridView2.Columns[2].HeaderText = "Số lượng";
            DataGridView2.Columns[3].HeaderText = "Đơn giá";
            DataGridView2.Columns[4].HeaderText = "Thành tiền";
            DataGridView2.Columns[1].Width = 80;
            DataGridView2.Columns[2].Width = 80;
            DataGridView2.Columns[3].Width = 80;
            DataGridView2.Columns[4].Width = 80;
            DataGridView2.AllowUserToAddRows = false;
            DataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues1()
        {
            txtMaHDN.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
            txtTongTien.Text = "";
            cboNVNhap.Text = "";
            cboNhaCungCap.Text = "";
        }
        private void ResetValues2()
        {
            txtSLNhap.Text = "";
            txtDonGiaNhap.Text = "";
            cboNguyenLieu.Text = "";
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            string manv, mancc;
            if (btnThem1.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHDN.Focus();
                return;
            }
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHDN.Text = DataGridView1.CurrentRow.Cells["MaHoaDonNhap"].Value.ToString();
            manv = DataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            cboNVNhap.Text = Function.GetFieldValues("SELECT TenNhanVien FROM NhanVien WHERE MaNhanVien = N'" + manv + "'");
            mancc = DataGridView1.CurrentRow.Cells["MaNhaCungCap"].Value.ToString();
            cboNhaCungCap.Text = Function.GetFieldValues("SELECT TenNhaCungCap FROM NhaCungCap WHERE MaNhaCungCap = N'" + mancc + "'");
            dtpNgayNhap.Value = Convert.ToDateTime(DataGridView1.CurrentRow.Cells["NgayNhap"].Value);
            txtTongTien.Text = DataGridView1.CurrentRow.Cells["TongTien"].Value.ToString();
            btnSua1.Enabled = true;
            btnXoa1.Enabled = true;
            btnThem2.Enabled = true;
            btnTimKiem2.Enabled = true;
            btnXoa2.Enabled = true;
            btnSua2.Enabled = true;
            btnTimKiem2.Enabled = true;
            btnLamMoi1.Enabled = true;
            Load_DataGridView2(txtMaHDN.Text);
        }

        private void DataGridView2_Click(object sender, EventArgs e)
        {
            string manl;
            if (btnThem2.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHDN.Focus();
                return;
            }
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtSLNhap.Text = DataGridView2.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGiaNhap.Text = DataGridView2.CurrentRow.Cells["DonGia"].Value.ToString();
            manl = DataGridView2.CurrentRow.Cells["MaNguyenLieu"].Value.ToString();
            cboNguyenLieu.Text = Function.GetFieldValues("SELECT TenNguyenLieu FROM NguyenLieu WHERE MaNguyenLieu = N'" + manl + "'");
            btnSua2.Enabled = true;
            btnXoa2.Enabled = true;
            btnLamMoi2.Enabled = true;
        }

        private void btnThem1_Click(object sender, EventArgs e)
        {
            btnSua1.Enabled = false;
            btnXoa1.Enabled = false;
            btnLamMoi1.Enabled = true;
            btnLuu1.Enabled = true;
            btnThem1.Enabled = false;
            ResetValues1();
            txtMaHDN.Enabled = true;
            txtMaHDN.Focus();
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            string sql1, sql2;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHDN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Xóa chi tiết hóa đơn nhập
                sql1 = "DELETE ChiTietHoaDonNhap WHERE MaHoaDonNhap=N'" + txtMaHDN.Text + "'";
                Function.RunSqlDel(sql1);
                sql2 = "DELETE HoaDonNhap WHERE MaHoaDonNhap=N'" + txtMaHDN.Text + "'";
                Function.RunSqlDel(sql2);
                Load_DataGridView1();
                Load_DataGridView2(txtMaHDN.Text);
                ResetValues1();
            }
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHDN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboNVNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboNVNhap.Focus();
                return;
            }
            if (cboNhaCungCap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboNhaCungCap.Focus();
                return;
            }
            if (dtpNgayNhap.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày nhập không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayNhap.Focus();
                return;
            }
            sql = "UPDATE HoaDonNhap SET MaNhanVien=N'" + cboNVNhap.SelectedValue.ToString() +
                "',MaNhaCungCap=N'" + cboNhaCungCap.SelectedValue.ToString() +
                "',NgayNhap='" + dtpNgayNhap.Value.ToString("yyyy/MM/dd") +
                "' WHERE MaHDN=N'" + txtMaHDN.Text + "'";
            Function.RunSql(sql);
            Load_DataGridView1();
            ResetValues1();
            btnLamMoi1.Enabled = false;
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaHDN.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hoá đơn nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHDN.Focus();
                return;
            }
            if (cboNVNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNVNhap.Focus();
                return;
            }
            if (cboNhaCungCap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhaCungCap.Focus();
                return;
            }
            sql = "SELECT MaHoaDonNhap FROM HoaDonNhap WHERE MaHoaDonNhap=N'" + txtMaHDN.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã hoá đơn này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHDN.Focus();
                txtMaHDN.Text = "";
                return;
            }
            sql = "INSERT INTO HoaDonNhap(MaHoaDonNhap, MaNhanVien, MaNhaCungCap, NgayNhap) VALUES (N'" + txtMaHDN.Text.Trim() +
                "',N'" + cboNVNhap.SelectedValue.ToString() +
                "',N'" + cboNhaCungCap.SelectedValue.ToString() +
                "','" + dtpNgayNhap.Value.ToString("yyyy/MM/dd") + "')";
            Function.RunSql(sql);
            Load_DataGridView1();
            ResetValues1();
            btnXoa1.Enabled = true;
            btnThem1.Enabled = true;
            btnSua1.Enabled = true;
            btnLamMoi1.Enabled = false;
            btnLuu1.Enabled = false;
            txtMaHDN.Enabled = false;
        }

        private void btnTimKiem1_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDN.Text == "") &&
                (cboNVNhap.Text == "") &&
                (cboNhaCungCap.Text == "") &&
                (dtpNgayNhap.Checked == false) &&
                (txtTongTien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HoaDonNhap WHERE 1=1";
            if (txtMaHDN.Text != "")
                sql = sql + " AND MaHoaDonNhap LIKE N'%" + txtMaHDN.Text + "%'";
            if (cboNVNhap.Text != "")
                sql = sql + " AND MaNhanVien LIKE N'%" + cboNVNhap.SelectedValue.ToString() + "%'";
            if (cboNhaCungCap.Text != "")
                sql = sql + " AND MaNhaCungCap LIKE N'%" + cboNhaCungCap.SelectedValue.ToString() + "%'";
            if (dtpNgayNhap.Checked == true)
                sql = sql + " AND NgayNhap = '" + dtpNgayNhap.Value.ToString("yyyy/MM/dd") + "'";
            tblHDN = Function.GetDataToTable(sql);
            if (tblHDN.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblHDN.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView1.DataSource = tblHDN;
            ResetValues1();
        }

        private void btnLamMoi1_Click(object sender, EventArgs e)
        {
            ResetValues1();
            btnLamMoi1.Enabled = false;
            btnThem1.Enabled = true;
            btnXoa1.Enabled = true;
            btnSua1.Enabled = true;
            btnLuu1.Enabled = false;
            txtMaHDN.Enabled = false;
            btnThem2.Enabled = false;
            btnXoa2.Enabled = false;
            btnSua2.Enabled = false;
            btnTimKiem2.Enabled = false;
            btnLuu2.Enabled = false;
            btnLamMoi2.Enabled = false;
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {
            btnSua2.Enabled = false;
            btnXoa2.Enabled = false;
            btnLamMoi2.Enabled = true;
            btnLuu2.Enabled = true;
            btnThem2.Enabled = false;
            ResetValues2();
            cboNguyenLieu.Enabled = true;
            cboNguyenLieu.Focus();
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboNguyenLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "delete ChiTietHoaDonNhap where MaNguyenLieu = (select MaNguyenLieu from NguyenLieu where TenNguyenLieu =N'" + cboNguyenLieu.Text + "')";
                Function.RunSqlDel(sql);
                Load_DataGridView2(txtMaHDN.Text);
                ResetValues2();
            }
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboNguyenLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSLNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSLNhap.Focus();
                return;
            }
            if (txtDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaNhap.Focus();
                return;
            }
            sql = "UPDATE ChiTietHoaDonNhap SET SoLuong='" + txtSLNhap.Text.Trim().ToString() +
                "',DonGia='" + txtDonGiaNhap.Text.Trim().ToString() +
                "' WHERE MaNguyenLieu=N'" + cboNguyenLieu.SelectedValue.ToString() + "'";
            Function.RunSql(sql);
            Load_DataGridView2(txtMaHDN.Text);
            ResetValues2();
            btnLamMoi2.Enabled = false;
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboNguyenLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNguyenLieu.Focus();
                return;
            }
            if (txtSLNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSLNhap.Focus();
                return;
            }
            if (txtDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaNhap.Focus();
                return;
            }
            sql = "SELECT MaNguyenLieu FROM ChiTietHoaDonNhap WHERE MaHoaDonNhap=N'" + txtMaHDN.Text.Trim() + "' AND MaNguyenLieu=(select MaNguyenLieu from NguyenLieu where TenNguyenLieu =N'" + cboNguyenLieu.SelectedValue.ToString() + "')";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Sản phẩm này đã có rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNguyenLieu.Focus();
                cboNguyenLieu.SelectedIndex = -1;
                return;
            }
            sql = "INSERT INTO ChiTietHoaDonNhap(MaHoaDonNhap, MaNguyenLieu, SoLuong, DonGia) VALUES (N'" + txtMaHDN.Text.Trim() +
                "',N'" + cboNguyenLieu.SelectedValue.ToString() +
                "','" + txtSLNhap.Text.Trim() +
                "','" + txtDonGiaNhap.Text.Trim() + "')";
            Function.RunSql(sql);
            Load_DataGridView1();
            Load_DataGridView2(txtMaHDN.Text);
            ResetValues2();
            btnXoa2.Enabled = true;
            btnThem2.Enabled = true;
            btnSua2.Enabled = true;
            btnLamMoi2.Enabled = false;
            btnLuu2.Enabled = false;
            txtMaHDN.Enabled = false;
        }

        private void btnTimKiem2_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboNguyenLieu.SelectedIndex == -1) && (txtSLNhap.Text == "") &&
                (txtDonGiaNhap.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM ChiTietHoaDonNhap WHERE 1=1";
            if (cboNguyenLieu.Text != "")
                sql = sql + " AND MaNguyenLieu Like N'%" + cboNguyenLieu.SelectedValue.ToString() + "%'";
            if (txtSLNhap.Text != "")
                sql = sql + " AND SoLuong Like N'%" + txtSLNhap.Text + "%'";
            if (txtDonGiaNhap.Text != "")
                sql = sql + " AND DonGia Like N'%" + txtDonGiaNhap.Text + "%'";
            tblCTHDN = Function.GetDataToTable(sql);
            if (tblCTHDN.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblCTHDN.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView2.DataSource = tblCTHDN;
            ResetValues2();
        }

        private void btnLamMoi2_Click(object sender, EventArgs e)
        {
            ResetValues2();
            btnLamMoi2.Enabled = false;
            btnThem2.Enabled = true;
            btnXoa2.Enabled = true;
            btnSua2.Enabled = true;
            btnLuu2.Enabled = false;
            cboNguyenLieu.Enabled = false;
        }

        private void txtSLNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b') // \b = Backspace
                e.Handled = true;

            if ((e.KeyChar == '.' && tb.Text.Contains(".")))
                e.Handled = true;
        }

        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b') // \b = Backspace
                e.Handled = true;

            if ((e.KeyChar == '.' && tb.Text.Contains(".")))
                e.Handled = true;
        }
    }
}
