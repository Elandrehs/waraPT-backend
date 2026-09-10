using Microsoft.EntityFrameworkCore;
using waraPT_backend.Models;
using waraPT_Backend.Models;

namespace waraPT_Backend.Data;

public class WaraDbContext : DbContext
{
    public WaraDbContext(DbContextOptions<WaraDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Worker> Workers { get; set; }
}