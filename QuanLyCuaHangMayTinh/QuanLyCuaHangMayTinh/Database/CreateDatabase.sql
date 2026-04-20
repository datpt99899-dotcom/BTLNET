-- Database migration for DE SO 1 - Quan ly cua hang may tinh
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

CREATE TABLE VaiTro (
    MaVaiTro NVARCHAR(10) NOT NULL PRIMARY KEY,
    TenVaiTro NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE NhanVien (
    MaNhanVien NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    HoTen NVARCHAR(150) NOT NULL,
    GioiTinh NVARCHAR(10) NULL,
    NgaySinh DATE NULL,
    SoDienThoai NVARCHAR(20) NULL,
    Email NVARCHAR(150) NULL,
    DiaChi NVARCHAR(255) NULL,
    MaVaiTro NVARCHAR(10) NOT NULL,
    TrangThai BIT NOT NULL DEFAULT 1,
    NgayTao DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_NhanVien_VaiTro FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);
GO

CREATE TABLE KhachHang (
    MaKhachHang NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenKhachHang NVARCHAR(150) NOT NULL,
    SoDienThoai NVARCHAR(20) NULL,
    Email NVARCHAR(150) NULL,
    DiaChi NVARCHAR(255) NULL,
    DiemTichLuy INT NOT NULL DEFAULT 0
);
GO

CREATE TABLE NhaCungCap (
    MaNhaCungCap NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenNhaCungCap NVARCHAR(150) NOT NULL,
    DiaChi NVARCHAR(255) NULL,
    SoDienThoai NVARCHAR(20) NULL
);
GO

CREATE TABLE LoaiSanPham (
    MaLoai NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenLoai NVARCHAR(150) NOT NULL UNIQUE
);
GO

CREATE TABLE ThuongHieu (
    MaThuongHieu NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenThuongHieu NVARCHAR(150) NOT NULL UNIQUE
);
GO

CREATE TABLE SanPham (
    MaSanPham NVARCHAR(20) NOT NULL PRIMARY KEY,
    TenSanPham NVARCHAR(200) NOT NULL,
    MaLoai NVARCHAR(20) NOT NULL,
    MaThuongHieu NVARCHAR(20) NOT NULL,
    MaNhaCungCap NVARCHAR(20) NOT NULL,
    GiaNhap DECIMAL(18,2) NOT NULL DEFAULT 0,
    GiaBan DECIMAL(18,2) NOT NULL DEFAULT 0,
    SoLuongTon INT NOT NULL DEFAULT 0,
    MoTa NVARCHAR(500) NULL,
    HinhAnh NVARCHAR(500) NULL,
    BaoHanhThang INT NOT NULL DEFAULT 12,
    CONSTRAINT FK_SanPham_Loai FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai),
    CONSTRAINT FK_SanPham_ThuongHieu FOREIGN KEY (MaThuongHieu) REFERENCES ThuongHieu(MaThuongHieu),
    CONSTRAINT FK_SanPham_NCC FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);
GO

