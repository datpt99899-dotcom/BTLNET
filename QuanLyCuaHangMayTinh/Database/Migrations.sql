/* ============================================================
   MIGRATION SCRIPT — Quản lý phiên bản CSDL
   ============================================================
   Mục đích: ghi lại lịch sử thay đổi schema để dễ deploy lên môi trường mới.

   Cách áp dụng:
   - Khi tạo CSDL lần đầu: chạy CreateDatabase.sql (đã bao gồm version 1.0)
   - Khi nâng cấp: chạy các script migration_v*.sql theo thứ tự version.
   - Sau khi chạy xong: verify bằng SELECT * FROM SchemaVersion ORDER BY AppliedAt DESC;
   ============================================================ */

USE QuanLyCuaHangMayTinhDB;
GO

-- Tạo bảng theo dõi phiên bản schema (nếu chưa có)
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SchemaVersion')
BEGIN
    CREATE TABLE SchemaVersion (
        Version    NVARCHAR(20)  NOT NULL PRIMARY KEY,
        Description NVARCHAR(500) NOT NULL,
        AppliedAt   DATETIME      NOT NULL DEFAULT GETDATE()
    );
END
GO

-- Phiên bản 1.0: schema gốc + 3 trigger
IF NOT EXISTS (SELECT 1 FROM SchemaVersion WHERE Version = '1.0')
    INSERT INTO SchemaVersion VALUES ('1.0', N'Schema gốc: 15 bảng + 3 trigger tự động cập nhật tồn kho', GETDATE());
GO

-- Phiên bản 1.1: thêm 10 stored procedures
IF NOT EXISTS (SELECT 1 FROM SchemaVersion WHERE Version = '1.1')
BEGIN
    -- Chạy file StoredProcedures.sql sẽ tự tạo các SP.
    INSERT INTO SchemaVersion VALUES ('1.1', N'Thêm 10 stored procedures cho nghiệp vụ và báo cáo', GETDATE());
END
GO

-- Phiên bản 1.2: migrate mật khẩu sang BCrypt
-- (Việc migrate thực hiện AUTOMATIC qua app: lần đầu user login bằng SHA256/plaintext,
--  AuthRepository.cs sẽ tự gọi SecurityHelper.HashPassword(BCrypt) và UPDATE lại DB.
--  Sau khi tất cả user đã login lại 1 lần, có thể chạy query sau để verify:
--    SELECT MaNhanVien, TenDangNhap,
--           CASE WHEN MatKhau LIKE '$2%' THEN 'BCrypt OK'
--                WHEN MatKhau LIKE 'SHA256:%' THEN 'Còn SHA256'
--                ELSE 'Còn plaintext' END AS TrangThaiHash
--    FROM NhanVien;
-- )
IF NOT EXISTS (SELECT 1 FROM SchemaVersion WHERE Version = '1.2')
    INSERT INTO SchemaVersion VALUES ('1.2', N'Migrate mật khẩu sang BCrypt cost=11 (auto via app)', GETDATE());
GO

SELECT * FROM SchemaVersion ORDER BY AppliedAt;
