/* ============================================================
   Hệ thống quản lý cửa hàng máy tính — Đề số 1
   Database: QuanLyCuaHangMayTinhDB
   ============================================================
   Tài liệu: BTL__NET.docx — Chương 2: Phân tích và thiết kế hệ thống
   15 bảng + 3 trigger tự động cập nhật tồn kho
   Mật khẩu: BCrypt cost=11 (admin/admin123, kho/kho123, ...)
   ============================================================ */

IF DB_ID(N'QuanLyCuaHangMayTinhDB') IS NOT NULL
BEGIN
    ALTER DATABASE QuanLyCuaHangMayTinhDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyCuaHangMayTinhDB;
END
GO

CREATE DATABASE QuanLyCuaHangMayTinhDB;
GO
USE QuanLyCuaHangMayTinhDB;
GO

/* ───────────────────────── 1. VaiTro ───────────────────────── */
CREATE TABLE VaiTro (
    MaVaiTro  NVARCHAR(10)  NOT NULL PRIMARY KEY,
    TenVaiTro NVARCHAR(100) NOT NULL UNIQUE
);
GO

/* ───────────────────────── 2. NhanVien ───────────────────────── */
CREATE TABLE NhanVien (
    MaNhanVien   NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenDangNhap  NVARCHAR(50)  NOT NULL UNIQUE,
    MatKhau      NVARCHAR(255) NOT NULL,
    HoTen        NVARCHAR(150) NOT NULL,
    GioiTinh     NVARCHAR(10)  NULL,
    NgaySinh     DATE          NULL,
    SoDienThoai  NVARCHAR(20)  NULL,
    Email        NVARCHAR(150) NULL,
    DiaChi       NVARCHAR(255) NULL,
    MaVaiTro     NVARCHAR(10)  NOT NULL,
    TrangThai    BIT           NOT NULL DEFAULT 1,
    NgayTao      DATETIME      NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_NhanVien_VaiTro FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);
GO

/* ───────────────────────── 3. KhachHang ───────────────────────── */
CREATE TABLE KhachHang (
    MaKhachHang  NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenKhachHang NVARCHAR(150) NOT NULL,
    SoDienThoai  NVARCHAR(20)  NULL UNIQUE,
    Email        NVARCHAR(150) NULL,
    DiaChi       NVARCHAR(255) NULL,
    DiemTichLuy  INT           NOT NULL DEFAULT 0
);
GO

/* ───────────────────────── 4. NhaCungCap ───────────────────────── */
CREATE TABLE NhaCungCap (
    MaNCC       NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenNCC      NVARCHAR(150) NOT NULL,
    DiaChi      NVARCHAR(255) NULL,
    SoDienThoai NVARCHAR(20)  NULL
);
GO

/* ───────────────────────── 5. LoaiSanPham ───────────────────────── */
CREATE TABLE LoaiSanPham (
    MaLoai  NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenLoai NVARCHAR(150) NOT NULL UNIQUE
);
GO

/* ───────────────────────── 6. ThuongHieu ───────────────────────── */
CREATE TABLE ThuongHieu (
    MaThuongHieu  NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenThuongHieu NVARCHAR(150) NOT NULL UNIQUE
);
GO

/* ───────────────────────── 7. SanPham (bảng trung tâm) ───────────────────────── */
CREATE TABLE SanPham (
    MaSanPham    NVARCHAR(20)   NOT NULL PRIMARY KEY,
    TenSanPham   NVARCHAR(200)  NOT NULL,
    MaLoai       NVARCHAR(20)   NOT NULL,
    MaThuongHieu NVARCHAR(20)   NOT NULL,
    MaNCC        NVARCHAR(20)   NOT NULL,
    GiaNhap      DECIMAL(18,2)  NOT NULL DEFAULT 0 CHECK (GiaNhap >= 0),
    GiaBan       DECIMAL(18,2)  NOT NULL DEFAULT 0 CHECK (GiaBan >= 0),
    SoLuongTon   INT            NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0),
    MoTa         NVARCHAR(500)  NULL,
    HinhAnh      NVARCHAR(300)  NOT NULL DEFAULT N'default.png',
    BaoHanhThang INT            NOT NULL DEFAULT 12 CHECK (BaoHanhThang >= 0),
    CONSTRAINT FK_SanPham_Loai       FOREIGN KEY (MaLoai)       REFERENCES LoaiSanPham(MaLoai),
    CONSTRAINT FK_SanPham_ThuongHieu FOREIGN KEY (MaThuongHieu) REFERENCES ThuongHieu(MaThuongHieu),
    CONSTRAINT FK_SanPham_NCC        FOREIGN KEY (MaNCC)        REFERENCES NhaCungCap(MaNCC)
);
GO

/* ───────────────────────── 8. DonDatHang ───────────────────────── */
CREATE TABLE DonDatHang (
    MaDonDatHang NVARCHAR(20)  NOT NULL PRIMARY KEY,
    NgayDat      DATETIME      NOT NULL DEFAULT GETDATE(),
    MaKhachHang  NVARCHAR(20)  NOT NULL,
    MaNhanVien   NVARCHAR(20)  NOT NULL,
    TienGiam     DECIMAL(18,2) NOT NULL DEFAULT 0,
    TongTien     DECIMAL(18,2) NOT NULL DEFAULT 0,
    TrangThai    NVARCHAR(30)  NOT NULL DEFAULT N'Chờ xử lý',
    CONSTRAINT FK_DonDatHang_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    CONSTRAINT FK_DonDatHang_NhanVien  FOREIGN KEY (MaNhanVien)  REFERENCES NhanVien(MaNhanVien)
);
GO

/* ───────────────────────── 9. ChiTietDonDatHang ───────────────────────── */
CREATE TABLE ChiTietDonDatHang (
    MaDonDatHang NVARCHAR(20)  NOT NULL,
    MaSanPham    NVARCHAR(20)  NOT NULL,
    SoLuong      INT           NOT NULL CHECK (SoLuong > 0),
    DonGia       DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietDonDatHang PRIMARY KEY (MaDonDatHang, MaSanPham),
    CONSTRAINT FK_CTDDH_DonDatHang FOREIGN KEY (MaDonDatHang) REFERENCES DonDatHang(MaDonDatHang),
    CONSTRAINT FK_CTDDH_SanPham    FOREIGN KEY (MaSanPham)    REFERENCES SanPham(MaSanPham)
);
GO

