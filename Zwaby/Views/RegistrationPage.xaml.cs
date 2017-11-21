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
using Plugin.Connectivity;

namespace Zwaby.Views
{
    public partial class RegistrationPage : ContentPage
    {
        private DatabaseManager manager;

        public RegistrationPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            //PrivacyPolicy.PrivacyPolicyInstance = new PrivacyPolicy();

            //PrivacyPolicy.PrivacyPolicyInstance.IsAcknowledged = false;

            manager = new DatabaseManager();

            // TODO: Ideally use RegistrationPageViewModel~
        }

        async void OnFinishRegistrationClicked(object sender, System.EventArgs e)
		{
            HockeyApp.MetricsManager.TrackEvent("OnFinishRegistrationClicked",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

            if (firstName.Text == null || lastName.Text == null || 
                (emailAddress.Text == null || !emailAddress.Text.Contains("@")) || 
                (phoneNumber.Text == null || phoneNumber.Text.Length != 10) || password.Text == null)
            {
                await DisplayAlert("Error", "Please enter the required information.", "OK");
            }
            else
            {
                //if (PrivacyPolicy.PrivacyPolicyInstance.IsAcknowledged == true)
                //{
                //    submitButton.IsEnabled = false;

                //    if (CrossConnectivity.Current.IsConnected)
                //    {
                //        try
                //        {
                //            await manager.AddNewCustomer(firstName.Text, lastName.Text, emailAddress.Text, phoneNumber.Text, password.Text);
                //        }
                //        //catch (Exception ex)
                //        //{
                //        //    Debug.WriteLine(ex.Message);
                //        //}
                //        finally
                //        {
                //            CreateSQLiteCustomer();

                //            await DisplayAlert("Success!", "Your registration has been received. An email confirmation will be sent shortly.", "OK");

                //            await Navigation.PushAsync(new MainPage());
                //        }
                //    }
                //    else
                //    {
                //        await DisplayAlert("Network connection not found", "Please try again with an active network connection.", "OK");
                //        submitButton.IsEnabled = true;
                //    }
                //}
                //else
                //{
                //    await DisplayAlert("Privacy Policy", "Please accept the Privacy Policy before continuing.", "OK");
                //}
            }
        }

        async void OnPrivacyPolicyClicked(object sender, System.EventArgs e)
        {
            //await Navigation.PushModalAsync(new PrivacyPolicyPage());
        }

        private void CreateSQLiteCustomer()
        {
            SQLiteConnection _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

            _sqLiteConnection.CreateTable<Customer>();

            _sqLiteConnection.Insert(new Customer
            {
                FirstName = firstName.Text,
                LastName = lastName.Text,
                EmailAddress = emailAddress.Text,
                PhoneNumber = phoneNumber.Text
            });

            _sqLiteConnection.Dispose();
        }
    }
}
