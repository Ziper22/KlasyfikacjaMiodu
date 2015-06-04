using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
{

    /// <summary>
    /// Author: Mariusz Gorzycki.   <para/>
    /// Klasa obsługująca pole tekstowe z czarnym tekstem kiedy nie jest aktywne.
    /// </summary>
    class BlackLabel : Label
    {
        /// <summary>
        /// Funkcja malująca.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (Enabled)
            {
                base.OnPaint(e);
                return;
            }

            //custom drawing
            using (Brush aBrush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(Text, Font, aBrush, ClientRectangle);
            }
        }
    }
}
