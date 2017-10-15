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

            // TODO: Generate values for approximate service duration, and total service price
            // parameters for duration: bedrooms, bathrooms, residence type, state of home (pull from ViewModel instance)
            // parameter for total service price: duration

            var calculations = new BookingCalculations();

            var bedrooms = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBedrooms;
            var bathrooms = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBathrooms;
            var residence = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceResidence;
            var homeState = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceHomeState;

            var approxDuration = calculations.CalculateDuration(bedrooms, bathrooms, residence, homeState);

            var totalBookingPrice = calculations.CalculatePrice(approxDuration, residence);

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

			//await DisplayAlert("Success!", "Your booking has been confirmed. You will find details in 'Current Booking'", "OK");

            // TODO: Initiliaze the MainPage and assign the collected values for the booking to the static ViewModel instance's properties

            // TODO: Perhaps have a static instance of a ViewModel (like FanReact)
            //       and use SaveState and RestoreState methods

            // await Navigation.PushAsync(new MainPage());
        }
    }
}