CREATE TABLE DonDatHang (
    MaDonDatHang NVARCHAR(20) NOT NULL PRIMARY KEY,
    NgayDat DATETIME NOT NULL DEFAULT GETDATE(),
    MaKhachHang NVARCHAR(20) NOT NULL,
    MaNhanVien NVARCHAR(20) NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Chờ xử lý',
    CONSTRAINT FK_DonDatHang_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    CONSTRAINT FK_DonDatHang_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

CREATE TABLE ChiTietDonDatHang (
    MaDonDatHang NVARCHAR(20) NOT NULL,
    MaSanPham NVARCHAR(20) NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietDonDatHang PRIMARY KEY (MaDonDatHang, MaSanPham),
    CONSTRAINT FK_CTDDH_DDH FOREIGN KEY (MaDonDatHang) REFERENCES DonDatHang(MaDonDatHang),
    CONSTRAINT FK_CTDDH_SP FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
GO

CREATE TABLE HoaDonBan (
    MaHoaDonBan NVARCHAR(20) NOT NULL PRIMARY KEY,
    NgayBan DATETIME NOT NULL DEFAULT GETDATE(),
    MaKhachHang NVARCHAR(20) NOT NULL,
    MaNhanVien NVARCHAR(20) NOT NULL,
    MaDonDatHang NVARCHAR(20) NULL,
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Hoàn thành',
    CONSTRAINT FK_HoaDonBan_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    CONSTRAINT FK_HoaDonBan_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    CONSTRAINT FK_HoaDonBan_DonDatHang FOREIGN KEY (MaDonDatHang) REFERENCES DonDatHang(MaDonDatHang)
);
GO

CREATE TABLE ChiTietHoaDonBan (
    MaHoaDonBan NVARCHAR(20) NOT NULL,
    MaSanPham NVARCHAR(20) NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietHoaDonBan PRIMARY KEY (MaHoaDonBan, MaSanPham),
    CONSTRAINT FK_CTHDB_HDB FOREIGN KEY (MaHoaDonBan) REFERENCES HoaDonBan(MaHoaDonBan),
    CONSTRAINT FK_CTHDB_SP FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
GO

CREATE TABLE PhieuNhapKho (
    MaPhieuNhap NVARCHAR(20) NOT NULL PRIMARY KEY,
    NgayNhap DATETIME NOT NULL DEFAULT GETDATE(),
    MaNhaCungCap NVARCHAR(20) NOT NULL,
    MaNhanVien NVARCHAR(20) NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_PhieuNhapKho_NCC FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap),
    CONSTRAINT FK_PhieuNhapKho_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhap NVARCHAR(20) NOT NULL,
    MaSanPham NVARCHAR(20) NOT NULL,
    SoLuong INT NOT NULL,
    DonGiaNhap DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietPhieuNhap PRIMARY KEY (MaPhieuNhap, MaSanPham),
    CONSTRAINT FK_CTPN_PNK FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhapKho(MaPhieuNhap),
    CONSTRAINT FK_CTPN_SP FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
GO

CREATE TABLE PhieuTraHang (
    MaPhieuTraHang NVARCHAR(20) NOT NULL PRIMARY KEY,
    NgayTra DATETIME NOT NULL DEFAULT GETDATE(),
    MaHoaDonBan NVARCHAR(20) NOT NULL,
    MaNhanVien NVARCHAR(20) NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_PhieuTraHang_HoaDonBan FOREIGN KEY (MaHoaDonBan) REFERENCES HoaDonBan(MaHoaDonBan),
    CONSTRAINT FK_PhieuTraHang_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

CREATE TABLE ChiTietPhieuTraHang (
    MaPhieuTraHang NVARCHAR(20) NOT NULL,
    MaSanPham NVARCHAR(20) NOT NULL,
    SoLuongTra INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietPhieuTraHang PRIMARY KEY (MaPhieuTraHang, MaSanPham),
    CONSTRAINT FK_CTPT_PhieuTraHang FOREIGN KEY (MaPhieuTraHang) REFERENCES PhieuTraHang(MaPhieuTraHang),
    CONSTRAINT FK_CTPT_SanPham FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
GO

INSERT INTO VaiTro VALUES
(N'VT01', N'Admin'),
(N'VT02', N'Nhân viên kho'),
(N'VT03', N'Nhân viên bán hàng'),
(N'VT04', N'Kế toán');
GO

-- Passwords: admin123 / kho123 / ban123 / kt123 (SHA256)
INSERT INTO NhanVien (MaNhanVien, TenDangNhap, MatKhau, HoTen, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, MaVaiTro)
VALUES
(N'NV001', N'admin', N'240be518fabd2724ddb6f04eebf2f2a7f141f7df4d5613d955f1f7a8e943b0c4', N'Nguyễn Quản Trị', N'Nam', '1995-01-01', N'0900000001', N'admin@store.local', N'Hà Nội', N'VT01'),
(N'NV002', N'kho', N'5efdfcbf45d8c1a64bdb2f7fe6f1b1d0e61d73e99d4e66f59f5e20f1ff2ea273', N'Trần Kho', N'Nam', '1996-05-10', N'0900000002', N'kho@store.local', N'Hà Nội', N'VT02'),
(N'NV003', N'banhang', N'6bd699c55d6d14bd0b8b8b006326d2d62aa95b036d68b65fc47e6d83f770d7f8', N'Lê Bán Hàng', N'Nữ', '1998-08-20', N'0900000003', N'banhang@store.local', N'Hà Nội', N'VT03'),
(N'NV004', N'ketoan', N'92ef1704f2f0bb0ec7eb48d6f42ec5b58e80dbf0eb5c04d88f3a92a6fd651350', N'Phạm Kế Toán', N'Nữ', '1994-03-15', N'0900000004', N'ketoan@store.local', N'Hà Nội', N'VT04');
GO

INSERT INTO KhachHang VALUES
(N'KH001', N'Nguyễn Văn An', N'0911111111', N'an@gmail.com', N'Hà Nội', 100),
(N'KH002', N'Trần Thị Bình', N'0922222222', N'binh@gmail.com', N'Đà Nẵng', 50),
(N'KH003', N'Lê Minh Cường', N'0933333333', N'cuong@gmail.com', N'Hải Phòng', 20);
GO

INSERT INTO NhaCungCap VALUES
(N'NCC01', N'Công ty ASUS Việt Nam', N'Hà Nội', N'0241111111'),
(N'NCC02', N'Công ty Dell Việt Nam', N'TP.HCM', N'0282222222'),
(N'NCC03', N'Công ty Logitech', N'TP.HCM', N'0283333333');
GO

INSERT INTO LoaiSanPham VALUES
(N'L01', N'Laptop'),
(N'L02', N'PC Gaming'),
(N'L03', N'Màn hình'),
(N'L04', N'Phụ kiện');
GO

INSERT INTO ThuongHieu VALUES
(N'TH01', N'ASUS'),
(N'TH02', N'Dell'),
(N'TH03', N'Logitech'),
(N'TH04', N'LG');
GO

INSERT INTO SanPham (MaSanPham, TenSanPham, MaLoai, MaThuongHieu, MaNhaCungCap, GiaNhap, GiaBan, SoLuongTon, MoTa, HinhAnh, BaoHanhThang) VALUES
(N'SP001', N'ASUS TUF Gaming F15', N'L01', N'TH01', N'NCC01', 18000000, 21000000, 15, N'Laptop gaming 15.6 inch, RTX 3050', NULL, 24),
(N'SP002', N'Dell Inspiron 15', N'L01', N'TH02', N'NCC02', 14500000, 16900000, 12, N'Laptop văn phòng hiệu năng ổn định', NULL, 24),
(N'SP003', N'LG UltraGear 24 inch', N'L03', N'TH04', N'NCC02', 3200000, 3900000, 20, N'Màn hình gaming 144Hz', NULL, 24),
(N'SP004', N'Logitech G102', N'L04', N'TH03', N'NCC03', 280000, 390000, 50, N'Chuột gaming phổ biến', NULL, 12);
GO

INSERT INTO DonDatHang VALUES
(N'DDH001', '2026-04-10', N'KH001', N'NV003', 21000000, N'Hoàn thành'),
(N'DDH002', '2026-04-11', N'KH002', N'NV003', 3900000, N'Chờ xử lý');
GO

INSERT INTO ChiTietDonDatHang VALUES
(N'DDH001', N'SP001', 1, 21000000),
(N'DDH002', N'SP003', 1, 3900000);
GO

INSERT INTO HoaDonBan VALUES
(N'HDB001', '2026-04-10', N'KH001', N'NV003', N'DDH001', 21000000, N'Hoàn thành'),
(N'HDB002', '2026-04-12', N'KH003', N'NV003', NULL, 780000, N'Hoàn thành');
GO

INSERT INTO ChiTietHoaDonBan VALUES
(N'HDB001', N'SP001', 1, 21000000),
(N'HDB002', N'SP004', 2, 390000);
GO

INSERT INTO PhieuNhapKho VALUES
(N'PNK001', '2026-04-05', N'NCC01', N'NV002', 54000000),
(N'PNK002', '2026-04-06', N'NCC03', N'NV002', 14000000);
GO

INSERT INTO ChiTietPhieuNhap VALUES
(N'PNK001', N'SP001', 3, 18000000),
(N'PNK002', N'SP004', 50, 280000);
GO

INSERT INTO PhieuTraHang VALUES
(N'PTH001', '2026-04-13', N'HDB002', N'NV004', 390000);
GO

INSERT INTO ChiTietPhieuTraHang VALUES
(N'PTH001', N'SP004', 1, 390000);
GO
