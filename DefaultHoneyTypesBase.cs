using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Resources;

namespace KlasyfikacjaMiodu
{
    internal class DefaultHoneyTypesBase
    {
        /// <summary>
        /// Author: Arek Mackiewicz,Krzysztof Kalisz<para/>
        /// All project data and current state is kept as a program Context.
        /// Every Context realted action as new project, loading new data etc. can by listened with events.
        /// </summary>
        public static List<HoneyType> GetAllHoneyTypesFromFile()
        {
            List<HoneyType> HoneyList = new List<HoneyType>();

            string HoneyName = "";
            string HoneyDescriptionName = "";
            string HoneyLinkedName = "";
            Color HoneyMarkerColor = Color.Empty;
            float HoneyMinimalPollensAmount = 0;
            float HoneyMinimalPollensPercentageAmount = 0;

            using (StringReader reader = new StringReader(Properties.Resources.HoneyTypes))
            {
                while (true)
                {
                    HoneyName = reader.ReadLine();
                    if (HoneyName == null) break;
                    HoneyDescriptionName = reader.ReadLine();
                    HoneyLinkedName = reader.ReadLine();
                    HoneyMarkerColor = Color.FromName(reader.ReadLine());
                    HoneyMinimalPollensAmount = Convert.ToSingle(reader.ReadLine());
                    HoneyMinimalPollensPercentageAmount = Convert.ToSingle(reader.ReadLine());
                    HoneyList.Add(new HoneyType(HoneyName, HoneyDescriptionName, HoneyLinkedName, HoneyMarkerColor,
                        HoneyMinimalPollensAmount, HoneyMinimalPollensPercentageAmount));
                }
            }
            return HoneyList;
        }
    }
}
