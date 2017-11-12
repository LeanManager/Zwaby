using System;
namespace ZwabyWebServices.Models
{
    public class PricingVariables
    {
        public PricingVariables()
        {
        }

        public string Bedrooms { get; set; }

        public string Bathrooms { get; set; }

        public string ResidenceType { get; set; }

        public string ServiceType { get; set; }
    }
}
