using AutoMapper;
using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.MVVM.Models;
using BookShelfProject.MVVM.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class SaveAdminChangesCommand : CommandBase
    {
        private readonly AdministratorViewModel _adminViewModel;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public SaveAdminChangesCommand(AdministratorViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
            _context = ServiceLocator.GetService<DatabaseContext>();
            _mapper = ServiceLocator.GetService<IMapper>();
        }
        public async override void Execute(object? parameter)
        {
            UpdateBooksData();
            UpdateCartsData();
            UpdateUsersData();

            await _context.SaveChangesAsync();
            MessageBox.Show("Data changes saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateBooksData()
        {
            List<Book> EditedBooks = _mapper.Map<List<Book>>(_adminViewModel._Books.ToList());

            List<Book> books = _context.Books.ToList();

            for(int i = 0; i < books.Count; i++)
            {
                if (!EditedBooks.Any(b => b.BookId == books[i].BookId))
                {
                    _context.Books.Remove(books[i]);
                }
                else if (EditedBooks.Any(b => b.BookId == books[i].BookId))
                {
                    var editedBook = EditedBooks.Where(b => b.BookId == books[i].BookId).FirstOrDefault();

                    _context.Entry(books[i]).CurrentValues.SetValues(editedBook);
                }
            }

            for(int i = 0; i < EditedBooks.Count; i++)
            {
                if (!books.Any(b=>b.BookId == EditedBooks[i].BookId))
                {
                    _context.Books.Add(EditedBooks[i]);
                }
            }
        }

        private void UpdateUsersData()
        {
            List<User> EditedUsers = _mapper.Map<List<User>>(_adminViewModel._Users.ToList());

            List<User> users = _context.Users.ToList();

            for (int i = 0; i < users.Count; i++)
            {
                if (!EditedUsers.Any(u => u.UserId == users[i].UserId))
                {
                    _context.Users.Remove(users[i]);
                }
                else if (EditedUsers.Any(u => u.UserId == users[i].UserId))
                {
                    var editedBook = EditedUsers.Where(u => u.UserId == users[i].UserId).FirstOrDefault();

                    _context.Entry(users[i]).CurrentValues.SetValues(editedBook);
                }
            }

            for (int i = 0; i < EditedUsers.Count; i++)
            {
                if (!users.Any(u => u.UserId == EditedUsers[i].UserId))
                {
                    _context.Users.Add(EditedUsers[i]);
                }
            }
        }

        private void UpdateCartsData()
        {
            List<Cart> EditedCarts = _mapper.Map<List<Cart>>(_adminViewModel._Carts.ToList());

            List<Cart> carts = _context.ShoppingCart.ToList();

            for (int i = 0; i < carts.Count; i++)
            {
                if (!EditedCarts.Any(c => c.CartId == carts[i].CartId))
                {
                    _context.ShoppingCart.Remove(carts[i]);
                }
                else if (EditedCarts.Any(c => c.CartId == carts[i].CartId))
                {
                    var editedBook = EditedCarts.Where(c => c.CartId == carts[i].CartId).FirstOrDefault();

                    _context.Entry(carts[i]).CurrentValues.SetValues(editedBook);
                }
            }

            for (int i = 0; i < EditedCarts.Count; i++)
            {
                if (!carts.Any(c => c.CartId == EditedCarts[i].CartId))
                {
                    _context.ShoppingCart.Add(EditedCarts[i]);
                }
            }
        }
    }
}
