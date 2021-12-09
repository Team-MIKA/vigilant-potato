using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Integrator.Features.Widgets.DTO;
using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces;
using Integrator.Features.Workspaces.DTO;
using Integrator.Features.Workspaces.Models;
using Integrator.Infrastructure;
using Integrator.Tests.TestHelpers;
using NUnit.Framework;

namespace Integrator.Tests.WorkspaceTests
{
    public class WorkspaceTests
    {
        private IUnitOfWork unitOfWork;
        private IWorkspaceService workspaceService;
        private IntegratorContext context;
        
        [SetUp]
        public void Setup()
        {
            context = TestHelper.MakeTestDbContext();
            unitOfWork = new UnitOfWork(context);
            workspaceService = new WorkspaceService(unitOfWork, new Mapper(TestHelper.GetMapperConfig()));
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public void WorkspaceService_CanCreateWorkspace()
        {
            Assert.AreEqual(0, context.Workspaces.ToList().Count);
            
            var newWorkspace = new WorkspaceDto
            {
                Title = "NewWorkspace"
            };

            var id = workspaceService.CreateWorkspace(newWorkspace);
            Assert.IsNotNull(id);
            Assert.AreEqual(1, context.Workspaces.ToList().Count);
        }
        
        [Test]
        public void WorkspaceService_CanGetWorkspaceById()
        {
            Assert.AreEqual(0, context.Workspaces.ToList().Count);
            var newWorkspace = new Workspace
            {
                Title = "NewWorkspace",
                Id = "testId"
            };
            context.Set<Workspace>().Add(newWorkspace);
            context.SaveChanges();
            
            var result = workspaceService.GetById("testId");
            Assert.AreEqual(newWorkspace.Id, result.Id);
        }
        
        [Test]
        public void WorkspaceService_CanDeleteWorkspace()
        {
            Assert.AreEqual(0, context.Workspaces.ToList().Count);
            var newWorkspace = new Workspace
            {
                Title = "NewWorkspace",
                Id = "testId"
            };
            context.Set<Workspace>().Add(newWorkspace);
            context.SaveChanges();
            Assert.AreEqual(1, context.Workspaces.ToList().Count);
            
            
            var result = workspaceService.DeleteWorkspace("testId");
            Assert.AreEqual(newWorkspace.Id, result);
        }
        
        [Test]
        public void WorkspaceService_CanListWorkspace()
        {
            Assert.AreEqual(0, context.Workspaces.ToList().Count);
            var newWorkspace = new Workspace
            {
                Title = "NewWorkspace",
                Id = "testId"
            };
            context.Set<Workspace>().Add(newWorkspace);
            context.SaveChanges();
            var result = workspaceService.ListWorkspaces();
            Assert.AreEqual(1, result.Count());
        }
        
        [Test]
        public void WorkspaceService_CanAddWidgetToWorkspace()
        {
            Assert.AreEqual(0, context.Workspaces.ToList().Count);
            var newWorkspace = new Workspace
            {
                Title = "NewWorkspace",
                Id = "workspaceTestId"
            };
            
            var newWidget = new WidgetDto
            {
                Title = "NewWidget"
            };
            context.Set<Workspace>().Add(newWorkspace);
            context.SaveChanges();

            
            Assert.AreEqual(3, context.Widgets.ToList().Count);
            var result = workspaceService.AddWidgetToWorkspace(newWidget, newWorkspace.Id);
            var widget = context.WorkspaceWidgets.Find(result);
            Assert.NotNull(widget);
            Assert.AreEqual(newWorkspace.Id,widget.WorkspaceId);
        }
        
        [Test]
        public void WorkspaceService_CanRemoveWidgetFromWorkspace()
        {
            Assert.AreEqual(0, context.Workspaces.ToList().Count);
            var newWidget = new Widget
            {
                Title = "NewWidget",
                Id = "widgetTestId"
            };
            var newWorkspace = new Workspace
            {
                Title = "NewWorkspace",
                Id = "workspaceTestId",
                Widgets = new List<WorkspaceWidget>
                {
                    new WorkspaceWidget
                    {
                        Id = "ididid",
                        Widget = newWidget,
                        WorkspaceId = "workspaceTestId"
                    }
                }
            };
            
            context.Set<Workspace>().Add(newWorkspace);
            context.SaveChanges();
            Assert.AreEqual(4, context.Widgets.ToList().Count);
            Assert.AreEqual(1, context.Workspaces.ToList().Count);


            var result = workspaceService.RemoveWidgetFromWorkspace("ididid");
            var widget = context.WorkspaceWidgets.FirstOrDefault(n => n.WidgetId == result);
            Assert.Null(widget);
        }
    }
}