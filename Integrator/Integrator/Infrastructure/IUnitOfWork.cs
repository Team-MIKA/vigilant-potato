using System;
using Integrator.Features.Settings;
using Integrator.Features.Widgets;
using Integrator.Features.Workspaces;

namespace Integrator.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ISettingsRepository Settings { get;  }
        IWorkspaceRepository Workspaces { get;  }

        IWidgetRepository Widgets { get; }
        int Complete();
    }
}