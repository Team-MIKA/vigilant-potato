using System.Threading.Tasks;
using Integrator.Features.Workspaces.DTO;

namespace Integrator.Features.Workspaces
{
    public interface IWorkspaceService
    {
        WorkspaceDTO GetById(string id);
    }
}