using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.Views;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShelfProject.MVVM.ViewModels;
using Microsoft.Win32;

namespace BookShelfProject.Core.Commands
{
    public class OpenProfileCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var user = ServiceLocator.GetService<CurrentUserDataStore>();

            if(user != null)
            {
                if(user.IsLogin)
                {
                    var cabinet = ServiceLocator.GetService<PersonalCabinetWindow>();

                    cabinet = new PersonalCabinetWindow()
                    {
                        DataContext = ServiceLocator.GetService<PersonalCabinetViewModel>()
                    };

                    cabinet.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                    cabinet.Show();

                    foreach (Window w in Application.Current.Windows)
                    {
                        if(w != cabinet)
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
