using System.Collections.Generic;
using Integrator.Features.Settings.Models;
using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
                Url = "https://api.aaen.cloud/TimeSmart/InsertRegistration"
            },
            new Widget
            {
                Id = "78iu214b-2067-47fc-9eaa-d3ac4b4f0352",
                Title = "Timesmart Registrations",
                Type = Integration.TimeSmartRegistrations,
                Url = "https://api.aaen.cloud/TimeSmart/GetCategories",


            },
            new Widget
            {
                Id = "hy67214b-2067-47fc-9eaa-d3ac4b4f0351",
                Title = "SAP List",
                Type = Integration.Sap,
                Url = "https://app.aaen.cloud/api/sap"

            }
        };

        public Option[] InitialOptions =
        {
            new Option{Id="1", Key = "username", Value = "admin", WidgetId = "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353"},
            new Option{Id="2", Key = "password", Value = "VeryGoodPassword", WidgetId = "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353"},
            
            
            new Option{Id ="3", Key = "username", Value = "admin", WidgetId = "78iu214b-2067-47fc-9eaa-d3ac4b4f0352"},
            new Option{Id ="4", Key = "password", Value = "VeryGoodPassword",WidgetId = "78iu214b-2067-47fc-9eaa-d3ac4b4f0352"},
            
            new Option{Id ="5", Key = "api-key", Value = "a4db08b7-5729-4ba9-8c08-f2df493465a", WidgetId = "hy67214b-2067-47fc-9eaa-d3ac4b4f0351"}
            
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
            
            modelBuilder.Entity<Option>(o =>
            {
                o.HasData(InitialOptions);
                o.Property(e=>e.Id).HasMaxLength(128);
                o.Property(e=>e.Id).ValueGeneratedOnAdd();
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