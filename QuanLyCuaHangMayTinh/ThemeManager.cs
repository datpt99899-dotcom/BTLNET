using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FontAwesome.Sharp;

namespace QuanLyCuaHangMayTinh
{
    /// <summary>
    /// Áp dụng AppTheme cho TOÀN BỘ control trong form một cách đệ quy.
    /// Cách dùng: gọi `ThemeManager.Apply(this);` trong sự kiện Load của mỗi form.
    /// </summary>
    internal static class ThemeManager
    {
        public static void Apply(Form form)
        {
            if (form == null) return;
            // Chỉ đổi BackColor form nếu Designer chưa set màu cụ thể
            if (form.BackColor == SystemColors.Control)
                form.BackColor = AppTheme.BodyBg;
            form.Font      = AppTheme.FontInput;
            // KHÔNG ép ForeColor form vì sẽ phá label trắng đã thiết kế
            ApplyRecursive(form);
        }

        private static void ApplyRecursive(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                switch (c)
                {
                    case DataGridView dgv:      StyleGrid(dgv);     break;
                    case IconButton ib:         StyleIconBtn(ib);   break;
                    case Button btn:            StyleButton(btn);   break;
                    case TextBox tb:            StyleTextBox(tb);   break;
                    case ComboBox cb:           StyleCombo(cb);     break;
                    case DateTimePicker dtp:    StyleDate(dtp);     break;
                    case Label lb:              StyleLabel(lb);     break;
                    case GroupBox gb:           StyleGroupBox(gb);  break;
                    case Panel pnl:             StylePanel(pnl);    break;
                    case TabControl tc:         StyleTab(tc);       break;
                    case Chart ch:              StyleChart(ch);     break;
                }
                if (c.HasChildren) ApplyRecursive(c);
            }
        }

        public static void StyleGrid(DataGridView dgv)
        {
            // Chỉ áp dụng style cơ bản, KHÔNG override màu nếu Designer đã thiết kế
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect   = false;
            if (dgv.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.None)
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgv.RowTemplate.Height < 25)
                dgv.RowTemplate.Height  = AppTheme.RowHeight;

