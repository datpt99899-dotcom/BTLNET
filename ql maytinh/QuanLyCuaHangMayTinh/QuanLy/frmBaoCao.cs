using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void rdoKhoang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoKhoang.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                mskNgay.Enabled = false;
                PanelTime.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void rdoNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNgay.Checked)
            {
                mskNgay.Enabled = true;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                PanelTime.Enabled = false;
            }
            else
            {
                mskNgay.Enabled = false;
            }
        }

        private void ckbHD_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHD.Checked)
            {
                ckbSP.Checked = false;
                cboSP.Enabled = false;
            }
            else if (!ckbSP.Checked)
            {
                cboSP.Enabled = false;
            }

        }

        private void ckbSP_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSP.Checked)
            {
                ckbHD.Checked = false;
                cboSP.Enabled = true;
            }
            else
            {
                cboSP.Enabled = false;
            }
        }
        DataTable tblBCSP;
        DataTable tblBCHD;
        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            //TODO: This line of code loads data into the 'quanLyBanHangCaPheDataSet.HoaDonBan' table. You can move, or remove it, as needed.
          //  this.hoaDonBanTableAdapter.Fill(this.quanLyBanHangCaPheDataSet.HoaDonBan);
            btnInBC.Enabled = false;
            btnLammoi.Enabled = false;
            txtTongtien.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            mskNgay.Format = DateTimePickerFormat.Custom;
            mskNgay.CustomFormat = "dd/MM/yyyy";

            Function.FillCombo("Select MaSanPham, TenSanPham From SanPham", cboSP, "MaSanPham", "TenSanPham");
            cboSP.SelectedIndex = -1;
            // --- Thiết lập mặc định báo cáo hóa đơn theo ngày hôm nay ---
            ckbHD.Checked = true;
            rdoNgay.Checked = true;
            mskNgay.Value = DateTime.Now;

            // Gọi hàm hiển thị dữ liệu
            btnHienthi_Click_1(null, null);

        }
        private void Load_dGridHD(string sql)
        {
            tblBCHD = Function.GetDataToTable(sql);
            dataGridView.DataSource = tblBCHD;
            dataGridView.Columns[0].HeaderText = "Mã đơn bán hàng";
            dataGridView.Columns[1].HeaderText = "Ngày bán";
            dataGridView.Columns[2].HeaderText = "Tên nhân viên";
            dataGridView.Columns[3].HeaderText = "Tên khách hàng";
            dataGridView.Columns[4].HeaderText = "Giảm giá";
            dataGridView.Columns[5].HeaderText = "Tổng tiền";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 120;
            dataGridView.Columns[3].Width = 120;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 100;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            btnLammoi.Enabled = true;
            btnInBC.Enabled = true;
        }
        private void Load_dGridSP(string sql)
        {
            tblBCSP = Function.GetDataToTable(sql);
            dataGridView.DataSource = tblBCSP;
            dataGridView.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView.Columns[2].HeaderText = "Mã loại";
            dataGridView.Columns[3].HeaderText = "Số luợng";
            dataGridView.Columns[4].HeaderText = "Ngày bán";
            dataGridView.Columns[5].HeaderText = "Giá bán";
            dataGridView.Columns[6].HeaderText = "Thành tiền";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 100;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            btnLammoi.Enabled = true;
            btnInBC.Enabled = true;
        }
        private void ResetValues()
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            mskNgay.Value = DateTime.Now;
            ckbHD.Checked = false;
            ckbSP.Checked = false;
            rdoKhoang.Checked = false;
            rdoNgay.Checked = false;
            cboSP.Text = "";
            txtTongtien.Text = "";
            txtBangchu.Text = "";
            dataGridView.DataSource = null;
        }
        // Khai báo biến toàn cục trong Form
        string sqlBaoCao = "";
        string loaiBaoCao = "";
        private void btnHienthi_Click_1(object sender, EventArgs e)
        {
            string sql = "", sql1 = "";
            string ngay = mskNgay.Text.Trim();
            txtBangchu.Text = "Bằng chữ: ";

            if (!ckbHD.Checked && !ckbSP.Checked)
            {
                dataGridView.DataSource = null;
                txtTongtien.Text = "";
                MessageBox.Show("Vui lòng chọn một loại báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ckbHD.Checked)
            {
                // Báo cáo theo hóa đơn
                sql = "SELECT a.MaHoaDonBan, a.NgayBan, b.TenNhanVien, c.TenKhachHang, (d.MucKhuyenMai)*(a.TongTien) as GiamGia, a.TongTien " +
                      "FROM HoaDonBan a " +
                      "JOIN NhanVien b ON a.MaNhanVien = b.MaNhanVien " +
                      "JOIN KhachHang c ON a.MaKhachHang = c.MaKhachHang " +
                      "JOIN KhuyenMai d ON d.MaKhuyenMai = a.MaKhuyenMai " +
                      "WHERE a.Trangthai=1";

                sql1 = "FROM HoaDonBan Where Trangthai=1";

                if (rdoNgay.Checked && !string.IsNullOrWhiteSpace(ngay))
                {
                    if (!Function.IsDate(ngay))
                    {
                        MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string date = Function.ConvertDateTime(ngay);
                    sql += $" AND a.NgayBan = '{date}'";
                    sql1 += $" AND NgayBan = '{date}'";
                }

                if (rdoKhoang.Checked)
                {
                    string tuNgay = dateTimePicker1.Text;
                    string denNgay = dateTimePicker2.Text;

                    if (string.IsNullOrWhiteSpace(tuNgay) || string.IsNullOrWhiteSpace(denNgay))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ khoảng thời gian", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DateTime fromDate = DateTime.ParseExact(tuNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime toDate = DateTime.ParseExact(denNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (fromDate > toDate)
                    {
                        MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    sql += $" AND a.NgayBan BETWEEN '{Function.ConvertDateTime(tuNgay)}' AND '{Function.ConvertDateTime(denNgay)}'";
                    sql1 += $" AND NgayBan BETWEEN '{Function.ConvertDateTime(tuNgay)}' AND '{Function.ConvertDateTime(denNgay)}'";
                }

                Load_dGridHD(sql);
                double? tongTien = Function.GetFieldValues1("SELECT SUM(TongTien) " + sql1);
                txtTongtien.Text = tongTien.HasValue ? string.Format("{0:N0}", tongTien.Value) : "0";
                txtBangchu.Text += Function.ChuyenSoSangChu(txtTongtien.Text);

                // Lưu để in
                sqlBaoCao = sql;
                loaiBaoCao = "HD";
            }
            else if (ckbSP.Checked)
            {
                // Báo cáo theo sản phẩm
                sql = "SELECT a.MaSanPham, a.TenSanPham, a.MaLoai, c.SoLuong, b.NgayBan, a.GiaBan, c.ThanhTien " +
                      "FROM SanPham a " +
                      "JOIN ChiTietHoaDonBan c ON a.MaSanPham = c.MaSanPham " +
                      "JOIN HoaDonBan b ON c.MaHoaDonBan = b.MaHoaDonBan " +
                      "WHERE b.Trangthai=1";

                sql1 = "FROM SanPham a " +
                       "JOIN ChiTietHoaDonBan b ON a.MaSanPham = b.MaSanPham " +
                       "JOIN HoaDonBan c ON b.MaHoaDonBan = c.MaHoaDonBan " +
                       "WHERE c.Trangthai=1";

                if (rdoNgay.Checked && !string.IsNullOrWhiteSpace(ngay))
                {
                    if (!Function.IsDate(ngay))
                    {
                        MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string date = Function.ConvertDateTime(ngay);
                    sql += $" AND b.NgayBan = '{date}'";
                    sql1 += $" AND c.NgayBan = '{date}'";
                }

                if (rdoKhoang.Checked)
                {
                    string tuNgay = dateTimePicker1.Text;
                    string denNgay = dateTimePicker2.Text;

                    if (string.IsNullOrWhiteSpace(tuNgay) || string.IsNullOrWhiteSpace(denNgay))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ khoảng thời gian", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DateTime fromDate = DateTime.ParseExact(tuNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime toDate = DateTime.ParseExact(denNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (fromDate > toDate)
                    {
                        MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    sql += $" AND b.NgayBan BETWEEN '{Function.ConvertDateTime(tuNgay)}' AND '{Function.ConvertDateTime(denNgay)}'";
                    sql1 += $" AND c.NgayBan BETWEEN '{Function.ConvertDateTime(tuNgay)}' AND '{Function.ConvertDateTime(denNgay)}'";
                }

                if (cboSP.SelectedValue != null)
                {
                    sql += $" AND a.MaSanPham = N'{cboSP.SelectedValue}'";
                    sql1 += $" AND a.MaSanPham = N'{cboSP.SelectedValue}'";
                }

                Load_dGridSP(sql);
                double? tongTien = Function.GetFieldValues1("SELECT SUM(b.ThanhTien) " + sql1);
                txtTongtien.Text = tongTien.HasValue ? string.Format("{0:N0}", tongTien.Value) : "0";
                txtBangchu.Text += Function.ChuyenSoSangChu(txtTongtien.Text);

                btnLammoi.Enabled = true;
                btnInBC.Enabled = true;

                // Lưu để in
                sqlBaoCao = sql;
                loaiBaoCao = "SP";
            }
        }

        private void btnLammoi_Click_1(object sender, EventArgs e)
        {

            cboSP.Text = "";
            txtTongtien.Text = "";
            mskNgay.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            txtBangchu.Text = "Bằng chữ: ";
            cboSP.Enabled = true;
            btnInBC.Enabled = false;
            btnLammoi.Enabled = false;
            btnHienthi.Enabled = true;
            rdoNgay.Checked = false;
            rdoKhoang.Checked = false;
            rdoNgay.Enabled = true;
            rdoKhoang.Enabled = true;
            dataGridView.DataSource = null;
        }
        private void btnInBC_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(loaiBaoCao) || string.IsNullOrEmpty(sqlBaoCao))
            {
                MessageBox.Show("Vui lòng hiển thị báo cáo trước khi in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            COMExcel.Worksheet exSheet = exBook.Worksheets[1];
            COMExcel.Range exRange;
            int row = 1;
            int colCount = (loaiBaoCao == "HD") ? 6 : 7;

            exSheet.Cells.Font.Name = "Times New Roman";

            // Tiêu đề chính
            exRange = exSheet.Range[exSheet.Cells[row, 1], exSheet.Cells[row, colCount]];
            exRange.MergeCells = true;
            exRange.Font.Size = 14;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "NEFT COFFEE - BÁO CÁO DOANH THU";
            row += 2;

            // Thời gian lọc
            string thoiGianLoc = "";
            if (rdoNgay.Checked && Function.IsDate(mskNgay.Text.Trim()))
                thoiGianLoc = "Ngày báo cáo: " + mskNgay.Text.Trim();
            else if (rdoKhoang.Checked)
                thoiGianLoc = "Từ ngày: " + dateTimePicker1.Text + " đến ngày: " + dateTimePicker2.Text;

            exRange = exSheet.Range[exSheet.Cells[row, 1], exSheet.Cells[row, colCount]];
            exRange.MergeCells = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Font.Italic = true;
            exRange.Value = thoiGianLoc;
            row += 2;

            double tongTien = 0;
            int dataStartRow = row;

            if (loaiBaoCao == "HD")
            {
                DataTable tblHD = Function.GetDataToTable(sqlBaoCao);

                // Header
                exRange = exSheet.Range[exSheet.Cells[row, 1], exSheet.Cells[row, 6]];
                exRange.Font.Bold = true;
                exRange.Value2 = new object[,] { { "Mã HĐ", "Ngày bán", "Nhân viên", "Khách hàng", "Giảm giá", "Tổng tiền" } };
                row++;

                // Dữ liệu
                foreach (DataRow r in tblHD.Rows)
                {
                    exSheet.Cells[row, 1] = r["MaHoaDonBan"];
                    exSheet.Cells[row, 2] = Convert.ToDateTime(r["NgayBan"]).ToString("dd/MM/yyyy");
                    exSheet.Cells[row, 3] = r["TenNhanVien"];
                    exSheet.Cells[row, 4] = r["TenKhachHang"];
                    exSheet.Cells[row, 5] = r["GiamGia"];
                    double tien = Convert.ToDouble(r["TongTien"]);
                    exSheet.Cells[row, 6] = tien.ToString("N0");
                    tongTien += tien;
                    row++;
                }
            }
            else if (loaiBaoCao == "SP")
            {
                DataTable tblSP = Function.GetDataToTable(sqlBaoCao);

                // Header
                exRange = exSheet.Range[exSheet.Cells[row, 1], exSheet.Cells[row, 7]];
                exRange.Font.Bold = true;
                exRange.Value2 = new object[,] { { "Mã SP", "Tên SP", "Mã loại", "Số lượng", "Ngày bán", "Giá bán", "Thành tiền" } };
                row++;

                // Dữ liệu
                foreach (DataRow r in tblSP.Rows)
                {
                    exSheet.Cells[row, 1] = r["MaSanPham"];
                    exSheet.Cells[row, 2] = r["TenSanPham"];
                    exSheet.Cells[row, 3] = r["MaLoai"];
                    exSheet.Cells[row, 4] = r["SoLuong"];
                    exSheet.Cells[row, 5] = Convert.ToDateTime(r["NgayBan"]).ToString("dd/MM/yyyy");
                    exSheet.Cells[row, 6] = Convert.ToDouble(r["GiaBan"]).ToString("N0");
                    double tien = Convert.ToDouble(r["ThanhTien"]);
                    exSheet.Cells[row, 7] = tien.ToString("N0");
                    tongTien += tien;
                    row++;
                }
            }

            // Tổng tiền
            exRange = exSheet.Cells[row, colCount - 1];
            exRange.Font.Bold = true;
            exRange.Value = "Tổng tiền:";
            exSheet.Cells[row, colCount] = tongTien.ToString("N0");

            // Bằng chữ
            row += 2;
            exRange = exSheet.Range[exSheet.Cells[row, 1], exSheet.Cells[row, colCount]];
            exRange.MergeCells = true;
            exRange.Font.Italic = true;
            exRange.Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tongTien.ToString());

            // Ngày ký
            row += 3;
            exRange = exSheet.Range[exSheet.Cells[row, colCount - 2], exSheet.Cells[row, colCount]];
            exRange.MergeCells = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "Hà Nội, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

            row++;
            exRange = exSheet.Range[exSheet.Cells[row, colCount - 2], exSheet.Cells[row, colCount]];
            exRange.MergeCells = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "Người lập báo cáo";

            exSheet.Name = "BaoCaoDoanhThu";
            exApp.Visible = true;
        }
    }
}