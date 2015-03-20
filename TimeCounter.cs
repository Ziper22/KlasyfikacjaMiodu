using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Handles working time label updates/
    /// </summary>
    class TimeCounter
    {
        private Timer timer;
        private Label time;

        public TimeCounter(Label time)
        {
            this.time = time;
            setOneSecondTimer();
            Session.Changed += Session_Changed;
        }

        private void setOneSecondTimer()
        {
            timer = new Timer();
            timer.Tick += TimeChanged;
            timer.Interval = 1000;
            timer.Start();
        }

        private void TimeChanged(Object sender, EventArgs args)
        {
            Session.Context.TimeSpan = Session.Context.TimeSpan.Add(new TimeSpan(0, 0, 1));
            time.Text = Session.Context.TimeSpan.ToString();
        }

        private void Session_Changed(Context context)
        {
            time.Text = context.TimeSpan.ToString();
        }
    }
}
