using Microsoft.AspNetCore.Mvc;
using Organizer.Shared.Models;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/job")]
public class JobController : ControllerBase
{
    private static Job[] temp_jobs = { // temporary until I get a database setup
        new Job {
            id = "job1",
            userSubmittingId = "usr1",
            supervisorId = "sup1",
            status = JobState.Pending,
            files = new string[] { "filepath1" },
            notes = "notes",
            estimatedFilament = 1.2f
        },
        new Job {
            id = "job2",
            userSubmittingId = "usr2",
            supervisorId = "sup2",
            status = JobState.InProgress,
            files = new string[] { "filepath1", "filepath2" },
            notes = "notes",
            estimatedFilament = 123.45f
        },
    };
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
            if (temp_jobs[i].id == id)
            {
                return temp_jobs[i];
            }
        }
        return null;
    }
}