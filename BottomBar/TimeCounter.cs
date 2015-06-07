using System;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.BottomBar
{
    /// <summary>
    /// Autor: Mariusz Gorzycki. <para/>
    /// Klasa przechowująca czas pracy działania programu.
    /// </summary>
    class TimeCounter
    {
        private Timer timer;
        private Label time;
        private Button stoperButton;
        /// <summary>
        /// Konstrukor klasy.
        /// </summary>
        /// <param name="time">Komórka pokazująca czas</param>
        /// <param name="stoperButton">Przycisk pauzujący stoper</param>
        public TimeCounter(Label time, Button stoperButton)
        {
            this.time = time;
            this.stoperButton = stoperButton;
            SetOneSecondTimer();
            stoperButton.Click += stoperButton_Click;

            SetContextEvents();
            Session.Changed += Session_ContextChanged;
            PauseTimer();
        }
        /// <summary>
        /// Funkcja wywoływana przy wciśnięciu przysicku stopera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Ustawia aby licznik czasu zmieniał się co 1 sekundę.
        /// </summary>
        private void SetOneSecondTimer()
        {
            timer = new Timer();
            timer.Tick += TimeChanged;
            timer.Interval = 1000;
        }
        /// <summary>
        /// Funkcja startująca stoper.
        /// </summary>
        public void StartTimer()
        {
            timer.Start();
            stoperButton.BackgroundImage = Properties.Resources.stop;
            Session.Context.EditMode = true;
        }
        /// <summary>
        /// Funkcja pauzująca stoper.
        /// </summary>
        public void PauseTimer()
        {
            timer.Stop();
            stoperButton.BackgroundImage = Properties.Resources.start;
            Session.Context.EditMode = false;
        }
        /// <summary>
        /// Funkcja wyświetlająca czas działania bieżącej sesji.
        /// </summary>
        private void TimeChanged(Object sender, EventArgs args)
        {
            Session.Context.TimeSpan = Session.Context.TimeSpan.Add(new TimeSpan(0, 0, 1));
        }
        /// <summary>
        /// Funkcja wywoływana podczas zmian czasu w Contexcie.
        /// </summary>
        /// <param name="timeSpan"></param>
        private void ContextOnTimeChanged(TimeSpan timeSpan)
        {
            time.Text = timeSpan.ToString();
        }

        /// <summary>
        /// Ustawia zdarzenia Contextu. Słuchacze powinny być ustawione ponownie po każdej zmianie Contextu w obecnej Sesji.
        /// </summary>
        private void SetContextEvents()
        {
            Session.Context.TimeChanged += ContextOnTimeChanged;
        }

        /// <summary>
        /// Funkcja wywoływana podczas zmian w Contexcie.
        /// </summary>
        private void Session_ContextChanged(Context context)
        {
            SetContextEvents();
            time.Text = context.TimeSpan.ToString();
            PauseTimer();
        }
        /// <summary>
        /// Właściwość zwracająca to czy w aktualnej chwili stoper działa.
        /// </summary>
        public bool Running
        {
            get { return timer.Enabled; }
        }
    }
}
