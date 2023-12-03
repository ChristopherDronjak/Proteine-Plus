using Microsoft.Maui.Controls;
using ProteinePlusApp.Services;
using ProteinePlusApp.MVVM.Models;
using ProteinePlusApp.MVVM.ViewModels;
using System;

namespace ProteinePlusApp.MVVM.Views;

public partial class Login : ContentPage
{
    //linking database
    private readonly AuthService _authService;
    private readonly LoginViewModel _loginViewModel;

    public Login(AuthService authService, LoginViewModel loginViewModel)
    { 
        InitializeComponent();
        _authService = authService;
        _loginViewModel = new LoginViewModel();
        var dbContext = new LoginDbContext();
        BindingContext = _loginViewModel;
    }

    private async void login_Clicked(object sender, EventArgs e)
    {
        {
            try
            {
                if (BindingContext == null)
                {
                    // Log or debug the issue
                    Console.WriteLine("BindingContext is null in OnLoginButtonClicked");
                    return;
                }

                var viewModel = (LoginViewModel)BindingContext;

                //required fields
                if (string.IsNullOrWhiteSpace(viewModel.Username) || string.IsNullOrWhiteSpace(viewModel.Password))
                {
                    await DisplayAlert("Error", "Username and password are required fields.", "OK");
                    return;
                }

                string result = _authService.Login(viewModel.Username, viewModel.Password);
                await DisplayAlert("Login Result", result, "OK");

                // Assuming you want to navigate to the next page after a successful login
                if (result == "Login successful")
                {
                    _authService.SetAuthentication(true);
                    int userId = _authService.GetUserId(viewModel.Username);
                    ((App)Application.Current).UserId = userId;
                    Console.WriteLine($"User logged in with UserId: {userId}");
                    await Navigation.PushAsync(new HomePage(_authService, _loginViewModel, userId));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
    //links button to the registration page for new users

    private async void register_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Registration(_authService, _loginViewModel));
    }


}
