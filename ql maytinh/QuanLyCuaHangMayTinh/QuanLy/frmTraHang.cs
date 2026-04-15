using Dapper;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.QuanLy
{
    public class frmTraHang : Form
    {
        private DataGridView dgv;
        private Button btnTai, btnTraNhieu;
        public frmTraHang()
        {
            Text = "Trả hàng"; Width = 1000; Height = 600;
            dgv = new DataGridView { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, MultiSelect = true };
            var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 45 };
            btnTai = new Button { Text = "Tải đơn bán", Width = 120 };
            btnTraNhieu = new Button { Text = "Trả nhiều sản phẩm", Width = 160 };
            btnTai.Click += (s,e) => LoadData();
            btnTraNhieu.Click += (s,e) => MessageBox.Show("Đã bổ sung giao diện trả nhiều sản phẩm cùng lúc. Cần ánh xạ bảng trả hàng trong SQL để chạy nghiệp vụ đầy đủ.");
            panel.Controls.AddRange(new Control[]{btnTai, btnTraNhieu});
            Controls.Add(dgv); Controls.Add(panel);
        }
        private void LoadData()
        {
            try
            {
                using(var conn = DapperRepository.CreateConnection())
                {
                    conn.Open();
                    var dt = new DataTable();
                    using (var da = new System.Data.SqlClient.SqlDataAdapter("SELECT TOP 100 MaDonBan, NgayBan, MaKhachHang, TrangThai, TongTien FROM DonBanHang ORDER BY NgayBan DESC", conn))
                    { da.Fill(dt); }
                    dgv.DataSource = dt;
                }
            }
            catch(Exception ex) { MessageBox.Show("Chưa tải được dữ liệu trả hàng: " + ex.Message); }
        }
    }
}
