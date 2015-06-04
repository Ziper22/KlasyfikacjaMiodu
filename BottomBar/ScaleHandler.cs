using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.BottomBar
{
    /// <summary>
    /// Author: Mariusz Gorzycki. <para/>
    /// Klasa odpowiedzialna za przechowywanie położenia znaczników oraz przemieszczania i skalowania obrazów.
    /// </summary>
    class ScaleHandler
    {
        private NumericUpDown scaleNumericUpDown;
        private bool myChanges = false;
        /// <summary>
        /// Konstruktor klasy.
        /// </summary>
        /// <param name="scaleNumericUpDown"></param>
        public ScaleHandler(NumericUpDown scaleNumericUpDown)
        {
            this.scaleNumericUpDown = scaleNumericUpDown;

            scaleNumericUpDown.ValueChanged += new EventHandler(ScaleNumeric_ScaleChanged);
            Session.Changed += Session_Changed;
            SetContextEvents();
            SetScaleText();
        }

        /// <summary>
        /// Funkcja wywoływana podczas zmian w bierzącej sesji.
        /// </summary>
        void Session_Changed(Context Context)
        {
            SetContextEvents();
        }

        /// <summary>
        /// Funkcja ustawiająca zdarzenia Contextu.
        /// </summary>>
        private void SetContextEvents()
        {
            Session.Context.ScaleChanged += Context_ScaleChanged;
        }

        /// <summary>
        /// Funkcja wywoływana podczas zmian Contextu w bierzącej sesji.
        /// </summary>
        private void Session_ContextChanged(Context context)
        {
            SetContextEvents();
        }

        /// <summary>
        /// Funkcja wywoływana podczas zmian wartości skali.
        /// </summary>
        private void ScaleNumeric_ScaleChanged(object sender, EventArgs e)
        {
            float scale = (float)scaleNumericUpDown.Value / 100f;
            if (!myChanges)
            {
                myChanges = true;
                Session.Context.Scale = scale;
                myChanges = false;
            }
        }

        /// <summary>
        /// Funkcja wywoływana podczas zmian sklai w Contexcie.
        /// </summary>
        private void Context_ScaleChanged(float scale)
        {
            if (!myChanges)
                SetScaleText(scale);
        }

        /// <summary>
        /// Funkcja odpowiedzialna za aktualizowanie wartości skali w komórce.
        /// </summary>
        private void SetScaleText(float scale)
        {
            myChanges = true;
            scaleNumericUpDown.Text = (int)(scale * 100) + "";
            myChanges = false;
        }

        /// <summary>
        /// Funkcja odpowiedzialna za aktualizowanie wartości skali w komórce.
        /// </summary>
        private void SetScaleText()
        {
            SetScaleText(Session.Context.Scale);
        }
    }
}
