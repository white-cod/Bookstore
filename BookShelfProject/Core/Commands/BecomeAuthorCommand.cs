using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class BecomeAuthorCommand : CommandBase
    {
        private readonly PersonalCabinetViewModel _personalCabinetViewModel;

        public BecomeAuthorCommand(PersonalCabinetViewModel personalCabinetViewModel)
        {
            _personalCabinetViewModel = personalCabinetViewModel;
        }

        public async override void Execute(object? parameter)
        {
            var currentUserDataStore = ServiceLocator.GetService<CurrentUserDataStore>();
            var context = ServiceLocator.GetService<DatabaseContext>();

            currentUserDataStore.CurrentUser.IsAuthor = true;

            var dbUser = await context.Users.FindAsync(currentUserDataStore.CurrentUser.UserId);

            dbUser.IsAuthor = true;

            await context.SaveChangesAsync();

            _personalCabinetViewModel.RaisePropertyChanged(nameof(_personalCabinetViewModel.IsCurrentUserAuthor));
            _personalCabinetViewModel.RaisePropertyChanged(nameof(_personalCabinetViewModel.IsAuthorStatusAvailable));

            MessageBoxResult message = MessageBox.Show("You have become an author.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}
