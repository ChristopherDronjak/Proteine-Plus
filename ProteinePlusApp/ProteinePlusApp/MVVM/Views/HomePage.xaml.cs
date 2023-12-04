using ProteinePlusApp;
using ProteinePlusApp.MVVM.ViewModels;
using SQLite;
using System.Diagnostics;
using ProteinePlusApp.Services;

namespace ProteinePlusApp.MVVM.Views;

public partial class HomePage : ContentPage
{
    //implementing database, view model and linking ID
    private readonly AuthService _authService;
    public readonly LocalDbService _dbService;
    public LocalDbService dbService;
    private readonly LoginViewModel _loginViewModel;
    private readonly int _userId;

    public HomePage(AuthService authService, LoginViewModel loginViewModel, int userId)
	{
        //Implementing database
		InitializeComponent();
        _authService = authService;
        _dbService = dbService;
        _loginViewModel = loginViewModel;
        _userId = userId;
    }
    //this button takes the user to the food intake page
    private void Foodintake_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new FoodIntake(dbService)));
    }

    //this button takes the user to the workout create page
    private void Workoutcreate_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new WorkoutCreatePage(dbService)));
    }

    //this button takes the user to the feedback forum
    private async void feedback_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://docs.google.com/forms/d/e/1FAIpQLSconRpCWMBcZoGsMC5U828ueOfhJchy4YADrgj-Eucoeob2hA/viewform?usp=sf_link");
    }

    //this button takes the user to the template workouts page
    private void templateworkouts_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new TemplateWorkouts()));
    }

    //this button takes the user to the template recipes page
    private void templaterecipes_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new TemplateRecipes()));
    }
}