using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.TopMenu
{
    /// <summary>
    /// Author: Dawid Ferszter. <para/>
    /// Class responsible for handling "View" menu.
    /// </summary>
    public class TopMenuView
    {
        private ToolStripMenuItem showPanel;
        private SidePanel.SidePanel sidePanel;

        public TopMenuView(ToolStripMenuItem showPanel, SidePanel.SidePanel sidePanel)
        {
            this.showPanel = showPanel;
            this.sidePanel = sidePanel;

            showPanel.Click += ShowPanel_Click;
        }

        void ShowPanel_Click(object sender, EventArgs e)
        {
            sidePanel.Visible = !sidePanel.Visible;

            if (sidePanel.Visible)
                showPanel.Text = "Ukryj listę";
            else
                showPanel.Text = "Pokaż listę";
        }

    }
}
