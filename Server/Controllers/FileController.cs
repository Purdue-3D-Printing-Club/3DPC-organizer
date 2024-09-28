using Microsoft.AspNetCore.Mvc;
using Organizer.Server.Database;

namespace Organizer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController(ILogger<JobController> logger, IConfiguration configuration)
    : ControllerBase
{
    private readonly ILogger<JobController> _logger = logger;
    private readonly string _folderPath =
        configuration.GetSection("FileStorageSettings").GetValue<string>("FolderPath") ?? "";

    [HttpGet("{filename}")]
    public IActionResult DownloadFile(string filename)
    {
        if (filename == null)
            return BadRequest("No filepath provided");

        string filePath = Path.ChangeExtension(Path.Combine(_folderPath, filename), ".stl");
        var memory = new MemoryStream();
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            stream.CopyTo(memory);
        }
        memory.Position = 0;

        return File(memory, "model/stl", filename);
    }

    [HttpPut]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");
        _logger.LogInformation("File: {0} | {1}", file.FileName, file.Length);

        string filePath = Path.Combine(_folderPath, file.FileName);
        if (!Directory.Exists(_folderPath))
            Directory.CreateDirectory(_folderPath);

        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        string fileName = Path.GetFileNameWithoutExtension(filePath);
        _logger.LogInformation("File uploaded at {filePath}", filePath);

        return Ok(new { fileName });
    }
}
