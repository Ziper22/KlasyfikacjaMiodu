using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu.TopMenu
{
    public class TopMenuEdit
    {
        private ToolStripMenuItem undo;
        private ToolStripMenuItem redo;

        public TopMenuEdit(ToolStripMenuItem undo, ToolStripMenuItem redo)
        {
            this.undo = undo;
            this.redo = redo;

            undo.Click += undo_Click;
            redo.Click += redo_Click;
        }

        private void undo_Click(object sender, EventArgs e)
        {
            // cofnięcie zmiany
        }

        private void redo_Click(object sender, EventArgs e)
        {
            // ponowienie zmiany
        }
    }
}
