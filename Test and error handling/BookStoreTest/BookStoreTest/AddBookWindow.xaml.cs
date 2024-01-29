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
using static BookStoreTest.MainWindow;
using static BookStoreTest.PersonalCabinetWindow;
using Microsoft.Win32;

namespace BookStoreTest
{
    public partial class AddBookWindow : Window
    {
        private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=BookStore;Integrated Security=True;";

        private string selectedCoverPath;
        private string selectedSummaryPath;

        public AddBookWindow(double left = 0, double top = 0)
        {
            InitializeComponent();
            DataContext = this;

            Left = left;
            Top = top;
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = titleTextBox.Text.Trim();
                string publisher = publisherTextBox.Text.Trim();
                int pages = int.Parse(pagesTextBox.Text.Trim());
                string genre = genreTextBox.Text.Trim();
                decimal costPrice = decimal.Parse(costPriceTextBox.Text.Trim());
                decimal salePrice = decimal.Parse(salePriceTextBox.Text.Trim());

                string username = CurrentUser.Name;
                int userId = CurrentUser.UserId;
                DateTime publicationYear = DateTime.Now;
                ResetForm();
                addBookButton.IsEnabled = false;

                string selectedCoverPath = GetSelectedCoverPath();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Books (Title, Publisher, Pages, Genre, CostPrice, SalePrice, Author, PublicationYear, CoverPath, SummaryPath, UserId) " +
                                   "VALUES (@Title, @Publisher, @Pages, @Genre, @CostPrice, @SalePrice, @Author, CONVERT(int, @PublicationYear), @CoverPath, @SummaryPath, @UserId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Publisher", publisher);
                        command.Parameters.AddWithValue("@Pages", pages);
                        command.Parameters.AddWithValue("@Genre", genre);
                        command.Parameters.AddWithValue("@CostPrice", costPrice);
                        command.Parameters.AddWithValue("@SalePrice", salePrice);
                        command.Parameters.AddWithValue("@Author", username);
                        command.Parameters.AddWithValue("@PublicationYear", publicationYear);
                        command.Parameters.AddWithValue("@CoverPath", selectedCoverPath);
                        command.Parameters.AddWithValue("@SummaryPath", selectedSummaryPath);
                        command.Parameters.AddWithValue("@UserId", userId);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Book added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding book: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

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

            addBookButton.IsEnabled = allFieldsFilled;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateFields();
        }

        private void OpenAddBookWindow()
        {
            AddBookWindow addBookWindow = new AddBookWindow();

            addBookWindow.Left = Left;
            addBookWindow.Top = Top;

            addBookWindow.Show();

            Close();
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