using System.Drawing;

namespace QuanLyCuaHangMayTinh
{
    /// <summary>
    /// Bảng màu / font / kích thước thiết kế dùng chung cho TOÀN BỘ ứng dụng.
    /// Mọi form đều gọi ThemeManager.Apply(this) trong sự kiện Load để được tô màu đồng bộ.
    /// </summary>
    internal static class AppTheme
    {
        // PALETTE
        public static readonly Color Primary       = Color.FromArgb( 30,  77, 156);
        public static readonly Color PrimaryDark   = Color.FromArgb( 20,  55, 120);
        public static readonly Color PrimaryLight  = Color.FromArgb( 70, 130, 200);
        public static readonly Color Accent        = Color.FromArgb(255, 153,   0);
        public static readonly Color Success       = Color.FromArgb( 40, 167,  69);
        public static readonly Color Warning       = Color.FromArgb(255, 193,   7);
        public static readonly Color Danger        = Color.FromArgb(220,  53,  69);
        public static readonly Color Info          = Color.FromArgb( 23, 162, 184);

        // BACKGROUNDS
        public static readonly Color SidebarBg     = Color.FromArgb( 24,  35,  61);
        public static readonly Color SidebarText   = Color.White;
        public static readonly Color SidebarHover  = Color.FromArgb( 40,  60,  95);
        public static readonly Color SidebarActive = Color.FromArgb(255, 153,   0);

        public static readonly Color HeaderBg      = Color.FromArgb( 30,  77, 156);
        public static readonly Color HeaderText    = Color.White;

        public static readonly Color BodyBg        = Color.FromArgb(245, 247, 250);
        public static readonly Color CardBg        = Color.White;
        public static readonly Color BorderColor   = Color.FromArgb(220, 225, 235);

        public static readonly Color TextPrimary   = Color.FromArgb( 33,  37,  41);
        public static readonly Color TextSecondary = Color.FromArgb(108, 117, 125);

        // GRID
        public static readonly Color GridHeaderBg    = Color.FromArgb( 30,  77, 156);
        public static readonly Color GridHeaderText  = Color.White;
        public static readonly Color GridRowAlt      = Color.FromArgb(245, 248, 252);
        public static readonly Color GridSelectionBg = Color.FromArgb(255, 153,   0);
        public static readonly Color GridLines       = Color.FromArgb(225, 230, 240);

        // FONTS
        public const string FontFamily = "Segoe UI";
        public static readonly Font FontTitle    = new Font(FontFamily, 18F, FontStyle.Bold);
        public static readonly Font FontHeading  = new Font(FontFamily, 14F, FontStyle.Bold);
        public static readonly Font FontLabel    = new Font(FontFamily, 10F, FontStyle.Regular);
        public static readonly Font FontLabelB   = new Font(FontFamily, 10F, FontStyle.Bold);
        public static readonly Font FontInput    = new Font(FontFamily, 11F, FontStyle.Regular);
        public static readonly Font FontButton   = new Font(FontFamily, 10F, FontStyle.Bold);
        public static readonly Font FontGridHead = new Font(FontFamily, 11F, FontStyle.Bold);
        public static readonly Font FontGridCell = new Font(FontFamily, 10F, FontStyle.Regular);

        // SPACING
        public const int PaddingSm  = 6;
        public const int PaddingMd  = 12;
        public const int PaddingLg  = 20;
        public const int RowHeight  = 32;
        public const int InputHeight = 32;
        public const int ButtonHeight = 36;
    }
}
