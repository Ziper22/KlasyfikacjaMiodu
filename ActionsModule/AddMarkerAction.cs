namespace KlasyfikacjaMiodu.ActionsModule
{
    /// <summary>
    /// Autor: Mariusz Gorzycki. <para/>
    /// Klasa odpowiedzialna za dodawanie nowego Markera.
    /// </summary>
    public class AddMarkerAction : Action
    {
        private Marker marker;
        /// <summary>
        ///     Dodanie nowego znacznika.
        /// </summary>
        /// <param name="marker">Wybrany znacznik</param>
        public AddMarkerAction(Marker marker)
        {
            this.marker = marker;
        }
        /// <summary>
        ///     Dodanie znacznika do sesji.
        /// </summary>
        public override void Do()
        {
            Session.Context.AddMArker(marker);
        }
        /// <summary>
        ///     Usunięcie znacznika z sesji.
        /// </summary>
        public override void Undo()
        {
            Session.Context.RemoveMarker(marker);
        }
    }
}
