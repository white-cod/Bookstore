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

namespace BookStoreTest
{
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=BookStore;Integrated Security=True;";

        private SqlConnection connection = new SqlConnection(ConnectionString);

        private DataTable booksTable;
        private int currentBookIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            booksTable = GetBooksData();
            DisplayBookInfo();
        }

        private DataTable GetBooksData()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Books";
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
                string bookInfo = $"Title: {bookRow["title"]}\nAuthor: {bookRow["author"]}\nPublisher: {bookRow["publisher"]}\nPages: {bookRow["pages"]}";
                bookLabel.Content = bookInfo;
            }
            else
            {
                bookLabel.Content = "No more books.";
            }
        }

        private void NextBookButton_Click(object sender, RoutedEventArgs e)
        {
            currentBookIndex++;
            DisplayBookInfo();
        }

    }
}