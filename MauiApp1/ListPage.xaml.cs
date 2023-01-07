using MauiApp1.Models;
namespace MauiApp1;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Reservation)BindingContext;
        slist.Date = DateTime.UtcNow;
        Route selectedRoute = (RoutePicker.SelectedItem as Route);
        slist.RouteID = selectedRoute.ID;
        await App.Database.SaveReservationAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Reservation)BindingContext;
        await App.Database.DeleteReservationAsync(slist);
        await Navigation.PopAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var items = await App.Database.GetRoutesAsync();
        RoutePicker.ItemsSource = (System.Collections.IList)items;
        RoutePicker.ItemDisplayBinding = new Binding("RouteDetails");

        var routel = (Reservation)BindingContext;

        
    }




}