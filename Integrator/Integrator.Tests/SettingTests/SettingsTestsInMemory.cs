using System;
using System.Linq;
using Integrator.Features.Settings;
using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;
using Integrator.Tests.TestHelpers;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Integrator.Tests.Settings
{
    public class SettingsTestInMemory
    {
        private IntegratorContext _context;
        
        [SetUp]
        public void Setup()
        {
            _context = TestHelper.MakeTestDbContext();
            
            _context.Set<Setting>().Add(new Setting { Id = "1", Name = "FPS_MAX", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            _context.Set<Setting>().Add(new Setting { Id = "2", Name = "Graphics", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            _context.Set<Setting>().Add(new Setting { Id = "3", Name = "Chat", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public void Remove_SettingsObjectPassed_ProperMethodCalled_InMemoryDatabase()
        {
            var test = _context.Settings.ToList();
            _context.Set<Setting>().Remove(_context.Set<Setting>().Find("2"));
            _context.SaveChanges();
            var settings = _context.Set<Setting>();
            Assert.AreEqual(2, settings.Count());
        }
        
        [Test]
        public void Get_SettingsObjectPassed_ProperMethodCalled_InMemoryDatabase()
        {
            var sut = new GenericRepository<Setting>(_context);
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
            var settingsRepository = new SettingsRepository(_context);
            
            //Act
            var setting = settingsRepository.GetById("2");

            //Assert
            Assert.AreEqual(result, setting.Name);
        }
    }
}