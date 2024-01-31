using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.MVVM.Models;
using BookShelfProject.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookShelfProject.Core.Commands
{
    public class RemoveBookFromCartCommand : CommandBase
    {
        private readonly ShoppingCartViewModel _shoppingCartViewModel;  
        public RemoveBookFromCartCommand(ShoppingCartViewModel shoppingCartViewModel)
        {
            _shoppingCartViewModel = shoppingCartViewModel;
        }
        public async override void Execute(object? parameter)
        {
            if (parameter != null && parameter is Cart item)
            {
                var selectedCart = parameter as Cart;

                var context = ServiceLocator.GetService<DatabaseContext>();
                var cartInContext = await context.ShoppingCart.FindAsync(selectedCart?.CartId);

                if (cartInContext == null) return;

                context.ShoppingCart.Remove(cartInContext);
                await context.SaveChangesAsync();
                _shoppingCartViewModel.CurrentCart = new ObservableCollection<Cart>(_shoppingCartViewModel._CurrentUserDataStore.CurrentUser._ShoppingCart);

                _shoppingCartViewModel.CalculateTotalPrice();
                MessageBox.Show("Book removed successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }          
        }
    }
}
