using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace Zwaby.Models
{
    //[Table("customer")]
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string FirstName
        {
            get; set;
        }

        [MaxLength(250)]
		public string LastName
		{
            get; set;
		}

        [MaxLength(250)]
		public string EmailAddress
		{
            get; set;
		}

        [MaxLength(250)]
		public string PhoneNumber
		{
            get; set;
		}

        public string Password
        {
            get; set;
        }

        //public DateTime DateAdded
        //{
        //    get; set;
        //}
    }
}
