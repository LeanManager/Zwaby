using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Models;

namespace Zwaby.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {
        private string firstName;
		public string FirstName
		{
			set
			{
				if (SetProperty(ref firstName, value))
				{
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new Customer
					{
						Id = 1,
						FirstName = value,
                        LastName = lastName,
                        EmailAddress = emailAddress,
                        PhoneNumber = phoneNumber
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
                return firstName;
			}
		}

		private string lastName;
		public string LastName
		{
			set
			{
				if (SetProperty(ref lastName, value))
				{
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new Customer
                    {
                        Id = 1,
                        FirstName = firstName,
						LastName = value,
						EmailAddress = emailAddress,
						PhoneNumber = phoneNumber
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
				return lastName;
			}
		}

		private string emailAddress;
		public string EmailAddress
		{
			set
			{
				if (SetProperty(ref emailAddress, value))
				{
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new Customer
                    {
                        Id = 1,
                        FirstName = firstName,
						LastName = lastName,
						EmailAddress = value,
						PhoneNumber = phoneNumber
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
				return emailAddress;
			}
		}

		private string phoneNumber;
		public string PhoneNumber
		{
			set
			{
				if (SetProperty(ref phoneNumber, value))
				{
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new Customer
                    {
                        Id = 1,
                        FirstName = firstName,
						LastName = lastName,
						EmailAddress = emailAddress,
						PhoneNumber = value
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
				return phoneNumber;
			}
		}

        public ProfilePageViewModel()
        {
			var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

			var customer = sqLiteConnection.Table<Customer>().First();

			FirstName = customer.FirstName;

			LastName = customer.LastName;

			PhoneNumber = customer.PhoneNumber;

			EmailAddress = customer.EmailAddress;

            sqLiteConnection.Dispose();

            //FirstNameCommand = new Command(
            //    execute: () =>
            //    {
            //    });
			//LastNameCommand = new Command(
			//	execute: () =>
			//	{  
			//	});
			//EmailAddressCommand = new Command(
			//	execute: () =>
			//	{ 
			//	});
			//PhoneNumberCommand = new Command(
				//execute: () =>
				//{
				//});
        }

		// ICommands~ is private access modifier necessary?
		//public ICommand FirstNameCommand { private set; get; }
		//public ICommand LastNameCommand { private set; get; }
		//public ICommand EmailAddressCommand { private set; get; }
		//public ICommand PhoneNumberCommand { private set; get; }
	}
}
