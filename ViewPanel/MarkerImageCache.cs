using System.Collections.Generic;
using System.Drawing;

namespace KlasyfikacjaMiodu.ViewPanel
{
    /// <summary>
    ///     Author: Mariusz Gorzycki
    ///     <para />
    ///     Caches Marker images for faster usage.
    /// </summary>
    public static class MarkerImageCache
    {
        private static readonly Dictionary<HoneyType, Image> cache = new Dictionary<HoneyType, Image>();

        public static void Initialize()
        {
            Session.Changed += Session_Changed;
        }

        private static void Session_Changed(Context Context)
        {
            Clear();
        }

        private static void Clear()
        {
            cache.Clear();
        }

        public static Image GetImageForHoneyType(HoneyType honeyType)
        {
            if (cache.ContainsKey(honeyType))
            {
                Image image;
                cache.TryGetValue(honeyType, out image);
                return image;
            }
            else
            {
                Image image = GetColoredXImage(honeyType.MarkerColor);
                cache.Add(honeyType, image);
                return image;
            }
        }

        private static Image GetColoredXImage(Color color)
        {
            Bitmap b = new Bitmap(Properties.Resources.marker128);
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    if (b.GetPixel(i, j).A >= 10)
                        b.SetPixel(i, j, color);
                    else
                        b.SetPixel(i, j, Color.Transparent);
                }
            }

//            Bitmap b = new Bitmap(128, 128);
//            for (int i = 0; i < b.Width; i++)
//            {
//                for (int j = 0; j < b.Height; j++)
//                {
//                    b.SetPixel(i, j, color);
//                }
//            }
            return b;
        }
    }
}