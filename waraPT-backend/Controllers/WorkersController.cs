using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waraPT_Backend.Data;
using waraPT_backend.Dtos;

namespace waraPT_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class WorkersController : ControllerBase
{
    private readonly WaraDbContext _context;

    public WorkersController(WaraDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetWorkers([FromQuery] string? dni)
    {
        var workers = await _context.WorkerList
            .FromSqlInterpolated($"CALL sp_ListWorkers({dni})")
            .ToListAsync();

        return Ok(workers);
    }

    [HttpPost]
    public async Task<IActionResult> AddWorker([FromBody] WorkerRequest request)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $"CALL sp_AddWorker({request.FirstName}, {request.LastName}, {request.Dni}, {request.Age})");

        return Ok(new { message = "Worker created successfully" });
    }
    
}