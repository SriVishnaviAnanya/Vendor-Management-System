using GovernanceApi.Data;
using GovernanceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GovernanceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NonComplianceLogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NonComplianceLogController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/NonComplianceLog
        // This lets you see the data (currently empty in your SQL screenshot)
        [HttpGet]
        public IActionResult GetLogs()
        {
            var logs = _context.NonComplianceLogs.ToList();
            return Ok(logs);
        }

        // POST: api/NonComplianceLog
        // This lets you add new logs via Swagger
        [HttpPost]
        public IActionResult AddLog([FromBody] NonComplianceLog log)
        {
            // Optional: Set default date if user doesn't provide it
            if (log.CreatedDate == default)
            {
                log.CreatedDate = System.DateTime.Now;
            }

            _context.NonComplianceLogs.Add(log);
            _context.SaveChanges();
            return Ok(log);
        }
    }
}

