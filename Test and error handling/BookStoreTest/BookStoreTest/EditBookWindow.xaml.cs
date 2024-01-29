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
using static BookStoreTest.UserBooksWindow;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Win32;

namespace BookStoreTest
{
    public partial class EditBookWindow : Window
    {
        private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=BookStore;Integrated Security=True;";

        private int bookId;
        private string selectedSummaryPath;
        private string selectedCoverPath;

        public EditBookWindow(int bookId, double left = 0, double top = 0)
        {
            InitializeComponent();
            this.bookId = bookId;
            LoadBookDetails();

            Left = left;
            Top = top;
        }

        private void LoadBookDetails()
        {
            UserBooksWindow.Book book = GetBookDetails(bookId);

            if (book != null)
            {
                titleTextBox.Text = book.Title;
                publisherTextBox.Text = book.Publisher;
                pagesTextBox.Text = book.Pages.ToString();
                genreTextBox.Text = book.Genre;
                costPriceTextBox.Text = book.CostPrice.ToString();
                salePriceTextBox.Text = book.SalePrice.ToString();

                if (book.CoverImage != null)
                {
                    coverImage.Source = book.CoverImage;
                }

                coverPathTextBox.Text = book.CoverPath;

                bookSummaryPathTextBox.Text = book.SummaryPath;
            }
            else
            {
                MessageBox.Show("Book not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private UserBooksWindow.Book GetBookDetails(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Books WHERE BookId = @BookId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserBooksWindow.Book
                            {
                                BookId = (int)reader["BookId"],
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                SalePrice = (decimal)reader["SalePrice"],
                                CoverPath = reader["CoverPath"].ToString(),
                                CoverImage = GetBitmapImage(reader["CoverPath"].ToString()),
                                Publisher = reader["Publisher"].ToString(),
                                Pages = (int)reader["Pages"],
                                Genre = reader["Genre"].ToString(),
                                CostPrice = (decimal)reader["CostPrice"],
                                SummaryPath = reader["SummaryPath"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        ///================== Fields Logic ==================///

        private void ResetForm()
        {
            titleTextBox.Clear();
            publisherTextBox.Clear();
            pagesTextBox.Clear();
            genreTextBox.Clear();
            costPriceTextBox.Clear();
            salePriceTextBox.Clear();
            coverPathTextBox.Clear();
            bookSummaryPathTextBox.Clear();

            coverPathTextBox.Visibility = Visibility.Collapsed;
            bookSummaryPathTextBox.Visibility = Visibility.Collapsed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateFields();
        }

        private void ValidateFields()
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(titleTextBox.Text)
                                && !string.IsNullOrWhiteSpace(publisherTextBox.Text)
                                && !string.IsNullOrWhiteSpace(pagesTextBox.Text)
                                && !string.IsNullOrWhiteSpace(genreTextBox.Text)
                                && !string.IsNullOrWhiteSpace(costPriceTextBox.Text)
                                && !string.IsNullOrWhiteSpace(salePriceTextBox.Text)
                                && !string.IsNullOrWhiteSpace(coverPathTextBox.Text)
                                && !string.IsNullOrWhiteSpace(bookSummaryPathTextBox.Text);

            SaveButton.IsEnabled = allFieldsFilled;
        }

        ///================== Fields Logic ==================///


        ///================== Summary ==================///

        private string GetSelectedSummaryPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }

        private void SelectSummaryButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedSummaryPath = openFileDialog.FileName;
            }

            bookSummaryPathTextBox.Text = selectedSummaryPath;
            coverPathTextBox.Visibility = Visibility.Visible;

            ValidateFields();
        }

        ///================== Summary ==================///


        ///================== Cover ==================///

        private void UpdateCoverImage(string coverPath)
        {
            try
            {
                if (!string.IsNullOrEmpty(coverPath))
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(coverPath));
                    coverImage.Source = bitmapImage;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private string GetSelectedCoverPath()
        {
            return selectedCoverPath;
        }

        private void SelectCoverButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedCoverPath = openFileDialog.FileName;
                UpdateCoverImage(selectedCoverPath);
            }

            coverPathTextBox.Text = selectedCoverPath;
            bookSummaryPathTextBox.Visibility = Visibility.Visible;

            ValidateFields();
        }

        ///================== Cover ==================///

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = titleTextBox.Text.Trim();
                string publisher = publisherTextBox.Text.Trim();
                int pages = int.Parse(pagesTextBox.Text.Trim());
                string genre = genreTextBox.Text.Trim();
                decimal costPrice = decimal.Parse(costPriceTextBox.Text.Trim());
                decimal salePrice = decimal.Parse(salePriceTextBox.Text.Trim());

                string selectedCoverPath = GetSelectedCoverPath();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "UPDATE Books SET " +
                           "Title = @Title, " +
                           "Publisher = @Publisher, " +
                           "Pages = @Pages, " +
                           "Genre = @Genre, " +
                           "CostPrice = @CostPrice, " +
                           "SalePrice = @SalePrice, " +
                           "CoverPath = @CoverPath " +
                           "WHERE BookId = @BookId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookId", bookId);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Publisher", publisher);
                        command.Parameters.AddWithValue("@Pages", pages);
                        command.Parameters.AddWithValue("@Genre", genre);
                        command.Parameters.AddWithValue("@CostPrice", costPrice);
                        command.Parameters.AddWithValue("@SalePrice", salePrice);
                        command.Parameters.AddWithValue("@CoverPath", selectedCoverPath);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("All changes have been saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: no changes were made. {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}