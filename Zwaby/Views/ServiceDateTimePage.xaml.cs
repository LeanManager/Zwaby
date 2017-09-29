using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Models;

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

                // Booking date in the proper string format
                string bookingDate = datePicker.Date.ToString("MM/dd/yyyy");

                // State of the home
                var homeState = statePicker.Items[statePicker.SelectedIndex];

                // Service notes
                var serviceNotes = instructions.Text;

                //TODO: Do this in the next PaymentPage after finish booking is clicked

                //var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
                //var variable = sqLiteConnection.GetTableInfo(typeof(BookingDetails).Name);
                //if (variable.Count == 0)
                //{
                //	sqLiteConnection.CreateTable<BookingDetails>();
                //	sqLiteConnection.Insert(new BookingDetails
                //                {
                //                    ServiceDate = datePicker.Date.ToString("MM/dd/yyyy"),
                //                    ServiceTime = 
                //                    HomeState = 
                //                    ServiceNotes =
                //                });
                //}
                //sqLiteConnection.Dispose();

                await Navigation.PushAsync(new PaymentPage());
            }
        }
    }
}
