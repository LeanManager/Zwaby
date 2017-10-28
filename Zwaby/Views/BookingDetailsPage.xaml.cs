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

			this.BackgroundColor = Color.FromRgb(0, 240, 255);

			bookingImage.Source = ImageSource.FromResource("Zwaby.Images.child-1245893_1280.jpg");

            var date = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDate;
            var time = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceTime;
            var street = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceStreet;
            var city = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceCity;
            var state = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceState;
            var zip = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceZipCode;
            var servicePrice = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice;
            var serviceDuration = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration;

            dateTime.Text = date + " at " + time + "  ";

            address.Text = street + ",\n " + city + ", " + state + " " + zip + "  ";

            price.Text = servicePrice + "  ";

            duration.Text = serviceDuration + "  ";
		}

		async void OnCancelBookingClicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new CancelBookingPage());
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDate) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceTime) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceStreet) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceCity) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceState) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceZipCode) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceResidence) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBedrooms) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBathrooms) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceHomeState))
            {
                Navigation.PopAsync();
            }
        }
	}
}
