﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace KlasyfikacjaMiodu
{
    class DB
    {
        /// <summary>
        /// Author: Arek Mackiewicz<para/>
        /// All project data and current state is kept as a program Context.
        /// Every Context realted action as new project, loading new data etc. can by listened with events.
        /// </summary>
        public static List<HoneyType> GetAllHoneyTypesFromFile()
        {
            List<HoneyType> HoneyList = new List<HoneyType>();

            string HoneyName = "";
            string HoneyDescriptionName = "";
            Color HoneyMarkerColor = Color.Empty;

            using (StreamReader reader = new StreamReader("HoneyTypes.txt"))
            {
                while (true)
                {
                    HoneyName = reader.ReadLine();
                    if (HoneyName == null) break;
                    HoneyDescriptionName = reader.ReadLine();
                    HoneyMarkerColor = Color.FromName(reader.ReadLine());

                    HoneyList.Add(new HoneyType(HoneyName, HoneyDescriptionName, HoneyMarkerColor));
                }
            }
            return HoneyList;
        }
    }
}
