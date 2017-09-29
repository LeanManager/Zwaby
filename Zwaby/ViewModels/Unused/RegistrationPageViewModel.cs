using System;
using System.Collections.Generic;
using SQLite;
using Zwaby.Models;

namespace Zwaby.ViewModels
{
    public class RegistrationPageViewModel : ViewModelBase
    {
		public RegistrationPageViewModel(string databasePath)
		{
			// creates SQLite async connection and creates Customer table at the specified path
			CustomerDataService.Initialize(databasePath);
		}

        // FirstName, LastName, EmailAddress, PhoneNumber properties for binding
        public Customer Customer { get; set; }


        // Call CustomerDataService, which contains SQLite async methods

		public void SaveState(IDictionary<string, object> dictionary)
		{
			//dictionary["HistoryString"] = HistoryString;
			//dictionary["isSumDisplayed"] = isSumDisplayed;

            // save SQLiteAsyncConnection itself?
            // save private fields and public properties of the ViewModel itself
		}

		public void RestoreState(IDictionary<string, object> dictionary)
		{
			//HistoryString = GetDictionaryEntry(dictionary, "HistoryString", "");
			//isSumDisplayed = GetDictionaryEntry(dictionary, "isSumDisplayed", false);
			//accumulatedSum = GetDictionaryEntry(dictionary, "accumulatedSum", 0.0);

		}

		public T GetDictionaryEntry<T>(IDictionary<string, object> dictionary, string key, T defaultValue)
		{
			if (dictionary.ContainsKey(key))
				return (T)dictionary[key];

			return defaultValue;
		}
    }
}
