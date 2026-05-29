using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    /// <summary>
    /// Defines the contract for a presenter that manages check mark functionality.
    /// </summary>
    /// <developer>KhangLP</developer>
    /// <version>1.0.0</version>
    /// <creationDate>21/10/2025</creationDate>
    public interface ICheckMarkPresenter
    {
        /// <summary>
        /// Renders the check mark icon on the specified graphics surface.
        /// </summary>
        /// <param name="g">The graphics surface to draw on.</param>
        /// <param name="rect">The bounding rectangle for the check mark.</param>
        /// <param name="e">The event arguments for the item image rendering.</param>
        void RenderMark(Graphics g, Rectangle rect, ToolStripItemImageRenderEventArgs e);
    }
}
