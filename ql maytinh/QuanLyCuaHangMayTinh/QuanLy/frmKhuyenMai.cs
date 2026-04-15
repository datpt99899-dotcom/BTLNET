using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.QuanLy
{
    public partial class frmKhuyenMai: Form
    {
        DataTable tblKM;
        public frmKhuyenMai()
        {
            InitializeComponent();
        }

        private void frmKhuyenMai_Load(object sender, EventArgs e)
        {
            Function.Connect();
            txtMaKM.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = false;
            Load_DataGridView();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM KhuyenMai";
            tblKM = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblKM;
            DataGridView.Columns[0].HeaderText = "Mã khuyến mãi";
            DataGridView.Columns[1].HeaderText = "Mức khuyến mãi";
            DataGridView.Columns[2].HeaderText = "Ngày bắt đầu";
            DataGridView.Columns[3].HeaderText = "Ngày kết thúc";
            DataGridView.Columns[4].HeaderText = "Điều kiện";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 100;
            DataGridView.Columns[4].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaKM.Text = "";
            txtMucKM.Text = "";
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now;
            txtDieuKien.Text = "";
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKM.Focus();
                return;
            }
            if (tblKM.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKM.Text = DataGridView.CurrentRow.Cells["MaKhuyenMai"].Value.ToString();
            txtMucKM.Text = DataGridView.CurrentRow.Cells["MucKhuyenMai"].Value.ToString();
            dtpNgayBD.Value = Convert.ToDateTime(DataGridView.CurrentRow.Cells["NgayBatDau"].Value);
            dtpNgayKT.Value = Convert.ToDateTime(DataGridView.CurrentRow.Cells["NgayKetThuc"].Value);
            txtDieuKien.Text = DataGridView.CurrentRow.Cells["DieuKien"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLamMoi.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLamMoi.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaKM.Enabled = true;
            txtMaKM.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKM.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKM.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE KhuyenMai WHERE MaKhuyenMai = '" + txtMaKM.Text.Trim() + "'";
                Function.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKM.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKM.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKM.Focus();
                return;
            }
            if (txtMucKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mức khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMucKM.Focus();
                return;
            }
            if (dtpNgayBD.Value > dtpNgayKT.Value)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayBD.Focus();
                return;
            }
            if (txtDieuKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập điều kiện khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDieuKien.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "UPDATE KhuyenMai SET MucKhuyenMai = '" + txtMucKM.Text.Trim() + "', NgayBatDau = '" + dtpNgayBD.Value.ToString("yyyy-MM-dd") + "', NgayKetThuc = '" + dtpNgayKT.Value.ToString("yyyy-MM-dd") + "', DieuKien = N'" + txtDieuKien.Text.Trim() + "' WHERE MaKhuyenMai = '" + txtMaKM.Text.Trim() + "'";
                Function.RunSql(sql);
                Load_DataGridView();
                ResetValues();
                btnLamMoi.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKM.Focus();
                return;
            }
            if (txtMucKM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mức khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMucKM.Focus();
                return;
            }
            if (dtpNgayBD.Value > dtpNgayKT.Value)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayBD.Focus();
                return;
            }
            if (txtDieuKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điều kiện khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDieuKien.Focus();
                return;
            }
            // Kiểm tra mã khuyến mãi đã tồn tại chưa
            sql = "SELECT MaKhuyenMai FROM KhuyenMai WHERE MaKhuyenMai=N'" + txtMaKM.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã khuyến mãi này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKM.Focus();
                txtMaKM.Text = "";
                return;
            }
            sql = "INSERT INTO KhuyenMai (MaKhuyenMai, MucKhuyenMai, NgayBatDau, NgayKetThuc, DieuKien) VALUES ('" + txtMaKM.Text.Trim() + "', '" + txtMucKM.Text.Trim() + "', '" + dtpNgayBD.Value.ToString("yyyy-MM-dd") + "', '" + dtpNgayKT.Value.ToString("yyyy-MM-dd") + "', N'" + txtDieuKien.Text.Trim() + "')";
            Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            txtMaKM.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaKM.Text == "") && (txtMucKM.Text == "") && (txtDieuKien.Text == "")
                && !dtpNgayBD.Checked && !dtpNgayKT.Checked)
            {
                MessageBox.Show("Bạn phải nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM KhuyenMai WHERE 1=1";

            if (txtMaKM.Text != "")
                sql += " AND MaKhuyenMai LIKE N'%" + txtMaKM.Text + "%'";
            if (txtMucKM.Text != "")
                sql += " AND MucKhuyenMai LIKE N'%" + txtMucKM.Text + "%'";
            if (txtDieuKien.Text != "")
                sql += " AND DieuKien LIKE N'%" + txtDieuKien.Text + "%'";

            // Lọc theo khoảng ngày nếu đã được chọn
            if (dtpNgayBD.Checked && dtpNgayKT.Checked)
            {
                string ngayBD = dtpNgayBD.Value.ToString("yyyy-MM-dd");
                string ngayKT = dtpNgayKT.Value.ToString("yyyy-MM-dd");
                sql += $" AND NgayBatDau >= '{ngayBD}' AND NgayKetThuc <= '{ngayKT}'";
            }

            tblKM = Function.GetDataToTable(sql);

            if (tblKM.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblKM.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DataGridView.DataSource = tblKM;
            ResetValues();
        }

    }
}