            // Chỉ set màu nếu Designer chưa cấu hình header
            if (dgv.ColumnHeadersDefaultCellStyle.BackColor == SystemColors.Control ||
                dgv.ColumnHeadersDefaultCellStyle.BackColor == Color.Empty)
            {
                dgv.BackgroundColor   = AppTheme.CardBg;
                dgv.BorderStyle       = BorderStyle.None;
                dgv.GridColor         = AppTheme.GridLines;

                dgv.ColumnHeadersDefaultCellStyle.BackColor          = AppTheme.GridHeaderBg;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor          = AppTheme.GridHeaderText;
                dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppTheme.GridHeaderBg;
                dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = AppTheme.GridHeaderText;
                dgv.ColumnHeadersDefaultCellStyle.Font     = AppTheme.FontGridHead;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ColumnHeadersDefaultCellStyle.Padding  = new Padding(6, 4, 6, 4);
                dgv.ColumnHeadersHeight = 38;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                dgv.DefaultCellStyle.BackColor       = AppTheme.CardBg;
                dgv.DefaultCellStyle.ForeColor       = AppTheme.TextPrimary;
                dgv.DefaultCellStyle.SelectionBackColor = AppTheme.GridSelectionBg;
                dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                dgv.DefaultCellStyle.Font            = AppTheme.FontGridCell;
                dgv.DefaultCellStyle.Padding         = new Padding(6, 2, 6, 2);
                dgv.AlternatingRowsDefaultCellStyle.BackColor = AppTheme.GridRowAlt;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            }
        }

        public static void StyleButton(Button btn)
        {
            if (btn.Tag is string tag && tag == "no-theme") return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = AppTheme.FontButton;
            btn.Cursor = Cursors.Hand;
            if (btn.Height < AppTheme.ButtonHeight) btn.Height = AppTheme.ButtonHeight;

            // CHỈ áp dụng màu khi Designer CHƯA set màu cụ thể
            // (BackColor default của Button = Control = ARGB(240,240,240) hoặc Transparent)
            bool hasDesignerColor = btn.BackColor != SystemColors.Control &&
                                     btn.BackColor != Color.Transparent &&
                                     btn.BackColor != Color.Empty;
            if (hasDesignerColor)
            {
                // Designer đã set màu cụ thể (Tomato, Orange, SteelBlue...) → GIỮ NGUYÊN
                // Chỉ đảm bảo chữ đọc được trên nền màu
                if (btn.ForeColor == SystemColors.ControlText || btn.ForeColor == Color.Black)
                {
                    // Tính sáng/tối của nền để chọn màu chữ phù hợp
                    int brightness = (btn.BackColor.R * 299 + btn.BackColor.G * 587 + btn.BackColor.B * 114) / 1000;
                    btn.ForeColor = brightness < 130 ? Color.White : Color.Black;
                }
                return;
            }

            // Designer KHÔNG set màu → áp dụng theme dựa vào tên/text
            string n = btn.Name.ToLower();
            string t = (btn.Text ?? "").ToLower();
            if (n.Contains("luu") || n.Contains("save") || n.Contains("them") || n.Contains("add")
                || t.Contains("lưu") || t.Contains("thêm"))
            { btn.BackColor = AppTheme.Success; btn.ForeColor = Color.White; }
            else if (n.Contains("xoa") || n.Contains("delete") || n.Contains("huy") || n.Contains("cancel")
                  || t.Contains("xóa") || t.Contains("hủy"))
            { btn.BackColor = AppTheme.Danger; btn.ForeColor = Color.White; }
            else if (n.Contains("sua") || n.Contains("edit") || n.Contains("update")
                  || t.Contains("sửa") || t.Contains("cập nhật"))
            { btn.BackColor = AppTheme.Warning; btn.ForeColor = Color.White; }
            else if (n.Contains("tim") || n.Contains("search") || n.Contains("loc") || n.Contains("filter")
                  || t.Contains("tìm") || t.Contains("lọc"))
            { btn.BackColor = AppTheme.Info; btn.ForeColor = Color.White; }
            else if (n.Contains("exit") || n.Contains("close") || n.Contains("dong")
                  || t.Contains("thoát") || t.Contains("đóng"))
            { btn.BackColor = Color.Gray; btn.ForeColor = Color.White; }
            else
            { btn.BackColor = AppTheme.Primary; btn.ForeColor = Color.White; }
        }

        public static void StyleIconBtn(IconButton ib)
        {
            if (ib.Tag is string tag && tag == "no-theme") return;
            ib.FlatStyle = FlatStyle.Flat;
            ib.FlatAppearance.BorderSize = 0;
            ib.Font = AppTheme.FontButton;
            ib.Cursor = Cursors.Hand;
            ib.ForeColor = Color.White;
            if (ib.BackColor == Color.Transparent) ib.BackColor = AppTheme.Primary;
            if (ib.IconColor == Color.Black) ib.IconColor = Color.White;
        }

        public static void StyleTextBox(TextBox tb)
        {
            tb.Font = AppTheme.FontInput;
            // Chỉ đổi nếu chưa có thiết kế cụ thể
            if (tb.BackColor == SystemColors.Window || tb.BackColor == SystemColors.Control)
                tb.BackColor = AppTheme.CardBg;
            if (tb.ForeColor == SystemColors.WindowText || tb.ForeColor == SystemColors.ControlText)
                tb.ForeColor = AppTheme.TextPrimary;
        }

        public static void StyleCombo(ComboBox cb)
        {
            cb.Font = AppTheme.FontInput;
            if (cb.BackColor == SystemColors.Window || cb.BackColor == SystemColors.Control)
                cb.BackColor = AppTheme.CardBg;
            if (cb.ForeColor == SystemColors.WindowText || cb.ForeColor == SystemColors.ControlText)
                cb.ForeColor = AppTheme.TextPrimary;
        }

        public static void StyleDate(DateTimePicker dtp)
        {
            dtp.Font = AppTheme.FontInput;
            dtp.Format = DateTimePickerFormat.Short;
            dtp.CalendarTitleBackColor = AppTheme.Primary;
            dtp.CalendarTitleForeColor = Color.White;
        }

        public static void StyleLabel(Label lb)
        {
            if (lb.Tag is string tag && tag == "no-theme") return;
            if (lb.Font == null || lb.Font.Size < 8) lb.Font = AppTheme.FontLabel;
            // KHÔNG đổi ForeColor nếu label đã được thiết kế trắng (đặt trên nền xanh)
            // hoặc đã có màu cụ thể khác đen
            if (lb.ForeColor == Color.Black || lb.ForeColor == SystemColors.ControlText)
                lb.ForeColor = AppTheme.TextPrimary;
            // SystemColors.Control (trắng) → giữ nguyên vì đã được thiết kế cố ý
        }

        public static void StyleGroupBox(GroupBox gb)
        {
            gb.Font = AppTheme.FontLabelB;
            // Check nền tối
            bool darkBg = gb.BackColor == Color.RoyalBlue ||
                          gb.BackColor == Color.DarkBlue ||
                          gb.BackColor == Color.MidnightBlue ||
                          gb.BackColor == Color.Navy ||
                          gb.BackColor == Color.Black ||
                          (gb.BackColor.R < 80 && gb.BackColor.G < 80 && gb.BackColor.B < 200);

            if (darkBg)
            {
                // Nền tối: giữ nguyên + chữ tiêu đề trắng cho đọc được
                gb.ForeColor = Color.White;
            }
            else
            {
                // Nền sáng: ép chữ tiêu đề về xanh đậm
                // (kể cả khi đã set SystemColors.Control = trắng vì sẽ không đọc được)
                gb.ForeColor = AppTheme.Primary;
                if (gb.BackColor == Color.RoyalBlue || gb.BackColor == Color.DarkBlue)
                {
                    // Đã xử lý ở case darkBg trên
                }
                else
                {
                    gb.BackColor = Color.Transparent;
                }
            }
        }

        public static void StylePanel(Panel pnl)
        {
            if (pnl.Tag is string tag && tag == "no-theme") return;
            // Giữ nguyên Panel có nền xanh đậm (header / banner) đã thiết kế cố ý
            // Chỉ KHÔNG đổi BackColor nữa - để Designer quyết định
            // (cách cũ ép sang AppTheme.Primary làm hỏng tab bar / header)
        }

        public static void StyleTab(TabControl tc)
        {
            tc.Font = AppTheme.FontLabelB;
            tc.Appearance = TabAppearance.Normal;
        }

        public static void StyleChart(Chart ch)
        {
            ch.BackColor = AppTheme.CardBg;
            foreach (var area in ch.ChartAreas)
            {
                area.BackColor = AppTheme.CardBg;
                area.AxisX.LabelStyle.ForeColor = AppTheme.TextPrimary;
                area.AxisY.LabelStyle.ForeColor = AppTheme.TextPrimary;
                area.AxisX.LineColor = AppTheme.BorderColor;
                area.AxisY.LineColor = AppTheme.BorderColor;
                area.AxisX.MajorGrid.LineColor = AppTheme.GridLines;
                area.AxisY.MajorGrid.LineColor = AppTheme.GridLines;
            }
        }
    }
}
