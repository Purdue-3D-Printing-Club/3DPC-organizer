using Microsoft.AspNetCore.Mvc;
using Organizer.Server.Database;
using Organizer.Shared.Enums;
using Organizer.Shared.Models;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController(ILogger<AdminController> logger, OrgContext orgContext)
    : ControllerBase
{
    private readonly ILogger<AdminController> _logger = logger;
    private readonly OrgContext _context = orgContext;

    [HttpPatch("{printerId}")]
    public IActionResult PrinterState(Guid printerId, [FromBody] PrinterState state)
    {
        Printer? printer = _context.Printers.Find(printerId);
        if (printer == null)
            return Problem();

        printer.Status = state;
        _context.SaveChanges();

        return Ok();
    }
}
