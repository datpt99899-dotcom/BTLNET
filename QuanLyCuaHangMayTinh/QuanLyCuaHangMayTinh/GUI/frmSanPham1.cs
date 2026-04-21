using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmSanpham : Form
    {
        private DataTable dtSanPham;
        private bool isAdding;
        private bool isEditingDetail;

        public frmSanpham()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void frmSanpham_Load(object sender, EventArgs e)
        {
            Function.Connect();
            txtMasanpham.Enabled = false;
            txtAnh.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            label8.Text = "Thương hiệu";
            label9.Text = "Nhà cung cấp";
            label10.Text = "Mã sản phẩm";
            label12.Text = "Tồn kho";

            LoadCombos();
            Load_DataGridViewSP();
            ResetValues();
            ResetDetailValues();
        }

        private void LoadCombos()
        {
            Function.FillCombo("SELECT MaLoai, TenLoai FROM LoaiSanPham", cboDanhmuc, "MaLoai", "TenLoai");
            cboDanhmuc.SelectedIndex = -1;
            Function.FillCombo("SELECT MaThuongHieu, TenThuongHieu FROM ThuongHieu", cboNguyenlieu, "MaThuongHieu", "TenThuongHieu");
            cboNguyenlieu.SelectedIndex = -1;
            Function.FillCombo("SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap", cboMaSPChitiet, "MaNhaCungCap", "TenNhaCungCap");
            cboMaSPChitiet.SelectedIndex = -1;
        }

        private void Load_DataGridViewSP(string keyword = "")
        {
            string sql = @"SELECT sp.MaSanPham, sp.TenSanPham, lsp.TenLoai, th.TenThuongHieu, ncc.TenNhaCungCap,
                                  sp.GiaNhap, sp.GiaBan, sp.SoLuongTon, sp.HinhAnh, sp.MoTa, sp.BaoHanhThang,
                                  sp.MaLoai, sp.MaThuongHieu, sp.MaNhaCungCap
                           FROM SanPham sp
                           INNER JOIN LoaiSanPham lsp ON sp.MaLoai = lsp.MaLoai
                           INNER JOIN ThuongHieu th ON sp.MaThuongHieu = th.MaThuongHieu
                           INNER JOIN NhaCungCap ncc ON sp.MaNhaCungCap = ncc.MaNhaCungCap
                           WHERE (@kw = '' OR sp.TenSanPham LIKE @likeKw OR ISNULL(sp.MoTa,'') LIKE @likeKw)
                           ORDER BY sp.TenSanPham";
            dtSanPham = Function.GetDataToTable(sql,
                new SqlParameter("@kw", keyword),
                new SqlParameter("@likeKw", "%" + keyword + "%"));
            dataGridViewQLyCaPhe.DataSource = dtSanPham;
            if (dataGridViewQLyCaPhe.Columns.Count == 0) return;
            dataGridViewQLyCaPhe.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewQLyCaPhe.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridViewQLyCaPhe.Columns[2].HeaderText = "Loại";
            dataGridViewQLyCaPhe.Columns[3].HeaderText = "Thương hiệu";
            dataGridViewQLyCaPhe.Columns[4].HeaderText = "Nhà cung cấp";
            dataGridViewQLyCaPhe.Columns[5].HeaderText = "Giá nhập";
            dataGridViewQLyCaPhe.Columns[6].HeaderText = "Giá bán";
            dataGridViewQLyCaPhe.Columns[7].HeaderText = "Tồn kho";
            if (dataGridViewQLyCaPhe.Columns.Contains("HinhAnh")) dataGridViewQLyCaPhe.Columns[8].Visible = false;
            if (dataGridViewQLyCaPhe.Columns.Contains("MoTa")) dataGridViewQLyCaPhe.Columns[9].Visible = false;
            if (dataGridViewQLyCaPhe.Columns.Contains("BaoHanhThang")) dataGridViewQLyCaPhe.Columns[10].Visible = false;
            if (dataGridViewQLyCaPhe.Columns.Contains("MaLoai")) dataGridViewQLyCaPhe.Columns[11].Visible = false;
            if (dataGridViewQLyCaPhe.Columns.Contains("MaThuongHieu")) dataGridViewQLyCaPhe.Columns[12].Visible = false;
            if (dataGridViewQLyCaPhe.Columns.Contains("MaNhaCungCap")) dataGridViewQLyCaPhe.Columns[13].Visible = false;
            dataGridViewQLyCaPhe.AllowUserToAddRows = false;
            dataGridViewQLyCaPhe.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Load_DataGridViewChiTietSP()
        {
            DataTable detail = new DataTable();
            detail.Columns.Add("Thuộc tính");
            detail.Columns.Add("Giá trị");
            if (dataGridViewQLyCaPhe.CurrentRow != null)
            {
                detail.Rows.Add("Thương hiệu", cboNguyenlieu.Text);
                detail.Rows.Add("Nhà cung cấp", cboMaSPChitiet.Text);
                detail.Rows.Add("Số lượng tồn", txtSoluongdung.Text);
                detail.Rows.Add("Đường dẫn ảnh", txtAnh.Text);
            }
            dataGridViewChiTietSP.DataSource = detail;
            dataGridViewChiTietSP.AllowUserToAddRows = false;
            dataGridViewChiTietSP.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void ResetValues()
        {
            txtMasanpham.Text = "";
            txtTensanpham.Text = "";
            cboDanhmuc.SelectedIndex = -1;
            txtGiaban.Text = "";
            txtGianhap.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }

        private void ResetDetailValues()
        {
            cboNguyenlieu.SelectedIndex = -1;
            cboMaSPChitiet.SelectedIndex = -1;
            txtSoluongdung.Text = "0";
            Load_DataGridViewChiTietSP();
        }

        private void dataGridViewQLyCaPhe_Click(object sender, EventArgs e)
        {
            if (dataGridViewQLyCaPhe.CurrentRow == null) return;
            txtMasanpham.Text = Convert.ToString(dataGridViewQLyCaPhe.CurrentRow.Cells["MaSanPham"].Value);
            txtTensanpham.Text = Convert.ToString(dataGridViewQLyCaPhe.CurrentRow.Cells["TenSanPham"].Value);
            cboDanhmuc.SelectedValue = Convert.ToString(dataGridViewQLyCaPhe.CurrentRow.Cells["MaLoai"].Value);
            txtGianhap.Text = Convert.ToString(dataGridViewQLyCaPhe.CurrentRow.Cells["GiaNhap"].Value);
            txtGiaban.Text = Convert.ToString(dataGridViewQLyCaPhe.CurrentRow.Cells["GiaBan"].Value);
            cboNguyenlieu.SelectedValue = Convert.ToString(dataGridViewQLyCaPhe.CurrentRow.Cells["MaThuongHieu"].Value);
            cboMaSPChitiet.SelectedValue = Convert.ToString(dataGridViewQLyCaPhe.CurrentRow.Cells["MaNhaCungCap"].Value);
            txtSoluongdung.Text = Convert.ToString(dataGridViewQLyCaPhe.CurrentRow.Cells["SoLuongTon"].Value);
            txtAnh.Text = Convert.ToString(dataGridViewQLyCaPhe.CurrentRow.Cells["HinhAnh"].Value);
            if (!string.IsNullOrWhiteSpace(txtAnh.Text) && File.Exists(txtAnh.Text))
                picAnh.Image = Image.FromFile(txtAnh.Text);
            else
                picAnh.Image = null;
            Load_DataGridViewChiTietSP();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ResetValues();
            ResetDetailValues();
            txtMasanpham.Enabled = true;
            txtMasanpham.Focus();
            btnLuu.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMasanpham.Text) || string.IsNullOrWhiteSpace(txtTensanpham.Text) || cboDanhmuc.SelectedIndex < 0 || cboNguyenlieu.SelectedIndex < 0 || cboMaSPChitiet.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm.");
                return;
            }
            int soLuongTon = 0;
            int.TryParse(string.IsNullOrWhiteSpace(txtSoluongdung.Text) ? "0" : txtSoluongdung.Text, out soLuongTon);
            decimal giaNhap = 0, giaBan = 0;
            decimal.TryParse(txtGianhap.Text, out giaNhap);
            decimal.TryParse(txtGiaban.Text, out giaBan);
            string checkSql = "SELECT COUNT(*) FROM SanPham WHERE MaSanPham = @MaSanPham";
            string exists = Function.GetFieldValues(checkSql.Replace("COUNT(*)", "CAST(COUNT(*) AS NVARCHAR(10))").Replace("@MaSanPham", "N'" + txtMasanpham.Text.Trim() + "'"));
            if (isAdding && exists != "0")
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại.");
                return;
            }
            string sql = isAdding
                ? @"INSERT INTO SanPham(MaSanPham, TenSanPham, MaLoai, MaThuongHieu, MaNhaCungCap, GiaNhap, GiaBan, SoLuongTon, MoTa, BaoHanhThang, HinhAnh)
                    VALUES(@MaSanPham,@TenSanPham,@MaLoai,@MaThuongHieu,@MaNhaCungCap,@GiaNhap,@GiaBan,@SoLuongTon,@MoTa,@BaoHanhThang,@HinhAnh)"
                : @"UPDATE SanPham SET TenSanPham=@TenSanPham, MaLoai=@MaLoai, MaThuongHieu=@MaThuongHieu, MaNhaCungCap=@MaNhaCungCap,
                        GiaNhap=@GiaNhap, GiaBan=@GiaBan, SoLuongTon=@SoLuongTon, MoTa=@MoTa, BaoHanhThang=@BaoHanhThang, HinhAnh=@HinhAnh
                    WHERE MaSanPham=@MaSanPham";
            Function.RunSql(sql,
                new SqlParameter("@MaSanPham", txtMasanpham.Text.Trim()),
                new SqlParameter("@TenSanPham", txtTensanpham.Text.Trim()),
                new SqlParameter("@MaLoai", cboDanhmuc.SelectedValue),
                new SqlParameter("@MaThuongHieu", cboNguyenlieu.SelectedValue),
                new SqlParameter("@MaNhaCungCap", cboMaSPChitiet.SelectedValue),
                new SqlParameter("@GiaNhap", giaNhap),
                new SqlParameter("@GiaBan", giaBan),
                new SqlParameter("@SoLuongTon", soLuongTon),
                new SqlParameter("@MoTa", txtTim.Text.Trim()),
                new SqlParameter("@BaoHanhThang", 12),
                new SqlParameter("@HinhAnh", txtAnh.Text.Trim())
            );
            isAdding = false;
            txtMasanpham.Enabled = false;
            btnLuu.Enabled = false;
            Load_DataGridViewSP(txtTim.Text.Trim());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMasanpham.Text)) return;
            isAdding = false;
            txtMasanpham.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMasanpham.Text)) return;
            if (MessageBox.Show("Xóa sản phẩm đã chọn?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            Function.RunSqlDel("DELETE FROM SanPham WHERE MaSanPham = N'" + txtMasanpham.Text.Trim() + "'");
            Load_DataGridViewSP(txtTim.Text.Trim());
            ResetValues();
            ResetDetailValues();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            isAdding = false;
            txtMasanpham.Enabled = false;
            btnLuu.Enabled = false;
            ResetValues();
            ResetDetailValues();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtAnh.Text = dlg.FileName;
                    picAnh.Image = Image.FromFile(dlg.FileName);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            Load_DataGridViewSP(txtTim.Text.Trim());
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnThemChitiet_Click(object sender, EventArgs e)
        {
            isEditingDetail = true;
            cboNguyenlieu.Enabled = true;
            cboMaSPChitiet.Enabled = true;
            txtSoluongdung.Enabled = true;
        }

        private void btnSuaChitiet_Click(object sender, EventArgs e)
        {
            btnThemChitiet_Click(sender, e);
        }

        private void btnLuuChitiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMasanpham.Text) || cboNguyenlieu.SelectedIndex < 0 || cboMaSPChitiet.SelectedIndex < 0) return;
            int soLuongTon = 0;
            int.TryParse(txtSoluongdung.Text, out soLuongTon);
            Function.RunSql(@"UPDATE SanPham SET MaThuongHieu=@MaThuongHieu, MaNhaCungCap=@MaNhaCungCap, SoLuongTon=@SoLuongTon WHERE MaSanPham=@MaSanPham",
                new SqlParameter("@MaThuongHieu", cboNguyenlieu.SelectedValue),
                new SqlParameter("@MaNhaCungCap", cboMaSPChitiet.SelectedValue),
                new SqlParameter("@SoLuongTon", soLuongTon),
                new SqlParameter("@MaSanPham", txtMasanpham.Text.Trim()));
            isEditingDetail = false;
            Load_DataGridViewSP(txtTim.Text.Trim());
            Load_DataGridViewChiTietSP();
        }

        private void btnXoaChitiet_Click(object sender, EventArgs e)
        {
            ResetDetailValues();
        }

        private void dataGridViewChiTietSP_Click(object sender, EventArgs e)
        {
        }

        private void txtSoluongdung_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
        }

        private void txtSoluongdung_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
