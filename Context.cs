using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasyfikacjaMiodu.ActionsModule;
using KlasyfikacjaMiodu.Properties;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    ///     Author: Mariusz Gorzycki. 
    ///     Wszystkie dane projektu i aktualne stany przechowywane są jako Context programu.
    ///     Każdy Context może być nasłuchiwany przez zdarzenia.
    /// </summary>
    [Serializable]
    public class Context
    {
        /// <summary>
        /// Delegat odpowiedzialny za skalowanie.
        /// </summary>
        /// <param name="newScale"></param>
        public delegate void ScaleEventHandler(float newScale);
        public event ScaleEventHandler ScaleChanged;
        /// <summary>
        /// Delegat odpowiedzialny za licznik czasu.
        /// </summary>
        /// <param name="newTimeSpan"></param>
        public delegate void TimeEventHandler(TimeSpan newTimeSpan);
        public event TimeEventHandler TimeChanged;
        /// <summary>
        /// Delegat odpowiedzialny za typy miodu.
        /// </summary>
        /// <param name="honeyType"></param>
        public delegate void HoneyTypeEventHandler(HoneyType honeyType);
        public event HoneyTypeEventHandler HoneyTypeAdded;
        public event HoneyTypeEventHandler HoneyTypeRemoved;
        public event HoneyTypeEventHandler HoneyTypeSelected;
        public event HoneyTypeEventHandler HoneyTypeEdited;
        /// <summary>
        /// Delegat odpowiedzialny za znaczniki.
        /// </summary>
        /// <param name="marker"></param>
        public delegate void MarkerEventHandler(Marker marker);
        public event MarkerEventHandler MarkerAdded;
        public event MarkerEventHandler MarkerRemoved;
        /// <summary>
        /// Delegat odpowiedzialny za zdjęcie.
        /// </summary>
        /// <param name="image"></param>
        public delegate void ImageEventHandler(Image image);
        public event ImageEventHandler ImageChanged;

        private float scale = 1;
        private TimeSpan timeSpan;
        private List<HoneyType> honeyTypes = new List<HoneyType>();
        private List<Marker> markers = new List<Marker>();
        private HoneyType selectedHoneyType;
        private Image image;
        private bool editMode = true;
        /// <summary>
        /// Konstuktor tworzący nowy Context
        /// </summary>
        public Context(bool useDefaultHoneyTypes)
        {
            Actions.Clear();

            if (useDefaultHoneyTypes)
                LoadDefaultHoneyTypes();
        }
        /// <summary>
        /// Funkcja ładująca podstawową bazę pyłków.
        /// </summary>
        private void LoadDefaultHoneyTypes()
        {
            honeyTypes = DefaultHoneyTypesBase.GetAllHoneyTypesFromFile();
        }
        /// <summary>
        /// Właściwość zwracająca skalę.
        /// </summary>
        public float Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                OnScaleChanged();
            }
        }
        /// <summary>
        /// Właściwość zwracająca TimeSpan.
        /// </summary>
        public TimeSpan TimeSpan
        {
            get { return timeSpan; }
            set
            {
                timeSpan = value;
                OnTimeChanged();
            }
        }
        /// <summary>
        /// Właściwość zwracająca aktualnie wczytany obraz. 
        /// </summary>
        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                OnImageChanged();
            }
        }
        /// <summary>
        /// Zwraca wyznaczony typ miodu.
        /// </summary>
        public HoneyType SelectedHoneyType
        {
            get { return selectedHoneyType; }
            set
            {
                selectedHoneyType = value;
                OnHoneyTypeSelected();
            }
        }
        /// <summary>
        /// Zwraca true jesli EditMode jest wlączony, w przeciwnym razie false.
        /// </summary>
        public bool EditMode
        {
            get { return editMode; }
            set { editMode = value; }
        }
        /// <summary>
        /// Zwraca listę Markerów
        /// </summary>
        public IList<Marker> Markers
        {
            get { return markers.AsReadOnly(); }
        }
        /// <summary>
        /// Zwraca listę typów miodu.
        /// </summary>
        public IList<HoneyType> HoneyTypes
        {
            get { return honeyTypes.AsReadOnly(); }
        }
        /// <summary>
        /// Funkcja zwracająca typ miodu na podstawie jego nazwy.
        /// </summary>
        public HoneyType GetHoneyType(string name)
        {
            foreach (HoneyType honeyType in honeyTypes)
            {
                if (honeyType.Name.ToLower().Contains(name.ToLower()))
                    return honeyType;
            }
            return null;
        }
        /// <summary>
        /// Funkcja dodająca nowy typ miodu.
        /// </summary>
        public void AddHoneyType(HoneyType honeyType)
        {
            honeyTypes.Add(honeyType);
            OnHoneyTypeAdded(honeyType);
        }
        /// <summary>
        /// Funkcja edytująca typ miodu.
        /// </summary>
        public void EditedHoneyType(HoneyType honeyType)
        {
            OnHoneyTypeEdited(honeyType);
        }
        /// <summary>
        /// Funkcja usuwająca typ miodu.
        /// </summary>
        public void RemoveHoneyType(HoneyType honeyType)
        {
            honeyTypes.Remove(honeyType);
            OnHoneyTypeRemoved(honeyType);
        }
        /// <summary>
        /// Funkcja dodająca Marker.
        /// </summary>
        public void AddMArker(Marker marker)
        {
            markers.Add(marker);
            OnMarkerAdded(marker);
        }
        /// <summary>
        /// Funkcja usuwająca Marker.
        /// </summary
        public void RemoveMarker(Marker marker)
        {
            markers.Remove(marker);
            OnMarkerRemoved(marker);
        }
        /// <summary>
        /// Funkcja wywołująca zdarzenie przy zmianie obrazka
        /// </summary>
        private void OnImageChanged()
        {
            if (ImageChanged != null)
                ImageChanged(image);
        }
        /// <summary>
        /// Funkcja wywołująca zdarzenie przy dodaniu Markera.
        /// </summary>
        private void OnMarkerAdded(Marker marker)
        {
            if (MarkerAdded != null)
                MarkerAdded(marker);
        }
        /// <summary>
        /// Funkcja wywołująca zdarzenie przy usunięciu Markera.
        /// </summary>
        private void OnMarkerRemoved(Marker marker)
        {
            if (MarkerRemoved != null)
                MarkerRemoved(marker);
        }
        /// <summary>
        /// Funkcja wywołująca zdarzenie przy dodaniu nowego typu miodu.
        /// </summary>
        private void OnHoneyTypeAdded(HoneyType honeyType)
        {
            if (HoneyTypeAdded != null)
                HoneyTypeAdded(honeyType);
        }
        /// <summary>
        /// Funkcja wywołująca zdarzenie przy usunięciu typu miodu.
        /// </summary>
        private void OnHoneyTypeRemoved(HoneyType honeyType)
        {
            if (HoneyTypeRemoved != null)
                HoneyTypeRemoved(honeyType);
        }
        /// <summary>
        /// Funkcja wywołująca zdarzenie przy zmianie skali.
        /// </summary>
        private void OnScaleChanged()
        {
            if (ScaleChanged != null)
                ScaleChanged(scale);
        }
        /// <summary>
        /// Funkcja wywołująca zdarzenie przy zmianie czasu.
        /// </summary>
        private void OnTimeChanged()
        {
            if (TimeChanged != null)
                TimeChanged(timeSpan);
        }
        /// <summary>
        /// Funkcja wywołująca zdarzenie przy zaznaczeniu typu miodu.
        /// </summary>
        protected virtual void OnHoneyTypeSelected()
        {
            if (HoneyTypeSelected != null)
                HoneyTypeSelected(selectedHoneyType);
        }
        /// <summary>
        /// Funkcja wywołująca zdarzenie przy edycji typu miodu.
        /// </summary>
        protected virtual void OnHoneyTypeEdited(HoneyType honeyType)
        {
            if (HoneyTypeEdited != null)
                HoneyTypeEdited(honeyType);
        }
    }
}
