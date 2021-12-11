using System.Collections.Generic;
using Integrator.Features.TimeSmart.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.TimeSmart.Repositories
{
    public interface IRegistrationRepository : IGenericRepository<Registration>
    {
        public IEnumerable<Registration> ListAllByOrderId(string orderId);
    }
}