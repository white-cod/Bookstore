using BookShelfProject.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookShelfProject.MVVM.ViewModels
{
    public class AddBookViewModel : ViewModelBase
    {
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

        public ICommand _AddBookCommand { get; }
        public ICommand _OpenCabinetWindowCommand { get; }
        public ICommand _SelectNewBookCover { get; }
        public ICommand _SelectNewBookSummary { get; }
        public AddBookViewModel()
        {
            _AddBookCommand = new AddBookCommand(this);
            _SelectNewBookCover = new SelectNewBookCoverCommand(this);
            _SelectNewBookSummary = new SelectNewBookSummaryCommand(this);
            _OpenCabinetWindowCommand = new OpenCabinetWindowCommand();
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
