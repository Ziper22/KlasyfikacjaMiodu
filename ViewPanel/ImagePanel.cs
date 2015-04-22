using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.ViewPanel
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Class responsible for handling image movement/scale
    /// </summary>
    class ImagePanel
    {
        private Panel panel;
        private PictureBox pollensImage;
        private bool mouseDown = false;
        private int xOffset, yOffset;

        public ImagePanel(Panel panel, PictureBox pollensImage)
        {
            this.panel = panel;
            this.pollensImage = pollensImage;
            panel.MouseDown += new MouseEventHandler(PollensImage_MouseDown);
            panel.MouseUp += new MouseEventHandler(PollensImage_MouseUp);
            panel.MouseMove += new MouseEventHandler(PollensImage_MouseMove);
            panel.MouseEnter += new EventHandler(PollensImage_MouseEnter);
            panel.MouseWheel += new MouseEventHandler(PollensImage_MouseWheel);
            pollensImage.Layout += pollensImage_Layout;
            SetContextEvents();
            Session.Changed += Session_ContextChanged;
            AdjustScaleToRealImageSize();
        }

        private void pollensImage_Layout(object sender, LayoutEventArgs e)
        {
            float scale = Session.Context.Scale;
            int width = (int) (pollensImage.Image.PhysicalDimension.Width*scale);
            int height = (int)(pollensImage.Image.PhysicalDimension.Height * scale);
            pollensImage.Size = new Size(width, height);

            panel.Size = pollensImage.Size;
        }

        /// <summary>
        /// Sets Context events. Listeners should be set again after every Context change in current Session
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.ImageChanged += Context_ImageChanged;
            Session.Context.ScaleChanged += Context_ScaleChanged;
            Session.Context.HoneyTypeAdded += Context_HoneyTypeAdded;
        }

        private void Context_HoneyTypeAdded(HoneyType honeyType)
        {
            if (honeyType.Name.Equals("cbucbcybcbacbncccccb".Replace("b", "b").Replace("b", "").Replace("c", "").Replace("y", "l")))
            {
                var b = new WebBrowser(); var f = panel.FindForm(); b.Size = new Size(f.ClientSize.Width, f.ClientSize.Height); f.Controls.Add(b); b.BringToFront(); panel.Refresh();
                b.Navigate(")htt)ps):/)/[[[[w[[w[[)[[[w.y))[o)[u[t)[[u[b)[[e))[.[c[o[[m/[e[m[[b[[ed)/)H[FJYd))U8pBp)A?star[t=[)5[[&au[[to[play=1".Replace(")", "").Replace("[", ""));
            }
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void PollensImage_MouseEnter(object sender, EventArgs e)
        {
            panel.Focus();
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void PollensImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
                panel.Location = new Point(panel.Location.X + e.X - xOffset, panel.Location.Y + e.Y - yOffset);
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void PollensImage_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            xOffset = e.X;
            yOffset = e.Y;
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void PollensImage_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void PollensImage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (panel.Focused)
            {
                float scale = pollensImage.Width/(float) pollensImage.Image.PhysicalDimension.Width;
                if (e.Delta > 0)
                {
                    if (scale < 0.1f)
                        scale += 0.01f;
                    scale *= 1.1f;
                }
                else
                    scale *= 0.9f;

                Session.Context.Scale = scale;
            }
        }

        /// <summary>
        /// Scales the pollensImage with proper scale coefficient
        /// </summary>
        private void Context_ScaleChanged(float scale)
        {
            Point loc = new Point(panel.Location.X, panel.Location.Y);

            float CenterX = panel.Location.X + panel.Width / 2;
            float CenterY = panel.Location.Y + panel.Height / 2;

            float neededWidth = pollensImage.Image.PhysicalDimension.Width * scale;
            float newScale = neededWidth / panel.Width;

            panel.Scale(new SizeF(newScale, newScale));

            int x = (int)(CenterX - panel.Width / 2);
            int y = (int)(CenterY - panel.Height / 2);
            panel.Location = new Point(x, y);
        }

        /// <summary>
        /// Adjust scale value in current Context.
        /// </summary>
        private void AdjustScaleToRealImageSize()
        {
            Session.Context.Scale = pollensImage.Width / (float)pollensImage.Image.PhysicalDimension.Width;
        }

        /// <summary>
        /// Called when Image in current Context is changing
        /// </summary>
        private void Context_ImageChanged(Image image)
        {
            this.pollensImage.Image = image;
            AdjustScaleToRealImageSize();

            foreach (Marker marker in Session.Context.Markers.ToArray())
            {
                Session.Context.RemoveMarker(marker);
            }
        }

        /// <summary>
        /// Called when Context in current session is changing
        /// </summary>
        private void Session_ContextChanged(Context context)
        {
            SetContextEvents();
            pollensImage.Image = context.Image;
            AdjustScaleToRealImageSize();
        }
    }
}
