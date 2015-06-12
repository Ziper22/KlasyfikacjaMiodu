using System.Collections.Generic;

namespace KlasyfikacjaMiodu.ActionsModule
{
    /// <summary>
    /// Autor: Mariusz Gorzycki. <para/>
    /// Zarządza wszystkimi akcjami podczas trwania jednej sesji.
    /// </summary>
    public class Actions
    {
        private static Stack<Action> doneActions = new Stack<Action>();
        private static Stack<Action> unDoneActions = new Stack<Action>();

        /// <summary>
        /// Wykonuje akacje i pozala na późniejsze jej cofnięcie.
        /// </summary>
        public static void RunAction(Action action)
        {
            doneActions.Push(action);
            action.Do();
        }

        /// <summary>
        /// Cofa zmiany wykonane przez ostatnia akcję.
        /// </summary>
        public static void UndoLastAction()
        {
            if (doneActions.Count > 0)
            {
                Action last = doneActions.Pop();
                unDoneActions.Push(last);
                last.Undo();
            }
        }

        /// <summary>
        /// Przywraca ostatnio cofniętą akcję.
        /// </summary>
        public static void RedoLastUndoneAction()
        {
            if (unDoneActions.Count > 0)
            {
                Action last = unDoneActions.Pop();
                doneActions.Push(last);
                last.Do();
            }
        }

        /// <summary>
        /// Zwraca ilość wykonanych akcji od czasu rozpoczęcia sesji.
        /// </summary>
        public static int DoneActionsAmount
        {
            get { return doneActions.Count; }
        }

        /// <summary>
        ///  Zwraca ilość cofniętych akcji od czasu rozpoczęcia sesji.
        /// </summary>
        public static int UnDoneActionsAmount
        {
            get { return unDoneActions.Count; }
        }
        /// <summary>
        /// Funkcja zerująca liczniki wykonanych i cofniętych akcji.
        /// </summary>
        public static void Clear()
        {
            doneActions.Clear();
            unDoneActions.Clear();
        }
    }
}
