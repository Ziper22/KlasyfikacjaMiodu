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
    ///     Author: Mariusz Gorzycki
    ///     <para />
    ///     All project data and current state is kept as a program Context.
    ///     Every Context realted action as new project, loading new data etc. can by listened with events.
    /// </summary>
    [Serializable]
    public class Context
    {
        public delegate void ScaleEventHandler(float newScale);
        [field: NonSerialized]
        public event ScaleEventHandler ScaleChanged;

        public delegate void TimeEventHandler(TimeSpan newTimeSpan);
        [field: NonSerialized]
        public event TimeEventHandler TimeChanged;

        public delegate void HoneyTypeEventHandler(HoneyType honeyType);
        [field: NonSerialized]
        public event HoneyTypeEventHandler HoneyTypeAdded;
        [field: NonSerialized]
        public event HoneyTypeEventHandler HoneyTypeRemoved;
        [field: NonSerialized]
        public event HoneyTypeEventHandler HoneyTypeSelected;
        [field: NonSerialized]
        public event HoneyTypeEventHandler HoneyTypeEdited;

        public delegate void MarkerEventHandler(Marker marker);
        [field: NonSerialized]
        public event MarkerEventHandler MarkerAdded;
        [field: NonSerialized]
        public event MarkerEventHandler MarkerRemoved;

        public delegate void ImageEventHandler(Image image);
        [field: NonSerialized]
        public event ImageEventHandler ImageChanged;

        private float scale = 1;
        private TimeSpan timeSpan;
        private List<HoneyType> honeyTypes = new List<HoneyType>();
        private List<Marker> markers = new List<Marker>();
        private HoneyType selectedHoneyType;
        private Image image;
        private bool blockedView;

        public Context(bool useDefaultHoneyTypes)
        {
            Actions.Clear();
            image = Resources.honeyPollens;

            if (useDefaultHoneyTypes)
                LoadDefaultHoneyTypes();
        }

        private void LoadDefaultHoneyTypes()
        {
            honeyTypes = DefaultHoneyTypesBase.GetAllHoneyTypesFromFile();
        }

        public float Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                OnScaleChanged();
            }
        }

        public TimeSpan TimeSpan
        {
            get { return timeSpan; }
            set
            {
                timeSpan = value;
                OnTimeChanged();
            }
        }

        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                OnImageChanged();
            }
        }

        public HoneyType SelectedHoneyType
        {
            get { return selectedHoneyType; }
            set
            {
                selectedHoneyType = value;
                OnHoneyTypeSelected();
            }
        }
        public bool BlockedView
        {
            get { return this.blockedView; }
            set { this.blockedView = value; }
        }
        public IList<Marker> Markers
        {
            get { return markers.AsReadOnly(); }
        }

        public IList<HoneyType> HoneyTypes
        {
            get { return honeyTypes.AsReadOnly(); }
        }

        public HoneyType GetHoneyType(string name)
        {
            foreach (HoneyType honeyType in honeyTypes)
            {
                if (honeyType.Name.ToLower().Contains(name.ToLower()))
                    return honeyType;
            }
            return null;
        }

        public void AddHoneyType(HoneyType honeyType)
        {
            honeyTypes.Add(honeyType);
            OnHoneyTypeAdded(honeyType);
        }

        public void EditedHoneyType(HoneyType honeyType)
        {
            OnHoneyTypeEdited(honeyType);
        }

        public void RemoveHoneyType(HoneyType honeyType)
        {
            honeyTypes.Remove(honeyType);
            OnHoneyTypeRemoved(honeyType);
        }

        public void AddMArker(Marker marker)
        {
            markers.Add(marker);
            OnMarkerAdded(marker);
        }

        public void RemoveMarker(Marker marker)
        {
            markers.Remove(marker);
            OnMarkerRemoved(marker);
        }

        private void OnImageChanged()
        {
            if (ImageChanged != null)
                ImageChanged(image);
        }

        private void OnMarkerAdded(Marker marker)
        {
            if (MarkerAdded != null)
                MarkerAdded(marker);
        }

        private void OnMarkerRemoved(Marker marker)
        {
            if (MarkerRemoved != null)
                MarkerRemoved(marker);
        }

        private void OnHoneyTypeAdded(HoneyType honeyType)
        {
            if (HoneyTypeAdded != null)
                HoneyTypeAdded(honeyType);
        }

        private void OnHoneyTypeRemoved(HoneyType honeyType)
        {
            if (HoneyTypeRemoved != null)
                HoneyTypeRemoved(honeyType);
        }

        private void OnScaleChanged()
        {
            if (ScaleChanged != null)
                ScaleChanged(scale);
        }

        private void OnTimeChanged()
        {
            if (TimeChanged != null)
                TimeChanged(timeSpan);
        }

        protected virtual void OnHoneyTypeSelected()
        {
            if (HoneyTypeSelected != null)
                HoneyTypeSelected(selectedHoneyType);
        }

        protected virtual void OnHoneyTypeEdited(HoneyType honeyType)
        {
            if (HoneyTypeEdited != null)
                HoneyTypeEdited(honeyType);
        }
    }
}
