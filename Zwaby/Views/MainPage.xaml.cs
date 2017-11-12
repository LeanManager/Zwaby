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
        }

        async void OnBookCleaningClicked(object sender, System.EventArgs e)
        {
            HockeyApp.MetricsManager.TrackEvent("OnBookCleaningClicked", 
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                }, 
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

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
        }

        async void OnBookingDetailsClicked(object sender, System.EventArgs e)
        {
            HockeyApp.MetricsManager.TrackEvent("OnBookingDetailsClicked",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

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
		}

        async void OnProfileClicked(object sender, System.EventArgs e)
        {
            HockeyApp.MetricsManager.TrackEvent("OnProfileClicked",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

            await Navigation.PushAsync(new ProfilePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (DateTime.Now > BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDateTime.AddHours(8))
            {
                ClearBookingDetailsViewModel();

                // TODO: ReviewPage - Navigation.PushModalAsync(new ReviewPage());
            }
        }

        private void ClearBookingDetailsViewModel()
        {
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDate = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceTime = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceStreet = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceCity = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceState = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceZipCode = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceResidence = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBedrooms = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBathrooms = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceType = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceNotes = "";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDateTime = DateTime.Now;
        }

        // Disable Android hardware Back button functionality on this page
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
