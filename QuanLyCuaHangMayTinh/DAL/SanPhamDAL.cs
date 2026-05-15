using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.DAL
{
    internal class SanPhamDAL
    {
        public DataTable GetAll(string keyword = null, string maLoai = null, string maThuongHieu = null)
        {
            const string sql = @"
                SELECT sp.MaSanPham, sp.TenSanPham, sp.MaLoai, lsp.TenLoai,
                       sp.MaThuongHieu, th.TenThuongHieu,
                       sp.MaNCC, ncc.TenNCC,
                       sp.GiaNhap, sp.GiaBan, sp.SoLuongTon, sp.MoTa, sp.HinhAnh, sp.BaoHanhThang
                FROM   SanPham sp
                INNER JOIN LoaiSanPham lsp ON sp.MaLoai = lsp.MaLoai
                INNER JOIN ThuongHieu  th  ON sp.MaThuongHieu = th.MaThuongHieu
                INNER JOIN NhaCungCap  ncc ON sp.MaNCC = ncc.MaNCC
                WHERE  (@keyword IS NULL OR sp.TenSanPham LIKE N'%'+@keyword+'%'
                                        OR sp.MaSanPham  LIKE N'%'+@keyword+'%'
                                        OR sp.MoTa       LIKE N'%'+@keyword+'%')
                  AND  (@maLoai       IS NULL OR sp.MaLoai       = @maLoai)
                  AND  (@maThuongHieu IS NULL OR sp.MaThuongHieu = @maThuongHieu)
                ORDER  BY sp.TenSanPham";
            return Function.GetDataToTable(sql,
                new SqlParameter("@keyword",      (object)keyword      ?? DBNull.Value),
                new SqlParameter("@maLoai",       (object)maLoai       ?? DBNull.Value),
                new SqlParameter("@maThuongHieu", (object)maThuongHieu ?? DBNull.Value));
        }

        public DataTable GetTonKhoThap(int nguong = 5)
        {
            const string sql = @"
                SELECT sp.MaSanPham, sp.TenSanPham, lsp.TenLoai, sp.SoLuongTon, sp.GiaBan
                FROM   SanPham sp
                INNER JOIN LoaiSanPham lsp ON sp.MaLoai = lsp.MaLoai
                WHERE  sp.SoLuongTon <= @nguong
                ORDER  BY sp.SoLuongTon ASC";
            return Function.GetDataToTable(sql, new SqlParameter("@nguong", nguong));
        }

        public int GetSoLuongTon(string maSanPham)
        {
            var dt = Function.GetDataToTable(
                "SELECT SoLuongTon FROM SanPham WHERE MaSanPham=@id",
                new SqlParameter("@id", maSanPham));
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        public bool Add(DTO.SanPhamDTO sp)
        {
            const string sql = @"
                INSERT INTO SanPham(MaSanPham,TenSanPham,MaLoai,MaThuongHieu,MaNCC,
                                    GiaNhap,GiaBan,SoLuongTon,MoTa,HinhAnh,BaoHanhThang)
                VALUES(@MaSanPham,@TenSanPham,@MaLoai,@MaThuongHieu,@MaNCC,
                       @GiaNhap,@GiaBan,@SoLuongTon,@MoTa,@HinhAnh,@BaoHanhThang)";
            try
            {
                Function.RunSql(sql,
                    new SqlParameter("@MaSanPham",    sp.MaSanPham),
                    new SqlParameter("@TenSanPham",   sp.TenSanPham),
                    new SqlParameter("@MaLoai",       sp.MaLoai),
                    new SqlParameter("@MaThuongHieu", sp.MaThuongHieu),
                    new SqlParameter("@MaNCC",        sp.MaNCC),
                    new SqlParameter("@GiaNhap",      sp.GiaNhap),
                    new SqlParameter("@GiaBan",       sp.GiaBan),
                    new SqlParameter("@SoLuongTon",   sp.SoLuongTon),
                    new SqlParameter("@MoTa",         (object)sp.MoTa ?? DBNull.Value),
                    new SqlParameter("@HinhAnh",      string.IsNullOrEmpty(sp.HinhAnh) ? "default.png" : sp.HinhAnh),
                    new SqlParameter("@BaoHanhThang", sp.BaoHanhThang > 0 ? sp.BaoHanhThang : 12));
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message);
                return false;
            }
        }

        public bool Update(DTO.SanPhamDTO sp)
        {
            const string sql = @"
                UPDATE SanPham SET TenSanPham=@TenSanPham, MaLoai=@MaLoai,
                    MaThuongHieu=@MaThuongHieu, MaNCC=@MaNCC,
                    GiaNhap=@GiaNhap, GiaBan=@GiaBan, MoTa=@MoTa, HinhAnh=@HinhAnh,
                    BaoHanhThang=@BaoHanhThang
                WHERE MaSanPham=@MaSanPham";
            try
            {
                Function.RunSql(sql,
                    new SqlParameter("@MaSanPham",    sp.MaSanPham),
                    new SqlParameter("@TenSanPham",   sp.TenSanPham),
                    new SqlParameter("@MaLoai",       sp.MaLoai),
                    new SqlParameter("@MaThuongHieu", sp.MaThuongHieu),
                    new SqlParameter("@MaNCC",        sp.MaNCC),
                    new SqlParameter("@GiaNhap",      sp.GiaNhap),
                    new SqlParameter("@GiaBan",       sp.GiaBan),
                    new SqlParameter("@MoTa",         (object)sp.MoTa ?? DBNull.Value),
                    new SqlParameter("@HinhAnh",      string.IsNullOrEmpty(sp.HinhAnh) ? "default.png" : sp.HinhAnh),
                    new SqlParameter("@BaoHanhThang", sp.BaoHanhThang));
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maSanPham)
        {
            const string sql = "DELETE FROM SanPham WHERE MaSanPham=@id";
            try { Function.RunSqlDel(sql, new SqlParameter("@id", maSanPham)); return true; }
            catch { return false; }
        }
    }
}
