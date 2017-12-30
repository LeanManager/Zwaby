using System;
using System.Collections.Generic;

namespace Zwaby.ViewModels
{
    public class BookingDetailsViewModel : ViewModelBase
    {
        public static BookingDetailsViewModel BookingDetailsViewModelInstance { get; set; }

        public string ServiceDate { get; set; }

        public string ServiceTime { get; set; }

        public string ServicePrice { get; set; }

        public string ServiceApproximateDuration { get; set; }

        public string ServiceStreet { get; set; }

        public string ServiceCity { get; set; }

        public string ServiceState { get; set; }

        public string ServiceZipCode { get; set; }

        public string ServiceResidence { get; set; }

        public string ServiceBedrooms { get; set; }

        public string ServiceBathrooms { get; set; }

        public string ServiceType { get; set; }

        public string ServiceNotes { get; set; }

        public DateTime ServiceDateTime { get; set; }

		public BookingDetailsViewModel()
		{
		}

        public void SaveState(IDictionary<string, object> dictionary, string date, string time, string price, string duration,
                             string street, string city, string state, string zip, string residence, string bedrooms,
                             string bathrooms, string serviceType, string notes, DateTime serviceTime)
        {
            dictionary["ServiceDate"] = date;
            dictionary["ServiceTime"] = time;
            dictionary["ServicePrice"] = price;
            dictionary["ServiceApproximateDuration"] = duration;
            dictionary["ServiceStreet"] = street;
            dictionary["ServiceCity"] = city;
            dictionary["ServiceState"] = state;
            dictionary["ServiceZipCode"] = zip;
            dictionary["ServiceResidence"] = residence;
            dictionary["ServiceBedrooms"] = bedrooms;
            dictionary["ServiceBathrooms"] = bathrooms;
            dictionary["ServiceType"] = serviceType;
            dictionary["ServiceNotes"] = notes;
            dictionary["ServiceDateTime"] = serviceTime;
        }

        public void RestoreState(IDictionary<string, object> dictionary)
        {
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDate = GetDictionaryEntry(dictionary, "ServiceDate", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceTime = GetDictionaryEntry(dictionary, "ServiceTime", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice = GetDictionaryEntry(dictionary, "ServicePrice", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration = GetDictionaryEntry(dictionary, "ServiceApproximateDuration", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceStreet = GetDictionaryEntry(dictionary, "ServiceStreet", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceCity = GetDictionaryEntry(dictionary, "ServiceCity", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceState = GetDictionaryEntry(dictionary, "ServiceState", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceZipCode = GetDictionaryEntry(dictionary, "ServiceZipCode", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceResidence = GetDictionaryEntry(dictionary, "ServiceResidence", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBedrooms = GetDictionaryEntry(dictionary, "ServiceBedrooms", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBathrooms = GetDictionaryEntry(dictionary, "ServiceBathrooms", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceType = GetDictionaryEntry(dictionary, "ServiceType", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceNotes = GetDictionaryEntry(dictionary, "ServiceNotes", "");
            BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDateTime = GetDictionaryEntry(dictionary, "ServiceDateTime", DateTime.Now);
        }

        public T GetDictionaryEntry<T>(IDictionary<string, object> dictionary, string key, T defaultValue)
        {
            if (dictionary.ContainsKey(key))
                return (T)dictionary[key];
            
            return defaultValue;
        }
    }
}
