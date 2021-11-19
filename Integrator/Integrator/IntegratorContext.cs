using Integrator.Features.Settings.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrator
{
    public class IntegratorContext : DbContext
    {
        public IntegratorContext(DbContextOptions options) : base(options)
        {
            
        }

        public virtual DbSet<Setting> Settings { get; set; }
    }
}