using System;
using System.Collections.Generic;
using System.Linq;
using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;
using Integrator.Tests.TestHelpers;
using Moq;
using NUnit.Framework;

namespace Integrator.Tests.Infrastructure
{
    public class InfrastructureTests
    {
        private Mock<IntegratorContext> _mockContext;
        private GenericRepository<Setting> _genericRepo;

        [SetUp]
        public void Setup()
        {

        }
    
        [Test]
        public void Test_ShouldTestTheTest()
        {
            
            _mockContext = new Mock<IntegratorContext>();
            var settingsDbSetMock = DbContextHelper.MakeMockDbSet(new List<Setting>
            {
                new()
                {
                    Created = DateTime.Now,
                    Id = "123",
                    Modified = DateTime.Now,
                    Name = "Test"
                }
            });
            
            _mockContext.Setup(c => c.Set<Setting>()).Returns(settingsDbSetMock.Object);

            _genericRepo = new GenericRepository<Setting>(_mockContext.Object);
            var settings = _genericRepo.ListAll();
            Assert.AreEqual(1, settings.Count());
            
            _genericRepo.Insert(new(){
                Created = DateTime.Now,
                Id = "new",
                Modified = DateTime.Now,
                Name = "Test2"
            });
            // TODO: use UnitOfWork in this test...
            // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
            _mockContext.Object.SaveChanges();
            
            Assert.AreEqual(2, settings.Count());
        }
    }
}