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
    public class Marker
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public HoneyType HoneyType { get; private set; }

        public Marker(int x, int y, HoneyType honeyType)
        {
            X = x;
            Y = y;
            HoneyType = honeyType;
        }

        public Marker(Point position, HoneyType honeyType)
        {
            X = position.X;
            Y = position.Y;
            HoneyType = honeyType;
        }
    }
}
