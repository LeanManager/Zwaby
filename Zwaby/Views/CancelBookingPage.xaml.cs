using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Models;
using Zwaby.Services;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class CancelBookingPage : ContentPage
    {
        private CancellationsManager manager;

        public CancelBookingPage()
        {
            InitializeComponent();

            //this.BackgroundColor = Color.FromRgb(0, 200, 255);
            this.BackgroundColor = Color.White;

            manager = new CancellationsManager();
        }

        async void OnFinishCancellationClicked(object sender, System.EventArgs e)
        {
            if (cancellationNotes.Text == null || cancellationNotes.Text == string.Empty)
            {
                await DisplayAlert("", "To help us improve, please provide a reason for cancellation.", "OK");
            }
            else
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    if (!await DisplayAlert("Confirm", "Are you sure you want to cancel your booking?", "No", "Yes"))
                    {
                        ClearBookingDetailsViewModel();

                        var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

                        var customer = sqLiteConnection.Table<Customer>().First();

                        try
                        {
                            await manager.AddNewCancellation(cancellationNotes.Text, DateTime.Now, customer.FirstName,
                                                         customer.LastName, customer.EmailAddress, customer.PhoneNumber);
                        }
                        //catch (Exception ex){}
                        finally
                        {
                            sqLiteConnection.Dispose();

                            await DisplayAlert("Confirmation", "Your booking has been cancelled.", "OK");

                            await Navigation.PushAsync(new MainPage());
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Network connection not found", "Please try again with an active network connection.", "OK");
                }
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
    }
}
