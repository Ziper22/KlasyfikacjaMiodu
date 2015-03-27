using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlasyfikacjaMiodu.ActionsModule;

namespace KlasyfikacjaMiodu.TopMenu
{
    /// <summary>
    /// Author: Dawid Ferszter. <para/>
    /// Class responsible for handling "Edit" menu.
    /// </summary>
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
            Actions.UndoLastAction();
        }

        private void redo_Click(object sender, EventArgs e)
        {
            Actions.RedoLastUndoneAction();
        }
    }
}
