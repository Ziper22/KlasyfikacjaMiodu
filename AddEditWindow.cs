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
    /// Author: Marek Borski<para/>
    /// </summary>
    /// 
    public partial class AddEditWindow : Form
    {
        public Color Color { get; set; }
        new public string Name { get; set; }
        public string Description { get; set; }
        private Color color;

        public AddEditWindow()
        {
            InitializeComponent();
            Name = null;
        }

        private void chooseColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                color = dlg.Color;
                specimenPictureBox.BackColor = color;
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            Name = nameTextBox.Text;
            Description = descriptionTextBox.Text;
            Color = color;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
