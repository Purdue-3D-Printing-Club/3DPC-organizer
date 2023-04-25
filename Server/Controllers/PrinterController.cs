using Microsoft.AspNetCore.Mvc;
using _3DPC_Server.Shared;

namespace BlazorWebAssemblySignalRApp.Server.Controllers;

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
        return Enumerable.Range(0, 5).Select(index => new Printer
        {
            Name = $"Printer {index}",
            Print = $"Print {index}",
            Status = $"Status {index}"
        });
    }
}