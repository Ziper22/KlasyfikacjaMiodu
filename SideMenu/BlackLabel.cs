﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// Author: Mariusz Gorzycki<para/>
    /// Label with black text when disabled.
    class BlackLabel : Label
    {
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
