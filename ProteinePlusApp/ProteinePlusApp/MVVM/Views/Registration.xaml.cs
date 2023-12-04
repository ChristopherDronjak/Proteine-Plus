using ProteinePlusApp.Services;
using ProteinePlusApp.MVVM.ViewModels;

namespace ProteinePlusApp.MVVM.Views;

public partial class Registration : ContentPage
{

    private readonly AuthService _authService;
    private readonly LoginViewModel _viewModel;

    public Registration(AuthService authService, LoginViewModel viewModel)
    {
        InitializeComponent();
        _authService = authService;
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void registerconfirm_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(_viewModel.Username) || string.IsNullOrWhiteSpace(_viewModel.Password))
            {
                await DisplayAlert("Error", "You must fill all fields.", "OK");
                return;
            }

            string result = _authService.Signup(_viewModel.Username, _viewModel.Password);
            await DisplayAlert("Registered", result, "OK");

            if (result == "Signup successful")
            {
                await Navigation.PushAsync(new Login(_authService, _viewModel));
            }
            else
            {
                await DisplayAlert("Register Error", result, "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error has happened: {ex.Message}", "OK");
        }
    }

    private async void returnlogin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login(_authService, _viewModel));
    }
}