using System.Linq;
using Integrator.Features.Widgets.DTO;
using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces.Models;
using Integrator.Infrastructure;
using Microsoft.EntityFrameworkCore;

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

        public void AddWidgetToWorkspace(Widget widget, string workspaceId)
        {
            _context.WorkspaceWidgets.Add(new WorkspaceWidget
            {
                WorkspaceId = workspaceId,
                WidgetId = widget.Id
            });
        }
        
        public void RemoveWidgetFromWorkspace(string widgetId, string workspaceId)
        {
            var entity = _context.WorkspaceWidgets.First(x => x.WidgetId.Equals(widgetId));
            _context.Set<WorkspaceWidget>().Remove(entity);

        }
        
        

    }
}