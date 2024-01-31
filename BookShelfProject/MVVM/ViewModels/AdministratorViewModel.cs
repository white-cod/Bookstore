using AutoMapper;
using BookShelfProject.Context;
using BookShelfProject.Core.Commands;
using BookShelfProject.Core.Locators;
using BookShelfProject.Dto;
using BookShelfProject.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookShelfProject.MVVM.ViewModels
{
    public class AdministratorViewModel : ViewModelBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public ObservableCollection<DbUserDto> _Users { get; set; }
        public ObservableCollection<DbBookDto> _Books { get; set; }
        public ObservableCollection<DbCartDto> _Carts { get; set; }

        public ICommand _OpenShopWindowCommand { get; }
        public ICommand _SaveAdminChangesCommand { get; set; }

        public AdministratorViewModel()
        {
            _context = ServiceLocator.GetService<DatabaseContext>();
            _mapper = ServiceLocator.GetService<IMapper>();
            _OpenShopWindowCommand = new OpenShopWindowCommand();
            _SaveAdminChangesCommand = new SaveAdminChangesCommand(this);

            _Users = new ObservableCollection<DbUserDto>(GetUsers());
            _Books = new ObservableCollection<DbBookDto>(GetBooks());
            _Carts = new ObservableCollection<DbCartDto>(GetCarts());
        }

        private List<DbUserDto> GetUsers()
        {
            List<User> users = _context.Users.ToList();

            if (users == null) return new List<DbUserDto>();

            return _mapper.Map<List<DbUserDto>>(users);
        }

        private List<DbBookDto> GetBooks()
        {
            List<Book> books = _context.Books.ToList();

            if (books == null) return new List<DbBookDto>();

            return _mapper.Map<List<DbBookDto>>(books);
        }

        private List<DbCartDto> GetCarts()
        {
            List<Cart> carts = _context.ShoppingCart.ToList();

            if (carts == null) return new List<DbCartDto>();

            return _mapper.Map<List<DbCartDto>>(carts);
        }
    }
}
