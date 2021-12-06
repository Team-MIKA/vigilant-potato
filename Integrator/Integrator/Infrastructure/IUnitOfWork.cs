using System;
using Integrator.Features.Settings;
using Integrator.Features.TimeSmart;
using Integrator.Features.TimeSmart.Repositories;
using Integrator.Features.Widgets;
using Integrator.Features.Workspaces;

namespace Integrator.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ISettingsRepository Settings { get;  }
        ICategoryRepository Categories { get; }
        IRegistrationRepository Registrations { get; }
        IWorkspaceRepository Workspaces { get;  }

        IWidgetRepository Widgets { get; }
        int Complete();
    }
}