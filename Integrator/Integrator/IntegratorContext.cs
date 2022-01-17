using System.Collections.Generic;
using Integrator.Features.Settings.Models;
using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces.Models;
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

        Widget[] InitialWidgets =
        {
            new Widget
            {
                Id = "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353",
                Title = "Timesmart",
                Type = Integration.TimeSmart,
                Url = "http://api.timesmart.tech:5000/TimeSmart/InsertRegistration",
                Options = new []{new Option{Key = "username", Value = "admin"}, new Option{Key = "password", Value = "VeryGoodPassword"}}
                
            },
            new Widget
            {
                Id = "78iu214b-2067-47fc-9eaa-d3ac4b4f0352",
                Title = "Timesmart Registrations",
                Type = Integration.TimeSmartRegistrations,
                Url = "http://api.timesmart.tech:5000/TimeSmart/GetCategories",
                Options = new []{new Option{Key = "username", Value = "admin"}, new Option{Key = "password", Value = "VeryGoodPassword"}}


            },
            new Widget
            {
                Id = "hy67214b-2067-47fc-9eaa-d3ac4b4f0351",
                Title = "SAP List",
                Type = Integration.Sap,
                Url = "http://app.timesmart.tech/api/sap",
                Options = new []{new Option{Key = "api-key", Value = "a4db08b7-5729-4ba9-8c08-f2df493465a"}}

            }
        };
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Workspace>(entity => 
            {
                entity.Property(e=>e.Id).HasMaxLength(128);
                entity.Property(e=>e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Widget>(entity =>
            {
                entity.HasData(InitialWidgets);
                entity.Property(e=>e.Id).HasMaxLength(128);
                entity.Property(e=>e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<WorkspaceWidget>(entity => 
            {
                entity.Property(e=>e.Id).HasMaxLength(128);
                entity.Property(e=>e.Id).ValueGeneratedOnAdd();
                entity.Property(e=>e.WorkspaceId).HasMaxLength(128);
                entity.Property(e=>e.WidgetId).HasMaxLength(128);
                entity.HasOne(e => e.Workspace)
                    .WithMany(e => e.Widgets)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}