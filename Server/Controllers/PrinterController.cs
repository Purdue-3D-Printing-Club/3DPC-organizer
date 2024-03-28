using Microsoft.AspNetCore.Mvc;
using Organizer.Server.Database;
using Organizer.Shared.Models;
using Organizer.Shared.Views;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrinterController(ILogger<PrinterController> logger, OrgContext orgContext) : ControllerBase
{
    private readonly ILogger<PrinterController> _logger = logger;
    private readonly OrgContext _context = orgContext;

    [HttpGet]
    public IEnumerable<PrinterOverview> Get()
    {
        // Retrieve a list of printer overviews
        List<PrinterOverview> printerOverviews = [];

        // Iterate through each printer in the context
        foreach (Printer printer in _context.Printers)
        {
            // Find the assigned job for the printer
            Job? job = _context.Jobs.Find(printer.AssignedJobId);

            // Create a new PrinterOverview object and add it to the list
            printerOverviews.Add(new PrinterOverview(printer, job));
        }

        // Return the list of printer overviews
        return printerOverviews;
    }

    [HttpGet("{id}")]
    public IActionResult GetPrinter(Guid id)
    {
        // Find the printer in the database
        Printer? printer = _context.Printers.Find(id);
        if (printer == null)
        {
            return NotFound("Printer not found");
        }

        // Find the assigned job for the printer
        Job? job = _context.Jobs.Find(printer.AssignedJobId);

        // Create a new PrinterDetail object
        PrinterDetail printerDetail = new PrinterDetail(printer, job);

        // Return the printer detail
        return Ok(printerDetail);
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
        Printer? existingPrinter = _context.Printers.Find(printer.Id);
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
        Printer? printer = _context.Printers.Find(id);
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
