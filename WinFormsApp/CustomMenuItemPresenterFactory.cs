using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
  
   /// <summary>
   /// A factory for creating check mark presenters based on the specified icon type.
   /// This file defines presenters for rendering custom check marks in menu items.
   /// </summary>
   /// <developer> HaiTN </developer>
   /// <version> 1.0.0 </version>
   /// <creationDate> 18/09/2025 </creationDate>
    public static class CustomMenuItemPresenterFactory
    {
        /// <summary>
        /// Gets the appropriate check mark presenter for the given icon type.
        /// </summary>
        /// <param name="type">The type of check mark icon to use.</param>
        /// <returns>An instance of a class that implements ICheckMarkPresenter.</returns>
        public static ICheckMarkPresenter GetPresenter(EMarkCheckIcon type)
        {
            return type switch
            {
                EMarkCheckIcon.Dot => new DotCheckPresenter(),
                EMarkCheckIcon.Check => new TickCheckPresenter(),
                _ => new DefaultCheckPresenter()
            };
        }
    }

    /// <summary>
    /// A presenter that renders the default check mark.
    /// </summary>
    public class DefaultCheckPresenter : ICheckMarkPresenter
    {
        /// <summary>
        /// Renders the default check mark.
        /// </summary>
        /// <param name="g">The Graphics object to draw on.</param>
        /// <param name="rect">The rectangle in which to draw the check mark.</param>
        /// <param name="e">The event arguments.</param>
        public void RenderMark(Graphics g, Rectangle rect, ToolStripItemImageRenderEventArgs e)
        {
            // WHY: This method is intentionally left empty to allow the default check mark to be rendered.
        }
    }

    /// <summary>
    /// A presenter that renders a dot as the check mark.
    /// </summary>
    public class DotCheckPresenter : ICheckMarkPresenter
    {
        /// <summary>
        /// Renders a dot as the check mark.
        /// </summary>
        /// <param name="g">The Graphics object to draw on.</param>
        /// <param name="rect">The rectangle in which to draw the check mark.</param>
        /// <param name="e">The event arguments.</param>
        public void RenderMark(Graphics g, Rectangle rect, ToolStripItemImageRenderEventArgs e)
        {
            int d = 4;
            int x = (rect.X + rect.Width) / 2 - d / 2;
            int y = (rect.Y + rect.Height) / 2 - d / 2;
            using (Brush b = new SolidBrush(Color.Black))
            {
                g.FillEllipse(b, x, y, d, d);
            }
        }
    }

    /// <summary>
    /// A presenter that renders a tick as the check mark.
    /// </summary>
    public class TickCheckPresenter : ICheckMarkPresenter
    {
        /// <summary>
        /// Renders a tick as the check mark.
        /// </summary>
        /// <param name="g">The Graphics object to draw on.</param>
        /// <param name="rect">The rectangle in which to draw the check mark.</param>
        /// <param name="e">The event arguments.</param>
        public void RenderMark(Graphics g, Rectangle rect, ToolStripItemImageRenderEventArgs e)
        {
            if (e.Image != null)
            {
                Rectangle r = new Rectangle(rect.X + 2, rect.Y + 4, rect.Width - 8, rect.Height - 8);
                g.DrawImage(e.Image, r);
            }
            else
            {
                using (var pen = new Pen(Color.Black, 2))
                {
                    Point p1 = new Point(rect.Left, rect.Bottom - 4);
                    Point p2 = new Point(rect.Left + 5, rect.Bottom);
                    Point p3 = new Point(rect.Right, rect.Top);
                    g.DrawLines(pen, new[] { p1, p2, p3 });
                }
            }
        }
    }

}
