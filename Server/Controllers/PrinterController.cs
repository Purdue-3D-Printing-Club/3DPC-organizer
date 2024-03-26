using Microsoft.AspNetCore.Mvc;
using Organizer.Shared.Models;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrinterController : ControllerBase
{
    private readonly ILogger<PrinterController> _logger;

    public PrinterController(ILogger<PrinterController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Printer> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Printer
        {
            Id = new Guid(),
            Name = $"Printer {index}",
            Status = PrinterState.Idle,
        })
        .ToArray();
    }
}
