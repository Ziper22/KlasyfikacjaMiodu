using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.ViewPanel
{
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
        }

        private void SetContextEvents()
        {
            Session.Context.ImageChanged += Context_ImageChanged;
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
            if (Session.Context.Scale > 0.1f || e.Delta > 0)
            {
                Point loc = panel.Location;
                float width = panel.Size.Width;
                float height = panel.Size.Height;

                if (e.Delta > 0)
                    pollensImage.Scale(new SizeF(1.1f, 1.1f));
                else
                    pollensImage.Scale(new SizeF(0.90f, 0.90f));

                int x = (int)(loc.X + (width - panel.Size.Width) / 2);
                int y = (int)(loc.Y + (height - panel.Size.Height) / 2);
                panel.Location = new Point(x, y);

                float scale = pollensImage.Width / (float)pollensImage.Image.Width;
                Session.Context.Scale = scale;
            }
        }

        /// <summary>
        /// Called when Image in current Context is changing
        /// </summary>
        /// <param name="image"></param>
        private void Context_ImageChanged(Image image)
        {
            this.pollensImage.Image = image;
        }


        /// <summary>
        /// Called when Context in current session is changing
        /// </summary>
        /// <param name="context"></param>
        private void Session_ContextChanged(Context context)
        {
            pollensImage.Image = context.Image;
        }
    }
}
