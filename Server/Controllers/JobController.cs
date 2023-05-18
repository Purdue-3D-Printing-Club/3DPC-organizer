using Microsoft.AspNetCore.Mvc;
using Organizer.Shared;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/job")]
public class JobController : ControllerBase
{
    private readonly ILogger<JobController> _logger;
    public JobController(ILogger<JobController> logger)
    {
        _logger = logger;
    }
}