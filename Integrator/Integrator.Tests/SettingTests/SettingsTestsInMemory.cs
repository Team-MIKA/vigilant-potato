using System;
using System.Linq;
using Integrator.Features.Settings;
using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;
using Integrator.Tests.TestHelpers;
using NUnit.Framework;

namespace Integrator.Tests.SettingTests
{
    public class SettingsTestInMemory
    {
        private IntegratorContext context;
        
        [SetUp]
        public void Setup()
        {
            context = TestHelper.MakeTestDbContext();
            
            context.Set<Setting>().Add(new Setting { Id = "1", Name = "FPS_MAX", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            context.Set<Setting>().Add(new Setting { Id = "2", Name = "Graphics", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            context.Set<Setting>().Add(new Setting { Id = "3", Name = "Chat", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            
            context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public void Remove_SettingsObjectPassed_ProperMethodCalled_InMemoryDatabase()
        {
            var test = context.Settings.ToList();
            context.Set<Setting>().Remove(context.Set<Setting>().Find("2"));
            context.SaveChanges();
            var settings = context.Set<Setting>();
            Assert.AreEqual(2, settings.Count());
        }
        
        [Test]
        public void Get_SettingsObjectPassed_ProperMethodCalled_InMemoryDatabase()
        {
            var sut = new GenericRepository<Setting>(context);
            //Act
            var settings = sut.GetAll();

            //Assert
            Assert.AreEqual(3, settings.Count());
        }
        
        [Test]
        public void Test_ProperCall_XD()
        {
            // Arrange
            const string result = "Graphics";
            var settingsRepository = new SettingsRepository(context);
            
            //Act
            var setting = settingsRepository.GetById("2");

            //Assert
            Assert.AreEqual(result, setting.Name);
        }
    }
}