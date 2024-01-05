﻿using System.Collections.ObjectModel;
using System.Printing;
using System.Text;
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
using BookShelf.MVVM.ViewModel;
using BookShelf.MVVM.Model;
using BookShelf.Core;


namespace BookShelf.Core
{
    public enum SearchType
    {
        Title = 0,
        Author,
        Genre
    }
    public static class SearchManager
    {   
        public static ObservableCollection<Book> SearchedBooks{ get; private set; } = new ObservableCollection<Book>();
        public static void Search(SearchType SearchParameter, string SearchValue)
        {
            switch (SearchParameter)
            {
                case SearchType.Title:
                    SearchedBooks = new ObservableCollection<Book>(DatabaseHelper.GetBooksByTitle(SearchValue));
                    break;
                case SearchType.Author:
                    SearchedBooks = new ObservableCollection<Book>(DatabaseHelper.GetBooksByAuthor(SearchValue));
                    break;
                case SearchType.Genre:
                    SearchedBooks = new ObservableCollection<Book>(DatabaseHelper.GetBooksByGenre(SearchValue));
                    break;
                default:
                    SearchedBooks = new ObservableCollection<Book>(DatabaseHelper.GetAllBooks());
                    break;
            }

            ((App)Application.Current).MainViewModel.UpdateViewCommand.Execute("BooksList");
        }
    }
}
