using System;
namespace Zwaby.Interfaces
{
    public interface IStripeRepository
    {
        string CreateToken(string cardNumber, string cardExpMonth, string cardExpYear, string cardCVC);
    }
}
