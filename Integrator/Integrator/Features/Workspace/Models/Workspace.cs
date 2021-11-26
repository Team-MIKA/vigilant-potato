using Integrator.Infrastructure;

namespace Integrator.Features.Workspace.Models
{
    public class Workspace : BaseEntity
    {
        public Workspace ()
	    {
            Widgets = new HashSet<Widget>();
	    }

        public string Title { get; set; }
        public string Id { get; set; }
        public ICollection<WorkspaceWidget> Widgets { get; set; }
    }

}