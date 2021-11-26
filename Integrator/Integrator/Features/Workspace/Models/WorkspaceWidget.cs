using Integrator.Infrastructure;

namespace Integrator.Features.Workspace.Models
{
    public class WorkspaceWidget : BaseEntity
    {
        public string Id { get; set; }
        public string WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }
        public string WidgetId { get; set; }
        public Widget Widget { get; set; }
    }
}