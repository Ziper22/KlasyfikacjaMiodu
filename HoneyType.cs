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
        public int ID { get; set; }
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
        public static bool operator ==(HoneyType h1, HoneyType h2)
        {
            if (h1.Name == h2.Name && h1.DescriptionName == h2.DescriptionName && h1.MarkerColor == h2.MarkerColor)
                return true;
            return false;
        }
        public static bool operator !=(HoneyType h1, HoneyType h2)
        {
            if (h1.Name == h2.Name && h1.DescriptionName == h2.DescriptionName && h1.MarkerColor == h2.MarkerColor)
                return false;
            return true;
        }
        public override bool Equals(object obj)
        {
            HoneyType h = (HoneyType)obj;
            if (this.Name == h.Name && this.DescriptionName == h.DescriptionName && this.MarkerColor == h.MarkerColor)
                return true;
            return false;
        }
        // Jakaś lepsza propozycja na przeciążenie tej funckji?
        public override int GetHashCode()
        {
            return this.ID;
        }
    }
}
