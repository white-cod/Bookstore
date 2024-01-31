using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Security.Cryptography;

namespace BookStoreTest
{
    public partial class RegistrationWindow : Window
    {
        private const string ConnectionString = "Data Source=OST_LAPTOP\\SQLEXPRESS;Initial Catalog=BookstoreDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=True;Multi Subnet Failover=False";
        public RegistrationWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordBox.Password.Trim();
            string confirmPassword = confirmPasswordBox.Password.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (IsUsernameTaken(username))
            {
                MessageBox.Show("Username is already taken. Please choose a different username.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            RegisterUser(username, password);

            MessageBox.Show("Registration successful. You can now log in.", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Application.Current.StartupUri = new Uri("MainWindow.xaml", UriKind.RelativeOrAbsolute);

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool IsUsernameTaken(string username)
        {
            return false;
        }

        private void RegisterUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string hashedPassword = HashPassword(password);

                string query = "INSERT INTO Users (UserId, Username, Password) VALUES (NEXT VALUE FOR Seq_Users, @Username, @Password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.ExecuteNonQuery();
                }
            }
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