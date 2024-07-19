using System.Windows;
using BusinessObjects.Models;
using Repositories;

namespace Product_Management_System.Views.Authentication
{
    public partial class ChangePasswordWindow : Window
    {
        private readonly UserRepository _userRepository;
        private readonly User _currentUser;

        public ChangePasswordWindow(User currentUser)
        {
            InitializeComponent();
            _userRepository = new UserRepository(new ProductManagementDbContext());
            _currentUser = currentUser;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string currentPassword = txtCurrentPassword.Password;
            string newPassword = txtNewPassword.Password;
            string confirmNewPassword = txtConfirmNewPassword.Password;

            if (currentPassword != _currentUser.Password)
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("New passwords do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _currentUser.Password = newPassword;
            _userRepository.UpdateUser(_currentUser);

            MessageBox.Show("Password changed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
