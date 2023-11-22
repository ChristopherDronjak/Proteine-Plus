using ProteinePlusApp.MVVM.Views;

namespace ProteinePlusApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());

        }
    }
}