using Integrator.Features.Widgets.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Widgets
{
    public interface IWidgetRepository : IGenericRepository<Widget>
    {
        void Test();
    }
}