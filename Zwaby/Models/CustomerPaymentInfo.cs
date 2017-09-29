using System;
using SQLite;

namespace Zwaby.Models
{
    public class CustomerPaymentInfo
    {
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[MaxLength(250)]
		public string CreditCardName
		{
			get; set;
		}

		[MaxLength(250)]
		public string CreditCardNumber
		{
			get; set;
		}

		[MaxLength(250)]
		public string ExpirationDate
		{
			get; set;
		}

		[MaxLength(250)]
		public string SecurityCode
		{
			get; set;
		}

		[MaxLength(250)]
		public string BillingZipCode
		{
			get; set;
		}
    }
}
