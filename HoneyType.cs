using System;
using System.Collections;
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
        public string Name { get; set; }
        public string DescriptionName { get; set; }
        public Color MarkerColor { get; set; }

        public HoneyType(string name, string descriptionName, Color markerColor)
        {
            DescriptionName = descriptionName;
            Name = name;
            MarkerColor = markerColor;
        }

        protected bool Equals(HoneyType other)
        {
            return string.Equals(Name, other.Name) && string.Equals(DescriptionName, other.DescriptionName) && MarkerColor.Equals(other.MarkerColor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HoneyType)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DescriptionName != null ? DescriptionName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ MarkerColor.GetHashCode();
                return hashCode;
            }
        }
    }
}
