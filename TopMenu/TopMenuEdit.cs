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

        public TopMenuEdit(Form form, ToolStripMenuItem editMenu, ToolStripMenuItem undo, ToolStripMenuItem redo)
        {
            this.undo = undo;
            this.redo = redo;

            form.KeyPreview = true;
            form.KeyDown += new KeyEventHandler(Form_KeyDown);

            undo.Click += Undo_Click;
            redo.Click += Redo_Click;
            editMenu.Click += EditMenu_Click;
            
        }

        void EditMenu_Click(object sender, EventArgs e)
        {
            ChangeEnabledProperty();
        }

        /// <summary>
        /// Defines Hotkeys for Undo and Redo options.
        /// </summary>
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

        private void Undo_Click(object sender, EventArgs e)
        {
            if (Session.Context.BlockedView)
                return;

            Actions.UndoLastAction();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            if (Session.Context.BlockedView)
                return;

            Actions.RedoLastUndoneAction();
        }

        /// <summary>
        /// Changes "Enabled" property for ToolStripMenuItem controls.
        /// </summary>
        private void ChangeEnabledProperty()
        {
            if (Actions.DoneActionsAmount > 0) undo.Enabled = true;
            else undo.Enabled = false;

            if (Actions.UnDoneActionsAmount > 0) redo.Enabled = true;
            else redo.Enabled = false;
        }
    }
}
