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
        await App.Database.SaveReservationAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Reservation)BindingContext;
        await App.Database.DeleteReservationAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoutePage((Reservation)
       this.BindingContext)
        {
            BindingContext = new Route()
        });

    }
    async void OnChooseButtonClickedd(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DateAndTimePage((Reservation)
       this.BindingContext)
        {
            BindingContext = new DateTimee()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Reservation)BindingContext;

        listView.ItemsSource = await App.Database.GetListRouteAsync(shopl.ID);
    }

}