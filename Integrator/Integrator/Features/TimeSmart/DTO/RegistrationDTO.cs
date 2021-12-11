using System;

namespace Integrator.Features.TimeSmart.DTO
{
    public class RegistrationDTO
    {
        public string Id { get; set; }
        public CategoryDTO Category { get; set; }
        public string OrderId { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}