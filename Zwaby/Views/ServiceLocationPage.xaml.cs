using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Zwaby.ViewModels;

namespace Zwaby.Views
{
    public partial class ServiceLocationPage : ContentPage
    {
        public ServiceLocationPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            var viewModel = new ServiceLocationPageViewModel();

            this.BindingContext = viewModel;
        }

        async void OnNextClicked(object sender, System.EventArgs e)
        {
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceStreet = street.Text;
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceCity = city.Text;
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceState = state.Text;
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceZipCode = zipCode.Text;
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceResidence = residence.SelectedItem.ToString();
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBedrooms = bedrooms.SelectedItem.ToString();
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBathrooms = bathrooms.SelectedItem.ToString();

            await Navigation.PushAsync(new ServiceDateTimePage());
        }
    }
}
