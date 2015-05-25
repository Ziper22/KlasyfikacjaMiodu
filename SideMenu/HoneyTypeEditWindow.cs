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
        public delegate void OkButtonClickedDelegate(HoneyType honeyType, bool persistent);
        public event OkButtonClickedDelegate OkButtonClicked;
        public delegate void CheckBoxCheckedDelegate();
        public event CheckBoxCheckedDelegate CheckBoxChecked;
        private HoneyType honeyType;

        bool isNameFieldRed = false;
        bool isHoneyNameFieldRed = false;

        /// <summary>
        /// Constructor for adding new pollen
        /// </summary>
        public HoneyTypeEditWindow()
        {
            InitializeComponent();
            CenterToScreen();

            honeyType = new HoneyType();
            specimenPictureBox.BackColor = DrawColor();
            nameTextBox.BackColor = Color.FromArgb(245, 174, 174);
            honeyNameTextBox.BackColor = Color.FromArgb(245, 174, 174);

            this.Text = "Dodaj";
            okButton.Enabled = false;

            ShowToolTip();
        }

        /// <summary>
        /// Constructor for editing existing pollen
        /// </summary>
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
            checkBox.Visible = false;
            ShowToolTip();
        }

        #region Events

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

            CheckIfSpaceWasClicked(nameTextBox);
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

            CheckIfSpaceWasClicked(honeyNameTextBox);
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

        private void SpecimenPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                specimenPictureBox.BackColor = Color.Empty;

                SwitchOkButton(CheckIfInputControlsAreFilled());
            }
            else if (e.Button == MouseButtons.Left)
            {
                ChooseColorButton_Click(sender, e);
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

                if (checkBox.Checked == true)
                    OnCheckBoxChecked();

                this.Close();
            }
            else
            {
                warningLabel.Visible = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        protected virtual void OnOkButtonClicked()
        {
            if (OkButtonClicked != null)
                OkButtonClicked(honeyType, checkBox.Checked);
        }
        
        protected virtual void OnCheckBoxChecked()
        {
            if (CheckBoxChecked != null)
                CheckBoxChecked();
        }

        /// <summary>
        /// Checks if color which we are going to choose is already assigned to other pollen
        /// </summary>
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
        /// Checks if the condition to switch the ok button on is satisfied
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
        /// Doesn't allow to type a space at the beggining and two or more spaces at the end of textboxes
        /// </summary>
        private void CheckIfSpaceWasClicked(TextBox control)
        {
            if (control.Text.StartsWith(" ") == true)  
            {
                control.Text = control.Text.Remove(0, 1);
            }

            if (control.Text.EndsWith("  ") == true) 
            {
                control.Text = control.Text.Remove(control.Text.Length - 1);
                control.Select(control.Text.Length, 0);
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

                    NumericUpDown temp = (NumericUpDown)control;
                    temp.Select(temp.Text.Length, 0);
                }
            }
        }

        /// <summary>
        /// Assigns tooltips to four controls
        /// </summary>
        private void ShowToolTip()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.IsBalloon = true;

            toolTip.SetToolTip(nameTextBox, "Nazwa pyłku - w postaci rzeczownika");
            toolTip.SetToolTip(honeyNameTextBox, "Nazwa miodu - w postaci przymiotnika");
            toolTip.SetToolTip(percentNumericUpDown, "Minimalna zawartość procentowa pyłków w miodzie potrzebna do stwierdzenia, że miód jest danego typu");
            toolTip.SetToolTip(specimenPictureBox, "Kliknij prawym przyciskiem myszy, aby usunąć kolor");
        }

        /// <summary>
        /// Gets a random color
        /// </summary>
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
