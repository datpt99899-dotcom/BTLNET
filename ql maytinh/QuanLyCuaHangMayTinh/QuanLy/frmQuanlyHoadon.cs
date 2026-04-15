using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Globalization;


namespace QuanLyCuaHangMayTinh
{
    public partial class frmQuanlyHoadon : Form
    {
        public frmQuanlyHoadon()
        {
            InitializeComponent();
        }
        DataTable tblHoadonBan;
        private void frmQuanlyHoadon_Load(object sender, EventArgs e)
        {
            Load_dGridHoadon();
            dGridDsHD.DataSource = null;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            //hien hoa don ngay hom day
            DateTime today = DateTime.Now;
            dateTimePicker1.Value = new DateTime(today.Year, today.Month, today.Day);
            dateTimePicker2.Value = new DateTime(today.Year, today.Month, today.Day);
            Load_dGridHoadon();



        }
        private void Load_dGridHoadon()
        {
            string sql;
            sql = "SELECT a.MaHoaDonBan, a.NgayBan, b.TenNhanVien, c.TenKhachHang, a.MaBan, a.MaKhuyenMai, a.TongTien FROM HoaDonBan a join NhanVien b on a.MaNhanVien=b.MaNhanVien join KhachHang c on a.MaKhachHang=c.MaKhachHang";
            tblHoadonBan = Function.GetDataToTable(sql);
            dGridDsHD.DataSource = tblHoadonBan;
            dGridDsHD.Columns[0].HeaderText = "Mã đơn bán hàng";
            dGridDsHD.Columns[1].HeaderText = "Ngày bán";
            dGridDsHD.Columns[2].HeaderText = "Tên nhân viên";
            dGridDsHD.Columns[3].HeaderText = "Tên khách hàng";
            dGridDsHD.Columns[4].HeaderText = "Mã bàn";
            dGridDsHD.Columns[5].HeaderText = "Mã khuyến mãi";
            dGridDsHD.Columns[6].HeaderText = "Tổng tiền";
            dGridDsHD.Columns[0].Width = 100;
            dGridDsHD.Columns[1].Width = 100;
            dGridDsHD.Columns[2].Width = 120;
            dGridDsHD.Columns[3].Width = 120;
            dGridDsHD.Columns[4].Width = 50;
            dGridDsHD.Columns[5].Width = 100;
            dGridDsHD.Columns[6].Width = 100;
            dGridDsHD.AllowUserToAddRows = false;
            dGridDsHD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        DataTable tblChitietHoadon;
        private void Load_dGridChitietHoadon(string ma)
        {
            string sql = "select b.MaHoaDonBan, c.TenSanPham, b.SoLuong, c.GiaBan, ThanhTien FROM HoaDonBan a " +
                         "join ChiTietHoaDonBan b on a.MaHoaDonBan=b.MaHoaDonBan " + " join SanPham c on b.MaSanPham=c.MaSanPham " +
                         "WHERE b.MaHoaDonBan = '" + ma + "'";

            tblChitietHoadon = Function.GetDataToTable(sql);
            dGridChitietHD.DataSource = tblChitietHoadon;
            dGridChitietHD.Columns["MaHoaDonBan"].Visible = false;
            dGridChitietHD.Columns[1].HeaderText = "Tên Sản phẩm";
            dGridChitietHD.Columns[2].HeaderText = "Số lượng";
            dGridChitietHD.Columns[3].HeaderText = "Đơn giá";
            dGridChitietHD.Columns[4].HeaderText = "Thành tiền";
            dGridChitietHD.Columns[1].Width = 100;
            dGridChitietHD.Columns[2].Width = 50;
            dGridChitietHD.Columns[3].Width = 100;
            dGridChitietHD.Columns[4].Width = 100;
            dGridChitietHD.AllowUserToAddRows = false;
            dGridChitietHD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dGridDsHD_Click(object sender, EventArgs e)
        {  //kiem tra du lieu
            if(tblHoadonBan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string ma;
            ma = dGridDsHD.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();
            Load_dGridChitietHoadon(ma);

        }
        #region methods
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dGridDsHD.DataSource = Function.GetBillListByDate(checkIn, checkOut);
        }
        #endregion

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và xóa
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false; // Cho phép nhập
            }
            else
            {
                e.Handled = true; // Không cho phép nhập ký tự khác
            }
        }

