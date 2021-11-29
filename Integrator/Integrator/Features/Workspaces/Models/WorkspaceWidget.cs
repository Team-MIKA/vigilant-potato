using Integrator.Infrastructure;

namespace Integrator.Features.Workspaces.Models
{
    public class WorkspaceWidget : BaseEntity
    {
        public string WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }
        public string WidgetId { get; set; }
        public Widget Widget { get; set; }
    }
}