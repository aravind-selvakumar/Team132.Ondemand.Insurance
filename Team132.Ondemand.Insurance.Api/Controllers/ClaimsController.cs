using Microsoft.AspNetCore.Mvc;
using Team132.Ondemand.Insurance.Api.Data;
using Team132.Ondemand.Insurance.Api.Models;

namespace Team132.Ondemand.Insurance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly InsuranceContext _context;

        public ClaimsController(InsuranceContext context)
        {
            _context = context;
        }

        [HttpPost("file")]
        public async Task<ActionResult<Claim>> FileClaim(Claim claim)
        {
            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClaim), new { claimId = claim.ClaimId }, claim);
        }

        [HttpGet("{claimId}")]
        public async Task<ActionResult<Claim>> GetClaim(int claimId)
        {
            var claim = await _context.Claims.FindAsync(claimId);

            if (claim == null)
            {
                return NotFound();
            }

            return claim;
        }
    }
}
