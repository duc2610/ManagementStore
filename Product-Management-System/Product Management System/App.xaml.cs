﻿using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Repositories;
using Services;
using Product_Management_System.Views.Authentication;
using Product_Management_System.Views.Admin;
using BusinessObjects.Models;

namespace Product_Management_System
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public ServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            // Đăng ký DbContext
            services.AddDbContext<ProductManagementDbContext>();

            // Đăng ký Repositories
            services.AddTransient<IUserRepository, UserRepository>();

            // Đăng ký Services
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            // Đăng ký Windows
            services.AddTransient<MainWindow>();
            services.AddTransient<LoginWindow>();
            services.AddTransient<AdminDashboardWindow>();
            services.AddSingleton<CurrentUserService>();
        }

        public class CurrentUserService
        {
            private User _currentUser;

            public User GetCurrentUser() => _currentUser;
            public void SetCurrentUser(User user) => _currentUser = user;
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var loginWindow = serviceProvider.GetService<LoginWindow>();
            loginWindow.Show();
        }
    }
}
