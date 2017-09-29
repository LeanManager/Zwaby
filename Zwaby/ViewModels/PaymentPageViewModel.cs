using System;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
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
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerPaymentInfo
					{
						Id = 1,
						CreditCardName = value,
                        CreditCardNumber = creditCardNumber,
                        ExpirationDate = expirationDate,
                        SecurityCode = securityCode,
                        BillingZipCode = billingZipCode
					});

					sqLiteConnection.Dispose();
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
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerPaymentInfo
					{
						Id = 1,
						CreditCardName = creditCardName,
						CreditCardNumber = value,
						ExpirationDate = expirationDate,
						SecurityCode = securityCode,
						BillingZipCode = billingZipCode
					});

					sqLiteConnection.Dispose();
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
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerPaymentInfo
					{
						Id = 1,
						CreditCardName = creditCardName,
						CreditCardNumber = creditCardNumber,
						ExpirationDate = value,
						SecurityCode = securityCode,
						BillingZipCode = billingZipCode
					});

					sqLiteConnection.Dispose();
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
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerPaymentInfo
					{
						Id = 1,
						CreditCardName = creditCardName,
						CreditCardNumber = creditCardNumber,
						ExpirationDate = expirationDate,
						SecurityCode = value,
						BillingZipCode = billingZipCode
					});

					sqLiteConnection.Dispose();
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
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerPaymentInfo
					{
						Id = 1,
						CreditCardName = creditCardName,
						CreditCardNumber = creditCardNumber,
						ExpirationDate = expirationDate,
						SecurityCode = securityCode,
						BillingZipCode = value
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
				return billingZipCode;
			}
		}


		public PaymentPageViewModel()
        {
			// TODO: Use BookingCalculations to assign the ViewModel properties

			// generate Approximate Duration for the service 
			// based on bedrooms, bathrooms, residence type, and *how dirty the residence is

			var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

			var variable = sqLiteConnection.GetTableInfo(typeof(CustomerPaymentInfo).Name);

			if (variable.Count == 0)
			{
				sqLiteConnection.CreateTable<CustomerPaymentInfo>();

				sqLiteConnection.Insert(new CustomerPaymentInfo());
			}
			else
			{
				var customerPaymentInfo = sqLiteConnection.Table<CustomerPaymentInfo>().First();

                CreditCardName = customerPaymentInfo.CreditCardName;

                CreditCardNumber = customerPaymentInfo.CreditCardNumber;

                ExpirationDate = customerPaymentInfo.ExpirationDate;

                SecurityCode = customerPaymentInfo.SecurityCode;

                BillingZipCode = customerPaymentInfo.BillingZipCode;
			}

			sqLiteConnection.Dispose();
        }
    }
}
