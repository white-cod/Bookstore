using BookShelf.MVVM.ViewModel;
using BookShelf.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics.Eventing.Reader;
using BookShelf.MVVM.View;
using Microsoft.EntityFrameworkCore.Metadata;
using BookShelf.Core.Managers;

namespace BookShelf.Core.Other
{
    public class UpdateViewCommand : ICommand // Support class for changing views in the application
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

            switch (parameter.ToString()) // Changes the current view according to the parameter
            {
                case "Home":
                    MainView.CurrentView = new HomeViewModel();
                    break;
                case "BooksList":
                    if (MainView.CurrentView is BooksListViewModel)
                        ((BooksListViewModel)MainView.CurrentView).SearchedBooks = SearchManager.SearchedBooks;
                    else
                        MainView.CurrentView = new BooksListViewModel(SearchManager.SearchedBooks);
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
