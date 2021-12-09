using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Integrator.Features.Widgets.DTO;
using Integrator.Features.Workspaces.DTO;
using Integrator.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Integrator.Features.Workspaces
{
    [ApiController]
    [Route("[controller]")]
    public class WorkspaceController : ControllerBase
    {
        private readonly ILogger<WorkspaceController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWorkspaceService workspaceService;

        public WorkspaceController(ILogger<WorkspaceController> logger, IUnitOfWork unitOfWork, IMapper mapper, IWorkspaceService workspaceService)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.workspaceService = workspaceService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorkspaceDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListWorkspaces()
        {
            if (!ModelState.IsValid) throw new Exception("Error retrieving list of workspaces");

            var res = workspaceService.ListWorkspaces();

            return Ok(res);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorkspaceDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error getting workspace by id: " + id);

            var workspaceDto = workspaceService.GetById(id);

            return Ok(workspaceDto);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateWorkspace([FromBody] WorkspaceDto workspaceDto)
        {
            if (!ModelState.IsValid) throw new Exception("Error creating workspace");
            
            var id = workspaceService.CreateWorkspace(workspaceDto);

            return Ok(id);
        }

        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteWorkspace(string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error deleting workspace: " + id);

            var deletedId = workspaceService.DeleteWorkspace(id);

            return Ok(deletedId);
        }

        [HttpPost("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddWidgetToWorkspace([FromBody] WidgetDto widgetDto, string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error adding widget: " + widgetDto.Id + " to workspace: " + id);

            var widgetId = workspaceService.AddWidgetToWorkspace(widgetDto, id);

            return Ok(widgetId);
        }
        
        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoveWidgetFromWorkspace(string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error removing widget" + id);

            var retId = workspaceService.RemoveWidgetFromWorkspace(id);

            return Ok(retId);
        }
    }
}