using BookShelfProject.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookShelfProject.MVVM.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public ICommand _OpenShopWindowCommand { get; }
        public ICommand _OpenLoginWindowCommand { get; }
        public ICommand _RegisterCommand { get; }

        private string username;
        private string password;
        private string confirmationPassword;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ConfirmationPassword
        {
            get
            {
                return confirmationPassword;
            }
            set
            {
                confirmationPassword = value;
                OnPropertyChanged(nameof(ConfirmationPassword));
            }
        }

        public RegistrationViewModel()
        {
            _OpenLoginWindowCommand = new OpenLoginWindowCommand();
            _RegisterCommand = new RegisterCommand(this);
            _OpenShopWindowCommand = new OpenShopWindowCommand();
        }
    }
}
