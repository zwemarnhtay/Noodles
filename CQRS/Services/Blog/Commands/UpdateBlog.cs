using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services.Blog.Commands
{
  public class UpdateBlog
  {
    private readonly AppDbContext _context;

    public UpdateBlog(AppDbContext context)
    {
      _context = context;
    }

    public async Task<int> Run(int id, BlogModel blogModel)
    {
      var desiredBlog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);

      if (desiredBlog == null) return 0;

      desiredBlog.Title = blogModel.Title;
      desiredBlog.Content = blogModel.Content;
      desiredBlog.Author = blogModel.Author;

      return await _context.SaveChangesAsync();
    }
  }
}
