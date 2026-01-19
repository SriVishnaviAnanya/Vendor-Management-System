using GovernanceApi.Data;
using GovernanceApi.DTOs;
using GovernanceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GovernanceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PerformanceController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddPerformance(VendorPerformance p)
        {

            CalculateFinalRating(p);
            _context.VendorPerformances.Add(p);
            _context.SaveChanges();
            return Ok(p);
        }
        [HttpPut("update-sla/{vendorId}")]
        public IActionResult UpdateSLA(int vendorId,[FromBody] SLAUpdateDto dto)
        {
            //var p = _context.VendorPerformances.FirstOrDefault(x => x.VendorId == vendorId);
            var p = _context.VendorPerformances.Where(x => x.VendorId == vendorId)
                                               .OrderByDescending(x => x.PerformanceId)
                                                  .FirstOrDefault();
            if (p == null) return NotFound("Vendor performance not found");
            p.SLAAdherence = dto.SLAAdherence;
            p.SLARemarks = dto.SLARemarks;
            p.SLARatedDate =DateTime.Now;
            CalculateFinalRating(p);
                _context.SaveChanges();
            return Ok(p);

        }
        private void CalculateFinalRating(VendorPerformance p) {
            p.FinalRating = (p.DeliveryQuality + p.SLAAdherence + p.ComplianceScore) / 3;
        }
    }
}
