using Microsoft.AspNetCore.Mvc;
using Organizer.Shared.Models;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
}
