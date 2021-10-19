namespace integrator.Features.TimeSmart
{
    public class Cell
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        public string IdentityId { get; set; }        
        public Identity Identity { get; set; }

        public string LocationId { get; set; }        
        public Location Location { get; set; }
    }
}