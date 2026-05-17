using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.DAL
{
    internal class NhanVienDAL
    {
        public DataTable GetAll()
        {
            const string sql = @"
                SELECT nv.MaNhanVien, nv.TenDangNhap, nv.HoTen, nv.GioiTinh,
                       nv.NgaySinh, nv.SoDienThoai, nv.Email, nv.DiaChi,
                       nv.MaVaiTro, vt.TenVaiTro, nv.TrangThai
                FROM   NhanVien nv
                INNER JOIN VaiTro vt ON nv.MaVaiTro = vt.MaVaiTro
                ORDER  BY nv.MaNhanVien";
            return Function.GetDataToTable(sql);
        }

        public DataTable Search(string keyword)
        {
            const string sql = @"
                SELECT nv.MaNhanVien, nv.TenDangNhap, nv.HoTen, nv.GioiTinh,
                       nv.SoDienThoai, nv.Email, nv.MaVaiTro, vt.TenVaiTro, nv.TrangThai
                FROM   NhanVien nv
                INNER JOIN VaiTro vt ON nv.MaVaiTro = vt.MaVaiTro
                WHERE  nv.MaNhanVien LIKE N'%'+@kw+'%'
                    OR nv.HoTen      LIKE N'%'+@kw+'%'
                    OR vt.TenVaiTro  LIKE N'%'+@kw+'%'
                ORDER  BY nv.MaNhanVien";
            return Function.GetDataToTable(sql, new SqlParameter("@kw", keyword ?? ""));
        }

        public bool AddNhanVien(DTO.NhanVienDTO nv, string matKhau)
        {
            string hash = SecurityHelper.HashPassword(matKhau?.Trim() ?? "");
            const string sql = @"
                INSERT INTO NhanVien(MaNhanVien,TenDangNhap,MatKhau,HoTen,GioiTinh,
                                     NgaySinh,SoDienThoai,Email,DiaChi,MaVaiTro,TrangThai)
                VALUES(@MaNhanVien,@TenDangNhap,@MatKhau,@HoTen,@GioiTinh,
                       @NgaySinh,@SoDienThoai,@Email,@DiaChi,@MaVaiTro,1)";
            try
            {
                Function.RunSql(sql,
                    new SqlParameter("@MaNhanVien",   nv.MaNhanVien),
                    new SqlParameter("@TenDangNhap",  nv.TenDangNhap),
                    new SqlParameter("@MatKhau",      hash),
                    new SqlParameter("@HoTen",        nv.HoTen),
                    new SqlParameter("@GioiTinh",     (object)nv.GioiTinh ?? DBNull.Value),
                    new SqlParameter("@NgaySinh",     (object)nv.NgaySinh ?? DBNull.Value),
                    new SqlParameter("@SoDienThoai",  (object)nv.SoDienThoai ?? DBNull.Value),
                    new SqlParameter("@Email",        (object)nv.Email ?? DBNull.Value),
                    new SqlParameter("@DiaChi",       (object)nv.DiaChi ?? DBNull.Value),
                    new SqlParameter("@MaVaiTro",     nv.MaVaiTro));
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message);
                return false;
            }
        }

        public bool UpdateNhanVien(DTO.NhanVienDTO nv)
        {
            const string sql = @"
                UPDATE NhanVien SET HoTen=@HoTen, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh,
                    SoDienThoai=@SDT, Email=@Email, DiaChi=@DiaChi,
                    MaVaiTro=@MaVaiTro, TrangThai=@TrangThai
                WHERE MaNhanVien=@MaNhanVien";
            try
            {
                Function.RunSql(sql,
                    new SqlParameter("@MaNhanVien", nv.MaNhanVien),
                    new SqlParameter("@HoTen",      nv.HoTen),
                    new SqlParameter("@GioiTinh",   (object)nv.GioiTinh ?? DBNull.Value),
                    new SqlParameter("@NgaySinh",   (object)nv.NgaySinh ?? DBNull.Value),
                    new SqlParameter("@SDT",        (object)nv.SoDienThoai ?? DBNull.Value),
                    new SqlParameter("@Email",      (object)nv.Email ?? DBNull.Value),
                    new SqlParameter("@DiaChi",     (object)nv.DiaChi ?? DBNull.Value),
                    new SqlParameter("@MaVaiTro",   nv.MaVaiTro),
                    new SqlParameter("@TrangThai",  nv.TrangThai ? 1 : 0));
                return true;
            }
            catch { return false; }
        }

        public bool DoiMatKhau(string maNV, string matKhauMoi)
        {
            string hash = SecurityHelper.HashPassword(matKhauMoi.Trim());
            try
            {
                Function.RunSql("UPDATE NhanVien SET MatKhau=@mk WHERE MaNhanVien=@id",
                    new SqlParameter("@mk", hash),
                    new SqlParameter("@id", maNV));
                return true;
            }
            catch { return false; }
        }

        public bool KichHoat(string maNV, bool active)
        {
            try
            {
                Function.RunSql("UPDATE NhanVien SET TrangThai=@tt WHERE MaNhanVien=@id",
                    new SqlParameter("@tt", active ? 1 : 0),
                    new SqlParameter("@id", maNV));
                return true;
            }
            catch { return false; }
        }

        public string GenerateMaNV()
        {
            var dt = Function.GetDataToTable("SELECT ISNULL(MAX(CAST(SUBSTRING(MaNhanVien,3,10) AS INT)),0)+1 FROM NhanVien");
            int next = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 1;
            return "NV" + next.ToString("D3");
        }

        /// <summary>
        /// XÓA MỀM nhân viên — chuyển TrangThai=0 thay vì DELETE thật.
        /// Lý do: NhanVien là FK trong HoaDonBan/DonDatHang/PhieuNhapKho/PhieuTraHang,
        /// nếu DELETE sẽ vi phạm ràng buộc khóa ngoại và làm mất dữ liệu lịch sử.
        /// Sau khi soft-delete, NV vẫn nằm trong DB nhưng KHÔNG đăng nhập được
        /// (AuthRepository có WHERE TrangThai = 1) và không hiện trong danh sách.
        /// </summary>
        public bool SoftDeleteNhanVien(string maNhanVien)
        {
            try
            {
                Function.RunSql("UPDATE NhanVien SET TrangThai=0 WHERE MaNhanVien=@id",
                    new SqlParameter("@id", maNhanVien));
                return true;
            }
            catch { return false; }
        }
    }
}
