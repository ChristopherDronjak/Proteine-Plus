using ProteinePlusApp.MVVM.ViewModels;
namespace ProteinePlusApp.MVVM.Views;

public partial class AddExercisePage : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editExerciseId;

    public AddExercisePage(LocalDbService dbService)
    {
        InitializeComponent();
        BindingContext = new WorkoutViewModel();
        _dbService = dbService;
        Task.Run(async () => listView.ItemsSource = await App.database.GetExercises());
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {

        if (_editExerciseId == 0)
        {
            await App.database.Create(new Exercise
            {
                ExerciseName = nameEntryField.Text,
                Sets = setsEntryField.Text,
                Reps = repsEntryField.Text
            });
        }
        else
        {
            await App.database.Update(new Exercise
            {
                Id = _editExerciseId,
                ExerciseName = nameEntryField.Text,
                Sets = setsEntryField.Text,
                Reps = repsEntryField.Text
            });

            _editExerciseId = 0;
        }

        nameEntryField.Text = string.Empty;
        setsEntryField.Text = string.Empty;
        repsEntryField.Text = string.Empty;

        listView.ItemsSource = await App.database.GetExercises();
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var exercise = (Exercise)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":

                _editExerciseId = exercise.Id;
                nameEntryField.Text = exercise.ExerciseName;
                setsEntryField.Text = exercise.Sets;
                repsEntryField.Text = exercise.Reps;
                break;

            case "Delete":
                await App.database.Delete(exercise);
                listView.ItemsSource = await App.database.GetExercises();
                break;
        }
    }
}