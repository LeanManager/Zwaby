using System;
namespace ZwabyWebServices.Models
{
    public class StripeItem
    {
		// The database generates the Id when a StripeItem is created.

		public long Id
		{
			get;
			set;
		}

        public string Token
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }
    }
}
