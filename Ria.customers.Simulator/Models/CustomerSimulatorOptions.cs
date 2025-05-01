namespace Ria.CustomerAPI.Models
{
    public class CustomerSimulatorOptions
    {
        public string BaseUrl { get; set; }
        public int StartingId { get; set; }
        public string[] FirstNames { get; set; }
        public string[] LastNames { get; set; }
    }
}
