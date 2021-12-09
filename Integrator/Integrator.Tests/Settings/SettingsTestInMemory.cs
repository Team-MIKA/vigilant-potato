using System;
using System.Linq;
using Integrator.Features.Settings;
using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Integrator.Tests.Settings
{
    public class SettingsTestInMemory
    {
        private DbContextOptions<IntegratorContext> Options { get; set; }
        
        [SetUp]
        public void Setup()
        {
            Options = new DbContextOptionsBuilder<IntegratorContext>()
                .UseInMemoryDatabase(databaseName: "IntegratorDatabase")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new IntegratorContext(Options))
            {
                context.Set<Setting>().Add(new Setting { Id = "1", Name = "FPS_MAX", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
                context.Set<Setting>().Add(new Setting { Id = "2", Name = "Graphics", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
                context.Set<Setting>().Add(new Setting { Id = "3", Name = "Chat", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
                context.SaveChanges();
            }
        }

        [TearDown]
        public void Tear_Down()
        {
            using var context = new IntegratorContext(Options);
            context.Database.EnsureDeleted();
        }

        [Test]
        public void Remove_SettingsObjectPassed_ProperMethodCalled_InMemoryDatabase()
        {
            using var context = new IntegratorContext(Options);
            context.Set<Setting>().Remove(context.Set<Setting>().Find("2"));
            context.SaveChanges();
            var settings = context.Set<Setting>();
            Assert.AreEqual(2, settings.Count());
        }
        
        [Test]
        public void Get_SettingsObjectPassed_ProperMethodCalled_InMemoryDatabase()
        {
            using (var context = new IntegratorContext(Options))
            {
                var sut = new GenericRepository<Setting>(context);
                //Act
                var settings = sut.ListAll();

                //Assert
                Assert.AreEqual(3, settings.Count());
            }
        }
        
        [Test]
        public void Test_ProperCall_XD()
        {
            // Arrange
            var result = "Graphics";
            using var context = new IntegratorContext(Options);
            var settingsRepository = new SettingsRepository(context);
            
            //Act
            var setting = settingsRepository.GetById("2");

            //Assert
            Assert.AreEqual(result, setting.Name);
        }
    }
}