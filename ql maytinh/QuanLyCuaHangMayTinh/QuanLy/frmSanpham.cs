using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmSanpham : Form
    {
        DataTable SanPham;
        DataTable ChiTietSanPham;
        public frmSanpham()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmSanpham_Load(object sender, EventArgs e)
        {
            // Khi form load thì sẽ gọi hàm Connect để kết nối với CSDL
            QuanLyCuaHangMayTinh.Function.Connect();
            txtMasanpham.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            // Gọi hàm load dữ liệu vào datagridview
            Load_DataGridViewSP();
             // Gọi hàm load dữ liệu vào datagridview chi tiết sản phẩm
            // Gọi hàm load dữ liệu vào combobox
            string sql = "SELECT * FROM Loai";
            QuanLyCuaHangMayTinh.Function.FillCombo(sql, cboDanhmuc, "Maloai", "Tenloai");
            cboDanhmuc.SelectedIndex = -1; // Đặt giá trị mặc định cho combobox

            // Khởi tạo DataSource cho cboMaSPChitiet và cboNguyenlieu
            string sqlSanPham = "SELECT MaSanPham, TenSanPham FROM SanPham";
            QuanLyCuaHangMayTinh.Function.FillCombo(sqlSanPham, cboMaSPChitiet, "MaSanPham", "TenSanPham");
            cboMaSPChitiet.SelectedIndex = -1;

            string sqlNguyenLieu = "SELECT MaNguyenLieu, TenNguyenLieu FROM NguyenLieu";
            QuanLyCuaHangMayTinh.Function.FillCombo(sqlNguyenLieu, cboNguyenlieu, "MaNguyenLieu", "TenNguyenLieu");
            cboNguyenlieu.SelectedIndex = -1;

            ResetValues();
            ResetValues1();

            // Ẩn
            txtMasanpham.Enabled = false;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            txtAnh.Enabled = false;
        }
        private void Load_DataGridViewSP()
        {
            string sql;
            sql = "SELECT MaSanPham, TenSanPham, TenLoai, GiaBan, HinhAnh, GiaNhap from SanPham s  join Loai l on l.MaLoai=s.MaLoai";
            SanPham = QuanLyCuaHangMayTinh.Function.GetDataToTable(sql);
            //Gán dữ liệu từ bảng vào datagridview
            dataGridViewQLyCaPhe.DataSource = SanPham;

            //đặt tên cho các cột
            dataGridViewQLyCaPhe.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewQLyCaPhe.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridViewQLyCaPhe.Columns[2].HeaderText = "Danh mục";
            dataGridViewQLyCaPhe.Columns[3].HeaderText = "Giá bán";
            dataGridViewQLyCaPhe.Columns[4].HeaderText = "Hình ảnh";
            dataGridViewQLyCaPhe.Columns[5].HeaderText = "Giá nhập";
            dataGridViewQLyCaPhe.Columns[0].Width = 150;
            dataGridViewQLyCaPhe.Columns[1].Width = 200;
            dataGridViewQLyCaPhe.Columns[2].Width = 150;
            dataGridViewQLyCaPhe.Columns[3].Width = 100;
            dataGridViewQLyCaPhe.Columns[4].Width = 100;
            dataGridViewQLyCaPhe.Columns[5].Width = 100;
            // In đậm tên các cột
            dataGridViewQLyCaPhe.ColumnHeadersDefaultCellStyle.Font = new Font(
                dataGridViewQLyCaPhe.Font.FontFamily,
                dataGridViewQLyCaPhe.Font.Size,
                FontStyle.Bold
            );

            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dataGridViewQLyCaPhe.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dataGridViewQLyCaPhe.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dataGridViewQLyCaPhe_Click(object sender, EventArgs e)
        {
            
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMasanpham.Focus();
                return;
            }
            if (SanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Lấy dòng hiện tại
            txtMasanpham.Text = dataGridViewQLyCaPhe.CurrentRow.Cells["MaSanPham"].Value.ToString();
            txtTensanpham.Text = dataGridViewQLyCaPhe.CurrentRow.Cells["TenSanPham"].Value.ToString();
            // ma = dataGridViewQLyCaPhe.CurrentRow.Cells["MaLoai"].Value.ToString();
            // cboDanhmuc.Text = QuanLyCuaHangMayTinh.Function.GetFieldValues("SELECT TenLoai FROM Loai WHERE MaLoai = N'" + ma + "'");
            cboDanhmuc.Text = dataGridViewQLyCaPhe.CurrentRow.Cells["TenLoai"].Value.ToString();
            txtGiaban.Text = dataGridViewQLyCaPhe.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtAnh.Text = QuanLyCuaHangMayTinh.Function.GetFieldValues("SELECT HinhAnh FROM SanPham WHERE MaSanPham = N'" + txtMasanpham.Text + "'");
            txtGianhap.Text = dataGridViewQLyCaPhe.CurrentRow.Cells["GiaNhap"].Value.ToString();
            //hien thị hình ảnh lên picturebox neu ko co hien thi tbao loi
            if (!string.IsNullOrEmpty(txtAnh.Text) && File.Exists(txtAnh.Text))
            {
                picAnh.Image = Image.FromFile(txtAnh.Text);
            }
            else
            {
                picAnh.Image = null;
                MessageBox.Show("Image file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
            txtGiaban.Enabled = false;
            txtGianhap.Enabled = false;

            Load_DataGridViewChiTietSP();

        }
        private void Load_DataGridViewChiTietSP()
        {
            if (dataGridViewQLyCaPhe.CurrentRow == null)
            {
                // Không có dòng nào được chọn, có thể reset hoặc xóa dữ liệu
                dataGridViewChiTietSP.DataSource = null;
                return;
            }

            string maSanPham = dataGridViewQLyCaPhe.CurrentRow.Cells["MaSanPham"].Value.ToString();

            string sql = $"SELECT MaSanPham, n.MaNguyenLieu, n.TenNguyenLieu, SoLuongDung, ChiPhi " +
                         $"FROM ChiTietSanPham c JOIN NguyenLieu n ON c.MaNguyenLieu = n.MaNguyenLieu " +
                         $"WHERE MaSanPham = N'{maSanPham}'";

            ChiTietSanPham = QuanLyCuaHangMayTinh.Function.GetDataToTable(sql);
            dataGridViewChiTietSP.DataSource = ChiTietSanPham;

            // Đặt tên cho các cột
            dataGridViewChiTietSP.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewChiTietSP.Columns[1].HeaderText = "Mã sản phẩm";
            dataGridViewChiTietSP.Columns[2].HeaderText = "Tên sản phẩm";
            dataGridViewChiTietSP.Columns[3].HeaderText = "Số lượng dùng";
            dataGridViewChiTietSP.Columns[4].HeaderText = "Chi phí";
            dataGridViewChiTietSP.Columns[0].Width = 70;
            dataGridViewChiTietSP.Columns[1].Width = 100;
            dataGridViewChiTietSP.Columns[2].Width = 100;
            dataGridViewChiTietSP.Columns[3].Width = 100;
            dataGridViewChiTietSP.Columns[4].Width = 50;

            // In đậm tên các cột
            dataGridViewChiTietSP.ColumnHeadersDefaultCellStyle.Font = new Font(
                dataGridViewChiTietSP.Font.FontFamily,
                dataGridViewChiTietSP.Font.Size,
                FontStyle.Bold
            );

            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dataGridViewChiTietSP.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dataGridViewChiTietSP.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void ResetValues()
        {
            txtMasanpham.Text = "";
            txtTensanpham.Text = "";
            cboDanhmuc.Text = "";
            txtGiaban.Text = "";
            txtGianhap.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }


        private void dataGridViewChiTietSP_Click(object sender, EventArgs e)
        {
            // Nạp lại dữ liệu cho ComboBox
            string sqlSanPham = "SELECT MaSanPham, TenSanPham FROM SanPham";
            QuanLyCuaHangMayTinh.Function.FillCombo(sqlSanPham, cboMaSPChitiet, "MaSanPham", "TenSanPham");

            string sqlNguyenLieu = "SELECT MaNguyenLieu, TenNguyenLieu FROM NguyenLieu";
            QuanLyCuaHangMayTinh.Function.FillCombo(sqlNguyenLieu, cboNguyenlieu, "MaNguyenLieu", "TenNguyenLieu");

            // Kiểm tra xem ComboBox có dữ liệu hay không
            if (cboMaSPChitiet.Items.Count == 0)
            {
                MessageBox.Show("ComboBox sản phẩm chi tiết không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (cboNguyenlieu.Items.Count == 0)
            {
                MessageBox.Show("ComboBox sản phẩm không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Lấy mã sản phẩm và mã sản phẩm từ dòng hiện tại
            if (dataGridViewChiTietSP.CurrentRow != null)
            {
                string ma2 = dataGridViewChiTietSP.CurrentRow.Cells["MaSanPham"].Value.ToString();
                string ma1 = dataGridViewChiTietSP.CurrentRow.Cells["MaNguyenLieu"].Value.ToString();
                txtSoluongdung.Text = dataGridViewChiTietSP.CurrentRow.Cells["SoLuongDung"].Value.ToString();

                // Gán giá trị cho ComboBox
                cboMaSPChitiet.SelectedValue = ma2;
                cboNguyenlieu.SelectedValue = ma1;
                cboMaSPChitiet.Enabled = false;
                cboNguyenlieu.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            btnOpen.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTim.Enabled = false;
            ResetValues();
            txtMasanpham.Enabled = true;
            txtTensanpham.Enabled = true;
            cboDanhmuc.Enabled = true;
            txtGiaban.Enabled = false;
            txtGianhap.Enabled = false;
            txtAnh.Enabled = true;
            txtMasanpham.Focus();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMasanpham.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK);
                txtMasanpham.Focus();
                return;
            }
            if (txtTensanpham.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK);
                txtTensanpham.Focus();
                return;
            }
            
            
            if (cboDanhmuc.Text == "")
            {
                MessageBox.Show("Bạn phải chọn loại sản phẩm", "Thông báo", MessageBoxButtons.OK);
                cboDanhmuc.Focus();
                return;
            }
            if (txtAnh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ảnh", "Thông báo", MessageBoxButtons.OK);
                txtAnh.Focus();
                return;
            }
            //check khóa chính mã hàng
            sql = "SELECT MaSanPham FROM SanPham WHERE MaSanPham=N'" + txtMasanpham.Text.Trim() + "'";

            if (QuanLyCuaHangMayTinh.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasanpham.Focus();
                txtMasanpham.Text = "";
                return;
            }
            //Thêm mới
            sql = "INSERT INTO SanPham (MaSanPham, TenSanPham,MaLoai, HinhAnh, GiaBan, GiaNhap) " +
      "VALUES (N'" + txtMasanpham.Text + "', N'" + txtTensanpham.Text + "', N'" + cboDanhmuc.SelectedValue.ToString() +
      "', N'" + txtAnh.Text + "', 0, 0 )";

            QuanLyCuaHangMayTinh.Function.RunSql(sql);
            Load_DataGridViewSP();
            ResetValues();

            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "jpg(*.jpg)|*.jpg|png(*.png)|*.png|All files(*.*)|*.*\"";
            open.InitialDirectory = "D:\\LẬP TRÌNH .NET\\BTLdotnet\\Picture";
            open.FilterIndex = 1;
            open.Title = "Chọn ảnh";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtAnh.Text = open.FileName;
                picAnh.Image = Image.FromFile(txtAnh.Text);
            }

        }

        public void ResetValues1()
        {
            cboMaSPChitiet.SelectedIndex = -1; // Reset giá trị chọn
            cboNguyenlieu.SelectedIndex = -1;  // Reset giá trị chọn
            txtSoluongdung.Text = "";
        }
        private void btnThemChitiet_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            btnOpen.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues1();
            cboMaSPChitiet.Enabled = true;
            cboNguyenlieu.Enabled = true;
            txtSoluongdung.Enabled = true;
            cboMaSPChitiet.Focus();

            string sqlSanPham = "SELECT MaSanPham, TenSanPham FROM SanPham";
            QuanLyCuaHangMayTinh.Function.FillCombo(sqlSanPham, cboMaSPChitiet, "MaSanPham", "TenSanPham");
            cboMaSPChitiet.SelectedIndex = -1;

            string sqlNguyenLieu = "SELECT MaNguyenLieu, TenNguyenLieu FROM NguyenLieu";
            QuanLyCuaHangMayTinh.Function.FillCombo(sqlNguyenLieu, cboNguyenlieu, "MaNguyenLieu", "TenNguyenLieu");
            cboNguyenlieu.SelectedIndex = -1;

            cboMaSPChitiet.Enabled = true;
            cboNguyenlieu.Enabled = true;
            txtSoluongdung.Enabled = true;
            cboMaSPChitiet.Focus();
        }

        private void btnLuuChitiet_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboMaSPChitiet.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mã sản phẩm", "Thông báo", MessageBoxButtons.OK);
                cboMaSPChitiet.Focus();
                return;
            }
            if (cboNguyenlieu.Text == "")
            {
                MessageBox.Show("Bạn phải chọn sản phẩm", "Thông báo", MessageBoxButtons.OK);
                cboNguyenlieu.Focus();
                return;
            }


            if (txtSoluongdung.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng dùng", "Thông báo", MessageBoxButtons.OK);
                cboDanhmuc.Focus();
                return;
            }

            //check khóa chính mã hàng
            sql = "SELECT MaSanPham,MaNguyenLieu FROM ChiTietSanPham WHERE MaSanPham=N'" + cboMaSPChitiet.Text.Trim() + "'";

            if (QuanLyCuaHangMayTinh.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm và mã sản phẩm này này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaSPChitiet.Focus();
                cboMaSPChitiet.Text = "";
                return;
            }
            //Thêm mới
            sql = "INSERT INTO ChiTietSanPham (MaSanPham, MaNguyenLieu,SoLuongDung) " +
      "VALUES (N'" + cboMaSPChitiet.SelectedValue.ToString() + "', N'" + cboNguyenlieu.SelectedValue.ToString() + "', N'" + txtSoluongdung.Text +
      "')";

            QuanLyCuaHangMayTinh.Function.RunSql(sql);
            Load_DataGridViewSP();
            ResetValues1();

            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            string sql1= "";
            if (SanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtMasanpham.Text == "")
            {
                MessageBox.Show("Bạn phải chọn hàng để xóa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql1= "delete ChiTietSanPham where MaSanPham = N'" + txtMasanpham.Text + "'";
                sql = "delete SanPham where MaSanPham = N'" + txtMasanpham.Text + "'";
                QuanLyCuaHangMayTinh.Function.RunSqlDel(sql1);
                QuanLyCuaHangMayTinh.Function.RunSqlDel(sql);
                Load_DataGridViewSP();
                ResetValues();
            }


        }

        private void btnXoaChitiet_Click(object sender, EventArgs e)
        {
            string sql1= "";

            if (ChiTietSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (cboMaSPChitiet.Text == "")
            {
                MessageBox.Show("Bạn phải chọn hàng để xóa", "Thông báo", MessageBoxButtons.OK);
                return; 
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                sql1 = "DELETE FROM ChiTietSanPham WHERE MaNguyenLieu = (SELECT MaNguyenLieu FROM Nguyenlieu WHERE TenNguyenLieu = N'" + cboNguyenlieu.Text + "') AND MaSanPham = N'" + cboMaSPChitiet.Text + "'";
                QuanLyCuaHangMayTinh.Function.RunSqlDel(sql1);
                Load_DataGridViewChiTietSP();
                ResetValues();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            txtGianhap.Enabled = false;
            txtMasanpham.Enabled = false;

            if (SanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtMasanpham.Text == "")
            {
                MessageBox.Show("Bạn phải chọn sản phẩm để sửa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtTensanpham.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK);
                txtTensanpham.Focus();
                return;
            }
            if (txtAnh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ảnh", "Thông báo", MessageBoxButtons.OK);
                txtAnh.Focus();
                return;
            }
            sql = "UPDATE SanPham SET TenSanPham = N'" + txtTensanpham.Text + "', MaLoai = N'" + cboDanhmuc.SelectedValue.ToString() +
                "', HinhAnh = N'" + txtAnh.Text +
                "' WHERE MaSanPham = N'" + txtMasanpham.Text + "'";

            //hỏi ý kiến người dùng có muốn sửa không
            if (MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuanLyCuaHangMayTinh.Function.RunSql(sql);
                Load_DataGridViewSP();
                ResetValues();
                btnBoqua.Enabled = false;
            }
            txtGiaban.Enabled = false;
            Load_DataGridViewSP();
            ResetValues();
            
        }

        private void btnSuaChitiet_Click(object sender, EventArgs e)
        {
            if (ChiTietSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (cboMaSPChitiet.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn sản phẩm để sửa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (cboNguyenlieu.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn tên sản phẩm", "Thông báo", MessageBoxButtons.OK);
                cboNguyenlieu.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSoluongdung.Text))
            {
                MessageBox.Show("Bạn phải nhập số lượng dùng", "Thông báo", MessageBoxButtons.OK);
                txtSoluongdung.Focus();
                return;
            }

            string maSanPham = cboMaSPChitiet.SelectedValue.ToString();
            string maNguyenLieu = cboNguyenlieu.SelectedValue.ToString();
            string soLuongDung = txtSoluongdung.Text.Trim();

            
            string sql = "UPDATE ChiTietSanPham SET SoLuongDung = " + soLuongDung +
                         " WHERE MaSanPham = N'" + maSanPham + "' AND MaNguyenLieu = N'" + maNguyenLieu + "'";

            if (MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuanLyCuaHangMayTinh.Function.RunSql(sql);
                Load_DataGridViewChiTietSP();  // truyền tham số maSanPham để load lại dữ liệu
                ResetValues1(); // Reset lại các trường chi tiết
                btnBoqua.Enabled = false;
            }
            Load_DataGridViewSP();
        }


        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMasanpham.Enabled = false;
            Load_DataGridViewSP();
            Load_DataGridViewChiTietSP();

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //code nút tìm kiếm sản phẩm
            string sql;
            if (txtTim.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK);
                txtTim.Focus();
                return;
            }
            sql = "SELECT MaSanPham, TenSanPham, TenLoai, GiaBan, HinhAnh, GiaNhap FROM SanPham s join Loai l on l.MaLoai=s.MaLoai WHERE TenSanPham like N'%" + txtTim.Text + "%'";
            SanPham = QuanLyCuaHangMayTinh.Function.GetDataToTable(sql);
            //Gán dữ liệu từ bảng vào datagridview
            dataGridViewQLyCaPhe.DataSource = SanPham;
            //xóa chữ ở ô txtTim sau khi tìm xong
            txtTim.Text = "";

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoluongdung_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoluongdung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // chặn ký tự không hợp lệ
            }

            // Không cho phép nhập nhiều hơn một dấu chấm
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
