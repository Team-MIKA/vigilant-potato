using System.Collections.Generic;
using Integrator.Features.Widgets.DTO;

namespace Integrator.Features.Workspaces.DTO
{
    public class WorkspaceDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public ICollection<WidgetDTO> Widgets { get; set; }
    }
}