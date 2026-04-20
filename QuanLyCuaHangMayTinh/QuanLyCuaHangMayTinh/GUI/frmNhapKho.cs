using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmNhapKho : Form
    {
        private DataTable tblPN;
        private DataTable tblCT;
        private bool addingHeader;
        private bool addingDetail;
        private int oldDetailQty;
        private string oldDetailProduct;

        public frmNhapKho()
        {
            InitializeComponent();
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            txtTongTien.Enabled = false;
            txtMaHDN.Enabled = false;
            LoadCombos();
            LoadReceiptGrid();
            ToggleHeaderEditing(false);
            ToggleDetailEditing(false);
        }

        private void LoadCombos()
        {
            Function.FillCombo("SELECT MaNhanVien, HoTen FROM NhanVien WHERE MaVaiTro IN (N'VT01',N'VT02')", cboNVNhap, "MaNhanVien", "HoTen");
            cboNVNhap.SelectedIndex = -1;
            Function.FillCombo("SELECT MaNhaCungCap, TenNhaCungCap FROM NhaCungCap", cboNhaCungCap, "MaNhaCungCap", "TenNhaCungCap");
            cboNhaCungCap.SelectedIndex = -1;
            Function.FillCombo("SELECT MaSanPham, TenSanPham FROM SanPham", cboNguyenLieu, "MaSanPham", "TenSanPham");
            cboNguyenLieu.SelectedIndex = -1;
        }

        private void ToggleHeaderEditing(bool enabled)
        {
            dtpNgayNhap.Enabled = enabled;
            cboNVNhap.Enabled = enabled;
            cboNhaCungCap.Enabled = enabled;
            btnLuu1.Enabled = enabled;
            btnLamMoi1.Enabled = enabled;
        }

        private void ToggleDetailEditing(bool enabled)
        {
            cboNguyenLieu.Enabled = enabled;
            txtSLNhap.Enabled = enabled;
            txtDonGiaNhap.Enabled = enabled;
            btnLuu2.Enabled = enabled;
            btnLamMoi2.Enabled = enabled;
        }

        private void LoadReceiptGrid()
        {
            string sql = @"SELECT pn.MaPhieuNhap, pn.NgayNhap, nv.HoTen AS TenNhanVien, ncc.TenNhaCungCap, pn.TongTien,
                                  pn.MaNhaCungCap, pn.MaNhanVien
                           FROM PhieuNhapKho pn
                           INNER JOIN NhanVien nv ON pn.MaNhanVien = nv.MaNhanVien
                           INNER JOIN NhaCungCap ncc ON pn.MaNhaCungCap = ncc.MaNhaCungCap
                           ORDER BY pn.NgayNhap DESC";
            tblPN = Function.GetDataToTable(sql);
            DataGridView1.DataSource = tblPN;
            if (DataGridView1.Columns.Count > 0)
            {
                DataGridView1.Columns[0].HeaderText = "Mã phiếu nhập";
                DataGridView1.Columns[1].HeaderText = "Ngày nhập";
                DataGridView1.Columns[2].HeaderText = "Nhân viên";
                DataGridView1.Columns[3].HeaderText = "Nhà cung cấp";
                DataGridView1.Columns[4].HeaderText = "Tổng tiền";
                DataGridView1.Columns[5].Visible = false;
                DataGridView1.Columns[6].Visible = false;
            }
            if (tblPN.Rows.Count > 0)
            {
                txtMaHDN.Text = tblPN.Rows[0]["MaPhieuNhap"].ToString();
                LoadDetailGrid(txtMaHDN.Text);
            }
            else
            {
                DataGridView2.DataSource = null;
            }
        }

        private void LoadDetailGrid(string maPhieuNhap)
        {
            string sql = @"SELECT ct.MaPhieuNhap, ct.MaSanPham, sp.TenSanPham, ct.SoLuong, ct.DonGiaNhap,
                                  ct.SoLuong * ct.DonGiaNhap AS ThanhTien
                           FROM ChiTietPhieuNhap ct
                           INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                           WHERE ct.MaPhieuNhap = @MaPhieuNhap";
            tblCT = Function.GetDataToTable(sql, new SqlParameter("@MaPhieuNhap", maPhieuNhap));
            DataGridView2.DataSource = tblCT;
            if (DataGridView2.Columns.Count > 0)
            {
                DataGridView2.Columns[0].Visible = false;
                DataGridView2.Columns[1].Visible = false;
                DataGridView2.Columns[2].HeaderText = "Sản phẩm";
                DataGridView2.Columns[3].HeaderText = "Số lượng";
                DataGridView2.Columns[4].HeaderText = "Đơn giá nhập";
                DataGridView2.Columns[5].HeaderText = "Thành tiền";
            }
            UpdateReceiptTotal(maPhieuNhap);
        }

        private void UpdateReceiptTotal(string maPhieuNhap)
        {
            string sumSql = "SELECT ISNULL(SUM(SoLuong * DonGiaNhap),0) FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap";
            string value = Function.GetFieldValues(sumSql.Replace("@MaPhieuNhap", "N'" + maPhieuNhap + "'"));
            txtTongTien.Text = string.IsNullOrWhiteSpace(value) ? "0" : Convert.ToDecimal(value).ToString("N0");
            Function.RunSql("UPDATE PhieuNhapKho SET TongTien=@TongTien WHERE MaPhieuNhap=@MaPhieuNhap",
                new SqlParameter("@TongTien", Convert.ToDecimal(string.IsNullOrWhiteSpace(value) ? "0" : value)),
                new SqlParameter("@MaPhieuNhap", maPhieuNhap));
        }

        private void ResetHeader()
        {
            txtMaHDN.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
            cboNVNhap.SelectedIndex = -1;
            cboNhaCungCap.SelectedIndex = -1;
            txtTongTien.Text = "0";
        }

        private void ResetDetail()
        {
            cboNguyenLieu.SelectedIndex = -1;
            txtSLNhap.Text = "";
            txtDonGiaNhap.Text = "";
            oldDetailQty = 0;
            oldDetailProduct = null;
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentRow == null) return;
            txtMaHDN.Text = Convert.ToString(DataGridView1.CurrentRow.Cells["MaPhieuNhap"].Value);
            dtpNgayNhap.Value = Convert.ToDateTime(DataGridView1.CurrentRow.Cells["NgayNhap"].Value);
            cboNVNhap.SelectedValue = Convert.ToString(DataGridView1.CurrentRow.Cells["MaNhanVien"].Value);
            cboNhaCungCap.SelectedValue = Convert.ToString(DataGridView1.CurrentRow.Cells["MaNhaCungCap"].Value);
            txtTongTien.Text = Convert.ToDecimal(DataGridView1.CurrentRow.Cells["TongTien"].Value).ToString("N0");
            LoadDetailGrid(txtMaHDN.Text);
        }

        private void DataGridView2_Click(object sender, EventArgs e)
        {
            if (DataGridView2.CurrentRow == null) return;
            cboNguyenLieu.SelectedValue = Convert.ToString(DataGridView2.CurrentRow.Cells["MaSanPham"].Value);
            txtSLNhap.Text = Convert.ToString(DataGridView2.CurrentRow.Cells["SoLuong"].Value);
            txtDonGiaNhap.Text = Convert.ToString(DataGridView2.CurrentRow.Cells["DonGiaNhap"].Value);
            oldDetailQty = Convert.ToInt32(DataGridView2.CurrentRow.Cells["SoLuong"].Value);
            oldDetailProduct = Convert.ToString(DataGridView2.CurrentRow.Cells["MaSanPham"].Value);
        }

        private string GenerateReceiptCode() => "PNK" + DateTime.Now.ToString("yyyyMMddHHmmss");

        private void btnThem1_Click(object sender, EventArgs e)
        {
            addingHeader = true;
            ResetHeader();
            txtMaHDN.Text = GenerateReceiptCode();
            ToggleHeaderEditing(true);
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text) || cboNVNhap.SelectedIndex < 0 || cboNhaCungCap.SelectedIndex < 0) return;
            if (addingHeader)
            {
                Function.RunSql(@"INSERT INTO PhieuNhapKho(MaPhieuNhap, NgayNhap, MaNhaCungCap, MaNhanVien, TongTien)
                                  VALUES(@MaPhieuNhap,@NgayNhap,@MaNhaCungCap,@MaNhanVien,0)",
                    new SqlParameter("@MaPhieuNhap", txtMaHDN.Text.Trim()),
                    new SqlParameter("@NgayNhap", dtpNgayNhap.Value),
                    new SqlParameter("@MaNhaCungCap", cboNhaCungCap.SelectedValue),
                    new SqlParameter("@MaNhanVien", cboNVNhap.SelectedValue));
            }
            else
            {
                Function.RunSql(@"UPDATE PhieuNhapKho SET NgayNhap=@NgayNhap, MaNhaCungCap=@MaNhaCungCap, MaNhanVien=@MaNhanVien WHERE MaPhieuNhap=@MaPhieuNhap",
                    new SqlParameter("@NgayNhap", dtpNgayNhap.Value),
                    new SqlParameter("@MaNhaCungCap", cboNhaCungCap.SelectedValue),
                    new SqlParameter("@MaNhanVien", cboNVNhap.SelectedValue),
                    new SqlParameter("@MaPhieuNhap", txtMaHDN.Text.Trim()));
            }
            addingHeader = false;
            ToggleHeaderEditing(false);
            LoadReceiptGrid();
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text)) return;
            addingHeader = false;
            ToggleHeaderEditing(true);
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text)) return;
            if (MessageBox.Show("Xóa phiếu nhập và toàn bộ chi tiết?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            foreach (DataRow row in tblCT.Rows)
            {
                Function.RunSql("UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSanPham=@MaSanPham",
                    new SqlParameter("@SoLuong", Convert.ToInt32(row["SoLuong"])),
                    new SqlParameter("@MaSanPham", row["MaSanPham"].ToString()));
            }
            Function.RunSql("DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap=@MaPhieuNhap", new SqlParameter("@MaPhieuNhap", txtMaHDN.Text.Trim()));
            Function.RunSql("DELETE FROM PhieuNhapKho WHERE MaPhieuNhap=@MaPhieuNhap", new SqlParameter("@MaPhieuNhap", txtMaHDN.Text.Trim()));
            LoadReceiptGrid();
            ResetHeader();
            ResetDetail();
        }

        private void btnTimKiem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text)) { LoadReceiptGrid(); return; }
            string sql = @"SELECT pn.MaPhieuNhap, pn.NgayNhap, nv.HoTen AS TenNhanVien, ncc.TenNhaCungCap, pn.TongTien,
                                  pn.MaNhaCungCap, pn.MaNhanVien
                           FROM PhieuNhapKho pn
                           INNER JOIN NhanVien nv ON pn.MaNhanVien = nv.MaNhanVien
                           INNER JOIN NhaCungCap ncc ON pn.MaNhaCungCap = ncc.MaNhaCungCap
                           WHERE pn.MaPhieuNhap LIKE @Ma";
            tblPN = Function.GetDataToTable(sql, new SqlParameter("@Ma", "%" + txtMaHDN.Text.Trim() + "%"));
            DataGridView1.DataSource = tblPN;
        }

        private void btnLamMoi1_Click(object sender, EventArgs e)
        {
            addingHeader = false;
            ToggleHeaderEditing(false);
            ResetHeader();
            LoadReceiptGrid();
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text)) { MessageBox.Show("Vui lòng chọn hoặc tạo phiếu nhập trước."); return; }
            addingDetail = true;
            ResetDetail();
            ToggleDetailEditing(true);
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text) || cboNguyenLieu.SelectedIndex < 0) return;
            int soLuong = 0; decimal donGia = 0;
            int.TryParse(txtSLNhap.Text, out soLuong);
            decimal.TryParse(txtDonGiaNhap.Text, out donGia);
            if (soLuong <= 0 || donGia <= 0) { MessageBox.Show("Số lượng và đơn giá phải lớn hơn 0."); return; }

            string maSanPham = cboNguyenLieu.SelectedValue.ToString();
            if (addingDetail)
            {
                Function.RunSql(@"INSERT INTO ChiTietPhieuNhap(MaPhieuNhap, MaSanPham, SoLuong, DonGiaNhap)
                                  VALUES(@MaPhieuNhap,@MaSanPham,@SoLuong,@DonGiaNhap)",
                    new SqlParameter("@MaPhieuNhap", txtMaHDN.Text.Trim()),
                    new SqlParameter("@MaSanPham", maSanPham),
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@DonGiaNhap", donGia));
                Function.RunSql("UPDATE SanPham SET SoLuongTon = SoLuongTon + @SoLuong, GiaNhap = @GiaNhap WHERE MaSanPham=@MaSanPham",
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@GiaNhap", donGia),
                    new SqlParameter("@MaSanPham", maSanPham));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(oldDetailProduct))
                {
                    Function.RunSql("UPDATE SanPham SET SoLuongTon = SoLuongTon - @OldQty WHERE MaSanPham=@MaSanPham",
                        new SqlParameter("@OldQty", oldDetailQty),
                        new SqlParameter("@MaSanPham", oldDetailProduct));
                }
                Function.RunSql(@"UPDATE ChiTietPhieuNhap SET MaSanPham=@NewSanPham, SoLuong=@SoLuong, DonGiaNhap=@DonGiaNhap
                                  WHERE MaPhieuNhap=@MaPhieuNhap AND MaSanPham=@OldSanPham",
                    new SqlParameter("@NewSanPham", maSanPham),
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@DonGiaNhap", donGia),
                    new SqlParameter("@MaPhieuNhap", txtMaHDN.Text.Trim()),
                    new SqlParameter("@OldSanPham", oldDetailProduct ?? maSanPham));
                Function.RunSql("UPDATE SanPham SET SoLuongTon = SoLuongTon + @SoLuong, GiaNhap = @GiaNhap WHERE MaSanPham=@MaSanPham",
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@GiaNhap", donGia),
                    new SqlParameter("@MaSanPham", maSanPham));
            }
            addingDetail = false;
            ToggleDetailEditing(false);
            LoadDetailGrid(txtMaHDN.Text.Trim());
            LoadReceiptGrid();
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            if (DataGridView2.CurrentRow == null) return;
            addingDetail = false;
            ToggleDetailEditing(true);
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            if (DataGridView2.CurrentRow == null) return;
            string maSanPham = Convert.ToString(DataGridView2.CurrentRow.Cells["MaSanPham"].Value);
            int soLuong = Convert.ToInt32(DataGridView2.CurrentRow.Cells["SoLuong"].Value);
            if (MessageBox.Show("Xóa chi tiết nhập đã chọn?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            Function.RunSql("DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap=@MaPhieuNhap AND MaSanPham=@MaSanPham",
                new SqlParameter("@MaPhieuNhap", txtMaHDN.Text.Trim()),
                new SqlParameter("@MaSanPham", maSanPham));
            Function.RunSql("UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSanPham=@MaSanPham",
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@MaSanPham", maSanPham));
            LoadDetailGrid(txtMaHDN.Text.Trim());
            LoadReceiptGrid();
        }

        private void btnTimKiem2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text) || cboNguyenLieu.SelectedIndex < 0)
            {
                if (!string.IsNullOrWhiteSpace(txtMaHDN.Text)) LoadDetailGrid(txtMaHDN.Text.Trim());
                return;
            }
            string sql = @"SELECT ct.MaPhieuNhap, ct.MaSanPham, sp.TenSanPham, ct.SoLuong, ct.DonGiaNhap,
                                  ct.SoLuong * ct.DonGiaNhap AS ThanhTien
                           FROM ChiTietPhieuNhap ct
                           INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                           WHERE ct.MaPhieuNhap=@MaPhieuNhap AND ct.MaSanPham=@MaSanPham";
            tblCT = Function.GetDataToTable(sql,
                new SqlParameter("@MaPhieuNhap", txtMaHDN.Text.Trim()),
                new SqlParameter("@MaSanPham", cboNguyenLieu.SelectedValue));
            DataGridView2.DataSource = tblCT;
        }

        private void btnLamMoi2_Click(object sender, EventArgs e)
        {
            addingDetail = false;
            ToggleDetailEditing(false);
            ResetDetail();
            if (!string.IsNullOrWhiteSpace(txtMaHDN.Text)) LoadDetailGrid(txtMaHDN.Text.Trim());
        }

        private void txtSLNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
        }

        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
        }
    }
}
