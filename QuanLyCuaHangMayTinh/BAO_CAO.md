# BÁO CÁO BÀI TẬP LỚN
## Hệ thống Quản lý Cửa hàng Máy tính

**Môn:** Lập trình .NET (IS25A) — **Học viện Ngân hàng**
**Đề số:** 1 — Quản lý cửa hàng máy tính

---

## 1. Giới thiệu

### 1.1. Lý do chọn đề tài
Cửa hàng máy tính vừa và nhỏ ở Việt Nam còn quản lý thủ công bằng Excel hoặc sổ sách, dễ sai sót, khó kiểm soát tồn kho thời gian thực và không có công cụ phân tích kinh doanh hiệu quả. Nhóm chọn đề tài "Xây dựng hệ thống quản lý cửa hàng máy tính" bằng C# WinForms + SQL Server để số hóa toàn bộ quy trình bán hàng, nhập kho, trả hàng và báo cáo doanh thu.

### 1.2. Mục tiêu
- **Chính xác**: mọi dữ liệu được ghi nhận và tính toán tự động qua trigger DB
- **Hiệu quả**: rút ngắn thời gian xử lý, tăng năng suất nhân viên
- **Bảo mật**: phân quyền 4 vai trò, BCrypt + parameterized query

### 1.3. Công nghệ
| Layer | Công nghệ |
|-------|-----------|
| Ngôn ngữ | C# 7.3 |
| UI | WinForms .NET Framework 4.7.2 |
| Component | FontAwesome.Sharp, Guna.UI2 |
| Biểu đồ | LiveCharts + System.Windows.Forms.DataVisualization |
| Database | SQL Server 2017+ |
| ORM | ADO.NET (SqlCommand + SqlParameter) + Dapper |
| Bảo mật | BCrypt.Net-Next cost=11 |

---

## 2. Phân tích & Thiết kế hệ thống

### 2.1. Tác nhân & phân quyền
```
                ┌──────────────────────┐
                │   ADMIN (VT01)       │  ── toàn quyền
                └──────────────────────┘

  ┌─────────────────┐  ┌──────────────────┐  ┌─────────────────┐
  │ NV KHO (VT02)   │  │ NV BÁN HÀNG (V3) │  │ KẾ TOÁN (VT04)  │
  ├─────────────────┤  ├──────────────────┤  ├─────────────────┤
  │ - Nhập kho      │  │ - Bán hàng POS   │  │ - Báo cáo DT    │
  │ - QL sản phẩm   │  │ - Đơn đặt hàng   │  │ - Báo cáo SP    │
  │ - Tồn kho       │  │ - Trả hàng       │  │ - Báo cáo đơn   │
  │ - NCC           │  │ - Khách hàng     │  │                 │
  └─────────────────┘  └──────────────────┘  └─────────────────┘
```

### 2.2. Nghiệp vụ chính

**A. Bán hàng (POS)** — Nhân viên chọn sản phẩm, hệ thống kiểm tra tồn kho, tính tổng, lưu HĐ + chi tiết trong 1 TRANSACTION. Trigger `trg_BanHang_GiamTon` TỰ trừ `SoLuongTon` (nếu thiếu, RAISERROR + ROLLBACK).

**B. Đơn đặt hàng** — Khách đặt trước → trạng thái "Chờ xử lý"; khi xử lý xong → chuyển thành hóa đơn bán hàng trong 1 transaction.

**C. Nhập kho** — Lập phiếu nhập từ NCC. Trigger `trg_NhapKho_TangTon` TỰ cộng `SoLuongTon += SoLuong`, update `GiaNhap = DonGiaNhap`, `GiaBan = ROUND(DonGiaNhap*1.10, -3)` (lợi nhuận 10%, làm tròn nghìn).

**D. Trả hàng** — Khách trả → nhập mã HĐ + chọn SP + lý do + tình trạng. Trigger `trg_TraHang_TangTon` TỰ cộng lại tồn kho nếu `TinhTrangSP = N'Nguyên vẹn'`.

**E. Báo cáo** — Doanh thu theo ngày/tháng/năm, top SP bán chạy, đơn theo trạng thái, KPI (tổng DT, số đơn, TB/đơn) — có biểu đồ cột/ngang/tròn.

### 2.3. Kiến trúc 3 lớp

