namespace Integrator.Features.Workspace.DTO
{
    public class WorkspaceDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<WidgetDTO> Widgets { get; set; }
    }
}