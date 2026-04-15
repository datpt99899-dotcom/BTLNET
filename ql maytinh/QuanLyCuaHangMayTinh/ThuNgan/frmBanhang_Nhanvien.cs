using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using QRCoder;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh
{
    public partial class frmBanhang_Nhanvien : Form
    {
        public frmBanhang_Nhanvien()
        {
            InitializeComponent();
        }

        //mã bàn
        private string maBan = "0";

        private void frmBanhang_Nhanvien_Load(object sender, EventArgs e)
        {
            //an
            InitializeButtonStyles();
            // load
            LoadTableList(flowLayoutPanel1);
            LoadDataGridView(dbChitiethoadon, maBan);
            //tat
            grChitietban.Enabled = false;
            grBan.Enabled = false;

            txtKhachhang.Enabled = false;
            btnThem.Enabled = false; 
        }
        private void InitializeButtonStyles()
        {
            var buttonsToStyle = new[] { btnThanhvien, btnAdd };
            foreach (var button in buttonsToStyle)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }
        }
        private void LoadTableList(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            panel.AutoScroll = true;
            panel.WrapContents = true;
            panel.Dock = DockStyle.Fill;

            string sql_danhsachban = "SELECT Maban, Tinhtrang FROM dbo.Ban";
            DataTable dtTables = Function.GetDataToTable(sql_danhsachban);

            int numberOfTablesPerRow = 3;
            int panelMargin = 10; 
            int totalMargin = (numberOfTablesPerRow + 1) * panelMargin;
            int panelWidth = (625 - totalMargin) / numberOfTablesPerRow;
            int panelHeight = 150;

            foreach (DataRow row in dtTables.Rows)
            {
                string maBan = row["Maban"].ToString();
                int status = Convert.ToInt32(row["Tinhtrang"]);

                Panel tablePanel = new Panel();
                tablePanel.Width = panelWidth;
                tablePanel.Height = panelHeight;
                tablePanel.Margin = new Padding(panelMargin);
                tablePanel.BackColor = (status == 1) ? Color.MistyRose : Color.Honeydew;
                tablePanel.BorderStyle = BorderStyle.FixedSingle;
                tablePanel.Tag = maBan;

                PictureBox pic = new PictureBox();
                pic.Width = 64;
                pic.Height = 64;
                pic.Top = 10;
                pic.Left = (panelWidth - pic.Width) / 2;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Image = (status == 1) ? Properties.Resources.table_red : Properties.Resources.table_white;

                Label lblName = new Label();
                lblName.Text = "Bàn " + maBan;
                lblName.AutoSize = true;
                lblName.Top = 80;
                lblName.Left = (panelWidth - TextRenderer.MeasureText(lblName.Text, lblName.Font).Width) / 2;

                Label lblStatus = new Label();
                lblStatus.Text = (status == 1) ? "Đang sử dụng" : "Trống";
                lblStatus.AutoSize = true;
                lblStatus.Top = 105;
                lblStatus.Left = (panelWidth - TextRenderer.MeasureText(lblStatus.Text, lblStatus.Font).Width) / 2;
                lblStatus.ForeColor = (status == 1) ? Color.Red : Color.Green;

                AddClickEvent(tablePanel, maBan);
                AddClickEvent(pic, maBan);
                AddClickEvent(lblName, maBan);
                AddClickEvent(lblStatus, maBan);


                tablePanel.Controls.Add(pic);
                tablePanel.Controls.Add(lblName);
                tablePanel.Controls.Add(lblStatus);

                panel.Controls.Add(tablePanel);

            }
                //fillcombo hinh thuc
                string sql_hinhthuc = "SELECT * FROM HinhThuc";
                Function.FillCombo(sql_hinhthuc, cbHinhthuc, "MaHinhThuc", "TenHinhThuc");
                cbHinhthuc.SelectedIndex = -1;
                //fill combo danh muc
                string sql_danhmuc = "SELECT * FROM Loai";
                Function.FillCombo(sql_danhmuc, cbDanhmuc, "MaLoai", "TenLoai");
                cbDanhmuc.SelectedIndex = -1;
                //fill ban
                string sql_chuyenban = "SELECT * FROM Ban WHERE TinhTrang = 0";
                Function.FillCombo(sql_chuyenban, cbChuyenban, "MaBan", "Maban");
                string sql_gopban = "SELECT * FROM Ban WHERE TinhTrang = 1";
                Function.FillCombo(sql_gopban, cbGopban, "MaBan", "Maban");
                cbChuyenban.SelectedIndex = -1;
                cbGopban.SelectedIndex = -1;
                
        }
        private void AddClickEvent(Control control, string maBan)
        {
            control.Click += (s, e) => ShowTableDetails(maBan);
            foreach (Control child in control.Controls)
            {
                child.Click += (s, e) => ShowTableDetails(maBan);
            }
        }
        //hàm lấy mã bàn
        
        DataTable dbChitiethoadon;
        private void ShowTableDetails(string selectedMaBan)
        {
            ResetValues();
            cbThanhvien.SelectedIndex = 1;
            maBan = selectedMaBan;
            string sql_ban = "SELECT * FROM Ban WHERE Maban = '" + maBan + "'";
            DataTable dtBan = Function.GetDataToTable(sql_ban);
            //kiem tra tinh trang ban
            int status = Convert.ToInt32(dtBan.Rows[0]["Tinhtrang"]);
            if (status == 1)
            {
                numSoluong.Value = 1;
                grChitietban.Enabled = true;
                LoadDataGridView(dbChitiethoadon,maBan);
                btnSua.Enabled = true;
                btnThoat.Enabled = true;
                grChitietban.Enabled = true;
                grBan.Enabled = true;


            }
            else
            {
                grBan.Enabled = true;
                grChitietban.Enabled = false;
                LoadDataGridView(dbChitiethoadon, maBan);
                txtTongtien.Text = "";
                cbChuyenban.Text="";
                cbGopban.Text ="";
                txtMagiamgia.Text = "";
                btnThoat.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = false;
            }
            grBan.Text = "Bàn " + maBan;
            grChitietban.Text = "Chi tiết bàn " + maBan;
        }
        //Loaddatagridview
        private void LoadDataGridView(DataTable dt, string maBan)
        {
            string sql = "SELECT sp.TenSanPham,ROUND(sp.GiaBan,2) AS GiaBan ,cthdb.SoLuong,  ROUND(cthdb.ThanhTien,2) AS ThanhTien, cthdb.GhiChu,hdb.MaHoaDonBan,hdb.MaKhachHang, hdb.Hinhthuc, hdb.TongTien, sp.MaSanPham,hdb.MaKhuyenMai, sp.MaLoai, hdb.MaNhanVien  " +
             "FROM HoaDonBan hdb " +
             "LEFT JOIN ChiTietHoaDonBan cthdb ON cthdb.MaHoaDonBan = hdb.MaHoaDonBan " +
             "LEFT JOIN SanPham sp ON cthdb.MaSanPham = sp.MaSanPham " +
             "LEFT JOIN Ban b ON b.MaBan = hdb.MaBan " +
             "WHERE b.MaBan = '" + maBan + "' AND HDB.TrangThai = 0";
            dbChitiethoadon = Function.GetDataToTable(sql);
            //lay du lieu bang

            dGridChitietban.DataSource = dbChitiethoadon;
            //do dl tu bang vao datagridview
            // Đặt HeaderText cho các cột cần hiển thị
            dGridChitietban.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dGridChitietban.Columns["GiaBan"].HeaderText = "Giá bán";
            dGridChitietban.Columns["SoLuong"].HeaderText = "Số lượng";
            dGridChitietban.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dGridChitietban.Columns["GhiChu"].HeaderText = "Ghi chú";

            // Ẩn tất cả các cột khác không nằm trong danh sách trên
            foreach (DataGridViewColumn col in dGridChitietban.Columns)
            {
                if (col.Name != "TenSanPham" && col.Name != "GiaBan" &&
                    col.Name != "SoLuong" && col.Name != "ThanhTien" && col.Name != "GhiChu")
                {
                    col.Visible = false;
                }
            }
            dGridChitietban.Columns[0].Width = 200;
            dGridChitietban.Columns[1].Width = 100;
            dGridChitietban.Columns[2].Width = 50;
            dGridChitietban.Columns[3].Width = 100;
            dGridChitietban.Columns[4].Width = 150;
            dGridChitietban.AllowUserToAddRows = false;
            dGridChitietban.EditMode = DataGridViewEditMode.EditProgrammatically;
            //hien thi hoa don
            if (dbChitiethoadon.Rows.Count > 0)
            {
                string maHinhthuc = dbChitiethoadon.Rows[0]["Hinhthuc"].ToString();
                cbHinhthuc.Text = Function.GetFieldValues("SELECT TenHinhThuc FROM HinhThuc WHERE MaHinhThuc = '" + maHinhthuc + "'");
                //co  ma khach hang
                string makhachhang = dbChitiethoadon.Rows[0]["MaKhachHang"].ToString();
                if (makhachhang != "")
                {
                    cbThanhvien.SelectedIndex = 0;
                    string sql_khachhang = "SELECT TenKhachHang, SoDienThoai FROM KhachHang WHERE MaKhachHang = '" + makhachhang + "'";
                    DataTable dtKhachHang = Function.GetDataToTable(sql_khachhang);
                    txtKhachhang.Text = dtKhachHang.Rows[0]["TenKhachHang"].ToString();
                    txtSodienthoai.Text = dtKhachHang.Rows[0]["SoDienThoai"].ToString();
                }
                else
                {
                    cbThanhvien.SelectedIndex = 1;
                    txtKhachhang.Text = "";
                    txtSodienthoai.Text = "";
                }
                //hien thi tong tien
                string TongTien = dbChitiethoadon.Rows[0]["Tongtien"].ToString();
                txtTongtien.Text = TongTien;
                decimal tongTienSo;
                bool isDecimal = decimal.TryParse(TongTien, out tongTienSo);
                btnThanhtoan.Enabled = isDecimal && tongTienSo > 0;
               
                //fill ma giam gia
                string maKhuyenMai = "";

                if (dbChitiethoadon.Rows.Count > 0 && dbChitiethoadon.Rows[0]["MaKhuyenMai"] != DBNull.Value)
                {
                    maKhuyenMai = dbChitiethoadon.Rows[0]["MaKhuyenMai"].ToString();           
                    txtMagiamgia.Text = maKhuyenMai;
                    lbThonbaogiamgia.Text = "Thành công";
                    btnGiamgia.Enabled = false;
                    txtMagiamgia.Enabled = false;
                }
                else
                {
                    txtMagiamgia.Text = "";
                    lbThonbaogiamgia.Text = "";
                    btnGiamgia.Enabled = true;
                    txtMagiamgia.Enabled = true;
                }
                //cb chuyen ban va gop ban
                cbChuyenban.Text = maBan;
                cbGopban.Text = maBan;
                //an
                btnThemmon.Enabled = false;
                btnXoamon.Enabled = false;
                btnSuamon.Enabled = false;
                btnBoqua.Enabled = false;
                cbDanhmuc.Enabled = false;
                txtGhichu.Enabled = false;
                cbThucuong.Enabled = false;
                numSoluong.Enabled = false;
                txtTongtien.Enabled = false;
                XoaMaGiamGiaNeuKhongDuDieuKien(maBan);
            }
        }
        //lay hoa don moi nhat
        public static string MaHoaDonMoiNhatTheoBan(string maBan)
        {
            string sql = "SELECT TOP 1 MaHoaDonBan FROM HoaDonBan WHERE MaBan = @MaBan AND TrangThai = 0 ORDER BY NgayBan DESC";

            using (SqlConnection conn = new SqlConnection(Function.connString)) 
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        //ham retset
        private void ResetDrinkSelection()
        {
            cbDanhmuc.SelectedIndex = -1;
            cbThucuong.SelectedIndex = -1;
            numSoluong.Value = 1;
            txtGhichu.Text = "";
        }

        private void ResetValues()
        {
            txtKhachhang.Text = "";
            txtSodienthoai.Text = "";
            txtMagiamgia.Text = "";
            txtTongtien.Text = "";
            cbHinhthuc.SelectedIndex = -1;
            cbDanhmuc.SelectedIndex = -1;
            cbThucuong.SelectedIndex = -1;
            btnThem.Enabled = false;

        }

        private void txMagiamgia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //thêm mới hóa đơn
            //kiểm tra trống
            if (cbThanhvien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập chọn loại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMagiamgia.Focus();
                return;
            }
            if(cbHinhthuc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hình thức sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbHinhthuc.Focus();
                return;
            }
            string maKhachHang = "";
            string sql_themhoadon = "";

            if (cbThanhvien.SelectedIndex == 0)
            {
                // Thành viên
                string sql_makhachhang = "SELECT MaKhachHang FROM KhachHang WHERE SoDienThoai = '" + txtSodienthoai.Text + "'";
                maKhachHang = Function.GetFieldValues(sql_makhachhang);

                if (string.IsNullOrEmpty(maKhachHang))
                {
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.");
                    return;
                }

                sql_themhoadon = "INSERT INTO HoaDonBan (MaBan,MaNhanVien, Hinhthuc, MaKhachHang, NgayBan) " +
                                 "VALUES ('" + maBan + "','NV01', '" + cbHinhthuc.SelectedValue + "', N'" + maKhachHang + "', GETDATE())";
            }
            else
            {
                // Khách lẻ
                sql_themhoadon = "INSERT INTO HoaDonBan (MaBan,MaNhanVien, Hinhthuc, NgayBan) " +
                                 "VALUES ('" + maBan + "','NV01', '" + cbHinhthuc.SelectedValue + "', GETDATE())";
            }

            // Xác nhận trước khi thêm
            DialogResult result = MessageBox.Show("Bạn có muốn thêm hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Function.RunSql(sql_themhoadon);
            }
            grChitietban.Enabled = true;
            LoadTableList(flowLayoutPanel1);
            LoadDataGridView(dbChitiethoadon, maBan);
            btnThem.Enabled = false;
            btnThoat.Enabled = true;
            btnSua.Enabled = true;

        }

        private void cbThanhvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThanhvien.SelectedIndex == 0)
            {

                txtSodienthoai.Enabled = true;
                btnThanhvien.Enabled = true;
            }
            else
            {
                txtSodienthoai.Text = "";
                txtKhachhang.Text = "";
                btnThanhvien.Enabled = false;
                txtSodienthoai.Enabled = false;
            }

        }

        private void btnThanhvien_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSodienthoai.Text))
            {
                string sql_khachhang = "SELECT TenKhachHang FROM KhachHang WHERE SoDienThoai = N'" + txtSodienthoai.Text + "'";
                string tenKhachHang = Function.GetFieldValues(sql_khachhang);
                //hien thong bao
                txtKhachhang.Text = tenKhachHang ?? "";
            }
            else
            {
                txtKhachhang.Text = "";
            }
        }

        private void cbDanhmuc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbDanhmuc.SelectedIndex >= 0 && cbDanhmuc.SelectedValue != null)
            {
                string maLoai = cbDanhmuc.SelectedValue.ToString();
                string sql_sanpham = "SELECT * FROM SanPham WHERE MaLoai = '" + maLoai + "'";
                Function.FillCombo(sql_sanpham, cbThucuong, "MaSanPham", "TenSanPham");
                cbThucuong.SelectedIndex = -1;
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetDrinkSelection();
        }

        private void btnThemmon_Click(object sender, EventArgs e)
        {
            
            
            //kiem tra rỗng
            if (cbThucuong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thức uống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbThucuong.Focus();
                return;
            }
            if (numSoluong.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoluong.Focus();
                return;
            }
            //nếu có món đấy r thì tăng số lượng lên
            //lay ma hoa don
            string maHoaDon = MaHoaDonMoiNhatTheoBan(maBan);
            string sql_check = "SELECT * FROM ChiTietHoaDonBan WHERE MaSanPham = '" + cbThucuong.SelectedValue + "' AND MaHoaDonBan =  '" + maHoaDon + "'";
            if(Function.CheckKey(sql_check))
            {
                string sql_update = "UPDATE ChiTietHoaDonBan SET SoLuong = SoLuong + " + numSoluong.Value + " WHERE MaSanPham = '" + cbThucuong.SelectedValue + "' AND MaHoaDonBan =  '" + maHoaDon + "'";
                Function.RunSql(sql_update);
                LoadDataGridView(dbChitiethoadon, maBan);
                //reset
                ResetDrinkSelection();
                return;
            }
            //them mon 
            //lay ma hoa don
            maHoaDon = MaHoaDonMoiNhatTheoBan(maBan);
            string sql_chitiethoadon = "INSERT INTO ChiTietHoaDonBan (MaHoaDonBan, MaSanPham, SoLuong, GhiChu) " +
                 "VALUES (" + maHoaDon + ", '" + cbThucuong.SelectedValue + "', " + numSoluong.Value + ", N'" + txtGhichu.Text.Replace("'", "''") + "')";

            //thong bao
            DialogResult result = MessageBox.Show("Bạn có muốn thêm món không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Function.RunSql(sql_chitiethoadon);
                LoadDataGridView(dbChitiethoadon, maBan);
                //load lai ban
                //reset
                ResetDrinkSelection();
            }
            btnThemmon.Enabled = false;

        }

        private void dGridChitietban_Click(object sender, EventArgs e)
        {
            
            if(btnAdd.Enabled == false)
            {
                MessageBox.Show("Đang trong chế độ chọn món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }  
            string TenSanPham = dGridChitietban.CurrentRow.Cells["TenSanPham"].Value.ToString();
            if (TenSanPham == "")
            {
                MessageBox.Show("Không có món nào trong hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
              
                int index = cbThucuong.FindStringExact(TenSanPham);
                //hien thi thuc uong
                cbThucuong.SelectedIndex = index;
                string MaLoai = dGridChitietban.CurrentRow.Cells["MaLoai"].Value.ToString();
                string sql_danhmuc = "SELECT TenLoai FROM Loai WHERE MaLoai = '" + MaLoai  + "'";
                string tenLoai = Function.GetFieldValues(sql_danhmuc);
                int index2 = cbDanhmuc.FindStringExact(tenLoai);
                //hien thi danh muc
                cbDanhmuc.SelectedIndex = index2;
                //hien thi so luong               
                numSoluong.Value = Convert.ToInt32(dGridChitietban.CurrentRow.Cells["SoLuong"].Value);
                //hien thi ghi chu
                txtGhichu.Text = dGridChitietban.CurrentRow.Cells["GhiChu"].Value.ToString();
           
            //hoa don
            btnThemmon.Enabled = false;
            btnXoamon.Enabled = true;
            btnAdd.Enabled = true;
            btnSuamon.Enabled = true;
            btnBoqua.Enabled = false;
            //chi tiet hoa don
            cbDanhmuc.Enabled = true;
            cbThucuong.Enabled = true;
            numSoluong.Enabled = true;
            txtGhichu.Enabled = true;
        }

        private void btnSuamon_Click(object sender, EventArgs e)
        {
            
            if (dGridChitietban.CurrentRow != null)
            {
                string maSanPham = dGridChitietban.CurrentRow.Cells["MaSanPham"].Value.ToString();
                string maHoaDon = dGridChitietban.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();
                //kiem tra rong
                if (numSoluong.Value == 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numSoluong.Focus();
                    return;
                }
                if (cbThucuong.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numSoluong.Focus();
                    return;
                }

                //update
                string ghiChu = txtGhichu.Text.Replace("'", "''"); 
                string sql_sua = "UPDATE ChiTietHoaDonBan SET " +
                             "MaSanPham = '" + cbThucuong.SelectedValue + "', " +
                             "SoLuong = " + numSoluong.Value + ", " +
                             "GhiChu = N'" + ghiChu + "' " +
                             "WHERE MaSanPham = '" + maSanPham + "' AND MaHoaDonBan = " + maHoaDon + ";";
                //thong bao
                DialogResult result = MessageBox.Show("Bạn có muốn sửa món không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Function.RunSql(sql_sua);
                    LoadDataGridView(dbChitiethoadon, maBan);
                    //reset
                    ResetDrinkSelection();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetDrinkSelection();
            cbDanhmuc.Enabled = true;
            cbThucuong.Enabled = true;
            numSoluong.Enabled = true;
            txtGhichu.Enabled = true;
            btnThemmon.Enabled = true;
            btnXoamon.Enabled = false;
            btnSuamon.Enabled = false;
            btnBoqua.Enabled = true;

        }
        private void btnXoamon_Click(object sender, EventArgs e)
        {
            string sql;
            if(dGridChitietban.Rows.Count == 0)
            {
                MessageBox.Show("Không có món nào trong hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(cbDanhmuc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbDanhmuc.Focus();
                return;
            }

            if (dGridChitietban.CurrentRow != null)
            {
                string maSanPham = dGridChitietban.CurrentRow.Cells["MaSanPham"].Value.ToString();
                string maHoaDon = dGridChitietban.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();
                //delete
                sql = "DELETE FROM ChiTietHoaDonBan WHERE MaSanPham = '" + maSanPham + "' AND MaHoaDonBan = '" + maHoaDon + "'";
                //thong bao
                DialogResult result = MessageBox.Show("Bạn có muốn xóa món không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Function.RunSqlDel(sql);
                    LoadDataGridView(dbChitiethoadon, maBan);
                    //reset
                    ResetDrinkSelection();
                }
            }
        }

        private void btnChuyenban_Click(object sender, EventArgs e)
        {
            string maChuyenban = cbChuyenban.SelectedValue.ToString();
            string maHoaDon = dGridChitietban.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();
            //thong bao
            DialogResult result = MessageBox.Show("Bạn có muốn chuyển bàn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            //chuyen ban
            string sql_chuyenban = "UPDATE HoaDonBan SET MaBan = '" + maChuyenban + "' WHERE MaHoaDonBan = '" + maHoaDon + "'";
            Function.RunSql(sql_chuyenban);
            //cap nhat ban  
            string sql_updateban = "UPDATE Ban SET TinhTrang = 1 WHERE MaBan = '" + maChuyenban + "'";
            Function.RunSql(sql_updateban);
            //cap nhat ban cu
            string sql_updatebancu = "UPDATE Ban SET TinhTrang = 0 WHERE MaBan = '" + maBan + "'";
            Function.RunSql(sql_updatebancu);
            //THONG BAO 
            MessageBox.Show("Chuyển bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //load lai ban
            LoadTableList(flowLayoutPanel1);
            grChitietban.Enabled = false;
            ResetValues();
            cbThanhvien.SelectedIndex = 1;
            LoadDataGridView(dbChitiethoadon, maBan);

        }

        private void btnGopban_Click(object sender, EventArgs e)
        {
            string maBanGop = cbGopban.SelectedValue.ToString();
            string maHoaDonCanGop = dGridChitietban.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();

            DialogResult result = MessageBox.Show("Bạn có muốn gộp bàn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }


            // Lấy mã hóa đơn bàn cần gộp vào
            string maHoaDonGop = Function.GetFieldValues("SELECT MaHoaDonBan FROM HoaDonBan WHERE MaBan = '" + maBanGop + "' AND TrangThai = 0");

            if (string.IsNullOrEmpty(maHoaDonGop))
            {
                MessageBox.Show("Không tìm thấy hóa đơn của bàn cần gộp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật chi tiết hóa đơn chuyển sang hóa đơn gộp
            string sql_Gopban = $@"
                UPDATE ChiTietHoaDonBan 
                SET MaHoaDonBan = '{maHoaDonGop}' 
                WHERE MaHoaDonBan = '{maHoaDonCanGop}'";
            string sql_xoaHD = $"DELETE FROM HoaDonBan WHERE MaHoaDonBan = '{maHoaDonCanGop}'";
            string sql_updateban = $"UPDATE Ban SET TinhTrang = 0 WHERE MaBan = '{maBan}'";

            // Thực thi lần lượt
            Function.RunSql(sql_Gopban);
            Function.RunSql(sql_xoaHD);
            Function.RunSql(sql_updateban);
            MessageBox.Show("Gộp bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadTableList(flowLayoutPanel1);
            LoadDataGridView(dbChitiethoadon, maBanGop);
            grChitietban.Enabled = false;
        }


        private void btnGiamgia_Click(object sender, EventArgs e)
        {

            // Hỏi người dùng xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn áp dụng mã giảm giá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            ApDungMaGiamGia(maBan);


        }
        private void ApDungMaGiamGia(string maBan)
        {
            string magiamgia = txtMagiamgia.Text.Trim();

            // Kiểm tra tồn tại mã giảm giá
            string sqlKhuyenmai = "SELECT * FROM KhuyenMai WHERE MaKhuyenMai = '" + magiamgia + "'";
            DataTable tbKhuyenmai = Function.GetDataToTable(sqlKhuyenmai);
            if (tbKhuyenmai.Rows.Count == 0)
            {
                lbThonbaogiamgia.Text = "Lỗi!";
                txtMagiamgia.Focus();
                return;
            }

            // Kiểm tra ngày áp dụng
            DateTime ngayHienTai = DateTime.Now;
            DateTime ngayBatDau = Convert.ToDateTime(tbKhuyenmai.Rows[0]["NgayBatDau"]);
            DateTime ngayKetThuc = Convert.ToDateTime(tbKhuyenmai.Rows[0]["NgayKetThuc"]);

            if (ngayHienTai < ngayBatDau)
            {
                lbThonbaogiamgia.Text = "Chưa được áp dụng!";
                txtMagiamgia.Focus();
                return;
            }

            if (ngayHienTai > ngayKetThuc)
            {
                lbThonbaogiamgia.Text = "Đã hết hạn!";
                txtMagiamgia.Focus();
                return;
            }

            // Lấy mã hóa đơn mới nhất theo bàn
            string maHoaDon = MaHoaDonMoiNhatTheoBan(maBan);

            // Kiểm tra điều kiện tổng tiền
            string sql_tonghoadon = "SELECT TongTien FROM HoaDonBan WHERE MaHoaDonBan = '" + maHoaDon + "'";
            decimal tongHoaDon = Convert.ToDecimal(Function.GetFieldValues(sql_tonghoadon));
            decimal dieuKien = Convert.ToDecimal(tbKhuyenmai.Rows[0]["DieuKien"]);

            if (tongHoaDon < dieuKien)
            {
                lbThonbaogiamgia.Text = "Không đủ đk!";
                txtMagiamgia.Focus();
                return;
            }
            // Áp dụng mã giảm giá
            string sql = "UPDATE HoaDonBan SET MaKhuyenMai = '" + magiamgia + "' WHERE MaHoaDonBan = '" + maHoaDon + "'";
            Function.RunSql(sql);

            // Cập nhật giao diện
            LoadDataGridView(dbChitiethoadon, maBan);
            lbThonbaogiamgia.Text = "Thành công!";
            txtMagiamgia.Enabled = false;
            btnGiamgia.Enabled = false;
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hóa đơn nào không
            if (dbChitiethoadon.Rows.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //thong bao
            DialogResult result = MessageBox.Show("Bạn có muốn thanh toán không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintHoaDon);
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();

            //Hien pdf thanh toan
            string maHoaDon = MaHoaDonMoiNhatTheoBan(maBan);
            string sql = "SELECT * FROM HoaDonBan WHERE MaHoaDonBan = '" + maHoaDon + "'";
            DataTable dt = Function.GetDataToTable(sql);
            if (dt != null)
            {
                // Cập nhật trạng thái hóa đơn
                string sql_updatehoadon = "UPDATE HoaDonBan SET TrangThai = 1 WHERE MaHoaDonBan = '" + maHoaDon + "'";
                Function.RunSql(sql_updatehoadon);
                // Cập nhật trạng thái bàn
                string sql_updateban = "UPDATE Ban SET TinhTrang = 0 WHERE MaBan = '" + maBan + "'";
                Function.RunSql(sql_updateban);
                // Cập nhật trạng thái bàn
                string sql_updateban2 = "UPDATE Ban SET TinhTrang = 0 WHERE MaBan = '" + maBan + "'";
                Function.RunSql(sql_updateban2);
                // Cập nhật thành viên
                string maKhachHang = dt.Rows[0]["MaKhachHang"].ToString();
                if (maKhachHang != null)
                {
                    string sql_updatekhachhang = "UPDATE KhachHang SET DiemTichLuy = '" + Convert.ToDecimal(txtTongtien.Text) + "' WHERE MaKhachHang = '" + dt.Rows[0]["MaKhachHang"] + "'";
                    Function.RunSql(sql_updatekhachhang);
                }
                // Thong bao
                MessageBox.Show("Đã xác nhận thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Load lại danh sách bàn
                LoadTableList(flowLayoutPanel1);
                LoadDataGridView(dbChitiethoadon, maBan);
                // Reset các trường
                ResetValues();
                cbThanhvien.SelectedIndex = 1;
                btnThem.Enabled = false;
                btnThoat.Enabled = false;
                btnThanhtoan.Enabled = false;
            }
         }
        //in hoa don
        private void PrintHoaDon(object sender, PrintPageEventArgs e)
        {

            Graphics g = e.Graphics;
            Font font = new Font("Times New Roman", 12, FontStyle.Regular);
            Font fontBold = new Font("Times New Roman", 12, FontStyle.Bold);
            float y = 20;
            float leftMargin = 20;
            float contentWidth = 520;
            //lay ma nhan vien
            string maNhanvien = ""; 
            maNhanvien = dbChitiethoadon.Rows[0]["MaNhanVien"].ToString();



            // Header
            g.DrawString("HOÁ ĐƠN THANH TOÁN", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, leftMargin, y); y += 32;
            g.DrawString($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}", font, Brushes.Black, leftMargin, y); y += 22;
            g.DrawString($"Mã hóa đơn: {MaHoaDonMoiNhatTheoBan(maBan)}", font, Brushes.Black, leftMargin, y); y += 22;
            g.DrawString($"Nhân viên: {maNhanvien}", font, Brushes.Black, leftMargin, y); y += 26;
            //add hình quán vào bên phải
            Image img = Properties.Resources.logo;
            g.DrawImage(img, leftMargin + 450, 20, 80, 80);

            // Separator
            g.DrawLine(Pens.Black, leftMargin, y, leftMargin + contentWidth, y); y += 8;

            // Table headers
            g.DrawString("TT", fontBold, Brushes.Black, leftMargin, y);
            g.DrawString("Tên món", fontBold, Brushes.Black, leftMargin + 40, y);
            g.DrawString("SL", fontBold, Brushes.Black, leftMargin + 220, y);
            g.DrawString("Đơn giá", fontBold, Brushes.Black, leftMargin + 270, y);
            g.DrawString("Thành tiền", fontBold, Brushes.Black, leftMargin + 350, y); y += 22;

            // Items
            decimal tongTien = 0;
            for (int i = 0; i < dbChitiethoadon.Rows.Count; i++)
            {
                var row = dbChitiethoadon.Rows[i];
                string tenMon = row["TenSanPham"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["GiaBan"]);
                decimal thanhTien = Convert.ToDecimal(row["ThanhTien"]);
                tongTien += thanhTien;

                g.DrawString((i + 1).ToString(), font, Brushes.Black, leftMargin, y);
                g.DrawString(tenMon, font, Brushes.Black, leftMargin + 40, y);
                g.DrawString(soLuong.ToString(), font, Brushes.Black, leftMargin + 220, y);
                g.DrawString(donGia.ToString("N0"), font, Brushes.Black, leftMargin + 270, y);
                g.DrawString(thanhTien.ToString("N0"), font, Brushes.Black, leftMargin + 380, y);
                y += 20;
            }

            y += 8;
            g.DrawLine(Pens.Black, leftMargin, y, leftMargin + contentWidth, y); y += 8;

            // Subtotal
            g.DrawString("Tạm tính:", font, Brushes.Black, leftMargin + 100, y);
            g.DrawString(tongTien.ToString("N0") + " đ", font, Brushes.Black, leftMargin + 380, y); y += 22;

            // Discount (if any)
            string maKhuyenMai = dbChitiethoadon.Rows[0]["MaKhuyenMai"].ToString();
            if (!string.IsNullOrEmpty(maKhuyenMai))
            {
                string sqlKhuyenMai = "SELECT MucKhuyenMai FROM KhuyenMai WHERE MaKhuyenMai = '" + maKhuyenMai + "'";
                DataTable dtKhuyenMai = Function.GetDataToTable(sqlKhuyenMai);
                decimal giamGia = 0;

                if (dtKhuyenMai.Rows.Count > 0)
                {
                    giamGia = Convert.ToDecimal(dtKhuyenMai.Rows[0]["MucKhuyenMai"]) * Convert.ToDecimal(tongTien);
                    g.DrawString("Giảm giá:", font, Brushes.Black, leftMargin + 100, y);
                    g.DrawString(giamGia.ToString("N0") + " đ", font, Brushes.Black, leftMargin + 380, y); y += 22;
                }
                else
                {
                    g.DrawString("Giảm giá:", font, Brushes.Black, leftMargin + 100, y);
                    g.DrawString(giamGia.ToString("N0") + " đ", font, Brushes.Black, leftMargin + 380, y); y += 22;
                }
                }  
            // Final total (No discount for now)
            g.DrawString("TỔNG CỘNG:", fontBold, Brushes.Black, leftMargin + 100, y);
            g.DrawString(Convert.ToDecimal(txtTongtien.Text).ToString("N0") + " đ", fontBold, Brushes.Black, leftMargin + 380, y); y += 32;

            // QR Code
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://forms.gle/C5MN5sJuHvTUu8MZ6", QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrImage = qrCode.GetGraphic(6);
                    g.DrawImage(qrImage, leftMargin + 40, y, 100, 100);
                }
            }

            // Bank info
            g.DrawString("Hãy cảm nhận cửa hàng máy tính qua link bên cạnh nha ><", font, Brushes.Black, leftMargin + 160, y + 20);
            g.DrawString("NEST COFFEE - COFFEE SHOP", fontBold, Brushes.Black, leftMargin + 160, y + 42);
            g.DrawString("Cảm ơn quý khách!", font, Brushes.Black, leftMargin + 160, y + 64);


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //thong bao
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            //cap nhat ban va hoa don ban
            
            //xoa chi tiet ban
            string sql_xoachitietban = "DELETE FROM ChiTietHoaDonBan WHERE MaHoaDonBan = '" + MaHoaDonMoiNhatTheoBan(maBan) + "'";
            Function.RunSql(sql_xoachitietban);
            //xoa hoa don ban
            string sql_xoaban = "DELETE FROM HoaDonBan WHERE MaHoaDonBan = '" + MaHoaDonMoiNhatTheoBan(maBan) + "'";
            Function.RunSql(sql_xoaban);
            string sql_updateban = "UPDATE Ban SET TinhTrang = 0 WHERE MaBan = '" + maBan + "'";
            Function.RunSql(sql_updateban);
            //load lai ban
            LoadTableList(flowLayoutPanel1);
            LoadDataGridView(dbChitiethoadon, maBan);
            //reset
            btnThoat.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            cbThanhvien.SelectedIndex = 1;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            //cap nhat 
            
            string maKhachHang = null;
            string sql_updatehoadon = "";

            if (cbThanhvien.SelectedIndex == 0)
            {
                // Thành viên
                string sql_makhachhang = "SELECT MaKhachHang FROM KhachHang WHERE SoDienThoai = '" + txtSodienthoai.Text + "'";
                maKhachHang = Function.GetFieldValues(sql_makhachhang);

                if (string.IsNullOrEmpty(maKhachHang))
                {
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.");
                    return;
                }
               sql_updatehoadon = "UPDATE HoaDonBan SET " +
                                         "Hinhthuc = '" + cbHinhthuc.SelectedValue + "', " +
                                         "MaKhachHang = N'" + maKhachHang + "' " +                                        
                                         " WHERE MaHoaDonBan = " + MaHoaDonMoiNhatTheoBan(maBan);
            }
            else
            {
                // Khách lẻ
                sql_updatehoadon = "UPDATE HoaDonBan SET " +
                                         "Hinhthuc = '" + cbHinhthuc.SelectedValue + "', " +
                                         "MaKhachHang = N'" + maKhachHang + "' " +
                                         " WHERE MaHoaDonBan = " + MaHoaDonMoiNhatTheoBan(maBan);
            }

            // Xác nhận trước khi thêm
            DialogResult result = MessageBox.Show("Bạn có muốn sửa hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Function.RunSql(sql_updatehoadon);
            }
            grChitietban.Enabled = true;
            LoadTableList(flowLayoutPanel1);
            LoadDataGridView(dbChitiethoadon, maBan);

            btnThem.Enabled = false;
            btnThoat.Enabled = true;
        }

        private void dGridChitietban_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void XoaMaGiamGiaNeuKhongDuDieuKien(string maBan)
        {
            string maHoaDon = MaHoaDonMoiNhatTheoBan(maBan);

            // Lấy mã giảm giá hiện tại (nếu có)
            string sqlCheck = "SELECT MaKhuyenMai, TongTien FROM HoaDonBan WHERE MaHoaDonBan = '" + maHoaDon + "'";
            DataTable dt = Function.GetDataToTable(sqlCheck);

            if (dt.Rows.Count == 0 || dt.Rows[0]["MaKhuyenMai"] == DBNull.Value)
                return; // Không có hóa đơn hoặc không có mã giảm giá

            string maKhuyenMai = dt.Rows[0]["MaKhuyenMai"].ToString();
            decimal tongTien = Convert.ToDecimal(dt.Rows[0]["TongTien"]);

            // Lấy điều kiện áp dụng của mã giảm giá
            string sqlKhuyenMai = "SELECT DieuKien FROM KhuyenMai WHERE MaKhuyenMai = '" + maKhuyenMai + "'";
            object objDieuKien = Function.GetFieldValues(sqlKhuyenMai);

            if (objDieuKien == null) return;

            decimal dieuKien = Convert.ToDecimal(objDieuKien);

            if (tongTien < dieuKien)
            {
                // Xoá mã giảm giá khỏi hóa đơn
                string sqlXoa = "UPDATE HoaDonBan SET MaKhuyenMai = NULL WHERE MaHoaDonBan = '" + maHoaDon + "'";
                Function.RunSql(sqlXoa);

                // Cập nhật giao diện
                lbThonbaogiamgia.Text = "Mã giảm giá đã bị xoá (không đủ điều kiện)";
                txtMagiamgia.Text = "";
                txtMagiamgia.Enabled = true;
                btnGiamgia.Enabled = true;
            }
        }

    }
}

