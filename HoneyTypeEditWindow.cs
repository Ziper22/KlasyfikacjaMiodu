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
    public partial class HoneyTypeEditWindow : Form
    {
        public delegate void OkButtonClickedDelegate(HoneyType honeyType);
        public event OkButtonClickedDelegate OkButtonClicked;
        private HoneyType honeyType;

        private Color color;

        public HoneyTypeEditWindow()
        {
            InitializeComponent();
            Name = null;
            honeyType = new HoneyType("", "", Color.White);
        }

        public HoneyTypeEditWindow(HoneyType honeyType)
        {
            InitializeComponent();
            this.honeyType = honeyType;

            nameTextBox.Text = honeyType.Name;
            descriptionTextBox.Text = honeyType.DescriptionName;
            specimenPictureBox.BackColor = honeyType.MarkerColor;
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

        private void okButton_Click(object sender, EventArgs e)
        {
            honeyType.Name = nameTextBox.Text;
            honeyType.DescriptionName = descriptionTextBox.Text;
            honeyType.MarkerColor = color;

            OnOkButtonClicked();

            this.Close();
        }

        protected virtual void OnOkButtonClicked()
        {
            if (OkButtonClicked != null)
                OkButtonClicked(honeyType);
        } 

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
