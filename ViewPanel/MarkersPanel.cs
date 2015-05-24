using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private bool mouseDown = false, mouseMovedOnMarker = false, mouseMovedOnPanel = false;
        private int imagePositionX, imagePositionY, lastMarkerSize = 32, mouseX, mouseY;

        public MarkersPanel(Panel panel, PictureBox image)
        {
            this.panel = panel;
            this.image = image;
            panel.MouseClick += new MouseEventHandler(MarkersPanel_Click);
            panel.MouseDown += panel_MouseDown;
            panel.MouseUp += PanelOnMouseUp;
            panel.MouseMove += panel_MouseMove;
            Session.Changed += MarkersPanel_ContextChanged;
            image.Paint += image_Paint;
            SetContextEvents();
        }

        void image_Paint(object sender, PaintEventArgs e)
        {
            foreach (Marker marker in Session.Context.Markers)
            {
                marker.draw(e, Session.Context.Scale);
            }
        }

        void panel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMovedOnPanel = true;
        }

        private void PanelOnMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            mouseMovedOnPanel = false;
        }

        void panel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMovedOnPanel = false;
        }

        /// <summary>
        /// Sets Context events. Listeners should be set again after every Context change in current Session
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.MarkerAdded += Context_MarkerAdded;
            Session.Context.MarkerRemoved += Context_MarkerRemoved;
            Session.Context.HoneyTypeRemoved += Context_HoneyTypeRemoved;
            Session.Context.HoneyTypeEdited += Context_HoneyTypeEdited;
        }

        void Context_HoneyTypeEdited(HoneyType honeyType)
        {
            image.Refresh();
        }

        void Context_HoneyTypeRemoved(HoneyType honeyType)
        {
            foreach (Marker marker in Session.Context.Markers.ToArray())
            {
                if (marker.HoneyType.Equals(honeyType))
                    Session.Context.RemoveMarker(marker);
            }
        }

        private void Marker_Click(object sender, MouseEventArgs e)
        {
            MarkerPictureBox box = sender as MarkerPictureBox;
            if (box != null && e.Button == MouseButtons.Right)
            {
                if (!mouseMovedOnMarker)
                {
                    RemoveMarkerAction action = new RemoveMarkerAction(box.Marker);
                    Actions.RunAction(action);
                }
            }
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
            image.Refresh();
        }

        private void Context_MarkerAdded(Marker marker)
        {
            MarkerPictureBox p = new MarkerPictureBox(marker);
            p.Paint += image_Paint;


            p.BackgroundImage = MarkerImageCache.GetImageForHoneyType(marker.HoneyType);
            p.BackgroundImageLayout = ImageLayout.Zoom;

            int size = (int)(32 * Session.Context.Scale);
            p.Size = new Size(32, 32);
            p.Scale(new SizeF(Session.Context.Scale, Session.Context.Scale));

            p.Update();
            p.Location = new Point(marker.X, marker.Y);
            panel.Controls.Add(p);
            p.BringToFront();
            p.MouseClick += Marker_Click;
            p.MouseWheel += Marker_MouseWheel;
            p.MouseDown += Marker_MouseDown;
            p.MouseUp += Marker_MouseUp;
            p.MouseEnter += Marker_MouseEnter;
            p.MouseMove += Marker_MouseMove;

            image.BringToFront();
            image.Refresh();
        }

        private void MarkersPanel_Click(object sender, MouseEventArgs e)
        {
            HoneyType selectedHoneyType = Session.Context.SelectedHoneyType;
            if (selectedHoneyType != null)
            {
                if (!mouseMovedOnPanel && e.Button == MouseButtons.Left)
                {
                    float scale = Session.Context.Scale;

                    float x = (e.X) / scale;
                    float y = (e.Y) / scale;
                    //                x = Math.Max(lastMarkerSize / 2, Math.Min(image.Image.PhysicalDimension.Width - lastMarkerSize / 2, x));
                    //                y = Math.Max(lastMarkerSize / 2, Math.Min(image.Image.PhysicalDimension.Height - lastMarkerSize / 2, y));


                    Marker marker = new Marker((int)x, (int)y, (int)lastMarkerSize, selectedHoneyType);
                    AddMarkerAction action = new AddMarkerAction(marker);
                    Actions.RunAction(action);
                    image.Refresh();
                }
            }
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void Marker_MouseEnter(object sender, EventArgs e)
        {
            ((MarkerPictureBox)sender).Focus();
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void Marker_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
                mouseMovedOnMarker = true;
            MarkerPictureBox box = sender as MarkerPictureBox;
            if (box != null && mouseDown)
            {
                mouseMovedOnMarker = true;
                MarkerPictureBox box = sender as MarkerPictureBox;
                if (box != null && mouseDown)
                {
                    float scale = Session.Context.Scale;

                    int x = (int) (imagePositionX - (mouseX - Cursor.Position.X)/scale);
                    int y = (int) (imagePositionY - (mouseY - Cursor.Position.Y)/scale);

                    x = Math.Max(-box.Marker.Size/6, x);
                    x = (int) Math.Min(image.Image.PhysicalDimension.Width + box.Marker.Size/6f, x);

                    y = Math.Max(-box.Marker.Size/6, y);
                    y = (int) Math.Min(image.Image.PhysicalDimension.Height + box.Marker.Size/6f, y);

                    box.Marker.X = x;
                    box.Marker.Y = y;

                    box.Location = new Point(1, 1);
                    box.Update();

                    image.Refresh();
                }
            }
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void Marker_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseMovedOnMarker = false;
            MarkerPictureBox box = sender as MarkerPictureBox;
            if (box != null && mouseDown)
            {
                imagePositionX = box.Marker.X;
                imagePositionY = box.Marker.Y;
            }
            mouseX = Cursor.Position.X;
            mouseY = Cursor.Position.Y;
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void Marker_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            mouseMovedOnMarker = false;
        }

        /// <summary>
        /// Function responsible for handling Mouse events.
        /// Should not be invoked manually.
        /// </summary>
        private void Marker_MouseWheel(object sender, MouseEventArgs e)
        {
            MarkerPictureBox box = sender as MarkerPictureBox;
            if (box != null)
            {
                if (e.Delta > 0)
                {
                    box.Marker.Size = (int)(box.Marker.Size * 1.05f);
                    box.Marker.Size++;
                    if (box.Marker.Size > Math.Min(image.Image.PhysicalDimension.Width, image.Image.PhysicalDimension.Height) / 3)
                        box.Marker.Size = (int) (Math.Min(image.Image.PhysicalDimension.Width, image.Image.PhysicalDimension.Height) / 3);
                }
                else
                {
                    box.Marker.Size = (int)(box.Marker.Size * 0.95f);
                    box.Marker.Size--;
                    if (box.Marker.Size < 16)
                        box.Marker.Size = 16;
                }
                lastMarkerSize = box.Marker.Size;
                box.Scale(new SizeF(1, 1));

                //poprawianie pozycji
                int x = box.Marker.X;
                int y = box.Marker.Y;

                x = Math.Max(-box.Marker.Size / 6, x);
                x = (int)Math.Min(image.Image.PhysicalDimension.Width + box.Marker.Size / 6f, x);

                y = Math.Max(-box.Marker.Size / 6, y);
                y = (int)Math.Min(image.Image.PhysicalDimension.Height + box.Marker.Size / 6f, y);

                box.Marker.X = x;
                box.Marker.Y = y;
                box.Location = new Point(1, 1);

                image.Refresh();
            }
        }

        /// <summary>
        /// Called when Context in current session is changing
        /// </summary>
        private void MarkersPanel_ContextChanged(Context context)
        {
            SetContextEvents();
            panel.Controls.Clear();
            panel.Controls.Add(image);

            foreach (Marker marker in context.Markers)
            {
                Context_MarkerAdded(marker);
            }
            image.Refresh();
        }

        /// Author: Mariusz Gorzycki<para/>
        /// Graphic marker representation.
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
