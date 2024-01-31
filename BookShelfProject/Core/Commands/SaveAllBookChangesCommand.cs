using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.ViewModels;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class SaveAllBookChangesCommand : CommandBase
    {
        private readonly EditBookViewModel _editBookViewModel;
        private readonly DatabaseContext _context;
        public SaveAllBookChangesCommand(EditBookViewModel editBookViewModel)
        {
            _editBookViewModel = editBookViewModel;
            _context = ServiceLocator.GetService<DatabaseContext>();
        }
        public  async override void Execute(object? parameter)
        {
            var currentBook = ServiceLocator.GetService<SelectedBookToEditStore>();

            var bookDb = await _context.Books.FindAsync(currentBook.CurrentBook.BookId);

            bookDb.Title = _editBookViewModel.BookTitle;
            bookDb.Publisher = _editBookViewModel.BookPublisher;
            bookDb.Pages = _editBookViewModel.BookPages;
            bookDb.Genre = _editBookViewModel.BookGenre;
            bookDb.CostPrice = _editBookViewModel.BookCostPrice;
            bookDb.SalePrice = _editBookViewModel.BookSalePrice;
            bookDb.CoverPath = _editBookViewModel.BookCoverPath;
            bookDb.SummaryPath = _editBookViewModel.BookSummaryPath;

            await _context.SaveChangesAsync();

            MessageBox.Show("Changes saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
