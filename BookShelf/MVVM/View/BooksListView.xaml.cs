using BookShelf.Core;
using BookShelf.MVVM.Model;
using BookShelf.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookShelf.MVVM.View
{
    /// <summary>
    /// Interaction logic for BooksListView.xaml
    /// </summary>
    public partial class BooksListView : UserControl
    {
        public BooksListView()
        {
            InitializeComponent();
            DataContext = ((App)Application.Current).MainViewModel.CurrentView as BooksListViewModel;
        }

        private void Book_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;

            if (item != null)
            {
                Book SelectedBook = item.DataContext as Book;

                if (SelectedBook != null)
                {
                    BookDataManager.BookData = SelectedBook;
                    ((App)Application.Current).MainViewModel.UpdateViewCommand.Execute("BookInfo");
                }
            }
        }
    }
}
