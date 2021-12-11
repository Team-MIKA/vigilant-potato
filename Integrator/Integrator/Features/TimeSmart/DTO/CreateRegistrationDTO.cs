using System;

namespace Integrator.Features.TimeSmart.DTO
{
    public class CreateRegistrationDTO
    {
        public string CategoryId { get; set; }
        public string OrderId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}