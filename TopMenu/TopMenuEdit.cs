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
    /// Klasa odpowiedzialna za przechowywnie zakładki "Edytuj" w menu.
    /// </summary>
    public class TopMenuEdit
    {
        private ToolStripMenuItem undo;
        private ToolStripMenuItem redo;
        /// <summary>
        /// Konstruktor klasy. Dodaje pola do rozwijanej listy.
        /// </summary>
        /// <param name="form">Formularz</param>
        /// <param name="editMenu">Edytuj menu</param>
        /// <param name="undo">Cofnij</param>
        /// <param name="redo">Cofnij cofnięcie</param>
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
        /// <summary>
        /// Funkcja opisująca jak ma się zachować zakładka "Edytuj" po kliknięciu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void EditMenu_Click(object sender, EventArgs e)
        {
            ChangeEnabledProperty();
        }

        /// <summary>
        /// Funkcja definiująca skróty klawiszowe dla elementów "Undo" i "Redo".
        /// </summary>
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Session.Context.EditMode)
                return;

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
        /// <summary>
        /// Funkcja cofająca ostatnią akcję.
        /// </summary>
        private void Undo_Click(object sender, EventArgs e)
        {
            Actions.UndoLastAction();
        }
        /// <summary>
        /// Funkcja cofająca ostatnie cofnięcie.
        /// </summary>
        private void Redo_Click(object sender, EventArgs e)
        {
            Actions.RedoLastUndoneAction();
        }

        /// <summary>
        /// Zmienia wartość "Enabled" dla kontrolek ToolStripMenuItem.
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
