using BookShelf.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookShelf.Core
{
    public class UpdateViewCommand : ICommand // Support class for changing views in an app
    {
        private MainViewModel MainView;

        public UpdateViewCommand(MainViewModel MainView) { this.MainView = MainView; }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }   
        public void Execute(object parameter) 
        { 
            switch(parameter.ToString())
            {
                case "Home":
                    MainView.CurrentView = new HomeViewModel();
                    break;
                case "BooksList":
                    MainView.CurrentView = new BooksListViewModel();
                    break;
                default:
                    MainView.CurrentView = new HomeViewModel();
                    break;
            }
        }
    }
}
