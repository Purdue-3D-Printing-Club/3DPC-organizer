using Microsoft.AspNetCore.Mvc;
using Organizer.Shared.Models;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{
    private static Job[] temp_jobs = {};
    private readonly ILogger<JobController> _logger;
    public JobController(ILogger<JobController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Job[] Get()
    {
        return temp_jobs;
    }

    [HttpGet("{id}")]
    public Job? Get(string? id)
    {
        if (id == null)
        {
            return null;
        }
        for (int i = 0; i < temp_jobs.Length; i++)
        {
            if (temp_jobs[i].Id.ToString() == id)
            {
                return temp_jobs[i];
            }
        }
        return null;
    }
}