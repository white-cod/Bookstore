using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.ViewModels;
using BookShelfProject.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class OpenCartCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var user = ServiceLocator.GetService<CurrentUserDataStore>();

            if (user != null)
            {
                if (user.IsLogin)
                {
                    var cart = ServiceLocator.GetService<ShoppingCartWindow>();

                    cart = new ShoppingCartWindow()
                    {
                        DataContext = ServiceLocator.GetService<ShoppingCartViewModel>()
                    };

                    cart.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                    cart.Show();

                    foreach (Window w in Application.Current.Windows)
                    {
                        if (w != cart)
                        {
                            w.Close();
                        }
                    }

                }
                else
                {
                    var register = ServiceLocator.GetService<RegistrationWindow>();

                    register = new RegistrationWindow()
                    {
                        DataContext = ServiceLocator.GetService<RegistrationViewModel>()
                    };

                    register.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                    register.Show();

                    foreach (Window w in Application.Current.Windows)
                    {
                        if (w != register)
                        {
                            w.Close();
                        }
                    }
                }
            }
        }
    }
}
