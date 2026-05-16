using System;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
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
    }
}
