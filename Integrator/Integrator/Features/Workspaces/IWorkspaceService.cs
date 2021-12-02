using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Integrator.Features.Widgets.DTO;
using Integrator.Features.Workspaces.DTO;
using Integrator.Features.Workspaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace Integrator.Features.Workspaces
{
    public interface IWorkspaceService
    {
        IEnumerable <WorkspaceDTO> ListWorkspaces();

        WorkspaceDTO GetById(string id);

        Workspace CreateWorkspace([FromBody] WorkspaceDTO workspaceDto);

        WorkspaceDTO DeleteWorkspace([FromBody] WorkspaceDTO workspaceDto);

        string AddWidgetToWorkspace([FromBody] WidgetDTO widgetDto, string id);

        string RemoveWidgetFromWorkspace([FromBody] string widgetId, string id);
    }
}