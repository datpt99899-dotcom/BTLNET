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

namespace QuanLyCuaHangMayTinh
{
    public partial class frmBaocaohoadon_Nhanvien : Form
    {
        public frmBaocaohoadon_Nhanvien()
        {
            InitializeComponent();
        }
        //ham trang thai
        private int trangthai()
        {
            if (cbTinhtrangthanhtoan.SelectedIndex == 0)
            {
                return 2;
            }
            else if (cbTinhtrangthanhtoan.SelectedIndex == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        private void frmBaocaohoadon_Nhanvien_Load(object sender, EventArgs e)
        {
            string sql = BuildSqlHoadon();
            LoadDataGridView(sql);
            txtMakhuyenmai.Enabled = false;
            txtMahoadon.Enabled = false;
            txtMuckhuyenmai.Enabled = false;
            txtTinhtrang.Enabled = false;
            txtTonghoadon.Enabled = false;
            mskNgayban.Enabled = false;

            txtTongtien.Enabled = false;
            cbTinhtrangthanhtoan.SelectedIndex = 0;
            trangthai();


        }
        //load dữ liệu lên datagridview
        DataTable dtHoaDon;

        private string BuildSqlHoadon()
        {
            string sql =
                "SELECT hdb.Ngayban, hdb.MaHoaDonBan, nv.TenNhanVien, hdb.MaBan, km.MucKhuyenMai, hdb.TongTien , " +
                "CASE WHEN hdb.TrangThai = 0 THEN N'Chưa thanh toán' " +
                "     WHEN hdb.TrangThai = 1 THEN N'Đã thanh toán' " +
                "     ELSE N'Không xác định' END AS TrangThai, " +
                "ht.TenHinhThuc " +
                "FROM HoaDonBan hdb " +
                "LEFT JOIN NhanVien nv ON hdb.MaNhanVien = nv.MaNhanVien " +
                "LEFT JOIN KhuyenMai km ON hdb.MaKhuyenMai = km.MaKhuyenMai " +
                "LEFT JOIN HinhThuc ht ON hdb.HinhThuc = ht.MaHinhThuc " +
                "WHERE 1 = 1 ";

            // Thêm điều kiện ngày nếu có chọn ngày
            DateTime selectedDate = Time.Value;
            string ngay = selectedDate.ToString("yyyy-MM-dd");
            sql += $" AND CONVERT(date, hdb.NgayBan) = '{ngay}'";

            // Thêm điều kiện trạng thái nếu không chọn "Tất cả"
            if (cbTinhtrangthanhtoan.SelectedIndex != 0)
            {
                sql += $" AND hdb.TrangThai = {trangthai()}";
            }

            return sql;
        }



        private void LoadDataGridView(string sql)
        {
            dtHoaDon = Function.GetDataToTable(sql);
            dGridBaocaohoadon.DataSource = dtHoaDon;

            //do dl tu bang vao datagridview

            dGridBaocaohoadon.Columns[0].HeaderText = "Ngày hóa đơn";
            dGridBaocaohoadon.Columns[1].HeaderText = "Mã hóa đơn";
            dGridBaocaohoadon.Columns[2].HeaderText = "Tên nhân viên";
            dGridBaocaohoadon.Columns[3].HeaderText = "Mã bàn";
            dGridBaocaohoadon.Columns[4].HeaderText = "Mức khuyến mãi";
            dGridBaocaohoadon.Columns[5].HeaderText = "Tổng tiền";
            dGridBaocaohoadon.Columns[6].HeaderText = "Trạng thái";
            dGridBaocaohoadon.Columns[7].HeaderText = "Hình thức";



            dGridBaocaohoadon.Columns[0].Width = 100;
            dGridBaocaohoadon.Columns[1].Width = 50;
            dGridBaocaohoadon.Columns[2].Width = 150;
            dGridBaocaohoadon.Columns[3].Width = 100;
            dGridBaocaohoadon.Columns[4].Width = 100;
            dGridBaocaohoadon.Columns[5].Width = 100;
            dGridBaocaohoadon.Columns[6].Width = 100;
            dGridBaocaohoadon.Columns[7].Width = 100;

            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dGridBaocaohoadon.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dGridBaocaohoadon.EditMode = DataGridViewEditMode.EditProgrammatically;
            //Tinh tong hoa don va tong tien
            decimal tonghoadon = 0;
            decimal tongtien = 0;

            for (int i = 0; i < dGridBaocaohoadon.Rows.Count; i++)
            {
                tonghoadon += 1;

                var value = dGridBaocaohoadon.Rows[i].Cells["TongTien"].Value;
                if (value != null && decimal.TryParse(value.ToString(), out decimal tien))
                {
                    tongtien += tien;
                }
                else
                {
                    tongtien += 0;
                }
            }
            txtTonghoadon.Text = tonghoadon.ToString();
            txtTongtien.Text = tongtien.ToString();
        }

        DataTable tblChitietHoadon;
        private void Load_dGridChitietHoadon(string ma)
        {
            string sql = "select c.TenSanPham, b.SoLuong, c.GiaBan, b.ThanhTien FROM HoaDonBan a " +
                         "join ChiTietHoaDonBan b on a.MaHoaDonBan=b.MaHoaDonBan " + " join SanPham c on b.MaSanPham=c.MaSanPham " +
                         "WHERE b.MaHoaDonBan = '" + ma + "'";

            tblChitietHoadon = Function.GetDataToTable(sql);
            dGridChitiethoadon.DataSource = tblChitietHoadon;
            dGridChitiethoadon.Columns[0].HeaderText = "Tên Sản phẩm";
            dGridChitiethoadon.Columns[1].HeaderText = "Số lượng";
            dGridChitiethoadon.Columns[2].HeaderText = "Đơn giá";
            dGridChitiethoadon.Columns[3].HeaderText = "Thành tiền";
            dGridChitiethoadon.Columns[0].Width = 200;
            dGridChitiethoadon.Columns[1].Width = 50;
            dGridChitiethoadon.Columns[2].Width = 100;
            dGridChitiethoadon.Columns[3].Width = 100;

            dGridChitiethoadon.AllowUserToAddRows = false;
            dGridChitiethoadon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dGridBaocaohoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dGridBaocaohoadon_Click(object sender, EventArgs e)
        {
            if (dGridBaocaohoadon.CurrentRow == null)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string ma;
            ma = dGridBaocaohoadon.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();
            Load_dGridChitietHoadon(ma);
            txtMahoadon.Text = dGridBaocaohoadon.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();
            txtMuckhuyenmai.Text = dGridBaocaohoadon.CurrentRow.Cells["MucKhuyenMai"].Value.ToString();
            txtTinhtrang.Text = dGridBaocaohoadon.CurrentRow.Cells["TrangThai"].Value.ToString();
            string maKhuyenmai = Function.GetFieldValues("SELECT MaKhuyenMai FROM HoaDonBan WHERE MaHoaDonBan = '" + ma + "'");
            txtMakhuyenmai.Text = maKhuyenmai;
            mskNgayban.Text = Convert.ToDateTime(dGridBaocaohoadon.CurrentRow.Cells["NgayBan"].Value).ToString("dd/MM/yyyy");



        }
        //reset
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
            string sql = BuildSqlHoadon();
            ResetValues();
            LoadDataGridView(sql);

        }

        private void btnHuy_Click(object sender, EventArgs e)

        {
            //Nhap password huy
            string pass = txtPass.Text;
            if(pass != "huyhoadon") {
                MessageBox.Show("Mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //kiểm tra tình trạng bàn đó
            string maban = dGridBaocaohoadon.CurrentRow.Cells["MaBan"].Value.ToString();
            string sqlMaban = "SELECT Tinhtrang FROM Ban WHERE MaBan = '" + maban + "'";
            int trangthai = Convert.ToInt16(Function.GetFieldValues(sqlMaban));
            if (trangthai == 1)
            {
                MessageBox.Show("Bàn này đang được sử dụng, không thể hủy hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //chuyen trang thai ve 0
            if (dGridBaocaohoadon.CurrentRow == null)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DialogResult.No == MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            string ma;
            ma = dGridBaocaohoadon.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();
            string sql = "UPDATE HoaDonBan SET TrangThai = 0 WHERE MaHoaDonBan = '" + ma + "'";
            Function.RunSql(sql);
            //load lai du lieu
            MessageBox.Show("Hủy hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetValues();
            LoadDataGridView(sql);

        }

        private void cbTinhtrangthanhtoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = BuildSqlHoadon();
            ResetValues();
            LoadDataGridView(sql);
        }
    }
}
