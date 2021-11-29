using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Widgets
{
    public class WidgetRepository : GenericRepository<Widget>, IWidgetRepository
    {
        public WidgetRepository(IntegratorContext context) : base(context)
        {
        }

        public void Test()
        {
            throw new System.NotImplementedException();
        }

    }
}