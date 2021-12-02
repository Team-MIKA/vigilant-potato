using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Settings
{
    public class SettingsRepository : GenericRepository<Setting>, ISettingsRepository
    {
        public SettingsRepository(IntegratorContext context) : base(context)
        {
        }

        public void Test()
        {
            throw new System.NotImplementedException();
        }
    }
}