using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class AddCurrentBookToCartCommand : CommandBase
    {
        private readonly CurrentBookDataStore _currentBookDataStore;
        private readonly CurrentUserDataStore _currentUserDataStore;
        private readonly DatabaseContext _context;
        public AddCurrentBookToCartCommand()
        {
            _currentBookDataStore = ServiceLocator.GetService<CurrentBookDataStore>();
            _currentUserDataStore = ServiceLocator.GetService<CurrentUserDataStore>();
            _context = ServiceLocator.GetService<DatabaseContext>();
        }
        public async override void Execute(object? parameter)
        {
            if(_currentBookDataStore != null && _currentUserDataStore.IsLogin)
            {
                Cart cart = new Cart()
                {
                    _Book = _currentBookDataStore.CurrentBook,
                    _User = _currentUserDataStore.CurrentUser
                };

                _context.ShoppingCart.Add(cart);

                await _context.SaveChangesAsync();

                MessageBox.Show("Book added to your's cart succesfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(!_currentUserDataStore.IsLogin)
            {
                MessageBox.Show("Login before trying to add the book to the cart.", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
