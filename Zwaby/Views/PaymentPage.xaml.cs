using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Zwaby.Services;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class PaymentPage : ContentPage
    {
        string approxDuration, totalBookingPrice;

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

            approximateDuration.Text = approxDuration + " hours";

            totalPrice.Text = "$ " + totalBookingPrice;

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


            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration = approxDuration + " hours";
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice = totalBookingPrice + " USD";

			await DisplayAlert("Success!", "Your booking has been confirmed. You will find details in 'Booking Details'", "OK");

            // TODO: Fix Android back OS button issue

            await Navigation.PushAsync(new MainPage());
        }
    }
}
