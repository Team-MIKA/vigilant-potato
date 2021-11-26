using Integrator.Features.Workspaces.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Workspaces
{
    public class WorkspaceRepository : GenericRepository<Workspace>, IWorkspaceRepository
    {
        public WorkspaceRepository(IntegratorContext context) : base(context)
        {
        }

        public void Test()
        {
            throw new System.NotImplementedException();
        }

    }
}