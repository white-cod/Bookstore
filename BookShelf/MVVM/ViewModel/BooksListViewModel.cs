using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShelf.Core;
using BookShelf.MVVM.Model;

namespace BookShelf.MVVM.ViewModel
{
    public class BooksListViewModel : BaseViewModel
    {
        private ObservableCollection<Book> searchedBooks;
        public ObservableCollection<Book> SearchedBooks
        {
            get { return searchedBooks; }
            set
            {
                if (value != searchedBooks)
                {
                    searchedBooks = value;
                    OnPropertyChanged(nameof(SearchedBooks));
                }
            }
        }
        public BooksListViewModel(ObservableCollection<Book> Books) 
        {
            SearchedBooks = Books;
        }
    }
}
