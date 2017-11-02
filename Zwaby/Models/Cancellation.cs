using System;
namespace Zwaby.Models
{
    public class Cancellation
    {
        public int Id { get; set; }

        public string CancellationReason { get; set; }

        public DateTime CancellationDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
    }
}
