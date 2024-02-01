using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Core.Commands
{
    public class LogoutCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            ServiceLocator.GetService<CurrentUserDataStore>().LogoutUser();

            var command = new OpenShopWindowCommand();
            command.Execute(null);
        }
    }
}
