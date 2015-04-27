using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.Serialization
{
    public static class HoneyTypeSerializer
    {
        private static List<string> honeyTypeStringList;

        public static List<string> Serialize(Context context)
        {
            honeyTypeStringList = new List<string>();
            string honeyTypeString;

            foreach (var honeyType in context.HoneyTypes)
            {
                honeyTypeString =
                    "NAME:" + honeyType.Name + " " +
                    "DESCRIPTION_NAME:" + honeyType.DescriptionName + " " +
                    "LINKED_NAME:" + honeyType.LinkedName + " " +
                    "MARKER_COLOR:" + ToHexConverter(honeyType.MarkerColor) + " " +
                    "MINIMAL_POLLENS_AMOUNT:" + honeyType.MinimalPollensAmount + " " +
                    "MINIMAL_POLLENS_PERCENTAGE_AMOUNT:" + honeyType.MinimalPollensPercentageAmount;
                honeyTypeStringList.Add(honeyTypeString);
            }
            return honeyTypeStringList;
        }
        public static HoneyType Deserialize(string line)
        {
            HoneyType honeyType = null;
            int startIndex, lastIndex, length;

            string name;
            string descriptionName;
            string linkedName;
            Color markerColor;
            float minimalPollensAmount;
            float minimalPollensPercentageAmount;

            // I'm getting a name of honey type
            startIndex = line.IndexOf("NAME:") + 5;
            lastIndex = line.IndexOf(" DESCRIPTION_NAME");
            length = lastIndex - startIndex;
            name = line.Substring(startIndex, length);

            // I'm getting a description name of honey type
            startIndex = line.IndexOf("DESCRIPTION_NAME:") + 17;
            lastIndex = line.IndexOf(" LINKED_NAME");
            length = lastIndex - startIndex;
            descriptionName = line.Substring(startIndex, length);

            // I'm getting a linked name of honey type
            startIndex = line.IndexOf("LINKED_NAME:") + 12;
            lastIndex = line.IndexOf(" MARKER_COLOR");
            length = lastIndex - startIndex;
            linkedName = line.Substring(startIndex, length);

            // I'm getting a marker color of honey type
            startIndex = line.IndexOf("MARKER_COLOR:") + 13;
            lastIndex = line.IndexOf(" MINIMAL_POLLENS_AMOUNT");
            length = lastIndex - startIndex;
            markerColor = ToColorConverter(line.Substring(startIndex, length));

            // I'm getting a minimal pollens amount;
            startIndex = line.IndexOf("MINIMAL_POLLENS_AMOUNT:") + 23;
            lastIndex = line.IndexOf(" MINIMAL_POLLENS_P");
            length = lastIndex - startIndex;
            minimalPollensAmount = float.Parse(line.Substring(startIndex, length));

            // I'm getting a minimal pollens percentage amount;
            startIndex = line.IndexOf("PERCENTAGE_AMOUNT:") + 18;
            lastIndex = line.Length;
            length = lastIndex - startIndex;
            string s = line.Substring(startIndex, length);
            minimalPollensPercentageAmount = float.Parse(line.Substring(startIndex, length));

            return new HoneyType(name, descriptionName, linkedName, markerColor, minimalPollensAmount, minimalPollensPercentageAmount);
        }

        private static String ToHexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        private static Color ToColorConverter(string hex)
        {
            return System.Drawing.ColorTranslator.FromHtml(hex);
        }
    }
}
