using System.Collections.ObjectModel;
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
using BookShelf.Core.Helpers;
using BookShelf.MVVM.Model;
using BookShelf.MVVM.ViewModel;

namespace BookShelf.MVVM.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Book> recommended_books { get; set; }
        public ObservableCollection<Book> new_books { get; set; }
        public ObservableCollection<Book> offered_books { get; set; }
        public HomeViewModel() 
        {
            recommended_books = new ObservableCollection<Book>(DatabaseHelper.GetAllBooks()[0..5]);
            new_books = new ObservableCollection<Book>(DatabaseHelper.GetAllBooks()[5..10]);
            offered_books = new ObservableCollection<Book>(DatabaseHelper.GetAllBooks()[10..15]);
        }
    }
}
