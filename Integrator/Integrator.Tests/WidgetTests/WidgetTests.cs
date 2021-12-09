using System;
using System.Linq;
using AutoMapper;
using Integrator.Features.Settings.Models;
using Integrator.Features.Widgets;
using Integrator.Features.Widgets.DTO;
using Integrator.Features.Widgets.Models;
using Integrator.Infrastructure;
using Integrator.Tests.TestHelpers;
using NUnit.Framework;

namespace Integrator.Tests
{
    public class WidgetTests
    {
        private IUnitOfWork _unitOfWork;
        private IWidgetService _widgetService;
        private IntegratorContext _context;
        
        // NOTE TO DEV: 
        [SetUp]
        public void Setup()
        {
            _context = DbContextHelper.MakeTestDbContext();
            
            _unitOfWork = new UnitOfWork(_context);
            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfiles());
            });
            
            _widgetService = new WidgetService(_unitOfWork, new Mapper(mappingConfig));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public void WidgetService_CanCreateWidget()
        {
            Assert.AreEqual(3, _context.Widgets.ToList().Count);
            
            var newWidget = new WidgetDTO
            {
                Title = "NewWidget"
            };

            var id = _widgetService.CreateWidget(newWidget);
            Assert.IsNotNull(id);
            Assert.AreEqual(4, _context.Widgets.ToList().Count);
        }
    }
}