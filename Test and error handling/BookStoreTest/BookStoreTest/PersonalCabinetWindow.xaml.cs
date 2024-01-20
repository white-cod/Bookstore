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
using static BookStoreTest.MainWindow;
using static BookStoreTest.ShoppingCartWindow;
using Microsoft.Win32;

namespace BookStoreTest
{
    public partial class PersonalCabinetWindow : Window
    {
        private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=BookStore;Integrated Security=True;";

        private string selectedAvatarPath;

        public PersonalCabinetWindow(double left = 0, double top = 0)
        {
            InitializeComponent();
            LoadUserData();

            Left = left;
            Top = top;
        }

        public class UserData
        {
            public string? Username { get; set; }
            public string? Email { get; set; }
            public string? Nickname { get; set; }
            public string? Name { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string? AvatarPath { get; set; }
            public bool IsAuthor { get; set; }
        }

        private UserData RetrieveUserData(string username)
        {
            UserData userData = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT username, email, nickname, name, date_of_birth, avatar_path, IsAuthor FROM Users WHERE username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userData = new UserData
                            {
                                Username = reader["username"].ToString(),
                                Email = reader["email"].ToString(),
                                Nickname = reader["nickname"].ToString(),
                                Name = reader["name"].ToString(),
                                DateOfBirth = reader["date_of_birth"] != DBNull.Value ? (DateTime?)reader["date_of_birth"] : null,
                                AvatarPath = reader["avatar_path"].ToString(),
                                IsAuthor = (bool)reader["IsAuthor"]
                            };
                        }
                    }
                }
            }

            return userData;
        }

        ///================== Avatar ==================///

        private void SelectAvatarButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedAvatarPath = openFileDialog.FileName;
                UpdateAvatarImage(selectedAvatarPath);
            }
        }

        private void UpdateAvatarImage(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath))
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                    avatarImage.Source = bitmapImage;
                }
                else
                {
                    Uri defaultImageUri = new Uri("D:\\My Documents\\Me\\Stockphoto\\no-profile-picture-icon.png");
                    BitmapImage defaultImage = new BitmapImage(defaultImageUri);
                    avatarImage.Source = defaultImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ///================== Avatar ==================///

        private void SaveAvatarPathToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Users SET " + "email = @Email, " + "nickname = @Nickname, " + "name = @Name, " + "date_of_birth = @DateOfBirth, " + "avatar_path = @AvatarPath " + "WHERE username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", CurrentUser.Email);
                    command.Parameters.AddWithValue("@Nickname", CurrentUser.Nickname);
                    command.Parameters.AddWithValue("@Name", CurrentUser.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", CurrentUser.DateOfBirth);
                    command.Parameters.AddWithValue("@AvatarPath", selectedAvatarPath);
                    command.Parameters.AddWithValue("@Username", CurrentUser.Username);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadUserData()
        {
            UserData userData = RetrieveUserData(CurrentUser.Username);

            if (userData != null)
            {
                CurrentUser.Email = userData.Email;
                CurrentUser.Nickname = userData.Nickname;
                CurrentUser.Name = userData.Name;
                CurrentUser.DateOfBirth = userData.DateOfBirth;
                CurrentUser.IsAuthor = userData.IsAuthor;

                selectedAvatarPath = userData.AvatarPath;
                UpdateAvatarImage(selectedAvatarPath);
            }

            DisplayUserData();

            TextBox_TextChanged(null, null);

            addBookButton.IsEnabled = CurrentUser.IsAuthor;
        }

        private void DisplayUserData()
        {
            usernameTextBox.Text = CurrentUser.Username;
            editEmailTextBox.Text = CurrentUser.Email;
            editNicknameTextBox.Text = CurrentUser.Nickname;
            editNameTextBox.Text = CurrentUser.Name;
            editDateOfBirthDatePicker.SelectedDate = CurrentUser.DateOfBirth;
        }

        private void UpdateUserInformation()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Users " + "SET email = @Email, " + " nickname = @Nickname, " + " name = @Name, " +" date_of_birth = @DateOfBirth " + "WHERE username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", CurrentUser.Email);
                    command.Parameters.AddWithValue("@Nickname", CurrentUser.Nickname);
                    command.Parameters.AddWithValue("@Name", CurrentUser.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", CurrentUser.DateOfBirth);
                    command.Parameters.AddWithValue("@Username", CurrentUser.Username);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = !string.IsNullOrWhiteSpace(editEmailTextBox.Text)
                                 && !string.IsNullOrWhiteSpace(editNicknameTextBox.Text)
                                 && !string.IsNullOrWhiteSpace(editNameTextBox.Text);

            UpdateBecomeAuthorButtonState();
            instructionsTextBlock.Visibility = AreRequiredFieldsFilled() ? Visibility.Collapsed : Visibility.Visible;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBecomeAuthorButtonState();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(editEmailTextBox.Text)
             || string.IsNullOrWhiteSpace(editNicknameTextBox.Text)
             || string.IsNullOrWhiteSpace(editNameTextBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            CurrentUser.Email = editEmailTextBox.Text;
            CurrentUser.Nickname = editNicknameTextBox.Text;
            CurrentUser.Name = editNameTextBox.Text;
            CurrentUser.DateOfBirth = editDateOfBirthDatePicker.SelectedDate;

            SaveAvatarPathToDatabase();

            MessageBox.Show("Changes saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CancelEditButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OpenShoppingCartWindow()
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow();

            shoppingCartWindow.Left = Left;
            shoppingCartWindow.Top = Top;

            shoppingCartWindow.Show();

            Close();
        }

        private void CartOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenShoppingCartWindow();
        }

        ///================== Becom Author ==================///

        private bool AreRequiredFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(editEmailTextBox.Text)
                && !string.IsNullOrWhiteSpace(editNicknameTextBox.Text)
                && !string.IsNullOrWhiteSpace(editNameTextBox.Text);
        }

        private void BecomeAuthorButton_Click(object sender, RoutedEventArgs e)
        {

            CurrentUser.IsAuthor = true;

            UpdateUserIsAuthorStatus(CurrentUser.Username, true);

            MessageBox.Show("Congratulations! You are now an author.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateUserIsAuthorStatus(string username, bool isAuthor)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Users SET IsAuthor = @IsAuthor WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IsAuthor", isAuthor);
                    command.Parameters.AddWithValue("@Username", username);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateBecomeAuthorButtonState()
        {
            becomeAuthorButton.IsEnabled = !string.IsNullOrWhiteSpace(editEmailTextBox.Text)
                                          && !string.IsNullOrWhiteSpace(editNicknameTextBox.Text)
                                          && !string.IsNullOrWhiteSpace(editNameTextBox.Text)
                                          && editDateOfBirthDatePicker.SelectedDate != null;
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow();
            addBookWindow.Show();
        }

    }
}