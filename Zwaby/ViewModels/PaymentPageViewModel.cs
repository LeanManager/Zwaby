using System;
using System.Collections.Generic;
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
				var exp = ExpirationDate.Split('/');

				var token = _repository.CreateToken(CreditCardNumber, exp[0], "20" + exp[1], SecurityCode);

                // TODO: Store Stripe token in SQLite for future payments

				await _api.ChargeCard(token, ServicePrice);

                ExceptionModel.ExceptionModelInstance.PaymentError = "";
			}
			catch (Exception ex)
			{
                HockeyApp.MetricsManager.TrackEvent("OnProcessPayment",
                                                new Dictionary<string, string>
                                                {
                                                    {"Time", DateTime.UtcNow.ToString() },
                                                    {"Error", ex.Message }
                                                },
                                                new Dictionary<string, double>
                                                {
                                                    {"Value", 2.5 }
                                                });

                ExceptionModel.ExceptionModelInstance.PaymentError = ex.Message;
				await Application.Current.MainPage.DisplayAlert("Error", "An error ocurred while processing payment. Please try again.", "OK");
			}
		}

		private string serviceDuration;
		public string ServiceDuration
		{
			set
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

		private int servicePrice;
		public int ServicePrice
		{
			set
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
			set
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
			set
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
			set
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
			set
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
			set
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
