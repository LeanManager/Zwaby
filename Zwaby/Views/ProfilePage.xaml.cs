using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Models;
using Zwaby.Services;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class ProfilePage : ContentPage
    {
        private NotificationService service;

        public ProfilePage()
        {
            InitializeComponent();

            //this.BackgroundColor = Color.FromRgb(0, 200, 255);
            this.BackgroundColor = Color.White;

            service = new NotificationService();

            var viewModel = new ProfilePageViewModel();

            this.BindingContext = viewModel;
        }

        async void EntryUnfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            await service.SendEmail(firstName.Text, lastName.Text, phoneNumber.Text, emailAddress.Text);
        }

        async void OnFirstNameClicked(object sender, System.EventArgs e)
        {
            HockeyApp.MetricsManager.TrackEvent("OnFirstNameClicked",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

            await DisplayAlert("First Name", "Please click on your first name to edit it.", "OK");
        }

		async void OnLastNameClicked(object sender, System.EventArgs e)
		{
            HockeyApp.MetricsManager.TrackEvent("OnLastNameClicked",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

			await DisplayAlert("Last Name", "Please click on your last name to edit it.", "OK");
		}

		async void OnEmailAddressClicked(object sender, System.EventArgs e)
		{
            HockeyApp.MetricsManager.TrackEvent("OnEmailAddressClicked",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

			await DisplayAlert("Email Address", "Please click on your email address to edit it.", "OK");
		}

		async void OnPhoneNumberClicked(object sender, System.EventArgs e)
		{
            HockeyApp.MetricsManager.TrackEvent("OnPhoneNumberClicked",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

			await DisplayAlert("Phone Number", "Please click on your phone number to edit it.", "OK");
		}
    }
}
