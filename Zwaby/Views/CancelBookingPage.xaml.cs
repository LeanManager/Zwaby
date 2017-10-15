using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class CancelBookingPage : ContentPage
    {
        public CancelBookingPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            // TODO: Cancellation policy check - PushModalAsync (24 hours prior for 50% refund, 48 hours prior for full refund(?))
        }

        async void OnFinishCancellationClicked(object sender, System.EventArgs e)
        {
            if (cancellationNotes.Text == null || cancellationNotes.Text == string.Empty)
            {
                await DisplayAlert("", "To help us improve, please provide a reason for cancellation.", "OK");
            }
            else
            {
                if (!await DisplayAlert("Confirm", "Are you sure you want to cancel your booking?", "No", "Yes"))
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
                    BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceHomeState = "";
                    BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceNotes = "";

					// TODO: Send SMS with cancellation notes

					await DisplayAlert("Confirmation", "Your booking has been cancelled.", "OK");

                    await Navigation.PopAsync();
                }
            }
        }
    }
}
