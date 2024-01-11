using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using BookShelf.MVVM.Model;
using System.Data.Common;

namespace BookShelf.Core.Helpers
{
    public static class DatabaseHelper // Class that helps to get and handle data from the database
    {
        private const string ConnectionString = "Data Source=DESKTOP-AJ6IRLC\\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // private const string ConnectionString = "Data Source=DESKTOP-C85D6OJ\\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private static DataTable booksTable;
        static DatabaseHelper()
        {
            booksTable = GetBooksData();
        }
        private static DataTable GetBooksData() // Getting data from the database and saving it in the general table
        {
            DataTable dataTable = new DataTable();


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Books.*, BookCovers.cover_path, BookSummaries.summary_path " +
                               "FROM Books " +
                               "LEFT JOIN BookCovers ON Books.book_id = BookCovers.book_id " +
                               "LEFT JOIN BookSummaries ON Books.book_id = BookSummaries.book_id";
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
        private static Book CreateBookObject(DataRow row) // Creating Book object from db row parameters
        {
            return new Book(row.Field<string>("title"),
                             row.Field<string>("author"),
                             row.Field<string>("publisher"),
                             row.Field<int?>("pages"),
                             row.Field<string>("genre"),
                             row.Field<int?>("publication_year"),
                             row.Field<decimal?>("cost_price"),
                             row.Field<decimal?>("sale_price"),
                             row.Field<int?>("continuation_of"),
                             row.Field<string?>("summary_path"),
                             row.Field<string?>("cover_path"));
        }

        #region Get methods
        public static List<Book> GetAllBooks()
        {
            List<DataRow> rows = booksTable.Select().ToList(); // Getting all books data from the table

            List<Book> selectedBooks = new List<Book>();
            foreach (DataRow row in rows)
            {
                // Creating Book objects from list of the DataRows
                if (row != null) selectedBooks.Add(CreateBookObject(row));
            }

            return selectedBooks;
        }

        public static List<Book> GetBooksByGenre(string genre) => GetBooksBy("genre", genre);
        public static List<Book> GetBooksByAuthor(string author) => GetBooksBy("author", author);
        public static List<Book> GetBooksByTitle(string title) => GetBooksBy("title", title);
        private static List<Book> GetBooksBy(string parameter, string value) // General method for the data searching according to the search parameter and search value
        {
            List<DataRow> rows = booksTable.Select()
             .Where(row => row.Field<string>(parameter).ToLower().Contains(value.ToLower()))
             .ToList();

            List<Book> selectedBooks = new List<Book>();
            foreach (DataRow row in rows)
            {
                if (row != null) selectedBooks.Add(CreateBookObject(row));
            }
            return selectedBooks;
        }

        #endregion

        public static class CurrentUser
        {
            public static int UserId { get; set; }
            public static string Username { get; set; }
            public static string Email { get; set; }
            public static string Nickname { get; set; }
            public static string Name { get; set; }
            public static DateTime? DateOfBirth { get; set; }
            public static string AvatarPath { get; set; }
        }

        public class UserData
        {
            public string? Username { get; set; }
            public string? Email { get; set; }
            public string? Nickname { get; set; }
            public string? Name { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string? AvatarPath { get; set; }
        }
    }

}