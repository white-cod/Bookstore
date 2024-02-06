using Azure.Identity;
using BookShelfProject.Core.Commands;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace BookShelfProject.MVVM.ViewModels
{
    public class PersonalCabinetViewModel : ViewModelBase
    {
        public CurrentUserDataStore _CurrentUserDataStore { get; }
        public bool AreFieldsFilled => AreFieldsNotEmpty();
        public bool IsCurrentUserAuthor => IsUserAuthor();
        public bool IsAuthorStatusAvailable => IsAuthorAvailable();

        public ICommand _OpenShopWindowCommand { get; }
        public ICommand _OpenCartCommand { get; }
        public ICommand _ChangeAvatarCommand { get; }
        public ICommand _SaveProfileChangesCommand { get; }
        public ICommand _OpenAdminWindowCommand { get; }
        public ICommand _OpenAddBookWindowCommand { get; }
        public ICommand _OpenUsersBooksWindowCommand { get; }
        public ICommand _BecomeAuthorCommand { get; }
        public ICommand _LogoutCommand { get; }

        private string username;
        private string name;
        private string email;
        private DateTime? birthDate;
        private string avatarPath;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(nameof(AreFieldsFilled));
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(AreFieldsFilled));
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                OnPropertyChanged(nameof(AreFieldsFilled));
                OnPropertyChanged(nameof(Email));
            }
        }

        public DateTime? BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
                OnPropertyChanged(nameof(AreFieldsFilled));
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        public string AvatarPath
        {
            get
            {
                return avatarPath;
            }

            set
            {
                avatarPath = value;
                OnPropertyChanged(nameof(AreFieldsFilled));
                OnPropertyChanged(nameof(AvatarPath));
            }
        }

        public PersonalCabinetViewModel()
        {
            _CurrentUserDataStore = ServiceLocator.GetService<CurrentUserDataStore>();
            _OpenShopWindowCommand = new OpenShopWindowCommand();
            _ChangeAvatarCommand = new ChangeAvatarCommand(this);
            _SaveProfileChangesCommand = new SaveProfileChangesCommand(this);
            _OpenCartCommand = new OpenCartCommand();
            _OpenAdminWindowCommand = new OpenAdminWindowCommand();
            _OpenAddBookWindowCommand = new OpenAddBookWindowCommand();
            _BecomeAuthorCommand = new BecomeAuthorCommand(this);
            _OpenUsersBooksWindowCommand = new OpenUsersBooksWindowCommand();
            _LogoutCommand = new LogoutCommand();

            Username = _CurrentUserDataStore.CurrentUser.Username;
            Email = _CurrentUserDataStore.CurrentUser.Email == null ? string.Empty : _CurrentUserDataStore.CurrentUser.Email;
            Name = _CurrentUserDataStore.CurrentUser.Name == null ? string.Empty : _CurrentUserDataStore.CurrentUser.Name;
            BirthDate = _CurrentUserDataStore.CurrentUser.BirthDate;
            AvatarPath = _CurrentUserDataStore.CurrentUser.AvatarPath == null ? string.Empty : _CurrentUserDataStore.CurrentUser.AvatarPath;
        }

        public void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        private bool AreFieldsNotEmpty()
        {
            return !string.IsNullOrEmpty(Username?.Trim()) &&
                   !string.IsNullOrEmpty(Email?.Trim()) &&
                   !string.IsNullOrEmpty(Name?.Trim()) &&
                   BirthDate.HasValue;
        }

        private bool IsAuthorAvailable()
        {
            if (_CurrentUserDataStore.CurrentUser.IsAuthor)
                return false;

            return !string.IsNullOrEmpty(_CurrentUserDataStore.CurrentUser.Name?.Trim()) &&
                   !string.IsNullOrEmpty(_CurrentUserDataStore.CurrentUser.Username?.Trim()) &&
                   !string.IsNullOrEmpty(_CurrentUserDataStore.CurrentUser.Email?.Trim()) &&
                   _CurrentUserDataStore.CurrentUser.BirthDate.HasValue;
        }

        private bool IsUserAuthor()
        {
            return _CurrentUserDataStore.CurrentUser.IsAuthor;
        }
    }
}