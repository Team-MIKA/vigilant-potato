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
        public virtual DbSet<Workspace> Workspaces { get; set; }
        public virtual DbSet<Widget> Widgets { get; set; }
        public virtual DbSet<WorkspaceWidget> WorkspaceWidgets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder)

            modelBuilder.Entity<Workspace>(entity => 
            { 
                entity.Property(e=>e.Id).HasMaxLength(128);
                entity.Property(e=>e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Widget>(entity => 
            { 
                entity.Property(e=>e.Id).HasMaxLength(128);
                entity.Property(e=>e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<WorkspaceWidget>(entity => 
            { 
                entity.Property(e=>e.Id).HasMaxLength(128);
                entity.Property(e=>e.Id).ValueGeneratedOnAdd();
            });
        }

    }
}