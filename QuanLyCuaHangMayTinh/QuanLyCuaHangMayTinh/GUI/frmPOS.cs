using System;
using System.Data;
using System.Data.SqlClient; 
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmPOS : Form
    {
        
        string connStr = @"Data Source=.;Initial Catalog=QuanLyCuaHangMayTinhDB;Integrated Security=True";

        DataTable cartTable = new DataTable();
        string maKhachHang = "KH001"; 

        public frmPOS()
        {
            InitializeComponent();
        }

      
        private void frmPOS_Load(object sender, EventArgs e)
        {
            InitCart();      
            LoadSanPham();   

          
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.ReadOnly = true;
            dgvCart.AllowUserToAddRows = false;
        }

       
        void InitCart()
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

       
        void LoadSanPham()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "SELECT MaSanPham, TenSanPham, GiaBan, SoLuongTon FROM SanPham " +
                                 "WHERE TenSanPham LIKE @kw OR MaSanPham LIKE @kw";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@kw", "%" + txtSearch.Text + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSanPham.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
            }
        }

       
        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadSanPham();

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string ma = dgvSanPham.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString();
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
                else MessageBox.Show("Không đủ hàng!");
            }
            TinhTong();
        }

        
        void TinhTong()
        {
            decimal tong = 0;
            if (cartTable.Rows.Count > 0)
                tong = cartTable.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));

            decimal giam = 0;
            decimal.TryParse(txtGiamGia.Text.Replace("%", ""), out giam);

            decimal thanhToan = tong - (tong * giam / 100); 
            lblTongTien.Text = thanhToan.ToString("N0") + " VNĐ";
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e) => TinhTong();

        
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0) return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction(); 
                try
                {
                    string maHD = "HDB" + DateTime.Now.ToString("yyyyMMddHHmmss");

                   
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO HoaDonBan(MaHoaDonBan, MaKhachHang, MaNhanVien, TongTien, NgayBan) " +
                        "VALUES(@ma, @kh, @nv, @tong, GETDATE())", conn, tran);
                    cmd.Parameters.AddWithValue("@ma", maHD);
                    cmd.Parameters.AddWithValue("@kh", maKhachHang);
                    cmd.Parameters.AddWithValue("@nv", "NV003"); 

                    decimal tongTien = Convert.ToDecimal(lblTongTien.Text.Replace(" VNĐ", "").Replace(",", ""));
                    cmd.Parameters.AddWithValue("@tong", tongTien);
                    cmd.ExecuteNonQuery();

                    foreach (DataRow r in cartTable.Rows)
                    {
                        SqlCommand ct = new SqlCommand(
                            "INSERT INTO ChiTietHoaDonBan(MaHoaDonBan, MaSanPham, SoLuong, DonGia) " +
                            "VALUES(@ma, @sp, @sl, @gia)", conn, tran);
                        ct.Parameters.AddWithValue("@ma", maHD);
                        ct.Parameters.AddWithValue("@sp", r["MaSanPham"]);
                        ct.Parameters.AddWithValue("@sl", r["SoLuong"]);
                        ct.Parameters.AddWithValue("@gia", r["GiaBan"]);
                        ct.ExecuteNonQuery();

                        SqlCommand upd = new SqlCommand(
                            "UPDATE SanPham SET SoLuongTon = SoLuongTon - @sl WHERE MaSanPham = @sp", conn, tran);
                        upd.Parameters.AddWithValue("@sl", r["SoLuong"]);
                        upd.Parameters.AddWithValue("@sp", r["MaSanPham"]);
                        upd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Thanh toán thành công! Mã HD: " + maHD);
                    btnLamMoi_Click(null, null); 
                }
                catch (Exception ex)
                {
                    tran.Rollback(); 
                    MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message);
                }
            }
        }

        
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCart.Columns[e.ColumnIndex].Name == "colDelete" && e.RowIndex >= 0)
            {
                cartTable.Rows.RemoveAt(e.RowIndex);
                TinhTong();
            }
        }

       
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cartTable.Clear();
            txtSearch.Clear();
            txtGiamGia.Text = "0";
            TinhTong();
            LoadSanPham();
        }
    }
}