/* ───────────────────────── 10. HoaDonBan ───────────────────────── */
CREATE TABLE HoaDonBan (
    MaHoaDonBan        NVARCHAR(20)  NOT NULL PRIMARY KEY,
    NgayBan            DATETIME      NOT NULL DEFAULT GETDATE(),
    MaKhachHang        NVARCHAR(20)  NULL,
    MaNhanVien         NVARCHAR(20)  NOT NULL,
    MaDonDatHang       NVARCHAR(20)  NULL,
    TienGiam           DECIMAL(18,2) NOT NULL DEFAULT 0,
    TongTien           DECIMAL(18,2) NOT NULL DEFAULT 0,
    HinhThucThanhToan  NVARCHAR(50)  NULL,
    TrangThai          NVARCHAR(30)  NOT NULL DEFAULT N'Hoàn thành',
    CONSTRAINT FK_HoaDonBan_KhachHang  FOREIGN KEY (MaKhachHang)  REFERENCES KhachHang(MaKhachHang),
    CONSTRAINT FK_HoaDonBan_NhanVien   FOREIGN KEY (MaNhanVien)   REFERENCES NhanVien(MaNhanVien),
    CONSTRAINT FK_HoaDonBan_DonDatHang FOREIGN KEY (MaDonDatHang) REFERENCES DonDatHang(MaDonDatHang)
);
GO

/* ───────────────────────── 11. ChiTietHoaDonBan ───────────────────────── */
CREATE TABLE ChiTietHoaDonBan (
    MaHoaDonBan NVARCHAR(20)  NOT NULL,
    MaSanPham   NVARCHAR(20)  NOT NULL,
    SoLuong     INT           NOT NULL CHECK (SoLuong > 0),
    DonGia      DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietHoaDonBan PRIMARY KEY (MaHoaDonBan, MaSanPham),
    CONSTRAINT FK_CTHDB_HoaDonBan FOREIGN KEY (MaHoaDonBan) REFERENCES HoaDonBan(MaHoaDonBan),
    CONSTRAINT FK_CTHDB_SanPham   FOREIGN KEY (MaSanPham)   REFERENCES SanPham(MaSanPham)
);
GO

/* ───────────────────────── 12. PhieuNhapKho ───────────────────────── */
CREATE TABLE PhieuNhapKho (
    MaPhieuNhap NVARCHAR(20)  NOT NULL PRIMARY KEY,
    NgayNhap    DATETIME      NOT NULL DEFAULT GETDATE(),
    MaNCC       NVARCHAR(20)  NOT NULL,
    MaNhanVien  NVARCHAR(20)  NOT NULL,
    TongTien    DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_PhieuNhap_NCC      FOREIGN KEY (MaNCC)      REFERENCES NhaCungCap(MaNCC),
    CONSTRAINT FK_PhieuNhap_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

/* ───────────────────────── 13. ChiTietPhieuNhap ───────────────────────── */
CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhap NVARCHAR(20)  NOT NULL,
    MaSanPham   NVARCHAR(20)  NOT NULL,
    SoLuong     INT           NOT NULL CHECK (SoLuong > 0),
    DonGiaNhap  DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietPhieuNhap PRIMARY KEY (MaPhieuNhap, MaSanPham),
    CONSTRAINT FK_CTPN_PhieuNhap FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhapKho(MaPhieuNhap),
    CONSTRAINT FK_CTPN_SanPham   FOREIGN KEY (MaSanPham)   REFERENCES SanPham(MaSanPham)
);
GO

/* ───────────────────────── 14. PhieuTraHang ───────────────────────── */
CREATE TABLE PhieuTraHang (
    MaPhieuTra   NVARCHAR(20)  NOT NULL PRIMARY KEY,
    NgayTra      DATETIME      NOT NULL DEFAULT GETDATE(),
    MaHoaDonBan  NVARCHAR(20)  NOT NULL,
    MaNhanVien   NVARCHAR(20)  NOT NULL,
    TongTien     DECIMAL(18,2) NOT NULL DEFAULT 0,
    LyDo         NVARCHAR(255) NOT NULL,
    CONSTRAINT FK_PhieuTra_HoaDonBan FOREIGN KEY (MaHoaDonBan) REFERENCES HoaDonBan(MaHoaDonBan),
    CONSTRAINT FK_PhieuTra_NhanVien  FOREIGN KEY (MaNhanVien)  REFERENCES NhanVien(MaNhanVien)
);
GO

/* ───────────────────────── 15. ChiTietPhieuTraHang ───────────────────────── */
CREATE TABLE ChiTietPhieuTraHang (
    MaPhieuTra   NVARCHAR(20)  NOT NULL,
    MaSanPham    NVARCHAR(20)  NOT NULL,
    SoLuongTra   INT           NOT NULL CHECK (SoLuongTra > 0),
    DonGia       DECIMAL(18,2) NOT NULL,
    TinhTrangSP  NVARCHAR(100) NOT NULL DEFAULT N'Nguyên vẹn',
    CONSTRAINT PK_ChiTietPhieuTraHang PRIMARY KEY (MaPhieuTra, MaSanPham),
    CONSTRAINT FK_CTPT_PhieuTra FOREIGN KEY (MaPhieuTra) REFERENCES PhieuTraHang(MaPhieuTra),
    CONSTRAINT FK_CTPT_SanPham  FOREIGN KEY (MaSanPham)  REFERENCES SanPham(MaSanPham)
);
GO

/* ═══════════════════════════════════════════════════════════════════
   TRIGGER 1: Tự trừ tồn kho khi bán hàng (theo spec)
   ═══════════════════════════════════════════════════════════════════ */
