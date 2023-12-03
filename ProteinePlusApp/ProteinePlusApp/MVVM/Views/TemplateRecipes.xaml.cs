namespace ProteinePlusApp.MVVM.Views;

public partial class TemplateRecipes : ContentPage
{
	public TemplateRecipes()
	{
		InitializeComponent();
	}

    private void spanishpisto_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new SpanishPisto()));
    }

    private void lasagne_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new Lasagne()));
    }

    private void wholewheatgarlicbread_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new WholeWheatGarlicBread()));
    }
}