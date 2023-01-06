using MauiApp1.Models;
namespace MauiApp1;

public partial class DateAndTimePage : ContentPage
{
    Reservation sl;
	public DateAndTimePage(Reservation slist)
	{
		InitializeComponent();
        sl = slist;
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var DateAndTime = (DateTimee)BindingContext;
        await App.Database.SaveDateAndTimeAsync(DateAndTime);
        listView.ItemsSource = await App.Database.GetDateAndTimeAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var DateAndTime = (DateTimee)BindingContext;
        await App.Database.DeleteDateAndTimeAsync(DateAndTime);
        listView.ItemsSource = await App.Database.GetDateAndTimeAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetDateAndTimeAsync();
    }
}