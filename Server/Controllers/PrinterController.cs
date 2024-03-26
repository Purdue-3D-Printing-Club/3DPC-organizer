using Microsoft.AspNetCore.Mvc;
using Organizer.Server.Database;
using Organizer.Shared.Models;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrinterController : ControllerBase
{
    private readonly ILogger<PrinterController> _logger;
    private readonly OrgContext _context;

    public PrinterController(ILogger<PrinterController> logger, OrgContext orgContext)
    {
        _logger = logger;
        _context = orgContext;
    }

    [HttpGet]
    public IEnumerable<Printer> Get()
    {        
        return _context.Printers.ToList();
    }

    
    [HttpPut]
    public IActionResult CreatePrinter([FromBody] Printer printer)
    {
        // Validate the request body
        if (printer == null)
        {
            return BadRequest("Invalid printer data");
        }
        // Add the new printer to the database
        _context.Printers.Add(printer);
        _context.SaveChanges();

        return Ok(printer);
    }
}
