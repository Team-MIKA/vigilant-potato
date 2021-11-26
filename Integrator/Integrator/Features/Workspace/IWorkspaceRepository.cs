using Integrator.Features.Workspace.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Workspace
{
    public interface IWorkspaceRepository : IGenericRepository<Workspace>
    {
        void Test();
    }
}