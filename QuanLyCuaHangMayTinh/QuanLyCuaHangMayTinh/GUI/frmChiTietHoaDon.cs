// ===================== frmChiTietHoaDon.cs =====================

using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmChiTietHoaDon : Form
    {
        private DataTable dtChiTiet;
        private bool isNewInvoice = true;
        private string currentMaHD = "";

        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            dtpNgayMua.Value = DateTime.Now;
            LoadNhanVien();
            LoadDataForNewInvoice();
        }

        private void LoadNhanVien()
        {
            DataTable dtNhanVien = Function.GetDataToTable("SELECT MaNhanVien, HoTen FROM NhanVien WHERE TrangThai = N'Đang làm'");
            cboMaNhanVien.DataSource = dtNhanVien;
            cboMaNhanVien.DisplayMember = "MaNhanVien";
            cboMaNhanVien.ValueMember = "MaNhanVien";

            cboTenNhanVien.DataSource = dtNhanVien.Copy();
            cboTenNhanVien.DisplayMember = "HoTen";
            cboTenNhanVien.ValueMember = "MaNhanVien";
        }

        private void LoadDataForNewInvoice()
        {
            isNewInvoice = true;
            txtMaHoaDon.Text = TaoMaHoaDonMoi();
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            dtpNgayMua.Value = DateTime.Now;
            if (cboMaNhanVien.Items.Count > 0) cboMaNhanVien.SelectedIndex = 0;
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("MaHang", typeof(string));
            dtChiTiet.Columns.Add("TenHang", typeof(string));
            dtChiTiet.Columns.Add("SoLuong", typeof(int));
            dtChiTiet.Columns.Add("GiamGia", typeof(decimal));
            dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));
            dgvChiTiet.DataSource = dtChiTiet;
            UpdateTotal();
        }

        private string TaoMaHoaDonMoi()
        {
            // Tạo mã tự động: HDB + yyyyMMdd + số thứ tự
            string today = DateTime.Now.ToString("yyyyMMdd");
            string sql = "SELECT TOP 1 MaHoaDonBan FROM HoaDonBan WHERE MaHoaDonBan LIKE @prefix ORDER BY MaHoaDonBan DESC";
            SqlParameter p = new SqlParameter("@prefix", "HDB" + today + "%");
            DataTable dt = Function.GetDataToTable(sql, p);
            int stt = 1;
            if (dt.Rows.Count > 0)
            {
                string lastCode = dt.Rows[0][0].ToString();
                if (lastCode.Length >= 13)
                {
                    string numPart = lastCode.Substring(11);
                    if (int.TryParse(numPart, out int lastNum))
                        stt = lastNum + 1;
                }
            }
            return "HDB" + today + stt.ToString("D3");
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            if (dtChiTiet != null)
            {
                foreach (DataRow row in dtChiTiet.Rows)
                {
                    if (row.RowState != DataRowState.Deleted && row["ThanhTien"] != DBNull.Value)
                        total += Convert.ToDecimal(row["ThanhTien"]);
                }
            }
            txtTongTien.Text = total.ToString("N0") + " đ";
            txtBangChu.Text = NumberToWords(total);
        }

        private string NumberToWords(decimal number)
        {
            if (number == 0) return "Không đồng";
            long intPart = (long)number;
            string words = ConvertIntToWords(intPart);
            words = words + " đồng";
            return char.ToUpper(words[0]) + words.Substring(1).ToLower();
        }

        private string ConvertIntToWords(long number)
        {
            if (number == 0) return "không";
            string[] units = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] tens = { "", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };
            string result = "";
            if (number >= 1000000000)
            {
                result += ConvertIntToWords(number / 1000000000) + " tỷ ";
                number %= 1000000000;
            }
            if (number >= 1000000)
            {
                result += ConvertIntToWords(number / 1000000) + " triệu ";
                number %= 1000000;
            }
            if (number >= 1000)
            {
                result += ConvertIntToWords(number / 1000) + " nghìn ";
                number %= 1000;
            }
            if (number >= 100)
            {
                result += ConvertIntToWords(number / 100) + " trăm ";
                number %= 100;
            }
            if (number >= 10)
            {
                int ten = (int)(number / 10);
                int unit = (int)(number % 10);
                result += tens[ten];
                if (unit > 0) result += " " + (unit == 5 ? "lăm" : units[unit]);
            }
            else if (number > 0)
            {
                result += units[number];
            }
            return result.Trim();
        }

        private void dgvChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateRow(e.RowIndex);
        }

        private void dgvChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvChiTiet.Columns["MaHang"].Index || e.ColumnIndex == dgvChiTiet.Columns["SoLuong"].Index || e.ColumnIndex == dgvChiTiet.Columns["GiamGia"].Index))
            {
                CalculateRow(e.RowIndex);
            }
        }

        private void CalculateRow(int rowIndex)
        {
            DataGridViewRow row = dgvChiTiet.Rows[rowIndex];
            string maHang = row.Cells["MaHang"].Value?.ToString();
            if (!string.IsNullOrEmpty(maHang))
            {
                // Tự động lấy tên hàng
                DataTable dt = Function.GetDataToTable("SELECT TenSanPham, GiaBan FROM SanPham WHERE MaSanPham = @ma", new SqlParameter("@ma", maHang));
                if (dt.Rows.Count > 0)
                {
                    row.Cells["TenHang"].Value = dt.Rows[0]["TenSanPham"].ToString();
                    decimal donGia = Convert.ToDecimal(dt.Rows[0]["GiaBan"]);
                    int soLuong = 1;
                    decimal giamGia = 0;
                    if (row.Cells["SoLuong"].Value != null) int.TryParse(row.Cells["SoLuong"].Value.ToString(), out soLuong);
                    if (row.Cells["GiamGia"].Value != null) decimal.TryParse(row.Cells["GiamGia"].Value.ToString(), out giamGia);
                    decimal thanhTien = soLuong * donGia * (1 - giamGia / 100);
                    row.Cells["ThanhTien"].Value = thanhTien;
                }
                else
                {
                    MessageBox.Show("Mã hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells["MaHang"].Value = null;
                }
            }
            else
            {
                row.Cells["TenHang"].Value = null;
                row.Cells["ThanhTien"].Value = null;
            }
            UpdateTotal();
        }

        private void dgvChiTiet_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotal();
        }

        private void dgvChiTiet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
            else
                UpdateTotal();
        }

        private void btnThemDong_Click(object sender, EventArgs e)
        {
            dtChiTiet.Rows.Add(null, null, 1, 0, null);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoadDataForNewInvoice();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhachHang.Focus();
                return;
            }
            if (dtChiTiet.Rows.Count == 0 || dtChiTiet.Rows[0]["MaHang"] == DBNull.Value)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một mặt hàng!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Function.GetSqlConnection())
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        // Kiểm tra khách hàng tồn tại, nếu chưa thì thêm mới
                        DataTable dtKH = Function.GetDataToTable("SELECT MaKhachHang FROM KhachHang WHERE MaKhachHang = @ma", new SqlParameter("@ma", txtMaKhachHang.Text));
                        if (dtKH.Rows.Count == 0)
                        {
                            string sqlInsertKH = @"INSERT INTO KhachHang (MaKhachHang, TenKhachHang, DiaChi, SoDienThoai) 
                                                   VALUES (@ma, @ten, @diachi, @dt)";
                            SqlCommand cmdKH = new SqlCommand(sqlInsertKH, conn, trans);
                            cmdKH.Parameters.AddWithValue("@ma", txtMaKhachHang.Text);
                            cmdKH.Parameters.AddWithValue("@ten", txtTenKhachHang.Text);
                            cmdKH.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                            cmdKH.Parameters.AddWithValue("@dt", txtDienThoai.Text);
                            cmdKH.ExecuteNonQuery();
                        }
                        else
                        {
                            // Cập nhật thông tin khách hàng
                            string sqlUpdKH = @"UPDATE KhachHang SET TenKhachHang=@ten, DiaChi=@diachi, SoDienThoai=@dt WHERE MaKhachHang=@ma";
                            SqlCommand cmdUpd = new SqlCommand(sqlUpdKH, conn, trans);
                            cmdUpd.Parameters.AddWithValue("@ma", txtMaKhachHang.Text);
                            cmdUpd.Parameters.AddWithValue("@ten", txtTenKhachHang.Text);
                            cmdUpd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                            cmdUpd.Parameters.AddWithValue("@dt", txtDienThoai.Text);
                            cmdUpd.ExecuteNonQuery();
                        }

                        string maNV = cboMaNhanVien.SelectedValue.ToString();
                        string sqlHD = @"INSERT INTO HoaDonBan (MaHoaDonBan, NgayBan, MaNhanVien, MaKhachHang, TongTien, TrangThai)
                                         VALUES (@maHD, @ngay, @maNV, @maKH, @tong, N'Đã thanh toán')";
                        SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans);
                        cmdHD.Parameters.AddWithValue("@maHD", txtMaHoaDon.Text);
                        cmdHD.Parameters.AddWithValue("@ngay", dtpNgayMua.Value);
                        cmdHD.Parameters.AddWithValue("@maNV", maNV);
                        cmdHD.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text);
                        cmdHD.Parameters.AddWithValue("@tong", decimal.Parse(txtTongTien.Text.Replace(" đ", "").Replace(",", "")));
                        cmdHD.ExecuteNonQuery();

                        // Xóa chi tiết cũ nếu có (trường hợp sửa)
                        string sqlDelCT = "DELETE FROM ChiTietHoaDonBan WHERE MaHoaDonBan = @ma";
                        SqlCommand cmdDel = new SqlCommand(sqlDelCT, conn, trans);
                        cmdDel.Parameters.AddWithValue("@ma", txtMaHoaDon.Text);
                        cmdDel.ExecuteNonQuery();

                        // Thêm chi tiết mới
                        string sqlCT = @"INSERT INTO ChiTietHoaDonBan (MaHoaDonBan, MaSanPham, SoLuong, DonGia, GiamGia) 
                                         VALUES (@maHD, @maSP, @sl, @dongia, @giamgia)";
                        foreach (DataRow row in dtChiTiet.Rows)
                        {
                            if (row.RowState == DataRowState.Deleted || row["MaHang"] == DBNull.Value) continue;
                            string maSP = row["MaHang"].ToString();
                            int sl = Convert.ToInt32(row["SoLuong"]);
                            decimal giam = Convert.ToDecimal(row["GiamGia"]);
                            // Lấy đơn giá từ bảng sản phẩm
                            DataTable dtGia = Function.GetDataToTable("SELECT GiaBan FROM SanPham WHERE MaSanPham = @ma", new SqlParameter("@ma", maSP));
                            decimal donGia = Convert.ToDecimal(dtGia.Rows[0]["GiaBan"]);

                            SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                            cmdCT.Parameters.AddWithValue("@maHD", txtMaHoaDon.Text);
                            cmdCT.Parameters.AddWithValue("@maSP", maSP);
                            cmdCT.Parameters.AddWithValue("@sl", sl);
                            cmdCT.Parameters.AddWithValue("@dongia", donGia);
                            cmdCT.Parameters.AddWithValue("@giamgia", giam);
                            cmdCT.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (isNewInvoice)
                            LoadDataForNewInvoice();
                        else
                            this.Close();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối CSDL lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy hóa đơn hiện tại?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoadDataForNewInvoice();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dtChiTiet.Rows.Count == 0 || dtChiTiet.Rows[0]["MaHang"] == DBNull.Value)
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("================== HÓA ĐƠN BÁN HÀNG ==================");
            sb.AppendLine($"Mã hóa đơn: {txtMaHoaDon.Text}");
            sb.AppendLine($"Ngày mua: {dtpNgayMua.Value:dd/MM/yyyy}");
            sb.AppendLine($"Khách hàng: {txtTenKhachHang.Text} - {txtDienThoai.Text}");
            sb.AppendLine($"Địa chỉ: {txtDiaChi.Text}");
            sb.AppendLine($"Nhân viên: {cboTenNhanVien.Text}");
            sb.AppendLine("------------------------------------------------------");
            sb.AppendLine($"{"Mã hàng",-10} {"Tên hàng",-20} {"SL",-5} {"Giảm%",-7} {"Thành tiền",-12}");
            foreach (DataRow row in dtChiTiet.Rows)
            {
                if (row.RowState == DataRowState.Deleted || row["MaHang"] == DBNull.Value) continue;
                sb.AppendLine($"{row["MaHang"],-10} {row["TenHang"],-20} {row["SoLuong"],-5} {row["GiamGia"],-7} {Convert.ToDecimal(row["ThanhTien"]).ToString("N0"),-12}");
            }
            sb.AppendLine($"Tổng tiền: {txtTongTien.Text}");
            sb.AppendLine($"Bằng chữ: {txtBangChu.Text}");
            sb.AppendLine("======================================================");
            MessageBox.Show(sb.ToString(), "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Có thể mở rộng gửi đến máy in thực tế
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maHD = txtTimMaHD.Text.Trim();
            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Nhập mã hóa đơn cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Tải thông tin hóa đơn lên form
            DataTable dtHD = Function.GetDataToTable("SELECT * FROM HoaDonBan WHERE MaHoaDonBan = @ma", new SqlParameter("@ma", maHD));
            if (dtHD.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isNewInvoice = false;
            currentMaHD = maHD;
            DataRow r = dtHD.Rows[0];
            txtMaHoaDon.Text = r["MaHoaDonBan"].ToString();
            dtpNgayMua.Value = Convert.ToDateTime(r["NgayBan"]);
            txtMaKhachHang.Text = r["MaKhachHang"].ToString();

            // Lấy thông tin khách hàng
            DataTable dtKH = Function.GetDataToTable("SELECT TenKhachHang, DiaChi, SoDienThoai FROM KhachHang WHERE MaKhachHang = @ma", new SqlParameter("@ma", r["MaKhachHang"]));
            if (dtKH.Rows.Count > 0)
            {
                txtTenKhachHang.Text = dtKH.Rows[0]["TenKhachHang"].ToString();
                txtDiaChi.Text = dtKH.Rows[0]["DiaChi"].ToString();
                txtDienThoai.Text = dtKH.Rows[0]["SoDienThoai"].ToString();
            }
            cboMaNhanVien.SelectedValue = r["MaNhanVien"].ToString();

            // Lấy chi tiết hóa đơn
            DataTable dtCT = Function.GetDataToTable(@"SELECT ct.MaSanPham, sp.TenSanPham, ct.SoLuong, ct.GiamGia, 
                                                              ct.SoLuong * ct.DonGia * (1 - ct.GiamGia/100) AS ThanhTien
                                                       FROM ChiTietHoaDonBan ct
                                                       INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                                                       WHERE ct.MaHoaDonBan = @ma", new SqlParameter("@ma", maHD));
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("MaHang", typeof(string));
            dtChiTiet.Columns.Add("TenHang", typeof(string));
            dtChiTiet.Columns.Add("SoLuong", typeof(int));
            dtChiTiet.Columns.Add("GiamGia", typeof(decimal));
            dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));
            foreach (DataRow rowCT in dtCT.Rows)
            {
                dtChiTiet.Rows.Add(rowCT["MaSanPham"], rowCT["TenSanPham"], rowCT["SoLuong"], rowCT["GiamGia"], rowCT["ThanhTien"]);
            }
            dgvChiTiet.DataSource = dtChiTiet;
            UpdateTotal();
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhanVien.SelectedValue != null)
            {
                string ma = cboMaNhanVien.SelectedValue.ToString();
                cboTenNhanVien.SelectedValue = ma;
            }
        }

        private void cboTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenNhanVien.SelectedValue != null)
            {
                string ma = cboTenNhanVien.SelectedValue.ToString();
                cboMaNhanVien.SelectedValue = ma;
            }
        }
    }
}