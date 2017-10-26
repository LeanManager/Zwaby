using System;

namespace Zwaby.Models
{
    public class PaymentModel
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public int Amount { get; set; }
    }
}
