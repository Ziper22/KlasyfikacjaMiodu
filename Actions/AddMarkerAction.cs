using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyfikacjaMiodu.Actions
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// Action responsible for adding new Marker.
    /// </summary>
    class AddMarkerAction : Action
    {
        private Marker marker;
        
        public AddMarkerAction(Marker marker)
        {
            this.marker = marker;
        }

        public override void Do()
        {
            Session.Context.AddMArker(marker);
        }

        public override void Undo()
        {
            Session.Context.RemoveMarker(marker);
        }
    }
}
