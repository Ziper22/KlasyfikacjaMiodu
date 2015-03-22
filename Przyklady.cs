using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyfikacjaMiodu
{
    class Przyklady
    {
        public Przyklady()
        {
            //Po polsku piszemy tylko ymczasowe rzeczy/komentarze które potem będą usunięte.
            //Reszta kodu powinna być po angielsku.


            //Dostep do Contextu programu można uzyskać przez:
            float scale = Session.Context.Scale;
            //w tym przypadku jest odczytanie aktualnej skali obrazka

            //Tworzenie nowej sesji:
            Session.New();

            //Wczytywanie z pliku i odtwarznie sesji:
            Context newContext = new Context();
            //trzeba wczytać i odtworzyć obiekt Context
            Session.Load(newContext);
            //po przekazaniu nowego contextu do sesji program sam wczyta jej zawartosc

            //Dodawanie nasluchiwaczy zmian:
            Session.Context.MarkerAdded += MarkerAdded;
            //teraz gdy zostanie dodany nowy marker wywoła się funkcja "MarkerAdded"

            Session.Changed += SessionChanged;
            //teraz Gdy zostanie zmieniona sesja (czyli np klikniecie "Nowy plik" w menu, albo wczytanie poprzedniego z pliku)
            //wywoła się funkcja "SessionChanged" a w niej powinno być ustawienie nowej wartości dla danego modułu.
            //np w klasie TimeCounter jest to wykorzystane do wczytania ilości czasu z nowego kontekstu.

            //Dodanie nowego typu miodu do kontekstu:
            //TO DO: dodanie licznika gatunków miodu
            Session.Context.AddHoneyType(new HoneyType("Wrzos", "Wrzosowy", Color.DarkViolet));
            //akurat kolor powinien byc podany przez uzytkownika, tu dla przyklady wartosc stala
        }

        public static void SessionChanged(Context context)
        {
            //tu będzie wczytywanie zmian
        }

        public static void MarkerAdded(Marker marker)
        {
            //tu można zrobić np obsługę zwiększanaia licznika danego gatunku
        }
    }
}
