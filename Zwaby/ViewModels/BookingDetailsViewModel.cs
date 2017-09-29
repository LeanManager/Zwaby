using System;
namespace Zwaby.ViewModels
{
    public class BookingDetailsViewModel : ViewModelBase
    {
		// Save the state of this ViewModel

		private string serviceDate;
		public string ServiceDate
		{
			private set
			{
				if (SetProperty(ref serviceDate, value))
				{
					
				}
			}
			get
			{
				return serviceDate;
			}
		}

		private string serviceTime;
		public string ServiceTime
		{
			private set
			{
				if (SetProperty(ref serviceTime, value))
				{

				}
			}
			get
			{
				return serviceTime;
			}
		}

		private string serviceLocation;
		public string ServiceLocation
		{
			private set
			{
				if (SetProperty(ref serviceLocation, value))
				{

				}
			}
			get
			{
				return serviceLocation;
			}
		}


        public BookingDetailsViewModel()
        {
        }
    }
}
