/* ============================================================
   STORED PROCEDURES — Hệ thống quản lý cửa hàng máy tính
   ============================================================
   Mục đích:
     - Đóng gói nghiệp vụ phức tạp ở tầng DB (transaction-safe).
     - Giảm round-trip giữa app và DB.
     - Tách logic SQL khỏi C# code → dễ bảo trì và tối ưu.

   Cách chạy:
     1. Đảm bảo đã chạy CreateDatabase.sql trước (tạo 15 bảng + 3 trigger).
     2. USE QuanLyCuaHangMayTinhDB và chạy nguyên file này.

   Danh sách 10 procedures:
     1.  sp_TaoHoaDonBan          - Tạo hóa đơn + chi tiết trong 1 transaction
     2.  sp_ChuyenDonDatHangThanhHoaDon - Chuyển đơn đặt → đơn bán
     3.  sp_NhapKho                - Tạo phiếu nhập + chi tiết
     4.  sp_TraHang                - Tạo phiếu trả hàng + chi tiết
     5.  sp_DoanhThuTheoNgay       - Báo cáo doanh thu theo ngày
     6.  sp_DoanhThuTheoThang      - Báo cáo doanh thu theo tháng
     7.  sp_TopSanPhamBanChay      - Top N sản phẩm bán chạy
     8.  sp_DonHangTheoTrangThai   - Thống kê đơn hàng theo trạng thái
     9.  sp_TimKiemSanPhamNangCao  - Tìm kiếm sản phẩm có nhiều bộ lọc
     10. sp_DoiMatKhau             - Đổi mật khẩu (verify + update)
   ============================================================ */

USE QuanLyCuaHangMayTinhDB;
GO

/* ──────────────────────────────────────────────────────────────
   1. sp_TaoHoaDonBan: tạo hóa đơn bán + chi tiết trong transaction.
      Tham số @ChiTietJson là JSON: [{"MaSanPham":"SP001","SoLuong":2,"DonGia":21000000}, ...]
      Lưu ý: trigger trg_BanHang_GiamTon sẽ tự trừ tồn kho khi insert ChiTietHoaDonBan.
   ────────────────────────────────────────────────────────────── */
IF OBJECT_ID('sp_TaoHoaDonBan', 'P') IS NOT NULL DROP PROCEDURE sp_TaoHoaDonBan;
GO
CREATE PROCEDURE sp_TaoHoaDonBan
    @MaHoaDonBan       NVARCHAR(20),
    @MaKhachHang       NVARCHAR(20) = NULL,
    @MaNhanVien        NVARCHAR(20),
    @MaDonDatHang      NVARCHAR(20) = NULL,
    @TienGiam          DECIMAL(18,2) = 0,
    @TongTien          DECIMAL(18,2),
    @HinhThucThanhToan NVARCHAR(50)  = N'Tiền mặt',
    @ChiTietJson       NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO HoaDonBan(MaHoaDonBan, NgayBan, MaKhachHang, MaNhanVien,
                              MaDonDatHang, TienGiam, TongTien, HinhThucThanhToan, TrangThai)
        VALUES (@MaHoaDonBan, GETDATE(), @MaKhachHang, @MaNhanVien,
                @MaDonDatHang, @TienGiam, @TongTien, @HinhThucThanhToan, N'Hoàn thành');

        -- Parse JSON chi tiết và insert (trigger sẽ tự trừ tồn kho)
        INSERT INTO ChiTietHoaDonBan(MaHoaDonBan, MaSanPham, SoLuong, DonGia)
        SELECT @MaHoaDonBan, MaSanPham, SoLuong, DonGia
        FROM   OPENJSON(@ChiTietJson)
               WITH (MaSanPham NVARCHAR(20) '$.MaSanPham',
                     SoLuong   INT          '$.SoLuong',
                     DonGia    DECIMAL(18,2) '$.DonGia');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrSev INT             = ERROR_SEVERITY();
        DECLARE @ErrSta INT             = ERROR_STATE();
        RAISERROR(@ErrMsg, @ErrSev, @ErrSta);
    END CATCH
END
GO

/* ──────────────────────────────────────────────────────────────
   2. sp_ChuyenDonDatHangThanhHoaDon: chuyển đơn đặt hàng "Chờ xử lý"
      thành hóa đơn bán hàng. Sao chép chi tiết, cập nhật trạng thái đơn đặt.
   ────────────────────────────────────────────────────────────── */
