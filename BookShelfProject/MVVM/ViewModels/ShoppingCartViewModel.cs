using BookShelfProject.Context;
using BookShelfProject.Core.Commands;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.Models;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookShelfProject.MVVM.ViewModels
{
    public class ShoppingCartViewModel : ViewModelBase
    {
        private readonly DatabaseContext _context;

        private decimal? totalPrice;
        private ObservableCollection<Cart> currentCart;

        public CurrentUserDataStore _CurrentUserDataStore { get; set; }

        public decimal? TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public ObservableCollection<Cart> CurrentCart
        {
            get
            {
                return currentCart;
            }

            set
            {
                currentCart = value;
                _CurrentUserDataStore.CurrentUser._ShoppingCart = value;

                OnPropertyChanged(nameof(CurrentCart));
            }
        }

        public ICommand _FindAddBookCartCommand { get; }
        public ICommand _OpenShopWindowCommand { get; }
        public ICommand _RemoveBookFromCartCommand { get; }

        public ShoppingCartViewModel()
        {
            _CurrentUserDataStore = ServiceLocator.GetService<CurrentUserDataStore>();
            _context = ServiceLocator.GetService<DatabaseContext>();

            CurrentCart = new ObservableCollection<Cart>(_CurrentUserDataStore.CurrentUser._ShoppingCart);

            _FindAddBookCartCommand = new FindAddBookCartCommand(this);
            _OpenShopWindowCommand = new OpenShopWindowCommand();
            _RemoveBookFromCartCommand = new RemoveBookFromCartCommand(this);

            CalculateTotalPrice();
        }

        public void CalculateTotalPrice()
        {
            if (_CurrentUserDataStore.CurrentUser?._ShoppingCart == null || _CurrentUserDataStore.CurrentUser?._ShoppingCart?.Count == 0)
            {
                TotalPrice = 0;
                return;
            }

            decimal? price = 0;

            for (int i = 0; i < CurrentCart.Count; i++)
            {
                price += CurrentCart[i]._Book.CostPrice;
            }

            TotalPrice = price;
        }
    }
}
