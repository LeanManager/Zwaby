﻿using System;
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
            HockeyApp.MetricsManager.TrackEvent("OnNextClicked2",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

            if (statePicker.SelectedItem == null)
            {
                await DisplayAlert("", "To better prepare for your service, please select the type of cleaning service.", "OK");
            }
            else
            {
                AddBookingDateTimeDetails();

                await Navigation.PushAsync(new PaymentPage());
            }
        }

        private void AddBookingDateTimeDetails()
        {
            TimeSpan timespan = timePicker.Time;
            DateTime time = datePicker.Date.Add(timespan);

            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDateTime = time;

            // Booking time in the proper string format
            string bookingTime = time.ToString("hh:mm tt");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceTime = bookingTime;

            // Booking date in the proper string format
            string bookingDate = datePicker.Date.ToString("MM/dd/yyyy");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDate = bookingDate;

            // Cleaning service type
            //var serviceType = statePicker.Items[statePicker.SelectedIndex];
            var serviceType = statePicker.SelectedItem.ToString();
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceType = serviceType;

            // Service notes
            var serviceNotes = instructions.Text;
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceNotes = serviceNotes;
        }
    }
}
