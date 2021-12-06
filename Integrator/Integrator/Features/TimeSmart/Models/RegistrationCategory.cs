using System;
using Integrator.Infrastructure;

namespace Integrator.Features.TimeSmart.Models
{
    public class RegistrationCategory : BaseEntity
    {
        public RegistrationCategory()
        {
            Id = Guid.NewGuid().ToString();
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }
        public string Text { get; set; }
    }
}