using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmBaocaohoadon_Nhanvien : Form
    {
        private DataTable dtHoaDon;
        private DataTable tblChitietHoadon;

        public frmBaocaohoadon_Nhanvien()
        {
            InitializeComponent();
        }

        private string GetSelectedStatus()
        {
            if (cbTinhtrangthanhtoan.SelectedIndex <= 0) return string.Empty;
            return cbTinhtrangthanhtoan.SelectedItem.ToString();
        }

        private void frmBaocaohoadon_Nhanvien_Load(object sender, EventArgs e)
        {
            cbTinhtrangthanhtoan.Items.Clear();
            cbTinhtrangthanhtoan.Items.AddRange(new object[]
            {
                "Tất cả", "Chờ xử lý", "Đang giao", "Đã giao", "Hủy", "Hoàn thành"
            });
            cbTinhtrangthanhtoan.SelectedIndex = 0;
            txtMakhuyenmai.Enabled = false;
            txtMahoadon.Enabled = false;
            txtMuckhuyenmai.Enabled = false;
            txtTinhtrang.Enabled = false;
            txtTonghoadon.Enabled = false;
            mskNgayban.Enabled = false;
            txtTongtien.Enabled = false;
            LoadDataGridView(BuildSqlHoadon());
        }

        private string BuildSqlHoadon()
        {
            string sql = @"SELECT h.NgayBan,
                                  h.MaHoaDonBan,
                                  nv.HoTen AS TenNhanVien,
                                  kh.TenKhachHang,
                                  ISNULL(h.MaDonDatHang,'') AS MaDonDatHang,
                                  h.TongTien,
                                  h.TrangThai,
                                  CASE WHEN h.MaDonDatHang IS NULL THEN N'Bán trực tiếp' ELSE N'Từ đơn đặt hàng' END AS NguonDon
                           FROM HoaDonBan h
                           INNER JOIN NhanVien nv ON h.MaNhanVien = nv.MaNhanVien
                           INNER JOIN KhachHang kh ON h.MaKhachHang = kh.MaKhachHang
                           WHERE CAST(h.NgayBan AS date) = @NgayBaoCao";
            if (!string.IsNullOrWhiteSpace(GetSelectedStatus()))
            {
                sql += " AND h.TrangThai = @TrangThai";
            }
            return sql + " ORDER BY h.NgayBan DESC";
        }

        private void LoadDataGridView(string sql)
        {
            if (string.IsNullOrWhiteSpace(GetSelectedStatus()))
                dtHoaDon = Function.GetDataToTable(sql, new SqlParameter("@NgayBaoCao", Time.Value.Date));
            else
                dtHoaDon = Function.GetDataToTable(sql,
                    new SqlParameter("@NgayBaoCao", Time.Value.Date),
                    new SqlParameter("@TrangThai", GetSelectedStatus()));

            dGridBaocaohoadon.DataSource = dtHoaDon;
            if (dGridBaocaohoadon.Columns.Count > 0)
            {
                dGridBaocaohoadon.Columns[0].HeaderText = "Ngày hóa đơn";
                dGridBaocaohoadon.Columns[1].HeaderText = "Mã hóa đơn";
                dGridBaocaohoadon.Columns[2].HeaderText = "Tên nhân viên";
                dGridBaocaohoadon.Columns[3].HeaderText = "Khách hàng";
                dGridBaocaohoadon.Columns[4].HeaderText = "Mã đơn đặt";
                dGridBaocaohoadon.Columns[5].HeaderText = "Tổng tiền";
                dGridBaocaohoadon.Columns[6].HeaderText = "Trạng thái";
                dGridBaocaohoadon.Columns[7].HeaderText = "Nguồn đơn";
                dGridBaocaohoadon.AllowUserToAddRows = false;
                dGridBaocaohoadon.EditMode = DataGridViewEditMode.EditProgrammatically;
            }

            txtTonghoadon.Text = dtHoaDon.Rows.Count.ToString();
            decimal tong = 0;
            foreach (DataRow r in dtHoaDon.Rows)
                tong += Convert.ToDecimal(r["TongTien"]);
            txtTongtien.Text = tong.ToString("N0");
        }

        private void Load_dGridChitietHoadon(string ma)
        {
            string sql = @"SELECT sp.TenSanPham, ct.SoLuong, ct.DonGia, ct.SoLuong * ct.DonGia AS ThanhTien
                           FROM ChiTietHoaDonBan ct
                           INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                           WHERE ct.MaHoaDonBan = @MaHoaDonBan";
            tblChitietHoadon = Function.GetDataToTable(sql, new SqlParameter("@MaHoaDonBan", ma));
            dGridChitiethoadon.DataSource = tblChitietHoadon;
            if (dGridChitiethoadon.Columns.Count > 0)
            {
                dGridChitiethoadon.Columns[0].HeaderText = "Tên sản phẩm";
                dGridChitiethoadon.Columns[1].HeaderText = "Số lượng";
                dGridChitiethoadon.Columns[2].HeaderText = "Đơn giá";
                dGridChitiethoadon.Columns[3].HeaderText = "Thành tiền";
            }
            dGridChitiethoadon.AllowUserToAddRows = false;
            dGridChitiethoadon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dGridBaocaohoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dGridBaocaohoadon_Click(object sender, EventArgs e)
        {
            if (dGridBaocaohoadon.CurrentRow == null) return;
            string ma = Convert.ToString(dGridBaocaohoadon.CurrentRow.Cells["MaHoaDonBan"].Value);
            Load_dGridChitietHoadon(ma);
            txtMahoadon.Text = ma;
            txtMakhuyenmai.Text = Convert.ToString(dGridBaocaohoadon.CurrentRow.Cells["MaDonDatHang"].Value);
            txtMuckhuyenmai.Text = Convert.ToString(dGridBaocaohoadon.CurrentRow.Cells["TenKhachHang"].Value);
            txtTinhtrang.Text = Convert.ToString(dGridBaocaohoadon.CurrentRow.Cells["TrangThai"].Value);
            mskNgayban.Text = Convert.ToDateTime(dGridBaocaohoadon.CurrentRow.Cells["NgayBan"].Value).ToString("dd/MM/yyyy");
        }

        private void ResetValues()
        {
            txtMahoadon.Text = "";
            txtMakhuyenmai.Text = "";
            txtMuckhuyenmai.Text = "";
            txtTinhtrang.Text = "";
            dGridChitiethoadon.DataSource = null;
            mskNgayban.Text = "";
        }

        private void Time_ValueChanged(object sender, EventArgs e)
        {
            ResetValues();
            LoadDataGridView(BuildSqlHoadon());
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dGridBaocaohoadon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần cập nhật trạng thái.");
                return;
            }
            if (txtPass.Text != "huyhoadon")
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ma = Convert.ToString(dGridBaocaohoadon.CurrentRow.Cells["MaHoaDonBan"].Value);
            Function.RunSql("UPDATE HoaDonBan SET TrangThai = N'Hủy' WHERE MaHoaDonBan = @Ma", new SqlParameter("@Ma", ma));
            ResetValues();
            LoadDataGridView(BuildSqlHoadon());
            MessageBox.Show("Đã cập nhật trạng thái hóa đơn thành Hủy.");
        }

        private void cbTinhtrangthanhtoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetValues();
            LoadDataGridView(BuildSqlHoadon());
        }
    }
}
