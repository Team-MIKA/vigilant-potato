using System.Collections.Generic;
using System.Linq;
using Integrator.Features.TimeSmart.DTO;
using Integrator.Features.TimeSmart.Models;
using Integrator.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Integrator.Features.TimeSmart.Repositories
{
    public class RegistrationRepository : GenericRepository<Registration>, IRegistrationRepository
    {
        public RegistrationRepository(IntegratorContext context) : base(context)
        {
        }

        public IEnumerable<Registration> ListAllByOrderId(string orderId)
        {
            if (orderId == "null")
            {
                return _context.Registrations
                    .Include(reg => reg.RegistrationCategory)
                    .ToList();
            }
            
            var registrationsForOrderId = _context.Registrations
                .Include(reg => reg.RegistrationCategory)
                .Where(reg => reg.OrderId.Equals(orderId))
                .ToList();
            

            return registrationsForOrderId;
        }
    }
}