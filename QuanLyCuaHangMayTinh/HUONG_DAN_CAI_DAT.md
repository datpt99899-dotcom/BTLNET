# 🖥️ Hướng dẫn cài đặt & chạy dự án

## 📦 1. Yêu cầu môi trường

| Yêu cầu             | Phiên bản            |
|---------------------|----------------------|
| Visual Studio       | 2019 / 2022          |
| .NET Framework      | 4.7.2                |
| SQL Server          | 2017 trở lên         |
| SSMS                | Bất kỳ phiên bản     |

## 🚀 2. Các bước chạy

### Bước 1 — Restore NuGet
1. Mở `QuanLyCuaHangMayTinh.sln` trong Visual Studio
2. Chuột phải Solution → **Restore NuGet Packages**

📦 Package mới: **BCrypt.Net-Next 4.0.3** (mã hóa mật khẩu)

### Bước 2 — Tạo Database
Mở **SSMS**, mở file `Database/CreateDatabase.sql`, bấm **F5**.

Script sẽ:
- Tạo database `QuanLyCuaHangMayTinhDB`
- Tạo **15 bảng** đầy đủ theo spec BTL__NET.docx
- Tạo **3 TRIGGER** tự động cập nhật tồn kho khi bán/nhập/trả hàng
- Insert dữ liệu mẫu (4 tài khoản + 12 sản phẩm + 30 hóa đơn 30 ngày)
- Mật khẩu hash bằng **BCrypt cost=11**

### Bước 3 — Cấu hình kết nối
Mở `App.config`, sửa `Data Source=.` thành tên SQL Server của máy bạn.

### Bước 4 — Build & Run
Bấm **F5**. App mở form **Đăng nhập**.

## 🔑 3. Tài khoản đăng nhập mẫu

| Vai trò              | Tên đăng nhập | Mật khẩu      | Mã NV |
|----------------------|---------------|---------------|-------|
| Quản trị (Admin)     | `admin`       | `admin123`    | NV001 |
| Nhân viên kho        | `kho`         | `kho123`      | NV002 |
| Nhân viên bán hàng   | `banhang`     | `banhang123`  | NV003 |
| Kế toán              | `ketoan`      | `ketoan123`   | NV004 |

## 🛡️ 4. Bảo mật

| Tiêu chí | Triển khai |
|----------|------------|
| Hash mật khẩu     | BCrypt + salt tự động, cost=11 |
| Xác thực          | `BCrypt.Verify()` — không bao giờ so plaintext |
| SQL Injection     | 100% query dùng `SqlParameter` |
| Transaction       | Bán hàng, nhập kho, trả hàng đều có rollback |
| Trigger tồn kho   | DB tự kiểm tra và cập nhật, đảm bảo nhất quán |

## 📊 5. Database (Schema theo spec)

15 bảng: VaiTro, NhanVien, KhachHang, NhaCungCap, LoaiSanPham, ThuongHieu,
SanPham, DonDatHang, ChiTietDonDatHang, HoaDonBan, ChiTietHoaDonBan,
PhieuNhapKho, ChiTietPhieuNhap, PhieuTraHang, ChiTietPhieuTraHang.

3 TRIGGER:
- `trg_BanHang_GiamTon` — tự trừ tồn kho khi insert ChiTietHoaDonBan
- `trg_NhapKho_TangTon` — tự cộng tồn kho + update giá khi nhập
- `trg_TraHang_TangTon` — tự cộng lại tồn kho nếu SP "Nguyên vẹn"

## ⚠️ 6. Lỗi thường gặp

**"Không thể kết nối đến cơ sở dữ liệu"**
→ Kiểm tra SQL Server đang chạy, sửa `Data Source` trong App.config

**"Could not load file or assembly 'BCrypt.Net-Next'"**
→ Restore NuGet packages (Bước 1)

**"Invalid object name 'NhanVien'"**
→ Chưa chạy `CreateDatabase.sql`
