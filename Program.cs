using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace KlasyfikacjaMiodu
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// Nic nie zmieniać w tej klasie!
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); //Nic nie zmieniać w tej klasie!
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
