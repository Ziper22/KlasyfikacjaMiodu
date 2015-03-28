using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.BottomBar
{
    class HoneyTypeInformer
    {
        private int allHoneyTypeAmount = 0;
        private Label honeyTypeLabel;
        private Dictionary<HoneyType, int> honeyCounter;

        public HoneyTypeInformer(Label honeyTypeLabel)
        {
            this.honeyTypeLabel = honeyTypeLabel;
            honeyCounter = new Dictionary<HoneyType, int>();

            SetContextEvents();
            Session.Changed += Session_ContextChanged;
        }

        /// <summary>
        /// Sets Context events. Listeners should be set again after every Context change in current Session
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.MarkerAdded += Context_MarkerAdded;
            Session.Context.MarkerRemoved += Context_MarkerRemoved;
        }

        /// <summary>
        /// Called when Context in current session is changing
        /// </summary>
        private void Session_ContextChanged(Context Context)
        {
            allHoneyTypeAmount = 0;
            honeyCounter.Clear();
            honeyTypeLabel.Text = "Nieskasyfikowany";

            SetContextEvents();
        }

        private void Context_MarkerAdded(Marker marker)
        {
            int oldHoneyTypeAmount = 0;
            if (honeyCounter.ContainsKey(marker.HoneyType))
            {
                honeyCounter.TryGetValue(marker.HoneyType, out oldHoneyTypeAmount);
                honeyCounter.Remove(marker.HoneyType);
            }

            int newHoneyTypeAmount = oldHoneyTypeAmount + 1;
            honeyCounter.Add(marker.HoneyType, newHoneyTypeAmount);
            allHoneyTypeAmount++;

            setHoneyTypeLabelText();
        }

        void Context_MarkerRemoved(Marker marker)
        {
            int oldHoneyTypeAmount = 1; //1 bo gdy nie bedzie ilosci danego typu w slowniku to potem odejmujemy 1 i wychodzi 0
            if (honeyCounter.ContainsKey(marker.HoneyType))
            {
                honeyCounter.TryGetValue(marker.HoneyType, out oldHoneyTypeAmount);
                honeyCounter.Remove(marker.HoneyType);
            }

            int newHoneyTypeAmount = oldHoneyTypeAmount - 1;
            honeyCounter.Add(marker.HoneyType, newHoneyTypeAmount);
            allHoneyTypeAmount--;

            setHoneyTypeLabelText();
        }

        private void setHoneyTypeLabelText()
        {
            //taki prosty algorytm zeby bylo wiadomo oglonie co trzeba zrobic

            //trzeba napisac od nowa i moze jakeis inne funkcje dodac zeby uwzglednial sklad procentowy danego pylku w miodzie
            //i tez w razie potrzeby robil polaczenia jak lipowo-wrzosowo-gryczany.

            //obczaj jakie pola ma klasa honeytype tam wszystko jest co potrzeba.

            int value = 0;
            HoneyType bestType = null;
            foreach (KeyValuePair<HoneyType, int> entry in honeyCounter)
            {
                if (bestType == null)
                {
                    bestType = entry.Key;
                    value = entry.Value;
                }

                if (entry.Value > value)
                {
                    bestType = entry.Key;
                    value = entry.Value;
                }   
            }

            if (bestType != null && bestType.MinimalPollensAmount <= value)
                honeyTypeLabel.Text = bestType.DescriptionName;
        }
    }
}
