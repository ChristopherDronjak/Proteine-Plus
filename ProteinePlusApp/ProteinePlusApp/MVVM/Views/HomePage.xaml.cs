using ProteinePlusApp;
using SQLite;
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
}