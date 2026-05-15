using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.DAL
{
    /// <summary>
    /// Truy cập dữ liệu hóa đơn bán. LƯU Ý: trigger trg_BanHang_GiamTon
    /// TỰ kiểm tra tồn kho và TỰ trừ SoLuongTon — DAL không cần làm thủ công.
    /// </summary>
    internal class HoaDonDAL
    {
        public DataTable GetAll()
        {
            const string sql = @"
                SELECT hd.MaHoaDonBan, hd.NgayBan, kh.TenKhachHang,
                       nv.HoTen AS TenNhanVien, hd.TienGiam, hd.TongTien,
                       hd.HinhThucThanhToan, hd.TrangThai
                FROM   HoaDonBan hd
                LEFT JOIN  KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                INNER JOIN NhanVien  nv ON hd.MaNhanVien   = nv.MaNhanVien
                ORDER  BY hd.NgayBan DESC";
            return Function.GetDataToTable(sql);
        }

        public DataTable GetChiTiet(string maHoaDon)
        {
            const string sql = @"
                SELECT ct.MaSanPham, sp.TenSanPham, ct.SoLuong,
                       ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
                FROM   ChiTietHoaDonBan ct
                INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                WHERE  ct.MaHoaDonBan = @id";
            return Function.GetDataToTable(sql, new SqlParameter("@id", maHoaDon));
        }

        /// <summary>
        /// Tạo hóa đơn bán: dùng Transaction để insert header + chi tiết cùng lúc.
        /// Trigger trg_BanHang_GiamTon sẽ TỰ kiểm tra tồn kho và TỰ trừ tồn —
        /// nếu không đủ tồn, trigger sẽ RAISERROR + ROLLBACK, ném exception về đây.
        /// </summary>
        public (bool ok, string msg) TaoHoaDon(DTO.HoaDonBanDTO hd, List<DTO.ChiTietHoaDonDTO> chiTiet)
        {
            Function.Connect();
            using (var tran = Function.Conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(@"
                        INSERT INTO HoaDonBan(MaHoaDonBan,NgayBan,MaKhachHang,MaNhanVien,
                                              MaDonDatHang,TienGiam,TongTien,HinhThucThanhToan,TrangThai)
                        VALUES(@MaHD,@NgayBan,@MaKH,@MaNV,@MaDDH,@Giam,@Tong,@PTTT,@TT)",
                        Function.Conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaHD",    hd.MaHoaDonBan);
                        cmd.Parameters.AddWithValue("@NgayBan", hd.NgayBan);
                        cmd.Parameters.AddWithValue("@MaKH",    (object)hd.MaKhachHang ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaNV",    hd.MaNhanVien);
                        cmd.Parameters.AddWithValue("@MaDDH",   (object)hd.MaDonDatHang ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Giam",    hd.TienGiam);
                        cmd.Parameters.AddWithValue("@Tong",    hd.TongTien);
                        cmd.Parameters.AddWithValue("@PTTT",    (object)hd.HinhThucThanhToan ?? "Tiền mặt");
                        cmd.Parameters.AddWithValue("@TT",      hd.TrangThai ?? "Hoàn thành");
                        cmd.ExecuteNonQuery();
                    }

                    // Trigger sẽ kiểm tra tồn kho & trừ tồn — chỉ cần INSERT
                    foreach (var ct in chiTiet)
                    {
                        using (var cmd = new SqlCommand(@"
                            INSERT INTO ChiTietHoaDonBan(MaHoaDonBan,MaSanPham,SoLuong,DonGia)
                            VALUES(@MaHD,@MaSP,@SL,@DG)",
                            Function.Conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", hd.MaHoaDonBan);
                            cmd.Parameters.AddWithValue("@MaSP", ct.MaSanPham);
                            cmd.Parameters.AddWithValue("@SL",   ct.SoLuong);
                            cmd.Parameters.AddWithValue("@DG",   ct.DonGia);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                    return (true, "Lưu hóa đơn thành công.");
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    return (false, ex.Message);
                }
            }
        }

        public bool CapNhatTrangThai(string maHoaDon, string trangThai)
        {
            try
            {
                Function.RunSql("UPDATE HoaDonBan SET TrangThai=@tt WHERE MaHoaDonBan=@id",
                    new SqlParameter("@tt", trangThai),
                    new SqlParameter("@id", maHoaDon));
                return true;
            }
            catch { return false; }
        }

        public string GenerateMaHoaDon()
        {
            var dt = Function.GetDataToTable("SELECT ISNULL(MAX(CAST(SUBSTRING(MaHoaDonBan,3,10) AS INT)),99)+1 FROM HoaDonBan WHERE MaHoaDonBan LIKE 'HD%'");
            int next = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 100;
            return "HD" + next.ToString("D5");
        }
    }
}
