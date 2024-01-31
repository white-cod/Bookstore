using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Profiles;
using BookShelfProject.Core.Services;
using BookShelfProject.Core.Stores;
using BookShelfProject.MVVM.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Documents;

namespace BookShelfProject.MVVM.Views
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window, INotifyPropertyChanged
    {
        #region Properties
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set
            {
                connectionString = value;
                OnPropertyChanged(nameof(ConnectionString));
            }
        }

        #endregion

        #region Constructor

        public StartupWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        #endregion

        #region Event Handlers

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender != null)
            {
                TextBox box = sender as TextBox;

                if (string.IsNullOrEmpty(box.Text))
                {
                    StartButton.IsEnabled = false;
                    return;
                }

                ConnectionString = box.Text;
                StartButton.IsEnabled = true;
            }
            else StartButton.IsEnabled = false;
        }

        private async void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckConnectionString())
            {
                MessageBox.Show("Fill in the connection string.", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsConnectionValid(ConnectionString))
            {
                MessageBox.Show("Incorrect connection string.", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            await InitializeServicesAndRunApp();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Private Methods

        private bool CheckConnectionString()
        {
            return !string.IsNullOrEmpty(ConnectionString);
        }

        private bool IsConnectionValid(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task InitializeServicesAndRunApp()
        {
            try
            {
                IServiceCollection services = new ServiceCollection();

                // Add DbContext
                services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseSqlServer(ConnectionString);
                }, ServiceLifetime.Scoped);

                // Add AutoMapper
                services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfiles>(), typeof(StartupWindow).Assembly);

                // Add Stores
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<SearchDataStore>();
                services.AddSingleton<CurrentBookDataStore>();
                services.AddSingleton<CurrentUserDataStore>();
                services.AddSingleton<SelectedBookToEditStore>();

                // Add ViewModels
                services.AddTransient<HomeViewModel>();
                services.AddTransient<CatalogueViewModel>();
                services.AddTransient<BookPageViewModel>();
                services.AddTransient<SearchResultViewModel>();

                // Add Navigation Services
                services.AddTransient<Func<SearchResultViewModel>>(provider => () => provider.GetRequiredService<SearchResultViewModel>());
                services.AddTransient<INavigationService<SearchResultViewModel>, NavigationService<SearchResultViewModel>>();

                services.AddTransient<Func<CatalogueViewModel>>(provider => () => provider.GetRequiredService<CatalogueViewModel>());
                services.AddTransient<INavigationService<CatalogueViewModel>, NavigationService<CatalogueViewModel>>();

                services.AddTransient<Func<BookPageViewModel>>(provider => () => provider.GetRequiredService<BookPageViewModel>());
                services.AddTransient<INavigationService<BookPageViewModel>, NavigationService<BookPageViewModel>>();

                services.AddTransient<Func<HomeViewModel>>(provider => () => provider.GetRequiredService<HomeViewModel>());
                services.AddTransient<INavigationService<HomeViewModel>, NavigationService<HomeViewModel>>();

                // Add MainViewModel
                services.AddTransient<MainViewModel>();

                // Add Windows
                services.AddScoped<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });

                services.AddTransient<RegistrationViewModel>();
                services.AddScoped<RegistrationWindow>(s => new RegistrationWindow()
                {
                    DataContext = s.GetRequiredService<RegistrationViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });

                services.AddTransient<LoginViewModel>();
                services.AddScoped<LoginWindow>(s => new LoginWindow()
                {
                    DataContext = s.GetRequiredService<LoginViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });

                services.AddTransient<PersonalCabinetViewModel>();
                services.AddScoped<PersonalCabinetWindow>(s => new PersonalCabinetWindow()
                {
                    DataContext = s.GetRequiredService<PersonalCabinetViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });

                services.AddTransient<ShoppingCartViewModel>();
                services.AddScoped<ShoppingCartWindow>(s => new ShoppingCartWindow()
                {
                    DataContext = s.GetService<ShoppingCartViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });

                services.AddTransient<AdministratorViewModel>();
                services.AddScoped<AdministratorWindow>(s => new AdministratorWindow()
                {
                    DataContext = s.GetRequiredService<AdministratorViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });

                services.AddTransient<AddBookViewModel>();
                services.AddScoped<AddBookWindow>(s => new AddBookWindow()
                {
                    DataContext = s.GetRequiredService<AddBookViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });

                services.AddTransient<EditBookViewModel>();
                services.AddScoped<EditBookWindow>(s => new EditBookWindow()
                {
                    DataContext = s.GetRequiredService<EditBookViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });

                services.AddTransient<UsersBooksViewModel>();
                services.AddScoped<UsersBooksWindow>(s => new UsersBooksWindow()
                {
                    DataContext = s.GetRequiredService<UsersBooksViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });

                // Build the service provider
                IServiceProvider serviceProvider = services.BuildServiceProvider();

                // Start the application
                StartApp(serviceProvider);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong.\n{ex.Message}", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartApp(IServiceProvider serviceProvider)
        {
            ServiceLocator.Initialize(serviceProvider);

            (Application.Current).MainWindow = serviceProvider.GetRequiredService<MainWindow>();
            (Application.Current).MainWindow.Show();

            Close();
        }

        #endregion
    }
}
