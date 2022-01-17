using System.Reflection.Metadata.Ecma335;
using Integrator.Infrastructure;

namespace Integrator.Features.Widgets.Models
{
    public class Option: BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}