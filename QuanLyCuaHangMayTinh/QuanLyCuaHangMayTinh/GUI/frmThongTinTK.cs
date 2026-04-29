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
    public partial class frmThongTinTK: Form
    {
        public frmThongTinTK()
        {
            InitializeComponent();
        }

        private void frmThongTinTK_Load(object sender, EventArgs e)
        {
            string maNV = StaticData.MaNV;
            string sql = "select nv.MaNhanVien, nv.TenNhanVien, cv.TenChucVu from NhanVien nv join ChucVu cv on nv.MaChucVu = cv.MaChucVu where nv.MaNhanVien = '" + maNV + "'";
            DataTable dt = Function.GetDataToTable(sql);
            if (dt.Rows.Count > 0)
            {
                txtMaNV.Text = dt.Rows[0]["MaNhanVien"].ToString();
                txtHoTen.Text = dt.Rows[0]["TenNhanVien"].ToString();
                txtChucVu.Text = dt.Rows[0]["TenChucVu"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
