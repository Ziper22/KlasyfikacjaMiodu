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
    /// Autor: Dawid Ferszter. <para/>
    /// Klasa odpowiedzialna za przechowywnie zakładki "Widok" w menu.
    /// </summary>
    public class TopMenuView
    {
        private ToolStripMenuItem showPanel;
        private ToolStripMenuItem centerImage;
        private SidePanel sidePanel;
        private Panel viewPanel;
        /// <summary>
        /// Konstruktor klasy. Dodaje pola do rozwijanej listy.
        /// </summary>
        /// <param name="showPanel">Pokaż listę.</param>
        /// <param name="centerImage">Wyśrodkuj zdjęcie.</param>
        /// <param name="sidePanel">Ukryj listę.</param>
        /// <param name="viewPanel"></param>
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
        /// <summary>
        /// Funkcja ustawiająca zdjęcie na środku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void CenterImageOnClick(object sender, EventArgs eventArgs)
        {
            Form form = viewPanel.FindForm();
            viewPanel.Location = new Point(form.ClientSize.Width / 2 - viewPanel.Width / 2, form.ClientSize.Height / 2 - viewPanel.Height / 2);
        }
        /// <summary>
        /// Funkcja pokazuje/ukrywa panel pyłków.
        /// </summary>
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
