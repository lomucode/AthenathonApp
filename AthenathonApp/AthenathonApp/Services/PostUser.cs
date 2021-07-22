using System;
using System.ComponentModel;

namespace AthenathonApp.Services
{
    public class PostUser : INotifyPropertyChanged
    {
        private string _textEmail;
        private string _passwordText;
        private string _response;
        private string _passwordTest;

        public string Email { get {
                return _textEmail;
            } set
            {
                _textEmail = value;

                if(PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
                }
            }
        }
        //public string Email { get; set; }

        public string PasswordHash
        {
            get
            {
                return _passwordText;
            }
            set
            {
                _passwordText = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(PasswordHash)));
                }
            }
        }

        public string Response
        {
            get
            {
                return _response;
            }
            set
            {
                _response = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Response)));
                }
            }
        }

        public string PasswordHashTest
        {
            get
            {
                return _passwordTest;
            }
            set
            {
                _passwordTest = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(PasswordHashTest)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
