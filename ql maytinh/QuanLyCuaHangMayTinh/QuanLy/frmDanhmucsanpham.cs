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
    public partial class frmDanhmucsanpham : Form
    {
        DataTable Loai;
        DataTable SanPham;
        public frmDanhmucsanpham()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTim.Enabled = false;
            ResetValues();
            txtMadanhmuc.Enabled = true;
            txtTendanhmuc.Enabled = true;
            txtMadanhmuc.Focus();
        }

        private void frmDanhmucsanpham_Load(object sender, EventArgs e)
        {
            // Khi form load thì sẽ gọi hàm Connect để kết nối với CSDL
            QuanLyCuaHangMayTinh.Function.Connect();
            txtMadanhmuc.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            // Gọi hàm load dữ liệu vào datagridview
            Load_DataGridViewDanhmuc();

            ResetValues();
            ResetValues1();

            // Ẩn
            txtMasanpham.Enabled = false;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
        }
        private void Load_DataGridViewDanhmuc()
        {
            string sql;
            sql = "SELECT MaLoai, TenLoai from Loai ";
            Loai = QuanLyCuaHangMayTinh.Function.GetDataToTable(sql);
            //Gán dữ liệu từ bảng vào datagridview
            dataGridViewDanhmuc.DataSource = Loai;

            //đặt tên cho các cột
            dataGridViewDanhmuc.Columns[0].HeaderText = "Mã danh mục";
            dataGridViewDanhmuc.Columns[1].HeaderText = "Tên danh mục";
            dataGridViewDanhmuc.Columns[0].Width = 150;
            dataGridViewDanhmuc.Columns[1].Width = 150;

            // In đậm tên các cột
            dataGridViewDanhmuc.ColumnHeadersDefaultCellStyle.Font = new Font(
            dataGridViewDanhmuc.Font.FontFamily,
            dataGridViewDanhmuc.Font.Size,
                FontStyle.Bold
            );

            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dataGridViewDanhmuc.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dataGridViewDanhmuc.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridViewDanhmuc_Click(object sender, EventArgs e)
        {
        
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMasanpham.Focus();
                return;
            }
            if (Loai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Lấy dòng hiện tại
            txtMadanhmuc.Text = dataGridViewDanhmuc.CurrentRow.Cells["MaLoai"].Value.ToString();
            txtTendanhmuc.Text = dataGridViewDanhmuc.CurrentRow.Cells["TenLoai"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;

            Load_DataGridViewSanpham();
        }
        private void Load_DataGridViewSanpham()
        {
            if (dataGridViewDanhmuc.CurrentRow == null)
            {
                // Không có dòng nào được chọn, có thể reset hoặc xóa dữ liệu
                dataGridViewSanpham.DataSource = null;
                return;
            }

            string maLoai = dataGridViewDanhmuc.CurrentRow.Cells["MaLoai"].Value.ToString();

            string sql = $"SELECT s.MaSanPham, s.TenSanPham, s.GiaNhap, s.GiaBan " +
             $"FROM SanPham s JOIN Loai l ON s.MaLoai = l.MaLoai " +
             $"WHERE s.MaLoai = N'{maLoai}'";

            SanPham = QuanLyCuaHangMayTinh.Function.GetDataToTable(sql);
            dataGridViewSanpham.DataSource = SanPham;

            // Đặt tên cho các cột
            dataGridViewSanpham.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewSanpham.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridViewSanpham.Columns[2].HeaderText = "Giá nhập";
            dataGridViewSanpham.Columns[3].HeaderText = "Giá bán";
            dataGridViewSanpham.Columns[0].Width = 150;
            dataGridViewSanpham.Columns[1].Width = 150;
            dataGridViewSanpham.Columns[2].Width = 150;
            dataGridViewSanpham.Columns[3].Width = 150;


            // In đậm tên các cột
            dataGridViewSanpham.ColumnHeadersDefaultCellStyle.Font = new Font(
            dataGridViewSanpham.Font.FontFamily,
            dataGridViewSanpham.Font.Size,
                FontStyle.Bold
            );

            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dataGridViewSanpham.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dataGridViewSanpham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridViewSanpham_Click(object sender, EventArgs e)
        {

            // Lấy mã sản phẩm và mã sản phẩm từ dòng hiện tại
            if (dataGridViewSanpham.CurrentRow != null)
            {
                txtMasanpham.Text = dataGridViewSanpham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                txtTensanpham.Text = dataGridViewSanpham.CurrentRow.Cells["TenSanPham"].Value.ToString();
                txtGianhap.Text = dataGridViewSanpham.CurrentRow.Cells["GiaNhap"].Value.ToString();
                txtGiaban.Text = dataGridViewSanpham.CurrentRow.Cells["GiaBan"].Value.ToString();
                txtMasanpham.Enabled = false;
                txtTensanpham.Enabled = false;
                txtGianhap.Enabled = false;
                txtGiaban.Enabled = false;
            }
        }
        public void ResetValues()
        {
            txtMadanhmuc.Text = "";
            txtTendanhmuc.Text = "";
        }
        public void ResetValues1()
        {
            txtMasanpham.Text = "";
            txtTensanpham.Text = "";
            txtGianhap.Text = "";
            txtGiaban.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;

            if (Loai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtMadanhmuc.Text == "")
            {
                MessageBox.Show("Bạn phải chọn danh mục để sửa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtTendanhmuc.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên danh mục", "Thông báo", MessageBoxButtons.OK);
                txtTensanpham.Focus();
                return;
            }

            sql = "UPDATE Loai SET TenLoai = N'" + txtTendanhmuc.Text.Trim() +
            "' WHERE MaLoai = N'" + txtMadanhmuc.Text.Trim() + "'";

            //hỏi ý kiến người dùng có muốn sửa không
            if (MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuanLyCuaHangMayTinh.Function.RunSql(sql);
                Load_DataGridViewDanhmuc();
                ResetValues();
                btnBoqua.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            string sql1 = "";
            
            if (dataGridViewDanhmuc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtMadanhmuc.Text == "")
            {
                MessageBox.Show("Bạn phải chọn danh mục để xóa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                sql1 = "UPDATE SanPham SET MaLoai = null WHERE MaLoai = N'" + txtMadanhmuc.Text + "'";
                sql = "DELETE FROM Loai WHERE MaLoai = N'" + txtMadanhmuc.Text + "'";
                //QuanLyCuaHangMayTinh.Function.RunSqlDel(sql3);
                QuanLyCuaHangMayTinh.Function.RunSql(sql1);
                QuanLyCuaHangMayTinh.Function.RunSqlDel(sql);
                Load_DataGridViewDanhmuc();
                Load_DataGridViewSanpham();
                ResetValues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMadanhmuc.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã danh mục", "Thông báo", MessageBoxButtons.OK);
                txtMasanpham.Focus();
                return;
            }
            if (txtTendanhmuc.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên danh mục", "Thông báo", MessageBoxButtons.OK);
                txtTensanpham.Focus();
                return;
            }

            //check khóa chính mã hàng
            sql = "SELECT MaLoai FROM Loai WHERE MaLoai=N'" + txtMadanhmuc.Text.Trim() + "'";

            if (QuanLyCuaHangMayTinh.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasanpham.Focus();
                txtMasanpham.Text = "";
                return;
            }
            //Thêm mới
            sql = "INSERT INTO Loai (MaLoai, TenLoai) " +
                    "VALUES (N'" + txtMadanhmuc.Text + "', N'" + txtTendanhmuc.Text + "')";

            QuanLyCuaHangMayTinh.Function.RunSql(sql);
            Load_DataGridViewDanhmuc();
            ResetValues();

            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMadanhmuc.Enabled = false;
            Load_DataGridViewDanhmuc();
            Load_DataGridViewSanpham();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //code nút tìm kiếm sản phẩm
            string sql;
            if (txtTimkiem.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK);
                txtTimkiem.Focus();
                return;
            }
            sql = "SELECT MaLoai, TenLoai FROM Loai WHERE TenLoai like N'%" + txtTimkiem.Text + "%'";
            Loai = QuanLyCuaHangMayTinh.Function.GetDataToTable(sql);
            //Gán dữ liệu từ bảng vào datagridview
            dataGridViewDanhmuc.DataSource = Loai;
            //xóa chữ ở ô txtTim sau khi tìm xong
            txtTimkiem.Text = "";
        }
    }
}
