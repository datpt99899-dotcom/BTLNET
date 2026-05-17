using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyCuaHangMayTinh
{
    /// <summary>
    /// Module bảo mật mật khẩu cho hệ thống quản lý cửa hàng máy tính.
    ///
    /// CHUẨN CHÍNH (mới): BCrypt.Net-Next cost=11
    ///   - Mỗi mật khẩu có salt RANDOM (lưu chung trong hash, prefix "$2a$" hoặc "$2b$").
    ///   - Chống brute-force tốt hơn SHA256 hàng nghìn lần do work-factor.
    ///   - Chuẩn công nghiệp, được OWASP khuyến nghị.
    ///
    /// FALLBACK 1: SHA256 + salt cố định (định dạng "SHA256:..."):
    ///   - Tương thích với dữ liệu cũ đã hash bằng SHA256 (ResetPasswordToSHA256.sql).
    ///
    /// FALLBACK 2: plaintext (cho dữ liệu mẫu trong CreateDatabase.sql):
    ///   - Nếu hash trong DB không có prefix nào -> coi như plaintext.
    ///   - Chỉ dùng cho demo, KHÔNG dùng trong production.
    /// </summary>
    internal static class SecurityHelper
    {
        private const string SHA256_PREFIX = "SHA256:";
        private const string SHA256_LEGACY_SALT = "QLCHMT_2025_Salt";
        private const int BCRYPT_WORK_FACTOR = 11;

        /// <summary>
        /// Hash mật khẩu plain text bằng BCrypt với salt RANDOM tự sinh.
        /// Mỗi lần gọi với cùng input sẽ ra hash KHÁC NHAU (do salt random) — đây là đặc tính bảo mật.
        /// </summary>
        public static string HashPassword(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                return string.Empty;

            try
            {
                // BCrypt.Net-Next: tự sinh salt random cost=11, hash output ~60 ký tự, prefix "$2a$"/"$2b$"
                return BCrypt.Net.BCrypt.HashPassword(plainText.Trim(), BCRYPT_WORK_FACTOR);
            }
            catch (Exception)
            {
                // Fallback nếu BCrypt DLL không load được (rất hiếm)
                return HashPasswordSHA256(plainText);
            }
        }

        /// <summary>
        /// Hash bằng SHA256 + salt cố định — CHỈ DÙNG CHO FALLBACK.
        /// Giữ lại để tương thích với data cũ; không khuyến khích dùng cho user mới.
        /// </summary>
        public static string HashPasswordSHA256(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                return string.Empty;

            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plainText.Trim() + SHA256_LEGACY_SALT));
                return SHA256_PREFIX + Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// Kiểm tra mật khẩu — hỗ trợ 3 trường hợp:
        ///   1. BCrypt hash (prefix "$2a$"/"$2b$"/"$2y$") → dùng BCrypt.Verify (an toàn nhất).
        ///   2. SHA256 hash (prefix "SHA256:") → hash lại plaintext và so sánh.
        ///   3. Plaintext (không có prefix) → so sánh chuỗi trực tiếp (chỉ cho data mẫu).
        /// </summary>
        public static bool VerifyPassword(string plainText, string stored)
        {
            if (string.IsNullOrWhiteSpace(plainText) || string.IsNullOrWhiteSpace(stored))
                return false;

            plainText = plainText.Trim();
            stored = stored.Trim();

            // Case 1: BCrypt hash
            if (IsBCryptHash(stored))
            {
                try
                {
                    return BCrypt.Net.BCrypt.Verify(plainText, stored);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            // Case 2: SHA256 hash với salt cố định (data đã reset bằng ResetPasswordToSHA256.sql)
            if (stored.StartsWith(SHA256_PREFIX, StringComparison.Ordinal))
            {
                string newHash = HashPasswordSHA256(plainText);
                return string.Equals(newHash, stored, StringComparison.Ordinal);
            }

            // Case 3: plaintext (chỉ cho seed data demo)
            return string.Equals(plainText, stored, StringComparison.Ordinal);
        }

        /// <summary>
        /// Kiểm tra hash trong DB có cần migrate sang BCrypt không.
        /// Trả về true nếu hash là SHA256 cũ hoặc plaintext — caller có thể update DB.
        /// </summary>
        public static bool NeedsRehash(string stored)
        {
            if (string.IsNullOrWhiteSpace(stored)) return true;
            return !IsBCryptHash(stored.Trim());
        }

        /// <summary>Phát hiện BCrypt hash dựa trên prefix (Modular Crypt Format).</summary>
        private static bool IsBCryptHash(string hash)
        {
            if (string.IsNullOrEmpty(hash) || hash.Length < 7) return false;
            return hash.StartsWith("$2a$", StringComparison.Ordinal)
                || hash.StartsWith("$2b$", StringComparison.Ordinal)
                || hash.StartsWith("$2y$", StringComparison.Ordinal);
        }
    }
}
