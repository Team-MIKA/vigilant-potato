using System.Collections.Generic;
using System.Linq;
using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces.Models;
using Integrator.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Integrator.Features.Widgets
{
    public class WidgetRepository : GenericRepository<Widget>, IWidgetRepository
    {
        public WidgetRepository(IntegratorContext context) : base(context)
        {
        }

        public new IEnumerable<Widget> ListAll() => _context.Widgets.Include(w => w.Options).ToList();
        

        public void Test()
        {
            throw new System.NotImplementedException();
        }

    }
}