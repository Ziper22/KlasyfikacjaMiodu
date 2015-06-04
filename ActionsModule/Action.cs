namespace KlasyfikacjaMiodu.ActionsModule
{
    /// <summary>
    /// Author: Mariusz Gorzycki. <para/>
    /// Abstrakcyjny model akcji, która może być wyonana lub cofnięta.
    /// </summary>
    public abstract class Action
    {
        /// <summary>
        /// Definiuje jaka może być akcja.
        /// </summary>
        public abstract void Do();
        /// <summary>
        /// Definiuje jak zmiany w Do() mogą być cofnięte
        /// </summary>
        public abstract void Undo();
    }
}
