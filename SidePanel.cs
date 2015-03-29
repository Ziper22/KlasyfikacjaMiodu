using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Author: Agata Hammermeister<para/>
    /// </summary>
    public partial class SidePanel : Form
    {
        public SidePanel()
        {
            InitializeComponent();
            //FormClosingEventHandler += SidePanel_FormClosing;
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddEditWindow addEditWindow = new AddEditWindow();
            //addEditWindow.Show();

            //tylko do testów    
            panel1.Controls.Add(new PollenModule("Nowy Pyłek", Color.DarkMagenta));
            panel1.Controls.Add(new PollenModule("Nowy Pyłek", Color.DarkMagenta));
            panel1.Controls.Add(new PollenModule("Nowy Pyłek", Color.DarkMagenta));
            panel1.Controls.Add(new PollenModule("Nowy Pyłek", Color.DarkMagenta));
            panel1.Controls.Add(new PollenModule("Nowy Pyłek", Color.DarkMagenta));
        }

        private void edytujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //wybór pollenmodule do edycji
            //pm - wybrany
            PollenModule pm = new PollenModule(); //tylko do testów
            pm.Edit();
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///???????????
            PollenModule pm = new PollenModule(); //tylko do testów
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrany znacznik?", "Znacznik zostanie usunięty", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                panel1.Container.Remove(pm);
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void pionowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.TopDown;
        }

        private void poziomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.FlowDirection = FlowDirection.LeftToRight;
        }
        //private void SidePanel_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    this.Hide();
        //    e.Cancel = true; // this cancels the close event
        //}
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
   }
}