CREATE TRIGGER trg_BanHang_GiamTon
ON ChiTietHoaDonBan AFTER INSERT
AS BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1
        FROM SanPham sp JOIN inserted i ON sp.MaSanPham = i.MaSanPham
        WHERE sp.SoLuongTon < i.SoLuong
    )
    BEGIN
        RAISERROR (N'So luong ton kho khong du de ban!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
    UPDATE sp
    SET sp.SoLuongTon = sp.SoLuongTon - i.SoLuong
    FROM SanPham sp JOIN inserted i ON sp.MaSanPham = i.MaSanPham;
END
GO

/* ═══════════════════════════════════════════════════════════════════
   TRIGGER 2: Tự cộng tồn kho + cập nhật giá khi nhập hàng
   ═══════════════════════════════════════════════════════════════════ */
CREATE TRIGGER trg_NhapKho_TangTon
ON ChiTietPhieuNhap AFTER INSERT
AS BEGIN
    SET NOCOUNT ON;
    UPDATE sp
    SET sp.SoLuongTon = sp.SoLuongTon + i.SoLuong,
        sp.GiaNhap    = i.DonGiaNhap,
        sp.GiaBan     = ROUND(i.DonGiaNhap * 1.10, -3)
    FROM SanPham sp JOIN inserted i ON sp.MaSanPham = i.MaSanPham;
END
GO

/* ═══════════════════════════════════════════════════════════════════
   TRIGGER 3: Tự cộng lại tồn kho khi trả hàng, chỉ với SP nguyên vẹn
   ═══════════════════════════════════════════════════════════════════ */
CREATE TRIGGER trg_TraHang_TangTon
ON ChiTietPhieuTraHang AFTER INSERT
AS BEGIN
    SET NOCOUNT ON;
    UPDATE sp
    SET sp.SoLuongTon = sp.SoLuongTon + i.SoLuongTra
    FROM SanPham sp JOIN inserted i ON sp.MaSanPham = i.MaSanPham
    WHERE i.TinhTrangSP = N'Nguyên vẹn';
END
GO

/* ═══════════════════════════════════════════════════════════════════
   DỮ LIỆU MẪU
   ═══════════════════════════════════════════════════════════════════ */
INSERT INTO VaiTro (MaVaiTro, TenVaiTro) VALUES
(N'VT01', N'Admin'),
(N'VT02', N'NV Kho'),
(N'VT03', N'NV Bán hàng'),
(N'VT04', N'Kế toán');
GO

-- Mật khẩu seed: lưu PLAINTEXT cho demo dễ.
-- Khi user login lần đầu, AuthRepository sẽ tự gọi SecurityHelper.HashPassword
-- (BCrypt cost=11) và UPDATE lại DB → từ lần thứ 2 trở đi, DB lưu BCrypt hash an toàn.
-- Cơ chế này được mô tả chi tiết trong Chương 4 — Bảo mật hệ thống.
--   admin   / admin123
--   kho     / kho123
--   banhang / banhang123
--   ketoan  / ketoan123
INSERT INTO NhanVien (MaNhanVien, TenDangNhap, MatKhau, HoTen, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, MaVaiTro) VALUES
(N'NV001', N'admin',   N'admin123',   N'Nguyễn Văn Admin',  N'Nam', '1990-01-01', N'0912345678', N'admin@shop.com',   N'Hà Nội',         N'VT01'),
(N'NV002', N'kho',     N'kho123',     N'Trần Thị Kho',      N'Nữ',  '1992-05-12', N'0912345679', N'kho@shop.com',     N'Hà Nội',         N'VT02'),
(N'NV003', N'banhang', N'banhang123', N'Lê Văn Bán Hàng',   N'Nam', '1995-08-20', N'0912345680', N'banhang@shop.com', N'Hà Nội',         N'VT03'),
(N'NV004', N'ketoan',  N'ketoan123',  N'Phạm Thị Kế Toán',  N'Nữ',  '1993-11-03', N'0912345681', N'ketoan@shop.com',  N'Hà Nội',         N'VT04');
GO

INSERT INTO KhachHang (MaKhachHang, TenKhachHang, SoDienThoai, Email, DiaChi, DiemTichLuy) VALUES
(N'KH001', N'Nguyễn Văn An',     N'0901111111', N'an.nguyen@gmail.com',     N'Số 12 Trần Phú, Hà Nội',          150),
(N'KH002', N'Trần Thị Bình',     N'0902222222', N'binh.tran@gmail.com',     N'Số 5 Lạch Tray, Hải Phòng',       80),
(N'KH003', N'Lê Văn Cường',      N'0903333333', N'cuong.le@gmail.com',      N'Số 7 Bạch Đằng, Đà Nẵng',         220),
(N'KH004', N'Phạm Thị Dung',     N'0904444444', N'dung.pham@gmail.com',     N'Số 9 Nguyễn Huệ, TP HCM',         50),
(N'KH005', N'Hoàng Văn Em',      N'0905555555', N'em.hoang@gmail.com',      N'Số 11 Ninh Kiều, Cần Thơ',        300),
(N'KH006', N'Đặng Thị Phương',   N'0906111222', N'phuong.dang@gmail.com',   N'Số 14 Lê Duẩn, Hà Nội',           120),
(N'KH007', N'Vũ Minh Giang',     N'0906222333', N'giang.vu@gmail.com',      N'Số 22 Cầu Giấy, Hà Nội',          90),
(N'KH008', N'Bùi Thu Hà',        N'0906333444', N'ha.bui@gmail.com',        N'Số 8 Phan Đình Phùng, Hà Nội',    180),
(N'KH009', N'Đỗ Quốc Khánh',     N'0906444555', N'khanh.do@gmail.com',      N'Số 18 Kim Mã, Hà Nội',            260),
(N'KH010', N'Ngô Thanh Linh',    N'0906555666', N'linh.ngo@gmail.com',      N'Số 33 Tôn Đức Thắng, TP HCM',     45),
(N'KH011', N'Trương Văn Minh',   N'0906666777', N'minh.truong@gmail.com',   N'Số 5 Hai Bà Trưng, TP HCM',       195),
(N'KH012', N'Nguyễn Hồng Nhung', N'0906777888', N'nhung.nguyen@gmail.com',  N'Số 27 Quang Trung, Hải Phòng',    110),
(N'KH013', N'Phan Văn Phúc',     N'0906888999', N'phuc.phan@gmail.com',     N'Số 14 Hùng Vương, Đà Nẵng',       75),
(N'KH014', N'Lý Mai Quỳnh',      N'0907111222', N'quynh.ly@gmail.com',      N'Số 6 Lý Thường Kiệt, Huế',        310),
(N'KH015', N'Hà Tuấn Sơn',       N'0907222333', N'son.ha@gmail.com',        N'Số 19 Trần Hưng Đạo, Hà Nội',     60),
(N'KH016', N'Cao Thu Trang',     N'0907333444', N'trang.cao@gmail.com',     N'Số 25 Nguyễn Văn Cừ, TP HCM',     145),
(N'KH017', N'Mai Văn Tùng',      N'0907444555', N'tung.mai@gmail.com',      N'Số 31 Lê Lợi, Vinh',              0),
(N'KH018', N'Tô Hoàng Uyên',     N'0907555666', N'uyen.to@gmail.com',       N'Số 4 Phạm Văn Đồng, Hà Nội',      230),
(N'KH019', N'Đinh Hữu Việt',     N'0907666777', N'viet.dinh@gmail.com',     N'Số 16 Nguyễn Trãi, TP HCM',       95),
(N'KH020', N'Trịnh Bảo Xuân',    N'0907777888', N'xuan.trinh@gmail.com',    N'Số 21 Trần Phú, Nha Trang',       170),
(N'KH021', N'Lương Thị Yến',     N'0907888999', N'yen.luong@gmail.com',     N'Số 12 Hồ Tùng Mậu, Hà Nội',       40),
(N'KH022', N'Nguyễn Hoàng Anh',  N'0908111222', N'anh.nguyen@gmail.com',    N'Số 8 Nguyễn Văn Linh, Hà Nội',    255),
(N'KH023', N'Trần Đức Bảo',      N'0908222333', N'bao.tran@gmail.com',      N'Số 13 Lê Văn Sỹ, TP HCM',         130),
(N'KH024', N'Lê Quỳnh Chi',      N'0908333444', N'chi.le@gmail.com',        N'Số 17 Phan Bội Châu, Đà Nẵng',    85),
(N'KH025', N'Phạm Hữu Dũng',     N'0908444555', N'dung.pham2@gmail.com',    N'Số 9 Trần Nhân Tông, Hà Nội',     210),
(N'KH026', N'Hoàng Bảo Hân',     N'0908555666', N'han.hoang@gmail.com',     N'Số 6 Hoàng Hoa Thám, Hà Nội',     35),
(N'KH027', N'Nguyễn Quang Huy',  N'0908666777', N'huy.nguyen@gmail.com',    N'Số 28 Lê Hồng Phong, Hải Phòng',  165),
(N'KH028', N'Trần Mỹ Linh',      N'0908777888', N'linh.tran@gmail.com',     N'Số 11 Nguyễn Thái Học, Huế',      105),
(N'KH029', N'Đỗ Văn Nam',        N'0908888999', N'nam.do@gmail.com',        N'Số 23 Phan Châu Trinh, Đà Nẵng',  280),
(N'KH030', N'Vũ Thị Oanh',       N'0909111222', N'oanh.vu@gmail.com',       N'Số 7 Trường Chinh, Hà Nội',       70);
GO

INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai) VALUES
(N'NCC01', N'Công ty TNHH ASUS Việt Nam',           N'Số 1 Nguyễn Văn Linh, Hà Nội',     N'02438123456'),
(N'NCC02', N'Công ty TNHH Dell Việt Nam',           N'Số 2 Trần Hưng Đạo, Hà Nội',       N'02438123457'),
(N'NCC03', N'Công ty TNHH Logitech VN',             N'Số 3 Hai Bà Trưng, Hà Nội',        N'02438123458'),
(N'NCC04', N'Công ty TNHH HP Việt Nam',             N'Số 4 Lê Lợi, TP HCM',              N'02838123459'),
(N'NCC05', N'Công ty TNHH Lenovo VN',               N'Số 5 Nguyễn Trãi, TP HCM',         N'02838123460'),
(N'NCC06', N'Công ty TNHH MSI Việt Nam',            N'Số 6 Phạm Văn Đồng, Hà Nội',       N'02438123461'),
(N'NCC07', N'Công ty CP Phân phối Acer VN',         N'Số 7 Lê Duẩn, TP HCM',             N'02838123462'),
(N'NCC08', N'Công ty TNHH Samsung Electronics VN',  N'Số 8 Trần Phú, Bắc Ninh',          N'02238123463'),
(N'NCC09', N'Công ty TNHH Intel Vietnam',           N'KCN Sài Gòn Hi-Tech, TP HCM',      N'02838123464'),
(N'NCC10', N'Công ty TNHH AMD Vietnam',             N'Số 10 Nguyễn Văn Cừ, TP HCM',      N'02838123465'),
(N'NCC11', N'Công ty TNHH Kingston Việt Nam',       N'Số 11 Tôn Đức Thắng, Hà Nội',      N'02438123466'),
(N'NCC12', N'Công ty TNHH Razer Việt Nam',          N'Số 12 Hồ Tùng Mậu, Hà Nội',        N'02438123467');
GO

