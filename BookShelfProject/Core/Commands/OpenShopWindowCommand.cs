using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class OpenShopWindowCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var window = ServiceLocator.GetService<MainWindow>();

            window = new MainWindow()
            {
                DataContext = ServiceLocator.GetService<MainViewModel>()
            };

            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            window.Show();
            foreach (Window w in Application.Current.Windows)
            {
                if(w != window)
                    w.Close();
            }
        }
    }
}
