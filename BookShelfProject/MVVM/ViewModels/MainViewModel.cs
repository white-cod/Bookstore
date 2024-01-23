using BookShelfProject.Context;
using BookShelfProject.Core.Commands;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Services;
using BookShelfProject.Core.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookShelfProject.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public CurrentUserDataStore _CurrentUserDataStore { get; }
        public ViewModelBase CurrentViewModel
        {
            get => _navigationStore.CurrentViewModel;
            set
            {
                _navigationStore.CurrentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateCatalogueCommand { get; }
        public ICommand _NavigateNextCommand { get; }
        public ICommand _NavigatePreviousCommand { get; }
        public ICommand _OpenProfileCommand { get; }
        public ICommand SearchBookCommand { get; }

        public MainViewModel()
        {
            _navigationStore = ServiceLocator.GetService<NavigationStore>();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationStore.CurrentViewModel = new HomeViewModel();
            _navigationStore.ViewModelsHistory.Add(_navigationStore.CurrentViewModel);

            _CurrentUserDataStore = ServiceLocator.GetService<CurrentUserDataStore>();

            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(ServiceLocator.GetService<INavigationService<HomeViewModel>>());
            NavigateCatalogueCommand = new NavigateCommand<CatalogueViewModel>(ServiceLocator.GetService<INavigationService<CatalogueViewModel>>());

            _NavigateNextCommand = new NavigateNextCommand();
            _NavigatePreviousCommand = new NavigatePreviousCommand();

            SearchBookCommand = new OpenSearchResultCommand();
            _OpenProfileCommand = new OpenProfileCommand();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