INSERT INTO LoaiSanPham (MaLoai, TenLoai) VALUES
(N'L01', N'Laptop'),
(N'L02', N'PC Desktop'),
(N'L03', N'Màn hình'),
(N'L04', N'Phụ kiện'),
(N'L05', N'Linh kiện'),
(N'L06', N'Thiết bị mạng'),
(N'L07', N'Thiết bị lưu trữ'),
(N'L08', N'Máy in & Scan');
GO

INSERT INTO ThuongHieu (MaThuongHieu, TenThuongHieu) VALUES
(N'TH01', N'ASUS'),
(N'TH02', N'Dell'),
(N'TH03', N'Logitech'),
(N'TH04', N'HP'),
(N'TH05', N'Lenovo'),
(N'TH06', N'Samsung'),
(N'TH07', N'Intel'),
(N'TH08', N'MSI'),
(N'TH09', N'Acer'),
(N'TH10', N'AMD'),
(N'TH11', N'Kingston'),
(N'TH12', N'Razer'),
(N'TH13', N'Apple'),
(N'TH14', N'LG'),
(N'TH15', N'Canon');
GO

INSERT INTO SanPham (MaSanPham, TenSanPham, MaLoai, MaThuongHieu, MaNCC, GiaNhap, GiaBan, SoLuongTon, MoTa, HinhAnh, BaoHanhThang) VALUES
-- Laptop (L01)
(N'SP001', N'ASUS TUF Gaming F15',         N'L01', N'TH01', N'NCC01', 18500000, 21000000, 15, N'Laptop gaming i5-12500H, RTX 3050, 16GB RAM, 512GB SSD',           N'sp001.png', 24),
(N'SP002', N'Dell XPS 13 Plus',             N'L01', N'TH02', N'NCC02', 28000000, 32500000, 8,  N'Ultrabook cao cấp i7-1360P, 16GB RAM, 1TB SSD, màn OLED',          N'sp002.png', 24),
(N'SP003', N'HP Pavilion 15',               N'L01', N'TH04', N'NCC04', 16000000, 18500000, 12, N'Laptop văn phòng i5-1235U, 8GB RAM, 512GB SSD',                    N'sp003.png', 12),
(N'SP004', N'Lenovo ThinkPad E14',          N'L01', N'TH05', N'NCC05', 17500000, 20500000, 10, N'Laptop doanh nhân i5-1235U, 16GB RAM, 512GB SSD',                  N'sp004.png', 24),
(N'SP005', N'ASUS ROG Strix G15',           N'L01', N'TH01', N'NCC01', 25000000, 29900000, 6,  N'Laptop gaming RTX 4060, 32GB RAM',                                 N'sp005.png', 24),
(N'SP006', N'Acer Nitro 5',                 N'L01', N'TH09', N'NCC07', 19000000, 22500000, 14, N'Laptop gaming i5-12450H, RTX 3050 4GB, 16GB RAM',                  N'sp006.png', 24),
(N'SP007', N'MSI Modern 14',                N'L01', N'TH08', N'NCC06', 15500000, 17900000, 9,  N'Laptop văn phòng i5-1235U, 8GB RAM, 256GB SSD',                    N'sp007.png', 12),
(N'SP008', N'Lenovo IdeaPad Slim 5',        N'L01', N'TH05', N'NCC05', 14000000, 16500000, 11, N'Laptop văn phòng Ryzen 5 7530U, 16GB RAM, 512GB SSD',              N'sp008.png', 24),
(N'SP009', N'HP Victus 15',                 N'L01', N'TH04', N'NCC04', 20000000, 23500000, 7,  N'Laptop gaming i5-12450H, RTX 3050 Ti, 16GB RAM',                   N'sp009.png', 24),
(N'SP010', N'MacBook Air M2',               N'L01', N'TH13', N'NCC04', 27000000, 31500000, 5,  N'MacBook Air M2 8-core, 8GB RAM, 256GB SSD',                        N'sp010.png', 12),
(N'SP011', N'Dell Inspiron 15',             N'L01', N'TH02', N'NCC02', 13500000, 15900000, 13, N'Laptop văn phòng i3-1215U, 8GB RAM, 256GB SSD',                    N'sp011.png', 12),
(N'SP012', N'ASUS Zenbook 14 OLED',         N'L01', N'TH01', N'NCC01', 22000000, 25900000, 8,  N'Ultrabook i7-1360P, 16GB RAM, 1TB SSD, OLED 2K',                   N'sp012.png', 24),

