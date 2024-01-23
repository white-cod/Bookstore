using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelfProject.Core.Services
{
    public class NavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _viewModelFactory;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> viewModelFactory)
        {
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
        }

        public void Navigate()
        {                      
            _navigationStore.CurrentViewModel = _viewModelFactory();          
        }
    }
}
