using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasyfikacjaMiodu
{
    /// <summary>
    /// Author: Mariusz Gorzycki<para/>
    /// All project data and current state is kept as a program Context.
    /// Every Context realted action as new project, loading new data etc. can by listened with events.
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

        public delegate void MarkerEventHandler(Marker marker);
        [field: NonSerialized]
        public event MarkerEventHandler MarkerAdded;
        [field: NonSerialized]
        public event MarkerEventHandler MarkerRemoved;

        public delegate void ImageEventHandler(Image image);
        [field: NonSerialized]
        public event ImageEventHandler ImageChanged;

        private float scale;
        private TimeSpan timeSpan;
        private List<HoneyType> honeyTypes = new List<HoneyType>();
        private List<Marker> markers = new List<Marker>();
        private Image image;

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
    }
}
