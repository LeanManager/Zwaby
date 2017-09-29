using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace Zwaby.Models
{
    public sealed class CustomerDataService
    {
        private SQLiteAsyncConnection conn;

        // There should only be 1 SQLite connection
        private static CustomerDataService instance;
        public static CustomerDataService Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new Exception("You must call Initialize before retrieving the singleton for the CustomerDataService.");
                }
                return instance;
            }
        }

        public static void Initialize(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException(nameof(filename));
            }
            // Dispose any existing connection
            if (instance != null)
            {
                instance.conn.GetConnection().Dispose();
            }

            instance = new CustomerDataService(filename);
        }

		// There should only be 1 SQLite connection
		private CustomerDataService(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);

            conn.CreateTableAsync<Customer>().Wait();
        }



        public string StatusMessage { get; set; }


		public async Task AddCustomerAsync(string firstName, string lastName, string emailAddress, string phoneNumber)
		{
			// call SQLite to add customer instance

            try
            {
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(phoneNumber))
                {
                    throw new Exception("Valid entries required.");
                }

                // Insert new Customer into the Customer table
                await conn.InsertAsync(new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = emailAddress,
                    PhoneNumber = phoneNumber
                });

                StatusMessage = string.Format("{0} added as Customer", emailAddress);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("{0} could not be added as Customer. Error: {1}", emailAddress, ex.Message);
            }
        }


        public async Task<IEnumerable<Customer>> GetCustomerAsync()
        {
            // call SQLite to retrieve customer instance
           
            try
            {
                // return the Customer table in the database
                return await conn.Table<Customer>().ToListAsync();

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve Customer. {0}", ex.Message);
            }

            return Enumerable.Empty<Customer>();
        }
    }
}
