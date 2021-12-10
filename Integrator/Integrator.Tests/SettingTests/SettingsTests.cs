using System.Collections.Generic;
using System.Linq;
using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Integrator.Tests.SettingTests
{
    public class SettingsTests
    {
        [SetUp]
        public void Setup()
        {
        }
    
        [Test]
        public void Test_ProperCall()
        {
            // Arrange
            var testObject = new Setting();

            var context = new Mock<IntegratorContext>();
            var dbSetMock = new Mock<DbSet<Setting>>();
            context.Setup(x => x.Set<Setting>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<Setting>()));

            // Act
            var repository = new GenericRepository<Setting>(context.Object);
            repository.Insert(testObject);

            //Assert
            context.Verify(x => x.Set<Setting>());
            dbSetMock.Verify(x => x.Add(It.Is<Setting>(y => y == testObject)));
        }
        
        [Test]
        public void ListAll_SettingObjectPassed_ProperMethodCalled()
        {
            // Arrange
            var testObject = new Setting() { Id = "asd" };
            var testList = new List<Setting>() { testObject };

            var dbSetMock = new Mock<DbSet<Setting>>();
            dbSetMock.As<IQueryable<Setting>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Setting>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Setting>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Setting>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<IntegratorContext>();
            context.Setup(x => x.Set<Setting>()).Returns(dbSetMock.Object);

            // Act
            var repository = new GenericRepository<Setting>(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.AreEqual(testList, result.ToList());
        }
        [Test]
        public void Remove_SettingObjectPassed_ProperMethodCalled()
        {
            // Arrange
            var testObject = new Setting();

            var context = new Mock<IntegratorContext>();
            var dbSetMock = new Mock<DbSet<Setting>>();
            context.Setup(x => x.Set<Setting>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Remove(It.IsAny<Setting>())).Returns(() => null);

            // Act
            var repository = new GenericRepository<Setting>(context.Object);
            repository.Delete(testObject);

            //Assert
            context.Verify(x => x.Set<Setting>());
            dbSetMock.Verify(x => x.Remove(It.Is<Setting>(y => y == testObject)));
        }
        
        [Test]
        public void Add_SettingsObjectPassed_ProperMethodCalled()
        {
            // Arrange
            var testObject = new Setting();
            
            var context = new Mock<IntegratorContext>();
            var dbSetMock = new Mock<DbSet<Setting>>();
            context.Setup(x => x.Set<Setting>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<Setting>())).Returns(() => null);
            
            // Act
            var repository = new GenericRepository<Setting>(context.Object);
            repository.Insert(testObject);
            
            //Assert
            context.Verify(x => x.Set<Setting>());
            dbSetMock.Verify(x => x.Add(It.Is<Setting>(y => y == testObject)));
        }
        
        [Test]
        public void Get_SettingsObjectPassed_ProperMethodCalled()
        {
            // Arrange
            var testObject = new Setting();

            var context = new Mock<IntegratorContext>();
            var dbSetMock = new Mock<DbSet<Setting>>();

            context.Setup(x => x.Set<Setting>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<string>())).Returns(testObject);

            // Act
            var repository = new GenericRepository<Setting>(context.Object);
            repository.GetById("");

            // Assert
            context.Verify(x => x.Set<Setting>());
            dbSetMock.Verify(x => x.Find(It.IsAny<string>()));
        }
    }
}