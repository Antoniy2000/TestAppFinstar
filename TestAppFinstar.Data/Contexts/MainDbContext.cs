using Microsoft.EntityFrameworkCore;
using TestAppFinstar.Models.Entities;

namespace TestAppFinstar.Data.Contexts;
public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options)
{
    public DbSet<SomeData> SomeData { get; set; }
}
