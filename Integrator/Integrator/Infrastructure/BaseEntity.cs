using System;

namespace Integrator.Infrastructure
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}