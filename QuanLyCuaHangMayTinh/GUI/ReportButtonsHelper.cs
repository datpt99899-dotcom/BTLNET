using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.GUI
{
    /// <summary>
    /// Helper chung cho 7 nút header của 3 form báo cáo (frmBaoCaoDT, frmBaoCaoSP, frmBaoCaoDonHang).
    /// Tránh viết trùng code cho từng form.
    /// </summary>
    internal static class ReportButtonsHelper
    {
        /// <summary>Gắn handler cho 7 nút header chuẩn của các form báo cáo.</summary>
        /// <param name="currentForm">Form báo cáo hiện tại (frmBaoCaoDT/SP/DonHang)</param>
        /// <param name="dgv">DataGridView chính của form để xuất excel</param>
        /// <param name="reportTitle">Tiêu đề báo cáo (in lên file xuất)</param>
        /// <param name="reload">Hàm reload data của form (gọi khi click Làm mới)</param>
        public static void AttachHandlers(
            Form currentForm,
            Button btnTabDoanhThu,
            Button btnTabSPBanChay,
            Button btnTabDonTrangThai,
            Button btnLamMoi,
            Button btnXuatExcel,
            Button btnInBaoCao,
            Button btnThoat,
            DataGridView dgv,
            string reportTitle,
            Action reload)
        {
            if (btnTabDoanhThu != null)
                btnTabDoanhThu.Click += (s, e) => ChuyenSangBaoCao(currentForm, "doanh_thu");
            if (btnTabSPBanChay != null)
                btnTabSPBanChay.Click += (s, e) => ChuyenSangBaoCao(currentForm, "sp_ban_chay");
            if (btnTabDonTrangThai != null)
                btnTabDonTrangThai.Click += (s, e) => ChuyenSangBaoCao(currentForm, "don_trang_thai");

            if (btnLamMoi != null)
                btnLamMoi.Click += (s, e) => { try { reload?.Invoke(); } catch (Exception ex) {
                    MessageBox.Show("Lỗi làm mới: " + ex.Message); } };

            if (btnXuatExcel != null)
                btnXuatExcel.Click += (s, e) => XuatCSV(dgv, reportTitle);

            if (btnInBaoCao != null)
                btnInBaoCao.Click += (s, e) => InBaoCao(dgv, reportTitle);

            if (btnThoat != null)
                btnThoat.Click += (s, e) => currentForm.Hide();
            // Không Close() vì form đang được host trong panelContent của frmMain.
            // Hide chỉ ẩn — người dùng có thể chọn tab khác ở menu chính.
        }

        /// <summary>Chuyển sang form báo cáo khác trong cùng module.</summary>
        private static void ChuyenSangBaoCao(Form currentForm, string target)
        {
            // Vì form đang nằm trong panelContent của frmMain, không thể tự tạo form mới.
            // → Tìm frmMain (parent) và yêu cầu chuyển tab.
            Form mainForm = Application.OpenForms.Cast<Form>()
                .FirstOrDefault(f => f.GetType().Name == "frm_quanly");
            if (mainForm == null)
            {
                MessageBox.Show("Vui lòng đóng form và chọn báo cáo từ menu chính.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Dùng reflection để gọi method nội bộ của frm_quanly
            try
            {
                var method = mainForm.GetType().GetMethod("MoBaoCaoTheoTen",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.NonPublic);
                if (method != null)
                {
                    method.Invoke(mainForm, new object[] { target });
                }
                else
                {
                    MessageBox.Show("Chức năng chuyển báo cáo chưa được kết nối. Vui lòng chọn từ menu trái.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển báo cáo: " + ex.Message);
            }
        }

        /// <summary>Xuất nội dung DataGridView ra file CSV (Excel mở được).</summary>
        private static void XuatCSV(DataGridView dgv, string title)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var sfd = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = $"{title.Replace(' ', '_')}_{DateTime.Now:yyyyMMdd_HHmm}.csv"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    using (var sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        var headers = dgv.Columns.Cast<DataGridViewColumn>()
                            .Where(c => c.Visible)
                            .Select(c => "\"" + c.HeaderText.Replace("\"", "\"\"") + "\"");
                        sw.WriteLine(string.Join(",", headers));

                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var cells = dgv.Columns.Cast<DataGridViewColumn>()
                                .Where(c => c.Visible)
                                .Select(c => "\"" + (row.Cells[c.Index].Value?.ToString() ?? "").Replace("\"", "\"\"") + "\"");
                            sw.WriteLine(string.Join(",", cells));
                        }
                    }
                    MessageBox.Show("Đã xuất:\n" + sfd.FileName, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất CSV: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>In báo cáo (xuất ra file txt định dạng cho dễ in).</summary>
        private static void InBaoCao(DataGridView dgv, string title)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var sfd = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt",
                FileName = $"{title.Replace(' ', '_')}_{DateTime.Now:yyyyMMdd_HHmm}.txt"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("=================================================");
                    sb.AppendLine("  " + title.ToUpper());
                    sb.AppendLine("  Ngày in: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    sb.AppendLine("=================================================");
                    sb.AppendLine();

                    // Header
                    var visibleCols = dgv.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible).ToList();
                    foreach (var c in visibleCols)
                        sb.Append(c.HeaderText.PadRight(20));
                    sb.AppendLine();
                    sb.AppendLine(new string('-', 20 * visibleCols.Count));

                    // Data
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (var c in visibleCols)
                        {
                            string val = row.Cells[c.Index].Value?.ToString() ?? "";
                            if (val.Length > 18) val = val.Substring(0, 18);
                            sb.Append(val.PadRight(20));
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                    MessageBox.Show("Đã lưu báo cáo:\n" + sfd.FileName, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi in: " + ex.Message);
                }
            }
        }
    }
}
