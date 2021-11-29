using Integrator.Infrastructure;

namespace Integrator.Features.Widgets
{
    public interface IWidgetRepository : IGenericRepository<Widget>
    {
        void Test();
    }
}