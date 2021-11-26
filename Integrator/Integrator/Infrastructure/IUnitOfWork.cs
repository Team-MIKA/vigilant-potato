﻿using System;
using Integrator.Features.Settings;
using Integrator.Features.Workspace;

namespace Integrator.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ISettingsRepository Settings { get;  }
        IWorkspaceRepository Workspace { get;  }
        int Complete();
    }
}