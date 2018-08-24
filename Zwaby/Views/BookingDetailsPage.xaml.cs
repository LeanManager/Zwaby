using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
	public partial class BookingDetailsPage : ContentPage
	{
		public BookingDetailsPage()
		{
			InitializeComponent();

            //this.BackgroundColor = Color.FromRgb(0, 200, 255);
            this.BackgroundColor = Color.White;

			bookingImage.Source = ImageSource.FromResource("Zwaby.Images.child-1245893_1280.jpg");

            AssignBookingDetails();
		}

		async void OnCancelBookingClicked(object sender, System.EventArgs e)
		{
            HockeyApp.MetricsManager.TrackEvent("OnCancelBookingClicked",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

			await Navigation.PushAsync(new CancelBookingPage());
		}

        private void AssignBookingDetails()
        {
            var date = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDate;
            var time = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceTime;
            var street = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceStreet;
            var city = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceCity;
            var state = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceState;
            var zip = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceZipCode;
            var servicePrice = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice;
            var serviceDuration = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration;
            var service = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceType;

            dateTime.Text = date + " at " + time + "  ";

            address.Text = street + ",\n " + city + ", " + state + " " + zip + "  ";

            price.Text = servicePrice + "  ";

            duration.Text = serviceDuration + "  ";

            serviceType.Text = service;
        }
	}
}
