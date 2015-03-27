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
                return;
            }
            else if (dialogResult == DialogResult.No)
            {
                panel1.Container.Remove(pm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
