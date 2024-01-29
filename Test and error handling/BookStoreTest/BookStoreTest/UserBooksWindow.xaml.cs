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
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using static BookStoreTest.MainWindow;
using static BookStoreTest.PersonalCabinetWindow;
using static BookStoreTest.ShoppingCartWindow;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStoreTest
{
    public partial class UserBooksWindow : Window
    {
        private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=BookStore;Integrated Security=True;";

        private ObservableCollection<Book> userBooks;

        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public decimal SalePrice { get; set; }
            public string CoverPath { get; set; }
            public BitmapImage CoverImage { get; set; }
            public string Publisher { get; set; }
            public int Pages { get; set; }
            public string Genre { get; set; }
            public decimal CostPrice { get; set; }
            public DateTime Created { get; set; }
            public string SummaryPath { get; set; }
        }

        public UserBooksWindow(double left = 0, double top = 0)
        {
            InitializeComponent();
            LoadUserBooks();

            Left = left;
            Top = top;
        }

        private void LoadUserBooks()
        {
            userBooks = new ObservableCollection<Book>(GetUserBooks(CurrentUser.UserId));
            userBooksListView.ItemsSource = userBooks;

            UpdateButtonStatus();
        }

        private List<Book> GetUserBooks(int userId)
        {
            List<Book> userBooks = new List<Book>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Books WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book
                            {
                                BookId = (int)reader["BookId"],
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                SalePrice = (decimal)reader["SalePrice"],
                                CoverPath = reader["CoverPath"].ToString(),
                                CoverImage = GetBitmapImage(reader["CoverPath"].ToString()),
                                Publisher = reader["Publisher"].ToString()
                            };

                            userBooks.Add(book);
                        }
                    }
                }
            }

            return userBooks;
        }
        private BitmapImage GetBitmapImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(imagePath);
                bitmapImage.EndInit();
                return bitmapImage;
            }
            else
            {
                return null;
            }
        }

        private void UpdateButtonStatus()
        {
            bool isItemSelected = userBooksListView.SelectedItem != null;
            editBookButton.IsEnabled = isItemSelected;
            removeBookButton.IsEnabled = isItemSelected;
        }
        private void userBooksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonStatus();
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = userBooksListView.SelectedItem as Book;

            if (selectedBook != null)
            {
                EditBookWindow editBookWindow = new EditBookWindow(selectedBook.BookId);
                editBookWindow.ShowDialog();

                LoadUserBooks();
            }
            else
            {
                MessageBox.Show("Please select a book to edit.", "Edit Book", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveBookButton_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = userBooksListView.SelectedItem as Book;

            if (selectedBook != null)
            {
                if (MessageBox.Show("Are you sure you want to remove this book?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    RemoveBook(selectedBook.BookId);
                    LoadUserBooks();
                }
            }
            else
            {
                MessageBox.Show("Please select a book to remove.", "Remove Book", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveBook(int bookId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Books WHERE BookId = @BookId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookId", bookId);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Book has been removed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: Book was not removed. {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenPersonalCabinetWindow()
        {
            PersonalCabinetWindow personalCabinetWindow = new PersonalCabinetWindow();

            personalCabinetWindow.Left = Left;
            personalCabinetWindow.Top = Top;

            personalCabinetWindow.Show();

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OpenPersonalCabinetWindow();
        }
    }
}