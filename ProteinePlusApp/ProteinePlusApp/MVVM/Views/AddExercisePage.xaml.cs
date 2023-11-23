namespace ProteinePlusApp.MVVM.Views;

public partial class AddExercisePage : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editExerciseId;

    public AddExercisePage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        Task.Run(async () => listView.ItemsSource = await _dbService.GetExercises());
    }

    private async void saveButton_Clicked(object sender, EventArgs e)
    {
        if (_editExerciseId == 0)
        {
            await _dbService.Create(new Exercise
            {
                ExerciseName = nameEntryField.Text,
                Sets = setsEntryField.Text,
                Reps = repsEntryField.Text

            });
        }
        else
        {
            await _dbService.Update(new Exercise
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

        listView.ItemsSource = await _dbService.GetExercises();
    }

    private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
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
                await _dbService.Delete(exercise);
                listView.ItemsSource = await _dbService.GetExercises();
                break;
        }
    }
}