using Integrator.Features.Settings;
using Integrator.Features.TimeSmart;

namespace Integrator.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntegratorContext _context;

        public UnitOfWork(IntegratorContext context)
        {
            _context = context;
            Settings = new SettingsRepository(_context);
            Categories = new CategoryRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public ISettingsRepository Settings { get; }
        public ICategoryRepository Categories { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}