namespace KlasyfikacjaMiodu.ActionsModule
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Action responsible for removing a Marker.
    /// </summary>
    public class RemoveMarkerAction : Action
    {
        private Marker marker;

        public RemoveMarkerAction(Marker marker)
        {
            this.marker = marker;
        }

        public override void Do()
        {
            if (Session.Context.BlockedView)
                return;

            Session.Context.RemoveMarker(marker);
        }

        public override void Undo()
        {
            if (Session.Context.BlockedView)
                return;

            Session.Context.AddMArker(marker);
        }
    }
}
