using System;
namespace Zwaby.ViewModels
{
    public class BookingDetailsViewModel : ViewModelBase
    {
		// Save the state of this ViewModel

        public static BookingDetailsViewModel BookingDetailsViewModelInstance { get; set; }

        public string ServiceDate { get; set; } //

        public string ServiceTime { get; set; } //

        public string ServicePrice { get; set; }

        public string ServiceApproximateDuration { get; set; }

        public string ServiceStreet { get; set; } //

        public string ServiceCity { get; set; } //

        public string ServiceState { get; set; } //

        public string ServiceZipCode { get; set; } //

        public string ServiceResidence { get; set; } //

        public string ServiceBedrooms { get; set; } //

        public string ServiceBathrooms { get; set; } //

        public string ServiceHomeState { get; set; } //

        public string ServiceNotes { get; set; } //

		public BookingDetailsViewModel()
		{
            
		}

		//private string serviceDate;
		//public string ServiceDate
		//{
		//	private set
		//	{
		//		if (SetProperty(ref serviceDate, value))
		//		{
		//		}
		//	}
		//	get
		//	{
		//		return serviceDate;
		//	}
		//}

		//private string serviceTime;
		//public string ServiceTime
		//{
		//	private set
		//	{
		//		if (SetProperty(ref serviceTime, value))
		//		{
		//		}
		//	}
		//	get
		//	{
		//		return serviceTime;
		//	}
		//}

		//private string serviceLocation;
		//public string ServiceLocation
		//{
		//	private set
		//	{
		//		if (SetProperty(ref serviceLocation, value))
		//		{
		//		}
		//	}
		//	get
		//	{
		//		return serviceLocation;
		//	}
		//}
    }
}
