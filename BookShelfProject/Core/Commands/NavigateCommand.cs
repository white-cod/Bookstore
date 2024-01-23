using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.ViewModels;
using BookShelfProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShelfProject.Core.Locators;

namespace BookShelfProject.Core.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly INavigationService<TViewModel> _navigationService;

        public NavigateCommand(INavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            var _navigationStore = ServiceLocator.GetService<NavigationStore>();

            _navigationStore.RewriteViewModelsHistory();
            _navigationService.Navigate();
            _navigationStore.ViewModelsHistory.Add(_navigationStore.CurrentViewModel);
        }
    }
}
