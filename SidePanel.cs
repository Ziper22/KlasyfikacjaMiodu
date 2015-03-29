using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
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
        private PollenModule chosenModule;
        public SidePanel()
        {
            InitializeComponent();
            MouseClick += PollenModule_Clicked;
            PollenModule chosenModule = null;
                       
           //FormClosing += new FormClosingEventHandler(SidePanel_FormClosing);
        }

        private void PollenModule_Clicked(object sender, EventArgs e)
        {
            chosenModule = sender as PollenModule;
        }
        
        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow();
            //addEditWindow.Show();
           // addEditWindow.OkButtonClicked += chosenModule.Add(HoneyType honeyType);


            //tylko do testów    
            panel1.Controls.Add(new PollenModule("Nowy Pyłek", Color.DarkMagenta));
            panel1.Controls.Add(new PollenModule("Nowy Pyłek", Color.DarkMagenta));
            panel1.Controls.Add(new PollenModule("Nowy Pyłek", Color.DarkMagenta));
            panel1.Controls.Add(new PollenModule("Nowy Pyłek", Color.DarkMagenta));
            panel1.Controls.Add(new PollenModule("Nowy Pyłek", Color.DarkMagenta));
        }

        private void edytujToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            HoneyTypeEditWindow addEditWindow = new HoneyTypeEditWindow();
            addEditWindow.Show();
            //addEditWindow.OkButtonClicked+=chosenModule.Edit(HoneyType);
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrany znacznik?", "Znacznik zostanie usunięty", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                panel1.Container.Remove(chosenModule);
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

        //private void SidePanel_FormClosing(object sender, EventArgs e)
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
