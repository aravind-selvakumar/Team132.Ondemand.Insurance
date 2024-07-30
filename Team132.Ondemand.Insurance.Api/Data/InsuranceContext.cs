using Microsoft.EntityFrameworkCore;
using Team132.Ondemand.Insurance.Api.Models;

namespace Team132.Ondemand.Insurance.Api.Data
{
    public class InsuranceContext :DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options) { }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Claim> Claims { get; set; }
    }
}
