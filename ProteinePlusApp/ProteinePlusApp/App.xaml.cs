using ProteinePlusApp.MVVM.Views;
using ProteinePlusApp.MVVM.Models;
namespace ProteinePlusApp
{
    public partial class App : Application
    {
        public static LocalDbService database { get; private set; }
        public App()
        {
            InitializeComponent();
            database = new LocalDbService();
            MainPage = new NavigationPage(new HomePage());

        }
    }
}