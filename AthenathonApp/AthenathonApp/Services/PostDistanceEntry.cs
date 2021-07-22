using System;
using System.ComponentModel;

namespace AthenathonApp.Services
{
    public class PostDistanceEntry : INotifyPropertyChanged
    {
        private string _distanz;
        private string _distanzArt;
        private string _userId;
        private DateTime _date;
        private string _total;

        public string Distanz
        {
            get
            {
                return _distanz;
            }
            set
            {
                _distanz = value;

                if (PropertyChanged != null)
                {
                    OnPropertyChanged(nameof(Distanz));
                }
            }
        }

        public string TotalDistance
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;

                if (PropertyChanged != null)
                {
                    OnPropertyChanged(nameof(TotalDistance));
                }
            }
        }

        public string DistanzArt
        {
            get
            {
                return _distanzArt;
            }
            set
            {
                _distanzArt = value;

                if (PropertyChanged != null)
                {
                    OnPropertyChanged(nameof(DistanzArt));
                }
            }
        }

        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;

                if (PropertyChanged != null)
                {
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }

        public DateTime DistanDatenDatum
        {
            get
            {
                return _date;
            } set
            {
                _date = value;
                if(PropertyChanged != null)
                {
                    OnPropertyChanged(nameof(DistanDatenDatum));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

 
    }
}
