using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyCuaHangMayTinh.BUS;
using QuanLyCuaHangMayTinh.DAL;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Form tìm kiếm phiếu nhập kho — filter theo nhiều tiêu chí:
    ///   - Mã phiếu nhập (textBox4)
    ///   - Tháng (txtTimKiem) + Năm (textBox2)
    ///   - Mã NCC (textBox1) + Mã NV (textBox3)
    /// Hiển thị danh sách trong dgvDSPhieuNhap, tổng tiền lọc trong textBox5.
    /// Double-click 1 dòng → xem chi tiết phiếu nhập (readonly).
    /// </summary>
    public partial class frmTimKiemPhieuNhap : Form
    {
        private readonly NhapKhoBUS _bus = new NhapKhoBUS();
        private DataTable _dt;

        public frmTimKiemPhieuNhap()
        {
            InitializeComponent();
            this.Load += FrmTimKiemPhieuNhap_Load;
        }

        private void FrmTimKiemPhieuNhap_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);
            LoadData();

            if (btnTimKiem != null) btnTimKiem.Click += BtnTimKiem_Click;
            if (btnLamMoi  != null) btnLamMoi.Click  += BtnLamMoi_Click;

            // button1 = "Đóng" — đóng form
            if (button1 != null) button1.Click += (s, ev) => this.Close();
            // button2 = "Tìm lại" — reset bộ lọc nhưng giữ kết quả hiển thị
            if (button2 != null) button2.Click += (s, ev) => ResetFilters();

            if (dgvDSPhieuNhap != null)
            {
                dgvDSPhieuNhap.CellDoubleClick += DgvDSPhieuNhap_CellDoubleClick;
                dgvDSPhieuNhap.ReadOnly = true;
                dgvDSPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void LoadData()
        {
            try
            {
                _dt = _bus.GetAll();
                if (dgvDSPhieuNhap != null) dgvDSPhieuNhap.DataSource = _dt;
                CapNhatTongTien(_dt);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy filter từ các ô input
                string maPhieu = textBox4?.Text?.Trim() ?? "";   // Mã phiếu nhập
                string thang   = txtTimKiem?.Text?.Trim() ?? ""; // Tháng
                string nam     = textBox2?.Text?.Trim() ?? "";   // Năm
                string maNCC   = textBox1?.Text?.Trim() ?? "";   // Mã NCC
                string maNV    = textBox3?.Text?.Trim() ?? "";   // Mã NV

                // Build SQL với điều kiện linh hoạt
                string sql = @"
                    SELECT pn.MaPhieuNhap, pn.NgayNhap, ncc.TenNCC, nv.HoTen AS TenNhanVien,
                           pn.MaNCC, pn.MaNhanVien, pn.TongTien
                    FROM   PhieuNhapKho pn
                    INNER JOIN NhaCungCap ncc ON pn.MaNCC = ncc.MaNCC
                    INNER JOIN NhanVien   nv  ON pn.MaNhanVien = nv.MaNhanVien
                    WHERE  (@maPhieu = '' OR pn.MaPhieuNhap LIKE '%' + @maPhieu + '%')
                      AND  (@thang = ''   OR MONTH(pn.NgayNhap) = @thangInt)
                      AND  (@nam = ''     OR YEAR(pn.NgayNhap) = @namInt)
                      AND  (@maNCC = ''   OR pn.MaNCC LIKE '%' + @maNCC + '%')
                      AND  (@maNV = ''    OR pn.MaNhanVien LIKE '%' + @maNV + '%')
                    ORDER  BY pn.NgayNhap DESC";

                int thangInt = 0, namInt = 0;
                int.TryParse(thang, out thangInt);
                int.TryParse(nam, out namInt);

                var dt = Function.GetDataToTable(sql,
                    new SqlParameter("@maPhieu", maPhieu),
                    new SqlParameter("@thang", thang),
                    new SqlParameter("@thangInt", thangInt),
                    new SqlParameter("@nam", nam),
                    new SqlParameter("@namInt", namInt),
                    new SqlParameter("@maNCC", maNCC),
                    new SqlParameter("@maNV", maNV));

                if (dgvDSPhieuNhap != null) dgvDSPhieuNhap.DataSource = dt;
                CapNhatTongTien(dt);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm kiếm: " + ex.Message); }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            ResetFilters();
            LoadData();
        }

        private void ResetFilters()
        {
            if (txtTimKiem != null) txtTimKiem.Text = "";
            if (textBox1 != null) textBox1.Text = "";
            if (textBox2 != null) textBox2.Text = "";
            if (textBox3 != null) textBox3.Text = "";
            if (textBox4 != null) textBox4.Text = "";
        }

        private void CapNhatTongTien(DataTable dt)
        {
            if (textBox5 == null || dt == null) return;
            decimal tong = 0;
            foreach (DataRow r in dt.Rows)
                if (r["TongTien"] != DBNull.Value)
                    tong += Convert.ToDecimal(r["TongTien"]);
            textBox5.Text = tong.ToString("N0");
        }

        private void DgvDSPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                string maPhieu = dgvDSPhieuNhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value?.ToString();
                if (string.IsNullOrEmpty(maPhieu)) return;

                // Mở form Lập phiếu nhập với phiếu đã chọn ở chế độ readonly
                // User có thể bấm "Sửa phiếu" để chuyển sang chế độ chỉnh sửa
                using (var f = new frmNhap(maPhieu))
                {
                    f.ShowDialog(this);
                }

                // Sau khi đóng form chi tiết, refresh lại danh sách
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở chi tiết: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
