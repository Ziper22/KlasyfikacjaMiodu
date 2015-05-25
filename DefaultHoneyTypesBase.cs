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
        /// 
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
        /// <summary>
        /// Adds new honey type to DefaultHoneyTypeBase
        /// </summary>
        /// <param name="honeyType">HoneyType</param>
        public static void AddNewHoneyTypeToFile(HoneyType honeyType)
        {
            {
                writer.WriteLine(honeyType.Name);
                writer.WriteLine(honeyType.DescriptionName);
                writer.WriteLine(honeyType.Name);
                writer.WriteLine(honeyType.MarkerColor);
                writer.WriteLine(honeyType.MinimalPollensPercentageAmount);
                writer.WriteLine(honeyType.MinimalPollensPercentageAmount);
            }
        }
    }
}
