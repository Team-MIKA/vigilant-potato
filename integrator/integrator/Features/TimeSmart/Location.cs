using System.Collections;
using System.Collections.Generic;

namespace integrator.Features.TimeSmart
{
    public class Location
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IList<Identity> Identities { get; set; }
        public IList<Cell> Cells { get; set; }
    }
}