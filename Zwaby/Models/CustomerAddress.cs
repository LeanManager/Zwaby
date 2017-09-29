using System;
using SQLite;

namespace Zwaby.Models
{
    public class CustomerAddress
    {
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[MaxLength(250)]
		public string Street
		{
			get; set;
		}

		[MaxLength(250)]
		public string City
		{
			get; set;
		}

		[MaxLength(250)]
		public string State
		{
			get; set;
		}

		[MaxLength(250)]
		public string ZipCode
		{
			get; set;
		}

		[MaxLength(250)]
		public string ResidenceType
		{
			get; set;
		}

		public double Bedrooms
		{
			get; set;
		}

		public double Bathrooms
		{
			get; set;
		}
    }
}
