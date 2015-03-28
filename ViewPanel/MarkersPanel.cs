using System;
using System.Drawing;
using System.Windows.Forms;
using KlasyfikacjaMiodu.ActionsModule;

namespace KlasyfikacjaMiodu.ViewPanel
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Class responsible for handling Markers placement and movement/scale
    /// </summary>
    public class MarkersPanel
    {
        private Panel panel;
        private PictureBox image;
        private bool mouseDown = false, mouseMoved = false;
        private int xOffset, yOffset;

        public MarkersPanel(Panel panel, PictureBox image)
        {
            this.panel = panel;
            this.image = image;
            panel.MouseClick += new MouseEventHandler(MarkersPanel_Click);
            Session.Changed += MarkersPanel_ContextChanged;
            SetContextEvents();
        }

        /// <summary>
        /// Sets Context events. Listeners should be set again after every Context change in current Session
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.MarkerAdded += Context_MarkerAdded;
            Session.Context.MarkerRemoved += Context_MarkerRemoved;
        }

        private void Marker_Click(object sender, MouseEventArgs e)
        {
            panel.Controls.Remove((Control)sender);
        }

        private void Context_MarkerRemoved(Marker marker)
        {
            foreach (Control control in panel.Controls)
            {
                MarkerPictureBox box = control as MarkerPictureBox;
                if (box != null && box.Marker.Equals(marker))
                {
                    panel.Controls.Remove(box);
                    break;
                }
            }
        }

        private void Context_MarkerAdded(Marker marker)
        {
            MarkerPictureBox p = new MarkerPictureBox(marker);

            Image im = image.Image;
            Bitmap b = new Bitmap(im);
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    b.SetPixel(i, j, Color.DeepSkyBlue);
                }
            }
            p.Image = (Image)b;

            int size = (int)(32 * Session.Context.Scale);
            p.Size = new Size(32, 32);
            p.Scale(Session.Context.Scale);

            p.Update();
            p.Location = new Point(marker.X, marker.Y);
            panel.Controls.Add(p);
            p.BringToFront();
            p.MouseClick += Marker_Click;
        }

        private void MarkersPanel_Click(object sender, MouseEventArgs e)
        {
            if (!mouseMoved && e.Button == MouseButtons.Left)
            {
                float scale = Session.Context.Scale;
                float markerSize = 32;

                float x = (e.X) / scale;
                float y = (e.Y) / scale;
                x = Math.Max(markerSize / 2, Math.Min(image.Image.PhysicalDimension.Width - markerSize / 2, x));
                y = Math.Max(markerSize/2, Math.Min(image.Image.PhysicalDimension.Height - markerSize/2, y));
                Marker marker = new Marker((int)x, (int)y, (int)markerSize, null);
                AddMarkerAction action = new AddMarkerAction(marker);
                Actions.RunAction(action);
            }
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void Marker_MouseEnter(object sender, EventArgs e)
        {
            ((MarkerPictureBox) sender).Focus();
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void Marker_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMoved = true;
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void Marker_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseMoved = false;
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void Marker_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void Marker_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// Called when Context in current session is changing
        /// </summary>
        private void MarkersPanel_ContextChanged(Context context)
        {
            SetContextEvents();
        }


        public class MarkerPictureBox : PictureBox
        {
            public Marker Marker { get; private set; }

            public MarkerPictureBox(Marker marker)
            {
                this.Marker = marker;
                this.LocationChanged += MarkerPictureBox_LocationChanged;
                this.SizeChanged += MarkerPictureBox_SizeChanged;
                this.Layout += MarkerPictureBox_SizeChanged;
                this.Layout += MarkerPictureBox_LocationChanged;
            }

            void MarkerPictureBox_SizeChanged(object sender, EventArgs e)
            {
                float scale = Session.Context.Scale;
                Size = new Size((int)(Marker.Size * scale), (int)(Marker.Size * scale));
            }

            void MarkerPictureBox_LocationChanged(object sender, EventArgs e)
            {
                float scale = Session.Context.Scale;

                int x = (int)(Marker.CenterX * scale);
                int y = (int)(Marker.CenterY * scale);

                Location = new Point(x, y);
            }
        }
    }
}
