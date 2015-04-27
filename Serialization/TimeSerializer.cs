using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyfikacjaMiodu.Serialization
{
    public static class TimeSerializer
    {
        public static string Serialize()
        {
            return Session.Context.TimeSpan.ToString();
        }

        public static TimeSpan Deserialize(string line)
        {
            int startIndex, length;
            string time;

            startIndex = line.IndexOf("Timer:") + 6;
            length = line.Length - startIndex;
            time = line.Substring(startIndex, length);

            TimeSpan ts = TimeSpan.Parse(time);

            return ts;
        }
    }
}
