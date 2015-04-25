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

        bool isNameFieldRed = false;
        bool isHoneyNameFieldRed = false;

        public HoneyTypeEditWindow()
        {
            InitializeComponent();
            CenterToScreen();

            //Name = null;
            honeyType = new HoneyType();
            specimenPictureBox.BackColor = DrawColor();

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
            percentNumericUpDown.Value = (decimal)honeyType.MinimalPollensPercentageAmount;

            this.Text = "Edytuj";
            okButton.Enabled = true;

            ShowToolTip();
        }

        private void ChooseColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bool wasColorAssigned = CheckIfColorWasAssigned(dlg.Color);

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
        private bool CheckIfColorWasAssigned(Color color)
        {
            foreach (HoneyType honey in Session.Context.HoneyTypes)
            {
                if (color == honey.MarkerColor)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if name (names) which we are going to choose is (are) already assigned to other pollen
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool CheckIfNameWasAssigned(string newName)
        {
            foreach (HoneyType honey in Session.Context.HoneyTypes)
            {
                if (string.Equals(newName, honey.Name, StringComparison.OrdinalIgnoreCase) || string.Equals(newName, honey.DescriptionName, StringComparison.OrdinalIgnoreCase)) 
                {
                    if (string.Equals(newName, honeyType.Name, StringComparison.OrdinalIgnoreCase) == false && string.Equals(newName, honeyType.DescriptionName, StringComparison.OrdinalIgnoreCase) == false) 
                    {
                        return true;
                    }
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
            if (isNameFieldRed == false && isHoneyNameFieldRed == false)
            {
                honeyType.Name = nameTextBox.Text;
                honeyType.DescriptionName = honeyNameTextBox.Text;
                honeyType.MarkerColor = specimenPictureBox.BackColor;
                honeyType.MinimalPollensPercentageAmount = (float)percentNumericUpDown.Value;

                OnOkButtonClicked();

                this.Close();
            }
            else
            {
                warningLabel.Visible = true;
            }
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
            if (CheckIfNameWasAssigned(nameTextBox.Text) == true || nameTextBox.TextLength == 0)
            {
                nameTextBox.BackColor = Color.FromArgb(245, 174, 174);
                isNameFieldRed = true;
            }
            else
            {
                nameTextBox.BackColor = Color.FromArgb(174, 245, 183);
                isNameFieldRed = false;
            }

            SwitchOkButton(CheckIfInputControlsAreFilled());
        }

        private void HoneyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CheckIfNameWasAssigned(honeyNameTextBox.Text) == true || honeyNameTextBox.TextLength == 0)
            {
                honeyNameTextBox.BackColor = Color.FromArgb(245, 174, 174);
                isHoneyNameFieldRed = true;
            }
            else
            {
                honeyNameTextBox.BackColor = Color.FromArgb(174, 245, 183);
                isHoneyNameFieldRed = false;
            }

            SwitchOkButton(CheckIfInputControlsAreFilled());
        }

        private void PercentNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                if (percentNumericUpDown.Text.Length == 0)
                {
                    percentNumericUpDown.Value = 1;
                    percentNumericUpDown.Text = "1";
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
            toolTip.IsBalloon = true;

            toolTip.SetToolTip(nameTextBox, "Nazwa pyłku - w postaci rzeczownika");
            toolTip.SetToolTip(honeyNameTextBox, "Nazwa miodu - w postaci przymiotnika");
            toolTip.SetToolTip(percentNumericUpDown, "Minimalna procentowa liczba pyłków, wymagana, by dać miód danego rodzaju");
            toolTip.SetToolTip(specimenPictureBox, "Kliknij prawym przyciskiem myszy, by usunąć kolor");
        }

        /// <summary>
        /// Gets a random color
        /// </summary>
        /// <returns></returns>
        private Color DrawColor()
        {
            Random rnd = new Random();
            Color color;
            int R, G, B;

            do
            {
                R = rnd.Next(0, 256);
                G = rnd.Next(0, 256);
                B = rnd.Next(0, 256);

                color = Color.FromArgb(R, G, B);

            } while (CheckIfColorWasAssigned(color) == true);

            return color;
        }
    }
}
