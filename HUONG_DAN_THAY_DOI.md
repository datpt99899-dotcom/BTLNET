# HƯỚNG DẪN - PHIÊN BẢN MENU ACCORDION + PHÂN QUYỀN ĐẦY ĐỦ

## 1. THAY ĐỔI CHÍNH

### Menu chính chỉ 5 nhóm lớn (giống ma trận trong sơ đồ)
Click vào header nhóm → submenu xổ xuống. Click lại → thu lại.
Chỉ 1 nhóm mở tại 1 thời điểm.

```
👤 Người dùng     → Tài khoản, Đổi mật khẩu
📦 Danh mục       → Sản phẩm, Loại SP, Thương hiệu, NCC, Khách hàng
🛒 Đơn hàng       → POS, Đơn đặt hàng, QL hóa đơn, Trả hàng
🏭 Kho/Nhập kho   → Lập phiếu nhập, Tìm phiếu nhập
📊 Báo cáo        → Doanh thu, SP bán chạy, Đơn hàng
```

### Phân quyền 4 role (bám sát ma trận trong đề)

| Role | Vào được gì |
|------|------------|
| **Admin (VT01)** | Tài khoản, Đổi MK, SP (chỉ xem), Loại SP, Thương hiệu, NCC, Khách hàng, QL hóa đơn, 3 báo cáo |
| **NV Kho (VT02)** | Đổi MK, SP (CRUD), Loại SP, Thương hiệu, NCC, Nhập kho, Tìm phiếu nhập |
| **NV Bán hàng (VT03)** | Đổi MK, SP (chỉ xem), Khách hàng, POS, Đơn đặt hàng, QL hóa đơn, Trả hàng |
| **Kế toán (VT04)** | Đổi MK, QL hóa đơn (chỉ xem), 3 báo cáo |

**Lưu ý quan trọng theo đề:**
- Admin CRUD tất cả danh mục **TRỪ sản phẩm** → vào form SP nhưng các nút Thêm/Sửa/Xóa bị disable
- NV Kho là người duy nhất CRUD sản phẩm + lập phiếu nhập
- NV Bán hàng và Kế toán: SP read-only
- Đề ghi "Báo cáo dành cho Admin" → Admin có đủ 3 báo cáo, Kế toán cũng được xem (read-only) cho hợp nghiệp vụ

## 2. CÁC FILE ĐÃ THAY ĐỔI

### GUI/frmMain.cs (VIẾT LẠI - ACCORDION MENU)
- Menu chính 5 nhóm: Người dùng, Danh mục, Đơn hàng, Kho, Báo cáo
- Mỗi nhóm có header (icon + tên + ▼/▲) và các submenu item
- `ToggleGroup()`: click header xổ/thu submenu (chỉ 1 nhóm mở)
- `ApDungPhanQuyen()`: ẩn submenu không thuộc role, ẩn cả nhóm nếu không có sub nào được phép
- `MapRoleForCategory()`: truyền đúng role vào form danh mục (Admin → "Admin", NV Kho → "Nhân viên kho", còn lại → read-only)
- Form max-screen khi chạy + có nút Đăng xuất ở góc phải header

### GUI/frmLogin.cs
- Tất cả 4 role mở `frm_quanly` (frm_quanly tự phân quyền theo `StaticData.MaVaiTro`)

### DAL/AuthRepository.cs
- Lấy mật khẩu hash từ DB → dùng `SecurityHelper.VerifyPassword()` (BCrypt-style)
- Thêm `AuthenticateByMaNV()` cho chức năng đổi mật khẩu

### SecurityHelper.cs (SỬA LỖI DLL)
- Trước: dùng BCrypt.Net (bị lỗi `System.Memory` thiếu DLL)
- Sau: dùng SHA256 + Salt cố định (đơn giản, không phụ thuộc DLL)
- Hỗ trợ FALLBACK: nếu DB còn hash BCrypt cũ → vẫn login được với mật khẩu mặc định
- → Sau khi build, login `admin/admin123` được luôn không cần làm gì thêm

### BUS/NhanVienBUS.cs
- Thêm overload `DoiMatKhau(maNV, matKhauCu, matKhauMoi)` xác thực mật khẩu cũ trước

### GUI/frmKhachHang.cs + Designer (VIẾT LOGIC)
- Dùng đúng UI Designer có sẵn
- CRUD đầy đủ: thêm tự sinh mã, sửa, xóa, tìm kiếm
- Phân quyền: Admin và NV Bán hàng được CRUD, role khác chỉ xem

### GUI/frmDonHang.cs + Designer (VIẾT LOGIC)
- Dùng đúng UI Designer có sẵn
- Quản lý đơn đặt hàng đúng đề 1.3:
  - Lọc theo trạng thái, ngày, từ khóa
  - Tạo đơn mới (dialog)
  - Cập nhật trạng thái (dialog) + chuyển sang hóa đơn bán
  - Hủy đơn (chuyển trạng thái = Hủy)
  - Xuất Excel/CSV

### GUI/frmDoiMatKhau.cs + Designer.cs + .resx (FORM MỚI)
- Form đổi mật khẩu với UI Designer chuẩn
- Kiểm tra mật khẩu cũ + mật khẩu mới >= 6 ký tự + có nút "Hiện mật khẩu"

## 3. CÁCH CHẠY VÀ DEMO

### Tài khoản test
| User | Pass | Role |
|------|------|------|
| admin | admin123 | VT01 Admin |
| kho | kho123 | VT02 NV Kho |
| banhang | banhang123 | VT03 NV Bán hàng |
| ketoan | ketoan123 | VT04 Kế toán |

### Kịch bản demo
1. **admin / admin123** → mở nhóm "Người dùng" + tài khoản
   - Thử mở các danh mục → CRUD được
   - Vào "Sản phẩm" → nút Thêm/Sửa/Xóa bị disable (theo đề)
   - Vào "Báo cáo" → xem 3 báo cáo + biểu đồ
2. **kho / kho123** → menu chỉ thấy: Danh mục, Kho
   - Vào "Sản phẩm" → CRUD đầy đủ
   - Tạo phiếu nhập kho → có transaction tự cộng tồn
3. **banhang / banhang123** → menu thấy: Đơn hàng, Danh mục (chỉ SP+KH)
   - Demo luồng: tạo đơn đặt hàng → cập nhật trạng thái → chuyển sang hóa đơn bán (ĐIỂM CHÍNH ĐỀ 1.3)
   - POS để bán tại quầy
4. **ketoan / ketoan123** → menu chỉ thấy: Báo cáo + xem hóa đơn

## 4. NẾU CẦN RESET MẬT KHẨU SANG SHA256

Chạy file `Database/ResetPasswordToSHA256.sql` trong SSMS một lần — sau đó mật khẩu trong DB sẽ ở dạng SHA256 chuẩn (không cần fallback nữa).

## 5. ĐIỂM CẦN NÓI KHI DEMO

- **Bảo mật**: SHA256 + Salt (hash 1 chiều), không lưu plain text
- **Kiến trúc 3 lớp**: GUI ↔ BUS ↔ DAL (mỗi nghiệp vụ có 3 file rõ ràng)
- **Transaction**: Trong `DonDatHangDAL.ChuyenSangHoaDon()`, `NhapKhoDAL` — đảm bảo nhất quán
- **Phân quyền 4 role**: ẩn menu + check role trong từng form (`_canManage`)
- **Đơn đặt hàng**: luồng đầy đủ Chờ xử lý → Đang giao → Đã giao → Hoàn thành (chuyển HD bán) hoặc Hủy
