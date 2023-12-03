using ProteinePlusApp;
using ProteinePlusApp.MVVM.ViewModels;
using SQLite;
using System.Diagnostics;
using ProteinePlusApp.Services;

namespace ProteinePlusApp.MVVM.Views;

public partial class HomePage : ContentPage
{
    private readonly AuthService _authService;
    public readonly LocalDbService _dbService;
    public LocalDbService dbService;
    private readonly LoginViewModel _loginViewModel;
    private readonly int _userId;

    //linking database
    public HomePage(AuthService authService, LoginViewModel loginViewModel, int userId)
	{
		InitializeComponent();
        _authService = authService;
        _dbService = dbService;
        _loginViewModel = loginViewModel;
        _userId = userId;
    }

    //navigation to other pages or feedback form
    private void Foodintake_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new FoodIntake(dbService)));
    }

    private void Workoutcreate_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new WorkoutCreatePage(dbService)));
    }

    //linking the feedback form to the home page
    private async void feedback_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://docs.google.com/forms/d/e/1FAIpQLSconRpCWMBcZoGsMC5U828ueOfhJchy4YADrgj-Eucoeob2hA/viewform?usp=sf_link");
    }

    private void templateworkouts_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new TemplateWorkouts()));
    }

    private void templaterecipes_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new TemplateRecipes()));
    }
}