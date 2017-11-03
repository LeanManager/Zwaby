using System;
namespace Zwaby.Models
{
    public class ExceptionModel
    {
        public static ExceptionModel ExceptionModelInstance { get; set; }

        public string PaymentError { get; set; }

        public ExceptionModel()
        {
        }
    }
}