```
┌─────────────────────────────────────────────────┐
│  GUI (Presentation)                             │
│  frmLogin, frm_quanly, frmPOS, frmNhap, ...     │
└─────────────────────────────────────────────────┘
                  ↕ truyền DTO
┌─────────────────────────────────────────────────┐
│  BUS (Business Logic)                           │
│  SanPhamBUS, HoaDonBUS, NhapKhoBUS, ...          │
│  - Validation, quy tắc nghiệp vụ                │
└─────────────────────────────────────────────────┘
                  ↕
┌─────────────────────────────────────────────────┐
│  DAL (Data Access)                              │
│  SanPhamDAL, HoaDonDAL, BaoCaoDAL, ...           │
│  - 100% parameterized query                     │
│  - Transaction management                       │
└─────────────────────────────────────────────────┘
                  ↕ ADO.NET
┌─────────────────────────────────────────────────┐
│  SQL Server: QuanLyCuaHangMayTinhDB (15 bảng)   │
│  + 3 TRIGGER tự động cập nhật tồn kho           │
└─────────────────────────────────────────────────┘

DTO chung: SanPhamDTO, HoaDonBanDTO, ChiTietHoaDonDTO,
DonDatHangDTO, PhieuNhapKhoDTO, PhieuTraHangDTO, NhanVienDTO

Helper: AppTheme (màu/font), ThemeManager (apply theme),
SecurityHelper (BCrypt), Function (DB utility), StaticData (session)
```

### 2.4. Schema (15 bảng) — theo BTL__NET.docx

**VaiTro** (MaVaiTro PK, TenVaiTro UNIQUE)
**NhanVien** (MaNhanVien PK, TenDangNhap UNIQUE, MatKhau, HoTen, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, MaVaiTro FK, TrangThai BIT, NgayTao)
**KhachHang** (MaKhachHang PK, TenKhachHang, SoDienThoai UNIQUE, Email, DiaChi, **DiemTichLuy** INT DEFAULT 0)
**NhaCungCap** (**MaNCC** PK, **TenNCC**, DiaChi, SoDienThoai)
**LoaiSanPham** (MaLoai PK, TenLoai UNIQUE)
**ThuongHieu** (MaThuongHieu PK, TenThuongHieu UNIQUE)
**SanPham** (MaSanPham PK, TenSanPham, MaLoai FK, MaThuongHieu FK, **MaNCC** FK, GiaNhap CHECK≥0, GiaBan CHECK≥0, SoLuongTon CHECK≥0, MoTa, **HinhAnh NOT NULL**, BaoHanhThang DEFAULT 12)
**DonDatHang** (MaDonDatHang PK, NgayDat, MaKhachHang FK, MaNhanVien FK, **TienGiam** DEFAULT 0, TongTien, TrangThai)
**ChiTietDonDatHang** (composite PK: MaDonDatHang+MaSanPham, SoLuong CHECK>0, DonGia)
**HoaDonBan** (MaHoaDonBan PK, NgayBan, MaKhachHang FK NULL, MaNhanVien FK, MaDonDatHang FK NULL, **TienGiam**, TongTien, **HinhThucThanhToan**, TrangThai)
**ChiTietHoaDonBan** (composite PK, SoLuong CHECK>0, DonGia)
**PhieuNhapKho** (MaPhieuNhap PK, NgayNhap, **MaNCC** FK, MaNhanVien FK, TongTien)
**ChiTietPhieuNhap** (composite PK, SoLuong CHECK>0, DonGiaNhap)
**PhieuTraHang** (**MaPhieuTra** PK, NgayTra, MaHoaDonBan FK, MaNhanVien FK, TongTien, **LyDo NOT NULL**)
**ChiTietPhieuTraHang** (composite PK: MaPhieuTra+MaSanPham, SoLuongTra CHECK>0, DonGia, **TinhTrangSP NOT NULL**)

### 2.5. 3 TRIGGER tự động (rất quan trọng!)

**Trigger 1 — `trg_BanHang_GiamTon` ON ChiTietHoaDonBan AFTER INSERT:**
- Kiểm tra `SoLuongTon >= SoLuong` cho từng dòng insert
- Nếu thiếu → `RAISERROR + ROLLBACK TRANSACTION`
- Nếu đủ → `UPDATE SoLuongTon -= SoLuong`

**Trigger 2 — `trg_NhapKho_TangTon` ON ChiTietPhieuNhap AFTER INSERT:**
- `SoLuongTon += SoLuong`
- `GiaNhap = DonGiaNhap` (cập nhật giá nhập mới)
- `GiaBan = ROUND(DonGiaNhap * 1.10, -3)` (auto lợi nhuận 10%)

**Trigger 3 — `trg_TraHang_TangTon` ON ChiTietPhieuTraHang AFTER INSERT:**
- Chỉ `SoLuongTon += SoLuongTra` nếu `TinhTrangSP = N'Nguyên vẹn'`

→ Hệ quả: DAL **KHÔNG** được phép tự `UPDATE SoLuongTon` thủ công, sẽ bị trừ 2 lần.

---

## 3. Xây dựng hệ thống

