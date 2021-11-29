using System.Collections.Generic;
using Integrator.Infrastructure;

namespace Integrator.Features.Workspaces.Models
{
    public class Workspace : BaseEntity
    {
        public Workspace ()
	    {
            Widgets = new HashSet<WorkspaceWidget>();
	    }

        public string Title { get; set; }
        public ICollection<WorkspaceWidget> Widgets { get; set; }
    }

}