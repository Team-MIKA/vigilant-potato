using Integrator.Features.Settings;
using Integrator.Features.TimeSmart;
using Integrator.Features.Widgets;
using Integrator.Features.Workspaces;

namespace Integrator.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntegratorContext _context;

        public UnitOfWork(IntegratorContext context)
        {
            _context = context;
            Settings = new SettingsRepository(_context);
            Workspaces = new WorkspaceRepository(_context);
            Widgets = new WidgetRepository(_context);
            Categories = new CategoryRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ISettingsRepository Settings { get; private set; }
        public IWorkspaceRepository Workspaces { get; private set; }

        public IWidgetRepository Widgets { get; private set; }

        public ISettingsRepository Settings { get; }
        public ICategoryRepository Categories { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}