using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<BlogModel> Blogs { get; set; }
}
