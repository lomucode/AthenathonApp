using System;
using System.ComponentModel;

namespace AthenathonApp.Services
{
    public class totalDistance : INotifyPropertyChanged
    {
        private string _total;

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
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
