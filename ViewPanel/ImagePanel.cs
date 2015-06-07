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
    /// Autor: Mariusz Gorzycki<para/>
    /// Klasa odpowiedzialna za przetrzymywanie zdjęcia i skalowanie go.
    /// </summary>
    class ImagePanel
    {
        private Panel panel;
        private PictureBox pollensImage;
        private Form form;
        private bool mouseDown = false;
        private int xOffset, yOffset;
        /// <summary>
        /// Konstuktor klasy.
        /// </summary>
        public ImagePanel(Panel panel, PictureBox pollensImage, Form form)
        {
            this.panel = panel;
            this.pollensImage = pollensImage;
            this.form = form;
            panel.MouseDown += new MouseEventHandler(PollensImage_MouseDown);
            panel.MouseUp += new MouseEventHandler(PollensImage_MouseUp);
            panel.MouseMove += new MouseEventHandler(PollensImage_MouseMove);
            panel.MouseEnter += new EventHandler(PollensImage_MouseEnter);
            panel.MouseWheel += new MouseEventHandler(PollensImage_MouseWheel);
            pollensImage.Layout += pollensImage_Layout;
            SetContextEvents();
            Session.Changed += Session_ContextChanged;
            AdjustScaleToRealImageSize();
            CenterImage();

            form.SizeChanged += form_SizeChanged;
        }
        /// <summary>
        /// Funkcja wywoływana po zmianie rozmiaru.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void form_SizeChanged(object sender, EventArgs e)
        {
            CenterImage();
        }
        /// <summary>
        /// Funkcja odpowiedzialna za ustawienie rozmiaru panelu.
        /// </summary>
        private void pollensImage_Layout(object sender, LayoutEventArgs e)
        {
            if (pollensImage.Image != null)
            {
                float scale = Session.Context.Scale;
                int width = (int) (pollensImage.Image.PhysicalDimension.Width*scale);
                int height = (int) (pollensImage.Image.PhysicalDimension.Height*scale);
                pollensImage.Size = new Size(width, height);

                panel.Size = pollensImage.Size;
            }
        }

        /// <summary>
        /// Ustawia zdarzenia Contextu. Nasłuchiwacze powinny być ustawione ponownie po każdej zmianie Contextu w aktualnej sesji.
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.ImageChanged += Context_ImageChanged;
            Session.Context.ScaleChanged += Context_ScaleChanged;
            Session.Context.HoneyTypeAdded += Context_HoneyTypeAdded;
        }
        /// <summary>
        /// Funkcja obsługująca dodanie nowego typu miodu do Contextu.
        /// </summary>
        private void Context_HoneyTypeAdded(HoneyType honeyType)
        {

        }

        /// <summary>
        /// Funkcja obsługująca zdarzenia myszy.
        /// Nie powinna być wywoływana manualnie.
        /// </summary>
        private void PollensImage_MouseEnter(object sender, EventArgs e)
        {
            panel.Focus();
        }

        /// <summary>
        /// Funkcja obsługująca zdarzenia myszy.
        /// Nie powinna być wywoływana manualnie.
        /// </summary>
        private void PollensImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && e.Button != MouseButtons.Left)
                panel.Location = new Point(panel.Location.X + e.X - xOffset, panel.Location.Y + e.Y - yOffset);
        }

        /// <summary>
        /// Funkcja obsługująca zdarzenia myszy.
        /// Nie powinna być wywoływana manualnie.
        /// </summary>
        private void PollensImage_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            xOffset = e.X;
            yOffset = e.Y;
        }

        /// <summary>
        /// Funkcja obsługująca zdarzenia myszy.
        /// Nie powinna być wywoływana manualnie.
        /// </summary>
        private void PollensImage_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        //// <summary>
        /// Funkcja obsługująca zdarzenia myszy.
        /// Nie powinna być wywoływana manualnie.
        /// </summary>
        private void PollensImage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (panel.Focused && pollensImage.Image != null)
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

                if (scale > 9.999)
                    scale = 9.999f;

                Session.Context.Scale = scale;
            }
        }

        /// <summary>
        /// Skaluje obrazki pyłków z odpowiednią skalą.
        /// </summary>
        private void Context_ScaleChanged(float scale)
        {
            if (pollensImage.Image != null)
            {
                Point loc = new Point(panel.Location.X, panel.Location.Y);

                float CenterX = panel.Location.X + panel.Width/2;
                float CenterY = panel.Location.Y + panel.Height/2;


                float neededWidth = pollensImage.Image.PhysicalDimension.Width*scale;
                float newScale = neededWidth/panel.Width;

                panel.Scale(new SizeF(newScale, newScale));

                int x = (int) (CenterX - panel.Width/2);
                int y = (int) (CenterY - panel.Height/2);
                panel.Location = new Point(x, y);
            }
        }

        /// <summary>
        /// Dopasowuje wartość skali w aktualnym Context.
        /// </summary>
        private void AdjustScaleToRealImageSize()
        {
            if (pollensImage.Image != null)
                Session.Context.Scale = pollensImage.Width / (float)pollensImage.Image.PhysicalDimension.Width;
        }
        /// <summary>
        /// Funkcja ustawiająca obraz na środku.
        /// </summary>
        private void CenterImage()
        {
            panel.Location = new Point(form.ClientSize.Width / 2 - panel.Width / 2, form.ClientSize.Height / 2 - panel.Height / 2);
        }

        //// <summary>
        /// Wywoływana gdy obraz w aktualnym Context został zmieniony.
        /// </summary>
        private void Context_ImageChanged(Image image)
        {
            this.pollensImage.Image = image;
            AdjustScaleToRealImageSize();

            foreach (Marker marker in Session.Context.Markers.ToArray())
            {
                Session.Context.RemoveMarker(marker);
            }

            CenterImage();
        }

        /// <summary>
        /// Wywoływana gdy obraz w aktualnej sesji został zmieniony.
        /// </summary>
        private void Session_ContextChanged(Context context)
        {
            SetContextEvents();
            pollensImage.Image = context.Image;
            AdjustScaleToRealImageSize();

            CenterImage();
        }
    }
}
