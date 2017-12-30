using System;
using System.Collections.Generic;

namespace Zwaby.Models
{
    public class TermsAndConditions
    {
        public static TermsAndConditions TermsAndConditionsInstance { get; set; }

        public bool IsAcknowledged { get; set; }

        public TermsAndConditions()
        {
        }

        public void SaveState(IDictionary<string, object> dictionary, bool isAcknowledged)
        {
            dictionary["IsAcknowledged"] = isAcknowledged;
        }

        public void RestoreState(IDictionary<string, object> dictionary)
        {
            TermsAndConditions.TermsAndConditionsInstance.IsAcknowledged = GetDictionaryEntry(dictionary, "IsAcknowledged", false);
        }

        public T GetDictionaryEntry<T>(IDictionary<string, object> dictionary, string key, T defaultValue)
        {
            if (dictionary.ContainsKey(key))
                return (T)dictionary[key];

            return defaultValue;
        }
    }
}
