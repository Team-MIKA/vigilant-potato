using Integrator.Features.Settings.Models;
using Integrator.Features.TimeSmart.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrator
{
    public class IntegratorContext : DbContext
    {
        public IntegratorContext(DbContextOptions options) : base(options)
        {
            
        }

        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<RegistrationCategory> RegistrationCategories { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
    }
}