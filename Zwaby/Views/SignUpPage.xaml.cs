using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Zwaby.ViewModels;
using Zwaby.Views;

namespace Zwaby.Views
{
    public partial class SignUpPage : ContentPage
    {
        // re adjust views Orientation property (for this(?) and other views)
        // OnPageSizeChanged

        public SignUpPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        async void OnSignUpClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}
