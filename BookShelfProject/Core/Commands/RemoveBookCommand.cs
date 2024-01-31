using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Dto;
using BookShelfProject.MVVM.ViewModels;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BookShelfProject.Core.Stores;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BookShelfProject.Core.Commands
{
    public class RemoveBookCommand : CommandBase
    {
        private readonly UsersBooksViewModel _usersBooksViewModel;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly CurrentUserDataStore _currentUserDataStore;
        public RemoveBookCommand(UsersBooksViewModel usersBooksViewModel)
        {
            _usersBooksViewModel = usersBooksViewModel;
            _context = ServiceLocator.GetService<DatabaseContext>();
            _mapper = ServiceLocator.GetService<IMapper>();
            _currentUserDataStore = ServiceLocator.GetService<CurrentUserDataStore>();
        }
        public async override void Execute(object? parameter)
        {
            if (parameter == null) return;
            var context = ServiceLocator.GetService<DatabaseContext>();

            ListBookDto book = (ListBookDto)parameter;

            var bookDb = await context.Books.FindAsync(book.BookId);

            if (bookDb == null) return;

            context.Books.Remove(bookDb);

            await context.SaveChangesAsync();

            _usersBooksViewModel._UsersBooks = new ObservableCollection<ListBookDto>(SelectUsersBooks());

            MessageBox.Show("Book removed successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private List<ListBookDto> SelectUsersBooks()
        {
            var list = _mapper.Map<List<ListBookDto>>(_context.Books.Where(b => b.AuthorId == _currentUserDataStore.CurrentUser.UserId));
            if (list == null)
                return new List<ListBookDto>();

            return list;
        }
    }
}
