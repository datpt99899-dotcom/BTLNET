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
            string sql = @"SELECT nv.MaNhanVien, nv.HoTen, vt.TenVaiTro
                           FROM NhanVien nv
                           JOIN VaiTro vt ON nv.MaVaiTro = vt.MaVaiTro
                           WHERE nv.MaNhanVien = @MaNV";
            DataTable dt = Function.GetDataToTable(sql,
                new System.Data.SqlClient.SqlParameter("@MaNV", maNV));
            if (dt.Rows.Count > 0)
            {
                txtMaNV.Text = dt.Rows[0]["MaNhanVien"].ToString();
                txtHoTen.Text = dt.Rows[0]["HoTen"].ToString();
                txtChucVu.Text = dt.Rows[0]["TenVaiTro"].ToString();
            }
        }
    }
}
