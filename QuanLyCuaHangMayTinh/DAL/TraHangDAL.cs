using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.DAL
{
    /// <summary>
    /// LƯU Ý: trigger trg_TraHang_TangTon TỰ cộng lại SoLuongTon nếu TinhTrangSP = N'Nguyên vẹn'.
    /// DAL chỉ insert phiếu trả + chi tiết.
    /// </summary>
    internal class TraHangDAL
    {
        public DataTable GetAll()
        {
            const string sql = @"
                SELECT pth.MaPhieuTra, pth.NgayTra, pth.MaHoaDonBan,
                       kh.TenKhachHang, pth.LyDo, pth.TongTien
                FROM   PhieuTraHang pth
                INNER JOIN HoaDonBan hd ON pth.MaHoaDonBan = hd.MaHoaDonBan
                LEFT  JOIN KhachHang kh ON hd.MaKhachHang  = kh.MaKhachHang
                ORDER  BY pth.NgayTra DESC";
            return Function.GetDataToTable(sql);
        }

        public DataTable GetSanPhamCuaHoaDon(string maHoaDon)
        {
            const string sql = @"
                SELECT ct.MaSanPham, sp.TenSanPham, ct.SoLuong AS SoLuongMua,
                       ct.DonGia, (ct.SoLuong*ct.DonGia) AS ThanhTien
                FROM   ChiTietHoaDonBan ct
                INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                WHERE  ct.MaHoaDonBan = @id";
            return Function.GetDataToTable(sql, new SqlParameter("@id", maHoaDon));
        }

        /// <summary>
        /// Tạo phiếu trả hàng (TRANSACTION):
        ///  1. Kiểm tra HĐ tồn tại & chưa trả
        ///  2. Insert PhieuTraHang + ChiTietPhieuTraHang (trigger TỰ cộng tồn kho cho SP nguyên vẹn)
        ///  3. Cập nhật trạng thái HĐ → "Đã trả hàng"
        /// </summary>
        public (bool ok, string msg) TaoPhieuTra(
            DTO.PhieuTraHangDTO phieu,
            List<(string maSP, int soLuong, decimal donGia, string tinhTrang)> chiTiet)
        {
            Function.Connect();
            using (var tran = Function.Conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(
                        "SELECT TrangThai FROM HoaDonBan WHERE MaHoaDonBan=@id", Function.Conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", phieu.MaHoaDonBan);
                        var tt = cmd.ExecuteScalar()?.ToString();
                        if (tt == null) throw new Exception("Hóa đơn không tồn tại.");
                        if (tt == "Đã trả hàng") throw new Exception("Hóa đơn này đã được trả hàng trước đó.");
                    }

                    using (var cmd = new SqlCommand(@"
                        INSERT INTO PhieuTraHang(MaPhieuTra, NgayTra, MaHoaDonBan, MaNhanVien, TongTien, LyDo)
                        VALUES(@MaPT, @NgayTra, @MaHD, @MaNV, @Tong, @LyDo)",
                        Function.Conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaPT",    phieu.MaPhieuTra);
                        cmd.Parameters.AddWithValue("@NgayTra", phieu.NgayTra);
                        cmd.Parameters.AddWithValue("@MaHD",    phieu.MaHoaDonBan);
                        cmd.Parameters.AddWithValue("@MaNV",    phieu.MaNhanVien);
                        cmd.Parameters.AddWithValue("@Tong",    phieu.TongTien);
                        cmd.Parameters.AddWithValue("@LyDo",    string.IsNullOrEmpty(phieu.LyDo) ? "Khách trả" : phieu.LyDo);
                        cmd.ExecuteNonQuery();
                    }

                    // Trigger sẽ tự cộng tồn kho cho SP có tình trạng "Nguyên vẹn"
                    foreach (var (maSP, soLuong, donGia, tinhTrang) in chiTiet)
                    {
                        using (var cmd = new SqlCommand(@"
                            INSERT INTO ChiTietPhieuTraHang(MaPhieuTra, MaSanPham, SoLuongTra, DonGia, TinhTrangSP)
                            VALUES(@MaPT, @MaSP, @SL, @DG, @TT)",
                            Function.Conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaPT", phieu.MaPhieuTra);
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@SL",   soLuong);
                            cmd.Parameters.AddWithValue("@DG",   donGia);
                            cmd.Parameters.AddWithValue("@TT",   string.IsNullOrEmpty(tinhTrang) ? "Nguyên vẹn" : tinhTrang);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    using (var cmd = new SqlCommand(
                        "UPDATE HoaDonBan SET TrangThai=N'Đã trả hàng' WHERE MaHoaDonBan=@id",
                        Function.Conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", phieu.MaHoaDonBan);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return (true, "Tạo phiếu trả hàng thành công.");
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    return (false, ex.Message);
                }
            }
        }

        public string GenerateMaPhieuTra()
        {
            var dt = Function.GetDataToTable("SELECT ISNULL(MAX(CAST(SUBSTRING(MaPhieuTra,4,10) AS INT)),0)+1 FROM PhieuTraHang");
            int next = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 1;
            return "PTH" + next.ToString("D3");
        }
    }
}
