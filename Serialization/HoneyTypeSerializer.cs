using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.Serialization
{
    public class HoneyTypeSerializer
    {
        private List<string> honeyTypeStringList;

        public HoneyTypeSerializer()
        {
            honeyTypeStringList = new List<string>();
        }

        public List<string> Serialize(Context context)
        {
            string honeyTypeString;

            foreach (var honeyType in context.HoneyTypes)
            {
                honeyTypeString =
                    "NAME:" + honeyType.Name + " " +
                    "DESCRIPTION_NAME:" + honeyType.DescriptionName + " " +
                    "MARKER_COLOR:" + ToHexConverter(honeyType.MarkerColor) + " " +
                    "MINIMAL_POLLENS_PERCENTAGE_AMOUNT:" + honeyType.MinimalPollensPercentageAmount;
                honeyTypeStringList.Add(honeyTypeString);
            }
            return honeyTypeStringList;
        }
        public HoneyType Deserialize(string line)
        {
            int startIndex, lastIndex, length;

            string name;
            string descriptionName;
            Color markerColor;
            float minimalPollensPercentageAmount;

            // I'm getting a name of honey type
            startIndex = line.IndexOf("NAME:") + 5;
            lastIndex = line.IndexOf(" DESCRIPTION_NAME");
            length = lastIndex - startIndex;
            name = line.Substring(startIndex, length);

            // I'm getting a description name of honey type
            startIndex = line.IndexOf("DESCRIPTION_NAME:") + 17;
            lastIndex = line.IndexOf(" MARKER_COLOR");
            length = lastIndex - startIndex;
            descriptionName = line.Substring(startIndex, length);

            // I'm getting a marker color of honey type
            startIndex = line.IndexOf("MARKER_COLOR:") + 13;
            lastIndex = line.IndexOf(" MINIMAL_POLLENS_P");
            length = lastIndex - startIndex;
            markerColor = ToColorConverter(line.Substring(startIndex, length));

            // I'm getting a minimal pollens percentage amount;
            startIndex = line.IndexOf("PERCENTAGE_AMOUNT:") + 18;
            lastIndex = line.Length;
            length = lastIndex - startIndex;
            string s = line.Substring(startIndex, length);
            minimalPollensPercentageAmount = float.Parse(line.Substring(startIndex, length));

            HoneyType h = new HoneyType(name,descriptionName, markerColor, minimalPollensPercentageAmount);

            if (h.Name.Equals("Zanieczyszczenie"))
                h.Dirt = true;

            return h;
        }

        private String ToHexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        private Color ToColorConverter(string hex)
        {
            return System.Drawing.ColorTranslator.FromHtml(hex);
        }
    }
}
