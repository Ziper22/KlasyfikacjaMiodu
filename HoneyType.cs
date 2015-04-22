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
    [Serializable]
    public class HoneyType
    {
        public string Name { get; set; }
        public string DescriptionName { get; set; }
        public Color MarkerColor { get; set; }
        public float MinimalPollensPercentageAmount { get; set; }

        public HoneyType()
        {

        }

        [Obsolete("Użyj drugiego konstruktora")]
        public HoneyType(string name, string descriptionName, string linkedName, Color markerColor, float minimalPollensAmount, float minimalPollensPercentageAmount)
        {
            Name = name;
            DescriptionName = descriptionName;
            MarkerColor = markerColor;
            MinimalPollensPercentageAmount = minimalPollensPercentageAmount;
        }

        public HoneyType(string name, string descriptionName, Color markerColor, float minimalPollensPercentageAmount)
        {
            Name = name;
            DescriptionName = descriptionName;
            MarkerColor = markerColor;
            MinimalPollensPercentageAmount = minimalPollensPercentageAmount;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, DescriptionName: {1}, MarkerColor: {2}, MinimalPollensPercentageAmount: {3}", Name, DescriptionName, MarkerColor, MinimalPollensPercentageAmount);
        }

        protected bool Equals(HoneyType other)
        {
            return string.Equals(Name, other.Name) && string.Equals(DescriptionName, other.DescriptionName) && MarkerColor.Equals(other.MarkerColor) && MinimalPollensPercentageAmount.Equals(other.MinimalPollensPercentageAmount);
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
                hashCode = (hashCode * 397) ^ MinimalPollensPercentageAmount.GetHashCode();
                return hashCode;
            }
        }
    }
}
