using System;
using System.Drawing;
using System.Windows.Forms;
using KlasyfikacjaMiodu.ActionsModule;

namespace KlasyfikacjaMiodu.ViewPanel
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Class responsible for handling Markers placement and image movement/scale
    /// </summary>
    public class MarkersPanel
    {
        private Panel panel;
        private PictureBox image;
        private NumericUpDown scaleNumericUpDown;
        private bool mouseDown = false, mouseMoved = false;
        private int xOffset, yOffset;

        public MarkersPanel(Panel panel, NumericUpDown scaleNumericUpDown, PictureBox image)
        {
            this.panel = panel;
            this.scaleNumericUpDown = scaleNumericUpDown;
            this.image = image;
            panel.MouseDown += new MouseEventHandler(MarkersPanel_MouseDown);
            panel.MouseUp += new MouseEventHandler(MarkersPanel_MouseUp);
            panel.MouseMove += new MouseEventHandler(MarkersPanel_MouseMove);
            panel.MouseEnter += new EventHandler(MarkersPanel_MouseEnter);
            panel.MouseClick += new MouseEventHandler(MarkersPanel_Click);
            panel.MouseWheel += new MouseEventHandler(MarkersPanel_MouseWheel);
            scaleNumericUpDown.ValueChanged += new EventHandler(MarkersPanel_ScaleChanged);
            Session.Context.ImageChanged += MarkersPanel_ImageChanged;
            Session.Changed += MarkersPanel_ContextChanged;
            Session.Context.MarkerAdded += Context_MarkerAdded;
            Session.Context.MarkerRemoved += Context_MarkerRemoved;
            UpdateScaleText();
        }

        private void Marker_Click(object sender, MouseEventArgs e)
        {
            panel.Controls.Remove((Control)sender);
        }

        private void Context_MarkerRemoved(Marker marker)
        {
            foreach (Control control in panel.Controls)
            {
                MarkerPictureBox box =  control as MarkerPictureBox;
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

            p.Size = new Size(32, 32);
            int x = Math.Min(image.Location.X + image.Size.Width - p.Size.Width, (Math.Max(0, marker.X - p.Size.Width / 2)));
            int y = Math.Min(image.Location.Y + image.Size.Height - p.Size.Height, (Math.Max(0, marker.Y - p.Size.Height / 2)));
            p.Location = new Point(x, y);
            panel.Controls.Add(p);
            p.BringToFront();
            p.MouseClick += Marker_Click;
        }

        private void MarkersPanel_Click(object sender, MouseEventArgs e)
        {
            if (!mouseMoved && e.Button == MouseButtons.Left)
            {
                Marker marker = new Marker(e.Location, 32, null);
                AddMarkerAction action = new AddMarkerAction(marker);
                Actions.RunAction(action);
            }
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void MarkersPanel_MouseEnter(object sender, EventArgs e)
        {
//            panel.Focus();
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void MarkersPanel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMoved = true;
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void MarkersPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseMoved = false;
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void MarkersPanel_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void MarkersPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            
        }

        private void MarkersPanel_ScaleChanged(object sender, EventArgs e)
        {
            float scale = (float)scaleNumericUpDown.Value / 100f;

            Point loc = panel.Location;
            float width2 = panel.Size.Width;
            float height2 = panel.Size.Height;

            int width = (int)(image.Image.PhysicalDimension.Width * scale);
            int height = (int)(image.Image.PhysicalDimension.Height * scale);
            panel.Size = new Size(width, height);

            int x = (int)(loc.X + (width2 - panel.Size.Width) / 2);
            int y = (int)(loc.Y + (height2 - panel.Size.Height) / 2);
            panel.Location = new Point(x, y);

            Session.Context.Scale = scale;
        }

        private void MarkersPanel_ImageChanged(Image image)
        {
            this.image.Image = image;
        }

        private void MarkersPanel_ContextChanged(Context context)
        {
            image.Image = context.Image;
        }

        /// <summary>
        /// Updates the Scale Label with proper % value.
        /// </summary>
        private void UpdateScaleText()
        {
            float scale = image.Width / (float)image.Image.Width;
            scaleNumericUpDown.Text = (int)(scale * 100) + "";

            Session.Context.Scale = scale;
        }

        public class MarkerPictureBox : PictureBox
        {
            public Marker Marker { get; private set; }

            public MarkerPictureBox(Marker marker)
            {
                this.Marker = marker;
            }
        }
    }
}
