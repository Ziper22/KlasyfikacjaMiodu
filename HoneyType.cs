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
        [Obsolete("Tylko 1 nazwa będzie używana")]
        public string DescriptionName { get; set; }
        [Obsolete("Tylko 1 nazwa będzie używana")]
        public string LinkedName { get; set; }
        public Color MarkerColor { get; set; }
        public float MinimalPollensAmount { get; set; }
        public float MinimalPollensPercentageAmount { get; set; }

        [Obsolete("Tylko 1 nazwa będzie używana")]
        public HoneyType(string name, string descriptionName, string linkedName, Color markerColor, float minimalPollensAmount, float minimalPollensPercentageAmount)
        {
            Name = name;
            DescriptionName = descriptionName;
            LinkedName = linkedName;
            MarkerColor = markerColor;
            MinimalPollensAmount = minimalPollensAmount;
            MinimalPollensPercentageAmount = minimalPollensPercentageAmount;
        }

        public HoneyType(string name, Color markerColor, float minimalPollensAmount, float minimalPollensPercentageAmount)
        {
            Name = name;
            MarkerColor = markerColor;
            MinimalPollensAmount = minimalPollensAmount;
            MinimalPollensPercentageAmount = minimalPollensPercentageAmount;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, DescriptionName: {1}, LinkedName: {2}, MarkerColor: {3}, MinimalPollensAmount: {4}, MinimalPollensPercentageAmount: {5}", Name, DescriptionName, LinkedName, MarkerColor, MinimalPollensAmount, MinimalPollensPercentageAmount);
        }

        protected bool Equals(HoneyType other)
        {
            return string.Equals(Name, other.Name) && string.Equals(DescriptionName, other.DescriptionName) && string.Equals(LinkedName, other.LinkedName) && MarkerColor.Equals(other.MarkerColor) && MinimalPollensAmount.Equals(other.MinimalPollensAmount) && MinimalPollensPercentageAmount.Equals(other.MinimalPollensPercentageAmount);
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
                hashCode = (hashCode * 397) ^ (LinkedName != null ? LinkedName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ MarkerColor.GetHashCode();
                hashCode = (hashCode * 397) ^ MinimalPollensAmount.GetHashCode();
                hashCode = (hashCode * 397) ^ MinimalPollensPercentageAmount.GetHashCode();
                return hashCode;
            }
        }
    }
}
