using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmDanhmucsanpham : Form
    {
        private DataTable dtLoai;
        private bool isAdding;

        public frmDanhmucsanpham()
        {
            InitializeComponent();
        }

        private void frmDanhmucsanpham_Load(object sender, EventArgs e)
        {
            LoadCategoryGrid();
            ResetValues();
        }

        private void LoadCategoryGrid(string keyword = "")
        {
            string sql = "SELECT MaLoai, TenLoai FROM LoaiSanPham WHERE (@kw = '' OR TenLoai LIKE @likeKw) ORDER BY TenLoai";
            dtLoai = Function.GetDataToTable(sql,
                new SqlParameter("@kw", keyword),
                new SqlParameter("@likeKw", "%" + keyword + "%"));
            dataGridViewDanhmuc.DataSource = dtLoai;
            if (dataGridViewDanhmuc.Columns.Count > 0)
            {
                dataGridViewDanhmuc.Columns[0].HeaderText = "Mã loại";
                dataGridViewDanhmuc.Columns[1].HeaderText = "Tên loại sản phẩm";
            }
        }

        private void LoadProductGridByCategory(string maLoai)
        {
            string sql = @"SELECT s.MaSanPham, s.TenSanPham, th.TenThuongHieu, s.GiaNhap, s.GiaBan, s.SoLuongTon
                           FROM SanPham s
                           INNER JOIN ThuongHieu th ON s.MaThuongHieu = th.MaThuongHieu
                           WHERE s.MaLoai = @MaLoai";
            DataTable dt = Function.GetDataToTable(sql, new SqlParameter("@MaLoai", maLoai));
            dataGridViewSanpham.DataSource = dt;
        }

        private void ResetValues()
        {
            txtMadanhmuc.Text = "";
            txtTendanhmuc.Text = "";
            txtTimkiem.Text = "";
            txtMasanpham.Text = "";
            txtTensanpham.Text = "";
            txtGianhap.Text = "";
            txtGiaban.Text = "";
            btnLuu.Enabled = false;
        }

        private void dataGridViewDanhmuc_Click(object sender, EventArgs e)
        {
            if (dataGridViewDanhmuc.CurrentRow == null) return;
            txtMadanhmuc.Text = Convert.ToString(dataGridViewDanhmuc.CurrentRow.Cells["MaLoai"].Value);
            txtTendanhmuc.Text = Convert.ToString(dataGridViewDanhmuc.CurrentRow.Cells["TenLoai"].Value);
            LoadProductGridByCategory(txtMadanhmuc.Text);
        }

        private void dataGridViewSanpham_Click(object sender, EventArgs e)
        {
            if (dataGridViewSanpham.CurrentRow == null) return;
            txtMasanpham.Text = Convert.ToString(dataGridViewSanpham.CurrentRow.Cells["MaSanPham"].Value);
            txtTensanpham.Text = Convert.ToString(dataGridViewSanpham.CurrentRow.Cells["TenSanPham"].Value);
            txtGianhap.Text = Convert.ToString(dataGridViewSanpham.CurrentRow.Cells["GiaNhap"].Value);
            txtGiaban.Text = Convert.ToString(dataGridViewSanpham.CurrentRow.Cells["GiaBan"].Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txtMadanhmuc.Text = "L" + DateTime.Now.ToString("yyMMddHHmmss");
            txtTendanhmuc.Text = "";
            btnLuu.Enabled = true;
            txtTendanhmuc.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMadanhmuc.Text)) return;
            isAdding = false;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMadanhmuc.Text) || string.IsNullOrWhiteSpace(txtTendanhmuc.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ mã và tên loại.");
                return;
            }
            if (isAdding)
            {
                Function.RunSql("INSERT INTO LoaiSanPham(MaLoai, TenLoai) VALUES(@MaLoai, @TenLoai)",
                    new SqlParameter("@MaLoai", txtMadanhmuc.Text.Trim()),
                    new SqlParameter("@TenLoai", txtTendanhmuc.Text.Trim()));
            }
            else
            {
                Function.RunSql("UPDATE LoaiSanPham SET TenLoai=@TenLoai WHERE MaLoai=@MaLoai",
                    new SqlParameter("@MaLoai", txtMadanhmuc.Text.Trim()),
                    new SqlParameter("@TenLoai", txtTendanhmuc.Text.Trim()));
            }
            btnLuu.Enabled = false;
            LoadCategoryGrid(txtTimkiem.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMadanhmuc.Text)) return;
            if (MessageBox.Show("Xóa loại sản phẩm đã chọn?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            Function.RunSqlDel("DELETE FROM LoaiSanPham WHERE MaLoai = N'" + txtMadanhmuc.Text.Trim() + "'");
            LoadCategoryGrid(txtTimkiem.Text.Trim());
            ResetValues();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            isAdding = false;
            ResetValues();
            LoadCategoryGrid();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadCategoryGrid(txtTimkiem.Text.Trim());
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
