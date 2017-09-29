using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Interfaces;
using Zwaby.Models;

namespace Zwaby.ViewModels
{
    public class PaymentPageViewModel : ViewModelBase
    {
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

        public async Task ProcessPayment()
        {
            try
            {
                if (string.IsNullOrEmpty(ExpirationDate))
                    ExpirationDate = "09/18";

                var exp = ExpirationDate.Split('/');
                var token = _repository.CreateToken(CreditCardNumber, exp[0], exp[1], SecurityCode);
                await Application.Current.MainPage.DisplayAlert("Test Message", token, "OK");
                await _api.ChargeCard(token, 5.00M);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        
        private readonly IStripeRepository _repository;
        private readonly IAPIRepository _api;
		public PaymentPageViewModel(IStripeRepository repository, IAPIRepository api)
        {
            _repository = repository;
            _api = api;
			// TODO: Use BookingCalculations to assign the ViewModel properties

			// generate Approximate Duration for the service 
			// based on bedrooms, bathrooms, residence type, and *how dirty the residence is

			//var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

			//var variable = sqLiteConnection.GetTableInfo(typeof(CustomerPaymentInfo).Name);

			//if (variable.Count == 0)
			//{
			//	sqLiteConnection.CreateTable<CustomerPaymentInfo>();

			//	sqLiteConnection.Insert(new CustomerPaymentInfo());
			//}
			//else
			//{
			//	var customerPaymentInfo = sqLiteConnection.Table<CustomerPaymentInfo>().First();

   //             CreditCardName = customerPaymentInfo.CreditCardName;

   //             CreditCardNumber = customerPaymentInfo.CreditCardNumber;

   //             ExpirationDate = customerPaymentInfo.ExpirationDate;

   //             SecurityCode = customerPaymentInfo.SecurityCode;

   //             BillingZipCode = customerPaymentInfo.BillingZipCode;
			//}

			//sqLiteConnection.Dispose();
        }
    }
}
