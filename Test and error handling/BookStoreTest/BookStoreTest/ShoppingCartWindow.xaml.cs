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
using System.ComponentModel;

namespace BookStoreTest
{
    public partial class ShoppingCartWindow : Window, INotifyPropertyChanged
    {
        private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=BookStore;Integrated Security=True;";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isRemoveButtonEnabled;

        public bool IsRemoveButtonEnabled
        {
            get { return _isRemoveButtonEnabled; }
            set
            {
                if (_isRemoveButtonEnabled != value)
                {
                    _isRemoveButtonEnabled = value;
                    OnPropertyChanged(nameof(IsRemoveButtonEnabled));
                }
            }
        }

        public class CartItem
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public decimal SalePrice { get; set; }
            public string CoverPath { get; set; }
            public BitmapImage CoverImage { get; set; }
            public decimal TotalCost => SalePrice;
        }

        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public decimal SalePrice { get; set; }

        }

        private void CartListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsRemoveButtonEnabled = cartListView.SelectedItem != null;
        }

        private List<CartItem> cartItems;

        public ShoppingCartWindow(double left = 0, double top = 0)
        {
            InitializeComponent();
            cartItems = GetShoppingCartItems(CurrentUser.UserId);
            DataContext = this;
            DisplayShoppingCart();

            Left = left;
            Top = top;

            cartItems = GetShoppingCartItems(CurrentUser.UserId);
            DisplayShoppingCart();
            WindowStartupLocation = WindowStartupLocation.Manual;
        }

        private List<CartItem> GetShoppingCartItems(int userId)
        {
            List<CartItem> items = new List<CartItem>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Books.*, ShoppingCarts.quantity " +
                               "FROM ShoppingCarts " +
                               "INNER JOIN Books ON ShoppingCarts.BookId = Books.BookId " +
                               "WHERE ShoppingCarts.UserId = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CartItem item = new CartItem
                            {
                                BookId = (int)reader["BookId"],
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                SalePrice = (decimal)reader["SalePrice"],
                                CoverPath = reader["CoverPath"].ToString(),
                                CoverImage = GetBitmapImage(reader["CoverPath"].ToString())
                            };

                            items.Add(item);
                        }
                    }
                }
            }

            return items;
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

        private void DisplayShoppingCart()
        {
            cartListView.ItemsSource = cartItems;
            cartListView.SelectionChanged += CartListView_SelectionChanged;

            decimal totalAmount = cartItems.Sum(item => item.TotalCost);
            totalAmountTextBox.Text = totalAmount.ToString(CultureInfo.InvariantCulture) + " $";

            if (cartListView.View is GridView gridView)
            {
                var coverColumn = new GridViewColumn
                {
                    Header = "Cover",
                    DisplayMemberBinding = new Binding("CoverImage")
                };


            }
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            string bookTitle = bookTitleTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(bookTitle))
            {
                int bookId = GetBookIdByTitle(bookTitle);

                if (bookId != -1)
                {
                    if (!IsBookInCart(bookId))
                    {
                        AddBookToCart(bookId, bookTitle);
                        cartItems = GetShoppingCartItems(CurrentUser.UserId);
                        DisplayShoppingCart();
                    }
                    else
                    {
                        MessageBox.Show("This book is already in your cart.", "Add to Cart", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Book not found in the Books table.", "Add to Cart", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a book title.", "Add to Cart", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private int GetBookIdByTitle(string title)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT BookId FROM Books WHERE Title = @Title";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return (int)result;
                    }
                }
            }

            return -1;
        }

        private bool IsBookInCart(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM ShoppingCarts WHERE UserId = @UserId AND BookId = @BookId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", CurrentUser.UserId);
                    command.Parameters.AddWithValue("@BookId", bookId);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private bool IsUserExists(int userId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE UserId = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private bool IsBookExists(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Books WHERE BookId = @BookId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void AddBookToCart(int bookId, string bookTitle)
        {
            if (IsUserExists(CurrentUser.UserId))
            {
                if (IsBookExists(bookId))
                {
                    if (!IsBookInCart(bookId))
                    {
                        using (SqlConnection connection = new SqlConnection(ConnectionString))
                        {
                            connection.Open();

                            string query = "INSERT INTO ShoppingCarts (UserId, BookId, quantity) VALUES (@UserId, @BookId, 1)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@UserId", CurrentUser.UserId);
                                command.Parameters.AddWithValue("@BookId", bookId);

                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show($"Book '{bookTitle}' added to your cart.", "Add to Cart", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("This book is already in your cart.", "Add to Cart", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Book not found in the Books table.", "Add to Cart", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("User not found in the Users table.", "Add to Cart", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenPersonalCabinetWindow();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            CartItem selectedCartItem = cartListView.SelectedItem as CartItem;

            if (selectedCartItem != null)
            {
                RemoveBookFromCart(selectedCartItem.BookId);
            }
        }

        private void RemoveBookFromCart(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM ShoppingCarts WHERE UserId = @UserId AND BookId = @BookId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", CurrentUser.UserId);
                    command.Parameters.AddWithValue("@BookId", bookId);

                    command.ExecuteNonQuery();
                }
            }

            cartItems = GetShoppingCartItems(CurrentUser.UserId);
            DisplayShoppingCart();
        }
    }
}