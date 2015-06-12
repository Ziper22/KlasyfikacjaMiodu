using System;
using System.Drawing;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    ///     Autor: Agata Hammermeister.
    ///     Przechowuje informacje o każdym  <see cref="HoneyType" />.
    ///     Wyświetlane na bocznym panelu.
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
        /// <summary>
        /// Konstruktor klasy.
        /// </summary>
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
        /// <summary>
        /// Konstruktor klasy.
        /// </summary>
        /// <param name="honeyType"></param>
        public PollenModule(HoneyType honeyType)
            : this()
        {
            HoneyType = honeyType;
            Number = 0;
            Percentage = 0;

            MarkerColor.BackColor = honeyType.MarkerColor;
            HoneyName.Text = honeyType.Name;
            if (honeyType.Dirt) PollenNumber.Text = "ilość: " + Number;
            else PollenNumber.Text = "pyłków: " + Number;
            if (honeyType.Dirt) PollenPercentage.Visible = false;
            else PollenPercentage.Text = Percentage + "%";
        }
        /// <summary>
        ///     Zlicza podział procentowy i numeryczny znaczników typu miodu.
        /// </summary>
        /// <param name="context"></param>
        private void Session_Changed(Context context)
        {
            Session.Context.MarkerAdded += Context_MarkerAdded;
            Session.Context.MarkerRemoved += Context_MarkerRemoved;
        }

        /// <summary>
        ///     Funkcja wywoływana przy zdzrzeniu dodania znacznika.
        /// </summary>
        private void Context_MarkerAdded(Marker marker)
        {
            if (marker.HoneyType.Equals(HoneyType))
            {
                Number++;
            }
            ComputeMarkerNumber();
        }
        /// <summary>
        ///     Funkcja wywoływana przy zdzrzeniu usunięcia znacznika.
        /// </summary>
        private void Context_MarkerRemoved(Marker marker)
        {
            if (marker.HoneyType.Equals(HoneyType))
            {
                Number--;
            }
            ComputeMarkerNumber();
        }
        /// <summary>
        ///     Funkcja odpowiedzialna za wyświetlanie liczby i wartości procentowej pyłków.
        /// </summary>
        private void ComputeMarkerNumber()
        {
            if (HoneyType.Dirt) PollenNumber.Text = "ilość: " + Number;
            else PollenNumber.Text = "pyłków: " + Number;
            int allMarkers = 0;
            foreach (Marker marker in Session.Context.Markers)
            {
                if (!marker.HoneyType.Dirt)
                {
                    allMarkers++;
                }
            }
            if (allMarkers > 0)
            {
                Percentage = Number*100f/allMarkers;
            }
            else Percentage = 0;
            PollenPercentage.Text = Math.Round(Percentage, 3) + "%";
        }
        /// <summary>
        ///     Funkja odpowiedzialna za dodanie panelu z pyłkiem.
        /// </summary>
        /// <param name="honey"></param>
        /// <returns></returns>
        public PollenModule Add(HoneyType honey)
        {
            PollenModule newPollen = new PollenModule(honey);
            return newPollen;
        }
        /// <summary>
        ///     Funkja odpowiedzialna za edycję panelu z pyłkiem.
        /// </summary>
        public void Edit(HoneyType honey)
        {
            HoneyType = honey;
            MarkerColor.BackColor = honey.MarkerColor;
            HoneyName.Text = honey.Name;
        }
        /// <summary>
        ///     Funkja odpowiedzialna za podświetlanie panelu z pyłkiem.
        /// </summary>
        public void Highlight()
        {
            if (chosen) return;

            BackColor = Color.PapayaWhip;
        }
        /// <summary>
        ///     Funkja odpowiedzialna za cofnięcie podświetlenia panelu z pyłkiem.
        /// </summary>
        public void UnHighlight()
        {
            if (chosen) return;
            BackColor = Color.Empty;
        }
        /// <summary>
        ///     Funkja odpowiedzialna za wybrnie panelu z pyłkiem.
        /// </summary>
        public void Choose()
        {
            chosen = true;
            BackColor = Color.NavajoWhite;
        }
        /// <summary>
        ///     Funkja odpowiedzialna za cofnięcie wyboru panelu z pyłkiem.
        /// </summary>
        public void UnChoose()
        {
            chosen = false;
            BackColor = Color.Empty;
        }
        /// <summary>
        /// Funkcja ukrywająca label pokazujący odsetek.
        /// </summary>
        public void HidePercentage()
        {
            PollenPercentage.Visible = false;
        }
    }
}