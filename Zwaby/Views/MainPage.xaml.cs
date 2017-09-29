using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Zwaby.Views
{
    public partial class MainPage : ContentPage
    {
        // TODO: ViewModel property. PaymentPage initializes BookingDetailsViewModel and assigns values statically (SQLite, etc.)

        public MainPage()
        {
            InitializeComponent();

            homeImage.Source = ImageSource.FromResource("Zwaby.Images.child-1245893_1280.jpg");

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            NavigationPage.SetHasBackButton(this, false);
        }

        async void OnBookCleaningClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ServiceLocationPage());

            // if DisplayAlert You can only book one service at a time. You may book again once your current booking is done~
        }

        async void OnBookingDetailsClicked(object sender, System.EventArgs e)
        {
            // TODO: change to Commands - canExecute returns true only if the user has completed a booking

            await Navigation.PushAsync(new BookingDetailsPage());

			// if DisplayAlert Please complete a booking first
		}

        async void OnProfileClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}
