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

-- Mật khẩu (BCrypt cost=11):
--   admin   / admin123
--   kho     / kho123
--   banhang / banhang123
--   ketoan  / ketoan123
INSERT INTO NhanVien (MaNhanVien, TenDangNhap, MatKhau, HoTen, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, MaVaiTro) VALUES
(N'NV001', N'admin',   N'$2b$11$m8RAvexgnOxJ1lCxxR/.ye4UwmIHmoOBis9muQIEEdcz8MUK2g6JO', N'Nguyễn Văn Admin',  N'Nam', '1990-01-01', N'0912345678', N'admin@shop.com',   N'Hà Nội',         N'VT01'),
(N'NV002', N'kho',     N'$2b$11$oqbEQI4w6tj8GStEUwYCieI20zvbsDb7O3NQxkyqI9R4RYF8ktfKy', N'Trần Thị Kho',      N'Nữ',  '1992-05-12', N'0912345679', N'kho@shop.com',     N'Hà Nội',         N'VT02'),
(N'NV003', N'banhang', N'$2b$11$16x5WvcnaDSinaxbwIYTtOu2bDDlhhcl2CHV4HIS9PqNzqCvWRo.y', N'Lê Văn Bán Hàng',   N'Nam', '1995-08-20', N'0912345680', N'banhang@shop.com', N'Hà Nội',         N'VT03'),
(N'NV004', N'ketoan',  N'$2b$11$xLeEOqN.welskrSUaku4cuD/VadSEIL1Mkg2yujraqsYJvl8IhwH2', N'Phạm Thị Kế Toán',  N'Nữ',  '1993-11-03', N'0912345681', N'ketoan@shop.com',  N'Hà Nội',         N'VT04');
GO

INSERT INTO KhachHang (MaKhachHang, TenKhachHang, SoDienThoai, Email, DiaChi, DiemTichLuy) VALUES
(N'KH001', N'Nguyễn Văn A', N'0901111111', N'a@gmail.com', N'Hà Nội',     150),
(N'KH002', N'Trần Thị B',   N'0902222222', N'b@gmail.com', N'Hải Phòng',  80),
(N'KH003', N'Lê Văn C',     N'0903333333', N'c@gmail.com', N'Đà Nẵng',    220),
(N'KH004', N'Phạm Thị D',   N'0904444444', N'd@gmail.com', N'TP HCM',     50),
(N'KH005', N'Hoàng Văn E',  N'0905555555', N'e@gmail.com', N'Cần Thơ',    300);
GO

INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai) VALUES
(N'NCC01', N'Công ty TNHH ASUS Việt Nam',  N'Số 1 Nguyễn Văn Linh, Hà Nội',     N'02438123456'),
(N'NCC02', N'Công ty TNHH Dell Việt Nam',  N'Số 2 Trần Hưng Đạo, Hà Nội',        N'02438123457'),
(N'NCC03', N'Công ty TNHH Logitech VN',    N'Số 3 Hai Bà Trưng, Hà Nội',         N'02438123458'),
(N'NCC04', N'Công ty TNHH HP Việt Nam',    N'Số 4 Lê Lợi, TP HCM',               N'02838123459'),
(N'NCC05', N'Công ty TNHH Lenovo VN',      N'Số 5 Nguyễn Trãi, TP HCM',          N'02838123460');
GO

INSERT INTO LoaiSanPham (MaLoai, TenLoai) VALUES
(N'L01', N'Laptop'),
(N'L02', N'PC Desktop'),
(N'L03', N'Màn hình'),
(N'L04', N'Phụ kiện'),
(N'L05', N'Linh kiện');
GO

INSERT INTO ThuongHieu (MaThuongHieu, TenThuongHieu) VALUES
(N'TH01', N'ASUS'),
(N'TH02', N'Dell'),
(N'TH03', N'Logitech'),
(N'TH04', N'HP'),
(N'TH05', N'Lenovo'),
(N'TH06', N'Samsung'),
(N'TH07', N'Intel');
GO

