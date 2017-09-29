using System;
using SQLite;

namespace Zwaby.Models
{
    public class BookingDetails
    {
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

        public string ServiceDate
        {
            get;
            set;
        }
  
        public string ServiceTime
        {
            get;
            set;
        }

		public string HomeState
		{
			get;
			set;
		}

        public string ServiceNotes
        {
            get;
            set;
        }
    }
}
