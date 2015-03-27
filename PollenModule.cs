using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Author: Agata Hammermeister<para/>
    /// Contains information on number/percentage of each marked <see cref="HoneyType"/>. Displayed on the side panel.
    /// </summary>
    public class PollenModule:Panel
    {
        public HoneyType HoneyType { get; private set; }
        public double Number;
        public double Percentage;

        public PictureBox MarkerColor;
        public Label HoneyName;
        public Label PollenNumber;
        public Label PollenPercentage;

        public PollenModule():base()
        {
            MarkerColor = new PictureBox();
            HoneyName = new Label();
            PollenNumber = new Label();
            PollenPercentage = new Label();

            Controls.Add(MarkerColor);
            Controls.Add(HoneyName);
            Controls.Add(PollenNumber);
            Controls.Add(PollenPercentage);

            Size = new Size(40, 40);
        }

        public PollenModule(double pollenNumber, double pollenPercentage, HoneyType honeyType):this()
        {
            HoneyName.Text = honeyType.Name;
            MarkerColor.BackColor = honeyType.MarkerColor;
            Number = pollenNumber;
            Percentage = pollenPercentage;
        }

        public PollenModule(string honeyName, Color color):this()
        {
            HoneyName.Text = honeyName;
            MarkerColor.BackColor = color;
            Number = 0;
            Percentage = 0;
            PollenNumber.Text = Number.ToString();
            PollenPercentage.Text = Percentage.ToString();
        }

        public void Edit()
        {
            AddEditWindow addEditWindow = new AddEditWindow();
            addEditWindow.Show();
        }
    }
}
