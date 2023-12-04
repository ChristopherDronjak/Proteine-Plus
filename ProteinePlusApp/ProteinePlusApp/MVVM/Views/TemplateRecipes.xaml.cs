namespace ProteinePlusApp.MVVM.Views;

public partial class TemplateRecipes : ContentPage
{
	public TemplateRecipes()
	{
		InitializeComponent();
	}

    //button to go to recipe page
    private void spanishpisto_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new SpanishPisto()));
    }

    //button to go to recipe page
    private void lasagne_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new Lasagne()));
    }

    //button to go to recipe page
    private void wholewheatgarlicbread_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NavigationPage(new WholeWheatGarlicBread()));
    }
}