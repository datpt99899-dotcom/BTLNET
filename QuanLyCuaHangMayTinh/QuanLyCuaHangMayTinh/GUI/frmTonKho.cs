using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmTonKho : Form
    {
        private DataTable tblSanPham;

        // ===== DRAG FORM =====
        [DllImport("user32.dll")]
        public static extern void ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmTonKho()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            try
            {
                Function.Connect();
                this.Text = "Quản lý tồn kho";
                LoadCombos();
                LoadDataGridView();
                ResetValues();
                AddWindowControlButtons();
                SetupFormDrag();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== THÊM 3 NÚT ĐIỀU KHIỂN VÀO TITLE BAR =====
        private void AddWindowControlButtons()
        {
            // Panel right chứa 3 nút (dùng DockStyle.Right)
            Panel pnlRight = new Panel();
            pnlRight.Name = "pnlRight";
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Width = 120;
            pnlRight.BackColor = Color.RoyalBlue;
            pnlRight.Height = 40;

            // Nút Thu nhỏ
            Button btnMinimize = new Button();
            btnMinimize.Text = "━";
            btnMinimize.Font = new Font("Arial", 12, FontStyle.Bold);
            btnMinimize.Location = new Point(0, 5);
            btnMinimize.Size = new Size(35, 30);
            btnMinimize.BackColor = Color.LightBlue;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.Click += (s, e) => { this.WindowState = FormWindowState.Minimized; };
            btnMinimize.MouseEnter += (s, e) => btnMinimize.BackColor = Color.SkyBlue;
            btnMinimize.MouseLeave += (s, e) => btnMinimize.BackColor = Color.LightBlue;
            new ToolTip().SetToolTip(btnMinimize, "Thu nhỏ");

            // Nút Mở rộng
            Button btnMaximize = new Button();
            btnMaximize.Text = "▢";
            btnMaximize.Font = new Font("Arial", 12, FontStyle.Bold);
            btnMaximize.Location = new Point(40, 5);
            btnMaximize.Size = new Size(35, 30);
            btnMaximize.BackColor = Color.LightBlue;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.Cursor = Cursors.Hand;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.Click += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    btnMaximize.Text = "▢";
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                    btnMaximize.Text = "❏";
                }
            };
            btnMaximize.MouseEnter += (s, e) => btnMaximize.BackColor = Color.SkyBlue;
            btnMaximize.MouseLeave += (s, e) => btnMaximize.BackColor = Color.LightBlue;
            new ToolTip().SetToolTip(btnMaximize, "Mở rộng");

            // Nút Đóng
            Button btnClose = new Button();
            btnClose.Text = "✕";
            btnClose.Font = new Font("Arial", 12, FontStyle.Bold);
            btnClose.Location = new Point(80, 5);
            btnClose.Size = new Size(35, 30);
            btnClose.BackColor = Color.Red;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => { this.Close(); };
            btnClose.MouseEnter += (s, e) => btnClose.BackColor = Color.DarkRed;
            btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Red;
            new ToolTip().SetToolTip(btnClose, "Đóng");

            pnlRight.Controls.Add(btnMinimize);
            pnlRight.Controls.Add(btnMaximize);
            pnlRight.Controls.Add(btnClose);

            // Thêm panel vào lblTitle hoặc tạo panel title riêng
            Panel pnlTitle = new Panel();
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Height = 40;
            pnlTitle.BackColor = Color.RoyalBlue;
            pnlTitle.Controls.Add(lblTitle);
            pnlTitle.Controls.Add(pnlRight);

            this.Controls.Add(pnlTitle);
            this.Controls.SetChildIndex(pnlTitle, 0);
            pnlTitle.BringToFront();
        }

        // ===== SETUP DRAG FORM =====
        private void SetupFormDrag()
        {
            // Drag bằng lblTitle
            lblTitle.MouseDown += (s, e) =>
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            };

            // Resize responsive
            this.Resize += (s, e) =>
            {
                this.Refresh();
            };
        }

        // ===== LOAD COMBOBOX =====
        private void LoadCombos()
        {
            try
            {
                Function.FillCombo("SELECT MaLoai, TenLoai FROM LoaiSanPham",
                    cboLoaiSP, "MaLoai", "TenLoai");
                cboLoaiSP.SelectedIndex = -1;

                cboTrangThai.Items.Add("Tất cả");
                cboTrangThai.Items.Add("Còn hàng");
                cboTrangThai.Items.Add("Sắp hết");
                cboTrangThai.Items.Add("Hết hàng");
                cboTrangThai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load combo: " + ex.Message);
            }
        }

        // ===== LOAD DATAGRIDVIEW =====
        private void LoadDataGridView()
        {
            try
            {
                string sql = @"SELECT sp.MaSanPham, 
                                      sp.TenSanPham, 
                                      ls.TenLoai, 
                                      th.TenThuongHieu,
                                      sp.SoLuongTon,
                                      sp.GiaNhap,
                                      sp.GiaBan,
                                      ncc.TenNhaCungCap,
                                      sp.NgayCapNhatCuoi,
                                      CASE 
                                          WHEN sp.SoLuongTon = 0 THEN 'Hết hàng'
                                          WHEN sp.SoLuongTon <= 10 THEN 'Sắp hết'
                                          ELSE 'Còn hàng'
                                      END AS TrangThai
                               FROM SanPham sp
                               LEFT JOIN LoaiSanPham ls ON sp.MaLoai = ls.MaLoai
                               LEFT JOIN ThuongHieu th ON sp.MaThuongHieu = th.MaThuongHieu
                               LEFT JOIN NhaCungCap ncc ON sp.MaNhaCungCap = ncc.MaNhaCungCap
                               ORDER BY sp.MaSanPham";

                tblSanPham = Function.GetDataToTable(sql);
                dataGridView1.DataSource = tblSanPham;
                ConfigureDataGridView();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        // ===== CẤU HÌNH DATAGRIDVIEW =====
        private void ConfigureDataGridView()
        {
            try
            {
                dataGridView1.Columns.Clear();

                DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
                col0.DataPropertyName = "MaSanPham";
                col0.HeaderText = "Mã SP";
                col0.Width = 80;
                dataGridView1.Columns.Add(col0);

                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.DataPropertyName = "TenSanPham";
                col1.HeaderText = "Tên sản phẩm";
                col1.Width = 180;
                dataGridView1.Columns.Add(col1);

                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.DataPropertyName = "TenLoai";
                col2.HeaderText = "Loại";
                col2.Width = 100;
                dataGridView1.Columns.Add(col2);

                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.DataPropertyName = "TenThuongHieu";
                col3.HeaderText = "Thương hiệu";
                col3.Width = 100;
                dataGridView1.Columns.Add(col3);

                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.DataPropertyName = "SoLuongTon";
                col4.HeaderText = "Tồn kho";
                col4.Width = 80;
                col4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns.Add(col4);

                DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
                col5.DataPropertyName = "GiaNhap";
                col5.HeaderText = "Giá nhập (đ)";
                col5.Width = 110;
                col5.DefaultCellStyle.Format = "N0";
                col5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns.Add(col5);

                DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
                col6.DataPropertyName = "GiaBan";
                col6.HeaderText = "Giá bán (đ)";
                col6.Width = 110;
                col6.DefaultCellStyle.Format = "N0";
                col6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns.Add(col6);

                DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
                col7.DataPropertyName = "TenNhaCungCap";
                col7.HeaderText = "Nhà cung cấp";
                col7.Width = 120;
                dataGridView1.Columns.Add(col7);

                DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
                col8.DataPropertyName = "NgayCapNhatCuoi";
                col8.HeaderText = "Cập nhật";
                col8.Width = 100;
                col8.DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns.Add(col8);

                DataGridViewTextBoxColumn col9 = new DataGridViewTextBoxColumn();
                col9.DataPropertyName = "TrangThai";
                col9.HeaderText = "Trạng thái";
                col9.Width = 100;
                dataGridView1.Columns.Add(col9);

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cấu hình DataGridView: " + ex.Message);
            }
        }

        // ===== CẬP NHẬT THỐNG KÊ =====
        private void UpdateStatistics()
        {
            try
            {
                if (tblSanPham == null || tblSanPham.Rows.Count == 0) return;

                int totalProducts = tblSanPham.Rows.Count;
                int outOfStock = 0;
                int lowStock = 0;
                decimal totalInventory = 0;

                foreach (DataRow row in tblSanPham.Rows)
                {
                    int qty = Convert.ToInt32(row["SoLuongTon"]);

                    if (qty == 0)
                        outOfStock++;
                    else if (qty <= 10)
                        lowStock++;

                    totalInventory += qty;
                }

                txtTongSP.Text = totalProducts.ToString();
                txtHetHang.Text = outOfStock.ToString();
                txtSapHet.Text = lowStock.ToString();
                txtTonTB.Text = (totalProducts > 0 ? (totalInventory / totalProducts).ToString("F0") : "0");
                txtTongTon.Text = totalInventory.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính toán: " + ex.Message);
            }
        }

        private void ResetValues()
        {
            txtTimKiem.Text = string.Empty;
            cboLoaiSP.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (tblSanPham == null || tblSanPham.Rows.Count == 0 || dataGridView1.CurrentRow == null)
                return;

            try
            {
                int rowIndex = dataGridView1.CurrentRow.Index;
                if (rowIndex >= 0 && rowIndex < tblSanPham.Rows.Count)
                {
                    DataRow row = tblSanPham.Rows[rowIndex];
                    MessageBox.Show(
                        $"Mã: {row["MaSanPham"]}\n" +
                        $"Tên: {row["TenSanPham"]}\n" +
                        $"Loại: {row["TenLoai"]}\n" +
                        $"Thương hiệu: {row["TenThuongHieu"]}\n" +
                        $"Tồn kho: {row["SoLuongTon"]}\n" +
                        $"Giá nhập: {Convert.ToDecimal(row["GiaNhap"]):N0}đ\n" +
                        $"Giá bán: {Convert.ToDecimal(row["GiaBan"]):N0}đ\n" +
                        $"Nhà cung cấp: {row["TenNhaCungCap"]}\n" +
                        $"Trạng thái: {row["TrangThai"]}",
                        "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"SELECT sp.MaSanPham, 
                                      sp.TenSanPham, 
                                      ls.TenLoai, 
                                      th.TenThuongHieu,
                                      sp.SoLuongTon,
                                      sp.GiaNhap,
                                      sp.GiaBan,
                                      ncc.TenNhaCungCap,
                                      sp.NgayCapNhatCuoi,
                                      CASE 
                                          WHEN sp.SoLuongTon = 0 THEN 'Hết hàng'
                                          WHEN sp.SoLuongTon <= 10 THEN 'Sắp hết'
                                          ELSE 'Còn hàng'
                                      END AS TrangThai
                               FROM SanPham sp
                               LEFT JOIN LoaiSanPham ls ON sp.MaLoai = ls.MaLoai
                               LEFT JOIN ThuongHieu th ON sp.MaThuongHieu = th.MaThuongHieu
                               LEFT JOIN NhaCungCap ncc ON sp.MaNhaCungCap = ncc.MaNhaCungCap
                               WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    sql += " AND (sp.MaSanPham LIKE N'%" + txtTimKiem.Text.Trim() + "%' " +
                           "OR sp.TenSanPham LIKE N'%" + txtTimKiem.Text.Trim() + "%')";
                }

                if (cboLoaiSP.SelectedIndex > -1)
                {
                    sql += " AND sp.MaLoai = N'" + cboLoaiSP.SelectedValue + "'";
                }

                if (cboTrangThai.SelectedIndex > 0)
                {
                    string trangThai = cboTrangThai.SelectedItem.ToString();
                    if (trangThai == "Còn hàng")
                        sql += " AND sp.SoLuongTon > 10";
                    else if (trangThai == "Sắp hết")
                        sql += " AND sp.SoLuongTon > 0 AND sp.SoLuongTon <= 10";
                    else if (trangThai == "Hết hàng")
                        sql += " AND sp.SoLuongTon = 0";
                }

                sql += " ORDER BY sp.MaSanPham";

                tblSanPham = Function.GetDataToTable(sql);
                dataGridView1.DataSource = tblSanPham;
                ConfigureDataGridView();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnLMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadDataGridView();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblSanPham == null || tblSanPham.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo");
                    return;
                }

                MessageBox.Show("Tính năng xuất Excel đang được phát triển!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblSanPham == null || tblSanPham.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để in!", "Cảnh báo");
                    return;
                }

                MessageBox.Show("Tính năng in đang được phát triển!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTKiem_Click(sender, e);
                e.Handled = true;
            }
        }


    }
}