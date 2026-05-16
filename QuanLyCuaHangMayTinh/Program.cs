using System;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Tắt DPI auto-scaling của Windows — giữ layout đúng pixel như Designer.
            // Phải gọi TRƯỚC EnableVisualStyles và TRƯỚC khi tạo form đầu tiên.
            try { SetProcessDPIAware(); } catch { /* OS cũ không hỗ trợ — bỏ qua */ }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try { Function.Connect(); }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu:\n" + ex.Message +
                    "\n\nHãy chạy Database/CreateDatabase.sql và kiểm tra App.config.",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Run(new frmLogin());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
