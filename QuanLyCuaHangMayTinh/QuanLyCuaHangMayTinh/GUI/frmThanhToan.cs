using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            Text = "Xử lý thanh toán";
            Width = 900;
            Height = 600;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmThanhToan
            // 
            this.ClientSize = new System.Drawing.Size(1164, 650);
            this.Name = "frmThanhToan";
            this.ResumeLayout(false);

        }
    }
}
