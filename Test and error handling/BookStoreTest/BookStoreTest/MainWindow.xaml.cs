using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BookStoreTest
{
    public partial class MainWindow : Window
    {
        //private const string ConnectionString = "Server=DESKTOP-AJ6IRLC\\\SQLEXPRESS;Database=BookStore;Integrated Security=True;";

        private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=BookStore;Integrated Security=True;";

        private SqlConnection connection = new SqlConnection(ConnectionString);

        private DataTable booksTable;
        private int currentBookIndex = 0;

        public class CurrentUser
        {
            public static int UserId { get; set; }
            public static string Username { get; set; }
            public static string Email { get; set; }
            public static string Nickname { get; set; }
            public static string Name { get; set; }
            public static DateTime? DateOfBirth { get; set; }
            public static string AvatarPath { get; set; }
            public static bool IsAuthor { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            booksTable = GetBooksData();
            currentBookIndex = 0;
            DisplayBookInfo();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private DataTable GetBooksData()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Books.*, BookCovers.cover_path, BookSummaries.summary_path " + "FROM Books " + "LEFT JOIN BookCovers ON Books.book_id = BookCovers.book_id " + "LEFT JOIN BookSummaries ON Books.book_id = BookSummaries.book_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void DisplayBookInfo()
        {
            if (currentBookIndex < booksTable.Rows.Count)
            {
                DataRow bookRow = booksTable.Rows[currentBookIndex];

                titleLabel.Content = $"{bookRow["title"]}";
                authorLabel.Content = $"{bookRow["author"]}";
                publisherLabel.Content = $"{bookRow["publisher"]}";
                pagesLabel.Content = $"{bookRow["pages"]}";

                string? coverImagePath = bookRow["cover_path"] as string;
                if (!string.IsNullOrEmpty(coverImagePath) && File.Exists(coverImagePath))
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(coverImagePath));
                    coverImage.Source = bitmapImage;
                }
                else
                {
                    coverImage.Source = null;
                }

                string? summaryFilePath = bookRow["summary_path"] as string;
                if (!string.IsNullOrEmpty(summaryFilePath) && File.Exists(summaryFilePath))
                {
                    string summaryText = File.ReadAllText(summaryFilePath);
                    summaryTextBox.Text = summaryText;
                }
                else
                {
                    summaryTextBox.Text = "No summary available.";
                }
            }
            else
            {
                titleLabel.Content = "No more books.";
                authorLabel.Content = string.Empty;
                publisherLabel.Content = string.Empty;
                pagesLabel.Content = string.Empty;
                summaryTextBox.Text = string.Empty;
                coverImage.Source = null;
            }
        }

        private void NextBookButton_Click(object sender, RoutedEventArgs e)
        {
            currentBookIndex++;
            DisplayBookInfo();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentBookIndex > 0)
            {
                currentBookIndex--;
                DisplayBookInfo();
            }
        }

        private void OpenPersonalCabinet_Click(object sender, RoutedEventArgs e)
        {
            PersonalCabinetWindow personalCabinetWindow = new PersonalCabinetWindow();
            personalCabinetWindow.Show();
        }

    }
}