-- PC Desktop (L02)
(N'SP013', N'PC Gaming RTX 4060',           N'L02', N'TH07', N'NCC01', 22000000, 26000000, 5,  N'PC gaming i7-13700F, 32GB RAM, RTX 4060 8GB',                      N'sp013.png', 24),
(N'SP014', N'PC Văn phòng i5-13400',        N'L02', N'TH07', N'NCC09', 11000000, 13500000, 12, N'PC i5-13400, 16GB RAM, 512GB SSD, không card đồ họa rời',          N'sp014.png', 24),
(N'SP015', N'PC Gaming RTX 4070',           N'L02', N'TH08', N'NCC06', 35000000, 41000000, 4,  N'PC gaming i7-13700K, 32GB DDR5, RTX 4070 12GB',                    N'sp015.png', 24),
(N'SP016', N'PC AMD Ryzen 5 5600',          N'L02', N'TH10', N'NCC10', 12500000, 14900000, 9,  N'PC Ryzen 5 5600, 16GB RAM, 512GB SSD, RX 6600',                    N'sp016.png', 24),
(N'SP017', N'PC Workstation Dell',          N'L02', N'TH02', N'NCC02', 28000000, 32500000, 3,  N'PC workstation Xeon, 32GB ECC RAM, Quadro T1000',                  N'sp017.png', 36),

-- Màn hình (L03)
(N'SP018', N'Màn hình ASUS TUF 27 inch',    N'L03', N'TH01', N'NCC01', 5500000,  6900000,  20, N'Màn hình 27 inch 2K 165Hz IPS',                                    N'sp018.png', 24),
(N'SP019', N'Màn hình Samsung 24 inch',     N'L03', N'TH06', N'NCC08', 3200000,  4100000,  25, N'Màn hình 24 inch FullHD 75Hz',                                     N'sp019.png', 24),
(N'SP020', N'Màn hình LG UltraGear 27"',    N'L03', N'TH14', N'NCC08', 7800000,  9500000,  15, N'Màn hình gaming 27 inch 2K 165Hz Nano IPS',                        N'sp020.png', 24),
(N'SP021', N'Màn hình Dell P2422H 24"',     N'L03', N'TH02', N'NCC02', 4200000,  5300000,  18, N'Màn hình văn phòng 24 inch IPS FullHD',                            N'sp021.png', 36),
(N'SP022', N'Màn hình MSI Optix 32"',       N'L03', N'TH08', N'NCC06', 9500000,  11500000, 10, N'Màn hình cong 32 inch 2K 165Hz',                                   N'sp022.png', 24),
(N'SP023', N'Màn hình ASUS ProArt 27"',     N'L03', N'TH01', N'NCC01', 11000000, 13500000, 6,  N'Màn hình đồ họa 27 inch 4K, Adobe RGB 100%',                       N'sp023.png', 36),

-- Phụ kiện (L04)
(N'SP024', N'Chuột Logitech MX Master 3S',  N'L04', N'TH03', N'NCC03', 1800000,  2400000,  40, N'Chuột không dây cao cấp, đa thiết bị',                             N'sp024.png', 12),
(N'SP025', N'Bàn phím Logitech G Pro X',    N'L04', N'TH03', N'NCC03', 1500000,  1990000,  35, N'Bàn phím cơ gaming, switch GX Brown',                              N'sp025.png', 12),
(N'SP026', N'Tai nghe Logitech G733',       N'L04', N'TH03', N'NCC03', 2100000,  2800000,  18, N'Tai nghe gaming không dây, LIGHTSPEED',                            N'sp026.png', 12),
(N'SP027', N'Chuột Razer DeathAdder V3',    N'L04', N'TH12', N'NCC12', 1600000,  2150000,  22, N'Chuột gaming optical 30K DPI',                                     N'sp027.png', 24),
(N'SP028', N'Bàn phím Razer Huntsman Mini', N'L04', N'TH12', N'NCC12', 2400000,  3100000,  16, N'Bàn phím cơ optical switch 60%',                                   N'sp028.png', 24),
(N'SP029', N'Tai nghe HyperX Cloud III',    N'L04', N'TH11', N'NCC11', 1900000,  2500000,  20, N'Tai nghe gaming có dây, driver 53mm',                              N'sp029.png', 24),
(N'SP030', N'Webcam Logitech C920',         N'L04', N'TH03', N'NCC03', 1700000,  2200000,  28, N'Webcam FullHD 1080p, autofocus',                                   N'sp030.png', 24),
(N'SP031', N'Loa Logitech Z313',            N'L04', N'TH03', N'NCC03', 850000,   1150000,  30, N'Loa 2.1 25W RMS, jack 3.5mm',                                      N'sp031.png', 12),
(N'SP032', N'Mousepad Razer Goliathus',     N'L04', N'TH12', N'NCC12', 350000,   490000,   50, N'Lót chuột vải gaming size XL',                                     N'sp032.png', 6),
(N'SP033', N'Ghế gaming DXRacer',           N'L04', N'TH12', N'NCC12', 5500000,  6800000,  8,  N'Ghế công thái học, da PU, có gối tựa',                             N'sp033.png', 24),

