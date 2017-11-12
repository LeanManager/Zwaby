using System;
namespace Zwaby.Models
{
    public class PrivacyPolicy
    {
        public static PrivacyPolicy PrivacyPolicyInstance { get; set; }

        public bool IsAcknowledged { get; set; }

        public PrivacyPolicy()
        {
        }
    }
}
