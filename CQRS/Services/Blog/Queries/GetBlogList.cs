using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services.Blog.Queries
{
  public class GetBlogList
  {
    private readonly AppDbContext _context;

    public GetBlogList(AppDbContext context)
    {
      _context = context;
    }

    public async Task<List<BlogModel>?> Run()
    {
      return await _context.Blogs.ToListAsync();
    }
  }
}
