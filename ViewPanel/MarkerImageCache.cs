using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyfikacjaMiodu.ViewPanel
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Caches Marker images for faster usage.
    /// </summary>
    public static class MarkerImageCache
    {
        private static Dictionary<HoneyType, Image> cache = new Dictionary<HoneyType, Image>();

        public static void Initialize()
        {
            
        }
    }
}
