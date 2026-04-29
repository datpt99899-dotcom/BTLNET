using System;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh_Forms.Forms;

namespace QuanLyCuaHangMayTinh_Forms.Forms
{
    public partial class frmMenuDemo : Form
    {
        public frmMenuDemo()
        {
            InitializeComponent();
        }

        private string SelectedRole => cboVaiTro.SelectedItem?.ToString() ?? "Admin";

        private void btnLoaiSanPham_Click(object sender, EventArgs e)
        {
            new QuanLyCuaHangMayTinh.frmLoaiSanPham().ShowDialog();
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            new frmThuongHieu(SelectedRole).ShowDialog();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            new frmNhaCungCap(SelectedRole).ShowDialog();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            new frmSanPham(SelectedRole).ShowDialog();
        }
    }
}
