using System;
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

        private ColorDialog dlg;

        public HoneyTypeEditWindow()
        {
            InitializeComponent();
            CenterToScreen();
            
            Name = null;
            honeyType = new HoneyType();

            this.Text = "Dodaj";
            okButton.Enabled = false;

            ShowToolTip();
        }

        public HoneyTypeEditWindow(HoneyType honeyType)
        {
            InitializeComponent();
            CenterToScreen();

            this.honeyType = honeyType;

            nameTextBox.Text = honeyType.Name;
            honeyNameTextBox.Text = honeyType.DescriptionName;
            specimenPictureBox.BackColor = honeyType.MarkerColor;
//            valueTextBox.Text = honeyType.MinimalPollensAmount.ToString();
            percentNumericUpDown.Value = (decimal)honeyType.MinimalPollensPercentageAmount;

            this.Text = "Edytuj";
            okButton.Enabled = true;

            ShowToolTip();
        }

        private void ChooseColorButton_Click(object sender, EventArgs e)
        {
            dlg = new ColorDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bool wasColorAssigned = CheckIfColorWasAssigned();

                if (wasColorAssigned == true)
                {
                    DialogResult result = MessageBox.Show("Ten kolor został już przypisany innemu pyłkowi. Czy chcesz go użyć ponownie?", "Zdublowany kolor", MessageBoxButtons.YesNo);
                    
                    if (result == DialogResult.Yes)
                    {
                        specimenPictureBox.BackColor = dlg.Color;
                    }
                    else
                    {
                        specimenPictureBox.BackColor = Color.Empty;
                    }
                }
                else
                {
                    specimenPictureBox.BackColor = dlg.Color;
                }
            }

            SwitchOkButton(CheckIfInputControlsAreFilled());
        }

        /// <summary>
        /// Checks if color which we are going to choose is already assigned to other pollen
        /// </summary>
        /// <returns></returns>
        private bool CheckIfColorWasAssigned()
        {
            foreach (HoneyType honey in Session.Context.HoneyTypes)
            {
                if (dlg.Color == honey.MarkerColor)
                {
                    return true;
                }
            }
            return false;
        }

        private void SpecimenPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                specimenPictureBox.BackColor = Color.Empty;

                SwitchOkButton(CheckIfInputControlsAreFilled());
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            honeyType.Name = nameTextBox.Text;
            honeyType.DescriptionName = honeyNameTextBox.Text;
            honeyType.MarkerColor = specimenPictureBox.BackColor;
//            honeyType.MinimalPollensAmount = float.Parse(valueTextBox.Text);
            honeyType.MinimalPollensPercentageAmount = (float)percentNumericUpDown.Value;

            OnOkButtonClicked();

            this.Close();
        }

        protected virtual void OnOkButtonClicked()
        {
            if (OkButtonClicked != null)
                OkButtonClicked(honeyType);
        } 

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            SwitchOkButton(CheckIfInputControlsAreFilled());
        }

        private void HoneyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SwitchOkButton(CheckIfInputControlsAreFilled());
        }

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckIfInt(valueTextBox);
            SwitchOkButton(CheckIfInputControlsAreFilled());
        }

        private void PercentNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                if (percentNumericUpDown.Text.Length == 0)
                {
                    percentNumericUpDown.Value = 0;
                    percentNumericUpDown.Text = "0";
                }
            }

            CheckIfInt(percentNumericUpDown);
        }

        /// <summary>
        /// Checks if all controls in which information must be set are filled
        /// </summary>
        private bool CheckIfInputControlsAreFilled()
        {
            foreach (Control cont in panel1.Controls) 
            {
                if (cont is TextBox)
                {
                    if (cont.Text == "")
                    {
                        return false;
                    }
                }
            }

            if (specimenPictureBox.BackColor.Name == "Control")  
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the condition to switch on the ok button is satisfied
        /// </summary>
        private void SwitchOkButton(bool areControlsFilled)
        {
            if (areControlsFilled == true) 
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }

        /// <summary>
        /// Doesn't allow to type in digit-type field anything else besides digits
        /// </summary>
        private void CheckIfInt(Control control)
        {
            try
            {
                int.Parse(control.Text);
            }
            catch (Exception)
            {
                if (control.Text.Length <= 1)
                {
                    control.Text = "";
                }
                else
                {
                    control.Text = control.Text.Remove(control.Text.Length - 1);

                    if (control is TextBox)
                    {
                        TextBox temp = (TextBox)control;
                        temp.Select(temp.Text.Length, 0);
                    }
                    else if (control is NumericUpDown)
                    {
                        NumericUpDown temp = (NumericUpDown)control;
                        temp.Select(temp.Text.Length, 0);
                    }                    
                }
            }
        }

        private void ShowToolTip()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(nameTextBox, "Nazwa pyłku - w postaci rzeczownika");
            toolTip.SetToolTip(honeyNameTextBox, "Nazwa miodu - w postaci przymiotnika");
            toolTip.SetToolTip(valueTextBox, "Minimalna liczba pyłków wymagana, by dać miód danego rodzaju");
            toolTip.SetToolTip(percentNumericUpDown, "Minimalna procentowa liczba pyłków, wymagana by dać miód danego rodzaju");
            toolTip.SetToolTip(specimenPictureBox, "Kliknij prawym przyciskiem myszy, by usunąć kolor");
        }
    }
}
