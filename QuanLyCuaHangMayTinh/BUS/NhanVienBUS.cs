using System.Data;
using QuanLyCuaHangMayTinh.DTO;
using QuanLyCuaHangMayTinh.Repositories;

namespace QuanLyCuaHangMayTinh.BUS
{
    internal class NhanVienBUS
    {
        private readonly DAL.NhanVienDAL _dal = new DAL.NhanVienDAL();

        public DataTable GetAll() => _dal.GetAll();
        public DataTable Search(string keyword) => _dal.Search(keyword);
        public string GenerateMaNV() => _dal.GenerateMaNV();

        public bool AddNhanVien(NhanVienDTO nv, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(nv.MaNhanVien))
                throw new System.Exception("Mã nhân viên không được trống.");
            if (string.IsNullOrWhiteSpace(nv.TenDangNhap))
                throw new System.Exception("Tên đăng nhập không được trống.");
            if (string.IsNullOrWhiteSpace(matKhau) || matKhau.Length < 6)
                throw new System.Exception("Mật khẩu phải có ít nhất 6 ký tự.");
            return _dal.AddNhanVien(nv, matKhau);
        }

        public bool UpdateNhanVien(NhanVienDTO nv)
            => _dal.UpdateNhanVien(nv);

        public bool DoiMatKhau(string maNV, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi) || matKhauMoi.Length < 6)
                throw new System.Exception("Mật khẩu mới phải có ít nhất 6 ký tự.");
            return _dal.DoiMatKhau(maNV, matKhauMoi);
        }

        /// <summary>Đổi mật khẩu có xác thực mật khẩu cũ (cho người dùng tự đổi).</summary>
        public bool DoiMatKhau(string maNV, string matKhauCu, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauCu))
                throw new System.Exception("Vui lòng nhập mật khẩu cũ.");
            if (string.IsNullOrWhiteSpace(matKhauMoi) || matKhauMoi.Length < 6)
                throw new System.Exception("Mật khẩu mới phải có ít nhất 6 ký tự.");

            // Kiểm tra mật khẩu cũ qua AuthRepository (sử dụng BCrypt verify)
            var row = AuthRepository.AuthenticateByMaNV(maNV, matKhauCu);
            if (row == null) return false; // Mật khẩu cũ sai

            return _dal.DoiMatKhau(maNV, matKhauMoi);
        }

        public bool KichHoat(string maNV, bool active) => _dal.KichHoat(maNV, active);

        /// <summary>
        /// Xóa mềm nhân viên — không cho xóa chính tài khoản đang đăng nhập.
        /// Sau khi xóa, nhân viên sẽ không đăng nhập được và không hiện trong danh sách.
        /// </summary>
        public bool SoftDeleteNhanVien(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new System.Exception("Mã nhân viên không được trống.");
            if (maNV == StaticData.MaNV)
                throw new System.Exception("Không thể xóa chính tài khoản đang đăng nhập.");
            return _dal.SoftDeleteNhanVien(maNV);
        }
    }
}