INSERT INTO SanPham (MaSanPham, TenSanPham, MaLoai, MaThuongHieu, MaNCC, GiaNhap, GiaBan, SoLuongTon, MoTa, HinhAnh, BaoHanhThang) VALUES
(N'SP001', N'ASUS TUF Gaming F15',    N'L01', N'TH01', N'NCC01', 18500000, 21000000, 15, N'Laptop gaming i5-12500H, RTX 3050, 16GB RAM, 512GB SSD',         N'sp001.png', 24),
(N'SP002', N'Dell XPS 13 Plus',        N'L01', N'TH02', N'NCC02', 28000000, 32500000, 8,  N'Ultrabook cao cấp i7-1360P, 16GB RAM, 1TB SSD, màn OLED',         N'sp002.png', 24),
(N'SP003', N'HP Pavilion 15',          N'L01', N'TH04', N'NCC04', 16000000, 18500000, 12, N'Laptop văn phòng i5-1235U, 8GB RAM, 512GB SSD',                   N'sp003.png', 12),
(N'SP004', N'Lenovo ThinkPad E14',     N'L01', N'TH05', N'NCC05', 17500000, 20500000, 10, N'Laptop doanh nhân i5-1235U, 16GB RAM, 512GB SSD',                 N'sp004.png', 24),
(N'SP005', N'ASUS ROG Strix G15',      N'L01', N'TH01', N'NCC01', 25000000, 29900000, 6,  N'Laptop gaming RTX 4060, 32GB RAM',                                N'sp005.png', 24),
(N'SP006', N'PC Gaming RTX 4060',      N'L02', N'TH07', N'NCC01', 22000000, 26000000, 5,  N'PC gaming i7-13700F, 32GB RAM, RTX 4060 8GB',                     N'sp006.png', 24),
(N'SP007', N'Màn hình ASUS 27 inch',   N'L03', N'TH01', N'NCC01', 5500000,  6900000,  20, N'Màn hình 27 inch 2K 165Hz IPS',                                   N'sp007.png', 24),
(N'SP008', N'Màn hình Samsung 24 inch',N'L03', N'TH06', N'NCC02', 3200000,  4100000,  25, N'Màn hình 24 inch FullHD 75Hz',                                    N'sp008.png', 24),
(N'SP009', N'Chuột Logitech MX Master',N'L04', N'TH03', N'NCC03', 1800000,  2400000,  40, N'Chuột không dây cao cấp, đa thiết bị',                            N'sp009.png', 12),
(N'SP010', N'Bàn phím Logitech G Pro', N'L04', N'TH03', N'NCC03', 1500000,  1990000,  35, N'Bàn phím cơ gaming, switch GX Brown',                             N'sp010.png', 12),
(N'SP011', N'Tai nghe Logitech G733',  N'L04', N'TH03', N'NCC03', 2100000,  2800000,  18, N'Tai nghe gaming không dây, LIGHTSPEED',                           N'sp011.png', 12),
(N'SP012', N'CPU Intel i7-13700K',     N'L05', N'TH07', N'NCC01', 9500000,  11500000, 8,  N'CPU Intel Gen 13, 16 nhân 24 luồng',                              N'sp012.png', 36);
GO

INSERT INTO DonDatHang (MaDonDatHang, NgayDat, MaKhachHang, MaNhanVien, TienGiam, TongTien, TrangThai) VALUES
(N'DDH001', DATEADD(DAY,-5, GETDATE()), N'KH001', N'NV003', 0,      21000000, N'Hoàn thành'),
(N'DDH002', DATEADD(DAY,-3, GETDATE()), N'KH002', N'NV003', 500000, 18000000, N'Đang giao'),
(N'DDH003', DATEADD(DAY,-1, GETDATE()), N'KH003', N'NV003', 0,      4100000,  N'Chờ xử lý');
GO

INSERT INTO ChiTietDonDatHang (MaDonDatHang, MaSanPham, SoLuong, DonGia) VALUES
(N'DDH001', N'SP001', 1, 21000000),
(N'DDH002', N'SP003', 1, 18500000),
(N'DDH003', N'SP008', 1, 4100000);
GO

/* ──────────────────────────────────────────────────────────────
   Seed 30 ngày dữ liệu hóa đơn bán (TẠM tắt trigger để không trừ kho)
   ────────────────────────────────────────────────────────────── */
DISABLE TRIGGER trg_BanHang_GiamTon ON ChiTietHoaDonBan;
GO

