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
            await Navigation.PushAsync(new ServiceDateTimePage());
        }
    }
}
