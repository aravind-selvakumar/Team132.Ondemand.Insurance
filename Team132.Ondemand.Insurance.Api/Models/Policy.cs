namespace Team132.Ondemand.Insurance.Api.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string TripId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
    }
}
