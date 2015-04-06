using System;

namespace KlasyfikacjaMiodu.SideMenu
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// </summary>
    
    class PollenModuleSelector
    {
        public PollenModule chosenModule { get; private set; }
        public PollenModule highlightedModule { get; private set; }

        public void AddListeners(PollenModule pollenModule)
        {
            pollenModule.MouseEnter += pollenModule_MouseEnter;
            pollenModule.MouseLeave += pollenModule_MouseLeave;
            pollenModule.MouseClick += pollenModule_MouseClick;
        }

        void pollenModule_MouseEnter(object sender, EventArgs e)
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

        void pollenModule_MouseLeave(object sender, EventArgs e)
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

        void pollenModule_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
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
