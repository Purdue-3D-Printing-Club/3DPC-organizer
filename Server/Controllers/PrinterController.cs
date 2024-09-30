using Microsoft.AspNetCore.Mvc;
using Organizer.Server.Database;
using Organizer.Shared.Enums;
using Organizer.Shared.Models;
using Organizer.Shared.Views;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrinterController(ILogger<PrinterController> logger, OrgContext orgContext)
    : ControllerBase
{
    private readonly ILogger<PrinterController> _logger = logger;
    private readonly OrgContext _context = orgContext;

    [HttpGet]
    public IEnumerable<PrinterDetail> Get()
    {
        // Retrieve a list of printer overviews
        List<PrinterDetail> PrinterDetails = [];

        // Iterate through each printer in the context
        foreach (Printer printer in _context.Printers)
        {
            // Find the assigned job for the printer
            Job? job = _context.Jobs.Find(printer.AssignedJobId);

            // Create a new PrinterDetail object and add it to the list
            PrinterDetails.Add(new PrinterDetail(printer, job));
        }

        // Return the list of printer overviews
        return PrinterDetails;
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

    [HttpGet("available")]
    public IEnumerable<Printer> GetAvailablePrinters()
    {
        // Retrieve a list of available printers
        List<Printer> availablePrinters = [];

        // Iterate through each printer in the context
        foreach (Printer printer in _context.Printers)
        {
            // Check if the printer is available
            if (printer.Status == PrinterState.Idle)
            {
                // Add the printer to the list of available printers
                availablePrinters.Add(printer);
            }
        }

        // Return the list of available printers
        return availablePrinters;
    }

    [HttpPut]
    public IActionResult CreatePrinter([FromBody] NewPrinter printer)
    {
        if (printer == null)
        {
            return BadRequest("Invalid printer data");
        }

        Printer newPrinter = new Printer(printer.Name, printer.PrinterType);

        _context.Printers.Add(newPrinter);
        _context.SaveChanges();

        return Ok(printer);
    }

    [HttpPatch]
    public IActionResult UpdatePrinter([FromBody] PrinterDetail printer)
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
            return Problem("Printer not found");
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
