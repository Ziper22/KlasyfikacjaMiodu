using System;
using System.Drawing;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    /// Author: Agata Hammermeister<para/>
    /// Represents information on each <see cref="HoneyType"/>. 
    /// Displayed on the side panel.
    /// </summary>
    public class PollenModule : FlowLayoutPanel
    {
        public HoneyType HoneyType { get; private set; }
        public double Number;
        public double Percentage;
        private bool chosen;

        public PictureBox MarkerColor;
        public Label HoneyName;
        public FlowLayoutPanel PollenValues;
        public Label PollenNumber;
        public Label PollenPercentage;

        public new FlowDirection FlowDirection;
        public FlowDirection FlowDirectionValues;

        public PollenModule()
        {
            MarkerColor = new PictureBox {Enabled = false};
            HoneyName = new Label {Enabled = false, Padding = new Padding(0, 6, 0, 0)};
            PollenValues = new FlowLayoutPanel {Enabled = false, Padding = new Padding(0, 3, 0, 0)};
            PollenNumber = new Label();
            PollenPercentage = new Label();

            Controls.Add(MarkerColor);
            Controls.Add(HoneyName);
            Controls.Add(PollenValues);
            PollenValues.Controls.Add(PollenNumber);
            PollenValues.Controls.Add(PollenPercentage);

            MarkerColor.Size = new Size(40, 40);
            HoneyName.Size = new Size(80, 40);
            PollenValues.Size = new Size(80, 40);
            PollenNumber.Size = new Size(80, 20);
            PollenPercentage.Size = new Size(80, 20);
            AutoSize = true;
            FlowDirection = FlowDirection.LeftToRight;
            FlowDirectionValues = FlowDirection.TopDown;

            Session.Changed += Session_Changed;
        }

        public PollenModule(HoneyType honeyType)
            : this()
        {
            HoneyType = honeyType;
            Number = 0;
            Percentage = 0;

            MarkerColor.BackColor = honeyType.MarkerColor;
            HoneyName.Text = honeyType.Name;
            PollenNumber.Text = Number + " pyłków";
            PollenPercentage.Text = Percentage + "%";
        }

        void Session_Changed(Context context)
        {
            Session.Context.MarkerAdded += Context_MarkerAdded;
        }

        /// <summary>
        ///Computes percentage share and number of honey type markers 
        /// </summary>
        void Context_MarkerAdded(Marker marker)
        {
            if (marker.HoneyType.Equals(HoneyType))
            {
                Number++;
                PollenNumber.Text = Number + " pyłków";
                int allMarkers = Session.Context.HoneyTypes.Count;
                Percentage = Number*100/allMarkers;
                PollenPercentage.Text = Percentage + "%";
            }
        }

        public PollenModule Add(HoneyType honey)
        {
            PollenModule newPollen = new PollenModule(honey);
            return newPollen;
        }
        public void Edit(HoneyType honey)
        {
            HoneyType = honey;
            MarkerColor.BackColor = honey.MarkerColor;
            HoneyName.Text = honey.Name;
        }

        public void Highlight()
        {
            if (chosen) return;

            BackColor = Color.PapayaWhip;
        }

        public void UnHighlight()
        {
            if (chosen) return;
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