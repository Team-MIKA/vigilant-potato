using Integrator.Features.Settings;

namespace Integrator.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntegratorContext _context;

        public UnitOfWork(IntegratorContext context)
        {
            _context = context;
            Settings = new SettingsRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public ISettingsRepository Settings { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}