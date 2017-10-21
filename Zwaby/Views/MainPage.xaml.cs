using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            NavigationPage.SetHasBackButton(this, false);

            // TODO: Clear BookingDetailsViewModelInstance properties 24 hours after the booking day/time

            // TODO: On Android, Onplatform device Back button is disabled
        }

        // TODO: Fix checking logic - somehow the if statement returns true before clicking Finish Booking
        // If you navigate back after ServiceDateTimePage constructor, if statement returns true
        async void OnBookCleaningClicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice) ||
                !string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration))
            {
                await DisplayAlert("", "Service must be completed before booking again. " +
                                   "Alternatively, you may cancel your current booking. " +
                                   "Please call 469-995-6899 if you have any questions.", "OK");
            }
            else
            {
                await Navigation.PushAsync(new ServiceLocationPage());
            }

            // if DisplayAlert You can only book one service at a time. You may book again once your current booking is done~
        }

        async void OnBookingDetailsClicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDate) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceTime) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceStreet) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceCity) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceState) ||
                string.IsNullOrWhiteSpace(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceZipCode))
            {
                await DisplayAlert("", "Please complete a booking first.", "OK");
            }
            else
            {
                await Navigation.PushAsync(new BookingDetailsPage());
            }

			// if DisplayAlert Please complete a booking first
		}

        async void OnProfileClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}
