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
    /// Author: Mariusz Gorzycki. <para/>
    /// Reprezentuje typ miodu.
    /// </summary>
    [Serializable]
    public class HoneyType
    {
        public string Name { get; set; }
        public string DescriptionName { get; set; }
        public Color MarkerColor { get; set; }
        public float MinimalPollensPercentageAmount { get; set; }
        public bool Dirt { get; set; }
        /// <summary>
        /// Konstruktor HoneyType.
        /// </summary>
        public HoneyType()
        {

        }
        /// <summary>
        /// Konstuktor tworzący nowy typ miodu.
        /// </summary>
        /// <param name="name">Nazwa miodu</param>
        /// <param name="descriptionName">Opis miodu</param>
        /// <param name="linkedName">Druga nazwa miodu</param>
        /// <param name="markerColor">Kolor znacznika miodu</param>
        /// <param name="minimalPollensAmount">Minimalna liczba znaczników miodu wymagana do klasyfikacji</param>
        /// <param name="minimalPollensPercentageAmount">Miminalna wartość procentowa miodu wymagana do klasyfikacji</param>
        [Obsolete("Użyj drugiego konstruktora")]
        public HoneyType(string name, string descriptionName, string linkedName, Color markerColor, float minimalPollensAmount, float minimalPollensPercentageAmount)
        {
            Name = name;
            DescriptionName = descriptionName;
            MarkerColor = markerColor;
            MinimalPollensPercentageAmount = minimalPollensPercentageAmount;
            Dirt = false;
        }
        /// <summary>
        /// Drugi konstuktor tworzący nowy typ miodu.
        /// </summary>
        public HoneyType(string name, string descriptionName, Color markerColor, float minimalPollensPercentageAmount)
        {
            Name = name;
            DescriptionName = descriptionName;
            MarkerColor = markerColor;
            MinimalPollensPercentageAmount = minimalPollensPercentageAmount;
            Dirt = false;
        }
        /// <summary>
        /// Nadpisana funkcja ToString()
        /// </summary>
        public override string ToString()
        {
            return string.Format("Name: {0}, DescriptionName: {1}, MarkerColor: {2}, MinimalPollensPercentageAmount: {3}", Name, DescriptionName, MarkerColor, MinimalPollensPercentageAmount);
        }
        /// <summary>
        /// Funkcja porównująca dwa typy miodu.
        /// </summary>
        protected bool Equals(HoneyType other)
        {
            return string.Equals(Name, other.Name) && string.Equals(DescriptionName, other.DescriptionName) && MarkerColor.Equals(other.MarkerColor) && MinimalPollensPercentageAmount.Equals(other.MinimalPollensPercentageAmount);
        }
        /// <summary>
        /// Nadpisana funkcja porównująca dwa typy miodu.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HoneyType)obj);
        }
        /// <summary>
        /// Funkcja zwracająca HashCode
        /// </summary>
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
