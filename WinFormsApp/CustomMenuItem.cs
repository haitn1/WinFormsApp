using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public enum EMarkCheckIcon
    {
        None = 0,
        Check,
        Dot,
    }
    public class CustomMenuItem : ToolStripMenuItem
    {
        /// <summary>
        /// Gets or sets the type of check mark to display next to the menu item.
        /// </summary>
        public EMarkCheckIcon MarkCheck { get; set; } = EMarkCheckIcon.None;
    }
}
