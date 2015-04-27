using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyfikacjaMiodu.Serialization
{
    public static class MarkerSerializer
    {
        private static List<string> markerStringList;

        public static List<string> Serialize(Context context)
        {
            markerStringList = new List<string>();
            string markerString;

            foreach (var marker in context.Markers)
            {
                markerString =
                    "X: " + marker.X + " " +
                    "Y: " + marker.Y + " " +
                    "SIZE: " + marker.Size + " " +
                    "TYPE_NAME: " + marker.HoneyType.Name;
                markerStringList.Add(markerString);
            }
            return markerStringList;
        }
        public static Marker Deserialize(string line)
        {
            Marker marker = null;
            int startIndex, lastIndex, length;
            int x, y, size;
            HoneyType honeyType;
            string honeyTypeName;
            
            // Get x
            startIndex = line.IndexOf("X:") + 2;
            lastIndex = line.IndexOf(" Y");
            length = lastIndex - startIndex;
            x = int.Parse(line.Substring(startIndex, length));

            // Get y
            startIndex = line.IndexOf("Y:") + 2;
            lastIndex = line.IndexOf(" SIZE");
            length = lastIndex - startIndex;
            y = int.Parse(line.Substring(startIndex, length));

            // Get size
            startIndex = line.IndexOf("SIZE:") + 5;
            lastIndex = line.IndexOf(" TYPE_NAME");
            length = lastIndex - startIndex;
            size = int.Parse(line.Substring(startIndex, length));

            // Get HoneyType
            startIndex = line.IndexOf("TYPE_NAME:") + 11;
            lastIndex = line.Length;
            length = lastIndex - startIndex;
            honeyTypeName = line.Substring(startIndex, length);

            foreach (var honey in Session.Context.HoneyTypes)
            {
                if (honey.Name == honeyTypeName)
                    return new Marker(x, y, size, honey);
            }
            return null; // nie można utworzyć markera, bo nie ma takiego honeyType'a
            
        }
    }
}
