using System.Collections.Generic;
using Integrator.Features.Widgets.Models;

namespace Integrator.Features.Widgets.DTO
{
    public class WidgetDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Integration Type { get; set; }
        public string Url { get; set; }

    }
}