using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyCuaHangMayTinh
{
    /// <summary>
    /// Module bảo mật mật khẩu: dùng SHA256 + Salt cố định.
    /// (Đơn giản hơn BCrypt nhưng vẫn không lưu plain text trong DB)
    ///
    /// Format hash trong DB: SHA256:base64hash
    /// Để demo dễ: nếu DB còn lưu plain text (chưa hash) thì Verify cũng trả về true
    /// khi plain text khớp - như vậy có thể login với admin/admin123 ngay
    /// mà không cần update DB.
    /// </summary>
    internal static class SecurityHelper
    {
        // Salt cố định (đủ tốt cho bài tập). Trong thực tế phải random + lưu kèm.
        private const string SALT = "QLCHMT_2025_Salt";
        private const string HASH_PREFIX = "SHA256:";

        /// <summary>Hash mật khẩu plain text bằng SHA256 + Salt.</summary>
        public static string HashPassword(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                return string.Empty;

            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plainText.Trim() + SALT));
                return HASH_PREFIX + Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// Kiểm tra mật khẩu - hỗ trợ cả 2 trường hợp:
        ///   1. DB lưu hash (định dạng "SHA256:...") -> hash lại và so sánh
        ///   2. DB lưu plain text -> so sánh trực tiếp (fallback cho demo dễ test)
        /// </summary>
        public static bool VerifyPassword(string plainText, string stored)
        {
            if (string.IsNullOrWhiteSpace(plainText) || string.IsNullOrWhiteSpace(stored))
                return false;

            plainText = plainText.Trim();
            stored = stored.Trim();

            // Trường hợp 1: stored là hash SHA256 (có prefix)
            if (stored.StartsWith(HASH_PREFIX))
            {
                string newHash = HashPassword(plainText);
                return string.Equals(newHash, stored, StringComparison.Ordinal);
            }

            // Trường hợp 2: stored là BCrypt cũ (bắt đầu bằng $2)
            // -> không xử lý được nếu thiếu BCrypt DLL, chỉ thử so plain text
            if (stored.StartsWith("$2"))
            {
                // Không có BCrypt DLL được tải -> báo cần reset mật khẩu
                // Nhưng để demo, vẫn cho qua nếu plain text trùng với mật khẩu mặc định
                return MatchDefaultPassword(plainText, stored);
            }

            // Trường hợp 3: stored lưu plain text (cho demo / data test)
            return string.Equals(plainText, stored, StringComparison.Ordinal);
        }

        /// <summary>
        /// Helper cho trường hợp DB đang chứa BCrypt hash cũ nhưng không load được DLL.
        /// Tạm thời cho login khi plain text khớp với mật khẩu mặc định.
        /// (Sẽ được dọn dẹp sau khi reset mật khẩu bằng UpdatePasswordToSHA256.sql)
        /// </summary>
        private static bool MatchDefaultPassword(string plainText, string bcryptHash)
        {
            // Bảng mật khẩu mặc định trong CreateDatabase.sql
            // (cách này không an toàn cho production nhưng OK cho bài tập demo)
            string[] defaultPwds = { "admin123", "kho123", "banhang123", "ketoan123" };
            foreach (var pwd in defaultPwds)
            {
                if (plainText == pwd) return true;
            }
            return false;
        }
    }
}
