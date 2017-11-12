using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwabyWebServices.Models;

namespace ZwabyWebServices.Controllers
{
    [Route("api/[controller]")]
    public class CancellationsController : Controller
    {
        private readonly CancellationsContext _context;

        public CancellationsController(CancellationsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cancellation cancellation)
        {
            var cancellationEntry = new Cancellation
            {
                CancellationReason = cancellation.CancellationReason,
                CancellationDate = cancellation.CancellationDate,
                FirstName = cancellation.FirstName,
                LastName = cancellation.LastName,
                EmailAddress = cancellation.EmailAddress,
                PhoneNumber = cancellation.PhoneNumber
            };

            try
            {
                _context.Add(cancellationEntry);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            return Ok(true);
        }
    }
}
