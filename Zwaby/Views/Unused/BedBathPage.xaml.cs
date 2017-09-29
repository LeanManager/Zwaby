using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Zwaby.Views
{
    public partial class BedBathPage : ContentPage
    {
        public BedBathPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgb(0, 240, 255);

            // TODO: Also add 3 pictures => How dirty is the house/apartment?
        }

        async void OnNextClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PaymentPage());
        }
    }
}
