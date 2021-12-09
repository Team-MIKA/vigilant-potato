using System;
using System.Linq;
using Integrator.Features.Settings;
using Integrator.Features.Settings.Models;
using Integrator.Features.Widgets;
using Integrator.Features.Workspaces;
using Integrator.Infrastructure;
using Integrator.Tests.TestHelpers;
using NUnit.Framework;

namespace Integrator.Tests.Infrastructure
{
    public class InMemUnitOfWorkTests
    {
        private IUnitOfWork _unitOfWork;
        private IntegratorContext _context;
        
        [SetUp]
        public void Setup()
        {
            _context = TestHelper.MakeTestDbContext();
            
            _context.Set<Setting>().Add(new Setting { Id = "1", Name = "test1", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            _context.Set<Setting>().Add(new Setting { Id = "2", Name = "test2", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            _context.Set<Setting>().Add(new Setting { Id = "3", Name = "test3", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            
            _context.SaveChanges();
            
            _unitOfWork = new UnitOfWork(_context);
        }

        [TearDown]
        public void TearDown()
        {
            using var context = TestHelper.MakeTestDbContext();
            context.Database.EnsureDeleted();
        }
        
        [Test]
        public void UnitOfWork_ContextPassed_HaveRepositories()
        {
            Assert.IsNotNull(_unitOfWork.Settings);
            Assert.IsNotNull(_unitOfWork.Widgets);
            Assert.IsNotNull(_unitOfWork.Workspaces);
            Assert.IsInstanceOf(typeof(ISettingsRepository), _unitOfWork.Settings);
            Assert.IsInstanceOf(typeof(IWidgetRepository), _unitOfWork.Widgets);
            Assert.IsInstanceOf(typeof(IWorkspaceRepository), _unitOfWork.Workspaces);
        }

        [Test]
        public void UnitOfWork_ShouldHaveSettingsSeedData()
        {
            // Act
            var settings = _unitOfWork.Settings.GetAll().ToList();
            
            // Assert
            Assert.AreEqual(3, settings.Count);
        }
        
        [Test]
        public void UnitOfWork_CanListAll()
        {
            var settings = _unitOfWork.Settings.GetAll().ToList();
            Assert.IsNotNull(settings);
            Assert.AreEqual(3, settings.Count);
            Assert.Contains("1", settings.Select(s => s.Id).ToList());
            Assert.Contains("2", settings.Select(s => s.Id).ToList());
            Assert.Contains("3", settings.Select(s => s.Id).ToList());
        }

        [Test]
        public void UnitOfWork_CanGetEntityById()
        {
            var setting = _unitOfWork.Settings.GetById("1");
            Assert.IsNotNull(setting);
        }
        
        [Test]
        public void UnitOfWork_CanInsert()
        {
            // Arrange
            _unitOfWork.Settings.Insert(new Setting
            {
                Id = "newsetting"
            });
            
            // Act
            _unitOfWork.Complete();
            
            // Assert
            Assert.AreEqual(4, _unitOfWork.Settings.GetAll().Count());
        }
        
        [Test]
        public void UnitOfWork_CanDelete()
        {
            // Arrange
            var settingToDelete = _unitOfWork.Settings.GetById("1");
            
            // Act
            _unitOfWork.Settings.Delete(settingToDelete);
            _unitOfWork.Complete();
            var deletedSetting = _unitOfWork.Settings.GetById("1");
            
            // Assert
            Assert.AreEqual(2, _unitOfWork.Settings.GetAll().Count());
            Assert.IsNull(deletedSetting);
        }
        
        [Test]
        public void UnitOfWork_CanDeleteById()
        {
            // Arrange
            _unitOfWork.Settings.Delete("1");

            // Act
            _unitOfWork.Complete();
            var deletedSetting = _unitOfWork.Settings.GetById("1");
            
            // Assert
            Assert.AreEqual(2, _unitOfWork.Settings.GetAll().Count());
            Assert.IsNull(deletedSetting);
        }
        
        [Test]
        public void UnitOfWork_CanUpdateEntity()
        {
            // Arrange
            var settingToUpdate = _unitOfWork.Settings.GetById("1");
            settingToUpdate.Name = "NewName";
            // Act
            _unitOfWork.Settings.Update(settingToUpdate);
            _unitOfWork.Complete();
            var updatedEntity = _unitOfWork.Settings.GetById("1");
            
            // Assert
            Assert.AreEqual(3, _unitOfWork.Settings.GetAll().Count());
            Assert.IsNotNull(updatedEntity);
            Assert.AreEqual("NewName", updatedEntity.Name);
        }
    }
}