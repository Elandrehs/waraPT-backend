using waraPT_backend.Dtos;

namespace waraPT_Backend.Data;

using waraPT_backend.Models;
using waraPT_Backend.Models;

using Microsoft.EntityFrameworkCore;

public class WaraDbContext : DbContext
{
    public WaraDbContext(DbContextOptions<WaraDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<LoginResultDto> LoginResults { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginResultDto>().HasNoKey();
    }
}