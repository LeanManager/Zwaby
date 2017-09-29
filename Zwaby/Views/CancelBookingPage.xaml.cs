using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Zwaby.Views
{
    public partial class CancelBookingPage : ContentPage
    {
        // TODO: Define booking properties. Previous page initializes this one with the appropriate values
        // TODO: Cancellation policy check - PushModalAsync (24 hours prior for 50% refund, 48 hours prior for full refund(?))

        public CancelBookingPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);
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
					// TODO: Update ViewModel, SQLite BookingDetails object is removed,
				    //       Cancel Booking button is disabled, Book Cleaing button is enabled

					// TODO: Send SMS with cancellation notes

					await DisplayAlert("Confirmation", "Your booking has been cancelled.", "OK");

                    await Navigation.PopAsync();
                }
            }
        }
    }
}
