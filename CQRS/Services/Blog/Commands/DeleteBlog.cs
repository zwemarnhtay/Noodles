using Microsoft.EntityFrameworkCore;

namespace CQRS.Services.Blog.Commands;

public class DeleteBlog
{
  private readonly AppDbContext _context;

  public DeleteBlog(AppDbContext context)
  {
    _context = context;
  }

  public async Task<int> Run(int id)
  {
    var desiredBlog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);

    if (desiredBlog is null) return 0;

    _context.Blogs.Remove(desiredBlog);
    return await _context.SaveChangesAsync();
  }
}
