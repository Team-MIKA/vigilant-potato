using System;
using System.Linq;
using Integrator.Features.Settings;
using Integrator.Features.Settings.Models;
using Integrator.Features.Widgets;
using Integrator.Features.Workspaces;
using Integrator.Infrastructure;
using Integrator.Tests.TestHelpers;
using NUnit.Framework;

namespace Integrator.Tests.InfrastructureTests
{
    public class InMemUnitOfWorkTests
    {
        private IUnitOfWork unitOfWork;
        private IntegratorContext context;
        
        [SetUp]
        public void Setup()
        {
            context = TestHelper.MakeTestDbContext();
            
            context.Set<Setting>().Add(new Setting { Id = "1", Name = "test1", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            context.Set<Setting>().Add(new Setting { Id = "2", Name = "test2", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            context.Set<Setting>().Add(new Setting { Id = "3", Name = "test3", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            
            context.SaveChanges();
            
            unitOfWork = new UnitOfWork(context);
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
            Assert.IsNotNull(unitOfWork.Settings);
            Assert.IsNotNull(unitOfWork.Widgets);
            Assert.IsNotNull(unitOfWork.Workspaces);
            Assert.IsInstanceOf(typeof(ISettingsRepository), unitOfWork.Settings);
            Assert.IsInstanceOf(typeof(IWidgetRepository), unitOfWork.Widgets);
            Assert.IsInstanceOf(typeof(IWorkspaceRepository), unitOfWork.Workspaces);
        }

        [Test]
        public void UnitOfWork_ShouldHaveSettingsSeedData()
        {
            // Act
            var settings = unitOfWork.Settings.GetAll().ToList();
            
            // Assert
            Assert.AreEqual(3, settings.Count);
        }
        
        [Test]
        public void UnitOfWork_CanListAll()
        {
            var settings = unitOfWork.Settings.GetAll().ToList();
            Assert.IsNotNull(settings);
            Assert.AreEqual(3, settings.Count);
            Assert.Contains("1", settings.Select(s => s.Id).ToList());
            Assert.Contains("2", settings.Select(s => s.Id).ToList());
            Assert.Contains("3", settings.Select(s => s.Id).ToList());
        }

        [Test]
        public void UnitOfWork_CanGetEntityById()
        {
            var setting = unitOfWork.Settings.GetById("1");
            Assert.IsNotNull(setting);
        }
        
        [Test]
        public void UnitOfWork_CanInsert()
        {
            // Arrange
            unitOfWork.Settings.Insert(new Setting
            {
                Id = "newsetting"
            });
            
            // Act
            unitOfWork.Complete();
            
            // Assert
            Assert.AreEqual(4, unitOfWork.Settings.GetAll().Count());
        }
        
        [Test]
        public void UnitOfWork_CanDelete()
        {
            // Arrange
            var settingToDelete = unitOfWork.Settings.GetById("1");
            
            // Act
            unitOfWork.Settings.Delete(settingToDelete);
            unitOfWork.Complete();
            var deletedSetting = unitOfWork.Settings.GetById("1");
            
            // Assert
            Assert.AreEqual(2, unitOfWork.Settings.GetAll().Count());
            Assert.IsNull(deletedSetting);
        }
        
        [Test]
        public void UnitOfWork_CanDeleteById()
        {
            // Arrange
            unitOfWork.Settings.Delete("1");

            // Act
            unitOfWork.Complete();
            var deletedSetting = unitOfWork.Settings.GetById("1");
            
            // Assert
            Assert.AreEqual(2, unitOfWork.Settings.GetAll().Count());
            Assert.IsNull(deletedSetting);
        }
        
        [Test]
        public void UnitOfWork_CanUpdateEntity()
        {
            // Arrange
            var settingToUpdate = unitOfWork.Settings.GetById("1");
            settingToUpdate.Name = "NewName";
            // Act
            unitOfWork.Settings.Update(settingToUpdate);
            unitOfWork.Complete();
            var updatedEntity = unitOfWork.Settings.GetById("1");
            
            // Assert
            Assert.AreEqual(3, unitOfWork.Settings.GetAll().Count());
            Assert.IsNotNull(updatedEntity);
            Assert.AreEqual("NewName", updatedEntity.Name);
        }
    }
}