IF OBJECT_ID('sp_ChuyenDonDatHangThanhHoaDon', 'P') IS NOT NULL DROP PROCEDURE sp_ChuyenDonDatHangThanhHoaDon;
GO
CREATE PROCEDURE sp_ChuyenDonDatHangThanhHoaDon
    @MaDonDatHang NVARCHAR(20),
    @MaHoaDonBan  NVARCHAR(20),
    @MaNhanVien   NVARCHAR(20),
    @HinhThucThanhToan NVARCHAR(50) = N'Tiền mặt'
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @MaKH NVARCHAR(20), @TongTien DECIMAL(18,2), @Giam DECIMAL(18,2);

        SELECT @MaKH = MaKhachHang, @TongTien = TongTien, @Giam = TienGiam
        FROM   DonDatHang
        WHERE  MaDonDatHang = @MaDonDatHang AND TrangThai != N'Hoàn thành';

        IF @MaKH IS NULL
        BEGIN
            RAISERROR(N'Đơn đặt hàng không tồn tại hoặc đã hoàn thành.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Tạo hóa đơn bán
        INSERT INTO HoaDonBan(MaHoaDonBan, NgayBan, MaKhachHang, MaNhanVien,
                              MaDonDatHang, TienGiam, TongTien, HinhThucThanhToan, TrangThai)
        VALUES (@MaHoaDonBan, GETDATE(), @MaKH, @MaNhanVien,
                @MaDonDatHang, @Giam, @TongTien, @HinhThucThanhToan, N'Hoàn thành');

        -- Sao chép chi tiết (trigger sẽ tự trừ tồn kho)
        INSERT INTO ChiTietHoaDonBan(MaHoaDonBan, MaSanPham, SoLuong, DonGia)
        SELECT @MaHoaDonBan, MaSanPham, SoLuong, DonGia
        FROM   ChiTietDonDatHang
        WHERE  MaDonDatHang = @MaDonDatHang;

        -- Cập nhật trạng thái đơn đặt
        UPDATE DonDatHang SET TrangThai = N'Hoàn thành'
        WHERE  MaDonDatHang = @MaDonDatHang;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END
GO

/* ──────────────────────────────────────────────────────────────
   3. sp_NhapKho: tạo phiếu nhập + chi tiết, trigger sẽ tự tăng tồn kho.
   ────────────────────────────────────────────────────────────── */
IF OBJECT_ID('sp_NhapKho', 'P') IS NOT NULL DROP PROCEDURE sp_NhapKho;
GO
CREATE PROCEDURE sp_NhapKho
    @MaPhieuNhap NVARCHAR(20),
    @MaNCC       NVARCHAR(20),
    @MaNhanVien  NVARCHAR(20),
    @TongTien    DECIMAL(18,2),
    @ChiTietJson NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO PhieuNhapKho(MaPhieuNhap, NgayNhap, MaNCC, MaNhanVien, TongTien)
        VALUES (@MaPhieuNhap, GETDATE(), @MaNCC, @MaNhanVien, @TongTien);

        INSERT INTO ChiTietPhieuNhap(MaPhieuNhap, MaSanPham, SoLuong, DonGiaNhap)
        SELECT @MaPhieuNhap, MaSanPham, SoLuong, DonGiaNhap
        FROM   OPENJSON(@ChiTietJson)
               WITH (MaSanPham  NVARCHAR(20)  '$.MaSanPham',
                     SoLuong    INT           '$.SoLuong',
                     DonGiaNhap DECIMAL(18,2) '$.DonGiaNhap');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END
GO

/* ──────────────────────────────────────────────────────────────
   4. sp_TraHang: tạo phiếu trả hàng + chi tiết.
      Trigger trg_TraHang_TangTon sẽ tự cộng lại tồn kho cho SP "Nguyên vẹn".
   ────────────────────────────────────────────────────────────── */
IF OBJECT_ID('sp_TraHang', 'P') IS NOT NULL DROP PROCEDURE sp_TraHang;
GO
CREATE PROCEDURE sp_TraHang
    @MaPhieuTra  NVARCHAR(20),
    @MaHoaDonBan NVARCHAR(20),
    @MaNhanVien  NVARCHAR(20),
    @TongTien    DECIMAL(18,2),
    @LyDo        NVARCHAR(255),
    @ChiTietJson NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra hóa đơn gốc tồn tại
        IF NOT EXISTS (SELECT 1 FROM HoaDonBan WHERE MaHoaDonBan = @MaHoaDonBan)
        BEGIN
            RAISERROR(N'Hóa đơn bán hàng không tồn tại.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        INSERT INTO PhieuTraHang(MaPhieuTra, NgayTra, MaHoaDonBan, MaNhanVien, TongTien, LyDo)
        VALUES (@MaPhieuTra, GETDATE(), @MaHoaDonBan, @MaNhanVien, @TongTien, @LyDo);

        INSERT INTO ChiTietPhieuTraHang(MaPhieuTra, MaSanPham, SoLuongTra, DonGia, TinhTrangSP)
        SELECT @MaPhieuTra, MaSanPham, SoLuongTra, DonGia, ISNULL(TinhTrangSP, N'Nguyên vẹn')
        FROM   OPENJSON(@ChiTietJson)
               WITH (MaSanPham   NVARCHAR(20)  '$.MaSanPham',
                     SoLuongTra  INT           '$.SoLuongTra',
                     DonGia      DECIMAL(18,2) '$.DonGia',
                     TinhTrangSP NVARCHAR(100) '$.TinhTrangSP');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END
GO

/* ──────────────────────────────────────────────────────────────
   5. sp_DoanhThuTheoNgay: báo cáo doanh thu chi tiết theo từng ngày.
   ────────────────────────────────────────────────────────────── */
IF OBJECT_ID('sp_DoanhThuTheoNgay', 'P') IS NOT NULL DROP PROCEDURE sp_DoanhThuTheoNgay;
GO
CREATE PROCEDURE sp_DoanhThuTheoNgay
    @TuNgay DATETIME,
    @DenNgay DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CAST(NgayBan AS DATE) AS Ngay,
           COUNT(*)              AS SoDon,
           SUM(TongTien)         AS DoanhThu,
           AVG(TongTien)         AS TrungBinh
    FROM   HoaDonBan
    WHERE  TrangThai IN (N'Hoàn thành', N'Đã giao')
      AND  NgayBan BETWEEN @TuNgay AND @DenNgay
    GROUP  BY CAST(NgayBan AS DATE)
    ORDER  BY Ngay;
END
GO

/* ──────────────────────────────────────────────────────────────
   6. sp_DoanhThuTheoThang: báo cáo doanh thu theo tháng của 1 năm cụ thể.
   ────────────────────────────────────────────────────────────── */
IF OBJECT_ID('sp_DoanhThuTheoThang', 'P') IS NOT NULL DROP PROCEDURE sp_DoanhThuTheoThang;
GO
CREATE PROCEDURE sp_DoanhThuTheoThang
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MONTH(NgayBan) AS Thang,
           COUNT(*)       AS SoDon,
           SUM(TongTien)  AS DoanhThu
    FROM   HoaDonBan
    WHERE  TrangThai IN (N'Hoàn thành', N'Đã giao')
      AND  YEAR(NgayBan) = @Nam
    GROUP  BY MONTH(NgayBan)
    ORDER  BY Thang;
END
GO

/* ──────────────────────────────────────────────────────────────
   7. sp_TopSanPhamBanChay: top N sản phẩm bán chạy trong khoảng thời gian.
   ────────────────────────────────────────────────────────────── */
IF OBJECT_ID('sp_TopSanPhamBanChay', 'P') IS NOT NULL DROP PROCEDURE sp_TopSanPhamBanChay;
GO
CREATE PROCEDURE sp_TopSanPhamBanChay
    @TuNgay DATETIME,
    @DenNgay DATETIME,
    @TopN   INT = 10
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP (@TopN)
           sp.MaSanPham,
           sp.TenSanPham,
           lsp.TenLoai,
           th.TenThuongHieu,
           SUM(ct.SoLuong)              AS TongSoLuong,
           SUM(ct.SoLuong * ct.DonGia)  AS DoanhThu
    FROM   ChiTietHoaDonBan ct
    INNER JOIN HoaDonBan    hd  ON ct.MaHoaDonBan = hd.MaHoaDonBan
    INNER JOIN SanPham      sp  ON ct.MaSanPham   = sp.MaSanPham
    INNER JOIN LoaiSanPham  lsp ON sp.MaLoai       = lsp.MaLoai
    INNER JOIN ThuongHieu   th  ON sp.MaThuongHieu = th.MaThuongHieu
    WHERE  hd.NgayBan BETWEEN @TuNgay AND @DenNgay
      AND  hd.TrangThai IN (N'Hoàn thành', N'Đã giao')
    GROUP  BY sp.MaSanPham, sp.TenSanPham, lsp.TenLoai, th.TenThuongHieu
    ORDER  BY TongSoLuong DESC;
END
GO

/* ──────────────────────────────────────────────────────────────
   8. sp_DonHangTheoTrangThai: thống kê số đơn theo từng trạng thái.
   ────────────────────────────────────────────────────────────── */
IF OBJECT_ID('sp_DonHangTheoTrangThai', 'P') IS NOT NULL DROP PROCEDURE sp_DonHangTheoTrangThai;
GO
CREATE PROCEDURE sp_DonHangTheoTrangThai
    @TuNgay DATETIME = NULL,
    @DenNgay DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TrangThai,
           COUNT(*)        AS SoLuong,
           SUM(TongTien)   AS TongTien
    FROM   DonDatHang
    WHERE  (@TuNgay  IS NULL OR NgayDat >= @TuNgay)
      AND  (@DenNgay IS NULL OR NgayDat <= @DenNgay)
    GROUP  BY TrangThai
    ORDER  BY SoLuong DESC;
END
GO

/* ──────────────────────────────────────────────────────────────
   9. sp_TimKiemSanPhamNangCao: tìm kiếm sản phẩm với nhiều bộ lọc.
      Các tham số NULL nghĩa là không lọc theo điều kiện đó.
   ────────────────────────────────────────────────────────────── */
IF OBJECT_ID('sp_TimKiemSanPhamNangCao', 'P') IS NOT NULL DROP PROCEDURE sp_TimKiemSanPhamNangCao;
GO
CREATE PROCEDURE sp_TimKiemSanPhamNangCao
    @TuKhoa        NVARCHAR(200) = NULL,
    @MaLoai        NVARCHAR(20)  = NULL,
    @MaThuongHieu  NVARCHAR(20)  = NULL,
    @GiaMin        DECIMAL(18,2) = NULL,
    @GiaMax        DECIMAL(18,2) = NULL,
    @ConHang       BIT           = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sp.MaSanPham, sp.TenSanPham, lsp.TenLoai, th.TenThuongHieu,
           sp.GiaBan, sp.SoLuongTon, sp.BaoHanhThang, sp.MoTa, sp.HinhAnh
    FROM   SanPham sp
    INNER JOIN LoaiSanPham lsp ON sp.MaLoai       = lsp.MaLoai
    INNER JOIN ThuongHieu  th  ON sp.MaThuongHieu = th.MaThuongHieu
    WHERE  (@TuKhoa       IS NULL OR sp.TenSanPham LIKE '%' + @TuKhoa + '%'
                                  OR sp.MaSanPham  LIKE '%' + @TuKhoa + '%')
      AND  (@MaLoai       IS NULL OR sp.MaLoai       = @MaLoai)
      AND  (@MaThuongHieu IS NULL OR sp.MaThuongHieu = @MaThuongHieu)
      AND  (@GiaMin       IS NULL OR sp.GiaBan      >= @GiaMin)
      AND  (@GiaMax       IS NULL OR sp.GiaBan      <= @GiaMax)
      AND  (@ConHang      IS NULL OR (@ConHang = 1 AND sp.SoLuongTon > 0)
                                   OR (@ConHang = 0))
    ORDER  BY sp.TenSanPham;
END
GO

/* ──────────────────────────────────────────────────────────────
   10. sp_DoiMatKhau: đổi mật khẩu cho nhân viên.
       Lưu ý: việc verify mật khẩu cũ + hash mật khẩu mới được thực hiện ở C#
       (SecurityHelper.VerifyPassword + HashPassword bằng BCrypt).
       SP này chỉ chịu trách nhiệm UPDATE với hash đã hash sẵn.
   ────────────────────────────────────────────────────────────── */
IF OBJECT_ID('sp_DoiMatKhau', 'P') IS NOT NULL DROP PROCEDURE sp_DoiMatKhau;
GO
CREATE PROCEDURE sp_DoiMatKhau
    @MaNhanVien    NVARCHAR(20),
    @MatKhauMoiHash NVARCHAR(255),
    @Result        INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = @MaNhanVien AND TrangThai = 1)
    BEGIN
        SET @Result = -1;  -- Tài khoản không tồn tại / khóa
        RETURN;
    END

    UPDATE NhanVien
    SET    MatKhau = @MatKhauMoiHash
    WHERE  MaNhanVien = @MaNhanVien;

    SET @Result = @@ROWCOUNT;  -- 1 nếu thành công, 0 nếu không có thay đổi
END
GO

PRINT N'Đã tạo xong 10 stored procedures.';
GO
