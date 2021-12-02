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
        public IActionResult ListWorkspaces()
        {
            if (!ModelState.IsValid) throw new Exception("Error retrieving list of workspaces");

            var res = _workspaceService.ListWorkspaces();

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
        public IActionResult CreateWorkspace([FromBody] WorkspaceDTO workspaceDto)
        {
            if (!ModelState.IsValid) throw new Exception("Error creating workspace");
            
            var workspace = _workspaceService.CreateWorkspace(workspaceDto);

            return Ok(workspace.Id);
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteWorkspace([FromBody] WorkspaceDTO workspaceDto)
        {
            if (!ModelState.IsValid) throw new Exception("Error deleting workspace: " + workspaceDto.Id);
            var workspace = _workspaceService.DeleteWorkspace(workspaceDto);

            return Ok(workspaceDto.Id);
        }

        [HttpPost("[action]/{id}")]
        public IActionResult AddWidgetToWorkspace([FromBody] WidgetDTO widgetDto, string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error adding widget: " + widgetDto.Id + " to workspace: " + id);

            var widgetId = _workspaceService.AddWidgetToWorkspace(widgetDto, id);

            return Ok(widgetId);
        }
        
        [HttpDelete("[action]/{id}")]
        public IActionResult RemoveWidgetFromWorkspace([FromBody] string widgetId, string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error adding widget: " + widgetId + " to workspace: " + id);

            var retId = _workspaceService.RemoveWidgetFromWorkspace(widgetId, id);

            return Ok(retId);
        }

    }
}