using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.Models;
using BookShelfProject.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class FindAddBookCartCommand : CommandBase
    {
        private readonly ShoppingCartViewModel _shoppingCartViewModel;
        public FindAddBookCartCommand(ShoppingCartViewModel shoppingCartViewModel)
        {
            _shoppingCartViewModel = shoppingCartViewModel;
        }
        public async override void Execute(object? parameter)
        {
            if (parameter == null || string.IsNullOrEmpty(parameter.ToString()))
            {
                return;
            }

            var searchString = parameter.ToString();

            var userData = ServiceLocator.GetService<CurrentUserDataStore>();
            var context = ServiceLocator.GetService<DatabaseContext>();

            var book = context.Books.Where(b => b.Title.ToLower().Contains(searchString.ToLower()))?.FirstOrDefault();

            if (book != null)
            {
                Cart addedCart = new Cart()
                {
                    _Book = book,
                    _User = userData.CurrentUser
                };

                context.ShoppingCart.Add(addedCart);

                await context.SaveChangesAsync();            
            }

            _shoppingCartViewModel.CalculateTotalPrice();

            MessageBox.Show("Book added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
