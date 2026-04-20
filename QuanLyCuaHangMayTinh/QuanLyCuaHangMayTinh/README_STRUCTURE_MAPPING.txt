Đã sắp xếp lại project theo cấu trúc GUI / BUS / DAL / DTO / Database.

Một số form trong project gốc không có đúng tên theo mẫu nên đã được map gần nhất như sau:
- frm_quanly -> GUI/frmMain.cs
- frmSanpham -> GUI/frmSanPham.cs
- frmDanhmucsanpham -> GUI/frmDanhMuc.cs
- frmNhanVienKho -> GUI/frmNhanVien.cs
- frmBanhang_Nhanvien -> GUI/frmPOS.cs
- frmNguyenLieu -> GUI/frmTonKho.cs
- frmDonDatHang -> GUI/frmDonHang.cs
- frmBaoCao -> GUI/frmBaoCaoDoanhThu.cs
- frmThongKeDonHang -> GUI/frmThongKeSP.cs
- frmQuanlyHoadon -> GUI/frmChiTietHoaDon.cs

Các file BUS / DAL / DTO còn thiếu trong project gốc đã được tạo khung để bạn tiếp tục phát triển.
