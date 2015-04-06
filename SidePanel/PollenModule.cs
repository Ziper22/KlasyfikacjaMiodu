using System.Drawing;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SidePanel
{
    /// <summary>
    /// Author: Agata Hammermeister<para/>
    /// Contains information on number/percentage of each marked <see cref="HoneyType"/>. Displayed on the side panel.
    /// </summary>
    public class PollenModule : FlowLayoutPanel
    {
        public HoneyType HoneyType { get; private set; }
        public double Number;
        public double Percentage;
        private bool highlighted;
        private bool chosen;

        public PictureBox MarkerColor;
        public Label HoneyName;
        public FlowLayoutPanel PollenValues;
        public Label PollenNumber;
        public Label PollenPercentage;

        public FlowDirection FlowDirection;
        public FlowDirection FlowDirectionValues;

        public PollenModule()
        {
            MarkerColor = new PictureBox();
            MarkerColor.Enabled = false;
            HoneyName = new Label();
            HoneyName.Enabled = false;
            PollenValues = new FlowLayoutPanel();
            PollenValues.Enabled = false;
            PollenNumber = new Label();
            PollenPercentage = new Label();

            Controls.Add(MarkerColor);
            Controls.Add(HoneyName);
            Controls.Add(PollenValues);
            PollenValues.Controls.Add(PollenNumber);
            PollenValues.Controls.Add(PollenPercentage);

            MarkerColor.Size = new Size(40, 40);
            HoneyName.Size = new Size(60, 40);
            PollenValues.Size = new Size(30, 40);
            PollenNumber.Size = new Size(30, 20);
            PollenPercentage.Size = new Size(30, 20);
            AutoSize = true;
            FlowDirection = FlowDirection.LeftToRight;
            FlowDirectionValues = FlowDirection.TopDown;

            Session.Changed += Session_Changed;
        }

        void Session_Changed(Context context)
        {
            Session.Context.MarkerAdded += Context_MarkerAdded;

            // Context.HoneyTypes
        }

        void Context_MarkerAdded(Marker marker)
        {
            if (marker.HoneyType.Equals(HoneyType))
            {
                Number++;
            }
        }

        public PollenModule(double pollenNumber, double pollenPercentage, HoneyType honeyType)
            : this()
        {
            HoneyName.Text = honeyType.Name;
            MarkerColor.BackColor = honeyType.MarkerColor;
            Number = pollenNumber;
            Percentage = pollenPercentage;
        }

        public PollenModule(HoneyType honeyType)
            : this()
        {
            HoneyName.Text = honeyType.Name;
            MarkerColor.BackColor = honeyType.MarkerColor;
            Number = 0;
            Percentage = 0;
        }

        public PollenModule(string honeyName, Color color)
            : this() //tylko do testów
        {
            HoneyName.Text = honeyName;
            MarkerColor.BackColor = color;
            Number = 0;
            Percentage = 0;
            PollenNumber.Text = Number.ToString();
            PollenPercentage.Text = Percentage.ToString();
        }

        public PollenModule Add(HoneyType honey)
        {
            PollenModule newPollen = new PollenModule(honey);
            return newPollen;
        }
        public void Edit(HoneyType honey)
        {
            MarkerColor.BackColor = honey.MarkerColor;
            HoneyName.Text = honey.Name;
            Number = honey.MinimalPollensAmount;
            Percentage = honey.MinimalPollensPercentageAmount;
        }

        public void Highlight()
        {
            if(chosen) return;

            BackColor = Color.PapayaWhip;
            highlighted = true;
        }

        public void UnHighlight()
        {
            if (chosen) return;
            highlighted = false;
            BackColor = Color.Empty;
        }

        public void Choose()
        {
            chosen = true;
            BackColor = Color.NavajoWhite;
        }

        public void UnChoose()
        {
            chosen = false;
            BackColor = Color.Empty;
        }
    }
}