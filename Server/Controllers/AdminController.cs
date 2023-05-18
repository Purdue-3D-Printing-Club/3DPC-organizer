using Microsoft.AspNetCore.Mvc;
using Organizer.Shared;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly ILogger<AdminController> _logger;
    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }
}