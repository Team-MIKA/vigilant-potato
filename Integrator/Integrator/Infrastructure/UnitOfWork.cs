using Integrator.Features.Settings;
using Integrator.Features.Workspace;

namespace Integrator.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntegratorContext _context;

        public UnitOfWork(IntegratorContext context)
        {
            _context = context;
            Settings = new SettingsRepository(_context);
            Workspace = new WorkspaceRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ISettingsRepository Settings { get; private set; }
        public IWorkspaceRepository Workspace { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}