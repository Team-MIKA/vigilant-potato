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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkspaceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public WorkspaceDTO GetById(string id)
        {
            var workspace = _unitOfWork.Workspaces.GetWorkspaceById(id);
            var workspaceDto = _mapper.Map<WorkspaceDTO>(workspace);
            return workspaceDto;
        }

        public string AddWidgetToWorkspace(WidgetDTO widgetDto, string id)
        {
            var widget = _mapper.Map<Widget>(widgetDto);
            var createdId = _unitOfWork.Workspaces.AddWidgetToWorkspace(widget, id);
            _unitOfWork.Complete();

            return createdId;
        }

        public string CreateWorkspace(WorkspaceDTO workspaceDto)
        {
            var workspace = _mapper.Map<Workspace>(workspaceDto);

            _unitOfWork.Workspaces.Insert(workspace);
            _unitOfWork.Complete();

            return workspace.Id;
        }

        public string DeleteWorkspace(string id)
        {
            //var workspace = _mapper.Map<Workspace>(workspaceDto);

            _unitOfWork.Workspaces.Delete(id);
            _unitOfWork.Complete();

            return id;
        }

        public string RemoveWidgetFromWorkspace(string widgetId)
        {
            _unitOfWork.Workspaces.RemoveWidgetFromWorkspace(widgetId);
            _unitOfWork.Complete();

            return widgetId;
        }

        public IEnumerable<WorkspaceDTO> ListWorkspaces()
        {
            var res = _unitOfWork.Workspaces.GetAll()
            .Select(workspace => new WorkspaceDTO
            {
                Id = workspace.Id,
                Title = workspace.Title,
            });

            return res;
        }
    }
}