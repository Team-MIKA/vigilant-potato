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
        IEnumerable <WorkspaceDto> ListWorkspaces();

        WorkspaceDto GetById(string id);

        string CreateWorkspace(WorkspaceDto workspaceDto);

        string DeleteWorkspace(string id);

        string AddWidgetToWorkspace(WidgetDto widgetDto, string id);

        string RemoveWidgetFromWorkspace(string widgetId);
    }
}