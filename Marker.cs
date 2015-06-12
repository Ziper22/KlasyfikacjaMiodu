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
    /// Autor: Mariusz Gorzycki. <para/>
    /// Reprezentuje Marker z <see cref="HoneyType"/>.
    /// </summary>
    [Serializable]
    public class Marker
    {
        /// <summary>
        /// Właściwość zwracająca pozycję X.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Właściwość zwracająca pozycję Y.
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Właściwość zwracająca rozmiar.
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Właściwość zwracająca typ miodu.
        /// </summary>
        public HoneyType HoneyType { get; private set; }

        /// <summary>
        /// Konstruktor tworzący nowy Marker.
        /// </summary>
        /// <param name="x">Pozycja X dla znacznika</param>
        /// <param name="y">Pozycja Y dla znacznika</param>
        /// <param name="size">Rozmiar znacznika</param>
        /// <param name="honeyType">Typ miodu</param>
        public Marker(int x, int y, int size, HoneyType honeyType)
        {
            X = x;
            Y = y;
            Size = size;
            HoneyType = honeyType;
        }

        /// <summary>
        /// Konstruktor tworzący nowy Marker.
        /// </summary>
        /// <param name="position">Pozycja dla Markera</param>
        /// <param name="size">Rozmiar Markera</param>
        /// <param name="honeyType">Typ miodu</param>
        public Marker(Point position, int size, HoneyType honeyType)
            : this(position.X, position.Y, size, honeyType)
        { }
        /// <summary>
        /// Funkcja sprawdzająca czy dwa Markery są identyczne.
        /// </summary>
        protected bool Equals(Marker other)
        {
            return X == other.X && Y == other.Y && Size == other.Size && Equals(HoneyType, other.HoneyType);
        }
        /// <summary>
        ///  Funkcja sprawdzająca czy dwa Markery są identyczne.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Marker)obj);
        }
        /// <summary>
        /// Funckja zwracająca HashCode.
        /// </summary>
        /// <returns>Int HashCode</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Size;
                hashCode = (hashCode * 397) ^ (HoneyType != null ? HoneyType.GetHashCode() : 0);
                return hashCode;
            }
        }
        /// <summary>
        /// Funckja rysująca na ekranie znacznik.
        /// </summary>
        /// <param name="scale">Skala znacznika</param>
        public void draw(PaintEventArgs e, float scale)
        {
            Rectangle dest = new Rectangle((int)((X - Size / 2f) * scale), (int)((Y - Size / 2f) * scale), (int)(Size * scale), (int)(Size * scale));
            Image image = MarkerImageCache.GetImageForHoneyType(HoneyType);

            Rectangle src = new Rectangle(0, 0, (int)image.PhysicalDimension.Width, (int)image.PhysicalDimension.Height);
            e.Graphics.DrawImage(image, dest, src, GraphicsUnit.Pixel);
        }
        /// <summary>
        /// Funkcja zwracająca środek X.
        /// </summary>
        public int CenterX
        {
            get { return X - Size / 2; }
        }
        /// <summary>
        /// Funkcja zwracająca środek Y.
        /// </summary>
        public int CenterY
        {
            get { return Y - Size / 2; }
        }
    }
}
