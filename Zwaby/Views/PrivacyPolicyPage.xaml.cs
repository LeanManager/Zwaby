using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Zwaby.Models;

namespace Zwaby.Views
{
    public partial class PrivacyPolicyPage : ContentPage
    {
        public PrivacyPolicyPage()
        {
            InitializeComponent();

            policyText.Text = "Zwaby will securely collect and store user information in two places:\n" + "\n" +
                              "1) Registration Page\n" +
                              "* In this page, we collect a user's first name, last name, email address, phone number, and a new password. This information will not be shared with anyone and it is stored securely. It is internal to Zwaby for account registration and cleaning service purposes, and personal for users (your registration information will appear in your Profile section within the application).\n" +
                              "\n" + 
                              "2) Service Location Page\n" +
                              "* In this page, we collect home information for cleaning service purposes. Address information lets Zwaby know where the cleaning service will take place. Type of residence (House or apartment), number of bedrooms, and number of bathrooms information is collected to generate the total price for the service. All this information is also stored securely and will not be shared with anyone.\n" +
                              "\n" +
                              "Zwaby does not store credit card information. When credit card information is entered in the payment page, it is securely processed by Stripe. For security reasons this information is never stored or saved, either locally or remotely.\n" + 
                              "\n" +
                              "By clicking the 'I Accept' button below, you acknowledge reading this Privacy Policy and you grant consent to Zwaby to securely collect and handle the stated information." + "\n";
        }

        async void OnAcceptClicked(object sender, System.EventArgs e)
        {
            PrivacyPolicy.PrivacyPolicyInstance.IsAcknowledged = true;

            await Navigation.PopModalAsync();
        }

        async void OnDeclineClicked(object sender, System.EventArgs e)
        {
            PrivacyPolicy.PrivacyPolicyInstance.IsAcknowledged = false;

            await Navigation.PopModalAsync();
        }
    }
}
