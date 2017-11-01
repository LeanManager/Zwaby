using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;
using Zwaby.Services;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class PaymentPage : ContentPage
    {
        string approxDuration, totalBookingPrice, roundedDuration;

        public PaymentPage()
        {
            InitializeComponent();

            // TODO: Generate values for approximate service duration, and total service price
            // parameters for duration: bedrooms, bathrooms, residence type, state of home (pull from ViewModel instance)
            // parameter for total service price: duration

            var calculations = new BookingCalculations();

            var bedrooms = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBedrooms;
            var bathrooms = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBathrooms;
            var residence = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceResidence;
            var homeState = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceHomeState;

            approxDuration = calculations.CalculateDuration(bedrooms, bathrooms, residence, homeState);

            totalBookingPrice = calculations.CalculatePrice(approxDuration, residence);

            roundedDuration = (Math.Round(Double.Parse(approxDuration), 1)).ToString();

            approximateDuration.Text = roundedDuration + " hours";

            totalPrice.Text = "$ " + totalBookingPrice;

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            var viewModel = new PaymentPageViewModel(new StripeRepository(), new APIRepository());

            this.BindingContext = viewModel;
        }

        async void OnFinishBookingClicked(object sender, System.EventArgs e)
        {
            // TODO: Do payment entries validation

            // TODO: Store Stripe token for future payments

            // TODO: Stripe live mode integration

            this.IsBusy = true;

            var viewModel = (PaymentPageViewModel)this.BindingContext;

            viewModel.ServiceDuration = roundedDuration + " hours";
            // Stripe charges in cents
            var doublePrice = Double.Parse(totalBookingPrice) * 100;
            var servicePrice = (int)doublePrice;
            viewModel.ServicePrice = servicePrice;

            viewModel.CreditCardName = cardName.Text;
            viewModel.CreditCardNumber = cardNumber.Text;
            viewModel.ExpirationDate = expirationDate.Text;
            viewModel.SecurityCode = securityCode.Text;
            viewModel.BillingZipCode = billingZipCode.Text;

            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    await viewModel.ProcessPayment();
                }
                finally
                {
                    this.IsBusy = false;
                }

                BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration = roundedDuration + " hours";
                BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice = totalBookingPrice + " USD";

                await DisplayAlert("Success!", "Your booking has been confirmed. You will find details in 'Booking Details'", "OK");

                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                this.IsBusy = false;

                await DisplayAlert("Network connection not found", "Please try again with an active network connection.", "OK");
            }
        }
    }
}
