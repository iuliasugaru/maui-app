using MauiApp1.Models;

namespace MauiApp1;

public partial class RoutePage : ContentPage
{
	public RoutePage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var route = (Route)BindingContext;
        await App.Database.SaveRouteAsync(route);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var route = (Route)BindingContext;
        await App.Database.DeleteRouteAsync(route);
        await Navigation.PopAsync();
    }
}