using BusinessObjects.Models;
using Repositories;
using Product_Management_System.Views.Authentication;
using System.Windows;
using System.Windows.Input;

namespace Product_Management_System
{
    public partial class MainWindow : Window
    {
        private ProductManagementDbContext dbContext;
        private User currentUser;
        private readonly IUserRepository userRepository;

        public MainWindow(User user)
        {
            InitializeComponent();
            dbContext = new ProductManagementDbContext();
            userRepository = new UserRepository(dbContext);
            currentUser = user;
            LoadUserInfo();

        }

        public MainWindow()
        {
            InitializeComponent();
            dbContext = new ProductManagementDbContext();
            userRepository = new UserRepository(dbContext);
            currentUser = userRepository.GetUserByUsername("default_username"); 
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            if (currentUser != null && !string.IsNullOrEmpty(currentUser.Fullname))
            {
                txtUserFullName.Text = currentUser.Fullname;
            }
            else
            {
                txtUserFullName.Text = "Unknown User";
            }
        }

        private void btnProductInventory_Click(object sender, RoutedEventArgs e)
        {
            frMainContent.Navigate(new ProductInventoryPage());
        }

        private void btnPriceHistory_Click(object sender, RoutedEventArgs e)
        {
            frMainContent.Navigate(new ProductPriceHistoryPage());
        }

        private void txtUserFullName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (currentUser != null)
            {
                UserInfoWindow userInfoWindow = new UserInfoWindow(currentUser, userRepository);
                userInfoWindow.Owner = this;
                bool? result = userInfoWindow.ShowDialog();

                if (result == true)
                {
                    txtUserFullName.Text = currentUser.Fullname;
                }
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow page = new LoginWindow();
            page.Show();
            this.Hide();
        }
    }
}