using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.MVVM.Models;
using BookShelfProject.MVVM.ViewModels;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookShelfProject.Core.Commands
{
    public class RegisterCommand : CommandBase
    {
        private readonly RegistrationViewModel _currentViewModel;
        private readonly DatabaseContext _context;
        public RegisterCommand(RegistrationViewModel currentViewModel)
        {
            _currentViewModel = currentViewModel;
            _context = ServiceLocator.GetService<DatabaseContext>();
        }
        public async override void Execute(object? parameter)
        {
            if(string.IsNullOrEmpty(_currentViewModel.Username) || string.IsNullOrEmpty(_currentViewModel.Password) || string.IsNullOrEmpty(_currentViewModel.ConfirmationPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentViewModel.Password != _currentViewModel.ConfirmationPassword)
            {
                MessageBox.Show("Passwords do not match.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(IsUsernameTaken(_currentViewModel.Username))
            {
                MessageBox.Show("Username has already taken.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User newUser = new User()
            {
                Username = _currentViewModel.Username,
                Password = HashPassword(_currentViewModel.Password),
            };

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();

            MessageBox.Show("Registration successful. You can now log in.", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

       private bool IsUsernameTaken(string username)
       {
            var users = _context.Users.Where(u => u.Username == username).ToList();

            if (users.Count == 0)
            {
                return false;
            }
            else return true;
       }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
