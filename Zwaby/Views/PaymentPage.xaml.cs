﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Connectivity;
using Xamarin.Forms;
using Zwaby.Models;
using Zwaby.Services;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class PaymentPage : ContentPage
    {
        string approxDuration, totalBookingPrice, roundedDuration;

        private BookingsManager manager;

        public PaymentPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            ExceptionModel.ExceptionModelInstance = new ExceptionModel();

            CalculatePriceAndDuration();

            manager = new BookingsManager();

            var viewModel = new PaymentPageViewModel(new StripeRepository(), new APIRepository());

            this.BindingContext = viewModel;
        }

        private void CalculatePriceAndDuration()
        {
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
        }

        private PaymentPageViewModel UpdatePaymentPageViewModel()
        {
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

            return viewModel;
        }


        async void OnFinishBookingClicked(object sender, System.EventArgs e)
        {
            HockeyApp.MetricsManager.TrackEvent("OnFinishBookingClicked",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

            if (cardNumber.Text == null || expirationDate.Text == null || securityCode.Text == null)
            {
                await DisplayAlert("", "Please enter valid credit card information.", "OK");
            }
            else if ((cardNumber.Text.Length < 15 || string.IsNullOrWhiteSpace(cardNumber.Text))
                     || (!expirationDate.Text.Contains("/") || string.IsNullOrWhiteSpace(expirationDate.Text) || expirationDate.Text.Length > 5)
                     || (securityCode.Text.Length < 3 || string.IsNullOrWhiteSpace(securityCode.Text) || securityCode.Text.Length > 4))
            {
                await DisplayAlert("", "Card number must have at least 15 digits.\n"
                                       + "Expiration date must be in the sample format 07/21\n"
                                       + "Security code must have 3 or 4 digits.", "OK");
            }
            else
            {
                finishBookingButton.IsEnabled = false;
                this.IsBusy = true;

                var viewModel = UpdatePaymentPageViewModel();

                if (CrossConnectivity.Current.IsConnected)
                {
                    await viewModel.ProcessPayment();

                    if (string.IsNullOrWhiteSpace(ExceptionModel.ExceptionModelInstance.PaymentError))
                    {
                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration = roundedDuration + " hours";
                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice = totalBookingPrice + " USD";

                        try
                        {
                            await manager.AddNewBooking(BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDate,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceTime,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceStreet,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceCity,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceState,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceZipCode,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceResidence,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBedrooms,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBathrooms,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceNotes,
                                                        BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDateTime);
                        }
                        // catch (Exception ex) { TODO: handle potential exception }
                        finally
                        {
                            HockeyApp.MetricsManager.TrackEvent("BookingCompletedSuccessfully",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

                            this.IsBusy = false;
                            finishBookingButton.IsEnabled = true;

                            await DisplayAlert("Success!", "Your booking has been confirmed. You will find details in 'Booking Details'", "OK");

                            await Navigation.PushAsync(new MainPage());
                        }
                    }
                    else
                    {
                        this.IsBusy = false;
                        finishBookingButton.IsEnabled = true;
                    }
                }
                else
                {
                    finishBookingButton.IsEnabled = true;
                    this.IsBusy = false;

                    await DisplayAlert("Network connection not found", "Please try again with an active network connection.", "OK");
                }
            }
        }
    }
}
