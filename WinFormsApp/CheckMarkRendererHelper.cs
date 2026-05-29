using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    /// <summary>
    /// A static helper class responsible for rendering custom check marks on menu items.
    /// This centralizes the rendering logic so it can be reused by multiple ToolStripRenderer classes.
    /// </summary>
    /// <developer>KhangLP</developer>
    /// <version>1.0.0</version>
    /// <creationDate>21/10/2025</creationDate>
    public static class CheckMarkRendererHelper
    {
        /// <summary>
        /// Draws the white sunken box background centered in the gutter and returns the inner glyph rect.
        /// Call this first, then draw the glyph on top.
        /// </summary>
        public static Rectangle RenderCheckMarkBox(ToolStripItemImageRenderEventArgs e)
        {
            var g = e.Graphics;

            int gutterCenterX = e.ImageRectangle.X + e.ImageRectangle.Width / 2;

            int boxW = Math.Min(e.Item.Height - 2, e.ImageRectangle.Width - 2);
            int boxH = e.Item.Height - 4;
            var box = new Rectangle(
                gutterCenterX - boxW / 2,
                (e.Item.Height - boxH) / 2,
                boxW, boxH);

            g.FillRectangle(Brushes.White, box);

            using (var dark = new Pen(SystemColors.ControlDark))
            using (var light = new Pen(SystemColors.ControlLight))
            {
                g.DrawLine(dark, box.Left, box.Top, box.Right - 1, box.Top);
                g.DrawLine(dark, box.Left, box.Top, box.Left, box.Bottom - 1);
                g.DrawLine(light, box.Left, box.Bottom - 1, box.Right - 1, box.Bottom - 1);
                g.DrawLine(light, box.Right - 1, box.Top, box.Right - 1, box.Bottom - 1);
            }

            // Glyph centered inside box using float for sub-pixel accuracy
            int glyphSize = Math.Min(boxW, boxH) - 2;
            int glyphX = box.X + (box.Width - glyphSize) / 2;
            int glyphY = box.Y + (box.Height - glyphSize) / 2;
            return new Rectangle(glyphX, glyphY, glyphSize, glyphSize);
        }

        /// <summary>
        /// Draws a checkmark glyph centered inside <paramref name="rect"/> using the Marlett font.
        /// This is GDI+ based and works reliably inside ToolStrip renderer overrides on themed Windows.
        /// </summary>
        public static void DrawCheckmarkGlyph(Graphics g, Rectangle rect)
        {
            // Marlett 'a' = checkmark glyph; scale font to fill the rect
            using var font = new Font("Marlett", rect.Height, GraphicsUnit.Pixel);
            using var brush = new SolidBrush(Color.Black);
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString("a", font, brush, (RectangleF)rect, sf);
        }

        /// <summary>
        /// Recursively applies a renderer to a ToolStrip and all nested sub-menu dropdowns.
        /// Use this instead of a plain <c>strip.Renderer = renderer</c> to ensure every
        /// flyout sub-menu also uses the same renderer.
        /// </summary>
        public static void ApplyRenderer(ToolStrip strip, ToolStripRenderer renderer)
        {
            strip.Renderer = renderer;
            foreach (ToolStripItem item in strip.Items)
                if (item is ToolStripMenuItem mi)
                    ApplyRendererToDropDown(mi, renderer);
        }

        private static void ApplyRendererToDropDown(ToolStripMenuItem item, ToolStripRenderer renderer)
        {
            if (item.HasDropDownItems)
            {
                item.DropDown.Renderer = renderer;
                foreach (ToolStripItem child in item.DropDownItems)
                    if (child is ToolStripMenuItem mi)
                        ApplyRendererToDropDown(mi, renderer);
            }
        }

        /// <summary>
        /// Renders a custom check mark for a given menu item based on its MarkCheck property.
        /// It delegates the actual rendering to a specific presenter obtained from a factory.
        /// </summary>
        /// <param name="e">The render event arguments containing the graphics context and item details.</param>
        public static void RenderCheckMark(ToolStripItemImageRenderEventArgs e)
        {
            if (e.Item is CustomMenuItem menuItem)
            {
                var presenter = CustomMenuItemPresenterFactory.GetPresenter(menuItem.MarkCheck);
                presenter.RenderMark(e.Graphics, e.ImageRectangle, e);
            }
            else
            {
                // Fallback to default rendering for non-custom menu items
                // Note: This block might be empty if the default renderer handles it,
                // but the call is kept for correctness.
                var defaultRenderer = new ToolStripProfessionalRenderer();
                defaultRenderer.DrawItemCheck(e);
            }
        }
    }
}
