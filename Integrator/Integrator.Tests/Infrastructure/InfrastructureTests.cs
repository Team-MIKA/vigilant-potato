using System;
using System.Collections.Generic;
using System.Linq;
using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;
using Integrator.Tests.TestHelpers;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Integrator.Tests.Infrastructure
{
    public class InfrastructureTests
    {
        private Mock<IntegratorContext> _mockContext;
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void Setup()
        {

        }
    
        [Test]
        public void GenericRepository_ShouldAddToDbSet()
        {
            // Arrange
            var setting = new Setting();

            _mockContext = new Mock<IntegratorContext>();
            var dbSetMock = new Mock<DbSet<Setting>>();
            _mockContext.Setup(x => x.Set<Setting>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<Setting>()));

            // Act
            
            _unitOfWork = new UnitOfWork(_mockContext.Object);
            _unitOfWork.Settings.Insert(setting);

            //Assert
            _mockContext.Verify(x => x.Set<Setting>());
            dbSetMock.Verify(x => x.Add(It.Is<Setting>(y => y == setting)));
        }
        
        [Test]
        public void ListAll_SettingObjectPassed_ShouldReturnTestList()
        {
            // Arrange
            var setting = new Setting() { Id = "test" };
            var seedData = new List<Setting>() { setting };

            var dbSetMock = DbContextHelper.MakeMockDbSet(seedData);

            var context = new Mock<IntegratorContext>();
            context.Setup(x => x.Set<Setting>()).Returns(dbSetMock.Object);

            // Act
            _unitOfWork = new UnitOfWork(context.Object);
            var result = _unitOfWork.Settings.ListAll();

            // Assert
            Assert.AreEqual(seedData, result.ToList());
        }
        [Test]
        public void Remove_SettingObjectPassed_ShouldCallDelete()
        {
            // Arrange
            var setting = new Setting();

            var context = new Mock<IntegratorContext>();
            var dbSetMock = new Mock<DbSet<Setting>>();
            context.Setup(x => x.Set<Setting>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Remove(It.IsAny<Setting>()));

            // Act
            _unitOfWork = new UnitOfWork(context.Object);
            _unitOfWork.Settings.Delete(setting);

            //Assert
            context.Verify(x => x.Set<Setting>());
            dbSetMock.Verify(x => x.Remove(It.Is<Setting>(y => y == setting)));
        }
        
        [Test]
        public void Add_SettingsObjectPassed_ShouldAddSetting()
        {
            // Arrange
            var setting = new Setting();
            
            var context = new Mock<IntegratorContext>();
            var dbSetMock = new Mock<DbSet<Setting>>();
            context.Setup(x => x.Set<Setting>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<Setting>())).Returns(() => null);
            
            // Act
            _unitOfWork = new UnitOfWork(context.Object);
            _unitOfWork.Settings.Insert(setting);
            
            //Assert
            context.Verify(x => x.Set<Setting>());
            dbSetMock.Verify(x => x.Add(It.Is<Setting>(y => y == setting)));
        }
        
        [Test]
        public void Get_SettingsObjectPassed_GetsCorrectSetting()
        {
            // Arrange
            var setting = new Setting
            {
                Id = "test"
            };

            var context = new Mock<IntegratorContext>();
            var dbSetMock = new Mock<DbSet<Setting>>();

            context.Setup(x => x.Set<Setting>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<string>())).Returns(setting);

            // Act
            _unitOfWork = new UnitOfWork(context.Object);
            _unitOfWork.Settings.GetById("test");

            // Assert
            context.Verify(x => x.Set<Setting>());
            dbSetMock.Verify(x => x.Find(It.IsAny<string>()));
        }
    }
}