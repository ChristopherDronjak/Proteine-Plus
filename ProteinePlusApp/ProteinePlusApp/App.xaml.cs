using ProteinePlusApp.MVVM.Views;

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