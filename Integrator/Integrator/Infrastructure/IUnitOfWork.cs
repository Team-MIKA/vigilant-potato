using System;
using Integrator.Features.Settings;
using Integrator.Features.TimeSmart;

namespace Integrator.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ISettingsRepository Settings { get;  }
        ICategoryRepository Categories { get; }
        IWorkspaceRepository Workspaces { get;  }

        IWidgetRepository Widgets { get; }
        int Complete();
    }
}