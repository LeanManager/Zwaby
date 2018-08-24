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

            var price = CalculatePrice(bedrooms, bathrooms, residenceType, serviceType);

            //double approxDuration = duration / 2;
            double finalDuration = Math.Round(duration, 1);

            string serviceDuration = finalDuration.ToString();

            string finalPrice = price.ToString();

            var list = new List<string>();
            list.Add(serviceDuration);
            list.Add(finalPrice);

            return list;
        }

        private double CalculatePrice(int bedrooms, int bathrooms, string residenceType, string serviceType)
        {
            double price;

            if (bedrooms == 1 && bathrooms == 1)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 75.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 150.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 90.0;
                }
                else
                {
                    price = 180.0;
                }
                return price;
            }
            else if (bedrooms == 2 && bathrooms == 1)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 85.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 170.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 100.0;
                }
                else
                {
                    price = 200.0;
                }
                return price;
            }
            else if (bedrooms == 2 && bathrooms == 2)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 95.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 190.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 110.0;
                }
                else
                {
                    price = 220.0;
                }
                return price;
            }
            else if (bedrooms == 3 && bathrooms == 1)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 95.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 190.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 110.0;
                }
                else
                {
                    price = 220.0;
                }
                return price;
            }
            else if (bedrooms == 3 && bathrooms == 2)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 105.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 210.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 120.0;
                }
                else
                {
                    price = 240.0;
                }
                return price;
            }
            else if (bedrooms == 3 && bathrooms == 3)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 115.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 230.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 130.0;
                }
                else
                {
                    price = 260.0;
                }
                return price;
            }
            else if (bedrooms == 4 && bathrooms == 1)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 105.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 210.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 120.0;
                }
                else
                {
                    price = 240.0;
                }
                return price;
            }
            else if (bedrooms == 4 && bathrooms == 2)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 115.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 230.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 130.0;
                }
                else
                {
                    price = 260.0;
                }
                return price;
            }
            else if (bedrooms == 4 && bathrooms == 3)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 125.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 250.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 140.0;
                }
                else
                {
                    price = 280.0;
                }
                return price;
            }
            else if (bedrooms == 4 && bathrooms == 4)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 135.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 270.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 150.0;
                }
                else
                {
                    price = 300.0;
                }
                return price;
            }
            else if (bedrooms == 5 && bathrooms == 1)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 115.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 230.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 130.0;
                }
                else
                {
                    price = 260.0;
                }
                return price;
            }
            else if (bedrooms == 5 && bathrooms == 2)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 125.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 250.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 140.0;
                }
                else
                {
                    price = 280.0;
                }
                return price;
            }
            else if (bedrooms == 5 && bathrooms == 3)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 135.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 270.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 150.0;
                }
                else
                {
                    price = 300.0;
                }
                return price;
            }
            else if (bedrooms == 5 && bathrooms == 4)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 145.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 290.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 160.0;
                }
                else
                {
                    price = 320.0;
                }
                return price;
            }
            else if (bedrooms == 5 && bathrooms == 5)
            {
                if (serviceType == "General Cleaning" && residenceType == "Apartment")
                {
                    price = 155.0;
                }
                else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
                {
                    price = 310.0;
                }
                else if (serviceType == "General Cleaning" && residenceType == "House")
                {
                    price = 170.0;
                }
                else
                {
                    price = 340.0;
                }
                return price;
            }
            // Never gets hit
            else
            {
                return price = 120.0;
            }

            //double price = hours * 30;
            //if (residenceType == "House")
            //{
            //    price = price + 5.0;
            //}
            //else // Apartment
            //{
            //    price = price + 3.0;
            //}
            //if (serviceType == "Deep Cleaning" && residenceType == "House")
            //{
            //    price = price + 15.0;
            //}
            //else if (serviceType == "Deep Cleaning" && residenceType == "Apartment")
            //{
            //    price = price + 10.0;
            //}
            //return price;
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