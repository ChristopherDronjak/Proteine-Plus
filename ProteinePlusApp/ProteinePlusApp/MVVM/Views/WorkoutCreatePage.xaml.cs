using ProteinePlusApp;
namespace ProteinePlusApp.MVVM.Views;

public partial class WorkoutCreatePage : ContentPage
{
    //linking database
    private readonly LocalDbService _dbService;
    public LocalDbService dbService;

    public WorkoutCreatePage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
    }

    //nav to add exercise page
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExercisePage(dbService));

        }
    
}