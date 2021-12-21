using System.Linq;
using AutoMapper;
using Integrator.Features.Widgets;
using Integrator.Features.Widgets.DTO;
using Integrator.Infrastructure;
using Integrator.Tests.TestHelpers;
using NUnit.Framework;

namespace Integrator.Tests.WidgetTests
{
    public class WidgetTests
    {
        private IUnitOfWork unitOfWork;
        private IWidgetService widgetService;
        private IntegratorContext context;
        
        // NOTE TO DEV: 
        [SetUp]
        public void Setup()
        {
            context = TestHelper.MakeTestDbContext();
            
            unitOfWork = new UnitOfWork(context);
            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfiles());
            });
            
            widgetService = new WidgetService(unitOfWork, new Mapper(mappingConfig));
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public void WidgetService_CanListAllWidgets()
        {
            var widgets = widgetService.ListWidgets();
            Assert.IsNotNull(widgets);
            Assert.AreEqual(3, widgets.ToList().Count);
        }
        
        [Test]
        public void WidgetService_CanCreateWidget()
        {
            Assert.AreEqual(3, context.Widgets.ToList().Count);
            
            var newWidget = new WidgetDto
            {
                Title = "NewWidget"
            };

            var id = widgetService.CreateWidget(newWidget);
            Assert.IsNotNull(id);
            Assert.AreEqual(4, context.Widgets.ToList().Count);
        }
        
        [Test]
        public void WidgetService_CanDeleteWidget()
        {
            var widgets = widgetService.ListWidgets().ToList();

            var idOfDeleteWidget = widgetService.DeleteWidget(widgets.First().Id);
            Assert.IsNotNull(idOfDeleteWidget);
            Assert.AreEqual(2, context.Widgets.ToList().Count);
        }
    }
}