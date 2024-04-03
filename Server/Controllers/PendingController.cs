using Microsoft.AspNetCore.Mvc;

using Organizer.Server.Database;
using Organizer.Shared.Enums;
using Organizer.Shared.Models;
using Organizer.Shared.Views;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PendingController(ILogger<PendingController> logger, OrgContext context) : ControllerBase
{
    private readonly ILogger<PendingController> _logger = logger;
    private readonly OrgContext _context = context;

    [HttpGet]
    public IEnumerable<PendingJobSubmission> Get()
    {
        return _context.Jobs.Where(j => j.Status == JobState.Pending).Select(j => new PendingJobSubmission(j));
    }

    [HttpPost]
    public IActionResult CreateJob([FromBody] PendingJobSubmission submission)
    {
        Job job = new(submission);
        _context.Jobs.Add(job);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateJob(Guid id, [FromBody] Job job)
    {
        Job? existingJob = _context.Jobs.Find(job.Id);
        if (existingJob == null)
        {
            return NotFound("Job not found");
        }
        Printer? printer = _context.Printers.Find(id);
        if (printer == null)
        {
            return NotFound("Printer not found");
        }

        existingJob.Status = job.Status;
        existingJob.StartedTime = job.StartedTime;
        existingJob.Notes = job.Notes;
        existingJob.EstimatedFilament = job.EstimatedFilament;

        existingJob.Status = JobState.InProgress;
        printer.AssignedJobId = existingJob.Id;
        printer.Status = PrinterState.Printing;

        _context.SaveChanges();

        return Ok();
    }
}