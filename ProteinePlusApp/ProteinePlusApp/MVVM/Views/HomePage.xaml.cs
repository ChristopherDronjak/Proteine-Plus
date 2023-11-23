using SQLite;
namespace ProteinePlusApp.MVVM.Views;

public partial class HomePage : ContentPage
{
    private readonly LocalDbService _dbService;
    public LocalDbService dbService;

    public HomePage()
	{
		InitializeComponent();
        _dbService = dbService;
    }

    private void foodintake_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new FoodIntake()));
    }

    private void workoutcreate_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new WorkoutCreatePage(dbService)));
    }
}