using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using Zwaby.Models;
using Zwaby.ViewModels;
using XamarinForms.SQLite.SQLite;
using Plugin.Messaging;
using System.Threading.Tasks;
using Zwaby.Services;
using System.Diagnostics;

namespace Zwaby.Views
{
    public partial class RegistrationPage : ContentPage
    {
        private SQLiteConnection _sqLiteConnection;

        private DatabaseManager manager;

        public RegistrationPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            manager = new DatabaseManager();

            // Ideally use RegistrationPageViewModel~
        }

        async void OnFinishRegistrationClicked(object sender, System.EventArgs e)
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
                try
                {
                    // Asynchronous function that POSTs a new Customer to the RegistrationController
                    await manager.AddNewCustomer(firstName.Text, lastName.Text, emailAddress.Text, phoneNumber.Text);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

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


                // TODO: If the above works, remove the following two lines of code
                await DisplayAlert("Confirmation", "Please confirm sending your information to the Zwaby team.", "OK");

                // TODO: Check connectivity first

                //var smsMessenger = CrossMessaging.Current.SmsMessenger;
                //if (smsMessenger.CanSendSms)
                //{
                //    smsMessenger.SendSms("4699956899",
                //                         firstName.Text + " " + lastName.Text + " , " + emailAddress.Text + " , " + phoneNumber.Text);
                //}

                await SendSms();

                await DisplayAlert("Success!", "Your registration has been received. An email confirmation will be sent shortly.", "OK");

                await Navigation.PushAsync(new MainPage());
            }
        }

        private Task SendSms()
        {
			var smsMessenger = CrossMessaging.Current.SmsMessenger;

			if (smsMessenger.CanSendSms)
			{
				smsMessenger.SendSms("4699956899",
									 firstName.Text + " " + lastName.Text + " , " + emailAddress.Text + " , " + phoneNumber.Text);
			}

            return Task.Delay(1);
        }
    }
}
