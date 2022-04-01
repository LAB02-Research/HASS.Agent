using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASS.Agent.Functions
{
    /// <summary>
    /// Makes sure our combobox has the right colors
    /// <para>Source: https://stackoverflow.com/a/60421006 </para>
    /// <para>Source: https://stackoverflow.com/a/11650321 </para>
    /// </summary>
    internal static class ComboBoxTheme
    {
        internal static void DrawItem(object sender, DrawItemEventArgs e)
        {
            // only relevant for listviews in detail mode
            if (sender is not ComboBox comboBox) return;

            // only if there are items
            if (comboBox.Items.Count <= 0) return;

            // fetch the index
            var index = e.Index >= 0 ? e.Index : 0;

            // draw the control's background
            e.DrawBackground();

            // check if we have an item to process
            if (index != -1)
            {
                // optionally set the item's background color as selected
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(241, 241, 241)), e.Bounds);
                }

                // draw the string
                var brush = (e.State & DrawItemState.Selected) > 0 ? new SolidBrush(Color.FromArgb(63, 63, 70)) : new SolidBrush(comboBox.ForeColor);
                e.Graphics.DrawString(comboBox.Items[index].ToString(), Variables.DefaultFont, brush, e.Bounds, StringFormat.GenericDefault);
            }

            // draw focus rectangle
            e.DrawFocusRectangle();
        }
    }
}
