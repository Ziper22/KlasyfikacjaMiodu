using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.BottomBar
{
    /// <summary>
    ///  Author: Michał Fornalski.   <para/>
    ///  Klasa informująca użytkownika o wyznaczonym typie miodu.
    /// </summary>
    class HoneyTypeInformer
    {
        private Label honeyTypeLabel;
        private ToolTip honeyTip;
        private Form form;
        /// <summary>
        ///     Konstruktor klasy.
        /// </summary>
        /// <param name="honeyTypeLabel">Miejsce w którym pojawi się nazwa miodu.</param>
        public HoneyTypeInformer(Label honeyTypeLabel)
        {
            this.honeyTypeLabel = honeyTypeLabel;
            honeyTip = new ToolTip();
            honeyTip.SetToolTip(honeyTypeLabel, "Nieskasyfikowany");
            honeyTip.ShowAlways = true;

            SetContextEvents();
            Session.Changed += Session_ContextChanged;

            form = honeyTypeLabel.FindForm();
            form.SizeChanged += form_SizeChanged;
        }
        /// <summary>
        /// Funkcja wywoływana przy edycji typu miodu.
        /// </summary>
        /// <param name="honeyType"></param>
        private void Context_HoneyTypeEdited(HoneyType honeyType)
        {
            Dictionary<HoneyType, int> honeyCounter = CountAllMarkers();
            List<KeyValuePair<HoneyType, int>> sortedHoneyTypes = FindSortedHoneyTypes(honeyCounter);

            SetHoneyTypeLabelText(sortedHoneyTypes);
        }
        /// <summary>
        /// Funkcja wywoływana po zmianie wielkości.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void form_SizeChanged(object sender, EventArgs e)
        {
            SetLabelText(honeyTip.GetToolTip(honeyTypeLabel));
            AdjustLabelPosition();
        }

        /// <summary>
        ///     Funkcja ustawia zdarzenie klasy Context.
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.HoneyTypeEdited += Context_HoneyTypeEdited;
            Session.Context.MarkerAdded += Context_MarkerAddedOrRemoved;
            Session.Context.MarkerRemoved += Context_MarkerAddedOrRemoved;
        }

        /// <summary>
        ///     Funkcja wywoływana podczas każdej zmiany w bieżącej sesji.
        /// </summary>
        private void Session_ContextChanged(Context Context)
        {
            honeyTypeLabel.Text = "Nieskasyfikowany";
            honeyTip.SetToolTip(honeyTypeLabel, "Nieskasyfikowany");

            SetContextEvents();
        }
        /// <summary>
        ///     Funkcja wywoływana podczas dodawaniu/usuwaniu znacznika w bieżącej sesji.
        /// </summary>
        /// <param name="marker">Znacznik</param>
        private void Context_MarkerAddedOrRemoved(Marker notUsed)
        {
            Dictionary<HoneyType, int> honeyCounter = CountAllMarkers();

            List<KeyValuePair<HoneyType, int>> sortedHoneyTypes = FindSortedHoneyTypes(honeyCounter);

            SetHoneyTypeLabelText(sortedHoneyTypes);

            AdjustLabelPosition();
        }
        /// <summary>
        /// Funkcja dopasowująca pozycje pola tekstowego.
        /// </summary>
        private void AdjustLabelPosition()
        {
            Control parent = honeyTypeLabel.Parent;

            parent.Location = new Point(form.ClientSize.Width / 2 - parent.Size.Width / 2, parent.Location.Y);
        }
        /// <summary>
        /// Funkcja zliczająca wszystkie znaczniki.
        /// </summary>
        /// <returns></returns>
        private Dictionary<HoneyType, int> CountAllMarkers()
        {
            Dictionary<HoneyType, int> honeyCounter = new Dictionary<HoneyType, int>();

            foreach (Marker marker in Session.Context.Markers)
            {
                int oldHoneyTypeAmount = 0;
                if (honeyCounter.ContainsKey(marker.HoneyType))
                {
                    honeyCounter.TryGetValue(marker.HoneyType, out oldHoneyTypeAmount);
                    honeyCounter.Remove(marker.HoneyType);
                }

                int newHoneyTypeAmount = oldHoneyTypeAmount + 1;
                honeyCounter.Add(marker.HoneyType, newHoneyTypeAmount);
            }

            return honeyCounter;
        }
        /// <summary>
        /// Funkcja znajdująca posortowane typy miodów.
        /// </summary>
        /// <param name="honeyCounter"></param>
        /// <returns></returns>
        private List<KeyValuePair<HoneyType, int>> FindSortedHoneyTypes(Dictionary<HoneyType, int> honeyCounter)
        {
            int markerAmount = 0;
            foreach (Marker marker in Session.Context.Markers)
            {
                if (!marker.HoneyType.Dirt)
                    markerAmount++;
            }

            List<KeyValuePair<HoneyType, int>> matchingHoneyTypes = new List<KeyValuePair<HoneyType, int>>();

            foreach (KeyValuePair<HoneyType, int> entry in honeyCounter)
            {
                if (100f * entry.Value / markerAmount >= entry.Key.MinimalPollensPercentageAmount && !entry.Key.Dirt)
                    matchingHoneyTypes.Add(entry);
            }

            sortHoneyTypes(matchingHoneyTypes);
            return matchingHoneyTypes;
        }
        /// <summary>
        /// Funkcja sortująca typy miodów.
        /// </summary>
        /// <param name="honeyTypes"></param>
        private void sortHoneyTypes(List<KeyValuePair<HoneyType, int>> honeyTypes)
        {
            honeyTypes.Sort(
                (KeyValuePair<HoneyType, int> p1, KeyValuePair<HoneyType, int> p2) =>
                {
                    return p2.Value - p1.Value;
                });
        }
        /// <summary>
        ///     Funkcja generuje i ustala finalną nazwę miodu.
        /// </summary>
        private void SetHoneyTypeLabelText(List<KeyValuePair<HoneyType, int>> sortedHoneyTypes)
        {
            StringBuilder name = new StringBuilder();

            if (sortedHoneyTypes.Count == 0)
                name.Append("Niesklasyfikowany");

            foreach (KeyValuePair<HoneyType, int> item in sortedHoneyTypes)
            {

                if (name.Length > 0)
                {
                    if (name[name.Length-1] == 'y')
                    {
                        name.Remove(name.Length - 1, 1);
                        name.Append("o-");
                    }
                    else
                        name.Append("-");
                }

                name.Append(item.Key.DescriptionName);
            }

            SetLabelText(name.ToString());
            honeyTip.SetToolTip(honeyTypeLabel, name.ToString());
        }
        /// <summary>
        /// Funkcja ustawiająca co ostatecznie pojawi się w polu tekstowym.
        /// </summary>
        /// <param name="text"></param>
        private void SetLabelText(String text)
        {
            String shortName = text;
            int pixelsPerLetter = 9;
            int otherLabelsWidth = 450;
            int maxTextSize = Math.Max(0, (form.ClientSize.Width - otherLabelsWidth) / pixelsPerLetter);

            if (shortName.Length > maxTextSize)
            {
                shortName = shortName.Substring(0, maxTextSize);
                if (shortName.Contains("-"))
                    shortName = shortName.Substring(0, shortName.LastIndexOf("-")) + "...";
                else
                    shortName = "...";
            }

            honeyTypeLabel.Text = shortName;
        }
    }
}
