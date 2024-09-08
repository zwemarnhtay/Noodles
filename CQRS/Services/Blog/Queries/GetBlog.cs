using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services.Blog.Queries;

public class GetBlog
{
  private readonly AppDbContext _context;

  public GetBlog(AppDbContext context)
  {
    _context = context;
  }

  public async Task<BlogModel?> Run(int blogId)
  {
    return await _context.Blogs.FirstOrDefaultAsync(x => x.Id == blogId);
  }
}
