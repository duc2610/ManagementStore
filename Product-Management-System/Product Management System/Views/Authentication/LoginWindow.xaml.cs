﻿using System.Windows;
using BusinessObjects.Models;
using Services;
using Repositories;
using Product_Management_System.Views.Admin;
using Microsoft.Extensions.DependencyInjection;
using static Product_Management_System.App;
using Product_Management_System.Views.ADMIN;

namespace Product_Management_System.Views.Authentication
{
    public partial class LoginWindow : Window
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly CurrentUserService _currentUserService;

        public LoginWindow(IAuthenticationService authService, CurrentUserService currentUserService)
        {
            InitializeComponent();
            var context = new ProductManagementDbContext(); 
            var userRepository = new UserRepository(context);
            _authenticationService = new AuthenticationService(userRepository);
            _authenticationService = authService;
            _currentUserService = currentUserService;
        }

        public LoginWindow()
        {
            InitializeComponent();
            var context = new ProductManagementDbContext();
            var userRepository = new UserRepository(context);
            _authenticationService = new AuthenticationService(userRepository);
            _currentUserService = new CurrentUserService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Password;

            var user = _authenticationService.Authenticate(username, password);

            if (user != null)
            {
                

                if (user.RoleId == 1) // Admin
                {
                    MessageBox.Show("Welcome admin!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    AdminHome adminHome = new AdminHome();
                    adminHome.Show();
                    this.Close();
                }
                else if (user.RoleId == 2) // Staff
                {
                    MessageBox.Show("Welcome staff!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.Show();
                    this.Close();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Login fail!.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtUser.Text = "";
            txtPass.Password = "";
        }
    }
}
