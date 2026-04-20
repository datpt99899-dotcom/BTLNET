using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmQuanlyHoadon : Form
    {
        private DataTable tblHoadonBan;
        private DataTable tblChitietHoadon;

        public frmQuanlyHoadon()
        {
            InitializeComponent();
        }

        private void frmQuanlyHoadon_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            Load_dGridHoadon();
        }

        private string BuildInvoiceQuery()
        {
            string sql = @"SELECT h.MaHoaDonBan,
                                  h.NgayBan,
                                  nv.HoTen AS TenNhanVien,
                                  kh.TenKhachHang,
                                  ISNULL(h.MaDonDatHang,'') AS MaDonDatHang,
                                  h.TrangThai,
                                  h.TongTien,
                                  ISNULL(kh.SoDienThoai,'') AS SoDienThoai
                           FROM HoaDonBan h
                           INNER JOIN NhanVien nv ON h.MaNhanVien = nv.MaNhanVien
                           INNER JOIN KhachHang kh ON h.MaKhachHang = kh.MaKhachHang
                           WHERE CAST(h.NgayBan AS date) BETWEEN @TuNgay AND @DenNgay";
            if (!string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                sql += " AND kh.SoDienThoai LIKE @SoDienThoai";
            }
            sql += " ORDER BY h.NgayBan DESC";
            return sql;
        }

        private void Load_dGridHoadon()
        {
            DateTime fromDate = dateTimePicker1.Value.Date;
            DateTime toDate = dateTimePicker2.Value.Date;
            tblHoadonBan = Function.GetDataToTable(
                BuildInvoiceQuery(),
                new System.Data.SqlClient.SqlParameter("@TuNgay", fromDate),
                new System.Data.SqlClient.SqlParameter("@DenNgay", toDate),
                new System.Data.SqlClient.SqlParameter("@SoDienThoai", "%" + txtsdt.Text.Trim() + "%")
            );

            dGridDsHD.DataSource = tblHoadonBan;
            if (dGridDsHD.Columns.Count == 0) return;
            dGridDsHD.Columns[0].HeaderText = "Mã hóa đơn";
            dGridDsHD.Columns[1].HeaderText = "Ngày bán";
            dGridDsHD.Columns[2].HeaderText = "Nhân viên";
            dGridDsHD.Columns[3].HeaderText = "Khách hàng";
            dGridDsHD.Columns[4].HeaderText = "Mã đơn đặt";
            dGridDsHD.Columns[5].HeaderText = "Trạng thái";
            dGridDsHD.Columns[6].HeaderText = "Tổng tiền";
            if (dGridDsHD.Columns.Contains("SoDienThoai")) dGridDsHD.Columns["SoDienThoai"].Visible = false;
            dGridDsHD.AllowUserToAddRows = false;
            dGridDsHD.EditMode = DataGridViewEditMode.EditProgrammatically;
            if (tblHoadonBan.Rows.Count > 0)
            {
                Load_dGridChitietHoadon(tblHoadonBan.Rows[0]["MaHoaDonBan"].ToString());
            }
            else
            {
                dGridChitietHD.DataSource = null;
            }
        }

        private void Load_dGridChitietHoadon(string ma)
        {
            string sql = @"SELECT ct.MaHoaDonBan,
                                  sp.TenSanPham,
                                  ct.SoLuong,
                                  ct.DonGia,
                                  ct.SoLuong * ct.DonGia AS ThanhTien
                           FROM ChiTietHoaDonBan ct
                           INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                           WHERE ct.MaHoaDonBan = @MaHoaDonBan";
            tblChitietHoadon = Function.GetDataToTable(sql, new System.Data.SqlClient.SqlParameter("@MaHoaDonBan", ma));
            dGridChitietHD.DataSource = tblChitietHoadon;
            if (dGridChitietHD.Columns.Count == 0) return;
            if (dGridChitietHD.Columns.Contains("MaHoaDonBan")) dGridChitietHD.Columns["MaHoaDonBan"].Visible = false;
            dGridChitietHD.Columns[1].HeaderText = "Tên sản phẩm";
            dGridChitietHD.Columns[2].HeaderText = "Số lượng";
            dGridChitietHD.Columns[3].HeaderText = "Đơn giá";
            dGridChitietHD.Columns[4].HeaderText = "Thành tiền";
            dGridChitietHD.AllowUserToAddRows = false;
            dGridChitietHD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dGridDsHD_Click(object sender, EventArgs e)
        {
            if (dGridDsHD.CurrentRow == null) return;
            string ma = Convert.ToString(dGridDsHD.CurrentRow.Cells["MaHoaDonBan"].Value);
            if (!string.IsNullOrEmpty(ma))
                Load_dGridChitietHoadon(ma);
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
        }

        private void BtnThongke_Click_1(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Load_dGridHoadon();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Load_dGridHoadon();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (dGridDsHD.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("HÓA ĐƠN BÁN HÀNG");
            sb.AppendLine("Mã hóa đơn: " + Convert.ToString(dGridDsHD.CurrentRow.Cells["MaHoaDonBan"].Value));
            sb.AppendLine("Ngày bán: " + Convert.ToDateTime(dGridDsHD.CurrentRow.Cells["NgayBan"].Value).ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine("Nhân viên: " + Convert.ToString(dGridDsHD.CurrentRow.Cells["TenNhanVien"].Value));
            sb.AppendLine("Khách hàng: " + Convert.ToString(dGridDsHD.CurrentRow.Cells["TenKhachHang"].Value));
            sb.AppendLine("Tổng tiền: " + Convert.ToDecimal(dGridDsHD.CurrentRow.Cells["TongTien"].Value).ToString("N0") + " đ");
            sb.AppendLine("------------------------------");
            if (tblChitietHoadon != null)
            {
                foreach (DataRow row in tblChitietHoadon.Rows)
                {
                    sb.AppendLine($"- {row["TenSanPham"]} x {row["SoLuong"]}: {Convert.ToDecimal(row["ThanhTien"]).ToString("N0")} đ");
                }
            }
            MessageBox.Show(sb.ToString(), "Xem nhanh hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
