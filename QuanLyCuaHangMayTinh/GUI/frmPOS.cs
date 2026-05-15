using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;
using QuanLyCuaHangMayTinh.DTO;

namespace QuanLyCuaHangMayTinh
{
    /// <summary>
    /// Form bán hàng tại quầy (POS). Dùng HoaDonBUS.TaoHoaDon (transaction).
    /// Trigger trg_BanHang_GiamTon TỰ kiểm tra tồn kho và TỰ trừ SoLuongTon —
    /// nếu không đủ tồn, trigger RAISERROR + ROLLBACK.
    /// </summary>
    public partial class frmPOS : Form
    {
        private readonly HoaDonBUS _hoaDonBus = new HoaDonBUS();
        private readonly DataTable cartTable = new DataTable();
        private string maKhachHang = "KH001";

        public frmPOS()
        {
            InitializeComponent();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            InitCart();
            LoadSanPham();
            LoadKhachHang();

            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.ReadOnly = true;
            dgvCart.AllowUserToAddRows = false;

            // Đăng ký event cho 2 nút Designer không gắn sẵn
            btnHuyDon.Click += btnHuyDon_Click;
            btnThanhVien.Click += btnThanhVien_Click;
        }

        private void InitCart()
        {
            if (cartTable.Columns.Count == 0)
            {
                cartTable.Columns.Add("MaSanPham");
                cartTable.Columns.Add("TenSanPham");
                cartTable.Columns.Add("GiaBan", typeof(decimal));
                cartTable.Columns.Add("SoLuong", typeof(int));
                cartTable.Columns.Add("ThanhTien", typeof(decimal), "GiaBan * SoLuong");
            }
            dgvCart.DataSource = cartTable;
            foreach (DataGridViewColumn col in dgvCart.Columns) col.ReadOnly = true;
            if (dgvCart.Columns.Contains("SoLuong")) dgvCart.Columns["SoLuong"].ReadOnly = false;
        }

        private void LoadSanPham()
        {
            try
            {
                string sql = @"
                    SELECT MaSanPham, TenSanPham, GiaBan, SoLuongTon
                    FROM   SanPham
                    WHERE  (TenSanPham LIKE @kw OR MaSanPham LIKE @kw)
                      AND  SoLuongTon > 0
                    ORDER  BY TenSanPham";
                var dt = Function.GetDataToTable(sql,
                    new SqlParameter("@kw", "%" + (txtSearch?.Text ?? "") + "%"));
                dgvSanPham.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message); }
        }

        private void LoadKhachHang()
        {
            // Đơn giản: mặc định KH001. Có thể mở rộng combobox sau.
            maKhachHang = "KH001";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadSanPham();

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string ma  = dgvSanPham.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString();
            string ten = dgvSanPham.Rows[e.RowIndex].Cells["TenSanPham"].Value.ToString();
            decimal gia = Convert.ToDecimal(dgvSanPham.Rows[e.RowIndex].Cells["GiaBan"].Value);
            int ton = Convert.ToInt32(dgvSanPham.Rows[e.RowIndex].Cells["SoLuongTon"].Value);

            DataRow found = cartTable.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaSanPham") == ma);
            if (found == null)
            {
                if (ton > 0) cartTable.Rows.Add(ma, ten, gia, 1);
                else MessageBox.Show("Hết hàng!");
            }
            else
            {
                int slMoi = found.Field<int>("SoLuong") + 1;
                if (slMoi <= ton) found["SoLuong"] = slMoi;
                else MessageBox.Show("Không đủ hàng (tồn: " + ton + ")");
            }
            TinhTong();
        }

        private void TinhTong()
        {
            decimal tong = 0;
            if (cartTable.Rows.Count > 0)
                tong = cartTable.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));

            decimal giam = 0;
            decimal.TryParse((txtGiamGia?.Text ?? "0").Replace("%", ""), out giam);
            decimal thanhToan = tong - (tong * giam / 100);
            lblTongTien.Text = thanhToan.ToString("N0") + " VNĐ";
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e) => TinhTong();

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal tongHang = cartTable.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));
                decimal phanTramGiam = 0;
                decimal.TryParse((txtGiamGia?.Text ?? "0").Replace("%", ""), out phanTramGiam);
                decimal tienGiam = tongHang * phanTramGiam / 100;
                decimal tongThanhToan = tongHang - tienGiam;

                string maNV = string.IsNullOrEmpty(StaticData.MaNV) ? "NV003" : StaticData.MaNV;
                string maHD = _hoaDonBus.GenerateMaHoaDon();

                var hd = new HoaDonBanDTO
                {
                    MaHoaDonBan = maHD,
                    NgayBan = DateTime.Now,
                    MaKhachHang = maKhachHang,
                    MaNhanVien = maNV,
                    TienGiam = tienGiam,
                    TongTien = tongThanhToan,
                    HinhThucThanhToan = "Tiền mặt",
                    TrangThai = "Hoàn thành"
                };

                var ct = cartTable.AsEnumerable().Select(r => new ChiTietHoaDonDTO
                {
                    MaHoaDonBan = maHD,
                    MaSanPham   = r.Field<string>("MaSanPham"),
                    SoLuong     = r.Field<int>("SoLuong"),
                    DonGia      = r.Field<decimal>("GiaBan")
                }).ToList();

                var result = _hoaDonBus.TaoHoaDon(hd, ct);
                if (result.ok)
                {
                    MessageBox.Show($"Thanh toán thành công!\nMã hóa đơn: {maHD}\nTổng tiền: {tongThanhToan:N0} VNĐ",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + result.msg, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvCart.Columns[e.ColumnIndex].Name == "colDelete")
            {
                cartTable.Rows.RemoveAt(e.RowIndex);
                TinhTong();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cartTable.Clear();
            if (txtSearch != null) txtSearch.Clear();
            if (txtGiamGia != null) txtGiamGia.Text = "0";
            TinhTong();
            LoadSanPham();
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var result = MessageBox.Show("Bạn có chắc muốn hủy đơn hàng hiện tại?",
                "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cartTable.Clear();
                if (txtGiamGia != null) txtGiamGia.Text = "0";
                if (txtSDT != null) txtSDT.Clear();
                if (txtTenKH != null) txtTenKH.Clear();
                TinhTong();
                MessageBox.Show("Đã hủy đơn hàng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThanhVien_Click(object sender, EventArgs e)
        {
            // Mở dialog thêm khách hàng nhanh (cho khách thành viên mới)
            string sdt = txtSDT?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại của khách hàng để tra cứu / thêm thành viên.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tra cứu thành viên theo SĐT
                var dt = Function.GetDataToTable(
                    "SELECT TenKhachHang FROM KhachHang WHERE SoDienThoai = @sdt",
                    new System.Data.SqlClient.SqlParameter("@sdt", sdt));

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (txtTenKH != null) txtTenKH.Text = dt.Rows[0]["TenKhachHang"].ToString();
                    MessageBox.Show("Đã tra cứu thành viên.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa có thành viên này. Vui lòng nhập tên khách hàng và thanh toán để hệ thống tự thêm.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
