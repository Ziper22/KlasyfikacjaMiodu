using System;
using System.Drawing;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    ///     Author: Agata Hammermeister
    ///     <para />
    ///     Represents information on each <see cref="HoneyType" />.
    ///     Displayed on the side panel.
    /// </summary>
    public class PollenModule : FlowLayoutPanel
    {
        public HoneyType HoneyType { get; private set; }
        private bool chosen;
        private new FlowDirection FlowDirection;
        private FlowDirection FlowDirectionValues;
        private Label HoneyName;
        private PictureBox MarkerColor;
        private double Number;
        private double Percentage;
        private Label PollenNumber;
        private Label PollenPercentage;
        private FlowLayoutPanel PollenValues;

        public PollenModule()
        {
            MarkerColor = new PictureBox {Enabled = false};
            HoneyName = new BlackLabel {Enabled = false, Padding = new Padding(0, 6, 0, 0)};
            PollenValues = new FlowLayoutPanel {Enabled = false, Padding = new Padding(0, 3, 0, 0)};
            PollenNumber = new BlackLabel();
            PollenPercentage = new BlackLabel();

            Controls.Add(MarkerColor);
            Controls.Add(HoneyName);
            Controls.Add(PollenValues);
            PollenValues.Controls.Add(PollenNumber);
            PollenValues.Controls.Add(PollenPercentage);

            MarkerColor.Size = new Size(40, 40);
            HoneyName.Size = new Size(73, 40);
            PollenValues.Size = new Size(70, 40);
            PollenNumber.Size = new Size(70, 20);
            PollenPercentage.Size = new Size(70, 20);
            AutoSize = true;
            FlowDirection = FlowDirection.LeftToRight;
            FlowDirectionValues = FlowDirection.TopDown;

            Session.Changed += Session_Changed;
            Session_Changed(Session.Context);
        }

        public PollenModule(HoneyType honeyType)
            : this()
        {
            HoneyType = honeyType;
            Number = 0;
            Percentage = 0;

            MarkerColor.BackColor = honeyType.MarkerColor;
            HoneyName.Text = honeyType.Name;
            PollenNumber.Text = "pyłków: " + Number;
            PollenPercentage.Text = Percentage + "%";
        }

        private void Session_Changed(Context context)
        {
            Session.Context.MarkerAdded += Context_MarkerAdded;
            Session.Context.MarkerRemoved += Context_MarkerRemoved;
        }

        /// <summary>
        ///     Computes percentage share and number of honey type markers
        /// </summary>
        private void Context_MarkerAdded(Marker marker)
        {
            if (marker.HoneyType.Equals(HoneyType))
            {
                Number++;
            }
            ComputeMarkerNumber();
        }

        private void Context_MarkerRemoved(Marker marker)
        {
            if (marker.HoneyType.Equals(HoneyType))
            {
                Number--;
            }
            ComputeMarkerNumber();
        }

        private void ComputeMarkerNumber()
        {
            PollenNumber.Text = "pyłków: " + Number;
            int allMarkers = Session.Context.Markers.Count;
            if (allMarkers > 0)
            {
                Percentage = Number*100f/allMarkers;
            }
            else Percentage = 0;
            PollenPercentage.Text = Math.Round(Percentage, 3) + "%";
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