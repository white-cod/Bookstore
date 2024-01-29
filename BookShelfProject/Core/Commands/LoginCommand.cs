using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.Models;
using BookShelfProject.MVVM.ViewModels;

namespace BookShelfProject.Core.Commands;

public class LoginCommand : CommandBase
{
    private readonly LoginViewModel _currentViewModel;
    private readonly DatabaseContext _context;

    public LoginCommand(LoginViewModel currentViewModel)
    {
        _currentViewModel = currentViewModel;
        _context = ServiceLocator.GetService<DatabaseContext>();
    }

    public override void Execute(object? parameter)
    {
        if (string.IsNullOrEmpty(_currentViewModel.Username) || string.IsNullOrEmpty(_currentViewModel.Password))
        {
            MessageBox.Show("Please fill in all fields.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            return;
        }
        if (!IsUserExistAndLogin(_currentViewModel.Username, _currentViewModel.Password))
        {
            MessageBox.Show("Username or password is incorrect", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            return;
        }
        User user = _context.Users.Where((User u) => u.Username == _currentViewModel.Username).ToList().FirstOrDefault();
        CurrentUserDataStore userData = ServiceLocator.GetService<CurrentUserDataStore>();
        userData.CurrentUser = user;
        userData.LoginUser();
        _currentViewModel._OpenShopWindowCommand.Execute(null);
    }

    private bool IsUserExistAndLogin(string username, string password)
    {
        var user = _context.Users?.Where(u => u.Username == username)?.ToList().FirstOrDefault();
        if (user != null)
        {
            string hashedPassword = HashPassword(password);
            if (user.Password == hashedPassword)
            {
                return true;
            }
        }
        return false;
    }

    private string HashPassword(string password)
    {
        using SHA256 sha256 = SHA256.Create();
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