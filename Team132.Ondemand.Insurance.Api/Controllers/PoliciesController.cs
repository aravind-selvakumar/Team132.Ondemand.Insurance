using Microsoft.AspNetCore.Mvc;
using Team132.Ondemand.Insurance.Api.Data;
using Team132.Ondemand.Insurance.Api.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Team132.Ondemand.Insurance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly InsuranceContext _context;

        public PoliciesController(InsuranceContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Policy>> CreatePolicy(Policy policy)
        {
            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPolicy), new { policyId = policy.PolicyId }, policy);
        }

        [HttpGet("{policyId}")]
        public async Task<ActionResult<Policy>> GetPolicy(int policyId)
        {
            var policy = await _context.Policies.FindAsync(policyId);

            if (policy == null)
            {
                return NotFound();
            }

            return policy;
        }
    }
}
