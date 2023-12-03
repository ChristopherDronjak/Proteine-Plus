using Microsoft.VisualBasic;
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

        CalculateAndDisplayDailyIntake();
    }


    private async void CalculateAndDisplayDailyIntake()
    {
        var trackers = await App.database.GetTrackers();

        // Filter trackers for the current date
        var todayTrackers = trackers.Where(t => t.TraDate.Date == DateTime.Now.Date).ToList();

        // Calculate total intake for the day
        double totalProtein = 0;
        double totalCalories = 0;
        double totalFat = 0;

        foreach (var tracker in todayTrackers)
        {
            double protein;
            double calories;
            double fat;

            if (double.TryParse(tracker.Protein, out protein))
                totalProtein += protein;

            if (double.TryParse(tracker.Calories, out calories))
                totalCalories += calories;

            if (double.TryParse(tracker.Fat, out fat))
                totalFat += fat;
        }

        // Display or use the calculated values as needed
        string message = $"Daily Intake:\nProtein: {totalProtein}g\nCalories: {totalCalories}kcal\nFat: {totalFat}g";

        await DisplayAlert("Daily Intake", message, "OK");
    }

    //Save Meals button
    private async void SaveTrackButton_Clicked(object sender, EventArgs e)
    {
        //generating a new meal if not editing a meal
        if (_editTrackerId == 0)
        {
            await App.database.Create(new Tracker
            {
                MealName = mealnameEntryField.Text,
                Protein = proteinEntryField.Text,
                Calories = caloriesEntryField.Text,
                Fat = fatEntryField.Text,
                TraDate = tradateEntryField.Date
            });
        }
        //updating meal
        else
        {
            await App.database.Update(new Tracker
            {
                TrackId = _editTrackerId,
                MealName = mealnameEntryField.Text,
                Protein = proteinEntryField.Text,
                Calories = caloriesEntryField.Text,
                Fat = fatEntryField.Text,
                TraDate = tradateEntryField.Date

            });

            _editTrackerId = 0;
        }
        //emptying the textboxes so user doesnt have to

        mealnameEntryField.Text = string.Empty;
        proteinEntryField.Text = string.Empty;
        caloriesEntryField.Text = string.Empty;
        fatEntryField.Text = string.Empty;
        tradateEntryField.Date = DateTime.Now;

        listTrackView.ItemsSource = await App.database.GetTrackers();
    }


    //when meal is clicked/tapped there is a popup for editing and deleting
    private async void ListTrackView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var tracker = (Tracker)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            //editing the meal in database
            case "Edit":

                _editTrackerId = tracker.TrackId;
                mealnameEntryField.Text = tracker.MealName;
                proteinEntryField.Text = tracker.Protein;
                caloriesEntryField.Text = tracker.Calories;
                fatEntryField.Text = tracker.Fat;
                tradateEntryField.Date = tracker.TraDate;


                break;
                //deleting the meal from databasse
            case "Delete":
                await App.database.Delete(tracker);
                listTrackView.ItemsSource = await App.database.GetTrackers();
                break;
        }
    }

    private async void DailyIntake_Clicked(object sender, EventArgs e)
    {

        listTrackView.ItemsSource = await App.database.GetTrackers();

        // Call the function to display daily intake
        CalculateAndDisplayDailyIntake();
    }
}