using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows;
using System.Windows.Controls;


namespace BookStoreTest
{
    public partial class AdministratorWindow : Window
    {
        private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=BookStore;Integrated Security=True;";

        public AdministratorWindow()
        {
            InitializeComponent();
            LoadBooksTab();
            LoadUsersTab();
            LoadShoppingCartsTab();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        ///================== Users Tab ==================///

        private void LoadUsersTab()
        {
            List<User> users = GetUsers();

            DataGrid dataGrid = new DataGrid();
            dataGrid.ItemsSource = users;

            TabItem usersTab = (TabItem)tabControl.Items[2];
            usersTab.Content = dataGrid;
        }

        private List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Users";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                UserId = (int)reader["UserId"],
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Email = reader["Email"].ToString(),
                                Nickname = reader["Nickname"].ToString(),
                                Name = reader["Name"].ToString(),
                                BirthDate = reader["BirthDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["BirthDate"],
                                AvatarPath = reader["AvatarPath"].ToString(),
                                IsAuthor = (bool)reader["IsAuthor"],
                                IsAdmin = reader["IsAdmin"] == DBNull.Value ? false : (bool)reader["IsAdmin"]
                            };


                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public class User
        {
            public int UserId { get; set; }
            public string? Username { get; set; }
            public string? Password { get; set; }
            public string? Email { get; set; }
            public string? Nickname { get; set; }
            public string? Name { get; set; }
            public DateTime BirthDate { get; set; }
            public string? AvatarPath { get; set; }
            public bool IsAuthor { get; set; }
            public bool IsAdmin { get; set; }
        }

        ///================== Users Tab ==================///


        ///================== Books Tab ==================///

        private void LoadBooksTab()
        {
            List<Book> books = GetBooks();

            DataGrid dataGrid = new DataGrid();
            dataGrid.ItemsSource = books;

            TabItem booksTab = (TabItem)tabControl.Items[0];
            booksTab.Content = dataGrid;
        }

        private List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Books";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book
                            {
                                BookId = (int)reader["BookId"],
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Publisher = reader["Publisher"].ToString(),
                                Pages = reader["Pages"] == DBNull.Value ? 0 : (int)reader["Pages"],
                                Genre = reader["Genre"].ToString(),
                                PublicationYear = reader["PublicationYear"] == DBNull.Value ? 0 : (int)reader["PublicationYear"],
                                CostPrice = reader["CostPrice"] == DBNull.Value ? 0.0m : (decimal)reader["CostPrice"],
                                SalePrice = reader["SalePrice"] == DBNull.Value ? 0.0m : (decimal)reader["SalePrice"],
                                ContinuationOf = reader["ContinuationOf"] == DBNull.Value ? (int?)null : (int)reader["ContinuationOf"],
                                CoverPath = reader["CoverPath"].ToString(),
                                SummaryPath = reader["SummaryPath"].ToString(),
                                UserId = (int)reader["UserId"],
                                IsRecommended = reader["IsRecommended"] == DBNull.Value ? false : (bool)reader["IsRecommended"],
                                IsDiscount = reader["IsDiscount"] == DBNull.Value ? false : (bool)reader["IsDiscount"]
                            };


                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }

        public class Book
        {
            public int BookId { get; set; }
            public string? Title { get; set; }
            public string? Author { get; set; }
            public string? Publisher { get; set; }
            public int Pages { get; set; }
            public string? Genre { get; set; }
            public int PublicationYear { get; set; }
            public decimal CostPrice { get; set; }
            public decimal SalePrice { get; set; }
            public int? ContinuationOf { get; set; }
            public string? CoverPath { get; set; }
            public string? SummaryPath { get; set; }
            public int UserId { get; set; }
            public bool IsRecommended { get; set; }
            public bool IsDiscount { get; set; }
        }


        ///================== Books Tab ==================///


        ///================== Shopping Carts Tab ==================///

        private void LoadShoppingCartsTab()
        {
            List<ShoppingCart> shoppingCarts = GetShoppingCarts();

            DataGrid dataGrid = new DataGrid();
            dataGrid.ItemsSource = shoppingCarts;

            TabItem shoppingCartsTab = (TabItem)tabControl.Items[1];
            shoppingCartsTab.Content = dataGrid;
        }

