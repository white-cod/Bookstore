using BookShelfProject.Core.Locators;
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
    public class OpenLoginWindowCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var window = ServiceLocator.GetService<LoginWindow>();

            window = new LoginWindow()
            {
                DataContext = ServiceLocator.GetService<LoginViewModel>()
            };

            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            window.Show();
            foreach (Window w in Application.Current.Windows)
            {
                if (w != window)
                    w.Close();
            }
        }
    }
}
