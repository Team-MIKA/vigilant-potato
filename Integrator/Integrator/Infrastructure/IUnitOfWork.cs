using System;
using Integrator.Features.Settings;
using Integrator.Features.TimeSmart;

namespace Integrator.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ISettingsRepository Settings { get;  }
        ICategoryRepository Categories { get; }
        int Complete();
    }
}