using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    /// <summary>
    /// Provides custom rendering for menu items, allowing for different check mark styles.
    /// </summary>
    /// <developer>HaiTN</developer>
    /// <version>1.0.0</version>
    /// <creationDate>15/09/2025</creationDate>
    public class CustomMenuItemRender : ToolStripProfessionalRenderer
    {
        /// <summary>
        /// Handles the rendering of the check mark on a menu item.
        /// For Check-style items use the base (default) renderer so the check matches the Settings menu (checkbox in box).
        /// For other mark types use the custom helper.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            var glyphRect = CheckMarkRendererHelper.RenderCheckMarkBox(e);
            CheckMarkRendererHelper.DrawCheckmarkGlyph(e.Graphics, glyphRect);
        }

        /// <summary>
        /// Paints the dropdown menu background in a uniform color so the gutter
        /// is visually indistinguishable from the text area.
        /// </summary>
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDownMenu)
            {
                using var brush = new SolidBrush(SystemColors.Menu);
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
            }
            else
            {
                base.OnRenderToolStripBackground(e);
            }
        }

        /// <summary>
        /// Draws horizontal separators spanning the full item width (x=0 to x=Width)
        /// instead of the default which starts after the gutter.
        /// </summary>
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if (e.Vertical) { base.OnRenderSeparator(e); return; }

            int y = e.Item.Height / 2;
            using var pen = new Pen(SystemColors.ControlDark);
            e.Graphics.DrawLine(pen, 0, y, e.Item.Width, y);
        }

        /// <summary>
        /// Handles the rendering of the background of a menu item.
        /// </summary>
        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {

        }
    }
}
