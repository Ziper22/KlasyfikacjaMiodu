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
            stoperButton.Click += stoperButton_Click;

            SetContextEvents();
            Session.Changed += Session_ContextChanged;
        }

        void stoperButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {

                PauseTimer();
                MainForm.SetEditMode((MainForm)MainForm.ActiveForm,false);
            }
            else
            {
                StartTimer();
                MainForm.SetEditMode((MainForm)MainForm.ActiveForm,true);
            }
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
        }

        private void ContextOnTimeChanged(TimeSpan timeSpan)
        {
            time.Text = timeSpan.ToString();
        }

        /// <summary>
        /// Sets Context events. Listeners should be set again after every Context change in current Session
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.TimeChanged += ContextOnTimeChanged;
        }

        /// <summary>
        /// Called when Context in current session is changing
        /// </summary>
        private void Session_ContextChanged(Context context)
        {
            SetContextEvents();
            time.Text = context.TimeSpan.ToString();
            PauseTimer();
        }

        public bool Running
        {
            get { return timer.Enabled; }
        }
    }
}
