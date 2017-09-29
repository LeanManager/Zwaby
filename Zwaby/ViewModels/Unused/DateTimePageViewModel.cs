using System;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Models;

namespace Zwaby.ViewModels
{
    public class DateTimePageViewModel : ViewModelBase
    {
        private DateTime serviceDate;
        public DateTime ServiceDate
        {
            private set
            {
                if(SetProperty(ref serviceDate, value))
                {
                    // do something with the value
                }
            }
            get
            {
                return serviceDate;
            }
        }

		private TimeSpan serviceTime;
		public TimeSpan ServiceTime
		{
			private set
			{
				if (SetProperty(ref serviceTime, value))
				{
					// do something with the value
				}
			}
			get
			{
				return serviceTime;
			}
		}

        public DateTimePageViewModel()
        {
			
        }
    }
}
