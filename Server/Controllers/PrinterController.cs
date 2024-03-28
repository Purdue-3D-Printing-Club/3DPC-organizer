using Microsoft.AspNetCore.Mvc;
using Organizer.Server.Database;
using Organizer.Shared.Models;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrinterController(ILogger<PrinterController> logger, OrgContext orgContext) : ControllerBase
{
    private readonly ILogger<PrinterController> _logger = logger;
    private readonly OrgContext _context = orgContext;

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

    [HttpPatch]
    public IActionResult UpdatePrinter([FromBody] Printer printer)
    {
        // Validate the request body
        if (printer == null)
        {
            return BadRequest("Invalid printer data");
        }
        // Find the printer in the database
        var existingPrinter = _context.Printers.Find(printer.Id);
        if (existingPrinter == null)
        {
            return NotFound("Printer not found");
        }
        // Update the printer in the database
        existingPrinter.Name = printer.Name;
        existingPrinter.PrinterType = printer.PrinterType;
        existingPrinter.Status = printer.Status;

        _context.SaveChanges();

        return Ok(existingPrinter);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePrinter(Guid id)
    {
        // Find the printer in the database
        var printer = _context.Printers.Find(id);
        if (printer == null)
        {
            return NotFound("Printer not found");
        }
        // Remove the printer from the database
        _context.Printers.Remove(printer);
        _context.SaveChanges();

        return Ok();
    }
}
