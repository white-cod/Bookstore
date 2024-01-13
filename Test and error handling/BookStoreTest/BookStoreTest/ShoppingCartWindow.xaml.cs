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

namespace BookStoreTest
{
    public partial class ShoppingCartWindow : Window
    {
        private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=BookStore;Integrated Security=True;";

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

        private List<CartItem> cartItems;

        public ShoppingCartWindow()
        {
            InitializeComponent();
            cartItems = GetShoppingCartItems(CurrentUser.UserId);
            DisplayShoppingCart();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private List<CartItem> GetShoppingCartItems(int userId)
        {
            List<CartItem> items = new List<CartItem>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Books.*, ShoppingCarts.quantity, BookCovers.cover_path " +
                               "FROM ShoppingCarts " +
                               "INNER JOIN Books ON ShoppingCarts.book_id = Books.book_id " +
                               "LEFT JOIN BookCovers ON Books.book_id = BookCovers.book_id " +
                               "WHERE ShoppingCarts.user_id = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CartItem item = new CartItem
                            {
                                BookId = (int)reader["book_id"],
                                Title = reader["title"].ToString(),
                                Author = reader["author"].ToString(),
                                SalePrice = (decimal)reader["sale_price"],
                                CoverPath = reader["cover_path"].ToString(),
                                CoverImage = GetBitmapImage(reader["cover_path"].ToString())
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

            decimal totalAmount = cartItems.Sum(item => item.TotalCost);
            totalAmountTextBox.Text = totalAmount.ToString(CultureInfo.InvariantCulture) + " $";

            if (cartListView.View is GridView gridView)
            {
                var coverColumn = new GridViewColumn
                {
                    Header = "Cover",
                    DisplayMemberBinding = new Binding("CoverImage")
                };

                gridView.Columns.Add(coverColumn);
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

                string query = "SELECT book_id FROM Books WHERE title = @Title";

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

                string query = "SELECT COUNT(*) FROM ShoppingCarts WHERE user_id = @UserId AND book_id = @BookId";

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

                string query = "SELECT COUNT(*) FROM Users WHERE user_id = @UserId";

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

                string query = "SELECT COUNT(*) FROM Books WHERE book_id = @BookId";

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

                            string query = "INSERT INTO ShoppingCarts (user_id, book_id, quantity) VALUES (@UserId, @BookId, 1)";

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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            PersonalCabinetWindow personalCabinetWindow = new PersonalCabinetWindow();
            personalCabinetWindow.Show();

            Close();
        }
    }
}