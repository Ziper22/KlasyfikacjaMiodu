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
        private Button stoperButton;

        public TimeCounter(Label time, Button stoperButton)
        {
            this.time = time;
            this.stoperButton = stoperButton;
            SetOneSecondTimer();
            Session.Changed += Session_Changed;
            stoperButton.Click += stoperButton_Click;
        }

        void stoperButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
                PauseTimer();
            else
                StartTimer();
        }

        private void SetOneSecondTimer()
        {
            timer = new Timer();
            timer.Tick += TimeChanged;
            timer.Interval = 1000;
            StartTimer();
        }

        public void StartTimer()
        {
            timer.Start();
            stoperButton.BackgroundImage = Properties.Resources.stop;
            Session.Context.EditMode = true;
        }

        public void PauseTimer()
        {
            timer.Stop();
            stoperButton.BackgroundImage = Properties.Resources.start;
            Session.Context.EditMode = false;
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

        public bool Running
        {
            get { return timer.Enabled; }
        }
    }
}
