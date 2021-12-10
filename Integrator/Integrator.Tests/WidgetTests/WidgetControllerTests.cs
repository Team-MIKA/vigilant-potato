using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Integrator.Features.Widgets;
using Integrator.Features.Widgets.DTO;
using Integrator.Infrastructure;
using Integrator.Tests.TestHelpers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Integrator.Tests.WidgetTests
{
    public class WidgetControllerTests
    {
        private IUnitOfWork unitOfWork;
        private IWidgetService widgetService;
        private IntegratorContext context;
        private WidgetController controller;
        
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

            controller = new WidgetController(widgetService);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }
        
        [Test]
        public void WidgetController_ListAllWidgets()
        {
            var widgetsResult = controller.ListWidgets();
            
            var okResult = widgetsResult as OkObjectResult;
            
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            var widgets = okResult.Value as IEnumerable<WidgetDto>;
            Assert.NotNull(widgets);
            Assert.AreEqual(3, widgets.Count());
        }
        
        [Test]
        public void WidgetController_CanCreateNewWidgets()
        {
            var widgetToAdd = new WidgetDto
            {
                Title = "NewWidget"
            };

            var response = controller.CreateWidget(widgetToAdd);
            
            var okResult = response as OkObjectResult;
            
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            var widgetId = okResult.Value as string;
            Assert.NotNull(widgetId);
            
            Assert.AreEqual(4, widgetService.ListWidgets().ToList().Count);
        }
        
        [Test]
        public void WidgetController_List404OnInvalidModel()
        {
            controller.ModelState.AddModelError("modelIsInvalid", "modelIsInvalid");
            
            var exception = Assert.Throws<Exception>(() =>
            {
                var widgets = controller.ListWidgets();
            });
            
            Assert.AreEqual("Error retrieving a list of widgets", exception.Message);
        }
        
        [Test]
        public void WidgetController_Create404OnInvalidModel()
        {
            Assert.Ignore();
            var widgetToAdd = new WidgetDto();

            controller.ModelState.AddModelError("modelIsInvalid", "modelIsInvalid");
            
            var exception = Assert.Throws<Exception>(() =>
            {
                controller.CreateWidget(widgetToAdd);
            });
            
            Assert.AreEqual("Error creating a widget", exception.Message);
        }
        
        [Test]
        public void WidgetController_Delete404OnInvalidModel()
        {
            var widgetId = "1";

            controller.ModelState.AddModelError("modelIsInvalid", "modelIsInvalid");
            
            var exception = Assert.Throws<Exception>(() =>
            {
                controller.DeleteWidget(widgetId);
            });
            
            Assert.AreEqual("Error deleting widget: " + widgetId, exception.Message);
        }
    }
}