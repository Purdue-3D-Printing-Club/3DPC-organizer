using Microsoft.AspNetCore.Mvc;
using Organizer.Server.Database;
using Organizer.Shared.Enums;
using Organizer.Shared.Models;
using Organizer.Shared.Views;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController(ILogger<JobController> logger, OrgContext orgContext) : ControllerBase
{
    private readonly ILogger<JobController> _logger = logger;
    private readonly OrgContext _context = orgContext;

    [HttpGet("completed")]
    public IEnumerable<CompletedJob> Get()
    {
        // Retrieve all completed jobs from the context and map them to CompletedJob view models
        return _context
            .Jobs.Where(j => j.Status == JobState.Completed)
            .Select(j => new CompletedJob(j));
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateJob(Guid id, [FromBody] ActiveJob activeJob)
    {
        // Find the job with the specified id
        Job? job = _context.Jobs.Find(id);
        if (job == null)
        {
            return NotFound("Job not found");
        }

        // Update the job properties with the values from the activeJob parameter
        job.Status = activeJob.Status;
        job.StartedTime = activeJob.StartedTime;
        job.Notes = activeJob.Notes;
        job.EstimatedFilament = activeJob.EstimatedFilament;
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteJob(Guid id)
    {
        // Find the job with the specified id
        Job? job = _context.Jobs.Find(id);
        if (job == null)
        {
            return NotFound("Job not found");
        }

        // Remove the job from the context and save changes
        _context.Jobs.Remove(job);
        _context.SaveChanges();

        return Ok();
    }
}
