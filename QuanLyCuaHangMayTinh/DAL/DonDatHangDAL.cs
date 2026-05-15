using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.DAL
{
    internal class DonDatHangDAL
    {
        public DataTable GetAll(string trangThai = null)
        {
            const string sql = @"
                SELECT ddh.MaDonDatHang, ddh.NgayDat, kh.TenKhachHang,
                       nv.HoTen AS TenNhanVien, ddh.TienGiam, ddh.TongTien, ddh.TrangThai
                FROM   DonDatHang ddh
                INNER JOIN KhachHang kh ON ddh.MaKhachHang = kh.MaKhachHang
                INNER JOIN NhanVien  nv ON ddh.MaNhanVien   = nv.MaNhanVien
                WHERE  (@tt IS NULL OR ddh.TrangThai = @tt)
                ORDER  BY ddh.NgayDat DESC";
            return Function.GetDataToTable(sql,
                new SqlParameter("@tt", (object)trangThai ?? DBNull.Value));
        }

        public DataTable GetChiTiet(string maDon)
        {
            const string sql = @"
                SELECT ct.MaSanPham, sp.TenSanPham, ct.SoLuong, ct.DonGia,
                       (ct.SoLuong*ct.DonGia) AS ThanhTien
                FROM   ChiTietDonDatHang ct
                INNER JOIN SanPham sp ON ct.MaSanPham=sp.MaSanPham
                WHERE  ct.MaDonDatHang=@id";
            return Function.GetDataToTable(sql, new SqlParameter("@id", maDon));
        }

        public bool TaoDon(DTO.DonDatHangDTO don, List<DTO.ChiTietHoaDonDTO> chiTiet)
        {
            Function.Connect();
            using (var tran = Function.Conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(@"
                        INSERT INTO DonDatHang(MaDonDatHang,NgayDat,MaKhachHang,MaNhanVien,TienGiam,TongTien,TrangThai)
                        VALUES(@MaDon,@NgayDat,@MaKH,@MaNV,@Giam,@Tong,N'Chờ xử lý')",
                        Function.Conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaDon",   don.MaDonDatHang);
                        cmd.Parameters.AddWithValue("@NgayDat", don.NgayDat);
                        cmd.Parameters.AddWithValue("@MaKH",    don.MaKhachHang);
                        cmd.Parameters.AddWithValue("@MaNV",    don.MaNhanVien);
                        cmd.Parameters.AddWithValue("@Giam",    don.TienGiam);
                        cmd.Parameters.AddWithValue("@Tong",    don.TongTien);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (var ct in chiTiet)
                    {
                        using (var cmd = new SqlCommand(@"
                            INSERT INTO ChiTietDonDatHang(MaDonDatHang,MaSanPham,SoLuong,DonGia)
                            VALUES(@MaDon,@MaSP,@SL,@DG)",
                            Function.Conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaDon", don.MaDonDatHang);
                            cmd.Parameters.AddWithValue("@MaSP", ct.MaSanPham);
                            cmd.Parameters.AddWithValue("@SL",   ct.SoLuong);
                            cmd.Parameters.AddWithValue("@DG",   ct.DonGia);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    System.Windows.Forms.MessageBox.Show("Lỗi tạo đơn: " + ex.Message);
                    return false;
                }
            }
        }

        public bool CapNhatTrangThai(string maDon, string trangThai)
        {
            try
            {
                Function.RunSql("UPDATE DonDatHang SET TrangThai=@tt WHERE MaDonDatHang=@id",
                    new SqlParameter("@tt", trangThai),
                    new SqlParameter("@id", maDon));
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Chuyển đơn đặt hàng sang hóa đơn bán. Trigger sẽ TỰ kiểm tra tồn + trừ kho khi insert chi tiết.
        /// </summary>
        public (bool ok, string msg) ChuyenSangHoaDon(string maDon, string maHoaDonMoi, string maNhanVien)
        {
            Function.Connect();
            using (var tran = Function.Conn.BeginTransaction())
            {
                try
                {
                    DataRow don;
                    using (var cmd = new SqlCommand(
                        "SELECT * FROM DonDatHang WHERE MaDonDatHang=@id AND TrangThai=N'Chờ xử lý'",
                        Function.Conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", maDon);
                        var adapter = new SqlDataAdapter(cmd);
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count == 0) throw new Exception("Đơn không tồn tại hoặc không ở trạng thái 'Chờ xử lý'.");
                        don = dt.Rows[0];
                    }

                    DataTable chiTiet;
                    using (var cmd = new SqlCommand(
                        "SELECT MaSanPham,SoLuong,DonGia FROM ChiTietDonDatHang WHERE MaDonDatHang=@id",
                        Function.Conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", maDon);
                        var adapter = new SqlDataAdapter(cmd);
                        chiTiet = new DataTable();
                        adapter.Fill(chiTiet);
                    }

                    using (var cmd = new SqlCommand(@"
                        INSERT INTO HoaDonBan(MaHoaDonBan,NgayBan,MaKhachHang,MaNhanVien,MaDonDatHang,
                                              TienGiam,TongTien,HinhThucThanhToan,TrangThai)
                        VALUES(@MaHD,GETDATE(),@MaKH,@MaNV,@MaDDH,@Giam,@Tong,N'Tiền mặt',N'Hoàn thành')",
                        Function.Conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaHD",  maHoaDonMoi);
                        cmd.Parameters.AddWithValue("@MaKH",  don["MaKhachHang"]);
                        cmd.Parameters.AddWithValue("@MaNV",  maNhanVien);
                        cmd.Parameters.AddWithValue("@MaDDH", maDon);
                        cmd.Parameters.AddWithValue("@Giam",  don["TienGiam"]);
                        cmd.Parameters.AddWithValue("@Tong",  don["TongTien"]);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (DataRow ct in chiTiet.Rows)
                    {
                        using (var cmd = new SqlCommand(@"
                            INSERT INTO ChiTietHoaDonBan(MaHoaDonBan,MaSanPham,SoLuong,DonGia)
                            VALUES(@MaHD,@MaSP,@SL,@DG)",
                            Function.Conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", maHoaDonMoi);
                            cmd.Parameters.AddWithValue("@MaSP", ct["MaSanPham"]);
                            cmd.Parameters.AddWithValue("@SL",   ct["SoLuong"]);
                            cmd.Parameters.AddWithValue("@DG",   ct["DonGia"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    using (var cmd = new SqlCommand(
                        "UPDATE DonDatHang SET TrangThai=N'Hoàn thành' WHERE MaDonDatHang=@id",
                        Function.Conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", maDon);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return (true, $"Đã tạo hóa đơn {maHoaDonMoi}.");
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    return (false, ex.Message);
                }
            }
        }

        public string GenerateMaDon()
        {
            var dt = Function.GetDataToTable("SELECT ISNULL(MAX(CAST(SUBSTRING(MaDonDatHang,4,10) AS INT)),0)+1 FROM DonDatHang");
            int next = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 1;
            return "DDH" + next.ToString("D3");
        }
    }
}