        private void BtnThongke_Click_1(object sender, EventArgs e)
        {
            dGridChitietHD.DataSource = null;
            string tuNgay = dateTimePicker1.Text;
            string denNgay = dateTimePicker2.Text;

            DateTime fromDate = DateTime.ParseExact(tuNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime toDate = DateTime.ParseExact(denNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sdt = txtsdt.Text.Trim();

            if (sdt == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu ý: nếu số điện thoại lưu trong DB có dấu '0' đầu thì cần giữ nguyên
            string sql = "SELECT a.MaHoaDonBan, a.NgayBan, a.TongTien, b.TenKhachHang, c.TenNhanVien " +
                         "FROM HoaDonBan AS a " +
                         "JOIN KhachHang AS b ON a.MaKhachHang = b.MaKhachHang " +
                         "JOIN NhanVien AS c ON a.MaNhanVien = c.MaNhanVien " +
                         "WHERE b.SoDienThoai = N'" + sdt + "'";

            DataTable dt = Function.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào cho số điện thoại này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dGridDsHD.DataSource = dt;
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (tblChitietHoadon == null || tblChitietHoadon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu chi tiết hóa đơn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            COMExcel.Worksheet exSheet = exBook.Worksheets[1];
            COMExcel.Range exRange;
            string sql;
            DataTable tblThongtinHD, tblThongtinHang;

            int currentRow = 1;
            exSheet.Cells.Font.Name = "Times New Roman"; // Font toàn sheet

            // Header - Tên quán
            exRange = exSheet.Cells[currentRow, 1];
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].Font.Size = 10;
            exRange.Range["A1:B1"].Font.Name = "Times New Roman";
            exRange.Range["A1:B1"].Font.Bold = true;
            exRange.Range["A1:B1"].Font.ColorIndex = 5;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Neft Coffee";

            // Địa chỉ
            exRange = exSheet.Cells[currentRow, 1];
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].Font.Size = 10;
            exRange.Range["A2:B2"].Font.Name = "Times New Roman";
            exRange.Range["A2:B2"].Font.Bold = true;
            exRange.Range["A2:B2"].Font.ColorIndex = 5;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Thanh Xuân - Hà Nội";

            // Điện thoại
            exRange = exSheet.Cells[currentRow, 1];
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].Font.Size = 10;
            exRange.Range["A3:B3"].Font.Name = "Times New Roman";
            exRange.Range["A3:B3"].Font.Bold = true;
            exRange.Range["A3:B3"].Font.ColorIndex = 5;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (+84)384336855";
            currentRow += 2;

            // Tiêu đề hóa đơn
            currentRow = 5; // Cố định tại dòng 6
            exRange = exSheet.Range["C" + currentRow + ":E" + currentRow];
            exRange.MergeCells = true;
            exRange.Font.Size = 16;
            exRange.Font.Name = "Times New Roman"; // Đảm bảo đồng bộ font
            exRange.Font.Bold = true;
            exRange.Font.ColorIndex = 3; // Màu đỏ
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "HÓA ĐƠN BÁN";
            currentRow += 2;

            // Lấy thông tin hóa đơn
            string ma = dGridDsHD.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();
            sql = "SELECT a.MaHoaDonBan, a.NgayBan, a.TongTien, b.TenKhachHang, b.SoDienThoai, c.TenNhanVien FROM HoaDonBan AS a, KhachHang AS b, NhanVien AS c WHERE a.MaHoaDonBan = N'" + ma + "' AND a.MaKhachHang = b.MaKhachHang AND a.MaNhanVien = c.MaNhanVien";
            tblThongtinHD = Function.GetDataToTable(sql);

            // Thông tin khách hàng
            exSheet.Cells[currentRow, 2].Value = "Mã hóa đơn:";
            exSheet.Range["C" + currentRow + ":E" + currentRow].MergeCells = true;
            exSheet.Cells[currentRow, 3].Value = tblThongtinHD.Rows[0][0].ToString();
            currentRow++;

            exSheet.Cells[currentRow, 2].Value = "Khách hàng:";
            exSheet.Range["C" + currentRow + ":E" + currentRow].MergeCells = true;
            exSheet.Cells[currentRow, 3].Value = tblThongtinHD.Rows[0][3].ToString();
            currentRow++;

            exSheet.Cells[currentRow, 2].Value = "Điện thoại:";
            exRange = exSheet.Range["C" + currentRow + ":E" + currentRow];
            exRange.MergeCells = true;
            exRange.NumberFormat = "@";
            exRange.Value = tblThongtinHD.Rows[0][4].ToString();
            currentRow += 2;

            // Dòng tiêu đề bảng hàng hóa
            exRange = exSheet.Range["A" + currentRow + ":F" + currentRow];
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value2 = new object[,] { { "STT", "Tên hàng", "Số lượng", "Đơn giá", "Giảm giá", "Thành tiền" } };
            currentRow++;

            // Lấy chi tiết mặt hàng
            sql = "SELECT b.TenSanPham, a.SoLuong, b.GiaBan, c.MaKhuyenMai, a.ThanhTien " +
                  "FROM ChiTietHoaDonBan AS a , SanPham AS b, HoaDonBan as c WHERE a.MaHoaDonBan = N'" +
                  ma + "' AND a.MaSanPham = b.MaSanPham AND a.MaHoaDonBan=c.MaHoaDonBan";
            tblThongtinHang = Function.GetDataToTable(sql);

            for (int i = 0; i < tblThongtinHang.Rows.Count; i++)
            {
                exSheet.Cells[currentRow, 1] = i + 1;
                for (int j = 0; j < tblThongtinHang.Columns.Count; j++)
                {
                    exSheet.Cells[currentRow, j + 2] = tblThongtinHang.Rows[i][j].ToString();
                }
                currentRow++;
            }

            // Tính tổng từ cột Thành tiền
            double tongTien = 0;
            foreach (DataRow row in tblThongtinHang.Rows)
            {
                if (!Convert.IsDBNull(row["ThanhTien"]))
                {
                    tongTien += Convert.ToDouble(row["ThanhTien"]);
                }
            }

            // Tổng tiền
            exSheet.Cells[currentRow, 5].Font.Bold = true;
            exSheet.Cells[currentRow, 5].Value2 = "Tổng tiền:";
            exSheet.Cells[currentRow, 6].Font.Bold = true;
            exSheet.Cells[currentRow, 6].Value2 = tongTien.ToString("N0"); // Có phân cách nghìn
            currentRow++;

            // Bằng chữ
            exRange = exSheet.Range["A" + currentRow + ":F" + currentRow];
            exRange.MergeCells = true;
            exRange.Font.Bold = true;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tongTien.ToString());
            currentRow += 2;


            // Ngày tháng và nhân viên căn phải
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);

            exRange = exSheet.Range["D" + currentRow + ":F" + currentRow];
            exRange.MergeCells = true;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            currentRow++;

            exRange = exSheet.Range["D" + currentRow + ":F" + currentRow];
            exRange.MergeCells = true;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Value = "Nhân viên bán hàng";
            currentRow++;

            exRange = exSheet.Range["D" + currentRow + ":F" + currentRow];
            exRange.MergeCells = true;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Value = tblThongtinHD.Rows[0][5];


            // Tên sheet
            exSheet.Name = "Đơn bán hàng";
            exApp.Visible = true;
        }
    }
}
