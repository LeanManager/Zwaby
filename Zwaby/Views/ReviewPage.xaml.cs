using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Zwaby.Views
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage()
        {
            InitializeComponent();
        }

        async void OnSubmitClicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
