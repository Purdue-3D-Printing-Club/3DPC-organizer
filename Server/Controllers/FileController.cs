using Microsoft.AspNetCore.Mvc;
using Organizer.Server.Database;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController(ILogger<JobController> logger, OrgContext orgContext) : ControllerBase
{
    private readonly ILogger<JobController> _logger = logger;
    private readonly OrgContext _context = orgContext;

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var filePath = Path.Combine("UploadedFiles", file.FileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok(new { filePath });
    }
}
