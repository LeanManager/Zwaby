using System;
namespace Zwaby.Services
{
    public class BookingCalculations
    {
        public string CalculateDuration(string bedrooms, string bathrooms, string residence, string homeState)
        {
            double bedroomNumber = Double.Parse(bedrooms);
            double bathroomNumber = Double.Parse(bathrooms);
            //double residenceFactor; // multiply approximate total duration by this factor
            string serviceDuration;
            double cleanerNumber;
            //double homeStateFactor;

            // Always send 2 cleaners?
            // 45 min/bed and 45 min/bath

            var duration = (bedroomNumber * 45) + (bathroomNumber * 45);

			if (residence == "House")
			{
				//residenceFactor = 1.5;
				cleanerNumber = 2.0;
                duration = duration / cleanerNumber;
			}
			else if (residence == "Apartment")
			{
				//residenceFactor = 1.4;
				cleanerNumber = 1.0;
                duration = duration / cleanerNumber;
			}

            duration = duration / 60;

            serviceDuration = duration.ToString();

            return serviceDuration;
        }

        public string CalculatePrice(string serviceDuration, string residence)
        {
            double totalPrice;

            // $30/hour
            if (residence == "House")
            {
                totalPrice = Double.Parse(serviceDuration) * 30 * 2;
            }
            else
            {
                totalPrice = Double.Parse(serviceDuration) * 30;
            }

            return totalPrice.ToString();
        }

        // TODO: The Cleaning Authority calculation methods


        public override string ToString()
        {
            return string.Format("[BookingCalculations]");
        }
    }
}
