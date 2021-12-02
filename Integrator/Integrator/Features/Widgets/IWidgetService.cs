using Integrator.Features.Widgets.DTO;
using Integrator.Features.Widgets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integrator.Features.Widgets
{
    public interface IWidgetService
    {
        string CreateWidget(WidgetDTO widgetDto);

        IEnumerable <WidgetDTO> ListWidgets();

        string DeleteWidget(string id);
    }
}
