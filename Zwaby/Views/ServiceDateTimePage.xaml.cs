using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Models;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class ServiceDateTimePage : ContentPage
    {
        public ServiceDateTimePage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            // Earliest booking for the following day
            datePicker.MinimumDate = DateTime.Now.AddDays(1);
        }

        async void OnNextClicked(object sender, System.EventArgs e)
        {
            if (statePicker.SelectedItem == null)
            {
                await DisplayAlert("", "To better prepare for your service, please select the state of your home.", "OK");
            }
            else
            {
                TimeSpan timespan = timePicker.Time;
                DateTime time = datePicker.Date.Add(timespan);

                // Booking time in the proper string format
                string bookingTime = time.ToString("hh:mm tt");
                BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceTime = bookingTime;

                // Booking date in the proper string format
                string bookingDate = datePicker.Date.ToString("MM/dd/yyyy");
                BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDate = bookingDate;

                // State of the home
                var homeState = statePicker.Items[statePicker.SelectedIndex];
                BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceHomeState = homeState;

                // Service notes
                var serviceNotes = instructions.Text;
                BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceNotes = serviceNotes;


                await Navigation.PushAsync(new PaymentPage());
            }
        }
    }
}
