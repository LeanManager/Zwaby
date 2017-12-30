using System;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using Zwaby.Models;

namespace Zwaby.ViewModels
{
    public class ServiceLocationPageViewModel : ViewModelBase
    {
        public ServiceLocationPageViewModel()
        {
            var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

            var variable = sqLiteConnection.GetTableInfo(typeof(CustomerAddress).Name);

            if (variable.Count == 0)
            {
                sqLiteConnection.CreateTable<CustomerAddress>();

                sqLiteConnection.Insert(new CustomerAddress());
            }
            else
            {
                var customerAddress = sqLiteConnection.Table<CustomerAddress>().First();

                Street = customerAddress.Street;

                City = customerAddress.City;

                State = customerAddress.State;

                ZipCode = customerAddress.ZipCode;

                ResidenceType = customerAddress.ResidenceType;

                Bedrooms = customerAddress.Bedrooms;

                Bathrooms = customerAddress.Bathrooms;
            }

            sqLiteConnection.Dispose();
        }

        private string street;
        public string Street
        {
            set
            {
                if(SetProperty(ref street, value))
                {
                    // Update SQLite
                    var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerAddress
					{
						Id = 1,
                        Street = value,
                        City = city,
                        State = state,
                        ZipCode = zipCode,
                        ResidenceType = residenceType,
                        Bedrooms = bedrooms,
                        Bathrooms = bathrooms
					});

                    sqLiteConnection.Dispose();
                }
            }
            get
            {
                return street;
            }
        }

        private string city;
        public string City
        {
			set
			{
				if (SetProperty(ref city, value))
				{
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerAddress
					{
						Id = 1,
						Street = street,
						City = value,
						State = state,
						ZipCode = zipCode,
						ResidenceType = residenceType,
						Bedrooms = bedrooms,
						Bathrooms = bathrooms
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
				return city;
			}
        }

        private string state;
        public string State
        {
			set
			{
				if (SetProperty(ref state, value))
				{
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerAddress
					{
						Id = 1,
						Street = street,
						City = city,
						State = value,
						ZipCode = zipCode,
						ResidenceType = residenceType,
						Bedrooms = bedrooms,
						Bathrooms = bathrooms
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
				return state;
			}
        }

        private string zipCode;
        public string ZipCode
        {
			set
			{
				if (SetProperty(ref zipCode, value))
				{
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerAddress
					{
						Id = 1,
						Street = street,
						City = city,
						State = state,
						ZipCode = value,
						ResidenceType = residenceType,
						Bedrooms = bedrooms,
						Bathrooms = bathrooms
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
				return zipCode;
			}
        }

        private string residenceType;
        public string ResidenceType
        {
			set
			{
				if (SetProperty(ref residenceType, value))
				{
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerAddress
					{
						Id = 1,
						Street = street,
						City = city,
						State = state,
						ZipCode = zipCode,
						ResidenceType = value,
						Bedrooms = bedrooms,
						Bathrooms = bathrooms
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
				return residenceType;
			}
        }

		private double bedrooms;
		public double Bedrooms
		{
			set
			{
				if (SetProperty(ref bedrooms, value))
				{
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerAddress
					{
						Id = 1,
						Street = street,
						City = city,
						State = state,
						ZipCode = zipCode,
						ResidenceType = residenceType,
                        Bedrooms = value,
                        Bathrooms = bathrooms
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
				return bedrooms;
			}
		}

		private double bathrooms;
		public double Bathrooms
		{
			set
			{
				if (SetProperty(ref bathrooms, value))
				{
					// Update SQLite
					var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

					sqLiteConnection.Update(new CustomerAddress
					{
						Id = 1,
						Street = street,
						City = city,
						State = state,
						ZipCode = zipCode,
						ResidenceType = residenceType,
						Bedrooms = bedrooms,
						Bathrooms = value
					});

					sqLiteConnection.Dispose();
				}
			}
			get
			{
				return bathrooms;
			}
		}
    }
}
