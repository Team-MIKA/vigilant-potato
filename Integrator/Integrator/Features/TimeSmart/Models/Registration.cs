using System;
using Integrator.Infrastructure;

namespace Integrator.Features.TimeSmart.Models
{
    public class Registration : BaseEntity
    {
        public Registration()
        {
            Id = Guid.NewGuid().ToString();
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }
        
        public string RegistrationCategoryId { get; set; }
        public RegistrationCategory RegistrationCategory { get; set; }
        public string OrderId { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}