using System;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    ///     Author: Mariusz Gorzycki
    ///     <para />
    /// </summary>
    internal class PollenModuleSelector
    {
        public PollenModule chosenModule { get; set; }
        public PollenModule highlightedModule { get; private set; }

        public void AddListeners(PollenModule pollenModule)
        {
            pollenModule.MouseEnter += pollenModule_MouseEnter;
            pollenModule.MouseLeave += pollenModule_MouseLeave;
            pollenModule.MouseClick += pollenModule_MouseClick;
        }

        private void pollenModule_MouseEnter(object sender, EventArgs e)
        {
            if (Session.Context.BlockedView)
                return;

            PollenModule newHighlightedModule = sender as PollenModule;

            if (newHighlightedModule != null)
            {
                if (highlightedModule != null)
                    highlightedModule.UnHighlight();

                highlightedModule = newHighlightedModule;
                newHighlightedModule.Highlight();
            }
        }

        private void pollenModule_MouseLeave(object sender, EventArgs e)
        {
            if (Session.Context.BlockedView)
                return;

            PollenModule newHighlightedModule = sender as PollenModule;

            if (newHighlightedModule != null)
            {
                if (highlightedModule != null)
                    highlightedModule.UnHighlight();

                highlightedModule = null;
                newHighlightedModule.UnHighlight();
            }
        }

        private void pollenModule_MouseClick(object sender, MouseEventArgs e)
        {
            if (Session.Context.BlockedView)
                return;

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