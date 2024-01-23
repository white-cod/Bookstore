using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Services;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Core.Commands
{
    public class OpenSearchResultCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (parameter == null || String.IsNullOrWhiteSpace(parameter.ToString())) return;

            ServiceLocator.GetService<SearchDataStore>().SearchString = parameter.ToString();

            var searchResultNavigationService = ServiceLocator.GetService<INavigationService<SearchResultViewModel>>();

            var navigationStore = ServiceLocator.GetService<NavigationStore>();

            if(navigationStore.CurrentViewModel is SearchResultViewModel searchResultViewModel)
            {
                searchResultViewModel.FilterAllCommand.Execute(null);
                return;
            }

            var navigateCommand = new NavigateCommand<SearchResultViewModel>(searchResultNavigationService);
            navigateCommand.Execute(null);
        }
    } 
}
