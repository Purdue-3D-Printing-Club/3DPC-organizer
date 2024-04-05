using Microsoft.AspNetCore.Mvc;
using Organizer.Shared.Models;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }
}
