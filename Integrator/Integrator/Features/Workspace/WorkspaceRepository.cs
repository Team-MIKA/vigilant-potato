using System.Linq;
using System.Runtime.CompilerServices;
using Integrator.Features.Workspace.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Workspace
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