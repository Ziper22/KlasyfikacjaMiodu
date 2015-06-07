using System;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    ///     Autor: Mariusz Gorzycki. 
    ///         Klasa odpowiedzialna za akcje wykonywane na bocznym panelu.
    /// </summary>
    internal class PollenModuleSelector
    {
        /// <summary>
        /// Właściwość zwracająca wybrany pyłek.
        /// </summary>
        public PollenModule chosenModule { get; set; }
        /// <summary>
        /// Właściwość zwracająca wyróżniony (podświetlony) pyłek.
        /// </summary>
        public PollenModule highlightedModule { get; private set; }
        /// <summary>
        /// Funkcja dodająca słuchaczy.
        /// </summary>
        /// <param name="pollenModule"></param>
        public void AddListeners(PollenModule pollenModule)
        {
            pollenModule.MouseEnter += pollenModule_MouseEnter;
            pollenModule.MouseLeave += pollenModule_MouseLeave;
            pollenModule.MouseClick += pollenModule_MouseClick;
        }
        /// <summary>
        ///     Podświetla moduł pyłka po najechaniu myszką.
        /// </summary>
        private void pollenModule_MouseEnter(object sender, EventArgs e)
        {
            PollenModule newHighlightedModule = sender as PollenModule;

            if (newHighlightedModule != null)
            {
                if (highlightedModule != null)
                    highlightedModule.UnHighlight();

                highlightedModule = newHighlightedModule;
                newHighlightedModule.Highlight();
            }
        }
        /// <summary>
        ///     Cofa podświetlenie po zjechaniu myszką.
        /// </summary>
        private void pollenModule_MouseLeave(object sender, EventArgs e)
        {
            PollenModule newHighlightedModule = sender as PollenModule;

            if (newHighlightedModule != null)
            {
                if (highlightedModule != null)
                    highlightedModule.UnHighlight();

                highlightedModule = null;
                newHighlightedModule.UnHighlight();
            }
        }
        /// <summary>
        ///     Wybiera typ miodu po kliknięciu myszką.
        /// </summary>
        private void pollenModule_MouseClick(object sender, MouseEventArgs e)
        {
            PollenModule newSelectedModule = sender as PollenModule;

            if (newSelectedModule != null)
            {
                if (chosenModule != null)
                    chosenModule.UnChoose();

                chosenModule = newSelectedModule;
                chosenModule.Choose();
                Session.Context.SelectedHoneyType = chosenModule.HoneyType;
            }
        }
    }
}