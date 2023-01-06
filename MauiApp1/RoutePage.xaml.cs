using MauiApp1.Models;

namespace MauiApp1;

public partial class RoutePage : ContentPage
{
    Reservation sl;
    public RoutePage(Reservation slist)
	{
        
        InitializeComponent();
        sl = slist;
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var route = (Route)BindingContext;
        await App.Database.SaveRouteAsync(route);
        listView.ItemsSource = await App.Database.GetRouteAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var route = (Route)BindingContext;
        await App.Database.DeleteRouteAsync(route);
        listView.ItemsSource = await App.Database.GetRouteAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRouteAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Route p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Route;
            var lp = new ListRoute()
            {
                ReservationID = sl.ID,
                RouteID = p.ID
            };
            await App.Database.SaveListRouteAsync(lp);
            p.ListRoute = new List<ListRoute> { lp };
            await Navigation.PopAsync();
        }

    }
    async void OnAddButtonClickedd(object sender, EventArgs e)
    {
        DateTimee p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as DateTimee;
            var lp = new ListDateAndTime()
            {
                ReservationID = sl.ID,
                DateAndTimeID = p.ID
            };
            await App.Database.SaveListDateAndTimeAsync(lp);
            p.ListDateAndTime = new List<ListDateAndTime> { lp };
            await Navigation.PopAsync();
        }

    }
}