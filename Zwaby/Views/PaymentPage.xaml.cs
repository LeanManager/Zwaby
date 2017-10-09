using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Zwaby.Services;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            var viewModel = new PaymentPageViewModel(new StripeRepository(), new APIRepository());

            this.BindingContext = viewModel;
        }

        async void OnFinishBookingClicked(object sender, System.EventArgs e)
        {
            // TODO: Do payment entries Validation

            // TODO: Store Stripe token for future payments

            // TODO: Stripe integration
            var viewModel = (PaymentPageViewModel)this.BindingContext;

            await viewModel.ProcessPayment();

            // use MessagingCenter to tell the ~BookingViewModel that a booking has been made? ChangeCanExecute() for the booking details button

			//await DisplayAlert("Success!", "Your booking has been confirmed. You will find details in 'Current Booking'", "OK");

            // Initiliaze the MainPage passing the collected values for the booking
           // Navigation.InsertPageBefore(new MainPage(), this);

           // await Navigation.PopAsync();

            //await Navigation.PopToRootAsync();

            // pop to root async will work once the conditional MainPage setting in App.cs is ready
        }
    }
}
