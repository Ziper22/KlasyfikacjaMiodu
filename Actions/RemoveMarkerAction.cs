using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyfikacjaMiodu.Actions
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Action responsible for removing a Marker.
    /// </summary>
    class RemoveMarkerAction : Action
    {
        private Marker marker;

        public RemoveMarkerAction(Marker marker)
        {
            this.marker = marker;
        }

        public override void Do()
        {
            Session.Context.RemoveMarker(marker);
        }

        public override void Undo()
        {
            Session.Context.AddMArker(marker);
        }
    }
}
