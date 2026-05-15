using System.Data;
using QuanLyCuaHangMayTinh.DTO;

namespace QuanLyCuaHangMayTinh.BUS
{
    internal class SanPhamBUS
    {
        private readonly DAL.SanPhamDAL _dal = new DAL.SanPhamDAL();

        public DataTable GetAll(string keyword = null, string maLoai = null, string maThuongHieu = null)
            => _dal.GetAll(keyword, maLoai, maThuongHieu);
        public DataTable GetTonKhoThap(int nguong = 5) => _dal.GetTonKhoThap(nguong);
        public int GetSoLuongTon(string maSanPham) => _dal.GetSoLuongTon(maSanPham);

        public bool Add(SanPhamDTO sp)
        {
            if (string.IsNullOrWhiteSpace(sp.MaSanPham) || string.IsNullOrWhiteSpace(sp.TenSanPham))
                throw new System.Exception("Mã và tên sản phẩm không được trống.");
            if (sp.GiaBan < sp.GiaNhap)
                throw new System.Exception("Giá bán không được nhỏ hơn giá nhập.");
            if (sp.SoLuongTon < 0)
                throw new System.Exception("Số lượng tồn không hợp lệ.");
            return _dal.Add(sp);
        }

        public bool Update(SanPhamDTO sp)
        {
            if (string.IsNullOrWhiteSpace(sp.TenSanPham))
                throw new System.Exception("Tên sản phẩm không được trống.");
            if (sp.GiaBan < sp.GiaNhap)
                throw new System.Exception("Giá bán không được nhỏ hơn giá nhập.");
            return _dal.Update(sp);
        }

        public bool Delete(string maSanPham) => _dal.Delete(maSanPham);
    }
}
