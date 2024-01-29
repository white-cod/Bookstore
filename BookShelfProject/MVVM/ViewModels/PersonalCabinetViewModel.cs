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
        public bool IsSaveButtonEnabled => AreFieldsNotEmpty();
        public ICommand _OpenShopWindowCommand { get; }
        public ICommand _ChangeAvatarCommand { get; }
        public ICommand _SaveProfileChangesCommand { get; }

        private string username;
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
                OnPropertyChanged(nameof(Username));
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
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
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
                OnPropertyChanged(nameof(BirthDate));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
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
                OnPropertyChanged(nameof(AvatarPath));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
            }
        }
        public PersonalCabinetViewModel()
        {
            _CurrentUserDataStore = ServiceLocator.GetService<CurrentUserDataStore>();
            _OpenShopWindowCommand = new OpenShopWindowCommand();
            _ChangeAvatarCommand = new ChangeAvatarCommand(this);
            _SaveProfileChangesCommand = new SaveProfileChangesCommand(this);

            Username = _CurrentUserDataStore.CurrentUser.Username;
            Email = _CurrentUserDataStore.CurrentUser.Email == null ? string.Empty : _CurrentUserDataStore.CurrentUser.Email;
            BirthDate = _CurrentUserDataStore.CurrentUser.BirthDate;
            AvatarPath = _CurrentUserDataStore.CurrentUser.AvatarPath == null ? "D:\\My Documents\\Me\\Stockphoto\\no-profile-picture-icon.png" : _CurrentUserDataStore.CurrentUser.AvatarPath;
        }

        private bool AreFieldsNotEmpty()
        {
            return !string.IsNullOrEmpty(Username?.Trim()) &&
                   !string.IsNullOrEmpty(Email?.Trim()) &&
                   BirthDate.HasValue;
        }

       
    }
}