        private List<ShoppingCart> GetShoppingCarts()
        {
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM ShoppingCarts";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ShoppingCart cart = new ShoppingCart
                            {
                                CartId = (int)reader["CartId"],
                                UserId = (int)reader["UserId"],
                                BookId = (int)reader["BookId"],
                                Quantity = (int)reader["quantity"]
                            };

                            shoppingCarts.Add(cart);
                        }
                    }
                }
            }

            return shoppingCarts;
        }

        public class ShoppingCart
        {
            public int CartId { get; set; }
            public int UserId { get; set; }
            public int BookId { get; set; }
            public int Quantity { get; set; }
        }

        ///================== Shopping Carts Tab ==================///


        ///================== Save Logic ==================///

        private void SaveChanges()
        {
            SaveBooksChanges();
            SaveShoppingCartsChanges();
            SaveUsersChanges();
        }

        private void SaveBooksChanges()
        {
            TabItem booksTab = (TabItem)tabControl.Items[0];
            DataGrid dataGrid = (DataGrid)booksTab.Content;

            if (dataGrid.ItemsSource is List<Book> books)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    foreach (Book book in books)
                    {
                        string updateQuery = @"UPDATE Books SET 
                                Title = @Title, 
                                Author = @Author, 
                                Publisher = @Publisher, 
                                Pages = @Pages, 
                                Genre = @Genre, 
                                PublicationYear = @PublicationYear, 
                                CostPrice = @CostPrice, 
                                SalePrice = @SalePrice, 
                                ContinuationOf = @ContinuationOf, 
                                CoverPath = @CoverPath, 
                                SummaryPath = @SummaryPath, 
                                UserId = @UserId, 
                                IsRecommended = @IsRecommended, 
                                IsDiscount = @IsDiscount 
                                WHERE BookId = @BookId";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@BookId", book.BookId);
                            command.Parameters.AddWithValue("@Title", book.Title);
                            command.Parameters.AddWithValue("@Author", book.Author);
                            command.Parameters.AddWithValue("@Publisher", book.Publisher);
                            command.Parameters.AddWithValue("@Pages", book.Pages);
                            command.Parameters.AddWithValue("@Genre", book.Genre);
                            command.Parameters.AddWithValue("@PublicationYear", book.PublicationYear);
                            command.Parameters.AddWithValue("@CostPrice", book.CostPrice);
                            command.Parameters.AddWithValue("@SalePrice", book.SalePrice);

                            SqlParameter continuationOfParam = new SqlParameter("@ContinuationOf", SqlDbType.Int);
                            continuationOfParam.Value = (object)book.ContinuationOf ?? DBNull.Value;
                            command.Parameters.Add(continuationOfParam);

                            command.Parameters.AddWithValue("@CoverPath", book.CoverPath);
                            command.Parameters.AddWithValue("@SummaryPath", book.SummaryPath);
                            command.Parameters.AddWithValue("@UserId", book.UserId);
                            command.Parameters.AddWithValue("@IsRecommended", book.IsRecommended);
                            command.Parameters.AddWithValue("@IsDiscount", book.IsDiscount);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void SaveShoppingCartsChanges()
        {
            TabItem shoppingCartsTab = (TabItem)tabControl.Items[1];
            DataGrid dataGrid = (DataGrid)shoppingCartsTab.Content;

            if (dataGrid.ItemsSource is List<ShoppingCart> shoppingCarts)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    foreach (ShoppingCart cart in shoppingCarts)
                    {
                        string updateQuery = @"UPDATE ShoppingCarts SET 
                                UserId = @UserId, 
                                BookId = @BookId, 
                                Quantity = @Quantity 
                                WHERE CartId = @CartId";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CartId", cart.CartId);
                            command.Parameters.AddWithValue("@UserId", cart.UserId);
                            command.Parameters.AddWithValue("@BookId", cart.BookId);
                            command.Parameters.AddWithValue("@Quantity", cart.Quantity);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void SaveUsersChanges()
        {
            TabItem usersTab = (TabItem)tabControl.Items[2];
            DataGrid dataGrid = (DataGrid)usersTab.Content;

            if (dataGrid.ItemsSource is List<User> users)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    foreach (User user in users)
                    {
                        string updateQuery = @"UPDATE Users SET 
                                Username = @Username, 
                                Password = @Password, 
                                Email = @Email, 
                                Nickname = @Nickname, 
                                Name = @Name, 
                                BirthDate = @BirthDate, 
                                AvatarPath = @AvatarPath, 
                                IsAuthor = @IsAuthor, 
                                IsAdmin = @IsAdmin 
                                WHERE UserId = @UserId";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", user.UserId);
                            command.Parameters.AddWithValue("@Username", user.Username);
                            command.Parameters.AddWithValue("@Password", user.Password);
                            command.Parameters.AddWithValue("@Email", user.Email);
                            command.Parameters.AddWithValue("@Nickname", user.Nickname);
                            command.Parameters.AddWithValue("@Name", user.Name);

                            SqlParameter birthDateParam = new SqlParameter("@BirthDate", SqlDbType.DateTime);
                            birthDateParam.Value = (user.BirthDate >= SqlDateTime.MinValue.Value && user.BirthDate <= SqlDateTime.MaxValue.Value)
                                ? (object)user.BirthDate
                                : SqlDateTime.MinValue.Value;
                            command.Parameters.Add(birthDateParam);

                            command.Parameters.AddWithValue("@AvatarPath", user.AvatarPath);
                            command.Parameters.AddWithValue("@IsAuthor", user.IsAuthor);
                            command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        private void SaveAllChangesButton_Click(object sender, RoutedEventArgs e)
        {
            SaveChanges();

            MessageBox.Show("All changes have been saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        ///================== Save Logic ==================///

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}