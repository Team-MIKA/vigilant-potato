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

        public new IEnumerable<Registration> ListAll()
        {
            return _context.Registrations
                .Include(reg => reg.RegistrationCategory)
                .ToList();
        }
    }
}