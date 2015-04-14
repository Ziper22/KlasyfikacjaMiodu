﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
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
        private int count = 0;

        public HoneyTypeEditWindow()
        {
            InitializeComponent();
            CenterToScreen();
            
            Name = null;
            honeyType = new HoneyType("", Color.Empty, 0, 0);

            this.Text = "Dodaj";
            okButton.Enabled = false;
        }

        public HoneyTypeEditWindow(HoneyType honeyType)
        {
            InitializeComponent();
            CenterToScreen();

            this.honeyType = honeyType;

            nameTextBox.Text = honeyType.Name;
            specimenPictureBox.BackColor = honeyType.MarkerColor;
            valueTextBox.Text = honeyType.MinimalPollensAmount.ToString();
            percentNumericUpDown.Value = (decimal)honeyType.MinimalPollensPercentageAmount * 100;

            this.Text = "Edytuj";
            okButton.Enabled = true;
        }

        private void chooseColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                color = dlg.Color;
                specimenPictureBox.BackColor = color;
            }

            CheckInputControls();
            SwitchOkButton();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            honeyType.Name = nameTextBox.Text;
            honeyType.MarkerColor = specimenPictureBox.BackColor;
            honeyType.MinimalPollensAmount = float.Parse(valueTextBox.Text);
            honeyType.MinimalPollensPercentageAmount = (float)percentNumericUpDown.Value / 100f;

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

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckInputControls();
            SwitchOkButton();
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckInputControls();
            SwitchOkButton();
        }

        private void linkedNameTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckInputControls();
            SwitchOkButton();
        }

        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckIfInt();
            CheckInputControls();
            SwitchOkButton();
        }

        private void percentNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                if (percentNumericUpDown.Text.Length == 0)
                {
                    percentNumericUpDown.Value = 0;
                    percentNumericUpDown.Text = "0";
                }
            }
        }

        /// <summary>
        /// Counts all controls in which information must be set
        /// </summary>
        private void CheckInputControls()
        {
            foreach (Control cont in panel1.Controls) 
            {
                if (cont is TextBox)
                {
                    if (cont.Text != "")
                    {
                        count++;
                    }
                }
            }

            if (specimenPictureBox.BackColor.Name != "Control")  
            {
                count++;
            }
        }

        /// <summary>
        /// Checks if the condition to switch on the ok button is satisfied
        /// </summary>
        private void SwitchOkButton()
        {
            if (count == 3) 
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
            count = 0;
        }

        /// <summary>
        /// Doesn't allow to type in "Ilość" field anything else besides digits
        /// </summary>
        private void CheckIfInt()
        {
            try
            {
                int.Parse(valueTextBox.Text);
            }
            catch (Exception)
            {
                if (valueTextBox.Text.Length <= 1)
                {
                    valueTextBox.Text = "";
                }
                else
                {
                    valueTextBox.Text = valueTextBox.Text.Remove(valueTextBox.Text.Length - 1);
                    valueTextBox.Select(valueTextBox.Text.Length, 0);
                }
            }
        }
    }
}
