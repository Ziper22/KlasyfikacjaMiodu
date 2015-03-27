namespace KlasyfikacjaMiodu.ActionsModule
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Abstract model of action witch can be done and eventually undone after that.
    /// </summary>
    public abstract class Action
    {
        /// <summary>
        /// Defines what the action can do
        /// </summary>
        public abstract void Do();
        /// <summary>
        /// Defines how the changes in Do() method can be undone.
        /// </summary>
        public abstract void Undo();
    }
}
