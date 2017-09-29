using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Zwaby.Views
{
	public partial class BookingDetailsPage : ContentPage
	{
		public BookingDetailsPage()
		{
			InitializeComponent();

			this.BackgroundColor = Color.FromRgb(0, 240, 255);

			bookingImage.Source = ImageSource.FromResource("Zwaby.Images.child-1245893_1280.jpg");
		}

		async void OnCancelBookingClicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new CancelBookingPage());
		}
	}
}
