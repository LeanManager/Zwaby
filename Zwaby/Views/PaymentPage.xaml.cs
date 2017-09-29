using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            var viewModel = new PaymentPageViewModel();

            this.BindingContext = viewModel;
        }

        async void OnFinishBookingClicked(object sender, System.EventArgs e)
        {
            // TODO: Do payment entries Validation

            var creditCardName = cardName.Text;
            var creditCardNumber = cardNumber.Text;
            var cardExpirationDate = expirationDate.Text;
            var cardSecurityCode = securityCode.Text;
            var cardZipCode = billingZipCode.Text;


            // TODO: Stripe integration (or manual)

            // use MessagingCenter to tell the ~BookingViewModel that a booking has been made? ChangeCanExecute() for the booking details button

			await DisplayAlert("Success!", "Your booking has been confirmed. You will find details in 'Current Booking'", "OK");

            // Initiliaze the MainPage passing the collected values for the booking
            Navigation.InsertPageBefore(new MainPage(), this);

            await Navigation.PopAsync();

            //await Navigation.PopToRootAsync();

            // pop to root async will work once the conditional MainPage setting in App.cs is ready
        }
    }
}
