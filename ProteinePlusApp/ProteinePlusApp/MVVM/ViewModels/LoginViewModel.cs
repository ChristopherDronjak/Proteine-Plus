using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using ProteinePlusApp.MVVM.Models;

namespace ProteinePlusApp.MVVM.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Users _user;

        public LoginViewModel()
        {
            _user = new Users();
        }

        public string Username
        {
            get { return _user.Username; }
            set
            {
                if (_user.Username != value)
                {
                    _user.Username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get { return _user.Password; }
            set
            {
                if (_user.Password != value)
                {
                    _user.Password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public ICommand SignupCommand { get; set; }
        public ICommand BackToLoginCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
