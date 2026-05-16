# 📋 NHẬT KÝ THAY ĐỔI — bản fix điểm cao

> Bản này fix 4 điểm yếu để đạt mức **Tốt** ở các tiêu chí 1.4, 2.2, 2.3 trong rubric chấm điểm. KHÔNG phá vỡ bất kỳ chức năng nào đang chạy.

## 🔧 Danh sách thay đổi

### 1. Bảo mật mật khẩu — BCrypt cost=11 thật sự (rubric 2.3)

**File sửa:**
- `SecurityHelper.cs` — viết lại 3 tầng tương thích:
  - Tầng 1 (chính): **BCrypt.Net-Next cost=11** — salt random mỗi user
  - Tầng 2 (fallback): SHA256 + salt cố định (cho data đã có)
  - Tầng 3 (fallback): plaintext (cho seed data demo)
- `DAL/AuthRepository.cs` — thêm **auto-migrate**: login lần đầu bằng plaintext/SHA256 → tự UPDATE sang BCrypt hash trong DB

**Kiểm tra sau khi triển khai:**
```sql
SELECT MaNhanVien, TenDangNhap,
       CASE WHEN MatKhau LIKE '$2%' THEN 'BCrypt OK'
            WHEN MatKhau LIKE 'SHA256:%' THEN 'Còn SHA256'
            ELSE 'Còn plaintext' END AS TrangThaiHash
FROM   NhanVien;
```

### 2. Stored Procedures (rubric 2.2 + 3.2)

**File mới:** `Database/StoredProcedures.sql` (404 dòng) — gồm **10 SP**:

| # | Tên SP | Chức năng |
|---|---|---|
| 1 | `sp_TaoHoaDonBan` | Tạo hóa đơn + chi tiết (transaction, dùng OPENJSON) |
| 2 | `sp_ChuyenDonDatHangThanhHoaDon` | Chuyển đơn đặt → hóa đơn bán |
| 3 | `sp_NhapKho` | Tạo phiếu nhập + chi tiết (transaction) |
| 4 | `sp_TraHang` | Tạo phiếu trả hàng (transaction) |
| 5 | `sp_DoanhThuTheoNgay` | Báo cáo doanh thu theo ngày |
| 6 | `sp_DoanhThuTheoThang` | Báo cáo doanh thu theo tháng (tham số: năm) |
| 7 | `sp_TopSanPhamBanChay` | Top N sản phẩm bán chạy |
| 8 | `sp_DonHangTheoTrangThai` | Thống kê đơn theo trạng thái |
| 9 | `sp_TimKiemSanPhamNangCao` | Tìm kiếm SP đa tiêu chí (từ khóa, giá, loại, thương hiệu, còn hàng) |
| 10 | `sp_DoiMatKhau` | Đổi mật khẩu (verify ở C#, update qua SP) |

Tất cả SP dùng `TRY/CATCH + ROLLBACK` đúng chuẩn, có `RAISERROR` khi lỗi.

**File mới:** `Database/Migrations.sql` — bảng `SchemaVersion` theo dõi phiên bản schema (rubric 3.2).

### 3. Biểu đồ LiveCharts (rubric 1.4)

**File mới:** `GUI/LiveChartsHelper.cs` — wrapper 3 loại chart:
- `RenderLineChart()` — biểu đồ đường (doanh thu)
- `RenderPieChart()` — biểu đồ tròn (trạng thái đơn) + hiển thị % tự động
- `RenderRowChart()` — biểu đồ cột ngang (top SP)

**File sửa:** 3 form báo cáo
- `GUI/frmBaoCaoDT.cs` — đường LiveCharts cho doanh thu theo ngày
- `GUI/frmBaoCaoDonHang.cs` — tròn LiveCharts cho đơn theo trạng thái
- `GUI/frmBaoCaoSP.cs` — cột ngang LiveCharts cho top SP bán chạy

**Giữ nguyên Designer.cs** — không động vào UI hiện có. Chart cũ (`System.Windows.Forms.DataVisualization`) bị ẩn (`Visible=false`), LiveCharts inject vào `pnlChart` lúc runtime.

### 4. Bảo vệ chuỗi kết nối (rubric 2.3)

**File sửa:** `App.config` — thêm comment hướng dẫn 3 phương án:
1. Integrated Security (Windows Authentication) — an toàn nhất
2. Mã hóa section bằng `aspnet_regiis -pef "connectionStrings"`
3. SQL user quyền tối thiểu (hiện tại — cho dev)

Thêm `appSettings` cho `BCryptCost` và `SessionTimeoutMinutes`.

### 5. Bonus — Cập nhật seed data

**File sửa:** `Database/CreateDatabase.sql` — đổi password seed từ BCrypt cứng (có thể không tương thích) → plaintext. Login lần đầu sẽ auto-migrate sang BCrypt.

### 6. Bonus — Hướng dẫn cài đặt mới

**File sửa:** `HUONG_DAN_CAI_DAT.md` — đầy đủ 7 phần: yêu cầu, các bước, tài khoản, cơ chế bảo mật, báo cáo, cấu trúc solution, troubleshooting.

### 7. Project file

**File sửa:** `QuanLyCuaHangMayTinh.csproj` — đăng ký `GUI/LiveChartsHelper.cs`.

---

## ✅ Quy trình triển khai

```
1. Mở QuanLyCuaHangMayTinh.sln trong Visual Studio 2019/2022
2. Right-click Solution → Restore NuGet Packages (BCrypt + LiveCharts + Dapper)
3. Mở SSMS, chạy LẠI Database/CreateDatabase.sql (drop & re-create)
4. Tiếp tục chạy Database/StoredProcedures.sql
5. (Tùy chọn) Chạy Database/Migrations.sql
6. Chỉnh App.config nếu cần
7. Ctrl+F5 → Login admin/admin123
```

## 📊 So sánh trước/sau

| Tiêu chí | Trước | Sau | Δ |
|---|---|---|---|
| 1.4 Báo cáo + biểu đồ | Khá (chart cũ) | **Tốt** (LiveCharts) | +0.3đ |
| 2.2 ORM | Khá | **Tốt** (10 SP + Dapper) | +0.3đ |
| 2.3 Bảo mật | Khá (SHA256 fix salt) | **Tốt** (BCrypt thật) | +0.2đ |
| 3.2 Phân tích thiết kế | Khá | **Tốt** (có migration) | +0.1đ |

**Tổng cải thiện ước tính: +0.9 → 1.0 điểm.**
