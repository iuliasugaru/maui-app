using MauiApp1.Models;

namespace MauiApp1;

public partial class RouteEntryPage : ContentPage
{
	public RouteEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRoutesAsync();
    }
    async void OnRouteAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoutePage
        {
            BindingContext = new Route()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new RoutePage
            {
                BindingContext = e.SelectedItem as Route
            });
        }
    }
}