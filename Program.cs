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
        /// </summary>
        [STAThread]
        static void Main()
        {
            DB baza = new DB();
            List<HoneyType> honeyList = baza.GetHoneyList;

            baza.DeleteHoneyType("Cipowy");
            baza.SaveHoneyTypesToFile();
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
