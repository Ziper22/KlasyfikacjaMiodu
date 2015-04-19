using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlasyfikacjaMiodu.ViewPanel;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Represents a marker with <see cref="HoneyType"/>.
    /// </summary>
    [Serializable]
    public class Marker
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
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
            return X == other.X && Y == other.Y && Size == other.Size && Equals(HoneyType, other.HoneyType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Marker) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode*397) ^ Y;
                hashCode = (hashCode*397) ^ Size;
                hashCode = (hashCode*397) ^ (HoneyType != null ? HoneyType.GetHashCode() : 0);
                return hashCode;
            }
        }

        public void draw(PaintEventArgs e, float scale)
        {
            Rectangle dest = new Rectangle((int)((X - Size / 2f) * scale), (int)((Y - Size / 2f) * scale), (int)(Size * scale), (int)(Size * scale));
            Image image = MarkerImageCache.GetImageForHoneyType(HoneyType);

            Rectangle src = new Rectangle(0,0, (int) image.PhysicalDimension.Width, (int) image.PhysicalDimension.Height);
            e.Graphics.DrawImage(image, dest, src, GraphicsUnit.Pixel);
        }

        public int CenterX
        {
            get { return X-Size/2; }
        }

        public int CenterY
        {
            get { return Y-Size/2; }
        }
    }
}
