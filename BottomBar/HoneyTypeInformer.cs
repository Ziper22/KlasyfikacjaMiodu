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

    //----------------------------
        private string returnName(string txt)  //zwraca nazwe
        {
            StringBuilder honeyName = new StringBuilder();

            honeyName.Clear();
            honeyName.Append(txt);
            return honeyName.ToString();
        }

        private string appendName(string lastName, string txt)  //zwraca zlozona nazwe (paro-gatunkowa)
        {
            StringBuilder honeyName = new StringBuilder();

            honeyName.Clear();
            honeyName.Append(lastName);
            honeyName.Replace('y', 'o', honeyName.Length, 0);
            honeyName.Append("-" + txt);
            return honeyName.ToString();
        }
    //----------------------------

        private void setHoneyTypeLabelText()
        {
            //taki prosty algorytm zeby bylo wiadomo oglonie co trzeba zrobic

            //trzeba napisac od nowa i moze jakeis inne funkcje dodac zeby uwzglednial sklad procentowy danego pylku w miodzie
            //i tez w razie potrzeby robil polaczenia jak lipowo-wrzosowo-gryczany.

            //obczaj jakie pola ma klasa honeytype tam wszystko jest co potrzeba.
            
            string labelName = "";   //do nazwy
            int honeyNameCounter = 0;
            bool foundOne = false;  //dla sprawdzenia, że już raz znalaeziono jakiś pyłek 

            HoneyType bestType = null;

            foreach (KeyValuePair<HoneyType, int> entry in honeyCounter)
            {
                if (bestType == null)   //nie ma bestType, to "Niezklasyfikowany"
                {
                    labelName = returnName("Niezklasyfikowany");
                    honeyTypeLabel.Text = labelName;

                    if (entry.Value >= 1 && honeyNameCounter >= 3 && foundOne == true) //ale jezeli nie ma best type, a byl juz jakis typ wypisany
                    {                                                                 //oraz bylo wiecej niz 3 gatunki, to "Wielokwiatowy"
                        labelName = returnName("Wielokwiatowy");
                        honeyTypeLabel.Text = labelName;
                    }
                }

                if (entry.Key.MinimalPollensAmount <= entry.Value)
                {
                    if (bestType != null)   //jest bestType i to co znaleziono tez spelnia zalozenia
                    {                       //, to nazwa sklada sie z kilku
                        labelName = appendName(labelName, entry.Key.DescriptionName);
                        honeyTypeLabel.Text = labelName;

                        honeyNameCounter++;

                        if (honeyNameCounter >= 3)
                            bestType = null;
                    }

                    if (bestType == null && honeyNameCounter < 1)   //pierwszy gatunek, ktory spelnia warunek, wypisuje nazwe
                    {                                               //i ustala bestType
                        bestType = entry.Key;
                        labelName = entry.Key.DescriptionName;
                        honeyTypeLabel.Text = labelName;

                        honeyNameCounter++;
                        foundOne = true;
                    }
                }
            }

            //int value = 0;
            //HoneyType bestType = null;

            //foreach (KeyValuePair<HoneyType, int> entry in honeyCounter)
            //{
            //    if (bestType == null)
            //    {
            //        bestType = entry.Key;
            //        value = entry.Value;
            //    }

            //    if (entry.Value > value)
            //    {
            //        bestType = entry.Key;
            //        value = entry.Value;
            //    }   
            //}

            //if (bestType != null && bestType.MinimalPollensAmount <= value)
            //    honeyTypeLabel.Text = bestType.DescriptionName;
        }
    }
}
