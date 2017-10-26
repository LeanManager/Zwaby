﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Interfaces;
using Zwaby.Models;

namespace Zwaby.ViewModels
{
    public class PaymentPageViewModel : ViewModelBase
    {
        // TODO: Store Stripe token in SQLite for future payments

		private readonly IStripeRepository _repository;
		private readonly IAPIRepository _api;

		public PaymentPageViewModel(IStripeRepository repository, IAPIRepository api)
		{
			_repository = repository;
			_api = api;
		}

		public async Task ProcessPayment()
		{
			try
			{
				if (string.IsNullOrEmpty(ExpirationDate))
					ExpirationDate = "09/18";

				var exp = ExpirationDate.Split('/');
				var token = _repository.CreateToken(CreditCardNumber, exp[0], exp[1], SecurityCode);
				await Application.Current.MainPage.DisplayAlert("Test Message", token, "OK");
				await _api.ChargeCard(token, 500);
			}
			catch (Exception ex)
			{
                Debug.WriteLine(ex.Message);
				await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
			}
		}

		private string serviceDuration;
		public string ServiceDuration
		{
			private set
			{
				if (SetProperty(ref serviceDuration, value))
				{
					// do something with the value
				}
			}
			get
			{
				return serviceDuration;
			}
		}

		private string servicePrice;
		public string ServicePrice
		{
			private set
			{
				if (SetProperty(ref servicePrice, value))
				{
					// do something with the value
				}
			}
			get
			{
				return servicePrice;
			}
		}

		private string creditCardName;
		public string CreditCardName
		{
			private set
			{
				if (SetProperty(ref creditCardName, value))
				{
				
				}
			}
			get
			{
				return creditCardName;
			}
		}

		private string creditCardNumber;
		public string CreditCardNumber
		{
			private set
			{
				if (SetProperty(ref creditCardNumber, value))
				{
					
				}
			}
			get
			{
				return creditCardNumber;
			}
		}

		private string expirationDate;
		public string ExpirationDate
		{
			private set
			{
				if (SetProperty(ref expirationDate, value))
				{
				

				}
			}
			get
			{
				return expirationDate;
			}
		}

		private string securityCode;
		public string SecurityCode
		{
			private set
			{
				if (SetProperty(ref securityCode, value))
				{
					
				}
			}
			get
			{
				return securityCode;
			}
		}

		private string billingZipCode;
		public string BillingZipCode
		{
			private set
			{
				if (SetProperty(ref billingZipCode, value))
				{
					
				}
			}
			get
			{
				return billingZipCode;
			}
		}
    }
}
