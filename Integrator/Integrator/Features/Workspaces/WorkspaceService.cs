using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Integrator.Features.Widgets.DTO;
using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces.DTO;
using Integrator.Features.Workspaces.Models;
using Integrator.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Integrator.Features.Workspaces
{
    public class WorkspaceService : IWorkspaceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WorkspaceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public WorkspaceDto GetById(string id)
        {
            var workspace = unitOfWork.Workspaces.GetWorkspaceById(id);
            var workspaceDto = mapper.Map<WorkspaceDto>(workspace);
            return workspaceDto;
        }

        public string AddWidgetToWorkspace(WidgetDto widgetDto, string id)
        {
            var widget = mapper.Map<Widget>(widgetDto);
            var createdId = unitOfWork.Workspaces.AddWidgetToWorkspace(widget, id);
            unitOfWork.Complete();

            return createdId;
        }

        public string CreateWorkspace(WorkspaceDto workspaceDto)
        {
            var workspace = mapper.Map<Workspace>(workspaceDto);

            unitOfWork.Workspaces.Insert(workspace);
            unitOfWork.Complete();

            return workspace.Id;
        }

        public string DeleteWorkspace(string id)
        {
            //var workspace = _mapper.Map<Workspace>(workspaceDto);

            unitOfWork.Workspaces.Delete(id);
            unitOfWork.Complete();

            return id;
        }

        public string RemoveWidgetFromWorkspace(string widgetId)
        {
            unitOfWork.Workspaces.RemoveWidgetFromWorkspace(widgetId);
            unitOfWork.Complete();

            return widgetId;
        }

        public IEnumerable<WorkspaceDto> ListWorkspaces()
        {
            var res = unitOfWork.Workspaces.GetAll()
            .Select(workspace => new WorkspaceDto
            {
                Id = workspace.Id,
                Title = workspace.Title,
            });

            return res;
        }
    }
}