using BookShelfProject.Core.Commands;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookShelfProject.MVVM.ViewModels
{
    public class EditBookViewModel : ViewModelBase
    {
        private readonly SelectedBookToEditStore _bookStore;
        private string bookTitle;
        private string bookPublisher;
        private int bookPages;
        private string bookGenre;
        private decimal bookCostPrice;
        private decimal bookSalePrice;
        private string bookCoverPath;
        private string bookSummaryPath;

        public bool AreFieldsFilled => AreFieldsNotEmpty();

        public string BookTitle
        {
            get { return bookTitle; }
            set
            {
                bookTitle = value;
                OnPropertyChanged(nameof(BookTitle));
                OnPropertyChanged(nameof(AreFieldsFilled));
            }
        }

        public string BookPublisher
        {
            get { return bookPublisher; }
            set
            {
                bookPublisher = value;
                OnPropertyChanged(nameof(BookPublisher));
                OnPropertyChanged(nameof(AreFieldsFilled));
            }
        }

        public int BookPages
        {
            get { return bookPages; }
            set
            {
                bookPages = value;
                OnPropertyChanged(nameof(BookPages));
                OnPropertyChanged(nameof(AreFieldsFilled));
            }
        }

        public string BookGenre
        {
            get { return bookGenre; }
            set
            {
                bookGenre = value;
                OnPropertyChanged(nameof(BookGenre));
                OnPropertyChanged(nameof(AreFieldsFilled));
            }
        }

        public decimal BookCostPrice
        {
            get { return bookCostPrice; }
            set
            {
                bookCostPrice = value;
                OnPropertyChanged(nameof(BookCostPrice));
                OnPropertyChanged(nameof(AreFieldsFilled));
            }
        }

        public decimal BookSalePrice
        {
            get { return bookSalePrice; }
            set
            {
                bookSalePrice = value;
                OnPropertyChanged(nameof(BookSalePrice));
                OnPropertyChanged(nameof(AreFieldsFilled));
            }
        }

        public string BookCoverPath
        {
            get { return bookCoverPath; }
            set
            {
                bookCoverPath = value;
                OnPropertyChanged(nameof(BookCoverPath));
                OnPropertyChanged(nameof(AreFieldsFilled));
            }
        }

        public string BookSummaryPath
        {
            get { return bookSummaryPath; }
            set
            {
                bookSummaryPath = value;
                OnPropertyChanged(nameof(BookSummaryPath));
                OnPropertyChanged(nameof(AreFieldsFilled));
            }
        }

        public ICommand _SaveAllBookChangesCommand { get; }
        public ICommand _OpenUsersBooksWindowCommand { get; }
        public ICommand _EditBookCoverCommand { get; }
        public ICommand _EditBookSummaryCommand { get; }

        public EditBookViewModel()
        {
            _bookStore = ServiceLocator.GetService<SelectedBookToEditStore>();

            _SaveAllBookChangesCommand = new SaveAllBookChangesCommand(this);
            _OpenUsersBooksWindowCommand = new OpenUsersBooksWindowCommand();
            _EditBookCoverCommand = new EditBookCoverCommand(this);
            _EditBookSummaryCommand = new EditBookSummaryCommand(this);

            BookTitle = _bookStore.CurrentBook.Title;
            BookPublisher = _bookStore.CurrentBook.Publisher;
            BookPages = _bookStore.CurrentBook.Pages;
            BookGenre = _bookStore.CurrentBook.Genre;
            BookCostPrice = _bookStore.CurrentBook.CostPrice;
            BookSalePrice = _bookStore.CurrentBook.SalePrice;
            BookCoverPath = _bookStore.CurrentBook.CoverPath;
            BookSummaryPath = _bookStore.CurrentBook.SummaryPath;
        }

        private bool AreFieldsNotEmpty()
        {
            return !string.IsNullOrEmpty(BookTitle?.Trim())
                && !string.IsNullOrEmpty(BookPublisher?.Trim())
                && !string.IsNullOrEmpty(BookGenre?.Trim())
                && (BookPages != 0)
                && (BookCostPrice != 0)
                && (BookSalePrice != 0)
                && !string.IsNullOrEmpty(BookCoverPath?.Trim())
                && !string.IsNullOrEmpty(BookSummaryPath?.Trim());
        }
    }
}