DECLARE @i INT = 0;
WHILE @i < 30
BEGIN
    DECLARE @maHD NVARCHAR(20)   = N'HD' + RIGHT('00000' + CAST(100 + @i AS NVARCHAR), 5);
    DECLARE @ngay DATETIME       = DATEADD(DAY, -@i, GETDATE());
    DECLARE @maKH NVARCHAR(20)   = CASE WHEN @i % 5 = 0 THEN N'KH001'
                                        WHEN @i % 5 = 1 THEN N'KH002'
                                        WHEN @i % 5 = 2 THEN N'KH003'
                                        WHEN @i % 5 = 3 THEN N'KH004'
                                        ELSE N'KH005' END;
    DECLARE @maSP NVARCHAR(20)   = CASE WHEN @i % 6 = 0 THEN N'SP001'
                                        WHEN @i % 6 = 1 THEN N'SP008'
                                        WHEN @i % 6 = 2 THEN N'SP009'
                                        WHEN @i % 6 = 3 THEN N'SP010'
                                        WHEN @i % 6 = 4 THEN N'SP007'
                                        ELSE N'SP011' END;
    DECLARE @gia DECIMAL(18,2)   = CASE @maSP
                                        WHEN N'SP001' THEN 21000000
                                        WHEN N'SP008' THEN 4100000
                                        WHEN N'SP009' THEN 2400000
                                        WHEN N'SP010' THEN 1990000
                                        WHEN N'SP007' THEN 6900000
                                        ELSE 2800000 END;
    DECLARE @sl INT              = 1 + (@i % 3);
    DECLARE @tong DECIMAL(18,2)  = @gia * @sl;
    DECLARE @ptt NVARCHAR(50)    = CASE WHEN @i % 2 = 0 THEN N'Tiền mặt' ELSE N'Chuyển khoản' END;

    INSERT INTO HoaDonBan(MaHoaDonBan, NgayBan, MaKhachHang, MaNhanVien, TienGiam, TongTien, HinhThucThanhToan, TrangThai)
    VALUES (@maHD, @ngay, @maKH, N'NV003', 0, @tong, @ptt, N'Hoàn thành');

    INSERT INTO ChiTietHoaDonBan(MaHoaDonBan, MaSanPham, SoLuong, DonGia)
    VALUES (@maHD, @maSP, @sl, @gia);

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
(N'PNK001', DATEADD(DAY,-20, GETDATE()), N'NCC01', N'NV002', 370000000),
(N'PNK002', DATEADD(DAY,-15, GETDATE()), N'NCC02', N'NV002', 224000000),
(N'PNK003', DATEADD(DAY,-10, GETDATE()), N'NCC03', N'NV002', 72000000),
(N'PNK004', DATEADD(DAY,-5,  GETDATE()), N'NCC04', N'NV002', 96000000),
(N'PNK005', DATEADD(DAY,-2,  GETDATE()), N'NCC05', N'NV002', 175000000);
GO

INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, SoLuong, DonGiaNhap) VALUES
(N'PNK001', N'SP001', 20, 18500000),
(N'PNK002', N'SP002', 8,  28000000),
(N'PNK003', N'SP009', 40, 1800000),
(N'PNK004', N'SP003', 6,  16000000),
(N'PNK005', N'SP004', 10, 17500000);
GO

ENABLE TRIGGER trg_NhapKho_TangTon ON ChiTietPhieuNhap;
GO

/* ──────────────────────────────────────────────────────────────
   Seed PHIẾU TRẢ HÀNG (tắt trigger trả hàng để không cộng lại tồn kho)
   ────────────────────────────────────────────────────────────── */
DISABLE TRIGGER trg_TraHang_TangTon ON ChiTietPhieuTraHang;
GO

INSERT INTO PhieuTraHang (MaPhieuTra, NgayTra, MaHoaDonBan, MaNhanVien, TongTien, LyDo) VALUES
(N'PTH001', DATEADD(DAY,-8, GETDATE()),  N'HD00105', N'NV003', 2400000,  N'Sản phẩm bị lỗi nhẹ, khách đổi sang model khác'),
(N'PTH002', DATEADD(DAY,-3, GETDATE()),  N'HD00108', N'NV003', 1990000,  N'Khách đổi ý, hàng còn nguyên vẹn');
GO

INSERT INTO ChiTietPhieuTraHang (MaPhieuTra, MaSanPham, SoLuongTra, DonGia, TinhTrangSP) VALUES
(N'PTH001', N'SP009', 1, 2400000, N'Lỗi nhẹ'),
(N'PTH002', N'SP010', 1, 1990000, N'Nguyên vẹn');
GO

ENABLE TRIGGER trg_TraHang_TangTon ON ChiTietPhieuTraHang;
GO

/* ──────────────────────────────────────────────────────────────
   Cập nhật lại trạng thái HĐ đã trả
   ────────────────────────────────────────────────────────────── */
UPDATE HoaDonBan SET TrangThai = N'Đã trả hàng' WHERE MaHoaDonBan IN (N'HD00105', N'HD00108');
GO

PRINT N'━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━';
PRINT N'  HOÀN THÀNH TẠO DATABASE QuanLyCuaHangMayTinhDB';
PRINT N'━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━';
PRINT N'  Bảng:    15 bảng + 3 trigger';
PRINT N'  Dữ liệu seed:';
PRINT N'    - 4 vai trò';
PRINT N'    - 4 nhân viên (admin/admin123, kho/kho123, banhang/banhang123, ketoan/ketoan123)';
PRINT N'    - 5 khách hàng (KH001-KH005)';
PRINT N'    - 5 nhà cung cấp (NCC01-NCC05)';
PRINT N'    - 5 loại sản phẩm + 7 thương hiệu';
PRINT N'    - 12 sản phẩm (SP001-SP012)';
PRINT N'    - 3 đơn đặt hàng (DDH001-DDH003)';
PRINT N'    - 30 hóa đơn bán (HD00100-HD00129) — rải đều 30 ngày gần nhất';
PRINT N'    - 5 phiếu nhập kho (PNK001-PNK005)';
PRINT N'    - 2 phiếu trả hàng (PTH001-PTH002)';
PRINT N'━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━';
GO
