using AutoMapper;
using BookShelfProject.Context;
using BookShelfProject.Core.Locators;
using BookShelfProject.Core.Services;
using BookShelfProject.Core.Stores;
using BookShelfProject.Dto;
using BookShelfProject.MVVM.ViewModels;
using BookShelfProject.MVVM.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace BookShelfProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;

        public App()
        {
            try
            {
                IServiceCollection services = new ServiceCollection();

                services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseSqlServer("Data Source=DESKTOP-AJ6IRLC\\SQLEXPRESS;Initial Catalog=BookstoreDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
);
                }, ServiceLifetime.Scoped);
                
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                services.AddSingleton<NavigationStore>();
                services.AddSingleton<SearchDataStore>();
                services.AddSingleton<CurrentBookDataStore>();
                services.AddSingleton<CurrentUserDataStore>();

                services.AddTransient<HomeViewModel>();
                services.AddTransient<CatalogueViewModel>();
                services.AddTransient<BookPageViewModel>();
                services.AddTransient<SearchResultViewModel>();

                services.AddTransient<Func<SearchResultViewModel>>(provider => () => provider.GetRequiredService<SearchResultViewModel>());
                services.AddTransient<INavigationService<SearchResultViewModel>, NavigationService<SearchResultViewModel>>();

                services.AddTransient<Func<CatalogueViewModel>>(provider => () => provider.GetRequiredService<CatalogueViewModel>());
                services.AddTransient<INavigationService<CatalogueViewModel>, NavigationService<CatalogueViewModel>>();

                services.AddTransient<Func<BookPageViewModel>>(provider => () => provider.GetRequiredService<BookPageViewModel>());
                services.AddTransient<INavigationService<BookPageViewModel>, NavigationService<BookPageViewModel>>();

                services.AddTransient<Func<HomeViewModel>>(provider => () => provider.GetRequiredService<HomeViewModel>());
                services.AddTransient<INavigationService<HomeViewModel>, NavigationService<HomeViewModel>>();

                services.AddTransient<MainViewModel>();
                services.AddScoped<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });

                services.AddTransient<RegistrationViewModel>();
                services.AddScoped<RegistrationWindow>(s => new RegistrationWindow()
                {
                    DataContext = s.GetRequiredService<RegistrationViewModel>()
                });

                services.AddTransient<LoginViewModel>();
                services.AddScoped<LoginWindow>(s => new LoginWindow()
                {
                    DataContext = s.GetRequiredService<LoginViewModel>()
                });

                services.AddTransient<PersonalCabinetViewModel>();
                services.AddScoped<PersonalCabinetWindow>(s => new PersonalCabinetWindow()
                {
                    DataContext = s.GetRequiredService<PersonalCabinetViewModel>()
                });

                serviceProvider = services.BuildServiceProvider();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceLocator.Initialize(serviceProvider);

            MainWindow = serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
           
        }
    }

}
