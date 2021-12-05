using System;

namespace Integrator.Features.TimeSmart.DTO
{
    public class RegistrationDTO
    {
        public CategoryDTO RegistrationCategory { get; set; }
        public string OrderId { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}