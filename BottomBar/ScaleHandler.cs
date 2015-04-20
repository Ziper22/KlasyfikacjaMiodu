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
    /// Author: Mariusz Gorzycki<para/>
    /// Class responsible for handling Markers placement and image movement/scale
    /// </summary>
    class ScaleHandler
    {
        private NumericUpDown scaleNumericUpDown;
        private bool myChanges = false;

        public ScaleHandler(NumericUpDown scaleNumericUpDown)
        {
            this.scaleNumericUpDown = scaleNumericUpDown;

            scaleNumericUpDown.ValueChanged += new EventHandler(ScaleNumeric_ScaleChanged);
            Session.Changed += Session_Changed;
            SetContextEvents();
            SetScaleText();
        }

        /// <summary>
        /// Called when Context in current session is changing
        /// </summary>
        void Session_Changed(Context Context)
        {
            SetContextEvents();
        }

        /// <summary>
        /// Sets Context events. Listeners should be set again after every Context change in current Session
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.ScaleChanged += Context_ScaleChanged;
        }

        /// <summary>
        /// Called when Context in current session is changing
        /// </summary>
        private void Session_ContextChanged(Context context)
        {
            SetContextEvents();
        }

        /// <summary>
        /// Called when scale value was changed directly from BottomBar
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
        /// Called when scale in current Context is changing
        /// </summary>
        private void Context_ScaleChanged(float scale)
        {
            if (!myChanges)
                SetScaleText(scale);
        }

        /// <summary>
        /// Updates the Scale Label with given scale value.
        /// </summary>
        private void SetScaleText(float scale)
        {
            myChanges = true;
            scaleNumericUpDown.Text = (int)(scale * 100) + "";
            myChanges = false;
        }

        /// <summary>
        /// Updates the Scale Label with proper scale value from current Context.
        /// </summary>
        private void SetScaleText()
        {
            SetScaleText(Session.Context.Scale);
        }
    }
}
