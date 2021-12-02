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

        string CreateWorkspace(WorkspaceDTO workspaceDto);

        string DeleteWorkspace(string id);

        string AddWidgetToWorkspace(WidgetDTO widgetDto, string id);

        string RemoveWidgetFromWorkspace(string widgetId);
    }
}