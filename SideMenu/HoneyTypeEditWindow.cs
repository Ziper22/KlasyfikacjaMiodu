using System;
using System.Drawing;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    /// Author: Marek Borski. <para/>
    /// Klasa odpowiedzialna za okno edycji typów miodu.
    /// </summary>
    public partial class HoneyTypeEditWindow : Form
    {
        public delegate void OkButtonClickedDelegate(HoneyType honeyType, bool persistent);
        public event OkButtonClickedDelegate OkButtonClicked;
        private HoneyType honeyType;

        bool isNameFieldRed = false;
        bool isHoneyNameFieldRed = false;

        /// <summary>
        /// Konstruktor klasy.
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
            ShowToolTips();
        }

        /// <summary>
        /// Konstruktor edytujący istniejący pyłek.
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

            Size = new System.Drawing.Size(288, 210);
            this.Text = "Edytuj";
            okButton.Enabled = true;
            checkBox.Visible = false;
            ShowToolTips();
        }

        #region Events
        /// <summary>
        /// Funkcja wywoływana podczas zmiany tekstu w polu NameTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Funkcja wywoływana podczas zmiany tekstu w polu HoneyNameTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Funkcja wywoływana przy wciśnięciu klawisza dodającego wartość w polu Percent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Funkcja wywoływana przy kliknięciu przycisku zmiany koloru.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Funkcja wywoływana po kliknięciu na obrazek z kolorem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Funkcja wywoływana po wciścięciu przycisku OK.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (isNameFieldRed == false && isHoneyNameFieldRed == false)
            {
                honeyType.Name = nameTextBox.Text.Trim();
                honeyType.DescriptionName = honeyNameTextBox.Text.Trim();
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
        /// <summary>
        /// Funkcja wywoływana przy wciśnięciu przycisku Anuluj.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        /// <summary>
        /// Funkcja sprawdzająca czy został wciśnięty przycisk OK.
        /// </summary>
        protected virtual void OnOkButtonClicked()
        {
            if (OkButtonClicked != null)
                OkButtonClicked(honeyType, checkBox.Checked);
        }

        /// <summary>
        /// Funkcja sprawdza czy wybrany kolor nie jest juz przypisany do innego pyłka.
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
        /// Funkcja sprawdza czy wybrana nazwa nie jest juz przypisana do innego pyłka.
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
        /// Funkcja sprawdzająca czy wszystkie pola zostały wypełnione.
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
        /// Funkcja sprawdzająca czy wszystkie warunki w formularzu zostały spełnione.
        /// Aktywuje przycisk lub go dezaktywuje.
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
        /// Funkcja zabezpieczająca przed wciśnięciem spacji na początku lub dwóch spacji pod rząd.
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
        /// Nie pozwala na wpisanie do numerycznego pola niczego innego poza cyframi.
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
        /// Funkcja odpowiedzialna za pokazywanie dymków z podpowiedziami.
        /// </summary>
        private void ShowToolTips()
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
        /// Funkcja generująca losowy kolor.
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
