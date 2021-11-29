using System;
using Integrator.Features.Settings;
using Integrator.Features.Workspaces;

namespace Integrator.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ISettingsRepository Settings { get;  }
        IWorkspaceRepository Workspace { get;  }

        IWorkspaceRepository Widget { get; }
        int Complete();
    }
}