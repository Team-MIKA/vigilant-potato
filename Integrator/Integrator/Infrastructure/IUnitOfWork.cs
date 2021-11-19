using System;
using Integrator.Features.Settings;

namespace Integrator.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ISettingsRepository Settings { get;  }
        int Complete();
    }
}