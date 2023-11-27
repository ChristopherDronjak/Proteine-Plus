using ProteinePlusApp.MVVM.Models;
using ProteinePlusApp.MVVM.ViewModels;
namespace ProteinePlusApp.MVVM.Views;

public partial class FoodIntake : ContentPage
{

    private readonly LocalDbService _dbService;
    private int _editTrackerId;

    public FoodIntake(LocalDbService dbService)
	{   
        InitializeComponent();
        BindingContext = new FoodIntakeViewModel();
        _dbService = dbService;
        Task.Run(async () => listTrackView.ItemsSource = await App.database.GetTrackers());
    }

    private async void SaveTrackButton_Clicked(object sender, EventArgs e)
    {

        if (_editTrackerId == 0)
        {
            await App.database.Create(new Tracker
            {
                MealName = mealnameEntryField.Text,
                Protein = proteinEntryField.Text,
                Calories = caloriesEntryField.Text,
                Fat = fatEntryField.Text
            });
        }
        else
        {
            await App.database.Update(new Tracker
            {
                TrackId = _editTrackerId,
                MealName = mealnameEntryField.Text,
                Protein = proteinEntryField.Text,
                Calories = caloriesEntryField.Text,
                Fat = fatEntryField.Text
            });

            _editTrackerId = 0;
        }

        mealnameEntryField.Text = string.Empty;
        proteinEntryField.Text = string.Empty;
        caloriesEntryField.Text = string.Empty;
        fatEntryField.Text = string.Empty;

        listTrackView.ItemsSource = await App.database.GetTrackers();
    }

    private async void ListTrackView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var tracker = (Tracker)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":

                _editTrackerId = tracker.TrackId;
                mealnameEntryField.Text = tracker.MealName;
                proteinEntryField.Text = tracker.Protein;
                caloriesEntryField.Text = tracker.Calories;
                fatEntryField.Text = tracker.Fat;
                break;

            case "Delete":
                await App.database.Delete(tracker);
                listTrackView.ItemsSource = await App.database.GetTrackers();
                break;
        }
    }
}