using System;
namespace Zwaby.Models
{
    public class TermsAndConditions
    {
        public static TermsAndConditions TermsAndConditionsInstance { get; set; }

        public bool IsAcknowledged { get; set; }

        public TermsAndConditions()
        {
        }
    }
}
