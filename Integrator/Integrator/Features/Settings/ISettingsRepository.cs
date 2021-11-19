using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Settings
{
    public interface ISettingsRepository : IGenericRepository<Setting>
    {
        void Test();
    }
}