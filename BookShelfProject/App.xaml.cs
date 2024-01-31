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
    }

}
