using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyfikacjaMiodu
{
    class PollenModuleSelector
    {
        private PollenModule choosenModule, highlightedModule;

        public PollenModuleSelector()
        {

        }

        public void AddListeners(PollenModule pollenModule)
        {
            pollenModule.MouseEnter += pollenModule_MouseEnter;
            pollenModule.MouseLeave += pollenModule_MouseLeave;
            pollenModule.MouseClick += pollenModule_MouseClick;
        }

        void pollenModule_MouseLeave(object sender, EventArgs e)
        {
            PollenModule newHighlightedModule = sender as PollenModule;

            if (newHighlightedModule != null)
            {
//                if (highlightedModule != null)
//                    highlightedModule.UnHighlight();
//
//                highlightedModule = null;
//                newHighlightedModule.UnHighlight();
            }
        }

        void pollenModule_MouseEnter(object sender, EventArgs e)
        {
            PollenModule newHighlightedModule = sender as PollenModule;

            if (newHighlightedModule != null)
            {
//                if (highlightedModule != null)
//                    highlightedModule.UnHighlight();
//
//                highlightedModule = newHighlightedModule;
//                newHighlightedModule.Highlight();
            }
        }

        void pollenModule_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PollenModule newSelectedModule = sender as PollenModule;

            if (newSelectedModule != null)
            {
//                if (choosenModule != null)
//                    choosenModule.UnChoose();
//
//                choosenModule = newSelectedModule;
//                choosenModule.Choose();
//                Session.Context.SelectedHoneyType = choosenModule.HoneyType; //powinno się nazywać selected zamiast choosen, ale funkcja Selected już istnieje w klasie PollenModule to musiałem zmienić
            }
        }
    }
}