-- Linh kiện (L05)
(N'SP034', N'CPU Intel i7-13700K',          N'L05', N'TH07', N'NCC09', 9500000,  11500000, 8,  N'CPU Intel Gen 13, 16 nhân 24 luồng',                               N'sp034.png', 36),
(N'SP035', N'CPU Intel i5-13400F',          N'L05', N'TH07', N'NCC09', 4800000,  5900000,  15, N'CPU Intel Gen 13, 10 nhân 16 luồng',                               N'sp035.png', 36),
(N'SP036', N'CPU AMD Ryzen 7 5800X',        N'L05', N'TH10', N'NCC10', 6500000,  7900000,  10, N'CPU AMD Zen 3, 8 nhân 16 luồng',                                   N'sp036.png', 36),
(N'SP037', N'RAM Kingston Fury 16GB DDR4',  N'L05', N'TH11', N'NCC11', 1300000,  1690000,  40, N'RAM DDR4 3200MHz 16GB CL16',                                       N'sp037.png', 60),
(N'SP038', N'RAM Kingston Fury 32GB DDR5',  N'L05', N'TH11', N'NCC11', 3500000,  4250000,  20, N'RAM DDR5 5600MHz 32GB (2x16GB)',                                   N'sp038.png', 60),
(N'SP039', N'VGA ASUS RTX 4060 8GB',        N'L05', N'TH01', N'NCC01', 8800000,  10500000, 12, N'Card đồ họa Nvidia RTX 4060 8GB GDDR6',                            N'sp039.png', 36),
(N'SP040', N'VGA MSI RTX 4070 12GB',        N'L05', N'TH08', N'NCC06', 15500000, 18500000, 6,  N'Card đồ họa Nvidia RTX 4070 12GB GDDR6X',                          N'sp040.png', 36),
(N'SP041', N'Mainboard ASUS B760 Plus',     N'L05', N'TH01', N'NCC01', 3800000,  4750000,  14, N'Mainboard ATX Intel B760, DDR5, WiFi 6',                           N'sp041.png', 36),
(N'SP042', N'Nguồn Corsair 750W 80+ Gold',  N'L05', N'TH08', N'NCC06', 2600000,  3300000,  18, N'PSU 750W Gold, full modular',                                      N'sp042.png', 60),

-- Thiết bị mạng (L06)
(N'SP043', N'Router TP-Link Archer AX73',   N'L06', N'TH09', N'NCC07', 2400000,  3100000,  16, N'Router WiFi 6 AX5400, 6 ăng-ten',                                  N'sp043.png', 24),
(N'SP044', N'Switch TP-Link 8 Port Gigabit',N'L06', N'TH09', N'NCC07', 550000,   720000,   24, N'Switch 8 cổng Gigabit unmanaged',                                  N'sp044.png', 24),
(N'SP045', N'USB WiFi Asus AX1800',         N'L06', N'TH01', N'NCC01', 950000,   1290000,  20, N'USB WiFi 6 Dual-band, tốc độ AX1800',                              N'sp045.png', 24),

-- Thiết bị lưu trữ (L07)
(N'SP046', N'SSD Samsung 980 Pro 1TB',      N'L07', N'TH06', N'NCC08', 2400000,  2990000,  25, N'SSD NVMe Gen4, 1TB, đọc 7000MB/s',                                 N'sp046.png', 60),
(N'SP047', N'SSD Kingston NV2 500GB',       N'L07', N'TH11', N'NCC11', 850000,   1150000,  30, N'SSD NVMe Gen4 500GB, đọc 3500MB/s',                                N'sp047.png', 36),
(N'SP048', N'HDD Seagate 2TB',              N'L07', N'TH06', N'NCC08', 1300000,  1700000,  22, N'Ổ cứng 2TB SATA 7200rpm',                                          N'sp048.png', 24),

-- Máy in (L08)
(N'SP049', N'Máy in Canon LBP2900',         N'L08', N'TH15', N'NCC04', 3000000,  3850000,  12, N'Máy in laser đen trắng, in 12 trang/phút',                         N'sp049.png', 12),
(N'SP050', N'Máy in HP LaserJet M111w',     N'L08', N'TH04', N'NCC04', 3700000,  4690000,  10, N'Máy in laser đen trắng có wifi',                                   N'sp050.png', 12);
GO

/* ──────────────────────────────────────────────────────────────
   100 ĐƠN ĐẶT HÀNG (sinh tự động) — rải đều 90 ngày gần nhất
   Mỗi đơn có 1–3 sản phẩm chi tiết.
   Trạng thái phân bố: Chờ xử lý 20%, Đang giao 25%, Hoàn thành 45%, Hủy 10%.
   ────────────────────────────────────────────────────────────── */
DECLARE @ddhIdx INT = 1;
WHILE @ddhIdx <= 100
BEGIN
    DECLARE @maDDH     NVARCHAR(20)  = N'DDH' + RIGHT('000' + CAST(@ddhIdx AS NVARCHAR), 3);
    DECLARE @ngayDat   DATETIME      = DATEADD(DAY, -((@ddhIdx * 71) % 90), GETDATE());
    DECLARE @maKHddh   NVARCHAR(20)  = N'KH' + RIGHT('000' + CAST(((@ddhIdx * 13) % 30) + 1 AS NVARCHAR), 3);
    DECLARE @ttDDH     NVARCHAR(30)  = CASE
        WHEN @ddhIdx % 20 = 0 THEN N'Hủy'
        WHEN @ddhIdx % 10 <= 1 THEN N'Chờ xử lý'
        WHEN @ddhIdx % 10 <= 3 THEN N'Đang giao'
        ELSE N'Hoàn thành' END;
    DECLARE @giamDDH   DECIMAL(18,2) = CASE WHEN @ddhIdx % 7 = 0 THEN 500000
                                            WHEN @ddhIdx % 5 = 0 THEN 200000
                                            ELSE 0 END;

    -- Số lượng dòng chi tiết: 1–3
    DECLARE @soDong INT = (@ddhIdx % 3) + 1;
    DECLARE @tongDDH DECIMAL(18,2) = 0;

    -- Tạo 1–3 dòng chi tiết, chọn SP từ SP001 → SP050 theo công thức xoay
    DECLARE @j INT = 0;
    DECLARE @addedSP TABLE (MaSP NVARCHAR(20));

    INSERT INTO DonDatHang(MaDonDatHang, NgayDat, MaKhachHang, MaNhanVien, TienGiam, TongTien, TrangThai)
    VALUES (@maDDH, @ngayDat, @maKHddh, N'NV003', @giamDDH, 0, @ttDDH);

    WHILE @j < @soDong
    BEGIN
        DECLARE @spIdx INT = ((@ddhIdx * 17 + @j * 11) % 50) + 1;
        DECLARE @maSPddh NVARCHAR(20) = N'SP' + RIGHT('000' + CAST(@spIdx AS NVARCHAR), 3);

        -- tránh trùng SP trong cùng 1 đơn (PK = MaDDH+MaSP)
        IF NOT EXISTS (SELECT 1 FROM @addedSP WHERE MaSP = @maSPddh)
        BEGIN
            DECLARE @gia DECIMAL(18,2);
            SELECT @gia = GiaBan FROM SanPham WHERE MaSanPham = @maSPddh;
            DECLARE @sl INT = (@j % 2) + 1;

            INSERT INTO ChiTietDonDatHang(MaDonDatHang, MaSanPham, SoLuong, DonGia)
            VALUES (@maDDH, @maSPddh, @sl, @gia);

            INSERT INTO @addedSP VALUES (@maSPddh);
            SET @tongDDH = @tongDDH + (@gia * @sl);
        END
        SET @j = @j + 1;
    END

    -- Cập nhật tổng tiền sau khi đã insert chi tiết
    UPDATE DonDatHang SET TongTien = @tongDDH - @giamDDH WHERE MaDonDatHang = @maDDH;

    DELETE FROM @addedSP;
    SET @ddhIdx = @ddhIdx + 1;
