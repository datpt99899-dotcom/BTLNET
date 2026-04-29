using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.Repositories
{
    internal static class ProductRepository
    {
        public static DataTable GetAll(string keyword = null, string maLoai = null, string maThuongHieu = null)
        {
            string sql = @"SELECT sp.MaSanPham, sp.TenSanPham, lsp.TenLoai, th.TenThuongHieu, ncc.TenNhaCungCap,
                                  sp.GiaNhap, sp.GiaBan, sp.SoLuongTon, sp.MoTa
                           FROM SanPham sp
                           INNER JOIN LoaiSanPham lsp ON sp.MaLoai = lsp.MaLoai
                           INNER JOIN ThuongHieu th ON sp.MaThuongHieu = th.MaThuongHieu
                           INNER JOIN NhaCungCap ncc ON sp.MaNhaCungCap = ncc.MaNhaCungCap
                           WHERE (@keyword IS NULL OR sp.TenSanPham LIKE N'%' + @keyword + '%' OR sp.MoTa LIKE N'%' + @keyword + '%')
                             AND (@maLoai IS NULL OR sp.MaLoai = @maLoai)
                             AND (@maThuongHieu IS NULL OR sp.MaThuongHieu = @maThuongHieu)
                           ORDER BY sp.TenSanPham";
            return Function.GetDataToTable(sql,
                new SqlParameter("@keyword", (object)keyword ?? DBNull.Value),
                new SqlParameter("@maLoai", (object)maLoai ?? DBNull.Value),
                new SqlParameter("@maThuongHieu", (object)maThuongHieu ?? DBNull.Value));
        }
    }
}
