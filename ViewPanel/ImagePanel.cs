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
            SetContextEvents();
            Session.Changed += Session_ContextChanged;
            AdjustScaleToRealImageSize();
        }

        /// <summary>
        /// Sets Context events. Listeners should be set again after every Context change in current Session
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.ImageChanged += Context_ImageChanged;
            Session.Context.ScaleChanged += Context_ScaleChanged;
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
            float scale = pollensImage.Width / (float)pollensImage.Image.PhysicalDimension.Width;
            if (e.Delta > 0)
            {
                if (scale < 0.1f)
                    scale += 0.01f;
                scale *= 1.1f;
            }
            else
                scale *= 0.9f;

            if (scale < 0.01f)
                scale = 0.01f;

            Session.Context.Scale = scale;
        }

        /// <summary>
        /// Scales the pollensImage with proper scale coefficient
        /// </summary>
        private void Context_ScaleChanged(float scale)
        {
            float width2 = panel.Size.Width;
            float height2 = panel.Size.Height;

            float width = (pollensImage.Image.PhysicalDimension.Width * scale);
            float height = (pollensImage.Image.PhysicalDimension.Height * scale);
            panel.Size = new Size((int)width, (int)height);

            int x = (int)(panel.Location.X + (width2 - width) / 2f);
            int y = (int)(panel.Location.Y + (height2 - height) / 2f);
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
        }

        /// <summary>
        /// Called when Context in current session is changing
        /// </summary>
        private void Session_ContextChanged(Context context)
        {
            pollensImage.Image = context.Image;
            SetContextEvents();
        }
    }
}