### 3.1. Cấu trúc thư mục
```
QuanLyCuaHangMayTinh/
├── App.config              (kết nối DB)
├── Program.cs              (entry → frmLogin)
├── AppTheme.cs             (palette + font)
├── ThemeManager.cs         (apply theme recursive)
├── SecurityHelper.cs       (BCrypt)
├── StaticData.cs           (session)
├── Database/
│   └── CreateDatabase.sql  (15 bảng + 3 trigger + seed)
├── DTO/                    (7 file)
├── DAL/                    (7 DAL + AuthRepository + Function)
├── BUS/                    (7 BUS - validation)
└── GUI/                    (20+ form)
```

### 3.2. Form chính

| Vai trò | Shell form | Form nghiệp vụ |
|---------|-----------|-----------------|
| Admin   | `frm_quanly` | Tất cả |
| NV kho  | `frmNhanVien` | frmNhap, frmTimKiemPhieuNhap, frmSanpham, frmTonKho |
| NV bán  | `frmQuanlybanhang_Nhanvien` | frmPOS, frmDonHang, frmTraHang, frmKhachHang |
| Kế toán | `frmBaoCaoDT` | frmBaoCaoDT, frmBaoCaoSP, frmBaoCaoDonHang |

### 3.3. Luồng nghiệp vụ tiêu biểu — Bán hàng

1. NV bán hàng mở `frmPOS`
2. Search SP, double-click thêm vào giỏ → giỏ tự tính `ThanhTien = GiaBan * SoLuong`
3. Nhập % giảm giá → cập nhật `TongTien`
4. Nhấn "Thanh toán" → tạo `HoaDonBanDTO` + List<ChiTietHoaDonDTO>
5. Gọi `HoaDonBUS.TaoHoaDon` → kiểm tra (chi tiết không rỗng, tổng > 0) → gọi `HoaDonDAL.TaoHoaDon`
6. DAL mở `BeginTransaction`, INSERT HoaDonBan + INSERT từng ChiTietHoaDonBan
7. **Trigger DB** tự kiểm tra tồn kho + trừ tồn → nếu lỗi, transaction rollback
8. Hiển thị "Thanh toán thành công" + làm mới grid

---

## 4. Kiểm thử

### 4.1. Test cases

| TC | Mô tả | Kết quả |
|----|-------|---------|
| TC01 | Login đúng (admin/admin123) | Mở Admin shell |
| TC02 | Login sai mật khẩu | Báo lỗi |
| TC03 | Thêm SP giá bán < giá nhập | BUS validation lỗi |
| TC04 | Bán SP có đủ tồn | Trừ tồn kho qua trigger |
| TC05 | Bán SP vượt tồn kho | Trigger RAISERROR + Rollback |
| TC06 | Nhập kho 10 SP | Tồn +10, GiaBan auto = GiaNhap*1.1 |
| TC07 | Trả hàng "Nguyên vẹn" | Tồn được cộng lại |
| TC08 | Trả hàng "Hỏng" | Tồn KHÔNG cộng lại |
| TC09 | Báo cáo doanh thu 30 ngày | Hiển thị KPI + biểu đồ |
| TC10 | Phân quyền NV kho | Ẩn menu QL tài khoản, báo cáo |

### 4.2. Bảo mật

| Vector tấn công | Phòng ngừa |
|-----------------|------------|
| Brute force mật khẩu | BCrypt cost=11 (~250ms/lần thử) |
| SQL Injection | 100% `SqlParameter` |
| Plaintext password | DB chỉ lưu hash; Verify không bao giờ so plain |
| Race condition khi bán | Trigger + transaction trong 1 batch |
| Mất tính toàn vẹn | Transaction rollback ở mọi nghiệp vụ đa-bảng |

---

## 5. Kết luận

### 5.1. Đã đạt được
- ✅ Kiến trúc 3 lớp DAL/BUS/GUI tách biệt, DTO chung
- ✅ 4 vai trò có shell riêng
- ✅ CRUD đầy đủ + bán/nhập/trả/đặt hàng với transaction
- ✅ 3 TRIGGER đảm bảo nhất quán tồn kho ở mức DB
- ✅ BCrypt + parameterized query
- ✅ 3 báo cáo có biểu đồ trực quan
- ✅ Theme đồng bộ qua `AppTheme` + `ThemeManager`
- ✅ Phân quyền menu theo vai trò

### 5.2. Hạn chế
- ❌ Chưa có chức năng quên mật khẩu (cần SMTP)
- ❌ Chưa có audit log đầy đủ
- ❌ Chưa xuất Excel báo cáo
- ❌ Chưa multi-user phiên đồng thời

### 5.3. Hướng phát triển
1. Web hóa qua ASP.NET Core
2. Cloud DB (Azure SQL)
3. API + mobile app cho khách hàng
4. Khuyến mãi & voucher
5. Tích hợp ZaloPay/Momo/VNPay
6. Audit log đầy đủ
7. Dashboard real-time với SignalR

Nhóm tự đánh giá đạt **9.0 – 9.5/10**.
