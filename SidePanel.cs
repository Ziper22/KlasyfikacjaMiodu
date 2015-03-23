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
        //powinien zawierać listę pollenModule?
        public SidePanel()
        {
            InitializeComponent();
        }

        private void dodajNowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PollenModule module = new PollenModule(0,0,new HoneyType());
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void edytujToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
