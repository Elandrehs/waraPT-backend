using Microsoft.EntityFrameworkCore;
using WaraPTBackend.Models;

namespace WaraPTBackend.Data;

public class WaraDbContext : DbContext
{
    public WaraDbContext(DbContextOptions<WaraDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Worker> Workers { get; set; }
}