using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waraPT_Backend.Data;
using waraPT_backend.Dtos;

namespace waraPT_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly WaraDbContext _context;

    public AuthController(WaraDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var users = await _context.LoginResults
            .FromSqlInterpolated($"CALL sp_Login({request.Username}, {request.Password})")
            .ToListAsync();

        if (!users.Any())
            return Unauthorized(new { message = "Invalid username or password" });

        return Ok(users.First());
    }
}