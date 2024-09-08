using CQRS.Models;

namespace CQRS.Services.Blog.Commands;

public class CreateBlog
{
  private readonly AppDbContext _context;

  public CreateBlog(AppDbContext context)
  {
    _context = context;
  }

  public async Task<int> Run(BlogModel blog)
  {
    await _context.Blogs.AddAsync(blog);
    return await _context.SaveChangesAsync();
  }
}
