using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyCuaHangMayTinh
{
    internal static class SecurityHelper
    {
        public static string ComputeSha256(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
