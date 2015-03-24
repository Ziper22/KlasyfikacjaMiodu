using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.TopMenu
{
<<<<<<< HEAD
    /// <summary>
    /// Author: Dawid Ferszter. <para/>
    /// Class responsible for handling "View" menu.
    /// </summary>
=======
>>>>>>> origin/master
    public class TopMenuView
    {
        private ToolStripMenuItem showPanel;

        public TopMenuView(ToolStripMenuItem showPanel)
        {
            this.showPanel = showPanel;

            showPanel.Click += ShowPanel_Click;
        }

        void ShowPanel_Click(object sender, EventArgs e)
        {
            // pokazuje panel
        }
    }
}
