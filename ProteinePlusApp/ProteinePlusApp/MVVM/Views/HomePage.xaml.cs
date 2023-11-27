using SQLite;
using System.Diagnostics;

namespace ProteinePlusApp.MVVM.Views;

public partial class HomePage : ContentPage
{
    public readonly LocalDbService _dbService;
    public LocalDbService dbService;

    public HomePage()
	{
		InitializeComponent();
        _dbService = dbService;
    }

    private void Foodintake_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new FoodIntake(dbService)));
    }

    private void Workoutcreate_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new WorkoutCreatePage(dbService)));
    }

    private async void feedback_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://docs.google.com/forms/d/e/1FAIpQLSconRpCWMBcZoGsMC5U828ueOfhJchy4YADrgj-Eucoeob2hA/viewform?usp=sf_link");
    }
}