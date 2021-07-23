using System;
using System.ComponentModel;

namespace AthenathonApp.Services
    //class, to setup global user data
{
    public class UserToken : INotifyPropertyChanged
    {
        private string _userToken;
        private string _email;

        public string Token
        {
            get
            {
                return _userToken;
            }
            set
            {
                _userToken = value;

                if (PropertyChanged != null)
                {
                    OnPropertyChanged(nameof(Token));
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                if(PropertyChanged != null)
                {
                    OnPropertyChanged(nameof(Email));
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
