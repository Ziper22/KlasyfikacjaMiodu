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
    /// Autor: Mariusz Gorzycki. <para/>
    /// Implementacja dla <see cref="Context"/>
    /// </summary>
    public static class Session
    {
        public delegate void SessionEventHandler(Context Context);
        public static event SessionEventHandler Changed;
        private static Context context = new Context(true);

        /// <summary>
        /// Zwraca aktualną aplikację. <see cref="Context"/>
        /// </summary>
        public static Context Context
        {
            get { return context; }
        }

        /// <summary>
        /// Tworzy nową aplikację. <see cref="Context"/>.
        /// Poprzedni Context będzie nadpisany.
        /// </summary>
        public static void NewClear()
        {
            Session.context = new Context(false);
            onChanged();
        }

        /// <summary>
        /// Tworzy nową aplikację. <see cref="Context"/>.
        /// Poprzedni Context będzie nadpisany.
        /// </summary>
        public static void NewDefault()
        {
            Session.context = new Context(true);
            onChanged();
        }

        /// <summary>
        /// Wykonuje <see cref="Changed"/> zdarzenie
        /// </summary>
        private static void onChanged()
        {
            if (Changed != null)
                Changed(context);
        }
    }
}
