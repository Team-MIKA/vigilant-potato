using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Integrator.Features.Workspace.DTO;
using Integrator.Features.Workspace.Models;
using Integrator.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Integrator.Features.Workspace
{
    [ApiController]
    [Route("[controller]")]
    public class WorkspaceController : ControllerBase
    {
        private readonly ILogger<WorkspaceController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkspaceController(ILogger<WorkspaceController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<WorkspaceDTO> ListWorkspaces()
        {
            return _unitOfWork.Workspace.ListAll()
                .Select(workspace => new WorkspaceDTO
                {
                    Id = workspace.Id,
                    Title = workspace.Title,
                });
        }

        [HttpGet("workspace/{id}")]
        public WorkspaceDTO GetById(string id)
        {
            var workspace = _unitOfWork.Workspace.GetById(id);

            var workspaceDTO = _mapper.Map<WorkspaceDTO>(workspace);

            return workspaceDTO;
        }

        [HttpPost("workspace")]
        public string CreateWorkspace([FromBody] WorkspaceDTO workspaceDTO)
        {
            var workspace = _mapper.Map<Workspace>(workspaceDTO);

            _unitOfWork.Workspace.Insert(workspace);
           
            return workspace.Id;
        }

        [HttpDelete("workspace/{id}")]
        public WorkspaceDTO DeleteWorkspace(string id)
        {
            _unitOfWork.Workspace.Delete(id);

            return id;
        }

        //[HttpPost("workspace/{id}")]
        //public string AddWidgetToWorkspace([FromBody] WidgetDTO widgetDTO, string id)
        //{
        //    var workspaceWidget = new WorkspaceWidget
        //    {
        //        WidgetId = widgetDTO.Id,
        //        WorkspaceId = id,
        //    }
        //    _unitOfWork.Workspace.Insert(workspaceWidget);

        //    return id;
        //}
    }
}