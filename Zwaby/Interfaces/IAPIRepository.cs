using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zwaby.Interfaces
{
    public interface IAPIRepository
    {
        Task<string> ChargeCard(string token, int amount);
    }
}
