CAP NHAT DATA - LAN 1
=====================

Da thuc hien tren source goc ban gui:
1. Xoa Typed DataSet cu:
   - QuanLyBanHangMayTinhDataSet.xsd
   - QuanLyBanHangMayTinhDataSet1.xsd
   - cac file .Designer.cs / .xsc / .xss di kem
2. Cap nhat App.config sang DB moi: QuanLyCuaHangMayTinhDB
3. Cap nhat Function.cs va DapperRepository.cs de dung DefaultConnection
4. Them Repository moi:
   - Repositories/AuthRepository.cs
   - Repositories/ProductRepository.cs
   - Repositories/ReportRepository.cs
5. Sua frmLogin.cs sang dang nhap theo NhanVien + VaiTro moi
6. Viet lai frmBaoCao.cs va frmBaoCao.Designer.cs de bo phu thuoc vao DataSet cu
7. Them file SQL moi: database_QuanLyCuaHangMayTinh.sql

Luu y quan trong:
- Cac form nghiep vu cu (san pham / don hang / nhap kho / tra hang...) chua duoc noi lai het voi DB moi.
- Day la buoc don data + tao tang truy cap du lieu moi de tiep tuc sua tung form.
- Can mo project trong Visual Studio, Restore NuGet, chay file SQL roi Build de kiem tra loi phat sinh tiep.
