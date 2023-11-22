namespace ProteinePlusApp.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void foodintake_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new FoodIntake()));
    }

    private void workoutcreate_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new WorkoutCreatePage()));
    }
}