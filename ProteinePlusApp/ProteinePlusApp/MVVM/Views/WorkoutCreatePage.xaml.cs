namespace ProteinePlusApp.MVVM.Views;

public partial class WorkoutCreatePage : ContentPage
{
    public WorkoutCreatePage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddExercisePage());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewExercisePage());
    }
}