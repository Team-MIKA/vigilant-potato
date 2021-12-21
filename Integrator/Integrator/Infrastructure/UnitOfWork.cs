using Integrator.Features.Settings;
using Integrator.Features.Widgets;
using Integrator.Features.Workspaces;

namespace Integrator.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntegratorContext context;

        public UnitOfWork(IntegratorContext context)
        {
            this.context = context;
            Settings = new SettingsRepository(this.context);
            Workspaces = new WorkspaceRepository(this.context);
            Widgets = new WidgetRepository(this.context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public ISettingsRepository Settings { get; private set; }
        public IWorkspaceRepository Workspaces { get; private set; }

        public IWidgetRepository Widgets { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}