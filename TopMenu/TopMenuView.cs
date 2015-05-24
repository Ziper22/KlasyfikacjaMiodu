using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlasyfikacjaMiodu.SideMenu;

namespace KlasyfikacjaMiodu.TopMenu
{
    /// <summary>
    /// Author: Dawid Ferszter. <para/>
    /// Class responsible for handling "View" menu.
    /// </summary>
    public class TopMenuView
    {
        private ToolStripMenuItem showPanel;
        private ToolStripMenuItem centerImage;
        private SidePanel sidePanel;
        private Panel viewPanel;

        public TopMenuView(ToolStripMenuItem showPanel, ToolStripMenuItem centerImage, SidePanel sidePanel, Panel viewPanel)
        {
            this.showPanel = showPanel;
            this.sidePanel = sidePanel;
            this.viewPanel = viewPanel;
            this.centerImage = centerImage;

            showPanel.Click += ShowPanel_Click;
            centerImage.Click += CenterImageOnClick;
            sidePanel.FormClosing += ShowPanel_Click;
        }

        private void CenterImageOnClick(object sender, EventArgs eventArgs)
        {
            Form form = viewPanel.FindForm();
            viewPanel.Location = new Point(form.ClientSize.Width / 2 - viewPanel.Width / 2, form.ClientSize.Height / 2 - viewPanel.Height / 2);
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
