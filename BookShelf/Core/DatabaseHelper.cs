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

namespace BookShelf.Core
{
    public static class DatabaseHelper
    {
        //private const string CONNECTION_STRING = "Data Source=DESKTOP-AJ6IRLC\\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private const string CONNECTION_STRING = "Data Source=DESKTOP-C85D6OJ\\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private static DataTable booksTable;

        static DatabaseHelper()
        {
            booksTable = GetBooksData();
        }

        private static DataTable GetBooksData()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
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

        private static Book CreateBookObject(DataRow row)
        {
            return new Book( row.Field<string>("title"),
                             row.Field<string>("author"),
                             row.Field<string>("publisher"),
                             row.Field<int?>("pages"),
                             row.Field<string>("genre"),
                             row.Field<int?>("publication_year"),
                             row.Field<decimal?>("cost_price"),
                             row.Field<decimal?>("sale_price"),
                             row.Field<int?>("continuation_of"),
                             row.Field<string?>("summary_path"),
                             row.Field<string?>("cover_path") );
        }
        public static List<Book> GetAllBooks()
        {
            List<DataRow> rows = booksTable.Select().ToList();

            List<Book> selectedBooks = new List<Book>();
            foreach (DataRow row in rows)
            {
                if (row != null) selectedBooks.Add(CreateBookObject(row));
            }
            
            return selectedBooks;
        }

        public static List<Book> GetBooksByGenre(string genre) => GetBooksBy("genre", genre);
        public static List<Book> GetBooksByAuthor(string author) => GetBooksBy("author", author);
        public static List<Book> GetBooksByTitle(string title) => GetBooksBy("title", title);
        private static List<Book> GetBooksBy(string parameter, string value)
        {
            List<DataRow> rows = booksTable.Select()
             .Where(row => row.Field<string>(parameter).Contains(value))
             .ToList();

            List<Book> selectedBooks = new List<Book>();
            foreach (DataRow row in rows)
            {
                if (row != null) selectedBooks.Add(CreateBookObject(row));
            }
            return selectedBooks;
        }
    }
}
