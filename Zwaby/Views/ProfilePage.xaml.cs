using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Models;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            var viewModel = new ProfilePageViewModel();

            this.BindingContext = viewModel;
        }

        async void OnFirstNameClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("First Name", "Please click on your first name to edit it.", "OK");
        }

		async void OnLastNameClicked(object sender, System.EventArgs e)
		{
			await DisplayAlert("Last Name", "Please click on your last name to edit it.", "OK");
		}

		async void OnEmailAddressClicked(object sender, System.EventArgs e)
		{
			await DisplayAlert("Email Address", "Please click on your email address to edit it.", "OK");
		}

		async void OnPhoneNumberClicked(object sender, System.EventArgs e)
		{
			await DisplayAlert("Phone Number", "Please click on your phone number to edit it.", "OK");
		}
    }
}
