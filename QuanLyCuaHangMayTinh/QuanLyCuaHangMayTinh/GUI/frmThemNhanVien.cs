using System;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.DTO;
using QuanLyCuaHangMayTinh.BUS;

namespace QuanLyCuaHangMayTinh.GUI
{
    public partial class frmThemNhanVien : Form
    {
        public NhanVienDTO NhanVienMoi { get; private set; }
        public string MatKhauMoi { get; private set; }
        public frmThemNhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtVaiTro.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            NhanVienMoi = new NhanVienDTO
            {
                MaNhanVien = txtMaNV.Text.Trim(),
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = cboGioiTinh.Text,
                SoDienThoai = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                MaVaiTro = txtVaiTro.Text.Trim()
            };
            MatKhauMoi = txtMatKhau.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
