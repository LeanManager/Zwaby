using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using Zwaby.Models;
using Zwaby.ViewModels;
using XamarinForms.SQLite.SQLite;
using Plugin.Messaging;
using System.Threading.Tasks;

namespace Zwaby.Views
{
    public partial class RegistrationPage : ContentPage
    {
        private SQLiteConnection _sqLiteConnection;

        public static ContentPage registrationPage;

        public RegistrationPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            // Maybe use RegistrationPageViewModel~
        }

		async void OnSubmitClicked(object sender, System.EventArgs e)
		{
            if (firstName.Text == null || 
                lastName.Text == null || 
                (emailAddress.Text == null || !emailAddress.Text.Contains("@")) || 
                (phoneNumber.Text == null || phoneNumber.Text.Length != 10))
            {
                await DisplayAlert("Error", "Please enter the required information.", "OK");
            }
            else
            {
				_sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

				_sqLiteConnection.CreateTable<Customer>();

                _sqLiteConnection.Insert(new Customer
                {
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    EmailAddress = emailAddress.Text,
                    PhoneNumber = phoneNumber.Text
                });

                _sqLiteConnection.Dispose();

                // TODO: Use Twilio for this? Or Azure? Perhaps just postpone until we have early adopter feedback.

                await DisplayAlert("Verification", "One-time password is on its way!", "OK");
                await DisplayAlert("Password", "2244", "OK");
            }
        }

        async void OnFinishRegistrationClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Confirmation", "Please confirm sending your information to the Zwaby team.", "OK");

            // TODO: Check connectivity first?

            var smsMessenger = CrossMessaging.Current.SmsMessenger;

            if (smsMessenger.CanSendSms)
            {
                smsMessenger.SendSms("4699956899", 
                                     firstName.Text + " " + lastName.Text + " , " + emailAddress.Text + " , " + phoneNumber.Text);
            }

			//if (smsMessenger.CanSendSmsInBackground)
			//{
			//	smsMessenger.SendSmsInBackground("4699956899",
			//						 firstName.Text + " " + lastName.Text + " , " + emailAddress.Text + " , " + phoneNumber.Text);
			//}

            //await SendSms();

            await DisplayAlert("Success!", "Your registration has been received. An email confirmation will be sent shortly.", "OK");

            await Navigation.PushAsync(new MainPage());
		}

   //     async Task SendSms()
   //     {
			//var smsMessenger = CrossMessaging.Current.SmsMessenger;

			//if (smsMessenger.CanSendSms)
			//{
			//	smsMessenger.SendSms("4699956899",
			//						 firstName.Text + " " + lastName.Text + " , " + emailAddress.Text + " , " + phoneNumber.Text);
			//}

        //    return;
        //}
    }
}
