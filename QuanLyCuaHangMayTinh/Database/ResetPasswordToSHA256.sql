/* =====================================================================
   RESET MẬT KHẨU SANG SHA256 + SALT (thay cho BCrypt cũ bị lỗi DLL)

   Chạy script này 1 lần sau khi đã CreateDatabase.sql, để các tài khoản
   demo có mật khẩu được hash đúng bằng SHA256 + Salt mới.

   Sau khi chạy script này, login với:
     - admin   / admin123
     - kho     / kho123
     - banhang / banhang123
     - ketoan  / ketoan123
   ===================================================================== */

USE QuanLyCuaHangMayTinhDB;
GO

UPDATE NhanVien SET MatKhau = N'SHA256:CUZ/I9Utxn8QMzj86/sVa5G7SDoYR85+/uDrOK/FZ3w='
WHERE TenDangNhap = N'admin';

UPDATE NhanVien SET MatKhau = N'SHA256:9c200F78sEV6t3Gc7Agx+QH0KzJm2MF2snaQRk36bZY='
WHERE TenDangNhap = N'kho';

UPDATE NhanVien SET MatKhau = N'SHA256:Qob/VqZwOMhSl/nvcytYgCqAarjdD2lYCwdnKx0fuWI='
WHERE TenDangNhap = N'banhang';

UPDATE NhanVien SET MatKhau = N'SHA256:XcS9DkBUd/6a7+tlaNHDD//xOb3WraHvdfYnQ1Mk+Ps='
WHERE TenDangNhap = N'ketoan';

GO

PRINT N'Đã reset mật khẩu cho 4 tài khoản demo sang SHA256+Salt.';
PRINT N'Có thể login với: admin/admin123, kho/kho123, banhang/banhang123, ketoan/ketoan123';
GO

-- Kiểm tra kết quả
SELECT MaNhanVien, TenDangNhap, HoTen, LEFT(MatKhau, 30) + '...' AS MatKhauPreview, MaVaiTro
FROM NhanVien
ORDER BY MaNhanVien;
GO
