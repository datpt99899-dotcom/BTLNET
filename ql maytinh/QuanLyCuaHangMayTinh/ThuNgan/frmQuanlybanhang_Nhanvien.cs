using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmQuanlybanhang_Nhanvien : Form
    {
        public frmQuanlybanhang_Nhanvien()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
        }

        private void frmQuanlybanhang_Nhanvien_Load(object sender, EventArgs e)
        {
            Function.Connect();
            KhoiTaoMenuMoRong();
            iconButton1_Click(iconButton1, EventArgs.Empty);
        }

        private void KhoiTaoMenuMoRong()
        {
            btnDonDatHang = new Button { Text = "Đơn đặt hàng", Width = 120, Height = 28, Left = 320, Top = 10, BackColor = Color.White, ForeColor = Color.Green };
            btnTraHang = new Button { Text = "Trả hàng", Width = 120, Height = 28, Left = 450, Top = 10, BackColor = Color.White, ForeColor = Color.Green };
            btnDonDatHang.Click += (s, ev) => { ShowFormInPanel(new QuanLy.frmDonDatHang(), pnelQuanlybanhang); ActivateButton(btnDonDatHang); };
            btnTraHang.Click += (s, ev) => { ShowFormInPanel(new QuanLy.frmTraHang(), pnelQuanlybanhang); ActivateButton(btnTraHang); };
            panel2.Controls.Add(btnDonDatHang);
            panel2.Controls.Add(btnTraHang);
        }
        private Button currentButton = null;
        private Color defaultBackColor = Color.White;
        private Color selectedBackColor = Color.MediumAquamarine; 
        private Color selectedForeColor = Color.White;
        private Color defaultForeColor = Color.Green;
        private Button btnDonDatHang;
        private Button btnTraHang;


        private void ShowFormInPanel(Form frm, Panel panel)
        {
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panel.Controls.Clear();
            panel.Controls.Add(frm);
            frm.Show();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            //hiển thị danh sách bàn
            ShowFormInPanel(new frmBanhang_Nhanvien(), pnelQuanlybanhang);
            ActivateButton((Button)sender);
        }
        
        //Đổi màu button khi click
        private void ActivateButton(Button senderButton)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = defaultBackColor;
                currentButton.ForeColor = defaultForeColor;
            }

            currentButton = senderButton;
            currentButton.BackColor = selectedBackColor;
            currentButton.ForeColor = selectedForeColor;
        }

        private void btnBaocaohoadon_nhanvien_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new frmBaocaohoadon_Nhanvien(), pnelQuanlybanhang);
            ActivateButton((Button)sender);
        }

        private void pnelQuanlybanhang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmLogin f = new frmLogin();
                f.Show();
            }
        }
    }
}
