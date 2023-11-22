namespace ProteinePlusApp.MVVM.Views;

public partial class AddExercisePage : ContentPage
{
    public AddExercisePage()
    {
        InitializeComponent();
    }


    private void OnSaveExerciseClicked(object sender, EventArgs e)
    {

        // Example:
        var exerciseName = exerciseNameEntry.Text;
        var setsCompleted = setsCompletedEntry.Text;
        var repsCompleted = repsCompletedEntry.Text;
        //SaveExercise(exerciseName);
        //SaveSets(setsCompleted);
        //SaveReps(repsCompleted);



        // Navigate back to the main page
        Navigation.PopAsync();
    }
}