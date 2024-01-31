using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.Models;
using BookShelfProject.MVVM.ViewModels;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class AddBookCommand : CommandBase
    {
        private readonly AddBookViewModel _addBookViewModel;
        public AddBookCommand(AddBookViewModel addBookViewModel)
        {
            _addBookViewModel = addBookViewModel;
        }
        public async override void Execute(object? parameter)
        {
            if (!_addBookViewModel.AreFieldsFilled)
            {
                MessageBox.Show("Please fill in all fields.", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var context = ServiceLocator.GetService<DatabaseContext>();

            var currentUser = context.Users.Find((ServiceLocator.GetService<CurrentUserDataStore>()).CurrentUser.UserId);

            if(currentUser == null) return;

            try
            {
                Book book = new Book()
                {
                    Title = _addBookViewModel.BookTitle,
                    Publisher = _addBookViewModel.BookPublisher,
                    Pages = _addBookViewModel.BookPages,
                    CostPrice = _addBookViewModel.BookCostPrice,
                    Genre = _addBookViewModel.BookGenre,
                    SalePrice = _addBookViewModel.BookSalePrice,
                    CoverPath = _addBookViewModel.BookCoverPath,
                    SummaryPath = _addBookViewModel.BookSummaryPath,
                    PublicationYear = DateTime.Now.Year,
                    AuthorUser = currentUser,
                    Author = currentUser.Name
                };

                if (book == null) return;

                context.Books.Add(book);

                await context.SaveChangesAsync();

                MessageBoxResult message = MessageBox.Show("New book added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                _addBookViewModel._OpenCabinetWindowCommand.Execute(null);
            }
            catch
            {
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }           
        }
    }
}
