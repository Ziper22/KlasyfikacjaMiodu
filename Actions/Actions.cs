﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyfikacjaMiodu.Actions
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Manage all Actions performed and cancelled during the Session lifecycle.
    /// </summary>
    class Actions
    {
        private static Stack<Action> doneActions = new Stack<Action>();
        private static Stack<Action> unDoneActions = new Stack<Action>();

        /// <summary>
        /// Runs action and allow to undo Action later.
        /// </summary>
        public static void RunAction(Action action)
        {
            doneActions.Push(action);
            action.Do();
        }

        /// <summary>
        /// Rollback changes made by last performed action
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
        /// Makes changes done by cancelled Action applicable again
        /// </summary>
        public static void RedoLastUndoneAction()
        {
            if (doneActions.Count > 0)
            {
                Action last = unDoneActions.Pop();
                doneActions.Push(last);
                last.Do();
            }
        }

        /// <summary>
        /// Returns the amount of actions performed since the program Session start
        /// </summary>
        public int DoneActionsAmount
        {
            get { return doneActions.Count; }
        }

        /// <summary>
        /// Returns the amount of actions cancelled since the program Session start
        /// </summary>
        public int UnDoneActionsAmount
        {
            get { return unDoneActions.Count; }
        }
    }
}
