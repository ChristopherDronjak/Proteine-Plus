using ProteinePlusApp.MVVM.Views;
using ProteinePlusApp.MVVM.Models;
using ProteinePlusApp.MVVM.ViewModels;
using ProteinePlusApp.Services;

namespace ProteinePlusApp
{
    public partial class App : Application
    {
        public static LocalDbService database { get; private set; }
        public int UserId { get; set; }

        public App()
        {
            var authService = new AuthService(new LoginDbContext()); // You may need to adjust this based on your actual setup
            var loginViewModel = new LoginViewModel();
            var dbContext = new LoginDbContext();


            database = new LocalDbService();
            // Pass the AuthService and LoginPageViewModel to MainPage constructor
            MainPage = new NavigationPage(new Login(authService, loginViewModel));

        }
    }
}