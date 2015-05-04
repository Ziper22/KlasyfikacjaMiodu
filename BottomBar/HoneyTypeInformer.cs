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
    class HoneyTypeInformer
    {
        private Label honeyTypeLabel;
        private ToolTip honeyTip;
        private Form form;

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

        void form_SizeChanged(object sender, EventArgs e)
        {
            SetLabelText(honeyTip.GetToolTip(honeyTypeLabel));
            AdjustLabelPosition();
        }

        /// <summary>
        /// Sets Context events. Listeners should be set again after every Context change in current Session
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.MarkerAdded += Context_MarkerAddedOrRemoved;
            Session.Context.MarkerRemoved += Context_MarkerAddedOrRemoved;
        }

        /// <summary>
        /// Called when Context in current session is changing
        /// </summary>
        private void Session_ContextChanged(Context Context)
        {
            honeyTypeLabel.Text = "Nieskasyfikowany";
            honeyTip.SetToolTip(honeyTypeLabel, "Nieskasyfikowany");

            SetContextEvents();
        }

        private void Context_MarkerAddedOrRemoved(Marker notUsed)
        {
            Dictionary<HoneyType, int> honeyCounter = CountAllMarkers();

            List<KeyValuePair<HoneyType, int>> sortedHoneyTypes = FindSortedHoneyTypes(honeyCounter);

            SetHoneyTypeLabelText(sortedHoneyTypes);

            AdjustLabelPosition();
        }

        private void AdjustLabelPosition()
        {
            Control parent = honeyTypeLabel.Parent;

            parent.Location = new Point(form.ClientSize.Width / 2 - parent.Size.Width / 2, parent.Location.Y);
        }

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

        private List<KeyValuePair<HoneyType, int>> FindSortedHoneyTypes(Dictionary<HoneyType, int> honeyCounter)
        {
            int markerAmount = Session.Context.Markers.Count;
            List<KeyValuePair<HoneyType, int>> matchingHoneyTypes = new List<KeyValuePair<HoneyType, int>>();

            foreach (KeyValuePair<HoneyType, int> entry in honeyCounter)
            {
                if (100f * entry.Value / markerAmount >= entry.Key.MinimalPollensPercentageAmount)
                    matchingHoneyTypes.Add(entry);
            }

            sortHoneyTypes(matchingHoneyTypes);
            return matchingHoneyTypes;
        }

        private void sortHoneyTypes(List<KeyValuePair<HoneyType, int>> honeyTypes)
        {
            honeyTypes.Sort(
                (KeyValuePair<HoneyType, int> p1, KeyValuePair<HoneyType, int> p2) =>
                {
                    return p2.Value - p1.Value;
                });
        }

        private void SetHoneyTypeLabelText(List<KeyValuePair<HoneyType, int>> sortedHoneyTypes)
        {
            StringBuilder name = new StringBuilder();

            if (sortedHoneyTypes.Count == 0)
                name.Append("Niesklasyfikowany");

            foreach (KeyValuePair<HoneyType, int> item in sortedHoneyTypes)
            {
                if (name.Length > 0)
                {
                    name.Remove(name.Length - 1, 1);
                    name.Append("o-");
                }

                name.Append(item.Key.DescriptionName);
            }

            SetLabelText(name.ToString());
            honeyTip.SetToolTip(honeyTypeLabel, name.ToString());
        }

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
