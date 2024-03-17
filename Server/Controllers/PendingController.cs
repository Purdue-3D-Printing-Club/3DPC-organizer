using Microsoft.AspNetCore.Mvc;
using Organizer.Shared.Models;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PendingController : ControllerBase
{
    private readonly ILogger<PendingController> _logger;
    public PendingController(ILogger<PendingController> logger)
    {
        _logger = logger;
    }
}