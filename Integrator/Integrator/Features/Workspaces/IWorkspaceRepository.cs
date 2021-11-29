using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Workspaces
{
    public interface IWorkspaceRepository : IGenericRepository<Workspace>
    {
        void Test();

        void AddWidgetToWorkspace(Widget widget, string workspaceId);
        
        void RemoveWidgetFromWorkspace(string widgetId, string workspaceId);
    }
}