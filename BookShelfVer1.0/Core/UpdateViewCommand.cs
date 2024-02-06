using BookShelf.MVVM.ViewModel;
using BookShelf.MVVM.Model;
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
            PagesHistoryManager.RewriteHistory(MainView.CurrentView);
            switch (parameter.ToString())
            {
                case "Home":
                    MainView.CurrentView = new HomeViewModel();
                    break;
                case "BooksList":
                    MainView.CurrentView = new BooksListViewModel();
                    break;
                case "Catalogue":
                    MainView.CurrentView = new CatalogueListViewModel();
                    break;
                case "BookInfo":
                    MainView.CurrentView = new BookInfoViewModel(BookDataManager.BookData);
                    break;
                default:
                    MainView.CurrentView = new HomeViewModel();
                    break;
            }
            PagesHistoryManager.pagesHistory.Add(MainView.CurrentView);          
        }
    }
}
