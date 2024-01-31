using AutoMapper;
using BookShelfProject.Context;
using BookShelfProject.Core.Commands;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookShelfProject.MVVM.ViewModels
{
    public class UsersBooksViewModel : ViewModelBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly CurrentUserDataStore _currentUserDataStore;

        public ICommand _OpenEditBookWindowCommand { get; }
        public ICommand _OpenCabinetWindowCommand { get; }
        public ICommand _RemoveBookCommand { get; }

        private ObservableCollection<ListBookDto> _usersBooks;

        public ObservableCollection<ListBookDto> _UsersBooks
        {
            get
            {
                return _usersBooks;
            }
            set
            {
                _usersBooks = value;
                OnPropertyChanged(nameof(_UsersBooks));
            }
        }

        public UsersBooksViewModel()
        {
            _context = ServiceLocator.GetService<DatabaseContext>();
            _mapper = ServiceLocator.GetService<IMapper>();
            _currentUserDataStore = ServiceLocator.GetService<CurrentUserDataStore>();

            _OpenEditBookWindowCommand = new OpenEditBookWindowCommand();
            _OpenCabinetWindowCommand = new OpenCabinetWindowCommand();
            _RemoveBookCommand = new RemoveBookCommand(this);

            _UsersBooks = new ObservableCollection<ListBookDto>(SelectUsersBooks());
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
