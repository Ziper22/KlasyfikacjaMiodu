using System;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.BottomBar
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
            SetOneSecondTimer();
            Session.Changed += Session_Changed;
        }

        private void SetOneSecondTimer()
        {
            timer = new Timer();
            timer.Tick += TimeChanged;
            timer.Interval = 1000;
            timer.Start();
        }

        private void TimeChanged(Object sender, EventArgs args)
        {
            if (Session.Context.BlockedView)
                return;

            Session.Context.TimeSpan = Session.Context.TimeSpan.Add(new TimeSpan(0, 0, 1));
            time.Text = Session.Context.TimeSpan.ToString();
        }

        private void Session_Changed(Context context)
        {
            time.Text = context.TimeSpan.ToString();
        }
    }
}
