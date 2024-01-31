using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.Models;
using BookShelfProject.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class SaveProfileChangesCommand : CommandBase
    {
        private readonly PersonalCabinetViewModel _personalCabinetViewModel;
        private readonly DatabaseContext _context;
        public SaveProfileChangesCommand(PersonalCabinetViewModel personalCabinetViewModel)
        {
            _personalCabinetViewModel = personalCabinetViewModel;
            _context = ServiceLocator.GetService<DatabaseContext>();
        } 

        public async override void Execute(object? parameter)
        {
            var currentUser = ServiceLocator.GetService<CurrentUserDataStore>();

            var tableUser = await _context.Users.FindAsync(currentUser.CurrentUser.UserId);

            tableUser.Username = _personalCabinetViewModel.Username;
            tableUser.Name = _personalCabinetViewModel.Name;
            tableUser.Email = _personalCabinetViewModel.Email;
            tableUser.BirthDate = _personalCabinetViewModel.BirthDate;
            tableUser.AvatarPath = _personalCabinetViewModel.AvatarPath;

            await _context.SaveChangesAsync();

            _personalCabinetViewModel.RaisePropertyChanged(nameof(_personalCabinetViewModel.IsAuthorStatusAvailable));

            MessageBox.Show("Changes saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
