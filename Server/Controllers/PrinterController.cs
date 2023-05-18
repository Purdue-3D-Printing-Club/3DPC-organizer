using Microsoft.AspNetCore.Mvc;
using Organizer.Shared;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("[controller]")]
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
            id = index.ToString(),
            name = $"Printer {index}",
            status = PrinterState.Idle,
        })
        .ToArray();
    }
}
