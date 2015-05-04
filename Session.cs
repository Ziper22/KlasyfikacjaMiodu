using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Author: Mariusz Gorzycki. <para/>
    /// A Singleton implementation for <see cref="Context"/>
    /// </summary>
    public static class Session
    {
        public delegate void SessionEventHandler(Context Context);
        public static event SessionEventHandler Changed;
        private static Context context = new Context(true);

        /// <summary>
        /// Returns current application <see cref="Context"/>
        /// </summary>
        public static Context Context
        {
            get { return context; }
        }

        /// <summary>
        /// Create new application <see cref="Context"/>.
        /// Previus Context will be overriden.
        /// </summary>
        public static void NewClear()
        {
            Session.context = new Context(false);
            onChanged();
        }

        /// <summary>
        /// Create new application <see cref="Context"/>.
        /// Previus Context will be overriden.
        /// </summary>
        public static void NewDefault()
        {
            Session.context = new Context(true);
            onChanged();
        }

        /// <summary>
        /// Executes <see cref="Changed"/> event
        /// </summary>
        private static void onChanged()
        {
            if (Changed != null)
                Changed(context);
        }
    }
}
