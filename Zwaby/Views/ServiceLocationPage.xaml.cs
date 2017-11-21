using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Models;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class ServiceLocationPage : ContentPage
    {
        public ServiceLocationPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            var viewModel = new ServiceLocationPageViewModel();

            this.BindingContext = viewModel;
        }

        async void OnNextClicked(object sender, System.EventArgs e)
        {
            HockeyApp.MetricsManager.TrackEvent("OnNextClicked1",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

            SQLiteConnection sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
            var variable = sqLiteConnection.GetTableInfo(typeof(Customer).Name);

            if (string.IsNullOrWhiteSpace(street.Text) || string.IsNullOrWhiteSpace(city.Text) || string.IsNullOrWhiteSpace(state.Text)
                || (string.IsNullOrWhiteSpace(zipCode.Text) || zipCode.Text.Length != 5) || residence.SelectedItem == null
                || bedrooms.SelectedItem == null || bathrooms.SelectedItem == null)
            {
                sqLiteConnection.Dispose();
                await DisplayAlert("", "Please provide all the information before proceeding.", "OK");
            }
            else if (variable.Count == 0)
            {
                sqLiteConnection.Dispose();
                await DisplayAlert("", "Please provide your information in the 'Profile' section before proceeding.", "OK");
            }
            else if (sqLiteConnection.Table<Customer>().First() != null)
            {
                var customer = sqLiteConnection.Table<Customer>().First();

                if (string.IsNullOrWhiteSpace(customer.FirstName) || string.IsNullOrWhiteSpace(customer.LastName)
                     || string.IsNullOrWhiteSpace(customer.EmailAddress) || string.IsNullOrWhiteSpace(customer.PhoneNumber))
                {
                    sqLiteConnection.Dispose();
                    await DisplayAlert("", "Please provide your information in the 'Profile' section before proceeding.", "OK");
                }
                else
                {
                    AddBookingLocationDetails();
                    sqLiteConnection.Dispose();
                    await Navigation.PushAsync(new ServiceDateTimePage());
                }
            }
        }

        private void AddBookingLocationDetails()
        {
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceStreet = street.Text;
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceCity = city.Text;
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceState = state.Text;
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceZipCode = zipCode.Text;
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceResidence = residence.SelectedItem.ToString();
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBedrooms = bedrooms.SelectedItem.ToString();
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBathrooms = bathrooms.SelectedItem.ToString();
        }
    }
}
