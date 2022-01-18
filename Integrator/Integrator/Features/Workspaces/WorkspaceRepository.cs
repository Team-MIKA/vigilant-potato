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
            var entityEntry = Context.WorkspaceWidgets.Add(new WorkspaceWidget
            {
                WorkspaceId = workspaceId,
                WidgetId = widget.Id
            });
            return entityEntry.Entity.Id;
        }
        
        public void RemoveWidgetFromWorkspace(string workspaceWidgetId)
        {
            var entity = Context.WorkspaceWidgets.First(x => x.Id.Equals(workspaceWidgetId));
            Context.Set<WorkspaceWidget>().Remove(entity);

        }

        public Workspace GetWorkspaceById(string id)
        {
            return Context.Workspaces
                .Include(prop => prop.Widgets)
                .ThenInclude(prop => prop.Widget).ThenInclude(w => w.Options)
                .First(w => w.Id.Equals(id));
        }


    }
}