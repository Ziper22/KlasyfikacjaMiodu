using System;
using System.Collections.Generic;
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
    
    class PollenModule:Panel
    {
        public double PollenNumber;
        public double PollenPercentage;
        public HoneyType HoneyType { get; private set; }
        public PictureBox MarkerColor;
        public Label HoneyName;
        

        public PollenModule(double pollenNumber, double pollenPercentage, HoneyType honeyType)
        {
            PollenNumber = pollenNumber;
            PollenPercentage = pollenPercentage;
            MarkerColor.BackColor = honeyType.MarkerColor;
            HoneyName.Text = honeyType.Name;
        }
    }
}
