using System;
using System.Threading.Tasks;
using AutoMapper;
using Integrator.Features.Workspaces.DTO;
using Integrator.Infrastructure;

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
    }
}