using System;

namespace Zwaby.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string ServiceDate { get; set; }

        public string ServiceTime { get; set; }

        public string ServicePrice { get; set; }

        public string ServiceApproximateDuration { get; set; }

        public string ServiceStreet { get; set; }

        public string ServiceCity { get; set; }

        public string ServiceState { get; set; }

        public string ServiceZipCode { get; set; }

        public string ServiceResidence { get; set; }

        public string ServiceBedrooms { get; set; }

        public string ServiceBathrooms { get; set; }

        public string ServiceType { get; set; }

        public string ServiceNotes { get; set; }

        public DateTime ServiceDateTime { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
    }
}
