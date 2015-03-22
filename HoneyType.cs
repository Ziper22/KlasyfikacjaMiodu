using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Represents a type of honey.
    /// </summary>
    public class HoneyType
    {
        public int ID { get; }
        public string Name { get; set; }
        public string DescriptionName { get; set; }
        public Color MarkerColor { get; set; }

        public HoneyType(int ID,string name, string descriptionName, Color markerColor)
        {
            this.ID = ID;
            DescriptionName = descriptionName;
            Name = name;
            MarkerColor = markerColor;

        }
    }
}