END
GO

/* ──────────────────────────────────────────────────────────────
   60 HÓA ĐƠN BÁN — rải đều 90 ngày, mỗi HĐ có 1–3 sản phẩm.
   TẠM tắt trigger để không trừ kho (do SoLuongTon đã seed sẵn).
   ────────────────────────────────────────────────────────────── */
DISABLE TRIGGER trg_BanHang_GiamTon ON ChiTietHoaDonBan;
GO

DECLARE @i INT = 0;
WHILE @i < 60
BEGIN
    DECLARE @maHD     NVARCHAR(20)  = N'HD' + RIGHT('00000' + CAST(100 + @i AS NVARCHAR), 5);
    DECLARE @ngay     DATETIME      = DATEADD(DAY, -((@i * 37) % 90), GETDATE());
    DECLARE @maKHhd   NVARCHAR(20)  = N'KH' + RIGHT('000' + CAST(((@i * 7) % 30) + 1 AS NVARCHAR), 3);
    DECLARE @ptt      NVARCHAR(50)  = CASE WHEN @i % 3 = 0 THEN N'Tiền mặt'
                                            WHEN @i % 3 = 1 THEN N'Chuyển khoản'
                                            ELSE N'Thẻ tín dụng' END;
    DECLARE @giamHD   DECIMAL(18,2) = CASE WHEN @i % 11 = 0 THEN 1000000
                                            WHEN @i % 6 = 0 THEN 300000
                                            ELSE 0 END;

    -- Số sản phẩm trong hóa đơn: 1–3
    DECLARE @soSpHD INT = (@i % 3) + 1;
    DECLARE @tongHD DECIMAL(18,2) = 0;
    DECLARE @kSp INT = 0;
    DECLARE @spDaThem TABLE (MaSP NVARCHAR(20));

    INSERT INTO HoaDonBan(MaHoaDonBan, NgayBan, MaKhachHang, MaNhanVien, TienGiam, TongTien, HinhThucThanhToan, TrangThai)
    VALUES (@maHD, @ngay, @maKHhd, N'NV003', @giamHD, 0, @ptt, N'Hoàn thành');

    WHILE @kSp < @soSpHD
    BEGIN
        DECLARE @spIdxHD INT = ((@i * 23 + @kSp * 19) % 50) + 1;
        DECLARE @maSPhd NVARCHAR(20) = N'SP' + RIGHT('000' + CAST(@spIdxHD AS NVARCHAR), 3);

        IF NOT EXISTS (SELECT 1 FROM @spDaThem WHERE MaSP = @maSPhd)
        BEGIN
            DECLARE @giaHD DECIMAL(18,2);
            SELECT @giaHD = GiaBan FROM SanPham WHERE MaSanPham = @maSPhd;
            DECLARE @slHD INT = (@kSp % 2) + 1;

            INSERT INTO ChiTietHoaDonBan(MaHoaDonBan, MaSanPham, SoLuong, DonGia)
            VALUES (@maHD, @maSPhd, @slHD, @giaHD);

            INSERT INTO @spDaThem VALUES (@maSPhd);
            SET @tongHD = @tongHD + (@giaHD * @slHD);
        END
        SET @kSp = @kSp + 1;
    END

    UPDATE HoaDonBan SET TongTien = @tongHD - @giamHD WHERE MaHoaDonBan = @maHD;

    DELETE FROM @spDaThem;
    SET @i = @i + 1;
END
GO

ENABLE TRIGGER trg_BanHang_GiamTon ON ChiTietHoaDonBan;
GO

/* ──────────────────────────────────────────────────────────────
   Seed PHIẾU NHẬP KHO (tắt trigger nhập kho để giữ nguyên SoLuongTon đã seed)
   ────────────────────────────────────────────────────────────── */
DISABLE TRIGGER trg_NhapKho_TangTon ON ChiTietPhieuNhap;
GO

INSERT INTO PhieuNhapKho (MaPhieuNhap, NgayNhap, MaNCC, MaNhanVien, TongTien) VALUES
(N'PNK001', DATEADD(DAY,-85, GETDATE()), N'NCC01', N'NV002', 370000000),
(N'PNK002', DATEADD(DAY,-78, GETDATE()), N'NCC02', N'NV002', 224000000),
(N'PNK003', DATEADD(DAY,-70, GETDATE()), N'NCC03', N'NV002', 72000000),
(N'PNK004', DATEADD(DAY,-60, GETDATE()), N'NCC04', N'NV002', 96000000),
(N'PNK005', DATEADD(DAY,-52, GETDATE()), N'NCC05', N'NV002', 175000000),
(N'PNK006', DATEADD(DAY,-45, GETDATE()), N'NCC06', N'NV002', 144000000),
(N'PNK007', DATEADD(DAY,-38, GETDATE()), N'NCC07', N'NV002', 88500000),
(N'PNK008', DATEADD(DAY,-30, GETDATE()), N'NCC08', N'NV002', 117000000),
(N'PNK009', DATEADD(DAY,-25, GETDATE()), N'NCC09', N'NV002', 95000000),
(N'PNK010', DATEADD(DAY,-20, GETDATE()), N'NCC10', N'NV002', 65000000),
(N'PNK011', DATEADD(DAY,-15, GETDATE()), N'NCC11', N'NV002', 78000000),
(N'PNK012', DATEADD(DAY,-12, GETDATE()), N'NCC12', N'NV002', 99500000),
(N'PNK013', DATEADD(DAY,-8,  GETDATE()), N'NCC01', N'NV002', 184500000),
(N'PNK014', DATEADD(DAY,-5,  GETDATE()), N'NCC03', N'NV002', 53700000),
(N'PNK015', DATEADD(DAY,-2,  GETDATE()), N'NCC06', N'NV002', 207000000);
GO

INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, SoLuong, DonGiaNhap) VALUES
(N'PNK001', N'SP001', 20, 18500000),
(N'PNK002', N'SP002', 8,  28000000),
(N'PNK003', N'SP024', 40, 1800000),
(N'PNK004', N'SP003', 6,  16000000),
(N'PNK005', N'SP004', 10, 17500000),
(N'PNK006', N'SP015', 4,  35000000),
(N'PNK006', N'SP022', 6,  9500000),
(N'PNK007', N'SP018', 12, 5500000),
(N'PNK007', N'SP019', 7,  3200000),
(N'PNK008', N'SP020', 8,  7800000),
(N'PNK008', N'SP021', 14, 4200000),
(N'PNK009', N'SP034', 10, 9500000),
(N'PNK010', N'SP036', 10, 6500000),
(N'PNK011', N'SP037', 60, 1300000),
(N'PNK012', N'SP027', 30, 1600000),
(N'PNK012', N'SP028', 22, 2400000),
(N'PNK013', N'SP005', 5,  25000000),
(N'PNK013', N'SP013', 3,  22000000),
(N'PNK014', N'SP046', 15, 2400000),
(N'PNK014', N'SP047', 20, 850000),
(N'PNK015', N'SP040', 6,  15500000),
(N'PNK015', N'SP039', 14, 8800000);
GO

ENABLE TRIGGER trg_NhapKho_TangTon ON ChiTietPhieuNhap;
GO

/* ──────────────────────────────────────────────────────────────
   Seed PHIẾU TRẢ HÀNG (tắt trigger trả hàng để không cộng lại tồn kho)
   ────────────────────────────────────────────────────────────── */
DISABLE TRIGGER trg_TraHang_TangTon ON ChiTietPhieuTraHang;
GO

INSERT INTO PhieuTraHang (MaPhieuTra, NgayTra, MaHoaDonBan, MaNhanVien, TongTien, LyDo) VALUES
(N'PTH001', DATEADD(DAY,-55, GETDATE()), N'HD00105', N'NV003', 2400000,  N'Sản phẩm bị lỗi nhẹ, khách đổi sang model khác'),
(N'PTH002', DATEADD(DAY,-48, GETDATE()), N'HD00108', N'NV003', 1990000,  N'Khách đổi ý, hàng còn nguyên vẹn'),
(N'PTH003', DATEADD(DAY,-40, GETDATE()), N'HD00112', N'NV003', 4100000,  N'Sản phẩm không đúng mô tả, khách yêu cầu trả'),
(N'PTH004', DATEADD(DAY,-32, GETDATE()), N'HD00118', N'NV003', 2800000,  N'Lỗi sản phẩm trong thời gian bảo hành'),
(N'PTH005', DATEADD(DAY,-25, GETDATE()), N'HD00125', N'NV003', 6900000,  N'Khách trả hàng do không hợp với nhu cầu sử dụng'),
(N'PTH006', DATEADD(DAY,-18, GETDATE()), N'HD00131', N'NV003', 1690000,  N'RAM bị lỗi không tương thích mainboard'),
(N'PTH007', DATEADD(DAY,-10, GETDATE()), N'HD00140', N'NV003', 1150000,  N'SSD chậm hơn quảng cáo, đổi sản phẩm khác'),
(N'PTH008', DATEADD(DAY,-3,  GETDATE()), N'HD00148', N'NV003', 720000,   N'Switch mạng không kết nối được, lỗi nhà sản xuất');
GO

INSERT INTO ChiTietPhieuTraHang (MaPhieuTra, MaSanPham, SoLuongTra, DonGia, TinhTrangSP) VALUES
(N'PTH001', N'SP024', 1, 2400000, N'Lỗi nhẹ'),
(N'PTH002', N'SP025', 1, 1990000, N'Nguyên vẹn'),
(N'PTH003', N'SP019', 1, 4100000, N'Nguyên vẹn'),
(N'PTH004', N'SP026', 1, 2800000, N'Lỗi nhẹ'),
(N'PTH005', N'SP018', 1, 6900000, N'Nguyên vẹn'),
(N'PTH006', N'SP037', 1, 1690000, N'Lỗi'),
(N'PTH007', N'SP047', 1, 1150000, N'Lỗi nhẹ'),
(N'PTH008', N'SP044', 1, 720000,  N'Lỗi');
GO

ENABLE TRIGGER trg_TraHang_TangTon ON ChiTietPhieuTraHang;
GO

/* ──────────────────────────────────────────────────────────────
   Cập nhật lại trạng thái HĐ đã trả
   ────────────────────────────────────────────────────────────── */
UPDATE HoaDonBan SET TrangThai = N'Đã trả hàng'
WHERE MaHoaDonBan IN (N'HD00105', N'HD00108', N'HD00112', N'HD00118',
                      N'HD00125', N'HD00131', N'HD00140', N'HD00148');
GO

PRINT N'━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━';
PRINT N'  HOÀN THÀNH TẠO DATABASE QuanLyCuaHangMayTinhDB';
PRINT N'━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━';
PRINT N'  Bảng:    15 bảng + 3 trigger';
PRINT N'  Dữ liệu seed:';
PRINT N'    - 4 vai trò';
PRINT N'    - 4 nhân viên (admin/admin123, kho/kho123, banhang/banhang123, ketoan/ketoan123)';
PRINT N'    - 30 khách hàng (KH001-KH030)';
PRINT N'    - 12 nhà cung cấp (NCC01-NCC12)';
PRINT N'    - 8 loại sản phẩm + 15 thương hiệu';
PRINT N'    - 50 sản phẩm (SP001-SP050)';
PRINT N'    - 100 đơn đặt hàng (DDH001-DDH100) — rải đều 90 ngày, đủ 4 trạng thái';
PRINT N'    - 60 hóa đơn bán (HD00100-HD00159) — rải đều 90 ngày, mỗi HĐ 1-3 SP';
PRINT N'    - 15 phiếu nhập kho (PNK001-PNK015)';
PRINT N'    - 8 phiếu trả hàng (PTH001-PTH008)';
PRINT N'━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━';
GO
