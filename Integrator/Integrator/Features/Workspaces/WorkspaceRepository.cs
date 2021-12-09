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

        public string AddWidgetToWorkspace(Widget widget, string workspaceId)
        {
            var entityEntry = _context.WorkspaceWidgets.Add(new WorkspaceWidget
            {
                WorkspaceId = workspaceId,
                WidgetId = widget.Id
            });
            return entityEntry.Entity.Id;
        }
        
        public void RemoveWidgetFromWorkspace(string workspaceWidgetId)
        {
            var entity = _context.WorkspaceWidgets.First(x => x.Id.Equals(workspaceWidgetId));
            _context.Set<WorkspaceWidget>().Remove(entity);

        }

        public Workspace GetWorkspaceById(string id)
        {
            return _context.Workspaces.Include(prop => prop.Widgets).ThenInclude(prop => prop.Widget).First(w => w.Id.Equals(id));
        }


    }
}