using System;

namespace ZwabyWebServices.Models
{
    public class Customer
    {
        public int Id 
        { 
            get; set; 
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string EmailAddress
        {
            get; set;
        }

        public string PhoneNumber
        {
            get; set;
        }

        public DateTime DateAdded
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }
    }
}
