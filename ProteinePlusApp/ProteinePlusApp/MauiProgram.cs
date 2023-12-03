using Microsoft.Extensions.Logging;
using ProteinePlusApp.MVVM.ViewModels;
using ProteinePlusApp.MVVM.Views;

namespace ProteinePlusApp
{
    public static class MauiProgram
    {
        //building application
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                //getting font for PROTEINE PLUS
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //generating main pages
            builder.Services.AddSingleton<LocalDbService>();
            builder.Services.AddTransient<AddExercisePage>();
            builder.Services.AddSingleton<WorkoutViewModel>();
            builder.Services.AddTransient<FoodIntake>();
            builder.Services.AddSingleton<FoodIntakeViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}