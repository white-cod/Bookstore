using BookShelfProject.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookShelfProject.MVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand _OpenRegisterWindowCommand { get; }
        public ICommand _LoginCommand { get; }
        public ICommand _OpenShopWindowCommand { get; }

        private string username;
        private string password;
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
        public LoginViewModel()
        {
            _OpenRegisterWindowCommand = new OpenRegisterWindowCommand();
            _OpenShopWindowCommand = new OpenShopWindowCommand();
            _LoginCommand = new LoginCommand(this);
            
        }
    }
}
