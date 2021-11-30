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
using Microsoft.Extensions.Logging;

namespace Integrator.Features.Workspaces
{
    [ApiController]
    [Route("[controller]")]
    public class WorkspaceController : ControllerBase
    {
        private readonly ILogger<WorkspaceController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWorkspaceService _workspaceService;

        public WorkspaceController(ILogger<WorkspaceController> logger, IUnitOfWork unitOfWork, IMapper mapper, IWorkspaceService workspaceService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _workspaceService = workspaceService;
        }

        [HttpGet]
        public async Task<IActionResult> ListWorkspaces()
        {
            if (!ModelState.IsValid) throw new Exception("Error retrieving list of workspaces");
            
            var res = _unitOfWork.Workspaces.ListAll()
                .Select(workspace => new WorkspaceDTO
                {
                    Id = workspace.Id,
                    Title = workspace.Title,
                });
            return Ok(res);

        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetById(string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error getting workspace by id: " + id);

            var workspaceDto = _workspaceService.GetById(id);

            return Ok(workspaceDto);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateWorkspace([FromBody] WorkspaceDTO workspaceDto)
        {
            if (!ModelState.IsValid) throw new Exception("Error creating workspace");
            var workspace = _mapper.Map<Workspace>(workspaceDto);

            _unitOfWork.Workspaces.Insert(workspace);
            _unitOfWork.Complete();
           
            return Ok(workspace.Id);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteWorkspace([FromBody] WorkspaceDTO workspaceDto)
        {
            if (!ModelState.IsValid) throw new Exception("Error deleting workspace: " + workspaceDto.Id);
            var workspace = _mapper.Map<Workspace>(workspaceDto);
            
            _unitOfWork.Workspaces.Delete(workspace);
            _unitOfWork.Complete();

            return Ok(workspaceDto.Id);
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> AddWidgetToWorkspace([FromBody] WidgetDTO widgetDto, string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error adding widget: " + widgetDto.Id + " to workspace: " + id);
            
            var widget = _mapper.Map<Widget>(widgetDto);
            _unitOfWork.Workspaces.AddWidgetToWorkspace(widget, id);
            _unitOfWork.Complete();

            return Ok(id);
        }
        
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemoveWidgetFromWorkspace([FromBody] string widgetId, string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error adding widget: " + widgetId + " to workspace: " + id);
            
            
            _unitOfWork.Workspaces.RemoveWidgetFromWorkspace(widgetId, id);
            _unitOfWork.Complete();

            return Ok(id);
        }

    }
}