using ProteinePlusApp.MVVM.Models;
using ProteinePlusApp.MVVM.ViewModels;
namespace ProteinePlusApp.MVVM.Views;

public partial class AddExercisePage : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editExerciseId;

    public AddExercisePage(LocalDbService dbService)
    {
        //binds the view model and links database to the page
        InitializeComponent();
        BindingContext = new WorkoutViewModel();
        _dbService = dbService;
        Task.Run(async () => listView.ItemsSource = await App.database.GetExercises());
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        //created new exercise if exercise is not already created
        if (_editExerciseId == 0)
        {
            await App.database.Create(new Exercise
            {
                ExerciseName = nameEntryField.Text,
                Sets = setsEntryField.Text,
                Reps = repsEntryField.Text,
                ExcDate = excdateEntryField.Date
            });
        }
        //if the exercise is created it will be updated with new information
        else
        {
            await App.database.Update(new Exercise
            {
                Id = _editExerciseId,
                ExerciseName = nameEntryField.Text,
                Sets = setsEntryField.Text,
                Reps = repsEntryField.Text,
                ExcDate = excdateEntryField.Date

            });

            _editExerciseId = 0;
        }
        //empties the entry fields for the user
        nameEntryField.Text = string.Empty;
        setsEntryField.Text = string.Empty;
        repsEntryField.Text = string.Empty;
        excdateEntryField.Date = DateTime.Now;

        listView.ItemsSource = await App.database.GetExercises();
    }

    //this is for when the user taps on a workout they have created and may want to either edit or delete it
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var exercise = (Exercise)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            //editing the exercise
            case "Edit":
                _editExerciseId = exercise.Id;
                nameEntryField.Text = exercise.ExerciseName;
                setsEntryField.Text = exercise.Sets;
                repsEntryField.Text = exercise.Reps;
                excdateEntryField.Date = exercise.ExcDate;
                break;

                //deleting the exercise
            case "Delete":
                await App.database.Delete(exercise);
                listView.ItemsSource = await App.database.GetExercises();
                break;
        }
    }
}