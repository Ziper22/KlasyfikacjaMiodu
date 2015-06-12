using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Główny punkt wejścia dla aplikacji.
    /// Klasa wygenerowana automatycznie.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Metoda startowa programu.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
