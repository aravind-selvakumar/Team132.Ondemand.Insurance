namespace Team132.Ondemand.Insurance.Api.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string TripId { get; set; } = string.Empty;
        public int PolicyId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
