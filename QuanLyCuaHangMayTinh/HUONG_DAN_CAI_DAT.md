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

Các package quan trọng:

- **BCrypt.Net-Next 4.0.3** — mã hóa mật khẩu (rubric 2.3)
- **LiveCharts 0.9.7 + LiveCharts.WinForms 0.9.7.1** — biểu đồ báo cáo (rubric 1.4)
- **Dapper 2.1.72** — ORM nhẹ cho 1 số truy vấn (rubric 2.2)
- **FontAwesome.Sharp** — icon UI
- **Guna.UI2** — UI components

### Bước 2 — Tạo Database

Mở **SSMS** và chạy theo thứ tự:

1. `Database/CreateDatabase.sql` — tạo **15 bảng + 3 trigger + dữ liệu mẫu 30 ngày**
2. `Database/StoredProcedures.sql` — tạo **10 stored procedures** cho nghiệp vụ
3. `Database/Migrations.sql` — *(tùy chọn)* tạo bảng version-tracking

### Bước 3 — Cấu hình kết nối

Chỉnh `App.config` cho phù hợp môi trường:

```xml
<connectionStrings>
    <add name="DefaultConnection"
         connectionString="Server=localhost;Database=QuanLyCuaHangMayTinhDB;User Id=sa;Password=...;TrustServerCertificate=True;"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

**(Khuyến nghị cho production):** mã hóa toàn bộ section connectionStrings bằng Windows DPAPI:

```cmd
%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pef "connectionStrings" "<thư mục chứa App.config>"
```

### Bước 4 — Build & Run

`Ctrl+F5` hoặc nhấn nút Start.

## 🔑 3. Tài khoản mặc định

| Vai trò       | Username | Password   |
|---------------|----------|------------|
| Admin         | admin    | admin123   |
| Nhân viên kho | kho      | kho123     |
| Bán hàng      | banhang  | banhang123 |
| Kế toán       | ketoan   | ketoan123  |

## 🔐 4. Cơ chế bảo mật mật khẩu

Hệ thống dùng **3 tầng tương thích** trong `SecurityHelper.cs`:

1. **BCrypt cost=11** (chuẩn chính) — hash mới đều dùng cơ chế này, mỗi user có salt random.
2. **SHA256 + salt cố định** (fallback) — tương thích với data cũ.
3. **Plaintext** (fallback) — chỉ để demo từ seed data ban đầu.

**Auto-migrate**: lần đầu mỗi user login, `AuthRepository.cs` tự nâng cấp hash từ SHA256/plaintext sang BCrypt. Sau lần login đầu tiên, DB sẽ chỉ chứa BCrypt hash an toàn.

Có thể verify trạng thái migrate bằng query trong `Database/Migrations.sql`.

## 📊 5. Báo cáo & Biểu đồ

3 form báo cáo dùng **LiveCharts** để vẽ:

- `frmBaoCaoDT` — biểu đồ đường doanh thu theo ngày
- `frmBaoCaoDonHang` — biểu đồ tròn đơn theo trạng thái
- `frmBaoCaoSP` — biểu đồ cột ngang top sản phẩm bán chạy

Logic nằm trong `GUI/LiveChartsHelper.cs`. Có thể đổi sang biểu đồ cột bằng tham số `asBar=true` của `RenderLineChart`.

## 🛠️ 6. Cấu trúc Solution

```
QuanLyCuaHangMayTinh/
├── GUI/                       # Lớp Presentation (WinForms)
│   ├── frmLogin.cs            # Đăng nhập
│   ├── frmMain.cs             # Form chính có sidebar phân quyền
│   ├── frmPOS.cs              # Bán hàng tại quầy (transaction)
│   ├── frmDonHang.cs          # Đơn đặt hàng
│   ├── frmNhap.cs             # Nhập kho
│   ├── frmTraHang.cs          # Trả hàng
│   ├── frmSanPham.cs          # Quản lý sản phẩm
│   ├── frmBaoCaoDT.cs         # Báo cáo doanh thu + LiveCharts
│   ├── frmBaoCaoSP.cs         # Báo cáo SP bán chạy
│   ├── frmBaoCaoDonHang.cs    # Báo cáo đơn theo trạng thái
│   ├── LiveChartsHelper.cs    # Helper LiveCharts cho 3 form báo cáo
│   └── ReportButtonsHelper.cs # Helper xuất Excel/In
├── BUS/                       # Lớp Business Logic
│   ├── SanPhamBUS.cs
│   ├── HoaDonBUS.cs
│   ├── DonDatHangBUS.cs
│   ├── NhapKhoBUS.cs
│   ├── TraHangBUS.cs
│   ├── NhanVienBUS.cs
│   └── BaoCaoBUS.cs
├── DAL/                       # Lớp Data Access
│   ├── AuthRepository.cs      # Xác thực + auto-migrate hash
│   ├── SanPhamDAL.cs
│   ├── HoaDonDAL.cs           # Transaction-safe
│   ├── DonDatHangDAL.cs       # Transaction-safe
│   ├── NhapKhoDAL.cs          # Transaction-safe
│   ├── TraHangDAL.cs          # Transaction-safe
│   ├── NhanVienDAL.cs
│   ├── BaoCaoDAL.cs
│   ├── DapperRepository.cs    # Demo dùng Dapper ORM
│   └── Function.cs            # DB helper chung (parameterized query)
├── DTO/                       # Data Transfer Objects
│   ├── SanPhamDTO.cs
│   ├── HoaDonBanDTO.cs
│   ├── ChiTietHoaDonDTO.cs
│   └── ...
├── Database/                  # SQL scripts
│   ├── CreateDatabase.sql     # 15 bảng + 3 trigger + seed
│   ├── StoredProcedures.sql   # 10 SP
│   ├── Migrations.sql         # Version tracking
│   └── ResetPasswordToSHA256.sql # (legacy)
├── SecurityHelper.cs          # BCrypt + SHA256 fallback
├── AppTheme.cs                # Bảng màu app
├── ThemeManager.cs            # Apply theme
└── App.config                 # Connection string + appSettings
```

## 📝 7. Troubleshooting

| Lỗi | Nguyên nhân | Cách fix |
|---|---|---|
| Không kết nối DB | Sai connection string / SQL Server chưa chạy | Sửa `App.config`, kiểm tra service `SQL Server (MSSQLSERVER)` |
| Login sai mật khẩu | Đã chạy script đè | Chạy lại `CreateDatabase.sql` |
| Lỗi BCrypt | Chưa restore NuGet | Right-click Solution → Restore NuGet Packages |
| Biểu đồ trống | DB không có data trong khoảng ngày chọn | Chỉnh DateTimePicker rộng ra hoặc chạy lại seed |
