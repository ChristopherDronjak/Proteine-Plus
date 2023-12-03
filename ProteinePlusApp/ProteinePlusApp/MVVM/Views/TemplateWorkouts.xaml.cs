namespace ProteinePlusApp.MVVM.Views;

public partial class TemplateWorkouts : ContentPage
{
	public TemplateWorkouts()
	{
		InitializeComponent();
	}

    //navigation to the template workouts
    private void backbiceps_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new BackAndBiceps()));

    }

    private void chesttriceps_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new ChestAndTriceps()));

    }

    private void legs_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new Legs()));

    }
}