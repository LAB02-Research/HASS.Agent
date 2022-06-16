using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HASS.Agent.Properties;

namespace HASS.Agent.Functions
{
    /// <summary>
    /// Modify ListView theme for both items and headers
    /// Sources: 
    /// https://stackoverflow.com/a/55525989
    /// https://stackoverflow.com/a/32163633/17997203
    /// https://stackoverflow.com/a/4467140/17997203
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class ListViewTheme
    {
        internal static int SB_HORZ = 0;
        internal static int SB_VERT = 1;
        internal static int SB_BOTH = 3;

        /// <summary>
        /// Hides or shows the selected scrollbar(s)
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="wBar"></param>
        /// <param name="bShow"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        internal static extern bool ShowScrollBar(IntPtr hwnd, int wBar, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)] bool bShow);
        
        private static readonly Color BackgroundColor = Color.FromArgb(63, 63, 70);
        private static readonly Color ForeColor = Color.FromArgb(241, 241, 241);
        private static readonly Color HeaderColor = Color.FromArgb(45, 45, 48);

        private static readonly List<string> IgnorableHeaders = new List<string>
        {
            "low integrity", "filler column", "action", "refresh", "hotkey enabled", "multivalue",
            "agent compatible", "satellite compatible"
        };

        internal static void DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // only relevant for listviews in detail mode
            if (sender is not ListView listView) return;
            if (listView.View == View.Details) return;

            // get variables
            var flags = GetTextAlignment(listView, 0);
            var itemColor = e.Item.ForeColor;

            // check if the item's selected
            if (e.Item.Selected)
            {
                // yep, set forecolor as background
                using (var bkgrBrush = new SolidBrush(ForeColor))
                {
                    e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
                }

                // and background as forecolor
                itemColor = BackgroundColor;
            }
            else e.DrawBackground();

            // draw the text
            TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, e.Bounds, itemColor, flags);

            // any subitems?
            if (e.Item.SubItems.Count <= 1) return;

            // yep
            var subItem = e.Item.SubItems[1];
            flags = GetTextAlignment(listView, 1);

            // draw it
            TextRenderer.DrawText(e.Graphics, subItem.Text, subItem.Font, e.Bounds, ForeColor, flags);
        }
        
        internal static void DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // only relevant for listviews
            if (sender is not ListView listView) return;

            // get variables
            var flags = GetTextAlignment(listView, e.ColumnIndex);
            var itemColor = e.Item.ForeColor;

            // check if the item's selected
            if (e.Item.Selected)
            {
                // only for full row or first column
                if (e.ColumnIndex == 0 || listView.FullRowSelect)
                {
                    // yep, set forecolor as background
                    using (var bkgrBrush = new SolidBrush(ForeColor))
                    {
                        e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
                    }

                    // and background as forecolor
                    itemColor = BackgroundColor;
                }
            }
            else e.DrawBackground();

            // draw the text
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, itemColor, flags);
        }

        internal static void DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // set the header's background
            using (var backBrush = new SolidBrush(HeaderColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }
            
            // draw the text in the right color
            if (!IgnorableHeaders.Contains(e.Header.Text))
            {
                // regular
                using var foreBrush = new SolidBrush(ForeColor);
                e.Graphics.DrawString(e.Header.Text, e.Font, foreBrush, new Rectangle(e.Bounds.X + 6, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));
            }
            else
            {
                // hidden (but written, for accessibility)
                using var foreBrush = new SolidBrush(HeaderColor);
                e.Graphics.DrawString(e.Header.Text, e.Font, foreBrush, new Rectangle(e.Bounds.X + 6, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));
            }

            // check if there's an image set
            if (string.IsNullOrEmpty(e.Header.ImageKey) || e.Header.ImageKey == "(none)" || e.Header.ImageList == null) return;

            // yep, draw it
            e.Graphics.DrawImage(e.Header.ImageList.Images[e.Header.ImageKey], new Rectangle(e.Bounds.X + 6, e.Bounds.Y + 4, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// Returns the text alignment for the provided listview column
        /// </summary>
        /// <param name="lstView"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        private static TextFormatFlags GetTextAlignment(ListView lstView, int colIndex)
        {
            var flags = (lstView.View == View.Tile)
                ? (colIndex == 0) ? TextFormatFlags.Default : TextFormatFlags.Bottom
                : TextFormatFlags.VerticalCenter;

            if (lstView.View == View.Details) flags |= TextFormatFlags.LeftAndRightPadding;
            if (lstView.Columns[colIndex].TextAlign != HorizontalAlignment.Left) flags |= (TextFormatFlags)((int)lstView.Columns[colIndex].TextAlign ^ 3);

            return flags;
        }
    }
}
