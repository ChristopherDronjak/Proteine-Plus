using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProteinePlusApp.MVVM.Views;

namespace ProteinePlusApp.MVVM.ViewModels;
public partial class WorkoutViewModel : ObservableObject
{
    //public WorkoutViewModel()
    //{
    //    Items = new ObservableCollection<string>();
    //}
    //[ObservableProperty]
    //ObservableCollection<string> items;

    //[ObservableProperty]
    //string name;

    //[ObservableProperty]
    //string sets;

    //[ObservableProperty]
    //string reps;

    //[RelayCommand]

    //void Add()
    //{
    //    //Adding Name
    //    if (string.IsNullOrWhiteSpace(name))
    //        return;
    //    if (string.IsNullOrWhiteSpace(sets))
    //        return;
    //    if (string.IsNullOrWhiteSpace(reps))
    //        return;

    //    Items.Add(name);
    //    Items.Add(sets);
    //    Items.Add(reps);

    //    name = string.Empty;
    //    sets = string.Empty;
    //    reps = string.Empty;


    //}

    //[RelayCommand]

    //void Delete(string s)
    //{
    //    if (Items.Contains(s))
    //    { Items.Remove(s); }

    //}

}