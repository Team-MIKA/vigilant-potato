using Integrator.Features.Workspaces.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Workspaces
{
    public interface IWorkspaceRepository : IGenericRepository<Workspace>
    {
        void Test();
    }
}