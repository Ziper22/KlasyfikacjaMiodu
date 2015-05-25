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
            int r, g, b;
            float HoneyMinimalPollensAmount = 0;
            float HoneyMinimalPollensPercentageAmount = 0;

            string text;
            if (File.Exists("HoneyTypes.txt"))
                text = File.ReadAllText("HoneyTypes.txt");
            else
                text = Properties.Resources.HoneyTypes;

            using (StringReader reader = new StringReader(text))
            {
                while (true)
                {
                    HoneyName = reader.ReadLine();
                    if (HoneyName == null) break;
                    HoneyDescriptionName = reader.ReadLine();
                    HoneyLinkedName = reader.ReadLine();
                    r = Convert.ToInt32(reader.ReadLine());
                    g = Convert.ToInt32(reader.ReadLine());
                    b = Convert.ToInt32(reader.ReadLine());
                    HoneyMarkerColor = Color.FromArgb(r, g, b);
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
            if (!File.Exists("HoneyTypes.txt"))
                File.WriteAllText("HoneyTypes.txt", Properties.Resources.HoneyTypes);

            using (StreamWriter writer = new StreamWriter("HoneyTypes.txt", true))
            {
                writer.WriteLine(honeyType.Name);
                writer.WriteLine(honeyType.DescriptionName);
                writer.WriteLine(honeyType.Name);
                writer.WriteLine(honeyType.MarkerColor.R);
                writer.WriteLine(honeyType.MarkerColor.G);
                writer.WriteLine(honeyType.MarkerColor.B);
                writer.WriteLine(honeyType.MinimalPollensPercentageAmount);
                writer.WriteLine(honeyType.MinimalPollensPercentageAmount);
            }
        }
    }
}
