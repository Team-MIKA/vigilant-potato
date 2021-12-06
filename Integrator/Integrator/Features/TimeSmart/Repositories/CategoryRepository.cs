using Integrator.Features.TimeSmart.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.TimeSmart.Repositories
{
    public class CategoryRepository : GenericRepository<RegistrationCategory>, ICategoryRepository
    {
        public CategoryRepository(IntegratorContext context) : base(context)
        {
        }
    }
}