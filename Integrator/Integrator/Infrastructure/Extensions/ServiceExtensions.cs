﻿using System;
using Integrator.Features.Settings;
using Integrator.Features.TimeSmart.Repositories;
using Integrator.Features.Widgets;
using Integrator.Features.Workspaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Integrator.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ISettingsRepository, SettingsRepository>();
            services.AddTransient<IWorkspaceRepository, WorkspaceRepository>();
            services.AddTransient<IWidgetRepository, WidgetRepository>();
            
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IWorkspaceService, WorkspaceService>();
            services.AddTransient<IWidgetService, WidgetService>();
        }

        public static void ConfigureDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IntegratorContext>(options => options
                .UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 6, 5)))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );
        }
        
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "Default",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }
    }
}
