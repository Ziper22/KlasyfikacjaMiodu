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

        public TopMenuEdit(Form form, ToolStripMenuItem undo, ToolStripMenuItem redo)
        {
            this.undo = undo;
            this.redo = redo;

            form.KeyPreview = true;
            form.KeyDown += new KeyEventHandler(Form_KeyDown);

            undo.Click += undo_Click;
            redo.Click += redo_Click;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Actions.UndoLastAction();
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.Y)
            {
                Actions.RedoLastUndoneAction();
                e.SuppressKeyPress = true;
            }
        }

        private void undo_Click(object sender, EventArgs e)
        {
            Actions.UndoLastAction();
        }

        private void redo_Click(object sender, EventArgs e)
        {
            Actions.RedoLastUndoneAction();
        }

        /// <summary>
        /// Changes "Enabled" property for ToolStripMenuItem controls.
        /// </summary>
        private void ChangeEnabledProperty()
        {
            if (Actions.DoneActionsAmount > 0) undo.Enabled = false;
            else undo.Enabled = true;
        }
    }
}
