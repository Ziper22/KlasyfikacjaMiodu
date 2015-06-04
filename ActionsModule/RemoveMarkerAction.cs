namespace KlasyfikacjaMiodu.ActionsModule
{
    /// <summary>
    /// Author: Mariusz Gorzycki. <para/>
    /// Klasa odpowiedzialna ze usuwanie znacznika.
    /// </summary>
    public class RemoveMarkerAction : Action
    {
        private Marker marker;
        /// <summary>
        /// Konstruktor klasy odpowiedzialnej ze usuwanie znacznika.
        /// </summary>
        public RemoveMarkerAction(Marker marker)
        {
            this.marker = marker;
        }
        /// <summary>
        ///     Usunięcie znacznika z bierzącej sesji.
        /// </summary>
        public override void Do()
        {
            Session.Context.RemoveMarker(marker);
        }
        /// <summary>
        ///     Cofnięcie usunięcia znacznika z bierzącej sesji.
        /// </summary>
        public override void Undo()
        {
            Session.Context.AddMArker(marker);
        }
    }
}
