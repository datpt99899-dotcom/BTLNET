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
    public partial class frm_quanlyban : Form
    {
        public frm_quanlyban()
        {
            InitializeComponent();
        }
        DataTable tblban;
        private void frm_quanlyban_Load(object sender, EventArgs e)
        {
            Function.Connect();
            txtMaban.Enabled = false;
            ibtnLuu.Enabled = false;
            Load_DataGridView();
            cboTinhtrang.Items.Clear();
            cboTinhtrang.Items.Add("1");
            cboTinhtrang.Items.Add("0");
            datagridBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql = "SELECT MaBan, SoLuongGhe, " +
             "CASE WHEN TinhTrang = 0 THEN N'Trống' " +
             "WHEN TinhTrang = 1 THEN N'Đang sử dụng' " +
             "ELSE N'Không xác định' END AS TinhTrang " +
             "FROM Ban";
            tblban = Function.GetDataToTable(sql);
            datagridBan.DataSource = tblban;
            datagridBan.Columns[0].HeaderText = "Mã bàn";
            datagridBan.Columns[1].HeaderText = "Số lượng ghế";
            datagridBan.Columns[2].HeaderText = "Tình trạng";
            datagridBan.Columns[0].Width = 100;
            datagridBan.Columns[1].Width = 150;
            datagridBan.Columns[2].Width = 150;
            datagridBan.AllowUserToAddRows = false;
            datagridBan.EditMode = DataGridViewEditMode.EditProgrammatically;
            DoiMauTrangThaiBan();
        }
        private void datagridBan_Click(object sender, EventArgs e)
        {
            if (ibtnLuu.Enabled == true)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaban.Focus();
                return;
            }

            if (datagridBan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Gán dữ liệu từ dòng đang chọn vào các ô nhập
            txtMaban.Text = datagridBan.CurrentRow.Cells["Maban"].Value.ToString();
            txtSoluongghe.Text = datagridBan.CurrentRow.Cells["Soluongghe"].Value.ToString();
            cboTinhtrang.Text = datagridBan.CurrentRow.Cells["Tinhtrang"].Value.ToString();

            // Cho phép sửa, xóa; không cho thêm hay lưu
            ibtnSua.Enabled = true;
            ibtnXoa.Enabled = true;
            ibtnThem.Enabled = false;
            ibtnLuu.Enabled = false;

            // Không cho sửa mã bàn
            txtMaban.Enabled = false;
        }
        private void DoiMauTrangThaiBan()
        {
            foreach (DataGridViewRow row in datagridBan.Rows)
            {
                if (row.Cells["Tinhtrang"].Value != null)
                {
                    string tinhtrang = row.Cells["Tinhtrang"].Value.ToString();
                    if (tinhtrang == "1")
                        row.DefaultCellStyle.BackColor = Color.LightPink; // Đang dùng
                    else
                        row.DefaultCellStyle.BackColor = Color.LightGreen; // Trống
                }
            }
        }
       
        
        private void ResetValues()
        {
            txtMaban.Text = "";
            txtSoluongghe.Text = "";
            cboTinhtrang.Text = "";
            ibtnThem.Enabled = true;
            ibtnXoa.Enabled = true;
            txtMaban.Focus();
        }

        private void ibtnThem_Click(object sender, EventArgs e)
        {
            ibtnSua.Enabled = false;
            ibtnXoa.Enabled = false;
            ibtnLuu.Enabled = true;
            ibtnThem.Enabled = false;
            ResetValues();
            txtMaban.Enabled = true;
            txtSoluongghe.Enabled = true;
            txtSoluongghe.Focus();
            cboTinhtrang.Enabled = true;
            cboTinhtrang.Focus();
        }

        private void ibtnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblban.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaban.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!int.TryParse(txtSoluongghe.Text.Trim(), out int soluongghe))
            {
                MessageBox.Show("Số lượng bàn phải là số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluongghe.Focus();
                return;
            }
            if (cboTinhtrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTinhtrang.Focus();
                return;
            }
            sql = "UPDATE Ban SET Soluongghe = " + soluongghe + ", Tinhtrang = N'" + cboTinhtrang.Text.Trim() + "' WHERE Maban = N'" + txtMaban.Text.Trim() + "'";
            Function.RunSql(sql);
            Load_DataGridView();
            ResetValues();
        }

        private void ibtnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblban.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaban.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Ban WHERE Maban = N'" + txtMaban.Text.Trim() + "'";
                Function.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }
        private void ibtnLuu_Click(object sender, EventArgs e)
        {
            string sql;

            if (txtMaban.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaban.Focus();
                return;
            }
            if (!int.TryParse(txtSoluongghe.Text, out int soluong))
            {
                MessageBox.Show("Số lượng bàn phải là số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluongghe.Focus();
                return;
            }
            if (cboTinhtrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTinhtrang.Focus();
                return;
            }
            sql = "SELECT Maban FROM Ban WHERE Maban=N'" + txtMaban.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã bàn này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaban.Focus();
                txtMaban.Text = "";
                return;
            }
            sql = "INSERT INTO Ban(Maban, Soluongghe, Tinhtrang) VALUES(N'" + txtMaban.Text.Trim() + "', " + soluong + ", N'" + cboTinhtrang.Text.Trim() + "')";
            Function.RunSql(sql);
            Load_DataGridView();  // Nạp lại bảng
            ResetValues();        // Đặt lại các textbox
            ibtnXoa.Enabled = true;
            ibtnThem.Enabled = true;
            ibtnSua.Enabled = true;
            ibtnLuu.Enabled = false;
            txtMaban.Enabled = false;
        }

        private void ibtnLamoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            ibtnThem.Enabled = true;
            ibtnSua.Enabled = false;
            ibtnXoa.Enabled = false;
            ibtnLuu.Enabled = false;
            txtMaban.Enabled = false;
        }

        private void datagridBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

