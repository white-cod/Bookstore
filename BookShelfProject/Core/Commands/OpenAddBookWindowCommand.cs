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
    public class OpenAddBookWindowCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var window = ServiceLocator.GetService<AddBookWindow>();

            window = new AddBookWindow()
            {
                DataContext = ServiceLocator.GetService<AddBookViewModel>()
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
