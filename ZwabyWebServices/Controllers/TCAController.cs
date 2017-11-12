using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwabyWebServices.Models;

namespace ZwabyWebServices.Controllers
{
    [Route("api/[controller]")]
    public class TCAController : Controller
    {
        [HttpPost]
        public List<string> Post([FromBody] PricingVariables variables)
        {
            var bedrooms = Int32.Parse(variables.Bedrooms);
            var bathrooms = Int32.Parse(variables.Bathrooms);
            var residenceType = variables.ResidenceType;
            var serviceType = variables.ServiceType;

            var duration = GetDuration(bedrooms, bathrooms, residenceType, serviceType);

            var price = CalculatePrice(duration, residenceType, serviceType);

            double approxDuration = duration / 2;
            double finalDuration = Math.Round(approxDuration, 1);

            string serviceDuration = finalDuration.ToString();

            string finalPrice = price.ToString();

            var list = new List<string>();
            list.Add(serviceDuration);
            list.Add(finalPrice);

            return list;
        }

        private double CalculatePrice(double hours, string residenceType, string serviceType)
        {
            double price = hours * 30;

            if (residenceType == "House")
            {
                price = price + 5.0;
            }
            else // Apartment
            {
                price = price + 3.0;
            }

            if (serviceType == "Deep Cleaning" && residenceType == "House")
            {
                price = price + 15.0;
            }
            else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
            {
                price = price + 10.0;
            }

            return price;
        }

        private double GetDuration(int bedrooms, int bathrooms, string residenceType, string serviceType)
        {
            // 40 min per bedroom, 40 min per bathroom (average; use live data to converge on truth)
            // Always 2 cleaners at a time

            double baseDuration = (bedrooms * 40) + (bathrooms * 40);

            double residenceFactor;
            double serviceTypeFactor;

            if (residenceType == "House")
            {
                residenceFactor = 1.1;
            }
            else // Apartment
            {
                residenceFactor = 1.0;
            }

            if (serviceType == "General Cleaning")
            {
                serviceTypeFactor = 1.0;
            }
            else // Deep
            {
                serviceTypeFactor = 2.0;
            }

            double totalTime = baseDuration * residenceFactor * serviceTypeFactor;

            totalTime = totalTime / 60;

            return totalTime;
        }
    }
}
