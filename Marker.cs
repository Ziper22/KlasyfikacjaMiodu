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
    /// Represents a marker with <see cref="HoneyType"/>.
    /// </summary>
    [Serializable]
    public class Marker
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Size { get; private set; }
        public HoneyType HoneyType { get; private set; }

        public Marker(int x, int y, int size, HoneyType honeyType)
        {
            X = x;
            Y = y;
            Size = size;
            HoneyType = honeyType;
        }

        public Marker(Point position, int size, HoneyType honeyType)
            : this(position.X, position.Y, size, honeyType)
        {}

        protected bool Equals(Marker other)
        {
            return X == other.X && Y == other.Y && Equals(HoneyType, other.HoneyType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Marker)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ (HoneyType != null ? HoneyType.GetHashCode() : 0);
                return hashCode;
            }
        }

        public int XMinusHalfSize
        {
            get { return X-Size/2; }
        }

        public int YMinusHalfSize
        {
            get { return Y-Size/2; }
        }
    }
}
