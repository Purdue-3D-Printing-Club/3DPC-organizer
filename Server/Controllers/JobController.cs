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

    [HttpGet("{id}")]
    public IActionResult GetJob(Guid id)
    {
        // Find the job with the specified id
        Job? job = _context.Jobs.Find(id);
        if (job == null)
        {
            return NotFound("Job not found");
        }

        // Return the job
        return Ok(job);
    }

    [HttpGet("active")]
    public IEnumerable<ActiveJob> GetActiveJobs()
    {
        // Retrieve all active jobs from the context and map them to ActiveJob view models
        return _context
            .Jobs.Where(j => j.Status == JobState.InProgress)
            .Select(j => new ActiveJob(j));
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

    [HttpPatch("finish/{jobId}")]
    public IActionResult FinishJob(Guid jobId)
    {
        Job? job = _context.Jobs.Find(jobId);
        if (job == null)
            return NotFound("Job not found");

        Printer? printer = _context.Printers.Find(job.AssignedPrinterId);
        if (printer == null)
            return Problem();

        printer.AssignedJobId = null;
        printer.Status = PrinterState.Idle;

        job.AssignedPrinterId = null;
        job.Status = JobState.Completed;
        job.CompletedTime = DateTime.UtcNow;

        _context.SaveChanges();
        return Ok();
    }

    [HttpPatch("fail/{jobId}")]
    public IActionResult FailJob(Guid jobId, [FromBody] string message)
    {
        Job? job = _context.Jobs.Find(jobId);
        if (job == null)
            return NotFound("Job not found");

        if (++job.FailureCount >= 3)
        {
            Printer? printer = _context.Printers.Find(job.AssignedPrinterId);
            if (printer == null)
                return Problem();

            printer.AssignedJobId = null;
            printer.Status = PrinterState.Idle;

            job.AssignedPrinterId = null;
            job.Status = JobState.Failed;
            job.CompletedTime = DateTime.UtcNow;
        }
        job.FailureNotes ??= [];
        job.FailureNotes.Append(String.Format("|Failure #{0}: {1}\n", job.FailureCount, message));

        _context.SaveChanges();
        return Ok();
    }
}
