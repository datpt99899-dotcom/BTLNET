using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.DAL
{
    /// <summary>
    /// LƯU Ý: trigger trg_NhapKho_TangTon TỰ cộng SoLuongTon, TỰ cập nhật GiaNhap và GiaBan.
    /// DAL chỉ cần insert phiếu nhập + chi tiết.
    /// </summary>
    internal class NhapKhoDAL
    {
        public DataTable GetAll()
        {
            const string sql = @"
                SELECT pnk.MaPhieuNhap, pnk.NgayNhap, ncc.TenNCC,
                       nv.HoTen AS TenNhanVien, pnk.TongTien
                FROM   PhieuNhapKho pnk
                INNER JOIN NhaCungCap ncc ON pnk.MaNCC = ncc.MaNCC
                INNER JOIN NhanVien   nv  ON pnk.MaNhanVien = nv.MaNhanVien
                ORDER  BY pnk.NgayNhap DESC";
            return Function.GetDataToTable(sql);
        }

        public DataTable GetChiTiet(string maPhieu)
        {
            const string sql = @"
                SELECT ct.MaSanPham, sp.TenSanPham, ct.SoLuong, ct.DonGiaNhap,
                       (ct.SoLuong*ct.DonGiaNhap) AS ThanhTien
                FROM   ChiTietPhieuNhap ct
                INNER JOIN SanPham sp ON ct.MaSanPham=sp.MaSanPham
                WHERE  ct.MaPhieuNhap=@id";
            return Function.GetDataToTable(sql, new SqlParameter("@id", maPhieu));
        }

        public (bool ok, string msg) TaoPhieuNhap(
            DTO.PhieuNhapKhoDTO phieu,
            List<(string maSP, int soLuong, decimal donGia)> chiTiet)
        {
            Function.Connect();
            using (var tran = Function.Conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(@"
                        INSERT INTO PhieuNhapKho(MaPhieuNhap,NgayNhap,MaNCC,MaNhanVien,TongTien)
                        VALUES(@MaPN,@NgayNhap,@MaNCC,@MaNV,@Tong)",
                        Function.Conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaPN",    phieu.MaPhieuNhap);
                        cmd.Parameters.AddWithValue("@NgayNhap",phieu.NgayNhap);
                        cmd.Parameters.AddWithValue("@MaNCC",   phieu.MaNCC);
                        cmd.Parameters.AddWithValue("@MaNV",    phieu.MaNhanVien);
                        cmd.Parameters.AddWithValue("@Tong",    phieu.TongTien);
                        cmd.ExecuteNonQuery();
                    }

                    // Trigger sẽ tự cộng tồn kho + update giá
                    foreach (var (maSP, soLuong, donGia) in chiTiet)
                    {
                        using (var cmd = new SqlCommand(@"
                            INSERT INTO ChiTietPhieuNhap(MaPhieuNhap,MaSanPham,SoLuong,DonGiaNhap)
                            VALUES(@MaPN,@MaSP,@SL,@DG)",
                            Function.Conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaPN", phieu.MaPhieuNhap);
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@SL",   soLuong);
                            cmd.Parameters.AddWithValue("@DG",   donGia);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                    return (true, "Nhập kho thành công. Tồn kho và giá đã được tự động cập nhật.");
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    return (false, ex.Message);
                }
            }
        }

        public string GenerateMaPhieuNhap()
        {
            var dt = Function.GetDataToTable("SELECT ISNULL(MAX(CAST(SUBSTRING(MaPhieuNhap,4,10) AS INT)),0)+1 FROM PhieuNhapKho");
            int next = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 1;
            return "PNK" + next.ToString("D3");
        }
    }
}
