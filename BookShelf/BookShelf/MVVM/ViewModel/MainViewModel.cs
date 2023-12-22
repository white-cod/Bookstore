using BookShelf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;

namespace BookShelf.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel // Main view model that contains current view
    {
        public ICommand UpdateViewCommand { get; private set; }

        private BaseViewModel currentView;
        public BaseViewModel CurrentView
        {
            get { return currentView; }                        
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            CurrentView = new HomeViewModel();
        }
    }
}
