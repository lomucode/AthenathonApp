using System;
using System.ComponentModel;

namespace AthenathonApp.Services
{
    public class Profile : INotifyPropertyChanged
    {
        private string _name;
        private string _role;
        private string _university;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Role)));
                }
            }
        }

        public string University
        {
            get
            {
                return _university;
            }
            set
            {
                _university = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(University)));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
