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
        private string FilePath;
        private List<HoneyType> HoneyList { get; set; }

        public DB()
        {
            this.FilePath = "HoneyTypes.txt";

            if (!File.Exists(FilePath))
            {
                FileStream fs = File.Create(FilePath);
                fs.Close();
            }

            HoneyList = this.GetAllHoneyTypesFromFile();
        }
        public List<HoneyType> GetHoneyList
        {
            get
            {
                return this.HoneyList;
            }
        }
        public List<HoneyType> GetAllHoneyTypesFromFile()
        {
            List<HoneyType> HoneyList = new List<HoneyType>();

            string HoneyName = "";
            string HoneyDescriptionName = "";
            Color HoneyMarkerColor = Color.Empty;
            int HoneyID = 0;

            using (StreamReader reader = new StreamReader(this.FilePath))
            {
                while (true)
                {
                HoneyName = reader.ReadLine();
                if (HoneyName == null) break;
                HoneyDescriptionName = reader.ReadLine();
                HoneyMarkerColor = Color.FromName(reader.ReadLine());
                HoneyID = Convert.ToInt32(reader.ReadLine());
                HoneyType tmp = new HoneyType(HoneyID, HoneyName, HoneyDescriptionName, HoneyMarkerColor);
                HoneyList.Add(tmp);
                }
            }
            return HoneyList;
        }
        public bool AddNewHoneyType(string HoneyName, string HoneyDescriptionName, Color HoneyMarkerColor)
        {
            HoneyType NewHoneyType = new HoneyType(HoneyList.Count+1,HoneyName,HoneyDescriptionName,HoneyMarkerColor);

            if (this.HoneyList.Exists(element => element == NewHoneyType)) return false;

            HoneyList.Add(new HoneyType(this.HoneyList.Count + 1, HoneyName, HoneyDescriptionName, HoneyMarkerColor));

            return true;
        }
        public bool EditHoneyType(string HoneyNameToEdit,string NewName, string NewDescriptionName, Color NewMarkerColor)
        {
           int OldHoneyIndex = this.GetHoneyTypeIndexByName(HoneyNameToEdit);
            if (OldHoneyIndex == -1) return false;

            this.HoneyList[OldHoneyIndex].Name = NewName;
            this.HoneyList[OldHoneyIndex].DescriptionName = NewDescriptionName;
            this.HoneyList[OldHoneyIndex].MarkerColor = NewMarkerColor;

            return true;
        }

        public int GetHoneyTypeIndexByName(string HoneyName)
        {
            if (this.HoneyList.Exists(element => element.Name == HoneyName)) 
                return HoneyList.FindIndex(element => element.Name == HoneyName);

            return -1;
        }
        public void SaveHoneyTypesToFile()
        {
            using (StreamWriter writer = new StreamWriter(this.FilePath))
            {
                foreach(HoneyType honey in HoneyList)
                {
                
                    writer.WriteLine(honey.Name);
                    writer.WriteLine(honey.DescriptionName);
                    writer.WriteLine(honey.MarkerColor.Name);
                    writer.WriteLine(honey.ID);
                }
            }
        }
        public void DeleteHoneyType(string HoneyName)
        {
            if (this.HoneyList.Exists(element => element.Name == HoneyName))
                this.HoneyList.RemoveAt(this.HoneyList.FindIndex(element => element.Name == HoneyName));
        }
    }
}

/*
 * public class HoneyType
    {
        public string Name { get; set; }
        public string DescriptionName { get; set; }
        public Color MarkerColor { get; set; }

        public HoneyType(int ID,string name, string descriptionName, Color markerColor)
        {
 *          this.ID = ID;
            DescriptionName = descriptionName;
            Name = name;
            MarkerColor = markerColor;

        }
    }
 */
